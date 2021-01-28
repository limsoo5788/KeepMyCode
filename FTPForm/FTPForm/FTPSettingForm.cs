using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FTPForm
{
    public partial class FTPSettingForm : Form
    {
        public delegate void FTPSettingFormDataHandler(Dictionary<string, string> message);
        public event FTPSettingFormDataHandler FTPSettingEvent;

        public FTPSettingForm()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            //텍스트박스 검사
            Dictionary<string, string> ConnData = GetDictionary();

            if (ConnData != null)
            {
                this.FTPSettingEvent(ConnData);
                this.Close();
            }
        }

        private Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> ConnData = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(tbx_input_ipadress.Text))
            {
                tbx_input_ipadress.Text = "localhost";
            }
            if (string.IsNullOrWhiteSpace(tbx_input_port.Text))
            {
                tbx_input_port.Text = "21";
            }
            if (string.IsNullOrWhiteSpace(tbx_input_id.Text))
            {
                MessageBox.Show("ID을(를) 입력하십시오");
                return null;
            }
            else if (string.IsNullOrWhiteSpace(tbx_input_pw.Text))
            {
                MessageBox.Show("PW을(를) 입력하십시오");
                return null;
            }
            else
            {
                ConnData.Add("ipadress", tbx_input_ipadress.Text);
                ConnData.Add("port", tbx_input_port.Text);
                ConnData.Add("id", tbx_input_id.Text);
                ConnData.Add("pw", tbx_input_pw.Text);
                return ConnData;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
