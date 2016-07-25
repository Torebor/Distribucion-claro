#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmadmitirreen
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
            this.btnguardar = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtcodigo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtcliente = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtdespacho = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtorigen = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdespacho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorigen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnguardar
            // 
            this.btnguardar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnguardar.BeforeTouchSize = new System.Drawing.Size(101, 29);
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.IsBackStageButton = false;
            this.btnguardar.Location = new System.Drawing.Point(204, 156);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(101, 29);
            this.btnguardar.TabIndex = 12;
            this.btnguardar.Text = "Admitir";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.BeforeTouchSize = new System.Drawing.Size(279, 23);
            this.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(48, 49);
            this.txtcodigo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(192, 23);
            this.txtcodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtcodigo.TabIndex = 10;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(48, 29);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 9;
            this.autoLabel1.Text = "Codigo:";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(255, 29);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(50, 17);
            this.autoLabel2.TabIndex = 13;
            this.autoLabel2.Text = "Cliente:";
            // 
            // txtcliente
            // 
            this.txtcliente.BeforeTouchSize = new System.Drawing.Size(279, 23);
            this.txtcliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcliente.Location = new System.Drawing.Point(255, 49);
            this.txtcliente.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.ReadOnly = true;
            this.txtcliente.Size = new System.Drawing.Size(228, 23);
            this.txtcliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtcliente.TabIndex = 14;
            // 
            // txtdespacho
            // 
            this.txtdespacho.BeforeTouchSize = new System.Drawing.Size(279, 23);
            this.txtdespacho.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdespacho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdespacho.Location = new System.Drawing.Point(48, 105);
            this.txtdespacho.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtdespacho.Name = "txtdespacho";
            this.txtdespacho.ReadOnly = true;
            this.txtdespacho.Size = new System.Drawing.Size(126, 23);
            this.txtdespacho.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtdespacho.TabIndex = 15;
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(48, 85);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(90, 17);
            this.autoLabel3.TabIndex = 16;
            this.autoLabel3.Text = "No despacho:";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(204, 85);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(51, 17);
            this.autoLabel4.TabIndex = 17;
            this.autoLabel4.Text = "Origen:";
            // 
            // txtorigen
            // 
            this.txtorigen.BeforeTouchSize = new System.Drawing.Size(279, 23);
            this.txtorigen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtorigen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtorigen.Location = new System.Drawing.Point(204, 105);
            this.txtorigen.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtorigen.Name = "txtorigen";
            this.txtorigen.ReadOnly = true;
            this.txtorigen.Size = new System.Drawing.Size(279, 23);
            this.txtorigen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtorigen.TabIndex = 18;
            // 
            // frmadmitirreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 223);
            this.Controls.Add(this.txtorigen);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.txtdespacho);
            this.Controls.Add(this.txtcliente);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.autoLabel1);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmadmitirreen";
            this.ShowMaximizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN";
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtcliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdespacho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtorigen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnguardar;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtcodigo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtcliente;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtdespacho;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtorigen;
    }
}