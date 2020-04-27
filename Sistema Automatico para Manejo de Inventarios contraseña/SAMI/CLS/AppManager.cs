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
