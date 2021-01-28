using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FTPForm
{
    public partial class MainForm : Form
    {
        CustomFTP CstmFTP = new CustomFTP();
        string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        List<string> ListUploadFile = new List<string>();
        List<string> ListDownloadFile = new List<string>();
        public MainForm()
        {
            InitializeComponent();
            lbx_upload.SelectionMode = SelectionMode.MultiExtended;
            lbx_download.SelectionMode = SelectionMode.MultiExtended;
            lbx_ftpfilelist.SelectionMode = SelectionMode.MultiExtended;

            InitFTPFileList();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            //뭐든지 버튼을 클릭했을때
            Button btn = null;
            if (sender is Button)
            {
                btn = (Button)sender;
                ButtonProcessing(btn.Name);
            }
            else
            {
                Console.WriteLine("ButtonClickError");
            }
        }

        private void ButtonProcessing(string sign)
        {
            if (sign.Equals(btn_download_plus.Name))
            {
                ListBox.SelectedObjectCollection items = lbx_ftpfilelist.SelectedItems;
                if (items.Count > 0)
                {
                    //리스트박스 선택이 있다면
                    int cnt = items.Count;
                    for (int i = cnt - 1; i >= 0; i--)
                    {
                        if (lbx_download.Items.Contains(items[i]))
                        {

                        }
                        else
                        {
                            lbx_download.Items.Add(items[i]);
                            ListDownloadFile.Add(items[i].ToString());
                        }
                    }
                }
                else
                {
                    //리스트박스 선택이 없다면
                }
                lbx_ftpfilelist.SelectedIndex = -1;
            }
            else if (sign.Equals(btn_download_minus.Name))
            {
                ListBox.SelectedObjectCollection items = lbx_download.SelectedItems;
                if (items.Count > 0)
                {
                    //리스트박스 선택이 있다면
                    int cnt = items.Count;
                    for (int i = cnt - 1; i >= 0; i--)
                    {
                        lbx_download.Items.Remove(items[i]);
                    }
                }
                else
                {
                    //리스트박스 선택이 없다면
                }
            }
            else if (sign.Equals(btn_upload_plus.Name))
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = DEFAULT_PATH;
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.Multiselect = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (String filepath in openFileDialog.FileNames)
                        {
                            if (filepath.Contains("#"))
                            {
                                MessageBox.Show("파일명에 # 이 포함되면 안됩니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                ListUploadFile.Add(filepath.ToString());
                                lbx_upload.Items.Add(filepath.ToString());
                            }

                        }
                    }
                    else
                    {
                        //선택하지 않았을때
                    }
                }
            }
            else if (sign.Equals(btn_upload_minus.Name))
            {
                ListBox.SelectedObjectCollection items = lbx_upload.SelectedItems;
                if (items.Count > 0)
                {
                    //리스트박스 선택이 있다면
                    int cnt = items.Count;
                    for (int i = cnt - 1; i >= 0; i--)
                    {
                        lbx_upload.Items.Remove(items[i]);
                    }
                }
                else
                {
                    //리스트박스 선택이 없다면
                }
            }
            else if (sign.Equals(btn_download.Name))
            {
                CstmFTP.DownloadFile(ListDownloadFile);
                ListDownloadFile.Clear();
                lbx_download.Items.Clear();
            }
            else if (sign.Equals(btn_upload.Name))
            {
                CstmFTP.UploadFile(ListUploadFile);
                ListUploadFile.Clear();
                lbx_upload.Items.Clear();
            }
            else if (sign.Equals(btn_ftpsetting.Name))
            {
                FTPSettingForm SettingForm = new FTPSettingForm();
                SettingForm.FTPSettingEvent += GetFTPSetting;
                SettingForm.ShowDialog();

                InitFTPFileList();
            }
        }

        private void InitFTPFileList()
        {
            lbx_ftpfilelist.Items.Clear();
            lbx_download.Items.Clear();
            ListDownloadFile.Clear();
            string[] FTPFilelist = CstmFTP.GetFileList();
            if (FTPFilelist != null)
            {
                foreach (string file in FTPFilelist)
                {
                    lbx_ftpfilelist.Items.Add(file);
                }
            }
            else
            {
                lbx_ftpfilelist.Items.Add("FTPServer와 연결되지 않았습니다");
            }
        }

        private void GetFTPSetting(Dictionary<string, string> message)
        {
            CstmFTP = new CustomFTP(message["ipadress"], message["id"], message["pw"], message["port"]);

        }
    }
}
