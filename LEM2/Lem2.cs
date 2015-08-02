using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEM2
{
    class Lem2
    {
        private DataTable tablicaDecyzyjna;
        private String daneWejsciowe;

        public Lem2(DataTable tablicaDecyzyjna, String daneWejsciowe)
        {
            this.tablicaDecyzyjna = tablicaDecyzyjna;
            this.daneWejsciowe = daneWejsciowe;
        }

        /// <summary>
        /// Metoda ta uruchamia algorytm LEM2.
        /// </summary>
        public void uruchomAlgorytmLem2()
        {

            //dane z tablicy decyzyjnej
            List<int> U = new List<int>();
            foreach (DataRow wiersz in tablicaDecyzyjna.Rows)
            {
                U.Add(Convert.ToInt32(wiersz[0]));
            }
            Console.WriteLine("U: " + U.ToString());

            List<String> A = new List<String>();
            foreach (DataColumn kolumna in tablicaDecyzyjna.Columns)
            {
                if (kolumna.Ordinal == 0 || kolumna.Ordinal == tablicaDecyzyjna.Columns.Count - 1) continue; //usuwam pierwszą i ostatnia kolumne
                A.Add(kolumna.ColumnName);
                //A.Add(kolumna.Caption);

            }
            Console.WriteLine("A: " + A.ToString());

            String d = tablicaDecyzyjna.Columns[tablicaDecyzyjna.Columns.Count - 1].ColumnName;
            Console.WriteLine("d: " + d);

            //algorytm
            //wejście
            List<int> X = new List<int>(); //niepusta dolna lub górna aproksymacja klasy decyzyjnej
            String[] wejscie = daneWejsciowe.Split(new Char[] { ',' });
            foreach (String we in wejscie)
            {
                X.Add(Convert.ToInt32(we));
            }
            Console.WriteLine("X: " + X.ToString());

            //inicjowanie zmiennych
            ZbiorWarunkow T = new ZbiorWarunkow();        //zbiór warunków t
            ZbiorWarunkow Tg =  new ZbiorWarunkow();      //zbiór warunków należących do G

            //begin
            List<int> G = X;                              //kopia danych wejściowych
            ZbiorWarunkow Tprim = new ZbiorWarunkow();    //wyjście, regóły, rodzina zbiorów T

            while (G.Count != 0)
            {
                T = new ZbiorWarunkow();

                foreach (DataRow wiersz in tablicaDecyzyjna.Rows)
                {
                    if (!G.Contains(Convert.ToInt32(wiersz[0]))) continue; //przeskakuje niepotrzebne wiersze
                    foreach (DataColumn kolumna in tablicaDecyzyjna.Columns)
                    {
                        if (!A.Contains(kolumna.ColumnName)) continue; //przeskakuje niepotrzebne kolumny
                        Warunek wartoscTg = new Warunek(kolumna.ColumnName, wiersz[kolumna.Ordinal].ToString()); //TODO zmienic nazwe
                        if (!Tg.listaWarunkow.Contains(wartoscTg)) Tg.listaWarunkow.Add(wartoscTg);
                    }
                }
                Console.WriteLine("Tg: " + Tg.ToString());

                while (T.listaWarunkow.Count == 0 /*|| T c/ X*/)
                {

                }
            }

            //end
        }
    }
}
