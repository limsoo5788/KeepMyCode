using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPForm
{
    //출처 : https://docs.microsoft.com/ko-kr/dotnet/api/system.iasyncresult?view=net-5.0
    class CustomFTP
    {
        // Command line arguments are two strings:
        // 1. The url that is the name of the file being uploaded to the server.
        // 2. The name of the file on the local machine.
        //
        string ipAdress = "";
        string user = "";
        string pwd = "";
        string port = "";
        string url = "";

        string DEFAULT_DOWNLOAD_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string Url
        {
            get
            {
                return url;
            }
        }
        public CustomFTP()
        {
            // Create a Uri instance with the specified URI string.
            // If the URI is not correctly formed, the Uri constructor
            // will throw an exception.

            ipAdress = "localhost";
            user = "isi";
            pwd = "5788";
            port = "21";
            url = string.Format(@"FTP://{0}:{1}/", this.ipAdress, this.port);
        }
        public CustomFTP(string inp_ipAdress, string inp_user, string inp_pwd, string inp_port)
        {
            // Create a Uri instance with the specified URI string.
            // If the URI is not correctly formed, the Uri constructor
            // will throw an exception.

            ipAdress = inp_ipAdress;
            user = inp_user;
            pwd = inp_pwd;
            port = inp_port;
            url = string.Format(@"FTP://{0}:{1}/", this.ipAdress, this.port);
        }
        public void UploadFile(List<string> list)
        {
            try
            {
                foreach (string fileName in list)
                {
                    UploadFile(fileName);
                }
                MessageBox.Show("업로드에 성공했습니다", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("업로드에 실패했습니다", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UploadFile(string fileName)
        {
            ManualResetEvent waitObject;

            Uri target = new Uri(url);
            FtpState state = new FtpState();
            //버그 출처: https://stackoverrun.com/ko/q/6858438
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + "/" + Path.GetFileName(fileName));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.Credentials = new NetworkCredential(user, pwd);

            // Store the request in the object that we pass into the
            // asynchronous operations.
            state.Request = request;
            state.FileName = fileName;

            // Get the event to wait on.
            waitObject = state.OperationComplete;

            // Asynchronously get the stream for the file contents.
            request.BeginGetRequestStream(
                new AsyncCallback(EndGetStreamCallback),
                state
            );

            // Block the current thread until all operations are complete.
            waitObject.WaitOne();

            // The operations either completed or threw an exception.
            if (state.OperationException != null)
            {
                throw state.OperationException;
            }
            else
            {
                Console.WriteLine("The operation completed - {0}", state.StatusDescription);
            }
        }

        private static void EndGetStreamCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;

            Stream requestStream = null;
            // End the asynchronous call to get the request stream.
            try
            {
                requestStream = state.Request.EndGetRequestStream(ar);
                // Copy the file contents to the request stream.
                const int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];
                int count = 0;
                int readBytes = 0;
                FileStream stream = File.OpenRead(state.FileName);
                //FileStream stream = File.OpenRead(state.FileName);

                do
                {
                    readBytes = stream.Read(buffer, 0, bufferLength);
                    requestStream.Write(buffer, 0, readBytes);
                    count += readBytes;
                }
                while (readBytes != 0);
                Console.WriteLine("Writing {0} bytes to the stream.", count);
                // IMPORTANT: Close the request stream before sending the request.
                requestStream.Close();
                // Asynchronously get the response to the upload request.
                state.Request.BeginGetResponse(
                    new AsyncCallback(EndGetResponseCallback),
                    state
                );
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Could not get the request stream.");
                state.OperationException = e;
                state.OperationComplete.Set();
                return;
            }
        }

        //다운로드 출처 : https://blog.naver.com/ambidext/220831166976
        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(user, pwd);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("."))
                    {
                        //확장자가 있다면
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();

                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                downloadFiles = null;

                MessageBox.Show("FTPServer에 연결 실패했습니다", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return downloadFiles;
            }
        }

        public void DownloadFile(List<string> list)
        {
            foreach (string fileName in list)
            {
                try
                {
                    DownloadFile(fileName);
                    MessageBox.Show("다운로드에 성공했습니다", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("다운로드에 실패했습니다", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DownloadFile(string fileName)
        {
            try
            {
                string localFilePath = DEFAULT_DOWNLOAD_PATH + "\\" + fileName;
                checkDir(localFilePath);

                FtpWebRequest FTPRequest = (FtpWebRequest)WebRequest.Create(url + "/" + Path.GetFileName(fileName));
                FTPRequest.Credentials = new NetworkCredential(user, pwd);
                FTPRequest.KeepAlive = false;
                FTPRequest.UseBinary = true;
                FTPRequest.UsePassive = false;

                using (FtpWebResponse response = (FtpWebResponse)FTPRequest.GetResponse())
                using (FileStream outputStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
                using (Stream ftpStream = response.GetResponseStream())
                {
                    int bufferSize = 2048;
                    int readCount;
                    byte[] buffer = new byte[bufferSize];

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    while (readCount > 0)
                    {
                        outputStream.Write(buffer, 0, readCount);
                        readCount = ftpStream.Read(buffer, 0, bufferSize);
                    }
                    ftpStream.Close();
                    outputStream.Close();

                    if (buffer != null)
                    {
                        Array.Clear(buffer, 0, buffer.Length);
                        buffer = null;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            ////출처: https://afsdzvcx123.tistory.com/entry/C-FTP-C-FTP-%EC%A0%91%EC%86%8D-%EB%B0%8F-%ED%8C%8C%EC%9D%BC-%EB%8B%A4%EC%9A%B4%EB%A1%9C%EB%93%9C?category=784688
            //string ftpPath = url + "/" + str;
            //string outputFile = str;

            //// WebRequest.Create로 Http,Ftp,File Request 객체를 모두 생성할 수 있다.
            //FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);
            //// FTP 다운로드한다는 것을 표시
            //req.Method = WebRequestMethods.Ftp.DownloadFile;
            //// 익명 로그인이 아닌 경우 로그인/암호를 제공해야
            //req.Credentials = new NetworkCredential(user, pwd);

            //// FTP Request 결과를 가져온다.
            //using (FtpWebResponse resp = (FtpWebResponse)req.GetResponse())
            //{
            //    // FTP 결과 스트림
            //    Stream stream = resp.GetResponseStream();

            //    // 결과를 문자열로 읽기 (바이너리로 읽을 수도 있다)
            //    string data;
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        data = reader.ReadToEnd();
            //    }
            //    // 로컬 파일로 출력
            //    File.WriteAllText(outputFile, data);
            //}
        }

        private void checkDir(string localFullPathFile)
        {
            //출처: https://afsdzvcx123.tistory.com/entry/C-FTP-C-FTP-%EC%A0%91%EC%86%8D-%EB%B0%8F-%ED%8C%8C%EC%9D%BC-%EB%8B%A4%EC%9A%B4%EB%A1%9C%EB%93%9C?category=784688
            FileInfo fInfo = new FileInfo(localFullPathFile);

            if (!fInfo.Exists)
            {
                DirectoryInfo dInfo = new DirectoryInfo(fInfo.DirectoryName);
                if (dInfo.Exists)
                {
                    dInfo.Create();
                }
            }
        }

        // The EndGetResponseCallback method
        // completes a call to BeginGetResponse.
        private static void EndGetResponseCallback(IAsyncResult ar)
        {
            FtpState state = (FtpState)ar.AsyncState;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)state.Request.EndGetResponse(ar);
                response.Close();
                state.StatusDescription = response.StatusDescription;
                // Signal the main application thread that
                // the operation is complete.
                state.OperationComplete.Set();
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Error getting response.");
                state.OperationException = e;
                state.OperationComplete.Set();
            }
        }

        //public static bool DisplayFileFromServer(Uri serverUri, string user, string pwd)
        public static bool DisplayFileFromServer(Uri serverUri)
        {
            //TODO: 다운로드 만들고있었음
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("isi", "5788");
            try
            {
                byte[] newFileData = request.DownloadData(serverUri.ToString());
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }
    }
}
