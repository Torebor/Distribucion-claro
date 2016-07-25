#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmreencaminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmreencaminar));
            this.btnreen = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtcodigo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cbdestino = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtdespacho = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnnuevo = new System.Windows.Forms.ToolStripButton();
            this.btnprint = new System.Windows.Forms.ToolStripButton();
            this.dgvreenca = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panelinforeen = new System.Windows.Forms.Panel();
            this.autoLabel22 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dgvdestinos = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnanular = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdestino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdespacho)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreenca)).BeginInit();
            this.panelinforeen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdestinos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnreen
            // 
            this.btnreen.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnreen.BeforeTouchSize = new System.Drawing.Size(104, 28);
            this.btnreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreen.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnreen.ForeColor = System.Drawing.Color.White;
            this.btnreen.IsBackStageButton = false;
            this.btnreen.Location = new System.Drawing.Point(267, 122);
            this.btnreen.Name = "btnreen";
            this.btnreen.Size = new System.Drawing.Size(104, 28);
            this.btnreen.TabIndex = 10;
            this.btnreen.Text = "Agregar";
            this.btnreen.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.BeforeTouchSize = new System.Drawing.Size(179, 23);
            this.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(342, 83);
            this.txtcodigo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(179, 23);
            this.txtcodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtcodigo.TabIndex = 9;
            this.txtcodigo.TextChanged += new System.EventHandler(this.txtcodigo_TextChanged);
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(267, 89);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 6;
            this.autoLabel1.Text = "Codigo:";
            this.autoLabel1.Click += new System.EventHandler(this.autoLabel1_Click);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(12, 39);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(58, 17);
            this.autoLabel2.TabIndex = 9;
            this.autoLabel2.Text = "Destinos";
            // 
            // cbdestino
            // 
            this.cbdestino.BackColor = System.Drawing.Color.White;
            this.cbdestino.BeforeTouchSize = new System.Drawing.Size(192, 23);
            this.cbdestino.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cbdestino.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdestino.Location = new System.Drawing.Point(267, 53);
            this.cbdestino.Name = "cbdestino";
            this.cbdestino.Size = new System.Drawing.Size(192, 23);
            this.cbdestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.cbdestino.TabIndex = 7;
            this.cbdestino.UseMetroColorsInActiveMode = true;
            this.cbdestino.Visible = false;
            this.cbdestino.SelectedValueChanged += new System.EventHandler(this.cbdestino_SelectedValueChanged);
            this.cbdestino.Enter += new System.EventHandler(this.cbdestino_Enter);
            this.cbdestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbdestino_KeyPress);
            this.cbdestino.Leave += new System.EventHandler(this.cbdestino_Leave);
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(267, 53);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(69, 17);
            this.autoLabel3.TabIndex = 15;
            this.autoLabel3.Text = "Despacho:";
            // 
            // txtdespacho
            // 
            this.txtdespacho.BeforeTouchSize = new System.Drawing.Size(179, 23);
            this.txtdespacho.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdespacho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdespacho.Location = new System.Drawing.Point(342, 47);
            this.txtdespacho.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtdespacho.Name = "txtdespacho";
            this.txtdespacho.Size = new System.Drawing.Size(179, 23);
            this.txtdespacho.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtdespacho.TabIndex = 8;
            this.txtdespacho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdespacho_KeyDown);
            this.txtdespacho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdespacho_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnnuevo,
            this.btnprint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(897, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnnuevo
            // 
            this.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnnuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnnuevo.Image")));
            this.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(46, 22);
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // btnprint
            // 
            this.btnprint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(106, 22);
            this.btnprint.Text = "Imprimir remisión";
            // 
            // dgvreenca
            // 
            this.dgvreenca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvreenca.BackColor = System.Drawing.SystemColors.Window;
            this.dgvreenca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvreenca.FreezeCaption = false;
            this.dgvreenca.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvreenca.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvreenca.Location = new System.Drawing.Point(267, 168);
            this.dgvreenca.Name = "dgvreenca";
            this.dgvreenca.Size = new System.Drawing.Size(618, 279);
            this.dgvreenca.TabIndex = 17;
            this.dgvreenca.TableDescriptor.AllowEdit = false;
            this.dgvreenca.TableDescriptor.AllowNew = false;
            this.dgvreenca.TableDescriptor.AllowRemove = false;
            this.dgvreenca.TableDescriptor.Appearance.GroupCaptionCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvreenca.TableDescriptor.Appearance.GroupCaptionRowHeaderCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this.dgvreenca.TableDescriptor.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount} Registros";
            this.dgvreenca.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvreenca.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvreenca.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvreenca.TableOptions.AllowDragColumns = false;
            this.dgvreenca.TableOptions.AllowDropDownCell = false;
            this.dgvreenca.TableOptions.AllowMultiColumnSort = false;
            this.dgvreenca.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.dgvreenca.TableOptions.AllowSortColumns = false;
            this.dgvreenca.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.dgvreenca.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvreenca.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvreenca.VersionInfo = "14.1400.0.41";
            this.dgvreenca.Visible = false;
            // 
            // panelinforeen
            // 
            this.panelinforeen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelinforeen.Controls.Add(this.autoLabel22);
            this.panelinforeen.Controls.Add(this.pictureBox4);
            this.panelinforeen.Location = new System.Drawing.Point(438, 217);
            this.panelinforeen.Name = "panelinforeen";
            this.panelinforeen.Size = new System.Drawing.Size(299, 130);
            this.panelinforeen.TabIndex = 20;
            // 
            // autoLabel22
            // 
            this.autoLabel22.AutoSize = false;
            this.autoLabel22.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel22.Location = new System.Drawing.Point(119, 16);
            this.autoLabel22.Name = "autoLabel22";
            this.autoLabel22.Size = new System.Drawing.Size(161, 96);
            this.autoLabel22.TabIndex = 21;
            this.autoLabel22.Text = "Reencaminar facturas";
            this.autoLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(114, 130);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // dgvdestinos
            // 
            this.dgvdestinos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvdestinos.BackColor = System.Drawing.SystemColors.Window;
            this.dgvdestinos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvdestinos.ChildGroupOptions.ShowFilterBar = true;
            this.dgvdestinos.FreezeCaption = false;
            this.dgvdestinos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvdestinos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvdestinos.Location = new System.Drawing.Point(12, 59);
            this.dgvdestinos.Name = "dgvdestinos";
            this.dgvdestinos.Size = new System.Drawing.Size(233, 372);
            this.dgvdestinos.TabIndex = 21;
            this.dgvdestinos.TableDescriptor.AllowEdit = false;
            this.dgvdestinos.TableDescriptor.AllowNew = false;
            this.dgvdestinos.TableDescriptor.AllowRemove = false;
            this.dgvdestinos.TableDescriptor.Appearance.GroupCaptionCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvdestinos.TableDescriptor.Appearance.GroupCaptionRowHeaderCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this.dgvdestinos.TableDescriptor.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount} Registros";
            this.dgvdestinos.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvdestinos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvdestinos.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvdestinos.TableOptions.AllowDragColumns = false;
            this.dgvdestinos.TableOptions.AllowDropDownCell = false;
            this.dgvdestinos.TableOptions.AllowMultiColumnSort = false;
            this.dgvdestinos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.dgvdestinos.TableOptions.AllowSortColumns = false;
            this.dgvdestinos.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.dgvdestinos.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvdestinos.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvdestinos.VersionInfo = "14.1400.0.41";
            this.dgvdestinos.DataSourceChanged += new System.EventHandler(this.dgvdestinos_DataSourceChanged);
            this.dgvdestinos.SelectedRecordsChanged += new Syncfusion.Grouping.SelectedRecordsChangedEventHandler(this.dgvdestinos_SelectedRecordsChanged);
            // 
            // btnanular
            // 
            this.btnanular.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnanular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnanular.BeforeTouchSize = new System.Drawing.Size(104, 28);
            this.btnanular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnanular.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnanular.ForeColor = System.Drawing.Color.White;
            this.btnanular.IsBackStageButton = false;
            this.btnanular.Location = new System.Drawing.Point(417, 122);
            this.btnanular.Name = "btnanular";
            this.btnanular.Size = new System.Drawing.Size(104, 28);
            this.btnanular.TabIndex = 22;
            this.btnanular.Text = "Anular";
            this.btnanular.Click += new System.EventHandler(this.btnanular_Click);
            // 
            // frmreencaminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 459);
            this.Controls.Add(this.btnanular);
            this.Controls.Add(this.dgvdestinos);
            this.Controls.Add(this.panelinforeen);
            this.Controls.Add(this.dgvreenca);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtdespacho);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.cbdestino);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.btnreen);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.autoLabel1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmreencaminar";
            this.ShowMaximizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN";
            this.Load += new System.EventHandler(this.frmreencaminar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdestino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdespacho)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreenca)).EndInit();
            this.panelinforeen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdestinos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnreen;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtcodigo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbdestino;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtdespacho;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnnuevo;
        private System.Windows.Forms.ToolStripButton btnprint;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvreenca;
        private System.Windows.Forms.Panel panelinforeen;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel22;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvdestinos;
        private Syncfusion.Windows.Forms.ButtonAdv btnanular;
    }
}