namespace FTPForm
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_back = new System.Windows.Forms.Panel();
            this.tpl_main = new System.Windows.Forms.TableLayoutPanel();
            this.tpl_buttons_download = new System.Windows.Forms.TableLayoutPanel();
            this.btn_download_plus = new System.Windows.Forms.Button();
            this.btn_download_minus = new System.Windows.Forms.Button();
            this.tpl_buttons_upload = new System.Windows.Forms.TableLayoutPanel();
            this.btn_upload_plus = new System.Windows.Forms.Button();
            this.btn_upload_minus = new System.Windows.Forms.Button();
            this.tbx_download = new System.Windows.Forms.TextBox();
            this.tbx_upload = new System.Windows.Forms.TextBox();
            this.lbx_upload = new System.Windows.Forms.ListBox();
            this.btn_download = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbx_download = new System.Windows.Forms.ListBox();
            this.lbx_ftpfilelist = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ftpsetting = new System.Windows.Forms.Button();
            this.pnl_back.SuspendLayout();
            this.tpl_main.SuspendLayout();
            this.tpl_buttons_download.SuspendLayout();
            this.tpl_buttons_upload.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_back
            // 
            this.pnl_back.Controls.Add(this.tpl_main);
            this.pnl_back.Location = new System.Drawing.Point(0, 29);
            this.pnl_back.Name = "pnl_back";
            this.pnl_back.Size = new System.Drawing.Size(814, 399);
            this.pnl_back.TabIndex = 0;
            // 
            // tpl_main
            // 
            this.tpl_main.ColumnCount = 2;
            this.tpl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_main.Controls.Add(this.tpl_buttons_download, 0, 2);
            this.tpl_main.Controls.Add(this.tpl_buttons_upload, 1, 2);
            this.tpl_main.Controls.Add(this.tbx_download, 0, 0);
            this.tpl_main.Controls.Add(this.tbx_upload, 1, 0);
            this.tpl_main.Controls.Add(this.lbx_upload, 1, 1);
            this.tpl_main.Controls.Add(this.btn_download, 0, 3);
            this.tpl_main.Controls.Add(this.btn_upload, 1, 3);
            this.tpl_main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tpl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpl_main.Location = new System.Drawing.Point(0, 0);
            this.tpl_main.Name = "tpl_main";
            this.tpl_main.RowCount = 4;
            this.tpl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.579439F));
            this.tpl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.99065F));
            this.tpl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.38318F));
            this.tpl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.813084F));
            this.tpl_main.Size = new System.Drawing.Size(814, 399);
            this.tpl_main.TabIndex = 0;
            // 
            // tpl_buttons_download
            // 
            this.tpl_buttons_download.ColumnCount = 2;
            this.tpl_buttons_download.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_buttons_download.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_buttons_download.Controls.Add(this.btn_download_plus, 0, 0);
            this.tpl_buttons_download.Controls.Add(this.btn_download_minus, 1, 0);
            this.tpl_buttons_download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpl_buttons_download.Location = new System.Drawing.Point(3, 312);
            this.tpl_buttons_download.Name = "tpl_buttons_download";
            this.tpl_buttons_download.RowCount = 1;
            this.tpl_buttons_download.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpl_buttons_download.Size = new System.Drawing.Size(401, 43);
            this.tpl_buttons_download.TabIndex = 0;
            // 
            // btn_download_plus
            // 
            this.btn_download_plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_download_plus.Font = new System.Drawing.Font("굴림", 20F);
            this.btn_download_plus.Location = new System.Drawing.Point(3, 3);
            this.btn_download_plus.Name = "btn_download_plus";
            this.btn_download_plus.Size = new System.Drawing.Size(194, 37);
            this.btn_download_plus.TabIndex = 0;
            this.btn_download_plus.Text = "+";
            this.btn_download_plus.UseVisualStyleBackColor = true;
            this.btn_download_plus.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btn_download_minus
            // 
            this.btn_download_minus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_download_minus.Font = new System.Drawing.Font("굴림", 20F);
            this.btn_download_minus.Location = new System.Drawing.Point(203, 3);
            this.btn_download_minus.Name = "btn_download_minus";
            this.btn_download_minus.Size = new System.Drawing.Size(195, 37);
            this.btn_download_minus.TabIndex = 1;
            this.btn_download_minus.Text = "-";
            this.btn_download_minus.UseVisualStyleBackColor = true;
            this.btn_download_minus.Click += new System.EventHandler(this.ButtonClick);
            // 
            // tpl_buttons_upload
            // 
            this.tpl_buttons_upload.ColumnCount = 2;
            this.tpl_buttons_upload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_buttons_upload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpl_buttons_upload.Controls.Add(this.btn_upload_plus, 0, 0);
            this.tpl_buttons_upload.Controls.Add(this.btn_upload_minus, 1, 0);
            this.tpl_buttons_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpl_buttons_upload.Location = new System.Drawing.Point(410, 312);
            this.tpl_buttons_upload.Name = "tpl_buttons_upload";
            this.tpl_buttons_upload.RowCount = 1;
            this.tpl_buttons_upload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpl_buttons_upload.Size = new System.Drawing.Size(401, 43);
            this.tpl_buttons_upload.TabIndex = 1;
            // 
            // btn_upload_plus
            // 
            this.btn_upload_plus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_upload_plus.Font = new System.Drawing.Font("굴림", 20F);
            this.btn_upload_plus.Location = new System.Drawing.Point(3, 3);
            this.btn_upload_plus.Name = "btn_upload_plus";
            this.btn_upload_plus.Size = new System.Drawing.Size(194, 37);
            this.btn_upload_plus.TabIndex = 0;
            this.btn_upload_plus.Text = "+";
            this.btn_upload_plus.UseVisualStyleBackColor = true;
            this.btn_upload_plus.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btn_upload_minus
            // 
            this.btn_upload_minus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_upload_minus.Font = new System.Drawing.Font("굴림", 20F);
            this.btn_upload_minus.Location = new System.Drawing.Point(203, 3);
            this.btn_upload_minus.Name = "btn_upload_minus";
            this.btn_upload_minus.Size = new System.Drawing.Size(195, 37);
            this.btn_upload_minus.TabIndex = 1;
            this.btn_upload_minus.Text = "-";
            this.btn_upload_minus.UseVisualStyleBackColor = true;
            this.btn_upload_minus.Click += new System.EventHandler(this.ButtonClick);
            // 
            // tbx_download
            // 
            this.tbx_download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_download.Font = new System.Drawing.Font("굴림", 16F);
            this.tbx_download.Location = new System.Drawing.Point(3, 3);
            this.tbx_download.Multiline = true;
            this.tbx_download.Name = "tbx_download";
            this.tbx_download.ReadOnly = true;
            this.tbx_download.Size = new System.Drawing.Size(401, 32);
            this.tbx_download.TabIndex = 2;
            this.tbx_download.Text = "Download";
            this.tbx_download.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbx_upload
            // 
            this.tbx_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_upload.Font = new System.Drawing.Font("굴림", 16F);
            this.tbx_upload.Location = new System.Drawing.Point(410, 3);
            this.tbx_upload.Multiline = true;
            this.tbx_upload.Name = "tbx_upload";
            this.tbx_upload.ReadOnly = true;
            this.tbx_upload.Size = new System.Drawing.Size(401, 32);
            this.tbx_upload.TabIndex = 3;
            this.tbx_upload.Text = "Upload";
            this.tbx_upload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbx_upload
            // 
            this.lbx_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_upload.FormattingEnabled = true;
            this.lbx_upload.ItemHeight = 15;
            this.lbx_upload.Location = new System.Drawing.Point(410, 41);
            this.lbx_upload.MultiColumn = true;
            this.lbx_upload.Name = "lbx_upload";
            this.lbx_upload.Size = new System.Drawing.Size(401, 265);
            this.lbx_upload.TabIndex = 5;
            // 
            // btn_download
            // 
            this.btn_download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_download.Location = new System.Drawing.Point(3, 361);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(401, 35);
            this.btn_download.TabIndex = 6;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btn_upload
            // 
            this.btn_upload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_upload.Location = new System.Drawing.Point(410, 361);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(401, 35);
            this.btn_upload.TabIndex = 7;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.ButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbx_download, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbx_ftpfilelist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.9434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.0566F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 265);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // lbx_download
            // 
            this.lbx_download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_download.FormattingEnabled = true;
            this.lbx_download.ItemHeight = 15;
            this.lbx_download.Location = new System.Drawing.Point(203, 32);
            this.lbx_download.Name = "lbx_download";
            this.lbx_download.Size = new System.Drawing.Size(195, 230);
            this.lbx_download.TabIndex = 12;
            // 
            // lbx_ftpfilelist
            // 
            this.lbx_ftpfilelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_ftpfilelist.FormattingEnabled = true;
            this.lbx_ftpfilelist.ItemHeight = 15;
            this.lbx_ftpfilelist.Location = new System.Drawing.Point(3, 32);
            this.lbx_ftpfilelist.Name = "lbx_ftpfilelist";
            this.lbx_ftpfilelist.Size = new System.Drawing.Size(194, 230);
            this.lbx_ftpfilelist.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(203, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(195, 25);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "DownLoadList";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(194, 25);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "FTPList(Folder X)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ftpsetting);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 26);
            this.panel1.TabIndex = 1;
            // 
            // btn_ftpsetting
            // 
            this.btn_ftpsetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ftpsetting.Location = new System.Drawing.Point(0, 0);
            this.btn_ftpsetting.Name = "btn_ftpsetting";
            this.btn_ftpsetting.Size = new System.Drawing.Size(814, 26);
            this.btn_ftpsetting.TabIndex = 0;
            this.btn_ftpsetting.Text = "FTPSetting";
            this.btn_ftpsetting.UseVisualStyleBackColor = true;
            this.btn_ftpsetting.Click += new System.EventHandler(this.ButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 428);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_back);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.pnl_back.ResumeLayout(false);
            this.tpl_main.ResumeLayout(false);
            this.tpl_main.PerformLayout();
            this.tpl_buttons_download.ResumeLayout(false);
            this.tpl_buttons_upload.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_back;
        private System.Windows.Forms.TableLayoutPanel tpl_main;
        private System.Windows.Forms.TableLayoutPanel tpl_buttons_download;
        private System.Windows.Forms.Button btn_download_plus;
        private System.Windows.Forms.Button btn_download_minus;
        private System.Windows.Forms.TableLayoutPanel tpl_buttons_upload;
        private System.Windows.Forms.Button btn_upload_plus;
        private System.Windows.Forms.Button btn_upload_minus;
        private System.Windows.Forms.TextBox tbx_download;
        private System.Windows.Forms.TextBox tbx_upload;
        private System.Windows.Forms.ListBox lbx_upload;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ftpsetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lbx_ftpfilelist;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lbx_download;
    }
}
