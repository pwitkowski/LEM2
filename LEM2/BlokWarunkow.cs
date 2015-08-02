using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEM2
{
    /// <summary>
    /// [t] – blok, tj. zbiór obiektów spełniajacych warunek t = (a, v);
    /// </summary>
    class BlokWarunkow
    {
        private Warunek warunek { get; set; }
        private List<int> listaWystapien { get; set; } //TODO zmienić nazwę

        public BlokWarunkow()
        {
            listaWystapien = new List<int>();
        }

        public override bool Equals(object obj)
        {
            BlokWarunkow obj2 = obj as BlokWarunkow;
            if (obj2 == null) return false;
            return warunek == obj2.warunek;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
