using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Empleado
    {
        //ATRIBUTOS
        String _IDEmpleado;
        String _Nombres;
        String _Apellidos;
        String _Genero;

        //PROPIEDADES

        public string IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Genero { get => _Genero; set => _Genero = value; }

        //ATRIBUTOS

        public Boolean Guardar() {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try {
                Sentencia = "INSERT INTO Empleados(Nombres,Apellidos,Genero) VALUES(";
                Sentencia += "'" + _Nombres + "',";
                Sentencia += "'"+ _Apellidos + "',";
                Sentencia += "'" + _Genero + "');";
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
                Sentencia = "UPDATE Empleados SET ";
                Sentencia += "Nombres ='" + _Nombres + "',";
                Sentencia += "Apellidos ='" + _Apellidos + "',";
                Sentencia += "Genero = '" + _Genero + "',";
                Sentencia += "WHERE IDEmpleado =" + _IDEmpleado + ";";

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
               
                Sentencia = "DELETE FROM Empleados ";
                Sentencia += "WHERE IDEmpleado=" + _IDEmpleado + ";";
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
