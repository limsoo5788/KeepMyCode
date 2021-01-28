namespace FTP
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_targetlist = new System.Windows.Forms.ListBox();
            this.lbx_deletelist = new System.Windows.Forms.ListBox();
            this.lbx_uploadlist = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP Connecter";
            // 
            // lbx_targetlist
            // 
            this.lbx_targetlist.FormattingEnabled = true;
            this.lbx_targetlist.ItemHeight = 15;
            this.lbx_targetlist.Location = new System.Drawing.Point(21, 64);
            this.lbx_targetlist.Name = "lbx_targetlist";
            this.lbx_targetlist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbx_targetlist.Size = new System.Drawing.Size(150, 289);
            this.lbx_targetlist.TabIndex = 1;
            // 
            // lbx_deletelist
            // 
            this.lbx_deletelist.FormattingEnabled = true;
            this.lbx_deletelist.ItemHeight = 15;
            this.lbx_deletelist.Location = new System.Drawing.Point(177, 64);
            this.lbx_deletelist.Name = "lbx_deletelist";
            this.lbx_deletelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbx_deletelist.Size = new System.Drawing.Size(153, 289);
            this.lbx_deletelist.TabIndex = 2;
            // 
            // lbx_uploadlist
            // 
            this.lbx_uploadlist.FormattingEnabled = true;
            this.lbx_uploadlist.ItemHeight = 15;
            this.lbx_uploadlist.Location = new System.Drawing.Point(667, 64);
            this.lbx_uploadlist.Name = "lbx_uploadlist";
            this.lbx_uploadlist.Size = new System.Drawing.Size(120, 94);
            this.lbx_uploadlist.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "<-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "->";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(769, 417);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "upload";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(309, 32);
            this.button4.TabIndex = 7;
            this.button4.Text = "start";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "DoNot";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 507);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbx_uploadlist);
            this.Controls.Add(this.lbx_deletelist);
            this.Controls.Add(this.lbx_targetlist);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_targetlist;
        private System.Windows.Forms.ListBox lbx_deletelist;
        private System.Windows.Forms.ListBox lbx_uploadlist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
