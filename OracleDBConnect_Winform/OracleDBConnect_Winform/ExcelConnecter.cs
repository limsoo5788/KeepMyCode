using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace OracleDBConnect_Winform
{

    class ExcelConnecter
    {
        //엑셀 버전이 97-2003 과 2007 ( 더 높은 버전) 은 다른 커넥션 스트링을 사용하는데, 전자는 Microsoft Jet Engine 을 사용하고, 후자는 Microsoft Ace Engine 을 사용합니다. 
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        public OleDbConnection OleDBconn(string getFilePath)
        {
            string fileExtension = Path.GetExtension(getFilePath);
            string connectionString = string.Empty;

            // 확장자로 구분하여 커넥션 스트링을 가져옮
            switch (fileExtension)
            {
                case ".xls":    //Excel 97-03
                    connectionString = string.Format(Excel03ConString, getFilePath, "yes");
                    break;
                case ".xlsx":  //Excel 07
                    connectionString = string.Format(Excel07ConString, getFilePath, "yes");
                    break;
            }

            OleDbConnection oleConn = new OleDbConnection(connectionString);

            return oleConn;
        }

        public string[] GetExcelSheetName(string getFilePath)
        {
            //출처: https://stackoverflow.com/questions/1164698/using-excel-oledb-to-get-sheet-names-in-sheet-order
            DataTable dataTable = new DataTable();
            using (OleDbConnection OleConn = OleDBconn(getFilePath))
            {
                try
                {
                    OleConn.Open();
                    dataTable = OleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                }
                catch (Exception ex)
                {
                    dataTable = null;
                }
            }
            if (dataTable == null)
            {
                return null;
            }
            string[] excelSheets = new string[dataTable.Rows.Count];
            int i = 0;

            // Add the sheet name to the string array.
            foreach (DataRow row in dataTable.Rows)
            {
                excelSheets[i] = row["TABLE_NAME"].ToString();
                //excelSheets[i] = "[" + excelSheets[i] + "]";
                i++;
            }
            return excelSheets;
        }

        public DataTable getDataTable(string getFilePath, string sheetname)
        {
            //(약간의 리팩토링)출처 https://link2me.tistory.com/823
            try
            {
                using (OleDbConnection oleConn = OleDBconn(getFilePath))
                {
                    string strQuery = "SELECT * FROM " + "[" + sheetname + "]";  // 엑셀 시트명 Sheet1의 모든 데이터를 가져오기
                    oleConn.Open();
                    using (OleDbCommand oleCmd = new OleDbCommand(strQuery, oleConn))
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(oleCmd))
                    using (DataTable dataTable = new DataTable())
                    {
                        dataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show("경로: " + getFilePath + "\n경로가 잘못되었습니다", "주의", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new DataTable();
            }
        }

        public void ExportToExcel(DataTable DataSource, string DEFAULT_EXPORT_PATH)
        {
            DialogResult dialogResult = MessageBox.Show("경로: " + DEFAULT_EXPORT_PATH + "\n이전에 있던 파일은 덮어씌워집니다", "주의", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

                DataTable target = DataSource;

                //컬럼명 가져오기
                for (int ColumnName = 0; ColumnName < target.Columns.Count; ColumnName++)
                {
                    workSheet.Cells[1, ColumnName + 1] = target.Columns[ColumnName].ColumnName;
                }

                for (int row = 0; row < target.Rows.Count; row++)
                {
                    for (int column = 0; column < target.Columns.Count; column++)
                    {
                        workSheet.Cells[row + 2, column + 1] = target.Rows[row][column];
                    }
                }

                //이전파일이 존재한다면
                if (File.Exists(DEFAULT_EXPORT_PATH))
                {
                    File.Delete(DEFAULT_EXPORT_PATH);
                }

                workSheet.SaveAs(DEFAULT_EXPORT_PATH);
                excelApp.Quit();
            }
        }
    }
}
