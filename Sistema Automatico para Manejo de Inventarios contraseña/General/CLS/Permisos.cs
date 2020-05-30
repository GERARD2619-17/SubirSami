using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.CLS
{
    class Permisos
    {
        String _IDPermiso;
        String _IDOpcion;
        String _IDRol;

        public string IDPermiso { get => _IDPermiso; set => _IDPermiso = value; }
        public string IDOpcion { get => _IDOpcion; set => _IDOpcion = value; }
        public string IDRol { get => _IDRol; set => _IDRol = value; }

        public Boolean Conceder()
        {
            Boolean Guardado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "INSERT INTO Permisos(IDOpcion, IDRol) VALUES(";
                Sentencia += _IDOpcion + ",";
                Sentencia += _IDRol+");";
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Guardado = true;
                    MessageBox.Show("Permiso asignado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Guardado = false;
                    MessageBox.Show("El permiso no pudo ser asignado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                Guardado = false;
                MessageBox.Show("Ha ocurrido un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Guardado;
        }
        public Boolean Revocar()
        {
            Boolean Eliminado = false;
            String Sentencia;
            DataManager.CLS.DBOperacion Operacion = new DataManager.CLS.DBOperacion();
            try
            {
                Sentencia = "DELETE FROM Permisos WHERE IdPermiso ="+_IDPermiso+";";
                if (Operacion.Eliminar(Sentencia) > 0)
                {
                    Eliminado = true;
                    MessageBox.Show("Permiso revocado", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Eliminado = false;
                    MessageBox.Show("El permiso no puede ser revocado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
