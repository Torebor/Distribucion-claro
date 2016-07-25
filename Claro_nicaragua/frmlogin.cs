#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Claro_nicaragua.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Claro_nicaragua
{
    public partial class frmlogin : Syncfusion.Windows.Forms.MetroForm
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        conexion acceso;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtuser.Text==modulo.usrGlobal && txtpass.Text== modulo.Passglobal)
            {
                modulo.user_config_log = true;
                this.Close();
            }

            acceso = new conexion();
            DataTable dt_login = acceso.buscar(
                "select usc.nombre as Nombre_usuario,ofi.idcentro, ofi.nombrecentro from ",
                "usuario_claro usc inner join oficinapostal ofi on usc.cod_sucursal=ofi.idcentro ",
                "where usc.contraseña='" + SHA256Encripta(txtpass.Text) + "' and usc.nombre='" + txtuser.Text + "'");
            /*DataTable dt_login = acceso.buscar(
                "select usc.nombre as Nombre_usuario,ofi.idcentro, ofi.nombrecentro from ",
                "usuario_claro usc inner join oficinapostal ofi on usc.cod_sucursal=ofi.idcentro ",
               "where usc.contraseña='" + txtpass.Text + "' and usc.nombre='" + txtuser.Text + "'");*/
            if (dt_login!=null)
            {
                if(dt_login.Rows.Count>0)
                {
                    modulo.user = dt_login.Rows[0][0].ToString();
                    modulo.id_sucursal = dt_login.Rows[0][1].ToString();
                    modulo.sucursal = dt_login.Rows[0][2].ToString();
                    /*obtenemos los roles del usuario*/
                    acceso = new conexion();
                    modulo.roles_user = acceso.buscar("select  id_rol from ", "usuario_cliente ", "where id_cliente=1 and nombre='" + dt_login.Rows[0][0].ToString() + "' order by id_rol");
                    this.Close();
                }
            }
        }


        public static string SHA256Encripta(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());
            return output.ToString();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
    }
}
