using System.Collections.Generic;
using System.Windows.Forms;

namespace OracleDBConnect_Winform
{

    public partial class DBSettingForm : Form
    {
        //winform간 data 전달
        //https://afsdzvcx123.tistory.com/entry/C-%EC%9C%88%ED%8F%BC-%ED%8F%BC%EA%B0%84-%EB%8D%B0%EC%9D%B4%ED%84%B0-%EC%A0%84%EB%8B%AC%ED%95%98%EB%8A%94-%EB%B0%A9%EB%B2%95-%EB%B6%80%EB%AA%A8%ED%8F%BC-%EC%9E%90%EC%8B%9D%ED%8F%BC-%EC%9E%90%EC%8B%9D%ED%8F%BC-%EB%B6%80%EB%AA%A8-%ED%8F%BC
        public delegate void DBSettingFormDataHandler(string message);
        public event DBSettingFormDataHandler DBSettingEvent;
        CustomOracleConnecter OracleConn = new CustomOracleConnecter();

        public DBSettingForm()
        {
            InitializeComponent();
        }

        string NewSource = "";
        private void btn_connect_Click(object sender, System.EventArgs e)
        {
            //string DEFAULT_CONNECT = @"Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = isetda) )); User Id=isi;Password=5788;";
            //텍스트박스 검사
            Dictionary<string, string> ConnData = GetDictionary();

            if (ConnData != null)
            {
                //최소 입력은 끝났을때
                if (btn_connect.Text.Equals("TryConnect"))
                {
                    NewSource = OracleConn.ConnectCheck(ConnData);
                    if (NewSource.Length > 0)
                    {
                        //연결시도 성공
                        btn_connect.Text = "Change";
                    }
                    else
                    {
                        //연결시도 실패
                    }
                }
                else if (btn_connect.Text.Equals("Change"))
                {
                    this.DBSettingEvent(NewSource);
                    this.Close();
                }
            }
        }

        private Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> ConnData = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(tbx_inp_protocol.Text))
            {
                tbx_inp_protocol.Text = "TCP";
            }
            if (string.IsNullOrWhiteSpace(tbx_inp_host.Text))
            {
                tbx_inp_host.Text = "localhost";
            }
            if (string.IsNullOrWhiteSpace(tbx_inp_port.Text))
            {
                tbx_inp_port.Text = "1521";
            }
            if (string.IsNullOrWhiteSpace(tbx_inp_server.Text))
            {
                tbx_inp_server.Text = "DEDICATED";
            }
            if (string.IsNullOrWhiteSpace(tbx_inp_servicename.Text))
            {
                MessageBox.Show("servicename을(를) 입력하십시오");
                return null;
            }
            else if (string.IsNullOrWhiteSpace(tbx_inp_id.Text))
            {
                MessageBox.Show("ID을(를) 입력하십시오");
                return null;
            }
            else if (string.IsNullOrWhiteSpace(tbx_inp_pw.Text))
            {
                MessageBox.Show("PW을(를) 입력하십시오");
                return null;
            }
            else
            {
                ConnData.Add("protocol", tbx_inp_protocol.Text);
                ConnData.Add("host", tbx_inp_host.Text);
                ConnData.Add("port", tbx_inp_port.Text);
                ConnData.Add("server", tbx_inp_server.Text);
                ConnData.Add("servicename", tbx_inp_servicename.Text);
                ConnData.Add("id", tbx_inp_id.Text);
                ConnData.Add("pw", tbx_inp_pw.Text);
                return ConnData;
            }
        }

        private void tbx_inp_KeyDown(object sender, KeyEventArgs e)
        {
            btn_connect.Text = "TryConnect";
        }

        private void btn_cancle_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }



}
