using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManager.CLS
{
    public class Sesion
    {
        private static Sesion _instancia = null;
        Datos _Informacion;
        private static readonly object padlock = new object();
        private Sesion()
        {
            Informacion = new Datos();
        }
        public static Sesion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (padlock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new Sesion();
                        }
                    }
                }
                return _instancia;
            }
        }

        public Datos Informacion
        {
            get
            {
                return _Informacion;
            }
            set
            {
                _Informacion = value;
            }
        }
    }
}
