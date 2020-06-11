﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DataManager.CLS
{
    public class DBConexion
    {
        protected MySqlConnection _CONEXION;
        static String User = "root";
        static String password = "admin123";
        
        String _Cadena = "Server=localhost;Port=3306;Database=samibd;Uid="+ User + ";Pwd="+password+";SslMode=None;";
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
