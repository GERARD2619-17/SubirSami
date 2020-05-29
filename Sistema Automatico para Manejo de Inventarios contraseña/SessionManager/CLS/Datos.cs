using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionManager.CLS
{
    public class Datos
    {
        DataTable _PERMISOS = new DataTable();
        String _IDUsuario;
        String _Usuario;
        String _IDRol;
        String _Rol;

        public string IDUsuario
        {
            get
            {
                return _IDUsuario;
            }

            set
            {
                _IDUsuario = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string IDRol
        {
            get
            {
                return _IDRol;
            }

            set
            {
                _IDRol = value;
                ObtenerPermiso();
            }
        }

        public string Rol
        {
            get
            {
                return _Rol;
            }

            set
            {
                _Rol = value;
            }
        }

        public void ObtenerPermiso() {
            try
            {
                _PERMISOS = CacheManager.CLS.Cache.PERMISOS_DE_UN_ROL(_IDRol);
            }
            catch { }
        }

        public Boolean VerificarPermiso(Int32 pIDOpcion) {
            Boolean Autorizado = false;
            DataTable a = _PERMISOS;
            try
            {
                foreach (DataRow fila in _PERMISOS.Rows)
                {
                    if (fila["IDOpcion"].ToString().Equals(pIDOpcion.ToString()))
                    {
                        Autorizado = true;
                        break;
                    }
                }
            }
            catch {
                Autorizado = false;
            }
            if (Autorizado == false) {
                MessageBox.Show("No tiene los permisos para acceder a esta opción","Aviso", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            return Autorizado;
        }
    }
}
