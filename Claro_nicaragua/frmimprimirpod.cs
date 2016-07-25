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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Claro_nicaragua
{
    public partial class frmimprimirpod : Syncfusion.Windows.Forms.MetroForm
    {
        public frmimprimirpod()
        {
            InitializeComponent();
        }

        frmworking frmwork;
        dsreportes ds;
        private void txtimposicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar==13)
            {
                if(txtimposicion.Text!="")
                {
                    hilo_print_pod.RunWorkerAsync(txtimposicion.Text);
                    frmwork = new frmworking();
                    frmwork.ShowDialog();
                }
                else
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Ingrese el Número de imposición", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void hilo_print_pod_DoWork(object sender, DoWorkEventArgs e)
        {
            string impo = e.Argument.ToString();
            DataTable dt_report = new DataTable();
            conexion conex = new conexion();
            SqlDataAdapter da = new SqlDataAdapter("print_pruebas_claro", conex.con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@imposicion", SqlDbType.NVarChar);
            da.SelectCommand.Parameters["@imposicion"].Value = impo;
            da.Fill(dt_report);
            if (dt_report == null)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Error al conectar con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ds = new dsreportes();
            foreach (DataRow row in dt_report.Rows)
            {
                ds.DT_POD.Rows.Add(row["codigo"], row["nombre_completo"], row["direccion"], row["Num_imposicion"], row["servicio"]);
            }
        }

        private void hilo_print_pod_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmwork.Close();
            Rpt_PE POD = new Rpt_PE();
            POD.SetDataSource(ds.Tables["DT_POD"]);
            crystalReportViewer1.ReportSource = POD;
        }

        private void frmimprimirpod_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
    }
}
