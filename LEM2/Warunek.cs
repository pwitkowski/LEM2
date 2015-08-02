using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEM2
{
    /// <summary>
    /// Warunek t=(a,v), gdzie a-atrybut warunkowy, v-wartość przyjmowana przez a.
    /// </summary>
    class Warunek 
    {
        private String atrybut { get; set; }
        private String wartosc { get; set; }

        public Warunek(String atrybut, String wartosc)
        { 
            this.atrybut=atrybut;
            this.wartosc = wartosc;
        }

        public override bool Equals(object obj)
        {
            Warunek obj2 = obj as Warunek;
            if (obj2 == null) return false;
            return atrybut == obj2.atrybut && wartosc == obj2.wartosc;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
