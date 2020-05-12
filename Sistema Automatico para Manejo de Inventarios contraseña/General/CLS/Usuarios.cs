using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Usuarios
    {
        //ATRIBUTOS

        String _IDUsuario;
        String _Usuario;
        String _Credencial;
        String _IDRol;
        String _IDEmpleado;

        //PROPIEDADES

        public string IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Credencial { get => _Credencial; set => _Credencial = value; }
        public string IDRol { get => _IDRol; set => _IDRol = value; }
        public string IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }

        public Boolean Guardar()
        {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "INSERT INTO Usuarios(Usuario, Credencial, IDRol, IDEmpleado) VALUES(";
                Sentencia += "'" + _Usuario + "',";
                Sentencia += "md5(sha1('" + _Credencial + "')),";
                Sentencia += _IDRol + ",";
                Sentencia += _IDEmpleado + ");";

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
                Sentencia = "UPDATE Usuarios SET ";
                Sentencia += "Usuario ='" + _Usuario + "',";
                Sentencia += "Credencial = md5(sha1('" + _Credencial + "')), ";
                Sentencia += "IDRol =" + _IDRol + ",";
                Sentencia += "IDEmpleado =" + _IDEmpleado;
                Sentencia += " WHERE IDUsuario =" + IDUsuario + ";";
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
                Sentencia = "DELETE FROM Usuario";
                Sentencia += "WHERE IDUsuario =" + _IDUsuario + ";";
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
