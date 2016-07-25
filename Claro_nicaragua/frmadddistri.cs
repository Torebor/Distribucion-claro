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
    public partial class frmadddistri : Syncfusion.Windows.Forms.MetroForm
    {
        int id_cartero;
        conexion acceso;
        public frmadddistri(string cartero, int id_cartero)
        {
            InitializeComponent();
            /*obtenemos las asignadas para el cartero en el mes corriente*/           
            lbcartero.Text = cartero;
            this.id_cartero = id_cartero;
            //load_asignadas();
            txtcodigo.Focus();
        }


        private void load_asignadas()
        {
            acceso = new conexion();
            DataTable dt_count_asignadas = acceso.buscar("select count(*) from  ",
                "seguimiento_claro sc inner join PE_claro pc on sc.cod_envio=pc.codigo ",
                "where sc.id_cartero=" + id_cartero + " and id_estado='A' and disponible=1 and convert(char(10),sc.fecha,103)='"+string.Format("{0:dd/MM/yyyy}",dptfechadist.Value)+"'");
            if (dt_count_asignadas == null)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else if (dt_count_asignadas.Rows.Count == 0)
            {
                lbasignadas.Text = "Facturas Asignadas: 0";
            }
            else
            {
                lbasignadas.Text = "Facturas Asignadas: " + dt_count_asignadas.Rows[0][0].ToString();
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            /*insertamos el evento*/
            if(txtcodigo.Text!="")
            {
                /*buscamos que el codigo de envio pertenesca al centro de distibucion logeado*/
                /*acceso = new conexion();
                DataTable cheking = acceso.buscar(
                    "select * from ",
                    "PE_claro inner join Barrio on PE_claro.IdBarrio= barrio.IdBarrio INNER JOIN Departamentos ON Barrio.IdDepto = Departamentos.IdDepto INNER JOIN Municipios ON Barrio.IdMunicipio = Municipios.IdMunicipio INNER JOIN OficinaPostal ON Barrio.IdOficinaPostal = OficinaPostal.IdCentro ",
                    "WHERE ((PE_claro.codigo='" + txtcodigo.Text + "' and OficinaPostal.IdCentro='" + modulo.id_sucursal + "') or exists(select * from seguimiento_claro sc where sc.cod_envio='" + txtcodigo.Text + "' and sc.id_centro='" + modulo.id_sucursal + "'))"
                    );
                if(cheking!=null)
                {
                    if(cheking.Rows.Count==0)
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("Esta factura no pertenece al centro!!, ¿Desea continuar de todas formas? ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }*/
                    acceso = new conexion();
                    DataTable dt_sin_estados = acceso.buscar("select * from ",
                        "pe_claro ",
                        "where pe_claro.codigo='"+txtcodigo.Text+"' and not exists(select * from seguimiento_claro sc where id_estado in('A','D') and id_centro='"+modulo.id_sucursal+"' and cod_envio='"+txtcodigo.Text+"')");
                    if(dt_sin_estados!=null)
                    {
                        if(dt_sin_estados.Rows.Count==0)
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No se puede asignar la factura las razones podrian ser que ya fue asignada o que fue reencaminada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        txtcodigo.SelectionStart = 0;
                        txtcodigo.SelectionLength = txtcodigo.Text.Length;
                        txtcodigo.Focus();
                        return;
                    }
                //}
                /*else
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtcodigo.SelectionStart = 0;
                    txtcodigo.SelectionLength = txtcodigo.Text.Length;
                    txtcodigo.Focus();
                    return;
                }*/

                acceso = new conexion();
                bool resul = acceso.insertar(
                    "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,id_cartero) " +
                    "values('"+txtcodigo.Text+"','A','"+ string.Format("{0:yyyy-MM-ddThh:mm:ss}",dptfechadist.Value)+"','"+modulo.user+"','"+modulo.id_sucursal+"','"+id_cartero+"')"
                    );
                if (resul == true)
                {
                    load_asignadas();
                    txtcodigo.SelectionStart = 0;
                    txtcodigo.SelectionLength = txtcodigo.Text.Length;
                    txtcodigo.Focus();
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
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Ingrese el codigo del envio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcodigo.Focus();
            }
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                btnguardar.Focus();
                btnguardar_Click(null, null);

            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void frmadddistri_Load(object sender, EventArgs e)
        {
            dptfechadist.Value = DateTime.Now;
            dptfechadist.Format = DateTimePickerFormat.Custom;
            dptfechadist.CustomFormat="dd-MM-yyyy";
            load_asignadas();
            dptfechadist.Focus();
        }

        private void frmadddistri_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dptfechadist_ValueChanged_1(object sender, EventArgs e)
        {
            load_asignadas();
            txtcodigo.Focus();
        }
    }
}
