using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OracleDBConnect_Winform
{
    public partial class MainForm : Form
    {
        CustomOracleConnecter OracleConn = new CustomOracleConnecter();
        ExcelConnecter ExcelConn = new ExcelConnecter();

        bool IsOracle = true;

        public MainForm()
        {
            InitializeComponent();

            //TODO: 
            // 1. 모든 버튼 클릭리스너 하나의 버튼클릭 리스너에서 if문으로 필터링하기
            // 2. 엑셀에 시트가 여러개일경우 처리 방법 고안해야함
            // 기본적으로 파일을 열면 첫번째 시트의 데이터값이 gridview에 나타나게 한다
            // listbox 요소를 클릭하면 해당 시트의 데이터가 gridview에 표시된다
            // listbox 요소를 여러개 클릭하면 마지막으로 클릭했던 시트가 표시된다
            // 시트 하나만 선택하고 임포트하면 평소처럼 임포트
            // 시트 여러개를 선택하고 임포트하면 여러개 임포트

            tlp_gridandbottons.RowStyles[1].Height = 0;

            Init_lbx_sheet_forOracle();
        }

        private void ForExcel()
        {
            lbx_sheetname.SelectionMode = SelectionMode.MultiExtended;
            IsOracle = false;
        }
        private void ForOracle()
        {
            lbx_sheetname.SelectionMode = SelectionMode.One;
            IsOracle = true;
        }

        string DEFAULT_EXPORT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\excel_export.xlsx";
        string DEFAULT_IMPORT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string FirstSheetName = "Sheet1$";
        private void ExcelOnGrid(string getFilePath)
        {
            dataGridView1.DataSource = ExcelConn.getDataTable(getFilePath, FirstSheetName);
        }

        private void btn_select_Click(object sender, System.EventArgs e)
        {
            lbx_sheetname.Items.Clear();
            string SQLQuery = tbx_query.Text;
            if (SQLQuery.Length > 0)
            {
                dataGridView1.DataSource = OracleConn.FilteredQuery(SQLQuery);
            }
        }

        private string FindLocate()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string filePath = string.Empty;
                openFileDialog.InitialDirectory = DEFAULT_IMPORT_PATH;
                openFileDialog.Filter = "엑셀 파일 (*.xls)|*.xls|엑셀 파일 (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    //lbx_sheetname에 여러개 시트 이름 넣어주기
                    Init_lbx_sheet_forExcel(filePath);
                    FirstSheetName = lbx_sheetname.Items[0].ToString();
                    ExcelOnGrid(filePath);
                    return filePath;
                }
                else
                {
                    //선택 안하고 종료시
                    return "";
                }
            }
        }


        private void btn_excel_locate_Click(object sender, EventArgs e)
        {
            ForExcel();
            string excel_path = FindLocate();

            if (excel_path.Length > 0)
            {
                this.tbx_excel_locate.Text = excel_path;
            }
            else
            {
                //아무값도 선택 안했을때
            }
        }

        private void Init_lbx_sheet_forExcel(string excel_path)
        {
            lbx_sheetname.Items.Clear();
            foreach (string name in ExcelConn.GetExcelSheetName(excel_path))
            {
                lbx_sheetname.Items.Add(name);
            }
        }
        private void Init_lbx_sheet_forOracle()
        {
            lbx_sheetname.Items.Clear();
            List<string> ColumnsName = OracleConn.GetTableNames();
            foreach (string ColumnName in ColumnsName)
            {
                lbx_sheetname.Items.Add(ColumnName);
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            //TODO: 파일명 테이블명으로 해야하나? -> 다른 결과나오는 쿼리(ex join)같은 경우는 애메할것 같아서 고정
            if (GridIsNotEmply())
            {
                ExcelConn.ExportToExcel((DataTable)dataGridView1.DataSource, DEFAULT_EXPORT_PATH);
            }
            else
            {
                MessageBox.Show("DataGridView가 비어있습니다", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //dataGridView가 비었는지 확인하기 위함
        private bool GridIsNotEmply()
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_excel_import_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection items = lbx_sheetname.SelectedItems;

            if (tbx_excel_locate.Text.Length > 0)
            {
                string FormExcelPath = this.tbx_excel_locate.Text;
                if (items.Count > 0)
                {
                    //리스트박스 선택이 있다면
                    //TODO: 시트 이름 넣어주기
                    foreach (string item in items)
                    {
                        DataTable ImportTable = ExcelConn.getDataTable(FormExcelPath, item);
                        if (ImportTable.Columns.Count > 0)
                        {
                            OracleConn.ImportDataTable(ImportTable, item);
                        }
                        else
                        {
                            //비어있는 경우
                        }
                    }
                }
                else
                {
                    //리스트박스 선택이 없다면
                    DataTable ImportTable = ExcelConn.getDataTable(FormExcelPath, FirstSheetName);
                    if (ImportTable.Columns.Count > 0)
                    {
                        OracleConn.ImportDataTable(ImportTable, FirstSheetName);
                    }
                    else
                    {
                        //비어있는 경우
                    }
                }
            }
            else
            {
                MessageBox.Show("경로가 지정되지 않았습니다", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbx_excel_locate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                ExcelOnGrid(tbx_excel_locate.Text);
            }
        }

        private void lbx_sheetname_Click(object sender, EventArgs e)
        {


            ListBox.SelectedObjectCollection items = lbx_sheetname.SelectedItems;

            if (items != null && items.Count > 0)
            {
                if (IsOracle)
                {
                    string TableName = items[items.Count - 1].ToString();
                    dataGridView1.DataSource = OracleConn.GetTable(TableName);
                }
                else
                {
                    string sheetname = string.Empty;

                    sheetname = items[items.Count - 1].ToString();
                    dataGridView1.DataSource = ExcelConn.getDataTable(this.tbx_excel_locate.Text, sheetname);
                }
            }
            else
            {
                return;
            }
        }

        private void btn_DBSetting_Click(object sender, EventArgs e)
        {
            ForOracle();
            DBSettingForm DBSetting = new DBSettingForm();
            DBSetting.DBSettingEvent += GetDBSetting;
            DBSetting.ShowDialog();
            Init_lbx_sheet_forOracle();
            //TODO: DBSetting 에서 넘어온 커넥션 넣기
        }

        private void GetDBSetting(string message)
        {
            OracleConn = new CustomOracleConnecter(message);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //사용자가 gridview의 값을 바꿧다고 확정하는 순간(커밋하는순간, 포커스가 벗어나는 순간)
            tlp_gridandbottons.RowStyles[1].Height = 30;
        }

        private void GridViewUpdateBottons(object sender, EventArgs e)
        {
            Button btn = null;
            if (sender is Button)
            {
                btn = (Button)sender;
                UpdateProcessing(btn.Name);
            }
            else
            {
                Console.WriteLine("ButtonClickError");
            }
        }

        private void UpdateProcessing(string name)
        {
            DataTable MyTable = (DataTable)dataGridView1.DataSource;
            if (name.Equals(btn_update.Name))
            {
                //출처: https://afsdzvcx123.tistory.com/entry/C-DataGridView-%EB%8D%B0%EC%9D%B4%ED%84%B0-%EC%88%98%EC%A0%95%ED%95%9C-%ED%9B%84-DB-%ED%85%8C%EC%9D%B4%EB%B8%94%EC%97%90-Update-%ED%95%98%EB%8A%94-%EB%B0%A9%EB%B2%95
                DataTable ChangedTable = MyTable.GetChanges(DataRowState.Modified);
                string[] Querys = new string[ChangedTable.Rows.Count];
                if (ChangedTable != null)
                {
                    for (int RowsNum = 0; RowsNum < ChangedTable.Rows.Count; RowsNum++)
                    {
                        string UpdateQuery = "update " + ChangedTable.TableName;
                        UpdateQuery += " Set ";
                        string TargetColumn = ChangedTable.Columns[0].ColumnName;
                        string TargetRow = Convert.ToString(ChangedTable.Rows[RowsNum][0]);
                        UpdateQuery += TargetColumn + " = " + TargetRow;
                        for (int ColumnsNum = 1; ColumnsNum < ChangedTable.Columns.Count; ColumnsNum++)
                        {
                            TargetColumn = ChangedTable.Columns[ColumnsNum].ColumnName;
                            TargetRow = Convert.ToString(ChangedTable.Rows[RowsNum][ColumnsNum]);
                            UpdateQuery += ", " + TargetColumn + " = " + TargetRow;
                        }

                        //TODO: 원본 데이터를 받아와야한다


                        UpdateQuery += " Where ";
                        string OriginalTargetColumn = ChangedTable.Columns[0].ColumnName;
                        string OriginalTargetRow = Convert.ToString(ChangedTable.Rows[RowsNum][0]);
                        UpdateQuery += TargetColumn + " " + TargetRow;

                        for (int ColumnsNum = 0; ColumnsNum < ChangedTable.Columns.Count; ColumnsNum++)
                        {
                            UpdateQuery += " Where ";
                            OriginalTargetColumn = ChangedTable.Columns[ColumnsNum].ColumnName;
                            OriginalTargetRow = Convert.ToString(ChangedTable.Rows[RowsNum][ColumnsNum]);
                            UpdateQuery += OriginalTargetColumn + " " + OriginalTargetRow;
                        }
                    }
                    dataGridView1.DataSource = ChangedTable;
                }

                //int dt_cols_count = dataSource.Columns.Count;

                //string[] Columns = new string[dt_cols_count];
                ////컬럼명 가져오기
                //for (int ColumnNum = 0; ColumnNum < dt_cols_count; ColumnNum++)
                //{
                //    Columns[ColumnNum] = dataSource.Columns[ColumnNum].ColumnName;
                //}

                //if (dt_rows_count > 0)//데이터 테이블의 크기가 0보다 크다면
                //{
                //    Rows = new string[dt_rows_count][];//행만큼의 2차원 배열 생성
                //    for (int i = 0; i < dt_rows_count; i++)
                //    {
                //        Rows[i] = new string[dt_cols_count];//해당 행만큼 세부 1차원 배열 생성
                //    }

                //    for (int i = 0; i < dt_rows_count; i++)
                //    {
                //        for (int j = 0; j < dt_cols_count; j++)
                //        {
                //            Rows[i][j] = Convert.ToString(dataSource.Rows[i][j]);//데이터를 생성한 배열에 저장
                //        }
                //    }
                //}
            }
            else if (name.Equals(btn_cancle.Name))
            {
                MyTable.RejectChanges();
                //TODO: 변경되기 이전으로 돌아가도록
                //캔슬 실행
                tlp_gridandbottons.RowStyles[1].Height = 0;
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            tlp_gridandbottons.RowStyles[1].Height = 0;
        }
    }
}
