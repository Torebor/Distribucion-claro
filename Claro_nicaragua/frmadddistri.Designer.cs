#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmadddistri
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtcodigo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnguardar = new Syncfusion.Windows.Forms.ButtonAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lbcartero = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lbasignadas = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dptfechadist = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(22, 92);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(54, 17);
            this.autoLabel1.TabIndex = 1;
            this.autoLabel1.Text = "Codigo:";
            // 
            // txtcodigo
            // 
            this.txtcodigo.BeforeTouchSize = new System.Drawing.Size(220, 23);
            this.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodigo.Location = new System.Drawing.Point(82, 86);
            this.txtcodigo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(220, 23);
            this.txtcodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtcodigo.TabIndex = 3;
            this.txtcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcodigo_KeyPress);
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
            this.btnguardar.Location = new System.Drawing.Point(115, 115);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(101, 29);
            this.btnguardar.TabIndex = 5;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(21, 27);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(55, 17);
            this.autoLabel2.TabIndex = 6;
            this.autoLabel2.Text = "Cartero:";
            // 
            // lbcartero
            // 
            this.lbcartero.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcartero.Location = new System.Drawing.Point(82, 27);
            this.lbcartero.Name = "lbcartero";
            this.lbcartero.Size = new System.Drawing.Size(78, 17);
            this.lbcartero.TabIndex = 7;
            this.lbcartero.Text = "--------------";
            // 
            // lbasignadas
            // 
            this.lbasignadas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbasignadas.Location = new System.Drawing.Point(-2, 182);
            this.lbasignadas.Name = "lbasignadas";
            this.lbasignadas.Size = new System.Drawing.Size(78, 17);
            this.lbasignadas.TabIndex = 8;
            this.lbasignadas.Text = "--------------";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(22, 59);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(129, 17);
            this.autoLabel3.TabIndex = 9;
            this.autoLabel3.Text = "Fecha de asignación:";
            // 
            // dptfechadist
            // 
            this.dptfechadist.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptfechadist.Location = new System.Drawing.Point(158, 59);
            this.dptfechadist.Name = "dptfechadist";
            this.dptfechadist.Size = new System.Drawing.Size(144, 20);
            this.dptfechadist.TabIndex = 2;
            this.dptfechadist.ValueChanged += new System.EventHandler(this.dptfechadist_ValueChanged_1);
            // 
            // frmadddistri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 202);
            this.Controls.Add(this.dptfechadist);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.lbasignadas);
            this.Controls.Add(this.lbcartero);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.autoLabel1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmadddistri";
            this.ShowMaximizeBox = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN";
            this.Load += new System.EventHandler(this.frmadddistri_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmadddistri_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtcodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtcodigo;
        private Syncfusion.Windows.Forms.ButtonAdv btnguardar;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbcartero;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lbasignadas;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.DateTimePicker dptfechadist;
    }
}