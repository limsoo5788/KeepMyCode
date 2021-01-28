using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FTP
{
    class CustomOracleConnecter
    {
        //ODP.Net 참조 필요
        //Oracle.ManageddataAccess.dll

        OracleConnection Conn = new OracleConnection();
        //DB접속을 위한 tns설정
        static string User = "isi";
        static string Password = "5788";
        string DEFAULT_CONNECT = string.Format("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = isetda) )); User Id={0};Password={1};", User, Password);

        //기본 생성자
        public CustomOracleConnecter()
        {
            //기본 생성자는 제 컴퓨터에 맞춰서 설정
            Conn.ConnectionString = DEFAULT_CONNECT;
        }

        //(생성자 오버로딩)새로운 tns설정을 위한 
        public CustomOracleConnecter(string NewConnString)
        {
            //tns설정을 인자로 받은경우 해당 설정으로 tns설정 변경
            Conn.ConnectionString = NewConnString;
        }

        //트랜잭션이 필요한 쿼리를 실행
        private bool OracleTran(string[] Querys)
        {
            //INSERT, UPDATE, DELETE 는 트랜잭션으로 쿼리를 실행 
            //출처: https://docs.microsoft.com/ko-kr/dotnet/api/system.data.oracleclient.oracleconnection.begintransaction?view=netframework-4.8
            using (OracleCommand Command = Conn.CreateCommand())
            {
                Conn.Open();
                OracleTransaction Transaction;

                // 트랜잭션 생성
                Transaction = Conn.BeginTransaction(IsolationLevel.ReadCommitted);
                Command.Transaction = Transaction;
                try
                {
                    //쿼리 배열을 받았기 때문에 한줄씩 트랜잭션에 입력 후 실행
                    foreach (string Query in Querys)
                    {
                        Command.CommandText = Query;
                        Command.ExecuteNonQuery();
                    }
                    //모두 실행됬다면 커밋
                    Transaction.Commit();

                    MessageBox.Show("트랜젝션이 성공적으로 처리되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Conn.Close();

                    //성공했으므로 True 반환
                    return true;
                }
                catch (Exception ex)
                {
                    //실행중 실패하면 트랜젝션 롤백
                    Transaction.Rollback();

                    MessageBox.Show("트랜젝션에 에러가 발생하여 실행 취소되었습니다.", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Conn.Close();

                    //실패했으므로 False 반환
                    return false;
                }

            }
        }

        //트랜잭션이 필요없는 쿼리를 실행
        private DataTable GetSimpleQueryResult(string Query)
        {
            //반환용 DataTable
            DataTable Table = new DataTable();
            try
            {
                using (OracleCommand Cmd = new OracleCommand(Query, Conn))
                {
                    Conn.Open();
                    using (OracleDataReader Reader = Cmd.ExecuteReader())
                    {
                        Table.Load(Reader);
                        Conn.Close();
                        return Table;
                    }
                }
            }
            catch (Exception ex)
            {
                Conn.Close();
                return Table;
            }
        }

        //쿼리문을 필터링
        //이곳에서 트랜잭션으로 실행여부 결정
        public DataTable FilteredQuery(string Query)
        {
            DataTable ResultTable = new DataTable();
            string SQLType = string.Empty;
            if (Query.Length < 6)
            {
                //SQL문이 6자보다 작을때 (에러방지)
                SQLType = "trash";
            }
            else
            {
                //정상
                SQLType = Query.Substring(0, 6).ToUpper();
            }

            //트랜잭션이 필요없는 쿼리
            string[] NoTransaction = { "SELECT", "DELETE" };
            //트랜잭션이 필요한 쿼리
            string[] NeedTransaction = { "UPDATE", "INSERT", "CREATE" };

            //뒤에 세미콜론 제거 (에러방지)
            if (Query.Substring(Query.Length - 1).Equals(";"))
            {
                Query = Query.Substring(0, Query.Length - 1);
            }

            //트랜잭션 없이 실행
            if (NoTransaction.Contains(SQLType))
            {
                ResultTable = GetSimpleQueryResult(Query);
                return ResultTable;
            }
            //트랜잭션으로 실행
            else if (NeedTransaction.Contains(SQLType))
            {
                OracleTran(Query.Split(';'));
                return ResultTable;
            }
            //문제가있는 쿼리 처리
            else
            {
                //이후 추가 필요하면 추가
                DialogResult Dialog = MessageBox.Show("SQL: " + Query + "\n지정되지않은 SQL문 입니다", "실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ResultTable;
            }
        }

        //쿼리가 한줄이 아닌경우 사용하기 위한 필터링 오버로딩
        //TODO: 모든 쿼리에 대해 필터링을 한번 거칠 필요가 있어보인다.<<쓰레기 쿼리가 들어가 있을 수 있기 때문에
        public void FilteredQuery(string[] Querys)
        {
            OracleTran(Querys);
        }

        //DataTable 내용을 OracleDB에 sheetname에 Import
        private void InsertDataTable(DataTable dataSource, string TableName)
        {
            //날짜 포멧
            //TO_DATE('2021-01-12 오전 10:10:19', 'yyyy-mm-dd am hh:mi:ss')
            //insert into D_PRODUCT(PROD_CATEGORY, PROD_DIVISION, PROD_DIVISION_DETAIL, PROD_CLASS, ZENDER, SUB_CLASS, ITEM_NM, PRICE, ITEM_ID, INSERT_TM, QUANTITY) values ('', '', '', '', '', '', '', '22222', '4444', TO_DATE('2021-01-12 오전 10:10:19', 'yyyy-mm-dd am hh:mi:ss'), '')

            //앞+컬럼+벨류 를 덩어리로만들어서 넣어야할듯

            /*
                0, 행 수 만큼 반복한다
                1. 쿼리를 생성한다(insert into ****)
                1.1. 빈 string 두개를 만든다
                    1.2. 컬럼 수 만큼 반복한다
                        1.2.1. 컬럼의 데이터 타입을 알아낸다
                        1.2.2, 데이터 타입에 따라서 value를 결정한다
                        1.2.3. 각각 컬럼과 value에 넣는다
                    1.3. 두개의 string을 쿼리에 넣는다
                2. 쿼리를 실행한다
             */
            string[] Querys = new string[dataSource.Rows.Count];

            for (int RowIndex = 0; RowIndex < dataSource.Rows.Count; RowIndex++)
            {
                string Query = string.Empty;
                string Columns = string.Empty;
                string Values = string.Empty;
                for (int ColumnIndex = 0; ColumnIndex < dataSource.Columns.Count; ColumnIndex++)
                {
                    Columns += dataSource.Columns[ColumnIndex].ColumnName;
                    //데이터 타입에 따른 예외처리 구간 (필요시 추가)
                    if (!string.IsNullOrWhiteSpace(dataSource.Rows[RowIndex][ColumnIndex].ToString()))
                    {
                        if (dataSource.Columns[ColumnIndex].DataType == Type.GetType("System.String"))
                        {
                            Values += string.Format("'{0}'", dataSource.Rows[RowIndex][ColumnIndex].ToString());
                        }
                        else if (dataSource.Columns[ColumnIndex].DataType == Type.GetType("System.Int32"))
                        {
                            Values += string.Format("{0}", dataSource.Rows[RowIndex][ColumnIndex].ToString());
                        }
                        else if (dataSource.Columns[ColumnIndex].DataType == Type.GetType("System.DateTime"))
                        {
                            //데이터 타입이라면
                            Values += string.Format("TO_DATE('{0}', '{1}')", dataSource.Rows[RowIndex][ColumnIndex].ToString(), "yyyy-mm-dd am hh:mi:ss");
                        }
                    }
                    else
                    {
                        Values += "NULL";
                    }
                    if (ColumnIndex < dataSource.Columns.Count - 1)
                    {
                        //다음에도 항목이 있다면 쉼표 붙이기
                        Columns += ", ";
                        Values += ", ";
                    }
                }
                Query = string.Format("insert into {0} ({1}) values ({2})", TableName, Columns, Values);
                Querys[RowIndex] = Query;
            }
            FilteredQuery(Querys);
        }

        //특정 테이블의 DataTable을 반환
        public DataTable GetFilterProductTable(string TableName)
        {
            if (TableName.ToLower().Equals("d_product"))
            {
                string Query = @"select
                                    item_id,
                                    item_nm,
                                    prod_division,
                                    prod_division_detail,
                                    prod_class,
                                    prod_category,
                                    sub_class,
                                    price,
                                    zender,
                                    insert_tm
                                from 
                                    d_product
                                order by
                                    prod_category desc,
                                    prod_division desc,
                                    prod_division_detail,
                                    prod_class,
                                    zender,
                                    sub_class";
                return FilteredQuery(Query);
            }
            else
            {
                return null;
            }
        }

        private void UpdateDataTable(DataTable UpdateTable, string TableName)
        {
            //index 0번째: before row
            //index 1번째: after row

            //TODO: 짝수 => 이전값, 홀수->변경값(나중에)

            /*
             * 행/2 만큼 반복
             * 행+1은 set 안으로
             *  컬럼 = 값 쉼표
             * 행은 where 안으로
             *  컬럼 = 값 앤드
             */

            string[] Querys = new string[UpdateTable.Rows.Count / 2];

            for (int RowIndex = 0; RowIndex < UpdateTable.Rows.Count; RowIndex += 2)
            {
                string Query = string.Empty;
                string After = "";
                string Before = "";

                for (int ColumnIndex = 0; ColumnIndex < UpdateTable.Columns.Count; ColumnIndex++)
                {
                    string Column = UpdateTable.Columns[ColumnIndex].ColumnName;
                    string SetValue = string.Empty;
                    string WhereValue = string.Empty;
                    //바꿀 값이 있다면
                    if (!string.IsNullOrWhiteSpace(UpdateTable.Rows[RowIndex / 2 + 1][ColumnIndex].ToString()))
                    {
                        //값이 있다면
                        if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.String"))
                        {
                            SetValue = string.Format("'{0}'", UpdateTable.Rows[RowIndex / 2 + 1][ColumnIndex].ToString());
                        }
                        else if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.Int32"))
                        {
                            SetValue = string.Format("{0}", UpdateTable.Rows[RowIndex / 2 + 1][ColumnIndex].ToString());
                        }
                        else if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.DateTime"))
                        {
                            //데이터 타입이라면
                            SetValue = string.Format("TO_DATE('{0}', '{1}')", UpdateTable.Rows[RowIndex / 2 + 1][ColumnIndex].ToString(), "yyyy-mm-dd am hh:mi:ss");
                        }
                        else
                        {
                            //여기는 정말 예외
                            SetValue = string.Format("'{0}'", UpdateTable.Rows[RowIndex / 2 + 1][ColumnIndex].ToString());
                        }
                        After += string.Format("{0} = {1} ", Column, SetValue);
                    }
                    else
                    {
                        //값이 없다면
                        SetValue = "NULL ";
                        After += string.Format("{0} = {1} ", Column, SetValue);
                    }


                    if (!string.IsNullOrWhiteSpace(UpdateTable.Rows[RowIndex / 2][ColumnIndex].ToString()))
                    {
                        //값이 있다면
                        if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.String"))
                        {
                            WhereValue = string.Format("'{0}'", UpdateTable.Rows[RowIndex / 2][ColumnIndex].ToString());
                        }
                        else if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.Int32"))
                        {
                            WhereValue = string.Format("{0}", UpdateTable.Rows[RowIndex / 2][ColumnIndex].ToString());
                        }
                        else if (UpdateTable.Columns[ColumnIndex].DataType == Type.GetType("System.DateTime"))
                        {
                            //데이터 타입이라면
                            WhereValue = string.Format("TO_DATE('{0}', '{1}')", UpdateTable.Rows[RowIndex / 2][ColumnIndex].ToString(), "yyyy-mm-dd am hh:mi:ss");
                        }
                        else
                        {
                            //여기는 정말 예외
                            WhereValue = string.Format("'{0}'", UpdateTable.Rows[RowIndex / 2][ColumnIndex].ToString());
                        }
                        Before += string.Format("{0} = {1} ", Column, WhereValue);
                    }
                    else
                    {
                        //값이 없다면
                        WhereValue = " IS NULL ";
                        Before += string.Format("{0} {1} ", Column, WhereValue);
                    }

                    if (ColumnIndex < UpdateTable.Columns.Count - 1)
                    {
                        After += ", ";
                        Before += "and ";
                    }
                }
                Query = string.Format("Update {0} Set {1} Where {2}", TableName, After, Before);
                Querys[RowIndex] = Query;
            }

            FilteredQuery(Querys);
        }

        private void DeleteDataTable(DataTable DeleteTable, string TableName)
        {
            string[] Querys = new string[DeleteTable.Rows.Count];

            for (int RowIndex = 0; RowIndex < DeleteTable.Rows.Count; RowIndex++)
            {
                string Query = string.Format("Delete from {0} where ", TableName);
                for (int ColumnIndex = 0; ColumnIndex < DeleteTable.Columns.Count; ColumnIndex++)
                {
                    string Column = DeleteTable.Columns[ColumnIndex].ColumnName;
                    string Value = string.Empty;
                    string WhereBlock = string.Empty;
                    if (!string.IsNullOrWhiteSpace(DeleteTable.Rows[RowIndex][ColumnIndex].ToString()))
                    {
                        //값이 있다면
                        if (DeleteTable.Columns[ColumnIndex].DataType == Type.GetType("System.String"))
                        {
                            Value = string.Format("'{0}'", DeleteTable.Rows[RowIndex][ColumnIndex].ToString());
                        }
                        else if (DeleteTable.Columns[ColumnIndex].DataType == Type.GetType("System.Int32"))
                        {
                            Value = string.Format("{0}", DeleteTable.Rows[RowIndex][ColumnIndex].ToString());
                        }
                        else if (DeleteTable.Columns[ColumnIndex].DataType == Type.GetType("System.DateTime"))
                        {
                            //데이터 타입이라면
                            Value = string.Format("TO_DATE('{0}', '{1}')", DeleteTable.Rows[RowIndex][ColumnIndex].ToString(), "yyyy-mm-dd am hh:mi:ss");
                        }
                        WhereBlock = string.Format("{0} = {1}", Column, Value);

                    }
                    else
                    {
                        //값이 없다면
                        Value = " IS NULL ";
                        WhereBlock = string.Format("{0} {1}", Column, Value);
                    }

                    if (ColumnIndex < DeleteTable.Columns.Count - 1)
                    {
                        //다음에도 항목이 있다면 쉼표 붙이기
                        WhereBlock += " and ";
                    }
                    Query += WhereBlock;
                }
                Querys[RowIndex] = Query;
            }

            FilteredQuery(Querys);
        }

        public void ControlTable(string Type, DataTable UpdateTable, string TableName)
        {
            if (Type.ToLower().Equals("update"))
            {
                UpdateDataTable(UpdateTable, TableName);
            }
            else if (Type.ToLower().Equals("insert"))
            {
                InsertDataTable(UpdateTable, TableName);
            }
            else if (Type.ToLower().Equals("delete"))
            {
                DeleteDataTable(UpdateTable, TableName);
            }
        }
    }
}
