namespace Claro_nicaragua
{
    partial class frmrastreo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrastreo));
            this.txtcodigo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dgvrastreo = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panelinforastreo = new System.Windows.Forms.Panel();
            this.autoLabel18 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrastreo)).BeginInit();
            this.panelinforastreo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtcodigo
            // 
            this.txtcodigo.BeforeTouchSize = new System.Drawing.Size(192, 23);
            this.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(72, 33);
            this.txtcodigo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(192, 23);
            this.txtcodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtcodigo.TabIndex = 9;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(12, 39);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 8;
            this.autoLabel1.Text = "Codigo:";
            // 
            // dgvrastreo
            // 
            this.dgvrastreo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvrastreo.BackColor = System.Drawing.SystemColors.Window;
            this.dgvrastreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvrastreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvrastreo.FreezeCaption = false;
            this.dgvrastreo.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro;
            this.dgvrastreo.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro;
            this.dgvrastreo.Location = new System.Drawing.Point(12, 73);
            this.dgvrastreo.Name = "dgvrastreo";
            this.dgvrastreo.Size = new System.Drawing.Size(662, 222);
            this.dgvrastreo.TabIndex = 10;
            this.dgvrastreo.TableDescriptor.AllowEdit = false;
            this.dgvrastreo.TableDescriptor.AllowNew = false;
            this.dgvrastreo.TableDescriptor.AllowRemove = false;
            this.dgvrastreo.TableDescriptor.TableOptions.CaptionRowHeight = 29;
            this.dgvrastreo.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25;
            this.dgvrastreo.TableDescriptor.TableOptions.RecordRowHeight = 25;
            this.dgvrastreo.TopLevelGroupOptions.CaptionText = "{RecordCount} Registros";
            this.dgvrastreo.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dgvrastreo.VersionInfo = "14.1400.0.41";
            this.dgvrastreo.Visible = false;
            // 
            // panelinforastreo
            // 
            this.panelinforastreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelinforastreo.Controls.Add(this.autoLabel18);
            this.panelinforastreo.Controls.Add(this.pictureBox2);
            this.panelinforastreo.Location = new System.Drawing.Point(200, 88);
            this.panelinforastreo.Name = "panelinforastreo";
            this.panelinforastreo.Size = new System.Drawing.Size(299, 130);
            this.panelinforastreo.TabIndex = 17;
            // 
            // autoLabel18
            // 
            this.autoLabel18.AutoSize = false;
            this.autoLabel18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel18.Location = new System.Drawing.Point(119, 16);
            this.autoLabel18.Name = "autoLabel18";
            this.autoLabel18.Size = new System.Drawing.Size(161, 96);
            this.autoLabel18.TabIndex = 10;
            this.autoLabel18.Text = "Ingrese el codigo para mostrar el seguimiento";
            this.autoLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(114, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmrastreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 307);
            this.Controls.Add(this.panelinforastreo);
            this.Controls.Add(this.dgvrastreo);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.autoLabel1);
            this.Name = "frmrastreo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN";
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvrastreo)).EndInit();
            this.panelinforastreo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtcodigo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl dgvrastreo;
        private System.Windows.Forms.Panel panelinforastreo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel18;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

