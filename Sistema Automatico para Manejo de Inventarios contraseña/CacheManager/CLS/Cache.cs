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
                Consulta = "SELECT IDRol, Rol FROM ROLES";
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
                a.NombreProducto, a.Estado, b.Clasificacion, a.Cantidad, c.LugarAlmacenamiento, a.Existencia, a.Precio 
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

        public static DataTable REPORTES_PRODUCTOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @"SELECT IDProducto, NombreProducto, 
                Estado, IdClasificacion, 
                Descripcion, Cantidad, 
                IDAlmacenamiento, Existencia 
                FROM productos ORDER BY NombreProducto ;";
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
                Consulta = @"SELECT a.IdPedido, b.NombreProveedor as Proveedor, a.Fecha_de_pedido as Fecha, a.TiempoPromedio as Tiempo, a.Costo, a.Estado
				FROM 
                pedidos a, proveedores b 
                WHERE a.IDProveedor = b.IDProveedor order by IdPedido;";
                Resultado = oConsulta.Consultar(Consulta);
            }
            catch
            {
                Resultado = new DataTable();
            }
            return Resultado;
        }

        public static DataTable REPORTES_PEDIDOS()
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = @" SELECT IdPedido, IDProducto,
                Cantidad, IDProveedor,
                Fecha_de_pedido, TiempoPromedio, Estado
                FROM pedidos ORDER BY Fecha_de_pedido;";
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

        public static DataTable TODOS_LOS_PEDIDOS_PRODUCTOS(String ID)
        {
            DataTable Resultado = new DataTable();
            String Consulta;
            DataManager.CLS.DBOperacion oConsulta = new DataManager.CLS.DBOperacion();
            try
            {
                Consulta = "SELECT b.NombreProducto, b.Estado, a.Cantidad FROM Pedidos_Productos a, Productos b WHERE a.IdProducto = b.IdProducto AND IdPedido = "+ID+";";
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
