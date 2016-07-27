#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Claro_nicaragua.clases;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Claro_nicaragua
{
    public partial class frmadmitirreen : Syncfusion.Windows.Forms.MetroForm
    {

        conexion acceso;
        public frmadmitirreen()
        {
            InitializeComponent();
        }

        private void add_entrega_fallida()
        {


        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if(txtcodigo.Text!="")
            {

                if (modulo.verificar_codigo(txtcodigo.Text.Trim()) == 2)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcodigo.SelectionStart = 0;
                    txtcodigo.SelectionLength = txtcodigo.Text.Length;
                    txtcodigo.Focus();
                    return;
                }
                else if (modulo.verificar_codigo(txtcodigo.Text.Trim()) == 1)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Esta factura no ha sido cargada al sistema", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int resul_estado = modulo.verificar_estado_anterior(txtcodigo.Text, "D", "'E'");
                    if(resul_estado==0)
                    {
                        /*Insertamos el acontecimiento*/
                        acceso = new conexion();
                        bool resul_insert = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,nodespacho) " +
                            "values('" + txtcodigo.Text + "','E',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','"+ txtdespacho.Text+"')"
                            );
                        if (resul_insert == true)
                        {
                            txtcodigo.SelectionStart = 0;
                            txtcodigo.SelectionLength = txtcodigo.Text.Length;
                            txtcodigo.Focus();
                            txtcliente.Text = ""; txtorigen.Text = ""; txtdespacho.Text = "";
                        }
                        else
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtcodigo.SelectionStart = 0;
                            txtcodigo.SelectionLength = txtcodigo.Text.Length;
                            txtcodigo.Focus();
                            return;
                        }
                    }
                    else if(resul_estado==1)
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("La factura ya fue recibida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcodigo.SelectionStart = 0;
                        txtcodigo.SelectionLength = txtcodigo.Text.Length;
                        txtcodigo.Focus();
                        return;
                    }
                    else if (resul_estado == 2)
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
            }
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar== Keys.Tab || (Keys)e.KeyChar==Keys.Enter)
            {
                if(txtcodigo.Text!="")
                {
                    /*cargamos los datos del reencaminamiento*/
                    acceso = new conexion();
                    DataTable dt_datos_envio = acceso.buscar("select pc.cliente,sc.nodespacho, op.nombrecentro from ",
                        "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join" + 
                        " oficinapostal op on sc.id_centro=op.idcentro ",
                        "where sc.cod_envio='"+txtcodigo.Text+"' and id_estado='D' and id_centro_destino='"+modulo.id_sucursal+"'");
                    if(dt_datos_envio!=null)
                    {
                        if(dt_datos_envio.Rows.Count>0)
                        {
                            txtcliente.Text = dt_datos_envio.Rows[0]["cliente"].ToString();
                            txtdespacho.Text = dt_datos_envio.Rows[0]["nodespacho"].ToString();
                            txtorigen.Text = dt_datos_envio.Rows[0]["nombrecentro"].ToString();
                        }
                        else
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("Verifique que el codigo ingresado sea valido para esta sucursal", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtcodigo.SelectionStart = 0;
                            txtcodigo.SelectionLength = txtcodigo.Text.Length;
                            txtcodigo.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                /*SendKeys.Send("{TAB}");*/

            }
        }

        private void txtincidencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

            }
        }
    }
}
