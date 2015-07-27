using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEM2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TODO usunąć wszystko pod komentarzem
            textBoxX.Text = "1,2,4,5";
            lem2();
        }

        private void lem2()
        {
            //algorytm LEM2
            //tablica decyzyjna
            DataTable DT = Toolbox.ConvertCSVtoDataTable("../../zbior2.csv");
            dataGridView1.DataSource = DT;

            //dane z tablicy decyzyjnej
            List<int> U = new List<int>();
            foreach (DataRow wiersz in DT.Rows)
            {
                U.Add(Convert.ToInt32(wiersz[0]));
            }
            Console.WriteLine("U: " + U.ToString());

            List<String> A = new List<String>();
            foreach (DataColumn kolumna in DT.Columns)
            {
                if (kolumna.Ordinal == 0 || kolumna.Ordinal == DT.Columns.Count - 1) continue; //usuwam pierwszą i ostatnia kolumne
                A.Add(kolumna.ColumnName);
            }
            Console.WriteLine("A: " + A.ToString());

            String d = DT.Columns[DT.Columns.Count - 1].ColumnName;
            Console.WriteLine("d: " + d);

            //algorytm
            //wejście
            List<int> X = new List<int>();
            String[] wejscie = textBoxX.Text.Split(new Char[] { ',' });
            foreach(String we in wejscie)
            {
                X.Add(Convert.ToInt32(we));
            }
            Console.WriteLine("X: "+X.ToString());

            //begin
            List<int> G = X;
            List<KeyValuePair<String, String>> T = new List<KeyValuePair<String, String>>();
            List<KeyValuePair<String, String>> Tg = new List<KeyValuePair<String, String>>();

            while (G.Count != 0)
            {
                T = new List<KeyValuePair<String, String>>();
                
                foreach(DataRow wiersz in DT.Rows)
                {
                    if (!G.Contains(Convert.ToInt32(wiersz[0]))) continue; //przeskakuje niepotrzebne wiersze
                    foreach(DataColumn kolumna in DT.Columns)
                    {
                        if (!A.Contains(kolumna.ColumnName)) continue; //przeskakuje niepotrzebne kolumny
                        KeyValuePair<String, String> wartoscTg = new KeyValuePair<String, String>(kolumna.ColumnName, wiersz[kolumna.Ordinal].ToString()); //TODO zmienic nazwe
                        if (!Tg.Contains(wartoscTg)) Tg.Add(wartoscTg);
                    }
                }
                Console.WriteLine("Tg: " + Tg.ToString());

                while (T.Count == 0 ||)
                {

                }
            }

            //end
        }

        private void przyciskPrzelicz_Click(object sender, EventArgs e)
        {
            lem2();
        }
    }
}
