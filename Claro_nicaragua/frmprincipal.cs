#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Claro_nicaragua.clases;
using ClosedXML.Excel;
using Syncfusion.Drawing;
using Syncfusion.GridExcelConverter;
using Syncfusion.GroupingGridExcelConverter;
//using Syncfusion.Linq;
using Syncfusion.Windows.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Claro_nicaragua
{
    public partial class frmprincipal : Syncfusion.Windows.Forms.MetroForm
    {
        string nombre_file;
        conexion acceso;
        DataTable DT_distibuidas;
        DataTable dt_info, dt_info_ordenada, dt_listafinal;
        frmworking trabajando;
        DataTable Dt_pendientesXdistribuir;
        frmworking frmwork;
        public frmprincipal()
        {
            InitializeComponent();
            tabControlAdv1.SelectedIndex = 0;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void btnimportar_Click(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
            dialog.InitialDirectory = @"E:\";
            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                lbruta.Text = dialog.FileName;
                nombre_file = dialog.SafeFileName;
                obtener_hojas(lbruta.Text,cbhoja);
            }
        }

        private void obtener_hojas(string archivo, Syncfusion.Windows.Forms.Tools.ComboBoxAdv cb)
        {
            cbhoja.Items.Clear();
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataTable dt = null;
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
            try
            {
                //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                conexion.Open(); //abrimos la conexio
                dt = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                conexion.Close();//cerramos la conexion
                if (dt.Rows.Count > 0)
                {
                    cb.Items.Clear();
                    foreach (DataRow item in dt.Rows)
                    {
                        cb.Items.Add(item["TABLE_NAME"].ToString());
                    }
                    cb.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                cb.Items.Clear();
                MessageBox.Show("Ocurrio un error cuando se estaba cargando el archivo", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable obtenerdatos(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            DataTable dt = null;
            string consultaHojaExcel = "Select * from [" + hoja + "]";

            //esta cadena es para archivos excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("Seleccione Una Hoja del archivo");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    dt = dataSet.Tables[0];
                    conexion.Close();//cerramos la conexion
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Ocurrio un error cuando se cargaba la informacion del archivo", ex.Message);
                }
            }
            return dt;
        }

        private DataView clasificar_registros(DataTable dt)
        {
            dt.Columns.Add("IdOficinaPostal");
            dt.Columns.Add("IdZonaPostal");
            /*rrecorremos el datatable para asignar el codigo postal y la zona postal*/
            for (int fila = 0; fila < dt.Rows.Count; fila++)
            {
                string id_barrio = dt.Rows[fila]["IdBarrio"].ToString().Trim();
                string id_municipio = dt.Rows[fila]["IdMunicipio"].ToString().Trim();
                string id_dep = dt.Rows[fila]["IdDepartamento"].ToString().Trim();
                if (id_barrio != string.Empty)
                {
                    acceso = new conexion();
                    DataTable dt_temp = acceso.buscar("select IdZonaPostal,IdOficinaPostal from ", "Barrio ", "where IdBarrio='" + id_barrio + "'");
                    if (dt_temp.Rows.Count > 0)
                    {
                        if (dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim() != "" && dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim() != "")
                        {
                            dt.Rows[fila]["IdOficinaPostal"] = dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim();
                            dt.Rows[fila]["IdZonaPostal"] = dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim();
                        }
                        else
                        {
                            acceso = new conexion();
                            dt_temp = acceso.buscar("select top 1 IdZonaPostal,IdOficinaPostal from ", "Barrio ", "where IdMunicipio='" + id_municipio + "'");
                            if (dt_temp.Rows.Count > 0)
                            {
                                if (dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim() != "" && dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim() != "")
                                {
                                    dt.Rows[fila]["IdOficinaPostal"] = dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim();
                                    dt.Rows[fila]["IdZonaPostal"] = dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim();
                                }
                                else
                                {
                                    acceso = new conexion();
                                    dt_temp = acceso.buscar("select top 1 IdZonaPostal,IdOficinaPostal from ", "Barrio ", "where IdDepto='" + id_dep + "'");
                                    if (dt_temp.Rows.Count > 0)
                                    {
                                        dt.Rows[fila]["IdOficinaPostal"] = dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim();
                                        dt.Rows[fila]["IdZonaPostal"] = dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        acceso = new conexion();
                        dt_temp = acceso.buscar("select top 1 IdZonaPostal,IdOficinaPostal from ", "Barrio ", "where IdMunicipio='" + id_municipio + "'");
                        if (dt_temp.Rows.Count > 0)
                        {
                            if (dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim() != "" && dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim() != "")
                            {
                                dt.Rows[fila]["IdOficinaPostal"] = dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim();
                                dt.Rows[fila]["IdZonaPostal"] = dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim();
                            }
                            else
                            {
                                acceso = new conexion();
                                dt_temp = acceso.buscar("select top 1 IdZonaPostal,IdOficinaPostal from ", "Barrio ", "where IdDepto='" + id_dep + "'");
                                if (dt_temp.Rows.Count > 0)
                                {
                                    dt.Rows[fila]["IdOficinaPostal"] = dt_temp.Rows[0]["IdOficinaPostal"].ToString().Trim();
                                    dt.Rows[fila]["IdZonaPostal"] = dt_temp.Rows[0]["IdZonaPostal"].ToString().Trim();
                                }
                            }
                        }
                    }
                }
            }

            /*ordenamos el datatable*/
            var datos_clasificados = (from table in dt.AsEnumerable()
                                      orderby Convert.ToString(table["IdOficinaPostal"]) ascending, Convert.ToString(table[19]) ascending, Convert.ToString(table[20]) ascending, Convert.ToString(table[15]) ascending, Convert.ToString(table[18]) ascending, Convert.ToString(table[8]) ascending, Convert.ToString(table[2]) ascending
                                      select table);
            return datos_clasificados.AsDataView();
        }

    
        private void hilolistaprevia_DoWork(object sender, DoWorkEventArgs e)
        {
            /*realizamos el ordenamiento de los registros por CD*/
            
            dt_info = obtenerdatos(lbruta.Text, cbhoja.SelectedItem.ToString());
            dt_info_ordenada= clasificar_registros(dt_info).ToTable();
        }
        private void hilolistaprevia_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /**/
            //dgvlistprevia.DataSource = dt_info_ordenada;
            /*var info_mostrar = (from table in dt_info_ordenada.AsEnumerable()
                                select new
                                {
                                    Nombres = table[7],
                                    Direccion = table[8],
                                    Departamento = table[11],
                                    Municipio = table[10],
                                    Barrio = table[9]
                                });*/
            dgvlistprevia.DataSource = dt_info_ordenada.AsDataView();
            trabajando.Close();
            dgvlistprevia.Visible = true;
            panelinfoclasificacion.Visible = false;
        }

       

        private void btncargarlistaf_Click(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
            dialog.InitialDirectory = @"E:\";
            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo
            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                lbrutalistaf.Text = dialog.FileName;
                obtener_hojas(lbrutalistaf.Text, cbhojalistaf);
                if(cbhojalistaf.Items.Count==0)
                {
                    lbrutalistaf.Text = "";
                }
            }
        }


        private void btnshowlistaf_Click(object sender, EventArgs e)
        {
            /*cuando seleccionamos una hoja*/
            if (cbhojalistaf.SelectedItem != null)
            {             
                dt_listafinal = obtenerdatos(lbrutalistaf.Text, cbhojalistaf.SelectedItem.ToString());
                dgvlistafinal.DataSource = dt_listafinal;
                dgvlistafinal.Visible = true;
                panelinfolistafinal.Visible = false;
            }
        }

        private void btnclasificar_Click(object sender, EventArgs e)
        {
            /*cuando seleccionamos una hoja*/
            if (cbhoja.SelectedItem != null)
            {
                hilolistaprevia.RunWorkerAsync();
                trabajando = new frmworking();
                trabajando.ShowDialog();
            }
        }

        private void hilolistafinal_DoWork(object sender, DoWorkEventArgs e)
        {
            int imposicion = int.Parse(txtimposicion.Text);
            string codigo;
            for (int fila = 0; fila < dt_listafinal.Rows.Count; fila++)
            {
                acceso = new conexion();
                codigo = dt_listafinal.Rows[fila][2].ToString() + string.Format("{0:00}", int.Parse(dt_listafinal.Rows[fila][4].ToString())) + string.Format("{0:00}", int.Parse(dt_listafinal.Rows[fila][5].ToString())) + dt_listafinal.Rows[fila][6].ToString();
                bool resul = acceso.insertar("insert into PE_claro(Codigo,consecutivo,factura,contrato,ciclo,mes,año,cliente,direccion,barrio,municipio,departamento,Distribuido,Ruta,zona,telefono,Segmento,IdBarrio,IdDepartamento,IdMunicipio,servicio,num_imposicion,fecha,ARCHIVO_SEGMENTADO,tarifa_destino, disponible) " +
                    "values('" + codigo + "','" + dt_listafinal.Rows[fila][1].ToString() + "','" + dt_listafinal.Rows[fila][3].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][2].ToString() + "','" + dt_listafinal.Rows[fila][4].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][5].ToString() + "','" + dt_listafinal.Rows[fila][6].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][7].ToString().Replace("'", " ") + "','" + dt_listafinal.Rows[fila][8].ToString().Replace("'", " ") + "'," +
                "'" + dt_listafinal.Rows[fila][9].ToString() + "','" + dt_listafinal.Rows[fila][10].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][11].ToString() + "','" + dt_listafinal.Rows[fila][12].ToString() + "','" + dt_listafinal.Rows[fila][13].ToString() + "','" + dt_listafinal.Rows[fila][14].ToString() + "','" + dt_listafinal.Rows[fila][15].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][16].ToString() + "','" + dt_listafinal.Rows[fila][18].ToString() + "'," +
                "'" + dt_listafinal.Rows[fila][19].ToString() + "','" + dt_listafinal.Rows[fila][20].ToString() + "','" + dt_listafinal.Rows[fila][21].ToString() + "'," + imposicion + ",getdate(),'" + dt_listafinal.Rows[fila][0].ToString() + "','" + dt_listafinal.Rows[fila][17].ToString() + "',1)");
                if (resul == true)
                {
                    dgvlistafinal.Table.Records[fila].Delete();
                    dt_listafinal.Rows.RemoveAt(fila);
                    fila--;
                }
            }
        }

        private void hilolistafinal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            trabajando.Close();
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            if (dt_listafinal.Rows.Count == 0)
            {
                dgvlistafinal.Visible = false;
                panelinfolistafinal.Visible = true;
                lbrutalistaf.Text = "--------------";
                txtimposicion.Text = "";
                cbhojalistaf.Items.Clear();       
                MessageBoxAdv.Show("La lista se agrego correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxAdv.Show("No se guardaron todos los registros esto se puede deber a que ya existen en la base de datos o que se hayan producidos errores de conexion mientras se ejecutaba la tarea", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void load_pendientes()
        {
            //acceso = new conexion();
            Dt_pendientesXdistribuir = new DataTable();
            /*Dt_pendientesXdistribuir = acceso.buscar("select codigo as Codigo,contrato as Contrato, cliente,ciclo,mes as Mes,departamento as Departamento, municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio from ",
                "PE_claro inner join Barrio on PE_claro.IdBarrio= barrio.IdBarrio INNER JOIN Departamentos ON Barrio.IdDepto = Departamentos.IdDepto INNER JOIN Municipios ON Barrio.IdMunicipio = Municipios.IdMunicipio INNER JOIN OficinaPostal ON Barrio.IdOficinaPostal = OficinaPostal.IdCentro ",
                " where disponible=1 and OficinaPostal.IdCentro='" + modulo.id_sucursal + "' and not exists(select * from  seguimiento_claro sc where sc.cod_envio=PE_claro.codigo)" +
                " union" +
                " select codigo as Codigo,contrato as Contrato, cliente,ciclo,mes as Mes,departamento as Departamento," +
                " municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio" +
                " from PE_claro inner join seguimiento_claro sc on sc.cod_envio=PE_claro.codigo" +
                " where (sc.id_centro='"+modulo.id_sucursal+ "' and disponible=1 and id_estado='E' and not exists(select * from  seguimiento_claro sc where sc.cod_envio=PE_claro.codigo and sc.id_estado='A' and sc.id_centro='" + modulo.id_sucursal + "'))");*/
            //Dt_pendientesXdistribuir = acceso.buscar("select codigo as Codigo,contrato as Contrato, cliente,ciclo,mes as Mes,departamento as Departamento, municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio from ",
            //"PE_claro inner join Barrios_aprendidos_claro on (cast(PE_claro.IdBarrio as varchar)+cast(PE_claro.zona as varchar))=(cast(Barrios_aprendidos_claro.Id_barrio as varchar)+cast(Barrios_aprendidos_claro.zona as varchar)) ",
            //" where disponible=1 and Barrios_aprendidos_claro.idcentro='" + modulo.id_sucursal + "' and not exists(select * from  seguimiento_claro sc where sc.cod_envio=PE_claro.codigo)" +
            //" union" +
            //" select codigo as Codigo,contrato as Contrato, cliente,ciclo,mes as Mes,departamento as Departamento," +
            //" municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio" +
            //" from PE_claro inner join seguimiento_claro sc on sc.cod_envio=PE_claro.codigo" +
            //" where (sc.id_centro='" + modulo.id_sucursal + "' and disponible=1 and id_estado='E' and not exists(select * from  seguimiento_claro sc where sc.cod_envio=PE_claro.codigo and sc.id_estado in ('A','D') and sc.id_centro='" + modulo.id_sucursal + "'))");
                     
            acceso = new conexion();
            SqlDataAdapter da = new SqlDataAdapter("load_pendientes_claro", acceso.con);
            da.SelectCommand.CommandTimeout = 120;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@sucursal", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@sucursal"].Value = modulo.id_sucursal;
            da.Fill(Dt_pendientesXdistribuir);
            
            //if (Dt_pendientesXdistribuir != null)
            //{
            //    if(Dt_pendientesXdistribuir.Rows.Count >0)
            //    {
            //        dgvdistribucion.TableDescriptor.GroupedColumns = null;
            //        dgvdistribucion.DataSource = Dt_pendientesXdistribuir.AsDataView();
            //        dgvdistribucion.TableDescriptor.GroupedColumns.Add("Ciclo");
            //        dgvdistribucion.TableDescriptor.VisibleColumns.Remove("Ciclo");
            //        dgvdistribucion.Table.ExpandAllGroups();
            //        panelinfodistribucion.Visible = false;
            //        dgvdistribucion.Visible = true;             
            //    }
            //    else
            //    {
            //        dgvdistribucion.DataSource = Dt_pendientesXdistribuir.AsDataView();
            //        panelinfodistribucion.Visible = true;
            //        dgvdistribucion.Visible = false;
            //    }
            //}

        }


        
        private void tabControlAdv1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControlAdv1.SelectedIndex==3)
            {
                
                /*if (ckasignadas.Checked==false)
                { load_pendientes(); }
                else
                { load_distibuidas(); }                
                cbcarteros.Focus();*/
            }
            else if(tabControlAdv1.SelectedIndex==4)
            {
                
                /*if (cbopciones.SelectedIndex == 0)
                {
                    load_entregadas();
                }
                else
                {
                    load_entrega_fallida();
                }*/
            }
            else if(tabControlAdv1.SelectedIndex == 5)
            {
               

            }
        }


        private DataTable load_View_seguimiento()
        {
            DataTable dt_seguimiento = new DataTable();
            acceso = new conexion();
            SqlDataAdapter da = new SqlDataAdapter("view_segui", acceso.con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt_seguimiento);
            return dt_seguimiento;
                //DataTable dt_seguimiento;
                //acceso = new conexion();
                //dt_seguimiento = acceso.buscar(
                //"select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.factura as Factura, CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha, op.nombrecentro as Centro, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero,(select top 1 ec.id_estado from estados_claro ec inner join seguimiento_claro sc on ec.id_estado=sc.id_estado where sc.cod_envio=pc.codigo and sc.id_estado in('A','B','C') order by sc.fecha desc) as Estado from ",
                ////"PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero inner join oficinapostal op on sc.id_centro=op.idcentro ",
                //"where sc.id_estado in ('A') and disponible=1 order by sc.fecha desc");
                //not exists(select * from seguimiento_claro scc where scc.id_estado in ('D', 'F') and scc.cod_envio = sc.cod_envio and scc.id_centro = sc.id_centro)
            /*if (dt_seguimiento != null)
            {
                if (dt_seguimiento.Rows.Count > 0)
                {
                    //var grupo_select = dgvcysegui.TableDescriptor.GroupedColumns.GetEnumerator();
                    dgvcysegui.TableDescriptor.GroupedColumns = null;
                    dgvcysegui.DataSource = null;
                    dgvcysegui.DataSource = dt_seguimiento.AsDataView();
                    //dgvcysegui.TableDescriptor.GroupedColumns.Add("Fecha");
                    //dgvcysegui.TableDescriptor.VisibleColumns.Remove("fecha");
                    dgvcysegui.TableDescriptor.GroupedColumns.Add("Centro");
                    dgvcysegui.TableDescriptor.VisibleColumns.Remove("Centro");
                    dgvcysegui.TableDescriptor.GroupedColumns.Add("Cartero");
                    dgvcysegui.TableDescriptor.VisibleColumns.Remove("Cartero");
                    //dgvcysegui.TableDescriptor.GroupedColumns.Add("ciclo");
                    //dgvcysegui.TableDescriptor.VisibleColumns.Remove("ciclo");
                    dgvcysegui.TableDescriptor.SortedColumns.Add("Estado", ListSortDirection.Ascending);
                    //dgvcysegui.Table.ExpandAllGroups();
                    /*expandimos los grupos primarios del grid*/
                    //for(int grupo=0; grupo< dgvcysegui.Table.TopLevelGroup.Groups.Count; grupo++)
                    //{
                        //dgvcysegui.Table.TopLevelGroup.Groups[grupo].IsExpanded = true;
                    //}
                   
                    //dgvcysegui.ChildGroupOptions.CaptionText = "{CategoryCaption}: {Category} - {RecordCount}  Registros";
                    //dgvcysegui.Visible = true;
                    //this.dgvcysegui.ChildGroupOptions.CaptionText = "{RecordCount} Items ";
                    //GridExcelFilter filter = new GridExcelFilter(); //To wire grid with filter 
                    //filter.WireGrid(this.gridGroupingControl1);

               // }
                //else
                //{
                    //dgvcysegui.DataSource = dt_seguimiento.AsDataView();
                    //dgvseguimiento.Visible = false;
                    //panelinfoseguimiento.Visible = true;
                //}
            //}*/
        }

        private DataTable load_View_rezagos()
        {
            DataTable dt_rezago=new DataTable();            
            acceso = new conexion();
            dt_rezago = acceso.buscar(
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.factura as Factura, CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha, op.nombrecentro as Centro, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, (select Nombres from cartero car inner join seguimiento_claro sc on car.id_cartero=sc.id_cartero where sc.cod_envio=pc.codigo and sc.id_estado='A' and sc.id_centro='" + modulo.id_sucursal+ "') as Cartero, incidencia_claro.incidencia as Incidencia from ",
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join oficinapostal op on sc.id_centro=op.idcentro inner join incidencia_claro on sc.incidencia=incidencia_claro.id_incidencia ",
            "where sc.id_estado in ('C') and pc.disponible=1");
            return dt_rezago;
            //if (dt_rezago != null)
            //{
            //    if (dt_rezago.Rows.Count > 0)
            //    {
            //        dgvcysegui.TableDescriptor.GroupedColumns = null;
            //        dgvcysegui.DataSource = null;
            //        dgvcysegui.DataSource = dt_rezago.AsDataView();
            //        dgvcysegui.TableDescriptor.GroupedColumns.Add("Fecha");
                   
            //        dgvcysegui.TableDescriptor.GroupedColumns.Add("Centro");
                  
            //        dgvcysegui.TableDescriptor.GroupedColumns.Add("Cartero");
            //        dgvcysegui.TableDescriptor.VisibleColumns.Remove("Cartero");
            //        dgvcysegui.TableDescriptor.GroupedColumns.Add("ciclo");
                    
            //        dgvcysegui.Table.ExpandAllGroups();
            //        dgvcysegui.Visible = true;
                 
            //    }
            //    else
            //    {
            //        dgvcysegui.DataSource = dt_rezago.AsDataView();
            //    }
            //}
        }

        private DataTable load_entregadas()
        {
            acceso = new conexion();
            DataTable entregadas = acceso.buscar(
             "select codigo as Codigo,cliente,departamento as Departamento, municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio, convert(char(10),sc.fecha,103) as Fecha from ",
             "PE_claro inner join seguimiento_claro sc on sc.cod_envio=PE_claro.codigo ",
             " WHERE ( disponible=1 and  sc.id_centro='" + modulo.id_sucursal + "' and id_estado='B' and sc.fecha between '" + dptfecha1.Value.ToString("yyyyMMdd") + "' and '" + dptfecha2.Value.ToString("yyyy-MM-dd") + "T23:59:59') order by Fecha desc"
                );
            return entregadas;
            /*if (entregadas != null)
            {
                if (entregadas.Rows.Count > 0)
                {
                    dgvseguimiento.DataSource = null;
                    dgvseguimiento.DataSource = entregadas.AsDataView();
                    panelinfoseguimiento.Visible = false;
                    dgvseguimiento.Visible = true;
                }
                else
                {
                    dgvseguimiento.DataSource = entregadas.AsDataView();
                    panelinfoseguimiento.Visible = true;
                    dgvseguimiento.Visible = false;
                }               
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Error al conectar con la base de datos, intente mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        public DataTable load_entrega_fallida()
        {
            acceso = new conexion();
            DataTable no_entregadas = acceso.buscar(
             "select codigo as Codigo, contrato as Contrato, cliente as Cliente,ciclo, convert(char(10),sc.fecha,103) as Fecha, departamento as Departamento, municipio as Municipio,PE_claro.barrio as Barrio, PE_claro.direccion as Dirección,servicio as Servicio, incidencia_claro.incidencia as Incidencia,(select nombres from cartero inner join seguimiento_claro sc on cartero.id_cartero=sc.id_cartero where sc.cod_envio=PE_claro.codigo and sc.id_estado='A' and sc.id_centro='" + modulo.id_sucursal+"') as Cartero from ",
             "PE_claro inner join  seguimiento_claro sc on sc.cod_envio=PE_claro.codigo inner join incidencia_claro on sc.incidencia=incidencia_claro.id_incidencia",
             " WHERE (sc.id_centro='" + modulo.id_sucursal + "' and sc.id_estado='C' and disponible=1 and sc.fecha between '" + dptfecha1.Value.ToString("yyyyMMdd") + "' and '" + dptfecha2.Value.ToString("yyyy-MM-dd") + "T23:59:59') order by sc.fecha desc"
                );
            return no_entregadas;
            /*if (no_entregadas != null)
            {
                if (no_entregadas.Rows.Count > 0)
                {
                    dgvseguimiento.TableDescriptor.GroupedColumns = null;
                    dgvseguimiento.DataSource = null;
                    dgvseguimiento.DataSource = no_entregadas.AsDataView();
                    //this.dgvseguimiento.TableDescriptor.AllowNew = false;
                    dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                    dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                    dgvseguimiento.TableDescriptor.GroupedColumns.Add("ciclo");
                    dgvseguimiento.TableDescriptor.VisibleColumns.Remove("ciclo");                    
                    dgvseguimiento.Table.ExpandAllGroups();
                    panelinfoseguimiento.Visible = false;
                    dgvseguimiento.Visible = true;
                }
                else
                {
                    dgvseguimiento.DataSource = no_entregadas.AsDataView();
                    panelinfoseguimiento.Visible = true;
                    dgvseguimiento.Visible = false; 
                }

            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Error al conectar con la base de datos, intente mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void btndistribuir_Click(object sender, EventArgs e)
        {
            /*validamos que el combo carteros no sea nulo*/
            if(cbcarteros.SelectedIndex==-1)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Antes de la asignacion debe seleccionar el cartero", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmadddistri frmdist = new frmadddistri(cbcarteros.Text, (int)cbcarteros.SelectedValue);
                frmdist.ShowDialog();
                /*refrescamos la lista de las pendientes o de las asignadas*/
                //if(ckasignadas.Checked==false)
                //{
                //load_distibuidas();
                //load_pendientes();
                hiloasignar.RunWorkerAsync();
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
           
        }


        private DataTable load_all_asignadas()
        {
            //DT_distibuidas = null;
            DataTable dt_seguimiento_local;
            acceso = new conexion();
            /*DT_distibuidas = acceso.buscar(
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero, sc.fecha as Fecha from ",
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero ",
            "where sc.id_estado in ('A') and sc.id_centro='" + modulo.id_sucursal + "' and not exists(select * from seguimiento_claro scc where scc.id_estado in ('D') and scc.cod_envio=sc.cod_envio and scc.id_centro='" + modulo.id_sucursal + "') and disponible=1");*/
            dt_seguimiento_local=acceso.buscar(
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero,(select top 1 ec.id_estado from estados_claro ec inner join seguimiento_claro sc on ec.id_estado=sc.id_estado where sc.cod_envio=pc.codigo and sc.id_estado in('A','B','C','F') order by sc.fecha desc) as Estado from ",
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero inner join oficinapostal op on sc.id_centro=op.idcentro ",
            "where sc.id_estado in ('A') and disponible=1 and sc.id_centro='"+modulo.id_sucursal+"' order by sc.fecha desc");
            return dt_seguimiento_local;
            /*if (dt_seguimiento_local != null)
            {
                if (dt_seguimiento_local.Rows.Count > 0)
                {
                    dgvseguimiento.TableDescriptor.GroupedColumns = null;
                    dgvseguimiento.DataSource = null;
                    dgvseguimiento.DataSource = dt_seguimiento_local.AsDataView();
                    dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                    dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                    //dgvseguimiento.TableDescriptor.GroupedColumns.Add("ciclo");
                    //dgvseguimiento.TableDescriptor.VisibleColumns.Remove("ciclo");
                    //dgvseguimiento.Table.ExpandAllGroups();
                    //dgvseguimiento.TableDescriptor.SortedColumns.Add("Estado", ListSortDirection.Ascending);
                    //dgvcysegui.Table.ExpandAllGroups();
                    /*expandimos los grupos primarios del grid*/
                    /*for (int grupo = 0; grupo < dgvseguimiento.Table.TopLevelGroup.Groups.Count; grupo++)
                    {
                        dgvseguimiento.Table.TopLevelGroup.Groups[grupo].IsExpanded = true;
                    }
                    dgvseguimiento.Visible = true;
                    panelinfoseguimiento.Visible = false;
                }
                else
                {
                    dgvseguimiento.DataSource = dt_seguimiento_local.AsDataView();
                    dgvseguimiento.Visible = false;
                    panelinfoseguimiento.Visible = true;
                }
            }*/
        }

        private void load_distibuidas(DateTime fecha)
        {
            DT_distibuidas = null;
            acceso = new conexion();
            DT_distibuidas = acceso.buscar(
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero from ",
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero ",
            "where sc.id_estado in ('A','F') and sc.id_centro='" + modulo.id_sucursal + "'  and not exists(select * from seguimiento_claro scc where scc.id_estado in ('B','C','D') and scc.cod_envio=sc.cod_envio and scc.id_centro='" + modulo.id_sucursal + "') and (pc.fecha_ini <= '" + DateTime.Now.ToString("yyyyMMdd") + "') and (pc.fecha_fin > '" + DateTime.Now.ToString("yyyyMMdd") + "')");

            //and sc.fecha between ('"+string.Format("{0:yyyyMMdd}", fecha)+"' and '"+ string.Format("{0:yyyyMMdd}", fecha) + "' : 23:59:59)
            if (DT_distibuidas != null)
            {
                if (DT_distibuidas.Rows.Count > 0)
                {
                    dgvdistribucion.TableDescriptor.GroupedColumns = null;
                    dgvdistribucion.DataSource = DT_distibuidas.AsDataView();
                    dgvdistribucion.TableDescriptor.GroupedColumns.Add("Cartero");
                    dgvdistribucion.TableDescriptor.VisibleColumns.Remove("Cartero");
                    dgvdistribucion.TableDescriptor.GroupedColumns.Add("ciclo");
                    dgvdistribucion.TableDescriptor.VisibleColumns.Remove("ciclo");
                    dgvdistribucion.Table.ExpandAllGroups();
                    dgvdistribucion.Visible = true;
                    panelinfoseguimiento.Visible = false;
                }
                else
                {
                    dgvdistribucion.DataSource = DT_distibuidas.AsDataView();
                    dgvdistribucion.Visible = false;
                    panelinfoseguimiento.Visible = true;
                }
            }
        }


        private DataTable load_distibuidas()
        {
            DT_distibuidas = new DataTable();
            /*acceso = new conexion();
            DT_distibuidas = acceso.buscar(
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero,sc.id_estado,CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha from ",
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero ",
            "where sc.id_estado in ('A') and sc.fecha between '"+dptfecha1.Value.ToString("yyyyMMdd")+"' and '"+ dptfecha2.Value.ToString("yyyy-MM-dd") + "T23:59:59' and sc.id_centro='" + modulo.id_sucursal + "' and not exists(select * from seguimiento_claro scc where scc.id_estado in ('F','B','C','D') and scc.cod_envio=sc.cod_envio and scc.id_centro='" + modulo.id_sucursal + "') and disponible=1 " +
            " union " +
            "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, (select Nombres from cartero inner join seguimiento_claro scc on scc.id_cartero=cartero.id_cartero where scc.cod_envio = pc.codigo and scc.id_estado = 'A' and scc.id_centro = '" + modulo.id_sucursal + "') as Cartero,sc.id_estado,CONVERT(VARCHAR(10), sc.fecha, 103) as Fecha from " +
            "PE_claro pc inner join seguimiento_claro sc on pc.codigo = sc.cod_envio inner join estados_claro ec on sc.id_estado = ec.id_estado " +
            "where sc.id_estado in ('F') and sc.fecha between '" + dptfecha1.Value.ToString("yyyyMMdd") + "' and '" + dptfecha2.Value.ToString("yyyy-MM-dd")  + "T23:59:59' and sc.id_centro='" + modulo.id_sucursal + "' and not exists(select * from seguimiento_claro scc where scc.tid_esado in ('B','C','D') and scc.cod_envio=sc.cod_envio and scc.id_centro='" + modulo.id_sucursal + "') and disponible=1 order by sc.fecha desc");*/
            /*DT_distibuidas = acceso.buscar(
           "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, cartero.nombres as Cartero,sc.id_estado,sc.fecha as Fecha from ",
           "PE_claro pc inner join seguimiento_claro sc on pc.codigo=sc.cod_envio inner join estados_claro ec on sc.id_estado=ec.id_estado inner join cartero on sc.id_cartero=cartero.id_cartero ",
           "where sc.id_estado in ('A') and sc.id_centro='" + modulo.id_sucursal + "' and disponible=1" +
           " union " +
           "select  pc.codigo as Codigo, pc.ciclo, pc.contrato as Contrato, pc.cliente as Cliente, pc.departamento as Departamento,pc.municipio as Municipio,pc.barrio as Barrio, pc.direccion as Dirección, 
           (select Nombres from cartero inner join seguimiento_claro scc on scc.id_cartero=cartero.id_cartero where scc.cod_envio = pc.codigo and scc.id_estado = 'A' and scc.id_centro = '" + modulo.id_sucursal + "') as Cartero,sc.id_estado,sc.fecha as Fecha from " +
           "PE_claro pc inner join seguimiento_claro sc on pc.codigo = sc.cod_envio inner join estados_claro ec on sc.id_estado = ec.id_estado " +
           "where sc.id_estado in ('F') and sc.id_centro='" + modulo.id_sucursal + "' and disponible=1"
           );*/
            acceso = new conexion();
            SqlDataAdapter da = new SqlDataAdapter("load_distibuidas", acceso.con);
            da.SelectCommand.CommandTimeout = 120;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@fecha1", SqlDbType.DateTime);
            da.SelectCommand.Parameters["@fecha1"].Value = DateTime.Parse(dptfecha1.Value.ToString("yyyy-MM-dd"));
            da.SelectCommand.Parameters.Add("@fecha2", SqlDbType.DateTime);
            da.SelectCommand.Parameters["@fecha2"].Value = DateTime.Parse(dptfecha2.Value.ToString("yyyy-MM-dd")+"T23:59:59");
            da.SelectCommand.Parameters.Add("@sucursal", SqlDbType.NVarChar);
            da.SelectCommand.Parameters["@sucursal"].Value = modulo.id_sucursal;
            da.Fill(DT_distibuidas);
            return DT_distibuidas;
            /*if (DT_distibuidas != null)
            {
                if(DT_distibuidas.Rows.Count>0)
                {
                    dgvseguimiento.DataSource = null;
                    dgvseguimiento.TableDescriptor.GroupedColumns = null;
                    dgvseguimiento.DataSource = DT_distibuidas.AsDataView();
                    dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                    //dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                    //dgvdistribucion.TableDescriptor.GroupedColumns.Add("ciclo");
                    //dgvdistribucion.TableDescriptor.VisibleColumns.Remove("ciclo");
                    /*GridColumnDescriptor EmpName = new GridColumnDescriptor();
                    EmpName.MappingName = "Revertir";
                    dgvseguimiento.TableDescriptor.Columns.Add(EmpName);*/
                    //dgvseguimiento.Table.ExpandAllGroups();
                    //dgvseguimiento.Visible = true;
                    //Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_Pendientes = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                    //Conditional Formatting applied through designer
                    //format_Pendientes.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(219))))));
                    //format_Pendientes.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                    //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                    // Applies format by checking the value ‘Row1’
                    /*format_Pendientes.Expression = "[id_estado]  LIKE \'F\'";
                    format_Pendientes.Name = "ConditionalFormat 1";*/
                    /*dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_Pendientes);
                    dgvseguimiento.TableDescriptor.VisibleColumns.Remove("id_estado");
                    panelinfoseguimiento.Visible = false;
                }
                else
                {
                    dgvseguimiento.DataSource = DT_distibuidas.AsDataView();
                    dgvseguimiento.Visible = false;
                    panelinfoseguimiento.Visible = true;
                }                
            }*/
           }

        private void ckasignadas_CheckStateChanged(object sender, EventArgs e)
        {
            if(ckasignadas.Checked==true)
            {
                dptfechadist.Enabled = true;
                load_distibuidas();
            }
            else
            {
                dptfechadist.Enabled = false;
                load_pendientes();
            }
        }

        private void dptfechadist_ValueChanged(object sender, EventArgs e)
        {
            //load_distibuidas();
        }

        private void btnaddentregas_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                /*int resul = modulo.verifica_codigoXCD(txtcodigo.Text);
                if (resul == 0)
                {*/
                int resul_estado;
                    //modulo.verificar_estado_anterior(txtcodigo.Text, "A", "'C','B'");
                    //if (resul_estado == 0)
                    //{
                        if(cbincidencias.SelectedValue.ToString()=="5" || cbincidencias.SelectedValue.ToString()=="8")
                        {
                    acceso = new conexion();
                            /*buscamos que no existacon el estadod evoluciones*/
                            DataTable dt_resul = acceso.buscar(
                                "select * from  ",
                                "PE_claro pc ",
                                "where pc.codigo='" + txtcodigo.Text.Trim()+"' and not exists(select * from seguimiento_claro scc where scc.cod_envio='"+txtcodigo.Text+"' and id_estado in ('B','C'))");
                            if(dt_resul.Rows.Count>0)
                            {
                        /*Insertamos el acontecimiento*/
                        acceso = new conexion();
                        bool resul_insert = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,incidencia) " +
                            "values('" + txtcodigo.Text.Trim() + "','C',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','" + cbincidencias.SelectedValue + "')"
                            );
                        if (resul_insert == true)
                        {
                            hilodistribucion.RunWorkerAsync(2);
                            frmwork = new frmworking();
                            frmwork.ShowDialog();
                            //load_entrega_fallida();
                            //cbincidencias.SelectedIndex = 0;
                            cbopciones.SelectedIndex = 2;
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
                        MessageBoxAdv.Show("Esta factura ya fue grabada como entrega efectica o como entrega fallida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                        }
                        else if (cbincidencias.SelectedValue.ToString() == "1")
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("Seleccione una incidencia valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cbincidencias.Focus();
                            return;
                            /*Insertamos el acontecimiento*/
                            /*acceso = new conexion();
                            bool resul_insert = acceso.insertar(
                                "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro) " +
                                "values('" + txtcodigo.Text + "','B',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "')"
                                );
                            if (resul_insert == true)
                            {
                                load_entregadas();
                                txtcodigo.SelectionStart = 0;
                                txtcodigo.SelectionLength = txtcodigo.Text.Length;
                                txtcodigo.Focus();
                            }
                            else
                            {
                                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                                MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }*/
                        }
                        else if(cbincidencias.SelectedValue.ToString() == "6")
                        {
                        //MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        //MessageBoxAdv.Show("Seleccione una incidencia valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //cbincidencias.Focus();
                        //return;
                        resul_estado = modulo.verificar_estado_anterior(txtcodigo.Text.Trim(), "A", "'C','B','F'");
                        if (resul_estado == 0)
                        {
                            /*Insertamos el acontecimiento*/
                            acceso = new conexion();
                            bool resul_insert = acceso.insertar(
                                "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,incidencia) " +
                                "values('" + txtcodigo.Text.Trim() + "','F',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','" + cbincidencias.SelectedValue + "')"
                                );
                            if (resul_insert == true)
                            {
                            /*load_distibuidas();*/
                            hilodistribucion.RunWorkerAsync(0);
                            frmwork = new frmworking();
                            frmwork.ShowDialog();
                            //cbincidencias.SelectedIndex = 0;
                            cbopciones.SelectedIndex = 0;
                                txtcodigo.SelectionStart = 0;
                                txtcodigo.SelectionLength = txtcodigo.Text.Length;
                                txtcodigo.Focus();
                            }
                            else
                            {
                                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                                MessageBoxAdv.Show("No se pudo agregar el evento, intentarlo de nuevo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtcodigo.SelectionStart = 0;
                                txtcodigo.SelectionLength = txtcodigo.Text.Length;
                                txtcodigo.Focus();
                                return;
                            }
                        }
                        else if (resul_estado == 1)
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No es posible grabar la factura como pendiente esto puede ser causado por las siguientes razones: \r\n -El evento ya fue agregado. \r\n -El codigo ingresado no existe. \r\n -La factura ya fue marcada como entrega efectiva o fallida.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (resul_estado == 2)
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }                        
                    }
                    else
                    {
                        resul_estado = modulo.verificar_estado_anterior(txtcodigo.Text.Trim(), "A", "'C','B'");
                        if (resul_estado == 0)
                        {
                            /*Insertamos el acontecimiento*/
                            acceso = new conexion();
                            bool resul_insert = acceso.insertar(
                                "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro,incidencia) " +
                                "values('" + txtcodigo.Text.Trim() + "','C',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "','" + cbincidencias.SelectedValue + "')"
                                );
                            if (resul_insert == true)
                            {
                            hilodistribucion.RunWorkerAsync(2);
                            frmwork = new frmworking();
                            frmwork.ShowDialog();
                            /*load_entrega_fallida();*/
                            //cbincidencias.SelectedIndex = 0;
                            cbopciones.SelectedIndex = 2;
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
                        else if (resul_estado == 1)
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No es posible grabar la entrega fallida del envio esto puede ser causado por las siguientes razones: \r\n -El evento ya fue agregado por otro usuario. \r\n -El codigo ingresado no existe. \r\n -La factura ya fue marcada como entrega efectiva.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (resul_estado == 2)
                        {
                            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                            MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }                       
                }                        
                    //}
                    /*else if (resul_estado == 1)
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No es posible grabar la entrega fallida del envio esto puede ser causado por las siguientes razones: \r\n -El evento ya fue agregado por otro usuario. \r\n -El codigo ingresado no existe. \r\n -La factura ya fue marcada como entrega efectiva. \r\n la factura esta marcada como pendiente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (resul_estado == 2)
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }*/
                //}
                /*else if (resul == 1)
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("Codigo Invalido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("No se pudo establecer conexión con la base de datos, intentarlo mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Ingrese el codigo", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnmostrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnexport_Click(object sender, EventArgs e)
        {

            if (dgvlistprevia.Visible != false)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Archivos de Excel (*.xls)|*.xls"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
                sv.InitialDirectory = @"C:\";
                sv.Title = "Seleccione la direccion donde sera creado el archivo";//le damos un titulo a la ventana
                sv.FileName = nombre_file;

                if (sv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GroupingGridExcelConverterControl converter = new GroupingGridExcelConverterControl();
                    // Export the contents of the Grid to Excel
                    dgvlistprevia.TableDescriptor.GroupedColumns = null;
                    converter.GroupingGridToExcel(dgvlistprevia,sv.FileName, ConverterOptions.Visible);
                    dgvlistprevia.Visible = false;
                    //dgvlistprevia.DataSource = null;
                    panelinfoclasificacion.Visible = true;
                    lbruta.Text = "------------";
                    cbhoja.Items.Clear();                    
                }
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No hay información para exportar","Sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbopciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbopciones.SelectedIndex==0)
            {
                //load_distibuidas();
                ckviewasignadas.Visible = true;
                btnaddentregadas.Visible = true;
                btneliminar.Visible = true;
                hilodistribucion.RunWorkerAsync(0);
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
            else if(cbopciones.SelectedIndex == 1)
            {
                //load_entregadas();
                ckviewasignadas.Visible = false;
                btnaddentregadas.Visible = false;
                btneliminar.Visible = false;
                hilodistribucion.RunWorkerAsync(1);
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
            else if (cbopciones.SelectedIndex == 2)
            {
                load_entrega_fallida();
                ckviewasignadas.Visible = false;
                btnaddentregadas.Visible = false;
                btneliminar.Visible = false;
                hilodistribucion.RunWorkerAsync(2);
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
        }

        private void dptfechaseguimiento_ValueChanged(object sender, EventArgs e)
        {
            if (cbopciones.SelectedIndex == 0)
            {                
                load_distibuidas(dptfechaseguimiento.Value);
                //load_entregadas();
            }
            else if(cbopciones.SelectedIndex == 2)
            {
                load_entrega_fallida();
            }
        }

        private void btnaddentregafail_Click(object sender, EventArgs e)
        {
            frmadmitirreen frm_noentre = new frmadmitirreen();
            frm_noentre.ShowDialog();
            if(cbopciones.SelectedIndex==0)
            {
                load_entregadas();
            }
            else
            {
                load_entrega_fallida();
            }
        }

        private void dgvdistribucion_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            
        }

        private void imprimirPODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmimprimirpod frmrpt_pod = new frmimprimirpod();
            frmrpt_pod.ShowDialog();
        }

        private void btnentregasmasi_Click(object sender, EventArgs e)
        {
            
        }

        private void imprimirDistribuidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrpt_master rpt_master = new frmrpt_master();
            rpt_master.Show();
        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                btnaddentregas_Click(null, null);
            }
        }

        private void cbincidencias_Enter(object sender, EventArgs e)
        {
            cbincidencias.DroppedDown = true;
        }

        private void cbincidencias_Leave(object sender, EventArgs e)
        {
            cbincidencias.DroppedDown = false;
        }

        private void cbincidencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab || (Keys)e.KeyChar == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            /*lbusername.Text = "";
            lbcentro.Text = "";
            frmlogin frmlog = new frmlogin();
            frmlog.ShowDialog(this);
            lbcentro.Text = modulo.sucursal;
            lbusername.Text = modulo.user;*/
            Application.Restart();
        }

        private void btnconsultar_envio_Click(object sender, EventArgs e)
        {
            frmrastreo frmras = new frmrastreo();
            frmras.Show();
        }

        private void btnconf_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvseguimiento_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvseguimiento.TableDescriptor.AllowEdit = false;
            this.dgvseguimiento.TableDescriptor.AllowNew = false;
            this.dgvseguimiento.TableDescriptor.AllowRemove = false;
            this.dgvseguimiento.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor parentColumn in this.dgvseguimiento.TableDescriptor.Columns)
            {
                parentColumn.AllowFilter = true;
            }
            this.dgvseguimiento.TableDescriptor.Appearance.FilterBarCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete;
        }

        private void btnreen_Click(object sender, EventArgs e)
        {
            frmreencaminar frmreen = new frmreencaminar();
            frmreen.ShowDialog();
            //load_distibuidas();
            hiloasignar.RunWorkerAsync();
            frmwork = new frmworking();
            frmwork.ShowDialog();
            //load_pendientes();
        }

        private void btnadmitir_Click(object sender, EventArgs e)
        {
            frmadmitirreen frmadmitir = new frmadmitirreen();
            frmadmitir.ShowDialog();
            hiloasignar.RunWorkerAsync();
            frmwork = new frmworking();
            frmwork.ShowDialog();
            //load_pendientes();
            //load_distibuidas();
        }

        private void ckviewasignadas_CheckStateChanged(object sender, EventArgs e)
        {
            if(ckviewasignadas.Checked==true)
            {
                //load_all_asignadas();
                btneliminar.Enabled = false;
                panelleyendaslocal.Visible = true;
                btnaddentregadas.Enabled = false;
                hilodistribucion.RunWorkerAsync("0");
                frmwork = new frmworking();
                frmwork.Show();
                //Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_fallida = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                ////Conditional Formatting applied through designer
                //format_entrega_fallida.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(75)))), ((int)(((byte)(75))))));
                //format_entrega_fallida.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
                ////gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                //// Applies format by checking the value ‘Row1’
                //format_entrega_fallida.Expression = "[Estado]  LIKE \'C\'";
                //format_entrega_fallida.Name = "ConditionalFormat 1";

                //Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_efec = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                ////Conditional Formatting applied through designer
                //format_entrega_efec.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(55))))));
                //format_entrega_efec.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
                ////gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                //// Applies format by checking the value ‘Row1’
                //format_entrega_efec.Expression = "[Estado]  LIKE \'B\'";
                //format_entrega_efec.Name = "ConditionalFormat 2";

                //Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_asignadas = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                ////Conditional Formatting applied through designer
                //format_asignadas.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(240)))), ((int)(((byte)(255))))));
                //format_asignadas.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                ////gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                //// Applies format by checking the value ‘Row1’
                //format_asignadas.Expression = "[Estado]  LIKE \'A\'";
                //format_asignadas.Name = "ConditionalFormat 3";

                //Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_pendiente = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                ////Conditional Formatting applied through designer
                //format_pendiente.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(219))))));
                //format_pendiente.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                ////gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                //// Applies format by checking the value ‘Row1’
                //format_pendiente.Expression = "[Estado]  LIKE \'F\'";
                //format_pendiente.Name = "ConditionalFormat 4";

                //dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_entrega_fallida);
                //dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_entrega_efec);
                //dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_asignadas);
                //dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_pendiente);

                //dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Estado");
            }
            else
            {
                //load_distibuidas();
                btneliminar.Enabled = true;
                panelleyendaslocal.Visible = false;
                btnaddentregadas.Enabled = true;
                hilodistribucion.RunWorkerAsync("0");
                frmwork = new frmworking();
                frmwork.Show();
            }
        }

        private void cbopcioncys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbopcioncys.SelectedIndex==0)
            {
                btnimport.Visible = false;
                panelindicadores.Visible = true;
                hiloseguimiento.RunWorkerAsync("0");
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
            else if(cbopcioncys.SelectedIndex==1)
            {
                btnimport.Visible = true;
                panelindicadores.Visible = false;
                hiloseguimiento.RunWorkerAsync("1");
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
        }

        private void btnguardarlistaf_Click(object sender, EventArgs e)
        {
            if (txtimposicion.Text!="" && dt_listafinal!=null)
            {
                hilolistafinal.RunWorkerAsync();
                trabajando = new frmworking();
                trabajando.ShowDialog();
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Verifique que el numero de imposición haya sido ingresado o que haya registros disponibles para agregar","Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabdistribucion_Enter(object sender, EventArgs e)
        {
            timer.Stop();
            hiloasignar.RunWorkerAsync();
            frmwork = new frmworking();
            frmwork.ShowDialog();
            /*obtenemos los carteros por oficina postal*/
            /*acceso = new conexion();
            DataTable dtcartero = acceso.buscar("select id_cartero,Nombres from ", "cartero", " where id_centro='" + modulo.id_sucursal + "'");
            if (dtcartero != null)
            {
                cbcarteros.DataSource = dtcartero;
                cbcarteros.DisplayMember = "Nombres";
                cbcarteros.ValueMember = "id_cartero";
                load_pendientes();
                //load_distibuidas();
                cbcarteros.Focus();
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No se pudo conectar con la base de datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlAdv1.SelectedIndex = 0;
                return;
            }*/
        }

        private void tabseguimiento_Enter(object sender, EventArgs e)
        {
            timer.Stop();
           
            //cbopciones.SelectedIndex = 0;  
            ckviewasignadas.Visible = true;
            btnaddentregadas.Visible = true;
            btneliminar.Visible = true;
            hilodistribucion.RunWorkerAsync("0");
            frmwork = new frmworking();
            frmwork.ShowDialog();

            /*cargamos las incidencias*/
            acceso = new conexion();
            DataTable dt_incidencias = acceso.buscar("select * from ", "incidencia_claro", "");
            cbincidencias.DataSource = dt_incidencias;
            cbincidencias.ValueMember = "id_incidencia";
            cbincidencias.DisplayMember = "incidencia";
            //cbincidencias.Focus();
            //cbopciones.SelectedIndex = 0;
            //txtcodigo.Focus();
        }

        private void pintar_segui()
        {            
            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_fallida = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
            //Conditional Formatting applied through designer
            format_entrega_fallida.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(219))))));
            format_entrega_fallida.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
            // Applies format by checking the value ‘Row1’
            format_entrega_fallida.Expression = "[Estado]  LIKE \'C\'";
            format_entrega_fallida.Name = "ConditionalFormat 1";

            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_efec = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
            //Conditional Formatting applied through designer
            format_entrega_efec.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(55))))));
            format_entrega_efec.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
            // Applies format by checking the value ‘Row1’
            format_entrega_efec.Expression = "[Estado]  LIKE \'B\'";
            format_entrega_efec.Name = "ConditionalFormat 2";

            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_asignadas = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
            //Conditional Formatting applied through designer
            format_asignadas.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(240)))), ((int)(((byte)(255))))));
            format_asignadas.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
            // Applies format by checking the value ‘Row1’
            format_asignadas.Expression = "[Estado]  LIKE \'A\'";
            format_asignadas.Name = "ConditionalFormat 3";

            dgvcysegui.TableDescriptor.ConditionalFormats.Add(format_entrega_fallida);
            dgvcysegui.TableDescriptor.ConditionalFormats.Add(format_entrega_efec);
            dgvcysegui.TableDescriptor.ConditionalFormats.Add(format_asignadas);

            dgvcysegui.TableDescriptor.VisibleColumns.Remove("Estado");
        }

        Timer timer=new Timer();
        
        private void tabPageAdv6_Enter(object sender, EventArgs e)
        {
            /*cargamos la lista que vera control y seguimiento*/
            //cbopcioncys.SelectedIndex = 0;           
            timer.Interval = 30000;
            /*activamos timer que refresca la tabla*/
            timer.Tick += delegate (object s, EventArgs ee)
            {
                if (cbopcioncys.SelectedIndex == 0)
                {
                    ((Timer)s).Stop();
                    //cargar_segui();
                    hiloseguimiento.RunWorkerAsync("0");
                    frmwork = new frmworking();
                    frmwork.ShowDialog();
                }
                else if(cbopcioncys.SelectedIndex == 1)
                {
                    ((Timer)s).Stop();
                    //load_View_rezagos();
                    hiloseguimiento.RunWorkerAsync("1");
                    frmwork = new frmworking();
                    frmwork.ShowDialog();
                }
            };
            timer.Start();
            hiloseguimiento.RunWorkerAsync("0");
            frmwork = new frmworking();
            frmwork.ShowDialog();
        }

        

        private void dgvcysegui_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvcysegui.TableDescriptor.AllowEdit = false;
            this.dgvcysegui.TableDescriptor.AllowNew = false;
            this.dgvcysegui.TableDescriptor.AllowRemove = false;
            this.dgvcysegui.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor parentColumn in this.dgvcysegui.TableDescriptor.Columns)
            {
                parentColumn.AllowFilter = true;
            }
            this.dgvcysegui.TableDescriptor.Appearance.FilterBarCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete;

        }

        private void dgvdistribucion_DataSourceChanged(object sender, EventArgs e)
        {
            this.dgvdistribucion.TableDescriptor.AllowEdit = false;
            this.dgvdistribucion.TableDescriptor.AllowNew = false;
            this.dgvdistribucion.TableDescriptor.AllowRemove = false;
            this.dgvdistribucion.TopLevelGroupOptions.ShowFilterBar = true;
            foreach (GridColumnDescriptor parentColumn in this.dgvdistribucion.TableDescriptor.Columns)
            {
                parentColumn.AllowFilter = true;
            }
            this.dgvdistribucion.TableDescriptor.Appearance.FilterBarCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete;
        }

        private void buttonAdv8_Click(object sender, EventArgs e)
        {
            if(dgvseguimiento.Table.Records.Count==0)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No hay registros para procesar.", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
            DialogResult resul = MessageBoxAdv.Show("Esta acción Marcara todos los registros de la lista como ENTREGA EFECTIVA, ¿Esta seguro de Continuar?","Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resul==DialogResult.No)
            {
                return;
            }
            /*rrecorremos el datatable que contiene las facturas*/
            //for(int fila=0; fila<DT_distibuidas.Rows.Count;fila++)
            for(int fila=0; fila < dgvseguimiento.Table.FilteredRecords.Count; fila++)
            {
                //if(DT_distibuidas.Rows[fila]["id_estado"].ToString()=="A")
                if(dgvseguimiento.Table.FilteredRecords[fila]["id_estado"].ToString()=="A")
                {
                    /*int resul_estado = modulo.verificar_estado_anterior(txtcodigo.Text, "A", "'C','B'");
                    if (resul_estado == 0)
                    {*/
                        /*Insertamos el acontecimiento*/
                        acceso = new conexion();
                        bool resul_insert = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro) " +
                            "values('" + dgvseguimiento.Table.FilteredRecords[fila]["Codigo"].ToString() + "','B',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "')"
                            );
                        /*if (resul_insert == true)
                        {
                            dgvseguimiento.Table.Records[fila].Delete();
                            //DT_distibuidas.Rows.RemoveAt(fila);
                            fila--;
                        }*/
                    //}
                } 
                else if (dgvseguimiento.Table.FilteredRecords[fila]["id_estado"].ToString() == "F")
                {
                    /*verificamos que el pendiente sea del dia anterior*/
                    DateTime fecha1 = Convert.ToDateTime(dgvseguimiento.Table.FilteredRecords[fila]["Fecha"].ToString());
                    DateTime fecha2 = Convert.ToDateTime(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                    if (fecha1 < fecha2 )
                    {
                        acceso = new conexion();
                        bool resul_insert = acceso.insertar(
                            "insert into seguimiento_claro(cod_envio,id_estado,fecha,nombreuser,id_centro) " +
                            "values('" + dgvseguimiento.Table.FilteredRecords[fila]["Codigo"].ToString() + "','B',getdate(),'" + modulo.user + "','" + modulo.id_sucursal + "')"
                         ); 
                    }                   
                }
           }
            /*load_distibuidas();*/
            hilodistribucion.RunWorkerAsync("0");
            frmwork = new frmworking();
            frmwork.ShowDialog();
        }

        private void tablistafinal_Enter(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void tablistaprevia_Enter(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void tabinicio_Enter(object sender, EventArgs e)
        {
            timer.Stop();
        }


        public void crear_excel(string ruta, DataTable dt)
        {
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Hoja1");
                    wb.SaveAs(ruta);
                    MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                    MessageBoxAdv.Show("El archivo se creo correctamente","Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show(ex.ToString());
            }
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            if (dgvcysegui.Table.GetRecordCount()>0)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Archivos de Excel (*.xlsx;*.xls)|*.xlsx;*.xls"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel
                sv.InitialDirectory = @"C:\";
                sv.Title = "Seleccione la direccion donde sera creado el archivo";//le damos un titulo a la ventana
                if (sv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataTable dt_list = new DataTable();
                    DataView dv = (DataView)(dgvcysegui.DataSource);
                    dt_list = dv.ToTable();
                    //DataTable dt_list = (DataTable)dgvcysegui.DataSource;
                    crear_excel(sv.FileName, dt_list);
                }
           }
            else
            {
                MessageBox.Show("No hay informacion disponible para exportar", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            frmcierres frmcierre = new frmcierres();
            frmcierre.ShowDialog();
        }

        private void txtimposicion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btneliminar_Click_2(object sender, EventArgs e)
        {
            var seleccion = dgvseguimiento.Table.SelectedRecords;
            if (seleccion.Count > 0)
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                DialogResult resul_dialog = MessageBoxAdv.Show("Esta acción anulara la asignación de la factura, ¿Esta seguro de continuar?", "Sistemas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resul_dialog == DialogResult.No)
                {
                    return;
                }
                //int contador=0;
                foreach (var item in seleccion)
                {
                    conexion acceso = new conexion();
                    string codigo = item.Record["Codigo"].ToString();
                    bool resul = acceso.insertar("delete seguimiento_claro where cod_envio='" + codigo + "' and id_estado='A' and id_centro='" + modulo.id_sucursal + "' and not exists(select * from seguimiento_claro sc where sc.id_centro='"+ modulo.id_sucursal +"' and sc.id_estado in ('F') and sc.cod_envio='"+ codigo + "')");
                    if (resul == true)
                    {
                        //load_distibuidas();
                        hilodistribucion.RunWorkerAsync("0");
                        frmwork = new frmworking();
                        frmwork.ShowDialog();
                    }
                    else
                    {
                        MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                        MessageBoxAdv.Show("No se puede anular la asignación porque esta factura esta marcada como pendiente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        //contador++;
                        
                    //load_pendientes();
                }
                /*if(contador== seleccion.Count)
                {
                    
                }*/
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Seleccione el registro que sera anulado", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnsugerencia_Click(object sender, EventArgs e)
        {
            frmsugerencias frmsuge = new frmsugerencias(cbcarteros.SelectedValue.ToString(), cbcarteros.Text);
            frmsuge.ShowDialog();
            hiloasignar.RunWorkerAsync();
            frmwork = new frmworking();
            frmwork.ShowDialog();
        }

        private void dptfecha1_ValueChanged(object sender, EventArgs e)
        {
            if(cbopciones.SelectedIndex==0)
            {
                /*load_distibuidas();*/
                hilodistribucion.RunWorkerAsync("0");
                frmwork = new frmworking();
                frmwork.ShowDialog();
               
            }
            else if(cbopciones.SelectedIndex==1)
            {
                hilodistribucion.RunWorkerAsync("1");
                frmwork = new frmworking();
                frmwork.ShowDialog();
                // load_entregadas();
            }
            else if(cbopciones.SelectedIndex==2)
            {
                hilodistribucion.RunWorkerAsync("2");
                frmwork = new frmworking();
                frmwork.ShowDialog();
                //load_entrega_fallida();
            }
        }

        private void dptfecha2_ValueChanged(object sender, EventArgs e)
        {
            if (cbopciones.SelectedIndex == 0)
            {
                /*load_distibuidas();*/
                hilodistribucion.RunWorkerAsync("0");
                frmwork = new frmworking();
                frmwork.ShowDialog();
            }
            else if (cbopciones.SelectedIndex == 1)
            {
                hilodistribucion.RunWorkerAsync("1");
                frmwork = new frmworking();
                frmwork.ShowDialog();
                // load_entregadas();
            }
            else if (cbopciones.SelectedIndex == 2)
            {
                hilodistribucion.RunWorkerAsync("2");
                frmwork = new frmworking();
                frmwork.ShowDialog();
                //load_entrega_fallida();
            }
        }


        private void hiloasignar_DoWork(object sender, DoWorkEventArgs e)
        {
            acceso = new conexion();
            DataTable dtcartero = acceso.buscar("select id_cartero,Nombres from ", "cartero", " where id_centro='" + modulo.id_sucursal + "'");
            e.Result = dtcartero;
            load_pendientes();
            /*if (dtcartero != null)
            {
                cbcarteros.DataSource = dtcartero;
                cbcarteros.DisplayMember = "Nombres";
                cbcarteros.ValueMember = "id_cartero";
               
                //load_distibuidas();
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("No se pudo conectar con la base de datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControlAdv1.SelectedIndex = 0;
                return;
            }*/
        }

        private void hiloasignar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dtcartero = (DataTable)e.Result;
            if (dtcartero != null)
           {
               cbcarteros.DataSource = dtcartero;
               cbcarteros.DisplayMember = "Nombres";
               cbcarteros.ValueMember = "id_cartero";

                if (Dt_pendientesXdistribuir != null)
                {
                    if (Dt_pendientesXdistribuir.Rows.Count > 0)
                    {
                        dgvdistribucion.TableDescriptor.GroupedColumns = null;
                        dgvdistribucion.DataSource = Dt_pendientesXdistribuir.AsDataView();
                        dgvdistribucion.TableDescriptor.GroupedColumns.Add("Ciclo");
                        dgvdistribucion.TableDescriptor.VisibleColumns.Remove("Ciclo");
                        dgvdistribucion.Table.ExpandAllGroups();
                        panelinfodistribucion.Visible = false;
                        dgvdistribucion.Visible = true;
                    }
                    else
                    {
                        dgvdistribucion.DataSource = Dt_pendientesXdistribuir.AsDataView();
                        panelinfodistribucion.Visible = true;
                        dgvdistribucion.Visible = false;
                    }
                }

                //load_pendientes();
                //load_distibuidas();
            }
           else
           {
               MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
               MessageBoxAdv.Show("No se pudo conectar con la base de datos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
               tabControlAdv1.SelectedIndex = 0;
               return;
           }
           frmwork.Close();           
           cbcarteros.Focus();
        }

        private void hilodistribucion_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt_result=new DataTable();
            string opcion = e.Argument.ToString();
            if (opcion == "0")
            {               
                if (ckviewasignadas.Checked == true)
                {
                    dt_result=load_all_asignadas();

                }
                else
                {
                    dt_result= load_distibuidas();
                }
            }
            else if(opcion=="1")
            {
                dt_result=load_entregadas();
            }
            else if(opcion=="2")
            {
                dt_result=load_entrega_fallida();
            }
            e.Result = dt_result;
        }

        private void hilodistribucion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dt_result = (DataTable)e.Result;
            if (cbopciones.SelectedIndex == 0)
            {
                if (ckviewasignadas.Checked == true)
                {
                    if (dt_result != null)
                    {
                        if (dt_result.Rows.Count > 0)
                        {
                            dgvseguimiento.TableDescriptor.GroupedColumns = null;
                            dgvseguimiento.DataSource = null;
                            dgvseguimiento.DataSource = dt_result.AsDataView();
                            dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                            dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                            //dgvseguimiento.TableDescriptor.GroupedColumns.Add("ciclo");
                            //dgvseguimiento.TableDescriptor.VisibleColumns.Remove("ciclo");
                            //dgvseguimiento.Table.ExpandAllGroups();
                            //dgvseguimiento.TableDescriptor.SortedColumns.Add("Estado", ListSortDirection.Ascending);
                            //dgvcysegui.Table.ExpandAllGroups();
                            /*expandimos los grupos primarios del grid*/
                            for (int grupo = 0; grupo < dgvseguimiento.Table.TopLevelGroup.Groups.Count; grupo++)
                            {
                                dgvseguimiento.Table.TopLevelGroup.Groups[grupo].IsExpanded = true;
                            }
                            dgvseguimiento.Visible = true;
                            panelinfoseguimiento.Visible = false;
                            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_fallida = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                            //Conditional Formatting applied through designer
                            format_entrega_fallida.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(75)))), ((int)(((byte)(75))))));
                            format_entrega_fallida.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
                            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                            // Applies format by checking the value ‘Row1’
                            format_entrega_fallida.Expression = "[Estado]  LIKE \'C\'";
                            format_entrega_fallida.Name = "ConditionalFormat 1";

                            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_entrega_efec = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                            //Conditional Formatting applied through designer
                            format_entrega_efec.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(138)))), ((int)(((byte)(55))))));
                            format_entrega_efec.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White;
                            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                            // Applies format by checking the value ‘Row1’
                            format_entrega_efec.Expression = "[Estado]  LIKE \'B\'";
                            format_entrega_efec.Name = "ConditionalFormat 2";

                            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_asignadas = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                            //Conditional Formatting applied through designer
                            format_asignadas.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(240)))), ((int)(((byte)(255))))));
                            format_asignadas.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                            // Applies format by checking the value ‘Row1’
                            format_asignadas.Expression = "[Estado]  LIKE \'A\'";
                            format_asignadas.Name = "ConditionalFormat 3";

                            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_pendiente = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                            //Conditional Formatting applied through designer
                            format_pendiente.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(219))))));
                            format_pendiente.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                            // Applies format by checking the value ‘Row1’
                            format_pendiente.Expression = "[Estado]  LIKE \'F\'";
                            format_pendiente.Name = "ConditionalFormat 4";

                            dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_entrega_fallida);
                            dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_entrega_efec);
                            dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_asignadas);
                            dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_pendiente);

                            dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Estado");
                        }
                        else
                        {
                            dgvseguimiento.DataSource = dt_result.AsDataView();
                            dgvseguimiento.Visible = false;
                            panelinfoseguimiento.Visible = true;
                        }
                    }
                }
                else
                {
                    if (dt_result != null)
                    {
                        if (dt_result.Rows.Count > 0)
                        {
                            dgvseguimiento.DataSource = null;
                            dgvseguimiento.TableDescriptor.GroupedColumns = null;
                            dgvseguimiento.DataSource = dt_result.AsDataView();
                            dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                            dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                            //dgvdistribucion.TableDescriptor.GroupedColumns.Add("ciclo");
                            //dgvdistribucion.TableDescriptor.VisibleColumns.Remove("ciclo");
                            /*GridColumnDescriptor EmpName = new GridColumnDescriptor();
                            EmpName.MappingName = "Revertir";
                            dgvseguimiento.TableDescriptor.Columns.Add(EmpName);*/
                            //dgvseguimiento.Table.ExpandAllGroups();
                            dgvseguimiento.Visible = true;
                            Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor format_Pendientes = new Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor();
                            //Conditional Formatting applied through designer
                            format_Pendientes.Appearance.AnyRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(214)))), ((int)(((byte)(219))))));
                            format_Pendientes.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black;
                            //gridConditionalFormatDescriptor3.Appearance.AnyRecordFieldCell.Enabled = false;
                            // Applies format by checking the value ‘Row1’
                            format_Pendientes.Expression = "[id_estado]  LIKE \'F\'";
                            format_Pendientes.Name = "ConditionalFormat 1";
                            dgvseguimiento.TableDescriptor.ConditionalFormats.Add(format_Pendientes);
                            dgvseguimiento.TableDescriptor.VisibleColumns.Remove("id_estado");
                            panelinfoseguimiento.Visible = false;
                        }
                        else
                        {
                            dgvseguimiento.DataSource = dt_result.AsDataView();
                            dgvseguimiento.Visible = false;
                            panelinfoseguimiento.Visible = true;
                        }
                    }
                }
            }
            else if (cbopciones.SelectedIndex == 1)
            {
                if (dt_result != null)
                {
                if (dt_result.Rows.Count > 0)
                {
                    dgvseguimiento.DataSource = null;
                    dgvseguimiento.DataSource = dt_result.AsDataView();
                    panelinfoseguimiento.Visible = false;
                    dgvseguimiento.Visible = true;
                }
                else
                {
                    dgvseguimiento.DataSource = dt_result.AsDataView();
                    panelinfoseguimiento.Visible = true;
                    dgvseguimiento.Visible = false;
                }               
            }
            else
            {
                MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                MessageBoxAdv.Show("Error al conectar con la base de datos, intente mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            else if (cbopciones.SelectedIndex == 2)
            {
             if (dt_result != null)
             {
                 if (dt_result.Rows.Count > 0)
                 {
                     dgvseguimiento.TableDescriptor.GroupedColumns = null;
                     dgvseguimiento.DataSource = null;
                     dgvseguimiento.DataSource = dt_result.AsDataView();
                     //this.dgvseguimiento.TableDescriptor.AllowNew = false;
                     dgvseguimiento.TableDescriptor.GroupedColumns.Add("Cartero");
                     dgvseguimiento.TableDescriptor.VisibleColumns.Remove("Cartero");
                     dgvseguimiento.TableDescriptor.GroupedColumns.Add("ciclo");
                     dgvseguimiento.TableDescriptor.VisibleColumns.Remove("ciclo");                    
                     dgvseguimiento.Table.ExpandAllGroups();
                     panelinfoseguimiento.Visible = false;
                     dgvseguimiento.Visible = true;
                 }
                 else
                 {
                     dgvseguimiento.DataSource = dt_result.AsDataView();
                     panelinfoseguimiento.Visible = true;
                     dgvseguimiento.Visible = false; 
                 }

             }
             else
             {
                 MessageBoxAdv.MessageBoxStyle = MessageBoxAdv.Style.Metro;
                 MessageBoxAdv.Show("Error al conectar con la base de datos, intente mas tarde", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            }
            frmwork.Close();
        }

        private void hiloseguimiento_DoWork(object sender, DoWorkEventArgs e)
        {
            string argumento = e.Argument.ToString();
            DataTable resul = new DataTable();
            if(argumento=="0")
            {
              resul=load_View_seguimiento();
            }
            else if(argumento=="1")
            {
                resul = load_View_rezagos();
            }
            e.Result=resul;           
        }

        private void hiloseguimiento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable resul = (DataTable)e.Result;
            if(cbopcioncys.SelectedIndex==0)
            {
                if (resul != null)
                { 
                    if (resul.Rows.Count > 0)
                    {
                        //var grupo_select = dgvcysegui.TableDescriptor.GroupedColumns.GetEnumerator();
                        dgvcysegui.TableDescriptor.GroupedColumns = null;
                        dgvcysegui.DataSource = null;
                        dgvcysegui.DataSource = resul.AsDataView();
                        //dgvcysegui.TableDescriptor.GroupedColumns.Add("Fecha");
                        //dgvcysegui.TableDescriptor.VisibleColumns.Remove("fecha");
                        dgvcysegui.TableDescriptor.GroupedColumns.Add("Centro");
                        dgvcysegui.TableDescriptor.VisibleColumns.Remove("Centro");
                        dgvcysegui.TableDescriptor.GroupedColumns.Add("Cartero");
                        dgvcysegui.TableDescriptor.VisibleColumns.Remove("Cartero");
                        //dgvcysegui.TableDescriptor.GroupedColumns.Add("ciclo");
                        //dgvcysegui.TableDescriptor.VisibleColumns.Remove("ciclo");
                        dgvcysegui.TableDescriptor.SortedColumns.Add("Estado", ListSortDirection.Ascending);
                        //dgvcysegui.Table.ExpandAllGroups();
                        /*expandimos los grupos primarios del grid*/
                        for (int grupo = 0; grupo < dgvcysegui.Table.TopLevelGroup.Groups.Count; grupo++)
                        {
                            dgvcysegui.Table.TopLevelGroup.Groups[grupo].IsExpanded = true;
                        }
                        pintar_segui();
                    }
                    else
                    {
                        dgvcysegui.DataSource = resul.AsDataView();
                        dgvseguimiento.Visible = false;
                        panelinfoseguimiento.Visible = true;
                    }
                }
            }
            else if(cbopcioncys.SelectedIndex==1)
            {
                if (resul != null)
                {
                    if (resul.Rows.Count > 0)
                    {
                        dgvcysegui.TableDescriptor.GroupedColumns = null;
                        dgvcysegui.DataSource = null;
                        dgvcysegui.DataSource = resul.AsDataView();
                        dgvcysegui.TableDescriptor.GroupedColumns.Add("Fecha");

                        dgvcysegui.TableDescriptor.GroupedColumns.Add("Centro");

                        dgvcysegui.TableDescriptor.GroupedColumns.Add("Cartero");
                        dgvcysegui.TableDescriptor.VisibleColumns.Remove("Cartero");
                        dgvcysegui.TableDescriptor.GroupedColumns.Add("ciclo");
                        dgvcysegui.Table.ExpandAllGroups();
                        dgvcysegui.Visible = true;

                    }
                    else
                    {
                        dgvcysegui.DataSource = resul.AsDataView();
                    }
                }
            }
            frmwork.Close();
        }

        private void imageStreamer1_Click(object sender, EventArgs e)
        {

        }

        private void habilitar_opciones()
        {
            Syncfusion.Windows.Forms.Tools.TabPageAdv page0 = tabControlAdv1.TabPages[0];
            Syncfusion.Windows.Forms.Tools.TabPageAdv page1 = tabControlAdv1.TabPages[1];
            Syncfusion.Windows.Forms.Tools.TabPageAdv page2 = tabControlAdv1.TabPages[2];
            Syncfusion.Windows.Forms.Tools.TabPageAdv page3 = tabControlAdv1.TabPages[3];
            Syncfusion.Windows.Forms.Tools.TabPageAdv page4 = tabControlAdv1.TabPages[4];
            Syncfusion.Windows.Forms.Tools.TabPageAdv page5 = tabControlAdv1.TabPages[5];

            for (int tab = tabControlAdv1.TabPages.Count - 1; tab >= 0; tab--)
            {
                tabControlAdv1.TabPages.RemoveAt(tab);
            }
            tabControlAdv1.TabPages.Add(page0);
            imprimirPODToolStripMenuItem.Enabled = false;
            imprimirDistribuidasToolStripMenuItem.Enabled = false;


            for (int row = 0; row < modulo.roles_user.Rows.Count; row++)
            {
                if ((int)modulo.roles_user.Rows[row][0] == 4)
                {
                    //tabControlAdv1.TabPages.Add(page0);
                    tabControlAdv1.TabPages.Add(page1);
                    tabControlAdv1.TabPages.Add(page2);
                    tabControlAdv1.TabPages.Add(page3);
                    tabControlAdv1.TabPages.Add(page4);
                    tabControlAdv1.TabPages.Add(page5);
                    imprimirPODToolStripMenuItem.Enabled = true;
                    imprimirDistribuidasToolStripMenuItem.Enabled = true;
                }
                if ((int)modulo.roles_user.Rows[row][0] == 16)
                {
                    tabControlAdv1.TabPages.Add(page4);
                    imprimirDistribuidasToolStripMenuItem.Enabled = true;
                }
                if ((int)modulo.roles_user.Rows[row][0] == 17)
                {
                    tabControlAdv1.TabPages.Add(page3);
                    imprimirDistribuidasToolStripMenuItem.Enabled = true;
                }
                if ((int)modulo.roles_user.Rows[row][0] == 18)
                {
                    tabControlAdv1.TabPages.Add(page5);
                }
                if ((int)modulo.roles_user.Rows[row][0] == 14)
                {
                    tabControlAdv1.TabPages.Add(page1);
                }
                if ((int)modulo.roles_user.Rows[row][0] == 15)
                {
                    tabControlAdv1.TabPages.Add(page2);
                    imprimirPODToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += delegate (object s, EventArgs ee)
            {
                ((Timer)s).Stop();
                /*leemos los datos de conexion*/
                string[] configuracion = null;
                String line;
                try
                {
                    using (StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, "conexion.txt"), false))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            configuracion = line.Split(';');
                        }
                        modulo.server = configuracion[0];
                        modulo.database = configuracion[1];
                        modulo.user_server = configuracion[2];
                        modulo.pass_server = configuracion[3];
                        string ruta = "Data Source=" + configuracion[0] + "; Initial Catalog=" + configuracion[1] + "; user=" + configuracion[2] + "; password=" + configuracion[3];
                        conexion.ruta = ruta;
                        frmlogin login = new frmlogin();
                        login.ShowDialog(this);
                        if (modulo.user_config_log == true)
                        {
                            toolStripDropDownButton1.Enabled = false;
                            tabinicio.Enabled = false;
                        }
                        else
                        {
                            habilitar_opciones();
                            lbcentro.Text = modulo.sucursal;
                            lbusername.Text = modulo.user;
                            btnconf.Enabled = false;
                            tabinicio.Enabled = true;
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Error al leer la informacion de conexion al servidor");
                }

            };
            timer.Start();
            CheckForIllegalCrossThreadCalls = false;
            //dgvlistafinal.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            //dgvlistprevia.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            //dgvdistribucion.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            dgvlistafinal.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            dgvlistprevia.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            dgvlistafinal.TableOptions.AllowSortColumns = false;
            dgvdistribucion.TableOptions.AllowSortColumns = false;
            dgvdistribucion.TableOptions.ListBoxSelectionMode = SelectionMode.One;
            dgvseguimiento.TableOptions.ListBoxSelectionMode = SelectionMode.One;

            /*asignamos a los dtp la fecha del sistema*/
            //dptfechadist.Value = DateTime.Now;
            dptfechalistaf.Value = DateTime.Now;
            dptfechatope.Value = DateTime.Now;           
        }
    }
}
