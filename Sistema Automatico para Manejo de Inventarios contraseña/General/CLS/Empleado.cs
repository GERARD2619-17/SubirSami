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
        String _Apelllidos;
        String _Genero;

        //PROPIEDADES

        public string IDEmpleado { get => _IDEmpleado; set => _IDEmpleado = value; }
        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Apelllidos { get => _Apelllidos; set => _Apelllidos = value; }
        public string Genero { get => _Genero; set => _Genero = value; }

        //ATRIBUTOS

        public Boolean Guardar() {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try {
                Sentencia = "INSERT INTO Empleados(Nombres,Apellidos,Genero) VALUES(";
                Sentencia += "'" + _Nombres + "',";
                Sentencia += "'"+ _Apelllidos + "',";
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


    }
}
