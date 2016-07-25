#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Claro_nicaragua
{
    partial class frmlogin
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
            this.txtuser = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.txtpass = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.btnlogin = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnsalir = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.txtuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(52, 25);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(56, 17);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Usuario:";
            // 
            // txtuser
            // 
            this.txtuser.BeforeTouchSize = new System.Drawing.Size(192, 23);
            this.txtuser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtuser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(52, 45);
            this.txtuser.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(192, 23);
            this.txtuser.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtuser.TabIndex = 1;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(52, 81);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(77, 17);
            this.autoLabel2.TabIndex = 2;
            this.autoLabel2.Text = "Contraseña:";
            // 
            // txtpass
            // 
            this.txtpass.BeforeTouchSize = new System.Drawing.Size(192, 23);
            this.txtpass.BorderSides = System.Windows.Forms.Border3DSide.Top;
            this.txtpass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpass.Location = new System.Drawing.Point(52, 101);
            this.txtpass.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '●';
            this.txtpass.Size = new System.Drawing.Size(192, 23);
            this.txtpass.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtpass.TabIndex = 3;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // btnlogin
            // 
            this.btnlogin.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnlogin.BeforeTouchSize = new System.Drawing.Size(101, 29);
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.IsBackStageButton = false;
            this.btnlogin.Location = new System.Drawing.Point(28, 145);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(101, 29);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "Iniciar";
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnsalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnsalir.BeforeTouchSize = new System.Drawing.Size(101, 29);
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.IsBackStageButton = false;
            this.btnsalir.Location = new System.Drawing.Point(184, 145);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(101, 29);
            this.btnsalir.TabIndex = 5;
            this.btnsalir.Text = "Salir";
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 199);
            this.ControlBox = false;
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.autoLabel1);
            this.MetroColor = System.Drawing.Color.Transparent;
            this.Name = "frmlogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtuser;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtpass;
        private Syncfusion.Windows.Forms.ButtonAdv btnlogin;
        private Syncfusion.Windows.Forms.ButtonAdv btnsalir;
    }
}