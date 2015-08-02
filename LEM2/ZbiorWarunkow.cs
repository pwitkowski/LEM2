using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEM2
{
    /// <summary>
    /// T - zbiór warunków t.
    /// </summary>
    class ZbiorWarunkow
    {
        public List<Warunek> listaWarunkow { get;  set; }

        public ZbiorWarunkow()
        {
            this.listaWarunkow = new List<Warunek>();
        }
    }
}
