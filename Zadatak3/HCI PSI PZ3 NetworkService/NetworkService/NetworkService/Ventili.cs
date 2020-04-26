using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService
{
    public class Ventil
    {
        private int id;
        private string naziv;
        private string tip;
        private List<int> stanja;
        private string image;
        private int st;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public string Tip
        {
            get
            {
                return tip;
            }

            set
            {
                tip = value;
            }
        }

        public List<int> Stanja
        {
            get
            {
                return stanja;
            }

            set
            {
                stanja = value;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public int St
        {
            get
            {
                return st;
            }

            set
            {
                st = value;
            }
        }

        public Ventil()
        {
            Id = 0;
            Naziv = "";
            Tip = "";
            Stanja = new List<int>();
            Image = "";
            St = 0;
        }

        public Ventil(int i, string s1, string s2)
        {
            Id = i;
            Naziv = s1;
            Tip = s2;
            Stanja = new List<int>();
            St = 0;
            switch (s2)
            {
                case "Tip1": Image = @"C:\Users\STEFAN\Documents\Zadatak3\Zadatak3\Images\tip1.jpg"; break;//NetworkService;component/Images/tip1.jpg/NwtworkService;component/Images/tip1.jpg
                case "Tip2": Image = @"C:\Users\STEFAN\Documents\Zadatak3\Zadatak3\Images\tip2.jpg"; break;
                case "Tip3": Image = @"C:\Users\STEFAN\Documents\Zadatak3\Zadatak3\Images\tip3.jpg"; break;
                
            }
        }

        public override string ToString()
        {
            return Id + " " + Naziv + " " + Tip + " " + ProcitajStanja() + "\n";
        }

        public string ProcitajStanja()
        {
            string pom = "";

            for (int i = 0; i < Stanja.Count(); i++)
            {
                pom += "\n\t\t\t\tdate: " + DateTime.Now.ToString() +" value: " + Stanja[i] + "\n";
            }

            return pom;
        }
    }
}
