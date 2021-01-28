namespace OracleDBConnect_Winform
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
            this.tbx_excel_locate = new System.Windows.Forms.TextBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_excel_locate = new System.Windows.Forms.Button();
            this.btn_excel_run = new System.Windows.Forms.Button();
            this.tlp_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_query = new System.Windows.Forms.TextBox();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_DBSetting = new System.Windows.Forms.Button();
            this.pnl_back = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp_left = new System.Windows.Forms.TableLayoutPanel();
            this.lbx_sheetname = new System.Windows.Forms.ListBox();
            this.pnl_gridandbuttons = new System.Windows.Forms.Panel();
            this.tlp_gridandbottons = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_updatebuttons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tlp_main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnl_back.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlp_left.SuspendLayout();
            this.pnl_gridandbuttons.SuspendLayout();
            this.tlp_gridandbottons.SuspendLayout();
            this.tlp_updatebuttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_excel_locate
            // 
            this.tbx_excel_locate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_excel_locate.Location = new System.Drawing.Point(3, 3);
            this.tbx_excel_locate.Multiline = true;
            this.tbx_excel_locate.Name = "tbx_excel_locate";
            this.tbx_excel_locate.Size = new System.Drawing.Size(149, 53);
            this.tbx_excel_locate.TabIndex = 0;
            this.tbx_excel_locate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_excel_locate_KeyPress);
            // 
            // btn_select
            // 
            this.btn_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_select.Location = new System.Drawing.Point(3, 70);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(149, 21);
            this.btn_select.TabIndex = 0;
            this.btn_select.Text = "Run_Query";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_excel_locate
            // 
            this.btn_excel_locate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_excel_locate.Location = new System.Drawing.Point(3, 62);
            this.btn_excel_locate.Name = "btn_excel_locate";
            this.btn_excel_locate.Size = new System.Drawing.Size(149, 29);
            this.btn_excel_locate.TabIndex = 1;
            this.btn_excel_locate.Text = "찾아보기";
            this.btn_excel_locate.UseVisualStyleBackColor = true;
            this.btn_excel_locate.Click += new System.EventHandler(this.btn_excel_locate_Click);
            // 
            // btn_excel_run
            // 
            this.btn_excel_run.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_excel_run.Location = new System.Drawing.Point(3, 303);
            this.btn_excel_run.Name = "btn_excel_run";
            this.btn_excel_run.Size = new System.Drawing.Size(155, 94);
            this.btn_excel_run.TabIndex = 1;
            this.btn_excel_run.Text = "Import_Excel";
            this.btn_excel_run.UseVisualStyleBackColor = true;
            this.btn_excel_run.Click += new System.EventHandler(this.btn_excel_import_Click);
            // 
            // tlp_main
            // 
            this.tlp_main.ColumnCount = 1;
            this.tlp_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlp_main.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tlp_main.Controls.Add(this.btn_excel_run, 0, 3);
            this.tlp_main.Controls.Add(this.btn_export, 0, 4);
            this.tlp_main.Controls.Add(this.btn_DBSetting, 0, 0);
            this.tlp_main.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp_main.Location = new System.Drawing.Point(576, 0);
            this.tlp_main.Name = "tlp_main";
            this.tlp_main.RowCount = 5;
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_main.Size = new System.Drawing.Size(161, 504);
            this.tlp_main.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.46429F));
            this.tableLayoutPanel1.Controls.Add(this.tbx_excel_locate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_excel_locate, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 94);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_select, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbx_query, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 203);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.66666F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(155, 94);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tbx_query
            // 
            this.tbx_query.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_query.Location = new System.Drawing.Point(3, 3);
            this.tbx_query.Multiline = true;
            this.tbx_query.Name = "tbx_query";
            this.tbx_query.Size = new System.Drawing.Size(149, 61);
            this.tbx_query.TabIndex = 1;
            this.tbx_query.Text = "select * from tab;";
            // 
            // btn_export
            // 
            this.btn_export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_export.Location = new System.Drawing.Point(3, 403);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(155, 98);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "Export_DataGridView";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_DBSetting
            // 
            this.btn_DBSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DBSetting.Location = new System.Drawing.Point(3, 3);
            this.btn_DBSetting.Name = "btn_DBSetting";
            this.btn_DBSetting.Size = new System.Drawing.Size(155, 94);
            this.btn_DBSetting.TabIndex = 5;
            this.btn_DBSetting.Text = "DBSetting";
            this.btn_DBSetting.UseVisualStyleBackColor = true;
            this.btn_DBSetting.Click += new System.EventHandler(this.btn_DBSetting_Click);
            // 
            // pnl_back
            // 
            this.pnl_back.Controls.Add(this.panel1);
            this.pnl_back.Controls.Add(this.tlp_main);
            this.pnl_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_back.Location = new System.Drawing.Point(0, 0);
            this.pnl_back.Name = "pnl_back";
            this.pnl_back.Size = new System.Drawing.Size(737, 504);
            this.pnl_back.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlp_left);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 504);
            this.panel1.TabIndex = 2;
            // 
            // tlp_left
            // 
            this.tlp_left.ColumnCount = 2;
            this.tlp_left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tlp_left.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tlp_left.Controls.Add(this.lbx_sheetname, 1, 0);
            this.tlp_left.Controls.Add(this.pnl_gridandbuttons, 0, 0);
            this.tlp_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_left.Location = new System.Drawing.Point(0, 0);
            this.tlp_left.Name = "tlp_left";
            this.tlp_left.RowCount = 1;
            this.tlp_left.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_left.Size = new System.Drawing.Size(576, 504);
            this.tlp_left.TabIndex = 4;
            // 
            // lbx_sheetname
            // 
            this.lbx_sheetname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_sheetname.FormattingEnabled = true;
            this.lbx_sheetname.ItemHeight = 15;
            this.lbx_sheetname.Location = new System.Drawing.Point(481, 3);
            this.lbx_sheetname.Name = "lbx_sheetname";
            this.lbx_sheetname.Size = new System.Drawing.Size(92, 498);
            this.lbx_sheetname.TabIndex = 3;
            this.lbx_sheetname.Click += new System.EventHandler(this.lbx_sheetname_Click);
            // 
            // pnl_gridandbuttons
            // 
            this.pnl_gridandbuttons.Controls.Add(this.tlp_gridandbottons);
            this.pnl_gridandbuttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_gridandbuttons.Location = new System.Drawing.Point(3, 3);
            this.pnl_gridandbuttons.Name = "pnl_gridandbuttons";
            this.pnl_gridandbuttons.Size = new System.Drawing.Size(472, 498);
            this.pnl_gridandbuttons.TabIndex = 4;
            // 
            // tlp_gridandbottons
            // 
            this.tlp_gridandbottons.ColumnCount = 1;
            this.tlp_gridandbottons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_gridandbottons.Controls.Add(this.tlp_updatebuttons, 0, 1);
            this.tlp_gridandbottons.Controls.Add(this.dataGridView1, 0, 0);
            this.tlp_gridandbottons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_gridandbottons.Location = new System.Drawing.Point(0, 0);
            this.tlp_gridandbottons.Name = "tlp_gridandbottons";
            this.tlp_gridandbottons.RowCount = 2;
            this.tlp_gridandbottons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_gridandbottons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_gridandbottons.Size = new System.Drawing.Size(472, 498);
            this.tlp_gridandbottons.TabIndex = 6;
            // 
            // tlp_updatebuttons
            // 
            this.tlp_updatebuttons.ColumnCount = 2;
            this.tlp_updatebuttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_updatebuttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tlp_updatebuttons.Controls.Add(this.btn_update, 0, 0);
            this.tlp_updatebuttons.Controls.Add(this.btn_cancle, 1, 0);
            this.tlp_updatebuttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlp_updatebuttons.Location = new System.Drawing.Point(3, 458);
            this.tlp_updatebuttons.Name = "tlp_updatebuttons";
            this.tlp_updatebuttons.RowCount = 1;
            this.tlp_updatebuttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_updatebuttons.Size = new System.Drawing.Size(466, 37);
            this.tlp_updatebuttons.TabIndex = 7;
            // 
            // btn_update
            // 
            this.btn_update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_update.Location = new System.Drawing.Point(3, 3);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(228, 31);
            this.btn_update.TabIndex = 0;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.GridViewUpdateBottons);
            // 
            // btn_cancle
            // 
            this.btn_cancle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_cancle.Location = new System.Drawing.Point(237, 3);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(226, 31);
            this.btn_cancle.TabIndex = 1;
            this.btn_cancle.Text = "Cancle";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.GridViewUpdateBottons);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(466, 448);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 504);
            this.Controls.Add(this.pnl_back);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tlp_main.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnl_back.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlp_left.ResumeLayout(false);
            this.pnl_gridandbuttons.ResumeLayout(false);
            this.tlp_gridandbottons.ResumeLayout(false);
            this.tlp_updatebuttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_excel_locate;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_excel_locate;
        private System.Windows.Forms.Button btn_excel_run;
        private System.Windows.Forms.TableLayoutPanel tlp_main;
        private System.Windows.Forms.Panel pnl_back;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbx_query;
        private System.Windows.Forms.ListBox lbx_sheetname;
        private System.Windows.Forms.Button btn_DBSetting;
        private System.Windows.Forms.TableLayoutPanel tlp_left;
        private System.Windows.Forms.Panel pnl_gridandbuttons;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tlp_gridandbottons;
        private System.Windows.Forms.TableLayoutPanel tlp_updatebuttons;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_cancle;
    }
}
