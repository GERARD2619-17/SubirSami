using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Pedidos
    {
        String _IdPedido;
        String _IDProveedor;
        String _Fecha_de_pedido;
        String _TiempoPromedio;
        String _Costo;
        String _Estado;

        public string IdPedido { get => _IdPedido; set => _IdPedido = value; }
        public string IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
        public string Fecha_de_pedido { get => _Fecha_de_pedido; set => _Fecha_de_pedido = value; }
        public string TiempoPromedio { get => _TiempoPromedio; set => _TiempoPromedio = value; }
        public string Costo { get => _Costo; set => _Costo = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public Boolean Guardar()
        {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "INSERT INTO Pedidos (IDProveedor, Fecha_de_pedido, TiempoPromedio, Costo, Estado) VALUES (";
                Sentencia += _IDProveedor + ",'";
                Sentencia += _Fecha_de_pedido + "',";
                Sentencia += _TiempoPromedio + ",";
                Sentencia += _Costo + ",'";
                Sentencia += _Estado + "');";
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Guardado = true;
                    MessageBox.Show("Registro insertado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public Boolean Eliminar()
        {
            Boolean Eliminado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "DELETE FROM Pedidos WHERE IDPedido = " + _IdPedido + ";";
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
