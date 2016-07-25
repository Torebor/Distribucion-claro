namespace Claro_nicaragua
{
    partial class frmrpt_master
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dptfechafin = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dptfechaini = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.autoLabel20 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btngenerar = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cbopciones = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel19 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.hilo_rpt = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dptfechafin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptfechaini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbopciones)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dptfechafin);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Controls.Add(this.dptfechaini);
            this.panel1.Controls.Add(this.autoLabel20);
            this.panel1.Controls.Add(this.btngenerar);
            this.panel1.Controls.Add(this.cbopciones);
            this.panel1.Controls.Add(this.autoLabel19);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 52);
            this.panel1.TabIndex = 0;
            // 
            // dptfechafin
            // 
            this.dptfechafin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dptfechafin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dptfechafin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dptfechafin.CalendarSize = new System.Drawing.Size(189, 176);
            this.dptfechafin.DropDownImage = null;
            this.dptfechafin.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechafin.DropDownPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechafin.DropDownSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(112)))), ((int)(((byte)(202)))));
            this.dptfechafin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptfechafin.Location = new System.Drawing.Point(438, 19);
            this.dptfechafin.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechafin.MinValue = new System.DateTime(((long)(0)));
            this.dptfechafin.Name = "dptfechafin";
            this.dptfechafin.ShowCheckBox = false;
            this.dptfechafin.Size = new System.Drawing.Size(106, 20);
            this.dptfechafin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.dptfechafin.TabIndex = 23;
            this.dptfechafin.Value = new System.DateTime(2016, 5, 6, 13, 41, 27, 473);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.autoLabel1.Location = new System.Drawing.Point(396, 24);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(40, 15);
            this.autoLabel1.TabIndex = 22;
            this.autoLabel1.Text = "Hasta:";
            // 
            // dptfechaini
            // 
            this.dptfechaini.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dptfechaini.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dptfechaini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dptfechaini.CalendarSize = new System.Drawing.Size(189, 176);
            this.dptfechaini.DropDownImage = null;
            this.dptfechaini.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechaini.DropDownPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechaini.DropDownSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(112)))), ((int)(((byte)(202)))));
            this.dptfechaini.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptfechaini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptfechaini.Location = new System.Drawing.Point(284, 19);
            this.dptfechaini.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.dptfechaini.MinValue = new System.DateTime(((long)(0)));
            this.dptfechaini.Name = "dptfechaini";
            this.dptfechaini.ShowCheckBox = false;
            this.dptfechaini.Size = new System.Drawing.Size(106, 20);
            this.dptfechaini.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.dptfechaini.TabIndex = 21;
            this.dptfechaini.Value = new System.DateTime(2016, 5, 6, 13, 41, 27, 473);
            // 
            // autoLabel20
            // 
            this.autoLabel20.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.autoLabel20.Location = new System.Drawing.Point(259, 24);
            this.autoLabel20.Name = "autoLabel20";
            this.autoLabel20.Size = new System.Drawing.Size(24, 15);
            this.autoLabel20.TabIndex = 20;
            this.autoLabel20.Text = "De:";
            // 
            // btngenerar
            // 
            this.btngenerar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btngenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btngenerar.BeforeTouchSize = new System.Drawing.Size(114, 25);
            this.btngenerar.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngenerar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerar.ForeColor = System.Drawing.Color.White;
            this.btngenerar.IsBackStageButton = false;
            this.btngenerar.Location = new System.Drawing.Point(598, 16);
            this.btngenerar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(114, 25);
            this.btngenerar.TabIndex = 19;
            this.btngenerar.Text = "Generar";
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // cbopciones
            // 
            this.cbopciones.BackColor = System.Drawing.Color.White;
            this.cbopciones.BeforeTouchSize = new System.Drawing.Size(163, 23);
            this.cbopciones.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cbopciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopciones.Items.AddRange(new object[] {
            "Distribuidas"});
            this.cbopciones.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cbopciones, "Distribuidas"));
            this.cbopciones.Location = new System.Drawing.Point(79, 16);
            this.cbopciones.Name = "cbopciones";
            this.cbopciones.Size = new System.Drawing.Size(163, 23);
            this.cbopciones.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.cbopciones.TabIndex = 16;
            this.cbopciones.Text = "Distribuidas";
            this.cbopciones.UseMetroColorsInActiveMode = true;
            // 
            // autoLabel19
            // 
            this.autoLabel19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel19.Location = new System.Drawing.Point(22, 24);
            this.autoLabel19.Name = "autoLabel19";
            this.autoLabel19.Size = new System.Drawing.Size(54, 15);
            this.autoLabel19.TabIndex = 7;
            this.autoLabel19.Text = "Mostrar: ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1188, 594);
            this.panel2.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1188, 594);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // hilo_rpt
            // 
            this.hilo_rpt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.hilo_rpt_DoWork);
            this.hilo_rpt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.hilo_rpt_RunWorkerCompleted);
            // 
            // frmrpt_master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 664);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmrpt_master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.frmrpt_master_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dptfechafin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptfechaini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbopciones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel19;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbopciones;
        private Syncfusion.Windows.Forms.ButtonAdv btngenerar;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dptfechafin;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dptfechaini;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel20;
        private System.ComponentModel.BackgroundWorker hilo_rpt;
    }
}