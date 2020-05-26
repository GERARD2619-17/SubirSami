﻿using System;
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
        String _IDProducto;
        String _IDProveedor;
        String _Fecha_de_pedido;
        String _TiempoPromedio;
        String _Estado;

        public string IdPedido { get => _IdPedido; set => _IdPedido = value; }
        public string IDProducto { get => _IDProducto; set => _IDProducto = value; }
        public string IDProveedor { get => _IDProveedor; set => _IDProveedor = value; }
        public string Fecha_de_pedido { get => _Fecha_de_pedido; set => _Fecha_de_pedido = value; }
        public string TiempoPromedio { get => _TiempoPromedio; set => _TiempoPromedio = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public Boolean Guardar()
        {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "INSERT INTO pedidos (IDProducto, IDProveedor, Fecha_de_pedido, TiempoPromedio, Estado) VALUES(";
                Sentencia += _IDProducto;
                Sentencia += "," + _IDProveedor;
                Sentencia += ",'" + _Fecha_de_pedido;
                Sentencia += "'," + TiempoPromedio;
                Sentencia +=",'"+_Estado+"');";
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
        public Boolean Actualizar()
        {
            Boolean Actualizado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "UPDATE pedidos SET ";
                Sentencia += "IDProducto = " + _IDProducto + ", ";
                Sentencia += "IDProveedor = " + _IDProveedor + ", ";
                Sentencia += "Fecha_de_pedido = '" + _Fecha_de_pedido + "', ";
                Sentencia += "TiempoPromedio = " + _TiempoPromedio + ", ";
                Sentencia += "Estado = '" + _Estado + "' ";
                Sentencia += "WHERE IdPedido = "+_IdPedido+";";

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
