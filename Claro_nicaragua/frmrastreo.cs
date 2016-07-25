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
    public partial class frmrastreo : Syncfusion.Windows.Forms.MetroForm
    {

        conexion acceso;
        public frmrastreo()
        {
            InitializeComponent();
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar==13)
            {
                if(txtcodigo.Text.Trim()=="")
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Ingrese el codigo a rastrear", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*hacemos el seguimiento del codigo*/
                acceso = new conexion();
                DataTable dt_rastreo = acceso.buscar("select ec.descripcion, sc.fecha,sc.nombreuser,op.nombrecentro,incidencia, (select nombres from cartero where cartero.id_cartero=sc.id_cartero and sc.cod_envio='"+txtcodigo.Text+"') as Cartero from ",
                    "seguimiento_claro sc inner join estados_claro ec on sc.id_estado=ec.id_estado inner join oficinapostal op on sc.id_centro = op.idcentro ",
                    "where sc.cod_envio='"+txtcodigo.Text+"' order by sc.fecha asc");
                if(dt_rastreo==null)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(dt_rastreo.Rows.Count==0)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Codigo invalido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    dgvrastreo.DataSource = dt_rastreo;
                    panelinforastreo.Visible = false;
                    dgvrastreo.Visible = true;
                }
            }
        }
    }
}
