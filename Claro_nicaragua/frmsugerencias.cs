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
    public partial class frmsugerencias : Syncfusion.Windows.Forms.MetroForm
    {
        string id;
        public frmsugerencias(string id, string nombre)
        {
            InitializeComponent();
            this.id = id;
            lbcartero.Text = nombre;
        }

        private void load_lista()
        {
            /*empezamos a obtener la asignación del mes anterior*/
            acceso = new conexion();
            DataTable dt_sugerencia = acceso.buscar("select contrato,ciclo,cliente, barrio, pe.telefono, convert(char(10),sc.fecha,103) as Fecha, cartero.nombres from ",
                " pe_claro pe inner join seguimiento_claro sc on pe.codigo=sc.cod_envio inner join cartero on sc.id_cartero=cartero.id_cartero ",
                " WHERE convert(char(10),sc.fecha,103)='"+string.Format("{0:dd/MM/yyyy}",cbdia.SelectedValue)+"' and (sc.id_centro = '" + modulo.id_sucursal + "') and sc.id_cartero='" + id + "' AND (id_estado = 'A') and exists(select pce.codigo from PE_claro pce where pce.contrato=pe.contrato and pce.mes= (pe.mes+1) and pce.año=year(getdate()))");
            if(dt_sugerencia.Rows.Count>0)
            {
                dgvsugerencia.DataSource = null;
                dgvsugerencia.DataSource = dt_sugerencia.AsDataView();
                dgvsugerencia.Visible = true;
                panelinfosugerencia.Visible = false;
            }
            else
            {
                dgvsugerencia.Visible = false;
                panelinfosugerencia.Visible = true;
            }
            
            //dgvsugerencia.TableDescriptor.GroupedColumns.Add("Fecha", ListSortDirection.Ascending);
        }

        conexion acceso;
        private void frmsugerencias_Load(object sender, EventArgs e)
        {
            /*obtenemos los carteros por oficina postal*/
            //acceso = new conexion();
            //DataTable dtcartero = acceso.buscar("select id_cartero,Nombres from ", "cartero", " where id_centro='" + modulo.id_sucursal + "'");
            //if (dtcartero != null)
            //{
            //    cbcarteros.DataSource = dtcartero;
            //    cbcarteros.DisplayMember = "Nombres";
            //    cbcarteros.ValueMember = "id_cartero";
            //    cbcarteros.Focus();
            //}
            //else
            //{
            //    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            //    MessageBoxAdv.Show("No se pudo conectar con la base de datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            /*cargamos los dias en que se hizo la asignacion en el mes anterior*/
            acceso = new conexion();
            DataTable dias = acceso.buscar("select  distinct convert(datetime,convert(char(10),sc.fecha,103),103) as Dia from ", 
                "pe_claro pe inner join seguimiento_claro sc on sc.cod_envio=pe.codigo ",
                " WHERE pe.año = " + DateTime.Now.Year + " AND pe.mes = " + DateTime.Now.AddMonths(-1).Month + " and (sc.id_centro = '" + modulo.id_sucursal + "') and sc.id_cartero='" + id + "' AND (id_estado = 'A')");
            cbdia.DataSource = dias;
            cbdia.DisplayMember = "Dia";
            cbdia.ValueMember = "Dia";           
            /*dgvsugerencia.TopLevelGroupOptions.ShowFilterBar = true;
            dgvsugerencia.TableDescriptor.Columns["Fecha"].AllowFilter = true;
            dgvsugerencia.TableDescriptor.Appearance.FilterBarCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete;*/
        }

        private void btndistribuir_Click(object sender, EventArgs e)
        {
            if (dgvsugerencia.Table.Records.Count == 0)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No hay registros para procesar.", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            DialogResult resul = MessageBoxAdv.Show("Esta acción asignara los registros de la lista al cartero "+lbcartero.Text+", ¿Esta seguro de Continuar?", "Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resul == DialogResult.No)
            {
                return;
            }
            /*rrecorremos el datatable que contiene las facturas*/
            //for(int fila=0; fila<DT_distibuidas.Rows.Count;fila++)
            for (int fila = 0; fila < dgvsugerencia.Table.FilteredRecords.Count; fila++)
            {
                string codigo = dgvsugerencia.Table.FilteredRecords[fila]["contrato"].ToString() + int.Parse(dgvsugerencia.Table.FilteredRecords[fila]["ciclo"].ToString()).ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString("0000");
                /*buscamos que la factura exista en la tabla PE_claro*/
                acceso = new conexion();
                DataTable existe = acceso.buscar("select * from ", "PE_claro pc", " where pc.codigo='" + codigo + "'");
                if(existe!=null)
                {
                    if(existe.Rows.Count==0)
                    {
                        continue;
                    }
                }
                else
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                acceso = new conexion();              
                DataTable dt_sin_estados = acceso.buscar("select * from ",
                    "pe_claro ",
                    "where pe_claro.codigo='" + codigo+ "' and not exists(select * from seguimiento_claro sc where id_estado in('A','D') and id_centro='" + modulo.id_sucursal + "' and cod_envio='" + codigo + "')");
                if (dt_sin_estados != null)
                {
                    if (dt_sin_estados.Rows.Count > 0)
                    {
                        acceso = new conexion();
                        bool resul2 = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,id_cartero) " +
                            "values('" + codigo + "','A',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','" + id + "')"
                            );
                        if (resul2 == true)
                        {

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
                        continue;
                    }
                   
                }
                else
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void cbdia_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
              load_lista();
            }
            catch
            {

            }
           
        }
    }
}
