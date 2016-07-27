#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Claro_nicaragua.clases;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid.Grouping;
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
    public partial class frmreencaminar : Syncfusion.Windows.Forms.MetroForm
    {

        conexion acceso;
        string id_centro;
        public frmreencaminar()
        {
            InitializeComponent();
            /* cargamos los centros a los cuales se podra despachar*/
            acceso = new conexion();
            DataTable dt_dentros = acceso.buscar("select idcentro,nombrecentro as Destino from ",
                "oficinapostal op ",
                "where op.idcentro<>'" + modulo.id_sucursal + "' order by nombrecentro");
            //cbdestino.DataSource = dt_dentros;
            //cbdestino.ValueMember = "idcentro";
            //cbdestino.DisplayMember = "nombrecentro";
            //cbdestino.Focus();
            dgvdestinos.DataSource = dt_dentros.AsDataView();
            dgvdestinos.TableDescriptor.VisibleColumns.Remove("idcentro");
        }

        private void agregar_entrega()
        {
            if (txtcodigo.Text != "")
            {
                /*buscamos que el codigo de envio pertenesca al centro de distibucion logeado*/
                //acceso = new conexion();
                //DataTable cheking = acceso.buscar(
                //    "select * from ",
                //    "PE_claro inner join Barrio on PE_claro.IdBarrio= barrio.IdBarrio INNER JOIN Departamentos ON Barrio.IdDepto = Departamentos.IdDepto INNER JOIN Municipios ON Barrio.IdMunicipio = Municipios.IdMunicipio INNER JOIN OficinaPostal ON Barrio.IdOficinaPostal = OficinaPostal.IdCentro ",
                //    "WHERE (PE_claro.codigo='" + txtcodigo.Text + "' and OficinaPostal.IdCentro='" + modulo.id_sucursal + "')"
                //    );
                //if (cheking != null)
                //{
                //    if (cheking.Rows.Count == 0)
                //    {
                //        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                //        MessageBoxAdv.Show("Este codigo pertenece a otro centro de distribución ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                //    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                ///*si todo va bien buscamos que este envio haya sido distibuido*/
                //acceso = new conexion();
                //DataTable dt_estado_anterior = acceso.buscar(
                //    "select * from ",
                //    "seguimiento_claro ",
                //    "where id_estado in ('A') and not exists(select * from seguimiento_claro where id_estado='B' and cod_envio='"+txtcodigo.Text+"') and cod_envio='" + txtcodigo.Text + "'");
                //if (dt_estado_anterior != null)
                //{
                //    if (dt_estado_anterior.Rows.Count > 0)
                //    {
                //        /*Insertamos el acontecimiento*/
                //        acceso = new conexion();
                //        bool resul = acceso.insertar(
                //            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro) " +
                //            "values('" + txtcodigo.Text + "','B',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "')"
                //            );
                //        if (resul == true)
                //        {
                //            txtcodigo.SelectionStart = 0;
                //            txtcodigo.SelectionLength = txtcodigo.Text.Length;
                //            txtcodigo.Focus();
                //        }
                //        else
                //        {
                //            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                //            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                //        MessageBoxAdv.Show("No es posible grabar la entrega efecyiva del envio esto puede ser causado por las siguientes razones: \r\n -El envio no ha sido distribuido. \r\n -El envio ya fue Entregado por otro usuario.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                //    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            //    int resul = modulo.verifica_codigoXCD(txtcodigo.Text);
            //    if (resul == 0)
            //    {
            //        int resul_estado = modulo.verificar_estado_anterior(txtcodigo.Text, "A", "'C','B'");
            //        if (resul_estado == 0)
            //        {
            //            /*Insertamos el acontecimiento*/
            //            acceso = new conexion();
            //            bool resul_insert = acceso.insertar(
            //                "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro) " +
            //                "values('" + txtcodigo.Text + "','B',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "')"
            //                );
            //            if (resul_insert == true)
            //            {
            //                txtcodigo.SelectionStart = 0;
            //                txtcodigo.SelectionLength = txtcodigo.Text.Length;
            //                txtcodigo.Focus();
            //            }
            //            else
            //            {
            //                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //                MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
            //        }
            //        else if (resul_estado == 1)
            //        {
            //            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //            MessageBoxAdv.Show("No es posible grabar la entrega efectiva del envio, esto puede ser causado por las siguientes razones: \r\n -El envio no ha sido distribuido. \r\n -Ya existe la entrega efectiva para este envio.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        else if (resul_estado == 2)
            //        {
            //            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //    else if (resul == 1)
            //    {
            //        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //        MessageBoxAdv.Show("Este codigo pertenece a otro centro de distribución ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    else
            //    {
            //        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //        MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //    MessageBoxAdv.Show("Ingrese el codigo del envio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cargar_despacho(string id)
        {
            /*obtenemos el despacho correspondiente*/
            acceso = new conexion();
            DataTable dtdesp = acceso.buscar("select max(nodespacho) from ",
                "seguimiento_claro sc ",
                "where id_centro='" + modulo.id_sucursal + "' and id_centro_destino='" + id + "' and year(sc.fecha)='" + DateTime.Now.Year + "'");
            if (dtdesp == null)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, se cerrara la ventana", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                try
                {
                    txtdespacho.Text = Convert.ToString((int)dtdesp.Rows[0][0] + 1);
                }
                catch
                {
                    txtdespacho.Text = "1";
                }


            }
        }


        /*private string get_id_destino()
        {
            string centro = "";
            var seleccion = dgvreenca.Table.SelectedRecords;
            foreach (var item in seleccion)
            {
                centro= item.Record["idcentro"].ToString();
            }
            return centro;
        }*/

        private void reencaminar()
        {
            if (txtcodigo.Text != "")
            {
                /*if(cbdestino.SelectedValue==null)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Seleccione el destino", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbdestino.Focus();
                    return;
                }*/
                /*int resul = modulo.verifica_codigoXCD(txtcodigo.Text);
                if (resul == 0)
                {*/
                   
                    if (id_centro=="")
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("Seleccione el destino", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //dgvreenca.Focus();
                        return;
                    }

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

                acceso = new conexion();
                    DataTable dt_existing_event = acceso.buscar("select * from ",
                        " PE_claro pc ",
                        "where pc.codigo='"+txtcodigo.Text + "' and not exists(select * from seguimiento_claro sc where sc.cod_envio='" + txtcodigo.Text + "' and sc.id_estado in ('D','B','C','F','A') and sc.id_centro='"+modulo.id_sucursal+"' and nodespacho='"+txtdespacho.Text+"')");
                //or exists(select * from seguimiento_claro sc where sc.cod_envio = '" + txtcodigo.Text + "' and sc.id_estado = 'A' and sc.id_centro = '"+modulo.id_sucursal+"' and not exists(select * from seguimiento_claro scc where scc.cod_envio = '"+txtcodigo.Text+"' and scc.id_centro = '"+modulo.id_sucursal+"' and id_estado in('D', 'B', 'C')))
                //not exists(select * from seguimiento_claro sc where sc.cod_envio = '" + txtcodigo.Text + "')
                if (dt_existing_event.Rows.Count>0)
                    {
                        /*insertamos el acontecimiento*/
                        acceso = new conexion();
                        bool resul_insert = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,id_centro_destino, nodespacho) " +
                            "values('" + txtcodigo.Text + "','D',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','"+ id_centro + "','"+txtdespacho.Text+"')"
                            );
                        if (resul_insert == true)
                        {
                            //cargar_despacho();
                            load_reen(int.Parse(txtdespacho.Text));
                            txtcodigo.SelectionStart = 0;
                            txtcodigo.SelectionLength = txtcodigo.Text.Length;
                            txtcodigo.Focus();

                        }
                        else
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        load_reen(int.Parse(txtdespacho.Text));
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No es posible realizar el reencaminamiento porque la factura Ya fue asigna", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcodigo.SelectionStart = 0;
                        txtcodigo.SelectionLength = txtcodigo.Text.Length;
                        txtcodigo.Focus();
                        return;
                    }
                //}
                /*else
                {
                    load_reen(int.Parse(txtdespacho.Text));
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Este codigo pertenece a otro centro de distribución ", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcodigo.SelectionStart = 0;
                    txtcodigo.SelectionLength = txtcodigo.Text.Length;
                    txtcodigo.Focus();
                    return;
                }*/
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Ingrese el codigo del envio", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcodigo.Focus();
            }
        }

        private void load_reen(int despacho)
        {
            acceso = new conexion();
            DataTable dt_reen = acceso.buscar("select pc.codigo as Codigo, pc.contrato as Contrato, pc.cliente as Cliente , pc.ciclo as Cliclo, pc.servicio, CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha from ",
                "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio ",
                "where sc.nodespacho="+despacho+" and id_centro_destino='"+ id_centro +"' and sc.id_estado='D' and id_centro='"+modulo.id_sucursal+"'");
            dgvreenca.DataSource = dt_reen;
            dgvreenca.Visible = true;
            panelinforeen.Visible = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //agregar_entrega();
            reencaminar();
            /*cargamos las reencamindas en el despacho*/          

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void autoLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                SendKeys.Send("{TAB}");

            }
        }

        private void cbdestino_SelectedValueChanged(object sender, EventArgs e)
        {
            /*try
            {
                if ((int)cbdestino.SelectedValue >= 1)
                {
                    txtdespacho.ReadOnly = false;
                    cargar_despacho();
                }
            }
            catch
            {
                txtdespacho.Text = "Seleccione el destino";
                txtdespacho.ReadOnly = true;
            }*/
            
        }

        private void cbdestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                if(cbdestino.SelectedValue!=null)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void cbdestino_Enter(object sender, EventArgs e)
        {
            cbdestino.DroppedDown = true;
        }

        private void cbdestino_Leave(object sender, EventArgs e)
        {
            cbdestino.DroppedDown = false;
        }

        private void txtdespacho_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            //cbdestino.SelectedIndex = -1;
            dgvdestinos.Enabled = true;
            id_centro = "";
            txtcodigo.Text = "";
            txtdespacho.Text = "";
            txtdespacho.ReadOnly = false;
            dgvreenca.Visible = false;
            panelinforeen.Visible = true;
            txtdespacho.Focus();
            dgvdestinos.Table.SelectedRecords.Clear();
            //dgvdestinos.TableControl.Select(false);
        }

        private void txtdespacho_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyData == Keys.Tab || (Keys)e.KeyData == Keys.Enter)
            {
                if (txtdespacho.Text != "")
                {
                    load_reen(int.Parse(txtdespacho.Text));
                    SendKeys.Send("{TAB}");
                    //txtdespacho.ReadOnly = true;
                }
            }
        }

        private void frmreencaminar_Load(object sender, EventArgs e)
        {

        }

        private void dgvdestinos_SelectedRecordsChanged(object sender, Syncfusion.Grouping.SelectedRecordsChangedEventArgs e)
        {
            var select=e.Table.SelectedRecords;
            foreach (var item in select)
            {
                id_centro = item.Record["idcentro"].ToString();
                cargar_despacho(id_centro);
                dgvdestinos.Enabled = false;
                //txtdespacho.ReadOnly = true;
            }               
        }

        private void btnanular_Click(object sender, EventArgs e)
        {
            /*obtenemos el codigo de la factura*/
            string codigo;
            var seleccion = dgvreenca.Table.SelectedRecords;
            if (seleccion.Count > 0)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                DialogResult resul_dialog = MessageBoxAdv.Show("Esta acción quitara la factura de este despacho, ¿Esta seguro de continuar?", "Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul_dialog == DialogResult.No)
                {
                    return;
                }
                foreach (var item in seleccion)
                {
                    acceso = new conexion();
                    codigo = item.Record["Codigo"].ToString();
                    /*procedemos a borrar el evento*/
                    bool resul = acceso.insertar("delete seguimiento_claro where cod_envio='" + codigo + "' and id_estado='D' and id_centro='" + modulo.id_sucursal + "'");
                    if (resul == true)
                        //contador++;
                        load_reen(int.Parse(txtdespacho.Text));
                }
            }
            txtcodigo.Text = "";
            txtcodigo.Focus();
        }

        private void dgvdestinos_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvdestinos.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor parentColumn in this.dgvdestinos.TableDescriptor.Columns)
            {
                parentColumn.AllowFilter = true;
            }
            this.dgvdestinos.TableDescriptor.Appearance.FilterBarCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete;
        }
    }
}
