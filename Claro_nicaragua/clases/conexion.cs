using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Claro_nicaragua.clases
{
    class conexion
    {
        //public static string ruta = "Data Source=192.168.1.5;Initial Catalog=Pruebas_entrega; user=sicuser; password=sicuser123";
        public static string ruta;
        public SqlConnection con;
        private SqlCommand cmd;

        private void conectar()
        {
            con = new SqlConnection(ruta);
        }

        public conexion()
        {
            conectar();
        }

        /*metodo de actualizacion*/
        public Boolean actualizar(string cadena)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = cadena;
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /*metodo de insercion de imagen*/
        public Boolean insertar_imagen(string codigo, byte[] imagen)
        {
            con.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO pruebasE_Guardadas VALUES(@codigo,@foto,GETDATE())";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image).Value = imagen;
            cmd.Connection = con;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean insertar(string cadena)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = cadena;
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }            
        }
        /*metodo de busqueda*/
        public DataTable buscar(string cadena, string tabla, string condicion)
         {
             try
             {
                 DataSet ds = new DataSet();
                 SqlDataAdapter da;
                 DataTable dt;
                 string consulta = cadena + tabla + condicion;
                 con.Open();
                 da = new SqlDataAdapter(consulta, con);
                 da.Fill(ds);
                 con.Close();
                 dt = ds.Tables[0];
                 return (dt);
             }
             catch 
             {
                con.Close();
                return null;
             }
        }
    }
}
