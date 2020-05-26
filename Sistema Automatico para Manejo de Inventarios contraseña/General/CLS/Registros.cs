using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Registros
    {
        String _IdRegistro;
        String _IDUsuario;
        String _IDProducto;
        String _Accion;
        String _Cantidad;
        String _TiempoAccion;

        public string IdRegistro { get => _IdRegistro; set => _IdRegistro = value; }
        public string IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public string Accion { get => _Accion; set => _Accion = value; }
        public string Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public string TiempoAccion { get => _TiempoAccion; set => _TiempoAccion = value; }

        public Boolean Guardar()
        {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {

                Sentencia = "INSERT INTO Registros(IDUsuario, IDProducto, Accion, Cantidad, TiempoAccion) VALUES (";
                Sentencia += _IDUsuario + ",";
                Sentencia += _IDProducto + ",";
                Sentencia += "'" + _Accion + "',";
                Sentencia += _Cantidad + ",";
                Sentencia += "'"+ _TiempoAccion + "');";
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Guardado = true;
                }
                else
                {
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
                Sentencia = "UPDATE Registros SET ";
                Sentencia += "IDUsuario = "+_IDUsuario+", ";
                Sentencia += "IDProducto = "+_IDProducto+", ";
                Sentencia += "Accion = '"+_Accion+"', ";
                Sentencia += "Cantidad = "+_Cantidad+", ";
                Sentencia += "TiempoAccion = '" + _TiempoAccion + "'";
                Sentencia += " WHERE IdRegistro = "+_IdRegistro+";";
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
                Sentencia = "DELETE FROM registros";
                Sentencia += "WHERE IdRegistro = " + _IdRegistro + ";";
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
