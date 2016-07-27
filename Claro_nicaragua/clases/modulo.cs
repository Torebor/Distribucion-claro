using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Claro_nicaragua.clases
{
    public class modulo
    {
        public static string user,id_sucursal,sucursal, usrGlobal="usrinformatica", Passglobal="informatica123", server, database, user_server, pass_server;
        public static bool user_config_log=false;
        public static DataTable roles_user;

        public static int verificar_estado_anterior(string codigo,string id_estado_ant, string id_estado_new)
        {
            int result = 0;
            conexion acceso;
            acceso = new conexion();
            DataTable dt_estado_anterior = acceso.buscar(
                "select * from ",
                "seguimiento_claro ",
                "where id_estado in ('"+id_estado_ant+"') and not exists(select * from seguimiento_claro where id_estado in ("+id_estado_new+") and cod_envio='" + codigo + "' and id_centro='"+modulo.id_sucursal+"') and cod_envio='" + codigo + "'");
            /*DataTable dt_estado_anterior = acceso.buscar(
                "select * from ",
                "seguimiento_claro ",
                "where exists(select * from seguimiento_claro where id_estado in (" + id_estado_new + ") and cod_envio='" + codigo + "' and id_centro='" + modulo.id_sucursal + "') and cod_envio='" + codigo + "'");*/
            if (dt_estado_anterior != null)
            {
                if (dt_estado_anterior.Rows.Count == 0)
                {
                    result = 1;
                }
            }
            else
            {
                result = 2;
            }
            return result;

        }

        public static int verifica_codigoXCD(string codigo)
        {
            int result=0;
            conexion acceso;
            /*buscamos que el codigo de envio pertenesca al centro de distibucion logeado*/
            acceso = new conexion();
            DataTable cheking = acceso.buscar(
                "select * from ",
                "PE_claro inner join Barrio on PE_claro.IdBarrio= barrio.IdBarrio INNER JOIN Departamentos ON Barrio.IdDepto = Departamentos.IdDepto INNER JOIN Municipios ON Barrio.IdMunicipio = Municipios.IdMunicipio INNER JOIN OficinaPostal ON Barrio.IdOficinaPostal = OficinaPostal.IdCentro ",
                "WHERE ((PE_claro.codigo='" + codigo + "' and OficinaPostal.IdCentro='" + modulo.id_sucursal + "') or exists(select * from seguimiento_claro sc where sc.cod_envio='"+codigo+"' and sc.id_centro='"+modulo.id_sucursal+"') )"
                );
            if (cheking != null)
            {
                if (cheking.Rows.Count == 0)
                {
                    result = 1;
                }
            }
            else
            {
                result = 2;
            }
            return result;
        }
        
        public static int verificar_codigo(string codigo)
        {
            int result = 0;
            conexion acceso;
            /*buscamos que el codigo de envio pertenesca al centro de distibucion logeado*/
            acceso = new conexion();
            DataTable cheking = acceso.buscar(
                "select * from ",
                "PE_claro ",
                "WHERE  codigo='"+codigo+"'"
                );
            if (cheking != null)
            {
                if (cheking.Rows.Count == 0)
                {
                    result = 1;
                }
            }
            else
            {
                result = 2;
            }
            return result;
        } 
    }

}
