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
                Empleados;";
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
        public static DataTable TODOS_LOS_REGISTROS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT 
                a.IdRegistro, b.Usuario, c.NombreProducto, a.Accion, a.Cantidad, a.TiempoAccion 
                FROM 
                Registros a, usuarios b, Productos c 
                WHERE 
                a.IDUsuario = b.IDUsuario 
                AND a.IDProducto = c.IDProducto;";
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
        public static DataTable TODAS_LAS_CLASIFICACIONES()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "SELECT IdClasificacion, Clasificacion FROM Clasificaciones;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_ALMACENAMIENTOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "SELECT IDAlmacenamiento, LugarAlmacenamiento FROM Almacenamientos;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_PEDIDOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT 
                a.IdPedido, b.NombreProducto, b.Estado as Estado_Prod, a.Cantidad, a.Estado as Estado_Ped, c.NombreProveedor, a.Fecha_de_pedido, a.TiempoPromedio 
                FROM 
                pedidos a, productos b, proveedores c 
                WHERE a.IDProducto = b.IDProducto AND a.IDProveedor = c.IDProveedor;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable TODOS_LOS_PROVEEDORES()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "SELECT IDProveedor, NombreProveedor FROM Proveedores;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable PERMISOS_DE_UN_ROL(String pIDRol)
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "select a.IDPermiso, a.IDOpcion, b.Opcion, a.IDRol FROM Permisos a, Opciones b WHERE a.IDOpcion = b.IDOpcion AND IDRol ="+pIDRol+";";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }
        public static DataTable ASIGNACIONES_DE_PERMISOS_SEGUN_IDROL(String pIDRol)
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT IDOpcion, Opcion, a.IDClasificacion, b.Clasificacion,
                IFNULL((SELECT IDPermiso FROM Permisos c WHERE c.IDRol = "+ pIDRol + @" AND c.IDOpcion = a.IDOpcion), 0) as 'IDPermiso',
                IF(IFNULL((SELECT IDPermiso FROM Permisos c WHERE c.IDRol = "+ pIDRol + @" AND c.IDOpcion = a.IDOpcion), 0)>0,1,0) as 'Asignado'
                FROM Opciones a, ClasificacionesSAMI b
                WHERE a.IDClasificacion = b.IDClasificacion;";
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
