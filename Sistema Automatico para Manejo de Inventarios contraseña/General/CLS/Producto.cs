using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Producto
    {
        //ATRIBUTOS

        String _IDProducto;
        String _NombreProducto;
        String _Estado;
        String _IdClasificacion;
        String _Descripcion;
        String _Cantidad;
        String _IDAlmacenamiento;
        String _Existencia;
        String _Precio;

        //PROPIEDADES

        public string IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public string NombreProducto { get => _NombreProducto; set => _NombreProducto = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string IdClasificacion { get => _IdClasificacion; set => _IdClasificacion = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string IDAlmacenamiento { get => _IDAlmacenamiento; set => _IDAlmacenamiento = value; }
        public string Existencia { get => _Existencia; set => _Existencia = value; }
        public string Precio { get => _Precio; set => _Precio = value; }

        //METODOS

        public Boolean Guardar() {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "INSERT INTO Productos(NombreProducto, Estado, IdClasificacion, Descripcion, Cantidad, IDAlmacenamiento, Existencia, Precio) VALUES(";
                Sentencia += "'" + _NombreProducto + "',";
                Sentencia += "'" + _Estado + "',";
                Sentencia += _IdClasificacion + ",";
                Sentencia += "'" + _Descripcion + "',";
                Sentencia += _Cantidad + ",";
                Sentencia += _IDAlmacenamiento + ",";
                Sentencia += "'" + _Existencia + "',";
                Sentencia += _Precio + ");";
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Guardado = true;
                    MessageBox.Show("Registro insertado correctamente","Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else {
                    Guardado = false;
                    MessageBox.Show("Registro no fue insertado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                Guardado = false;
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Guardado;
        }

        public Boolean Actualizar()
        {
            Boolean Actualizado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "UPDATE Productos SET ";
                Sentencia += "NombreProducto ='" + _NombreProducto + "',";
                Sentencia += "Estado ='" + _Estado + "',";
                Sentencia += "IdClasificacion =" + _IdClasificacion + ",";
                Sentencia += "Descripcion ='" + _Descripcion + "',";
                Sentencia += "Cantidad =" + _Cantidad + ",";
                Sentencia += "IDAlmacenamiento =" + _IDAlmacenamiento + ",";
                Sentencia += "Existencia ='" + _Existencia + "',";
                Sentencia += "Precio = "+_Precio;
                Sentencia += " WHERE IDProducto =" + _IDProducto + ";";
                String dato = Sentencia;
                if (Operacion.Actualizar(Sentencia) > 0)
                {
                    Actualizado = true;
                    MessageBox.Show("Registro actualizado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Actualizado = false;
                    MessageBox.Show("Registro no fue actualizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                Actualizado = false;
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Actualizado;
        }

        public Boolean Eliminar()
        {
            Boolean Eliminado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "DELETE FROM Productos ";
                Sentencia += "WHERE IDProducto =" + _IDProducto + ";";
                if (Operacion.Eliminar(Sentencia) > 0)
                {
                    Eliminado = true;
                    MessageBox.Show("Registro eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Eliminado = false;
                    MessageBox.Show("Registro no fue eliminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                Eliminado = false;
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Eliminado;
        }
    }
}