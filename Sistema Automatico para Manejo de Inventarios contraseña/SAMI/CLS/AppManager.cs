using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAMI.CLS
{
    class AppManager : ApplicationContext
    {
        public AppManager()
        {
            if (Splash())
            {
              
                if (Login())
                {
                    //General.GUI.GestionProductos f = new General.GUI.GestionProductos();
                    GUI.Principal f = new GUI.Principal();
                    f.ShowDialog();
                }
            }
        }
        private Boolean Splash()
        {
            Boolean _Resultado = true;
            GUI.Splash f = new GUI.Splash();
            f.ShowDialog();
            String U = Local.obtenerUsuario();
            String P = Local.obtenerContra();
            DataManager.CLS.DBConexion._User = U;
            DataManager.CLS.DBConexion._password = P;
            if (U.Length < 1) {
                if (MessageBox.Show("Se a detectado que no hay una conexión al servicio de base de datos ¿Configurar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    General.GUI.Conexión g = new General.GUI.Conexión();
                    g.ShowDialog();
                    if (g.Validar == false)
                    {
                        _Resultado = false;
                    }
                }
                else {
                    _Resultado = false;
                }
            }
            return _Resultado;
        }
        private Boolean Login()
        {
            Boolean _Resultado = true;
            GUI.Login f = new GUI.Login();
            f.ShowDialog();
            //detecta la autorizacion y si no lo deniega
            _Resultado = f.Autorizado;
            return _Resultado;
        }
    }
}
