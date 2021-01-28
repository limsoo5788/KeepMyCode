using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace FTP
{
    /*
     * TODO: 다음에 해야할것
     * start하고 나서 오라클에 쿼리 날려주기(누적?)
     * 테이블에 값 넣어주면 반대로 받아와서 GridView에 보여주기(수정불가로)
     */
    public partial class Form1 : Form
    {
        string ipAdress;
        string user;
        string pwd;
        string port;
        string uri;
        string DownloadPath;
        string SuccessPath;
        string FailPath = "";
        string FileName = "Target";
        string FileExtension = ".txt";
        string FileFullName = "";
        bool usePassive = false;

        public Form1()
        {
            InitializeComponent();
            InitFTPFileList();
        }

        private void InitFTPFileList()
        {
            SetFTPHost();
        }

        private void SetExpressionList()
        {
            //수식 계산
            string[] Needs = GetEachText(FileFullName, DownloadPath);

            lbx_targetlist.Items.Clear();

            for (int i = 0; i < Needs.Length; i++)
            {
                lbx_targetlist.Items.Add(Needs[i].ToString());
            }
        }

        private void OutTargetListSelectedItems()
        {
            ListBox.SelectedObjectCollection selectedItems = lbx_targetlist.SelectedItems;
            if (lbx_targetlist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lbx_deletelist.Items.Add(selectedItems[i]);
                    lbx_targetlist.Items.Remove(selectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("선택된 행이 없습니다");
            }
        }
        private void InTargetListSelectedItems()
        {
            ListBox.SelectedObjectCollection selectedItems = lbx_deletelist.SelectedItems;
            if (lbx_deletelist.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                {
                    lbx_targetlist.Items.Add(selectedItems[i]);
                    lbx_deletelist.Items.Remove(selectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("선택된 행이 없습니다");
            }
        }

        //private void SetFTPFileList()
        //{
        //    string[] FTPFileList = GetFTPFileList();
        //    if (FTPFileList != null)
        //    {
        //        foreach (string FileName in GetFTPFileList())
        //        {
        //            lbx_targetlist.Items.Add(FileName);
        //        }
        //    }
        //}

        private void btn_Click(object sender, System.EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = (Button)sender;
                ButtonProcess(btn.Text);
            }
        }

        private void ButtonProcess(string name)
        {
            if (name.ToLower().Equals("<-"))
            {
                InTargetListSelectedItems();
            }
            else if (name.ToLower().Equals("->"))
            {
                OutTargetListSelectedItems();
            }
            else if (name.ToLower().Equals("upload"))
            {
                FtpUploadUsingWebClient(new string[] { "Success.txt", "Fail.txt" }, DownloadPath);
            }
            else if (name.ToLower().Equals("start"))
            {
                RunProcess();
            }
        }

        private void RunProcess()
        {
            // 수식 뒤 "," 제거해야함
            string[] ExpressionList = GetExpressionList();
            StreamWriter sw;
            //파일 초기화
            File.WriteAllText(SuccessPath, String.Empty);
            File.WriteAllText(FailPath, String.Empty);
            foreach (string Need in ExpressionList)
            {
                string Write;
                bool isGood;
                string Commmet;
                double? result;
                string Expression = Need.Replace(",", "");
                try
                {
                    result = (double)Calculate.calculate(Expression);
                    isGood = true;
                    Commmet = "없음";
                }
                catch (Exception ex)
                {
                    //무언가 문제로 계산이 안됨
                    result = 0;
                    isGood = false;
                    Commmet = ex.Message;
                }

                Write = string.Format("{0}, {1}, {2}, {3}", Expression, result, isGood ? "성공" : "실패", Commmet);

                if (isGood)
                {
                    //성공했다면
                    sw = new StreamWriter(SuccessPath, true);
                }
                else
                {
                    //실패했다면
                    sw = new StreamWriter(FailPath, true);
                }
                sw.WriteLine(Write);
                sw.Close();
            }
            MessageBox.Show("처리 완료");
        }

        private string[] GetExpressionList()
        {
            return lbx_targetlist.Items.OfType<string>().ToArray();
        }

        private void SetFTPHost()
        {
            ipAdress = "localhost";
            user = "isi";
            pwd = "5788";
            port = "21";
            uri = string.Format(@"FTP://{0}:{1}/", this.ipAdress, this.port);
            DownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CalFolder";
            SuccessPath = DownloadPath + "\\" + "Success.txt";
            FailPath = DownloadPath + "\\" + "Fail.txt";
            FileFullName = FileName + FileExtension;

            FtpDownloadUsingWebClient(FileFullName, DownloadPath);
        }

        //private string[] GetFTPFileList()
        //{
        //    //출처 : http://blog.naver.com/PostView.nhn?blogId=ambidext&logNo=220831166976&categoryNo=40&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=postView
        //    string[] FileList;
        //    StringBuilder Result = new StringBuilder();
        //    FtpWebRequest RequestFTP;
        //    try
        //    {
        //        RequestFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
        //        //RequestFTP.UseBinary = true;
        //        RequestFTP.UsePassive = usePassive;
        //        RequestFTP.Credentials = new NetworkCredential(user, pwd);
        //        RequestFTP.Method = WebRequestMethods.Ftp.ListDirectory;
        //        using (WebResponse response = RequestFTP.GetResponse())
        //        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        //        {
        //            string line = reader.ReadLine();
        //            while (line != null)
        //            {
        //                Result.Append(line);
        //                Result.Append("\n");
        //                line = reader.ReadLine();
        //            }
        //            Result.Remove(Result.ToString().LastIndexOf('\n'), 1);
        //        }

        //        return Result.ToString().Split('\n');
        //    }
        //    catch
        //    {
        //        MessageBox.Show("FPT연결에 실패했습니다.");
        //        FileList = null;
        //        return FileList;
        //    }
        //}

        public void FtpDownloadUsingWebClient(string filename, string downpath)
        {
            //출처 : http://www.csharpstudy.com/Tip/Tip-using-ftp.aspx
            // WebClient 객체 생성
            using (WebClient WebCli = new WebClient())
            {
                // FTP 사용자 설정
                WebCli.Credentials = new NetworkCredential(user, pwd);
                // 다운로드가 완료되면 실행
                WebCli.DownloadFileCompleted += WebCli_DownloadFileCompleted;
                // FTP 다운로드 실행
                WebCli.DownloadFileAsync(new Uri(uri + filename), downpath + "\\" + filename);
            }
        }

        //public void FtpUploadUsingWebClient(string filename, string uppath)
        //{
        //    // WebClient 객체 생성
        //    using (WebClient WebCli = new WebClient())
        //    {
        //        // FTP 사용자 설정
        //        WebCli.Credentials = new NetworkCredential(user, pwd);
        //        // FTP 업로드 실행
        //        WebCli.UploadFile(new Uri(uri + filename), uppath + "\\" + filename);
        //    }
        //}
        public void FtpUploadUsingWebClient(string[] filenames, string uppath)
        {
            // WebClient 객체 생성
            using (WebClient WebCli = new WebClient())
            {
                // FTP 사용자 설정
                WebCli.Credentials = new NetworkCredential(user, pwd);
                foreach (string filename in filenames)
                {
                    // FTP 업로드 실행
                    WebCli.UploadFile(new Uri(uri + filename), uppath + "\\" + filename);
                }
            }
        }

        private void WebCli_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //수식 계산
            CalculateTask();
        }

        private void CalculateTask()
        {
            //수식 계산
            SetExpressionList();

            ////수식 계산
            //string[] Needs = GetEachText(FileFullName, DownloadPath);

            //StreamWriter sw;
            ////파일 초기화
            //File.WriteAllText(SuccessPath, String.Empty);
            //File.WriteAllText(FailPath, String.Empty);
            //foreach (string Need in Needs)
            //{
            //    string Write;
            //    bool isGood;
            //    string Commmet;
            //    double? result;
            //    string Expression = Need.Replace(",", "");
            //    try
            //    {
            //        result = (double)Calculate.calculate(Expression);
            //        isGood = true;
            //        Commmet = "없음";
            //    }
            //    catch (Exception ex)
            //    {
            //        //무언가 문제로 계산이 안됨
            //        result = 0;
            //        isGood = false;
            //        Commmet = ex.Message;
            //    }

            //    Write = string.Format("{0}, {1}, {2}, {3}", Expression, result, isGood ? "성공" : "실패", Commmet);

            //    if (isGood)
            //    {
            //        //성공했다면
            //        sw = new StreamWriter(SuccessPath, true);
            //    }
            //    else
            //    {
            //        //실패했다면
            //        sw = new StreamWriter(FailPath, true);
            //    }
            //    sw.WriteLine(Write);
            //    sw.Close();
            //}
        }

        private string[] GetEachText(string filename, string uppath)
        {
            try
            {
                List<string> LineList = new List<string>();
                string Line;

                // Read the file and display it line by line.  
                System.IO.StreamReader Reader =
                    new System.IO.StreamReader(uppath + "\\" + filename);
                while ((Line = Reader.ReadLine()) != null)
                {
                    LineList.Add(Line);
                }

                Reader.Close();
                return LineList.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일이 존재하지 않습니다");
                return null;
            }
        }
    }
}
