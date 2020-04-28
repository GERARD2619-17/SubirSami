using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable TODOS_LOS_USUARIOS() {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT 
                a.IDUsuario, 
                a.Usuario, 
                a.Credencial, 
                a.IDRol,
                b.Rol,  
                a.IDEmpleado,
                CONCAT(c.Nombres,' ',c.Apellidos) as Empleado
                FROM 
                usuarios a, roles b, empleados c 
                WHERE a.IDRol=b.IDRol AND a.IDEmpleado=c.IDEmpleado;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_EMPLEADOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT
                IDEmpleado as ID,
                CONCAT(Nombres,' ',Apellidos) as Nombre,
                Genero
                FROM
                EMPLEADOS;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_ROLES()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "SELECT * FROM ROLES";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_PRODUCTOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT  
                a.NombreProducto, a.Estado, b.Clasificacion, a.Cantidad, c.LugarAlmacenamiento, a.Existencia 
                FROM 
                Productos a, Clasificaciones b, Almacenamientos c 
                WHERE 
                a.IdClasificacion = b.IdClasificacion 
                AND 
                a.IDAlmacenamiento = c.IDAlmacenamiento 
                ORDER BY 
                a.NombreProducto;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }

    }
}
