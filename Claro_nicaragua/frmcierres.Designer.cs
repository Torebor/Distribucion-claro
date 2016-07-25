#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmcierres
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
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btncerrar = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgvciclosactivos = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnanular = new Syncfusion.Windows.Forms.ButtonAdv();
            this.dgvciclocerrado = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvciclosactivos)).BeginInit();
            this.tabPageAdv2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvciclocerrado)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.BackColor = System.Drawing.SystemColors.Window;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(372, 325);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.InactiveTabColor = System.Drawing.SystemColors.Window;
            this.tabControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(372, 325);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabPanelBackColor = System.Drawing.SystemColors.Window;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.btncerrar);
            this.tabPageAdv1.Controls.Add(this.dgvciclosactivos);
            this.tabPageAdv1.Image = null;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv1.Location = new System.Drawing.Point(1, 22);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(369, 301);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "Ciclos activos";
            this.tabPageAdv1.ThemesEnabled = false;
            this.tabPageAdv1.Enter += new System.EventHandler(this.tabPageAdv1_Enter);
            // 
            // btncerrar
            // 
            this.btncerrar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btncerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btncerrar.BeforeTouchSize = new System.Drawing.Size(95, 44);
            this.btncerrar.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.ForeColor = System.Drawing.Color.White;
            this.btncerrar.IsBackStageButton = false;
            this.btncerrar.Location = new System.Drawing.Point(265, 13);
            this.btncerrar.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(95, 44);
            this.btncerrar.TabIndex = 29;
            this.btncerrar.Text = "Cerrar distribución";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // dgvciclosactivos
            // 
            this.dgvciclosactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvciclosactivos.Appearance.AnyGroupCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvciclosactivos.Appearance.GroupCaptionCell.AutoFit = Syncfusion.Windows.Forms.Grid.AutoFitOptions.Numeric;
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Font.Italic = true;
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Font.Size = 10F;
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PeachPuff);
            this.dgvciclosactivos.Appearance.GroupCaptionCell.TextColor = System.Drawing.Color.Black;
            this.dgvciclosactivos.Appearance.GroupCaptionCell.Themed = false;
            this.dgvciclosactivos.Appearance.GroupCaptionRowHeaderCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvciclosactivos.BackColor = System.Drawing.SystemColors.Window;
            this.dgvciclosactivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvciclosactivos.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount}  Registros";
            this.dgvciclosactivos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvciclosactivos.FreezeCaption = false;
            this.dgvciclosactivos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvciclosactivos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvciclosactivos.Location = new System.Drawing.Point(11, 13);
            this.dgvciclosactivos.Name = "dgvciclosactivos";
            this.dgvciclosactivos.Size = new System.Drawing.Size(248, 278);
            this.dgvciclosactivos.TabIndex = 12;
            this.dgvciclosactivos.TableDescriptor.AllowEdit = false;
            this.dgvciclosactivos.TableDescriptor.AllowNew = false;
            this.dgvciclosactivos.TableDescriptor.AllowRemove = false;
            this.dgvciclosactivos.TableDescriptor.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount} Registros";
            this.dgvciclosactivos.TableDescriptor.ChildGroupOptions.ShowFilterBar = false;
            this.dgvciclosactivos.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvciclosactivos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvciclosactivos.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvciclosactivos.TableOptions.AllowDragColumns = false;
            this.dgvciclosactivos.TableOptions.AllowMultiColumnSort = false;
            this.dgvciclosactivos.TableOptions.AllowSortColumns = false;
            this.dgvciclosactivos.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvciclosactivos.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvciclosactivos.VersionInfo = "14.1400.0.41";
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.Controls.Add(this.btnanular);
            this.tabPageAdv2.Controls.Add(this.dgvciclocerrado);
            this.tabPageAdv2.Image = null;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv2.Location = new System.Drawing.Point(1, 22);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(369, 301);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "Ciclos cerrados";
            this.tabPageAdv2.ThemesEnabled = false;
            this.tabPageAdv2.Enter += new System.EventHandler(this.tabPageAdv2_Enter);
            // 
            // btnanular
            // 
            this.btnanular.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnanular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btnanular.BeforeTouchSize = new System.Drawing.Size(99, 43);
            this.btnanular.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None;
            this.btnanular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnanular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnanular.ForeColor = System.Drawing.Color.White;
            this.btnanular.IsBackStageButton = false;
            this.btnanular.Location = new System.Drawing.Point(264, 13);
            this.btnanular.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(75)))), ((int)(((byte)(139)))));
            this.btnanular.Name = "btnanular";
            this.btnanular.Size = new System.Drawing.Size(99, 43);
            this.btnanular.TabIndex = 27;
            this.btnanular.Text = "Anular cierre de distribución";
            this.btnanular.Click += new System.EventHandler(this.btnanular_Click);
            // 
            // dgvciclocerrado
            // 
            this.dgvciclocerrado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvciclocerrado.Appearance.AnyGroupCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvciclocerrado.Appearance.GroupCaptionCell.AutoFit = Syncfusion.Windows.Forms.Grid.AutoFitOptions.Numeric;
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Font.Italic = true;
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Font.Size = 10F;
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.PeachPuff);
            this.dgvciclocerrado.Appearance.GroupCaptionCell.TextColor = System.Drawing.Color.Black;
            this.dgvciclocerrado.Appearance.GroupCaptionCell.Themed = false;
            this.dgvciclocerrado.Appearance.GroupCaptionRowHeaderCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window);
            this.dgvciclocerrado.BackColor = System.Drawing.SystemColors.Window;
            this.dgvciclocerrado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvciclocerrado.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount}  Registros";
            this.dgvciclocerrado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvciclocerrado.FreezeCaption = false;
            this.dgvciclocerrado.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvciclocerrado.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvciclocerrado.Location = new System.Drawing.Point(11, 13);
            this.dgvciclocerrado.Name = "dgvciclocerrado";
            this.dgvciclocerrado.Size = new System.Drawing.Size(247, 278);
            this.dgvciclocerrado.TabIndex = 11;
            this.dgvciclocerrado.TableDescriptor.AllowEdit = false;
            this.dgvciclocerrado.TableDescriptor.AllowNew = false;
            this.dgvciclocerrado.TableDescriptor.AllowRemove = false;
            this.dgvciclocerrado.TableDescriptor.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount} Registros";
            this.dgvciclocerrado.TableDescriptor.ChildGroupOptions.ShowFilterBar = false;
            this.dgvciclocerrado.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvciclocerrado.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvciclocerrado.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvciclocerrado.TableOptions.AllowDragColumns = false;
            this.dgvciclocerrado.TableOptions.AllowMultiColumnSort = false;
            this.dgvciclocerrado.TableOptions.AllowSortColumns = false;
            this.dgvciclocerrado.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvciclocerrado.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvciclocerrado.VersionInfo = "14.1400.0.41";
            // 
            // frmcierres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 325);
            this.Controls.Add(this.tabControlAdv1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmcierres";
            this.ShowMaximizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierres de ciclos";
            this.Load += new System.EventHandler(this.frmcierres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvciclosactivos)).EndInit();
            this.tabPageAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvciclocerrado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvciclosactivos;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvciclocerrado;
        private Syncfusion.Windows.Forms.ButtonAdv btnanular;
        private Syncfusion.Windows.Forms.ButtonAdv btncerrar;
    }
}