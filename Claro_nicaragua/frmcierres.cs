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
    public partial class frmcierres : Syncfusion.Windows.Forms.MetroForm
    {
        public frmcierres()
        {
            InitializeComponent();
        }


        conexion acceso;

        private void activos()
        {
            acceso = new conexion();
            DataTable dt_ciclo_activo = acceso.buscar("select distinct ciclo, mes, año, num_imposicion as Imposición from ", "PE_claro ", "where disponible=1");
            dgvciclosactivos.DataSource = dt_ciclo_activo.AsDataView();
        }
        private void tabPageAdv1_Enter(object sender, EventArgs e)
        {
            /*cargamos los ciclos activos*/
            activos();
        }

        private void load_cerrados()
        {
            acceso = new conexion();
            DataTable dt_ciclo_activo = acceso.buscar("select distinct ciclo, mes, año, num_imposicion as Imposición from ", "PE_claro ", "where disponible=0");
            dgvciclocerrado.DataSource = dt_ciclo_activo.AsDataView();
        }

        private void tabPageAdv2_Enter(object sender, EventArgs e)
        {
            load_cerrados();

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            var seleccion = dgvciclosactivos.Table.SelectedRecords;
            if (seleccion.Count > 0)
            {
                int contador = 0;
                foreach (var item in seleccion)
                {
                    conexion acceso = new conexion();
                    bool resul = acceso.insertar("update pe_claro set disponible=0 where num_imposicion='" + item.Record["Imposición"].ToString() + "'");
                    if (resul == true)
                        contador++;
                }
                if (contador == seleccion.Count)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("El ciclo se cerro correctamente", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    activos();
                }
            }
        }

        private void frmcierres_Load(object sender, EventArgs e)
        {
            dgvciclosactivos.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            dgvciclosactivos.TableOptions.AllowSortColumns = false;
            dgvciclocerrado.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            dgvciclocerrado.TableOptions.AllowSortColumns = false;
        }

        private void btnanular_Click(object sender, EventArgs e)
        {
            var seleccion = dgvciclocerrado.Table.SelectedRecords;
            if (seleccion.Count > 0)
            {
                int contador = 0;
                foreach (var item in seleccion)
                {
                    conexion acceso = new conexion();
                    bool resul = acceso.insertar("update pe_claro set disponible=1 where num_imposicion='" + item.Record["Imposición"].ToString() + "'");
                    if (resul == true)
                        contador++;
                }
                if (contador == seleccion.Count)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Cierre anulado", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load_cerrados();
                }
            }
        }

    }
}
