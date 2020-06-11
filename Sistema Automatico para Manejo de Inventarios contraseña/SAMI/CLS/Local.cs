using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMI.CLS
{
    class Local
    {
        String _User;
        String _password;

        public string Password { get => _password; set => _password = value; }
        public string User { get => _User; set => _User = value; }

        static DataTable _DATOS = new DataTable();
        static void Configurar()
        {
            _DATOS.Columns.Add("cUsuario");
            _DATOS.Columns.Add("cPassword");
        }
        static void LeerLista()
        {
            try
            {
                _DATOS.TableName = "Configurar";
                _DATOS.ReadXml("Configuracion.xml");
            }

            catch { }
        }
        public static String obtenerUsuario()
        {
            Configurar();
            LeerLista();
            String usuario = "";
            
            try
            {
                usuario = _DATOS.Rows[0]["cUsuario"].ToString();
            }
            catch {
                usuario = "";
            }
            
            return usuario;
        }
        public static String obtenerContra()
        {
            String contra = "";
            try
            {
                contra = _DATOS.Rows[0]["cPassword"].ToString();
            }
            catch {
                contra = "";
            }
            
            return contra;
        }
    }
}
