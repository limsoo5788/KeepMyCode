namespace FTPForm
{
    partial class FTPSettingForm
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
            this.pnl_main = new System.Windows.Forms.Panel();
            this.tlp_main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_values = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_input_pw = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.tbx_input_id = new System.Windows.Forms.TextBox();
            this.tbx_id = new System.Windows.Forms.TextBox();
            this.tbx_input_port = new System.Windows.Forms.TextBox();
            this.tbx_port = new System.Windows.Forms.TextBox();
            this.tbx_input_ipadress = new System.Windows.Forms.TextBox();
            this.tbx_ipadress = new System.Windows.Forms.TextBox();
            this.tlp_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.pnl_main.SuspendLayout();
            this.tlp_main.SuspendLayout();
            this.tlp_values.SuspendLayout();
            this.tlp_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.tlp_main);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(0, 0);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(275, 179);
            this.pnl_main.TabIndex = 0;
            // 
            // tlp_main
            // 
            this.tlp_main.ColumnCount = 1;
            this.tlp_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_main.Controls.Add(this.tlp_values, 0, 0);
            this.tlp_main.Controls.Add(this.tlp_buttons, 0, 1);
            this.tlp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_main.Location = new System.Drawing.Point(0, 0);
            this.tlp_main.Name = "tlp_main";
            this.tlp_main.RowCount = 2;
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.29843F));
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.70157F));
            this.tlp_main.Size = new System.Drawing.Size(275, 179);
            this.tlp_main.TabIndex = 0;
            // 
            // tlp_values
            // 
            this.tlp_values.ColumnCount = 2;
            this.tlp_values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.48327F));
            this.tlp_values.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.51673F));
            this.tlp_values.Controls.Add(this.tbx_input_pw, 1, 3);
            this.tlp_values.Controls.Add(this.tbx_password, 0, 3);
            this.tlp_values.Controls.Add(this.tbx_input_id, 1, 2);
            this.tlp_values.Controls.Add(this.tbx_id, 0, 2);
            this.tlp_values.Controls.Add(this.tbx_input_port, 1, 1);
            this.tlp_values.Controls.Add(this.tbx_port, 0, 1);
            this.tlp_values.Controls.Add(this.tbx_input_ipadress, 1, 0);
            this.tlp_values.Controls.Add(this.tbx_ipadress, 0, 0);
            this.tlp_values.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_values.Location = new System.Drawing.Point(3, 3);
            this.tlp_values.Name = "tlp_values";
            this.tlp_values.RowCount = 4;
            this.tlp_values.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_values.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_values.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_values.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_values.Size = new System.Drawing.Size(269, 125);
            this.tlp_values.TabIndex = 0;
            // 
            // tbx_input_pw
            // 
            this.tbx_input_pw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_input_pw.Location = new System.Drawing.Point(84, 96);
            this.tbx_input_pw.Name = "tbx_input_pw";
            this.tbx_input_pw.PasswordChar = '*';
            this.tbx_input_pw.Size = new System.Drawing.Size(182, 25);
            this.tbx_input_pw.TabIndex = 7;
            // 
            // tbx_password
            // 
            this.tbx_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_password.Location = new System.Drawing.Point(3, 96);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.ReadOnly = true;
            this.tbx_password.Size = new System.Drawing.Size(75, 25);
            this.tbx_password.TabIndex = 6;
            this.tbx_password.Text = "password";
            this.tbx_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_input_id
            // 
            this.tbx_input_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_input_id.Location = new System.Drawing.Point(84, 65);
            this.tbx_input_id.Name = "tbx_input_id";
            this.tbx_input_id.Size = new System.Drawing.Size(182, 25);
            this.tbx_input_id.TabIndex = 5;
            // 
            // tbx_id
            // 
            this.tbx_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_id.Location = new System.Drawing.Point(3, 65);
            this.tbx_id.Name = "tbx_id";
            this.tbx_id.ReadOnly = true;
            this.tbx_id.Size = new System.Drawing.Size(75, 25);
            this.tbx_id.TabIndex = 4;
            this.tbx_id.Text = "id";
            this.tbx_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_input_port
            // 
            this.tbx_input_port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_input_port.Location = new System.Drawing.Point(84, 34);
            this.tbx_input_port.Name = "tbx_input_port";
            this.tbx_input_port.Size = new System.Drawing.Size(182, 25);
            this.tbx_input_port.TabIndex = 3;
            // 
            // tbx_port
            // 
            this.tbx_port.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_port.Location = new System.Drawing.Point(3, 34);
            this.tbx_port.Name = "tbx_port";
            this.tbx_port.ReadOnly = true;
            this.tbx_port.Size = new System.Drawing.Size(75, 25);
            this.tbx_port.TabIndex = 2;
            this.tbx_port.Text = "port";
            this.tbx_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_input_ipadress
            // 
            this.tbx_input_ipadress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_input_ipadress.Location = new System.Drawing.Point(84, 3);
            this.tbx_input_ipadress.Name = "tbx_input_ipadress";
            this.tbx_input_ipadress.Size = new System.Drawing.Size(182, 25);
            this.tbx_input_ipadress.TabIndex = 1;
            // 
            // tbx_ipadress
            // 
            this.tbx_ipadress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_ipadress.Location = new System.Drawing.Point(3, 3);
            this.tbx_ipadress.Name = "tbx_ipadress";
            this.tbx_ipadress.ReadOnly = true;
            this.tbx_ipadress.Size = new System.Drawing.Size(75, 25);
            this.tbx_ipadress.TabIndex = 0;
            this.tbx_ipadress.Text = "ipadress";
            this.tbx_ipadress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tlp_buttons
            // 
            this.tlp_buttons.ColumnCount = 2;
            this.tlp_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_buttons.Controls.Add(this.button2, 1, 0);
            this.tlp_buttons.Controls.Add(this.btn_connect, 0, 0);
            this.tlp_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_buttons.Location = new System.Drawing.Point(3, 134);
            this.tlp_buttons.Name = "tlp_buttons";
            this.tlp_buttons.RowCount = 1;
            this.tlp_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_buttons.Size = new System.Drawing.Size(269, 42);
            this.tlp_buttons.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(137, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_connect.Location = new System.Drawing.Point(3, 3);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(128, 36);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Change";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // FTPSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 179);
            this.Controls.Add(this.pnl_main);
            this.Name = "FTPSettingForm";
            this.Text = "FTPSettingForm";
            this.pnl_main.ResumeLayout(false);
            this.tlp_main.ResumeLayout(false);
            this.tlp_values.ResumeLayout(false);
            this.tlp_values.PerformLayout();
            this.tlp_buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.TableLayoutPanel tlp_main;
        private System.Windows.Forms.TableLayoutPanel tlp_values;
        private System.Windows.Forms.TextBox tbx_input_pw;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.TextBox tbx_input_id;
        private System.Windows.Forms.TextBox tbx_id;
        private System.Windows.Forms.TextBox tbx_input_port;
        private System.Windows.Forms.TextBox tbx_port;
        private System.Windows.Forms.TextBox tbx_input_ipadress;
        private System.Windows.Forms.TextBox tbx_ipadress;
        private System.Windows.Forms.TableLayoutPanel tlp_buttons;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_connect;
    }
}
