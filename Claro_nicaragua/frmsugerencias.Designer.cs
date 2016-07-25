#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmsugerencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsugerencias));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelinfosugerencia = new System.Windows.Forms.Panel();
            this.autoLabel22 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.cbdia = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btndistribuir = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgvsugerencia = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lbcartero = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel1.SuspendLayout();
            this.panelinfosugerencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsugerencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelinfosugerencia);
            this.panel1.Controls.Add(this.cbdia);
            this.panel1.Controls.Add(this.autoLabel1);
            this.panel1.Controls.Add(this.btndistribuir);
            this.panel1.Controls.Add(this.dgvsugerencia);
            this.panel1.Controls.Add(this.lbcartero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(888, 564);
            this.panel1.MinimumSize = new System.Drawing.Size(888, 564);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 564);
            this.panel1.TabIndex = 0;
            // 
            // panelinfosugerencia
            // 
            this.panelinfosugerencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelinfosugerencia.Controls.Add(this.autoLabel22);
            this.panelinfosugerencia.Controls.Add(this.pictureBox4);
            this.panelinfosugerencia.Location = new System.Drawing.Point(295, 217);
            this.panelinfosugerencia.Name = "panelinfosugerencia";
            this.panelinfosugerencia.Size = new System.Drawing.Size(299, 130);
            this.panelinfosugerencia.TabIndex = 27;
            // 
            // autoLabel22
            // 
            this.autoLabel22.AutoSize = false;
            this.autoLabel22.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel22.Location = new System.Drawing.Point(119, 16);
            this.autoLabel22.Name = "autoLabel22";
            this.autoLabel22.Size = new System.Drawing.Size(161, 96);
            this.autoLabel22.TabIndex = 10;
            this.autoLabel22.Text = "Sin resultados";
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
            // cbdia
            // 
            this.cbdia.BackColor = System.Drawing.Color.White;
            this.cbdia.BeforeTouchSize = new System.Drawing.Size(179, 23);
            this.cbdia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.cbdia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbdia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbdia.Location = new System.Drawing.Point(73, 34);
            this.cbdia.Name = "cbdia";
            this.cbdia.Size = new System.Drawing.Size(179, 23);
            this.cbdia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.cbdia.TabIndex = 26;
            this.cbdia.UseMetroColorsInActiveMode = true;
            this.cbdia.SelectedValueChanged += new System.EventHandler(this.cbdia_SelectedValueChanged);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(27, 44);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(40, 13);
            this.autoLabel1.TabIndex = 25;
            this.autoLabel1.Text = "Fecha:";
            // 
            // btndistribuir
            // 
            this.btndistribuir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndistribuir.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btndistribuir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btndistribuir.BeforeTouchSize = new System.Drawing.Size(108, 25);
            this.btndistribuir.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btndistribuir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndistribuir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btndistribuir.ForeColor = System.Drawing.Color.White;
            this.btndistribuir.IsBackStageButton = false;
            this.btndistribuir.Location = new System.Drawing.Point(258, 32);
            this.btndistribuir.MetroColor = System.Drawing.Color.Red;
            this.btndistribuir.Name = "btndistribuir";
            this.btndistribuir.Size = new System.Drawing.Size(108, 25);
            this.btndistribuir.TabIndex = 24;
            this.btndistribuir.Text = "Asignar";
            this.btndistribuir.Click += new System.EventHandler(this.btndistribuir_Click);
            // 
            // dgvsugerencia
            // 
            this.dgvsugerencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvsugerencia.Appearance.GroupCaptionCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvsugerencia.Appearance.GroupCaptionCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvsugerencia.Appearance.GroupCaptionCell.Font.Italic = true;
            this.dgvsugerencia.Appearance.GroupCaptionCell.Font.Size = 10F;
            this.dgvsugerencia.Appearance.GroupCaptionCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PeachPuff);
            this.dgvsugerencia.Appearance.GroupCaptionCell.Themed = false;
            this.dgvsugerencia.BackColor = System.Drawing.SystemColors.Window;
            this.dgvsugerencia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvsugerencia.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount}  Registros";
            this.dgvsugerencia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvsugerencia.FreezeCaption = false;
            this.dgvsugerencia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvsugerencia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvsugerencia.Location = new System.Drawing.Point(27, 63);
            this.dgvsugerencia.Name = "dgvsugerencia";
            this.dgvsugerencia.ShowNavigationBar = true;
            this.dgvsugerencia.Size = new System.Drawing.Size(834, 480);
            this.dgvsugerencia.TabIndex = 23;
            this.dgvsugerencia.TableDescriptor.AllowEdit = false;
            this.dgvsugerencia.TableDescriptor.AllowNew = false;
            this.dgvsugerencia.TableDescriptor.AllowRemove = false;
            this.dgvsugerencia.TableDescriptor.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount} Registros";
            this.dgvsugerencia.TableDescriptor.ChildGroupOptions.ShowFilterBar = false;
            this.dgvsugerencia.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvsugerencia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvsugerencia.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvsugerencia.TableOptions.AllowDragColumns = false;
            this.dgvsugerencia.TableOptions.AllowMultiColumnSort = false;
            this.dgvsugerencia.TableOptions.AllowSortColumns = false;
            this.dgvsugerencia.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.dgvsugerencia.TableOptions.SelectionTextColor = System.Drawing.Color.White;
            this.dgvsugerencia.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvsugerencia.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvsugerencia.VersionInfo = "14.1400.0.41";
            this.dgvsugerencia.Visible = false;
            // 
            // lbcartero
            // 
            this.lbcartero.Location = new System.Drawing.Point(27, 14);
            this.lbcartero.Name = "lbcartero";
            this.lbcartero.Size = new System.Drawing.Size(208, 13);
            this.lbcartero.TabIndex = 14;
            this.lbcartero.Text = "-------------------------------------------------------------------";
            // 
            // frmsugerencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 564);
            this.Controls.Add(this.panel1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmsugerencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación sugerida";
            this.Load += new System.EventHandler(this.frmsugerencias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelinfosugerencia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbdia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsugerencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbcartero;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvsugerencia;
        private Syncfusion.Windows.Forms.ButtonAdv btndistribuir;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cbdia;
        private System.Windows.Forms.Panel panelinfosugerencia;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel22;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}