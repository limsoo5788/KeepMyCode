using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OracleDBConnect_Winform
{
    //DataTable형태로 넘어오는것을 전제로

    class CustomOracleConnecter
    {
        OracleConnection conn = new OracleConnection();
        //LocalDataBase
        string DEFAULT_CONNECT = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = isetda) )); User Id=isi;Password=5788;";
        //"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = isetda) )); User Id=isi;Password=5788;"
        //"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = isetda) )); User Id=isi;Password=5788;"
        public CustomOracleConnecter()
        {
            conn.ConnectionString = DEFAULT_CONNECT;
        }
        public CustomOracleConnecter(string NewConnString)
        {
            //conn.ConnectionString =  NewConnString;
            conn.ConnectionString = NewConnString;
        }
        public string ConnectCheck(Dictionary<string, string> NewConnData)
        {
            string NewSource = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = " + NewConnData["protocol"] + ")(HOST = " + NewConnData["host"] + ")(PORT = " + NewConnData["port"] + ")) (CONNECT_DATA =(SERVER = " + NewConnData["server"] + ")(SERVICE_NAME = " + NewConnData["servicename"] + ") )); User Id=" + NewConnData["id"] + ";Password=" + NewConnData["pw"] + ";";
            conn.ConnectionString = NewSource;
            try
            {
                conn.Open();
                conn.Clone();
                return NewSource;
            }
            catch (Exception ex)
            {
                conn.Clone();
                NewSource = "";
                return "";
            }

        }

        private bool OracleTran(string[] Querys)
        {
            //TODO: InsertRecord 안에 쿼리실행문, CreateTable 안에있는 쿼리 실행문

            //출처: https://docs.microsoft.com/ko-kr/dotnet/api/system.data.oracleclient.oracleconnection.begintransaction?view=netframework-4.8
            //insert, update 같은 DML에서만 가능할 듯 하다 즉. 테이블로 리턴값이 돌아오지 않는 것들
            using (OracleCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                OracleTransaction transaction;

                // Start a local transaction
                transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                cmd.Transaction = transaction;

                try
                {
                    foreach (string Query in Querys)
                    {
                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();

                    //TODO: 가끔씩 2번 실행된다
                    DialogResult dialogResult = MessageBox.Show("성공적으로 처리되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Close();
                    return true;
                    //Console.WriteLine("Both records are written to database.");
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    DialogResult dialogResult = MessageBox.Show("에러가 발생하여 실행 취소되었습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return false;
                    //Console.WriteLine(e.ToString());
                    //Console.WriteLine("Neither record was written to database.");
                }

            }
        }

        //Export
        private DataTable GetSimpleQueryResult(string Query)
        {

            //실패시 반환용
            DataTable dataTable = new DataTable();

            try
            {
                using (OracleCommand cmd = new OracleCommand(Query, conn))
                {
                    conn.Open();
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        conn.Close();
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: 외부로 직접적인 에러 메세지 노출되지 않도록 하기
                //MessageBox.Show(ex.Message);
                conn.Close();
                return dataTable;
            }
        }

        public DataTable FilteredQuery(string Query)
        {
            DataTable ResultTable = new DataTable();
            string SQLType = string.Empty;
            if (Query.Length < 6)
            {
                //SQL문이 6자보다 작을때
                SQLType = "trash";
            }
            else
            {
                //정상
                SQLType = Query.Substring(0, 6).ToUpper();
            }
            string[] NoTransaction = { "SELECT", "DELETE" };
            string[] NeedTransaction = { "UPDATE", "INSERT", "CREATE" };
            //뒤에 세미콜론 제거
            if (Query.Substring(Query.Length - 1).Equals(";"))
            {
                Query = Query.Substring(0, Query.Length - 1);
            }

            if (NoTransaction.Contains(SQLType))
            {
                ResultTable = GetSimpleQueryResult(Query);
                return ResultTable;
            }
            else if (NeedTransaction.Contains(SQLType))
            {
                OracleTran(Query.Split(';'));
                return ResultTable;
            }
            else
            {
                //이후 추가 필요하면 추가
                DialogResult dialogResult = MessageBox.Show("SQL: " + Query + "\n지정되지않은 SQL문 입니다", "실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ResultTable;
            }
        }
        public void FilteredQuery(string[] Querys)
        {
            OracleTran(Querys);
        }

        public string[] GetColumnsName()
        {
            DataTable MyTables = FilteredQuery("select * from tab;");

            return GetColumnsName(MyTables);
        }

        private string[] GetColumnsName(DataTable dataSource)
        {
            int dt_cols_count = dataSource.Columns.Count;

            string[] Columns = new string[dt_cols_count];
            //컬럼명 가져오기
            for (int ColumnNum = 0; ColumnNum < dt_cols_count; ColumnNum++)
            {
                Columns[ColumnNum] = dataSource.Columns[ColumnNum].ColumnName;
            }

            return Columns;
        }

        public void ImportDataTable(DataTable dataSource, string sheetname)
        {
            int dt_rows_count = dataSource.Rows.Count;//데이터 테이블의 행 수 얻기
            int dt_cols_count = dataSource.Columns.Count;//데이터 테이블의 칼럼 수 얻기

            string[] Columns = GetColumnsName(dataSource);
            string[][] Rows = new string[dt_cols_count][];

            if (dt_rows_count > 0)//데이터 테이블의 크기가 0보다 크다면
            {
                Rows = new string[dt_rows_count][];//행만큼의 2차원 배열 생성
                for (int i = 0; i < dt_rows_count; i++)
                {
                    Rows[i] = new string[dt_cols_count];//해당 행만큼 세부 1차원 배열 생성
                }

                for (int i = 0; i < dt_rows_count; i++)
                {
                    for (int j = 0; j < dt_cols_count; j++)
                    {
                        Rows[i][j] = Convert.ToString(dataSource.Rows[i][j]);//데이터를 생성한 배열에 저장
                    }
                }
            }

            string TableName = sheetname;
            if (!HasTable(TableName))
            {
                //만들어둔 테이블이 없다면
                CreateTable(TableName, Columns);
            }
            InsertRecord(TableName, Columns, Rows);
        }
        private void InsertRecord(string TableName, string[] Columns, string[][] Rows)
        {
            string[] Querys = new string[Rows.Length];
            for (int column = 0; column < Rows.Length; column++)
            {
                string Query = "";
                Query += "insert into " + TableName;
                Query += "(";
                Query += Columns[0];
                for (int num = 1; num < Columns.Length; num++)
                {
                    Query += ", " + Columns[num];
                }
                Query += ")";
                Query += " values ";
                Query += "(";
                Query += "'" + Rows[column][0] + "'";

                for (int row = 1; row < Rows[column].Length; row++)
                {
                    Query += ", " + "'" + Rows[column][row] + "'";
                }

                Query += ")";
                Querys[column] = Query;
            }
            FilteredQuery(Querys);
        }

        private void CreateTable(string TableName, string[] Columns)
        {
            //TODO: 사용자에게 테이블명과 컬럼자료형을 고를 수 있게
            string Query = "";
            Query += "create table " + TableName;
            Query += "(";
            Query += Columns[0] + " varchar2(33)";
            for (int num = 1; num < Columns.Length; num++)
            {
                Query += ", " + Columns[num] + " varchar2(33)";
            }
            Query += ")";
            FilteredQuery(Query);
        }

        private bool HasTable(string TableName)
        {
            //db에 해당 테이블이 있는지 확인
            TableName = TableName.ToUpper();
            string Query = "select count(*) from all_tables where table_name = '" + TableName + "'";
            DataTable QueryResult = GetSimpleQueryResult(Query);
            if (QueryResult.Rows[0][0].ToString().Equals("0"))
            {
                //테이블이 없다면
                return false;
            }
            else
            {
                //테이블이 있다면
                return true;
            }
        }
        private List<string> GetTargetRowList(DataTable dataTable, string ColumnName)
        {
            List<string> list = new List<string>();
            ColumnName = ColumnName.ToUpper();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName.Equals(ColumnName))
                    {
                        list.Add(row[column].ToString());
                    }
                }
            }

            return list;
        }

        public List<string> GetTableNames()
        {
            DataTable MyTables = FilteredQuery("select * from tab where tabtype='TABLE';");

            return GetTargetRowList(MyTables, "TNAME");
        }

        public DataTable GetTable(string TableName)
        {
            return FilteredQuery("select * from " + TableName);
        }
    }
}
