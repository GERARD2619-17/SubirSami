using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace DataManager.CLS
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION;
        public static String _User;
        public static String _password;
        String _Cadena = "Server=localhost;Port=3306;Database=samibd;Uid="+ _User + ";Pwd="+ _password + ";SslMode=None;";
        protected Boolean Conectar()
        {
            Boolean _Conectado = false;
            _CONEXION = new MySqlConnection(_Cadena);
            try
            {
                _CONEXION.Open();
                _Conectado = true;
            }
            catch
            {
                _Conectado = false;
            }
            return _Conectado;
        }
        protected void Desconectar()
        {
            try
            {
                if (_CONEXION.State == System.Data.ConnectionState.Open)
                {
                    _CONEXION.Close();
                }
            }
            catch
            {

            }
        }

    }
}
