namespace OracleDBConnect_Winform
{
    partial class DBSettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbl_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_protocol = new System.Windows.Forms.TextBox();
            this.tbx_host = new System.Windows.Forms.TextBox();
            this.tbx_port = new System.Windows.Forms.TextBox();
            this.tbx_server = new System.Windows.Forms.TextBox();
            this.tbx_servicename = new System.Windows.Forms.TextBox();
            this.tbx_id = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.tbx_inp_protocol = new System.Windows.Forms.TextBox();
            this.tbx_inp_host = new System.Windows.Forms.TextBox();
            this.tbx_inp_port = new System.Windows.Forms.TextBox();
            this.tbx_inp_server = new System.Windows.Forms.TextBox();
            this.tbx_inp_servicename = new System.Windows.Forms.TextBox();
            this.tbx_inp_id = new System.Windows.Forms.TextBox();
            this.tbx_inp_pw = new System.Windows.Forms.TextBox();
            this.tbl_main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_main
            // 
            this.tbl_main.ColumnCount = 1;
            this.tbl_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tbl_main.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tbl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl_main.Location = new System.Drawing.Point(0, 0);
            this.tbl_main.Name = "tbl_main";
            this.tbl_main.RowCount = 2;
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.6087F));
            this.tbl_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.3913F));
            this.tbl_main.Size = new System.Drawing.Size(282, 253);
            this.tbl_main.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_connect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 212);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(276, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_connect
            // 
            this.btn_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_connect.Location = new System.Drawing.Point(3, 3);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(132, 32);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "TryConnect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancle.Location = new System.Drawing.Point(141, 3);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(132, 32);
            this.btn_cancle.TabIndex = 1;
            this.btn_cancle.Text = "Cancle";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel2.Controls.Add(this.tbx_protocol, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbx_host, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbx_port, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbx_server, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbx_servicename, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbx_id, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbx_password, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_protocol, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_host, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_port, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_server, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_servicename, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_id, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.tbx_inp_pw, 1, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.80788F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.77833F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(276, 203);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tbx_protocol
            // 
            this.tbx_protocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_protocol.Location = new System.Drawing.Point(3, 3);
            this.tbx_protocol.Name = "tbx_protocol";
            this.tbx_protocol.ReadOnly = true;
            this.tbx_protocol.Size = new System.Drawing.Size(95, 25);
            this.tbx_protocol.TabIndex = 0;
            this.tbx_protocol.Text = "protocol";
            this.tbx_protocol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_host
            // 
            this.tbx_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_host.Location = new System.Drawing.Point(3, 32);
            this.tbx_host.Name = "tbx_host";
            this.tbx_host.ReadOnly = true;
            this.tbx_host.Size = new System.Drawing.Size(95, 25);
            this.tbx_host.TabIndex = 1;
            this.tbx_host.Text = "host";
            this.tbx_host.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_port
            // 
            this.tbx_port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_port.Location = new System.Drawing.Point(3, 58);
            this.tbx_port.Name = "tbx_port";
            this.tbx_port.ReadOnly = true;
            this.tbx_port.Size = new System.Drawing.Size(95, 25);
            this.tbx_port.TabIndex = 2;
            this.tbx_port.Text = "port";
            this.tbx_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_server
            // 
            this.tbx_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_server.Location = new System.Drawing.Point(3, 88);
            this.tbx_server.Name = "tbx_server";
            this.tbx_server.ReadOnly = true;
            this.tbx_server.Size = new System.Drawing.Size(95, 25);
            this.tbx_server.TabIndex = 3;
            this.tbx_server.Text = "server";
            this.tbx_server.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_servicename
            // 
            this.tbx_servicename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_servicename.Location = new System.Drawing.Point(3, 117);
            this.tbx_servicename.Name = "tbx_servicename";
            this.tbx_servicename.ReadOnly = true;
            this.tbx_servicename.Size = new System.Drawing.Size(95, 25);
            this.tbx_servicename.TabIndex = 4;
            this.tbx_servicename.Text = "servicename";
            this.tbx_servicename.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_id
            // 
            this.tbx_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_id.Location = new System.Drawing.Point(3, 146);
            this.tbx_id.Name = "tbx_id";
            this.tbx_id.ReadOnly = true;
            this.tbx_id.Size = new System.Drawing.Size(95, 25);
            this.tbx_id.TabIndex = 5;
            this.tbx_id.Text = "ID";
            this.tbx_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_password
            // 
            this.tbx_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_password.Location = new System.Drawing.Point(3, 175);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.ReadOnly = true;
            this.tbx_password.Size = new System.Drawing.Size(95, 25);
            this.tbx_password.TabIndex = 6;
            this.tbx_password.Text = "PW";
            this.tbx_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_inp_protocol
            // 
            this.tbx_inp_protocol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_protocol.Location = new System.Drawing.Point(104, 3);
            this.tbx_inp_protocol.Name = "tbx_inp_protocol";
            this.tbx_inp_protocol.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_protocol.TabIndex = 7;
            this.tbx_inp_protocol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_host
            // 
            this.tbx_inp_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_host.Location = new System.Drawing.Point(104, 32);
            this.tbx_inp_host.Name = "tbx_inp_host";
            this.tbx_inp_host.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_host.TabIndex = 8;
            this.tbx_inp_host.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_port
            // 
            this.tbx_inp_port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_port.Location = new System.Drawing.Point(104, 58);
            this.tbx_inp_port.Name = "tbx_inp_port";
            this.tbx_inp_port.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_port.TabIndex = 9;
            this.tbx_inp_port.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_server
            // 
            this.tbx_inp_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_server.Location = new System.Drawing.Point(104, 88);
            this.tbx_inp_server.Name = "tbx_inp_server";
            this.tbx_inp_server.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_server.TabIndex = 10;
            this.tbx_inp_server.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_servicename
            // 
            this.tbx_inp_servicename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_servicename.Location = new System.Drawing.Point(104, 117);
            this.tbx_inp_servicename.Name = "tbx_inp_servicename";
            this.tbx_inp_servicename.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_servicename.TabIndex = 11;
            this.tbx_inp_servicename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_id
            // 
            this.tbx_inp_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_id.Location = new System.Drawing.Point(104, 146);
            this.tbx_inp_id.Name = "tbx_inp_id";
            this.tbx_inp_id.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_id.TabIndex = 12;
            this.tbx_inp_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // tbx_inp_pw
            // 
            this.tbx_inp_pw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_inp_pw.Location = new System.Drawing.Point(104, 175);
            this.tbx_inp_pw.Name = "tbx_inp_pw";
            this.tbx_inp_pw.PasswordChar = '*';
            this.tbx_inp_pw.Size = new System.Drawing.Size(169, 25);
            this.tbx_inp_pw.TabIndex = 13;
            this.tbx_inp_pw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_inp_KeyDown);
            // 
            // DBSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.tbl_main);
            this.Name = "DBSettingForm";
            this.Text = "DBSettingForm";
            this.tbl_main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbx_protocol;
        private System.Windows.Forms.TextBox tbx_host;
        private System.Windows.Forms.TextBox tbx_port;
        private System.Windows.Forms.TextBox tbx_server;
        private System.Windows.Forms.TextBox tbx_servicename;
        private System.Windows.Forms.TextBox tbx_id;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.TextBox tbx_inp_protocol;
        private System.Windows.Forms.TextBox tbx_inp_host;
        private System.Windows.Forms.TextBox tbx_inp_port;
        private System.Windows.Forms.TextBox tbx_inp_server;
        private System.Windows.Forms.TextBox tbx_inp_servicename;
        private System.Windows.Forms.TextBox tbx_inp_id;
        private System.Windows.Forms.TextBox tbx_inp_pw;
    }
}
