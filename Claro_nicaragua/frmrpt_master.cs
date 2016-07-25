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
    public partial class frmrpt_master : Syncfusion.Windows.Forms.MetroForm
    {

    
        public frmrpt_master()
        {
            InitializeComponent();
        }

        private void frmrpt_master_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dptfechafin.Value = DateTime.Now;
            dptfechaini.Value = DateTime.Now;
        }

        frmworking frmwork;
        dsreportes ds;
        private void btngenerar_Click(object sender, EventArgs e)
        {
            if(cbopciones.SelectedIndex!=-1)
            {
                hilo_rpt.RunWorkerAsync(cbopciones.SelectedIndex);
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
        }

        private void hilo_rpt_DoWork(object sender, DoWorkEventArgs e)
        {
            int opcion = (int)e.Argument;
            if(opcion==0)
            {
                DataTable dt_report = new DataTable();
                conexion conex = new conexion();
                SqlDataAdapter da = new SqlDataAdapter("get_segui_claro", conex.con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime);
                da.SelectCommand.Parameters["@fecha1"].Value = string.Format("{0:yyyy-MM-dd}", dptfechaini.Value) + " 00:00:00" ;
                da.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime);
                da.SelectCommand.Parameters["@fecha2"].Value = string.Format("{0:yyyy-MM-dd}", dptfechafin.Value) + " 23:59:59";
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.Int);
                da.SelectCommand.Parameters["@centro"].Value = int.Parse(modulo.id_sucursal);
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
                    ds.DT_lista.Rows.Add(row["ciclo"], row["nombres"], row["departamento"], row["barrio"],  string.Format("{0:dd-MM-yyyy}",row["fecha"]), row["direccion"], row["id_estado"], string.Format("{0:hh:mm:ss}", row["fecha"]),row["direccion"]);
                }
            }
        }

        private void hilo_rpt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmwork.Close();
            rpt_estatus POD = new rpt_estatus();
            POD.SetDataSource(ds.Tables["DT_lista"]);
            POD.SetParameterValue("desc_estado", "Distribuidas");
            POD.SetParameterValue("estado", "A");
            POD.SetParameterValue("fecha1", string.Format("{0:dd-MM-yy}", dptfechaini.Value));
            POD.SetParameterValue("fecha2", string.Format("{0:dd-MM-yy}", dptfechafin.Value));
            crystalReportViewer1.ReportSource = POD;
        }
    }
}
