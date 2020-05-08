using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    class Herramientas
    {
        public static String CadenaMayuscula(String cadenas) {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            return ti.ToTitleCase(cadenas);
        }
    }
}
