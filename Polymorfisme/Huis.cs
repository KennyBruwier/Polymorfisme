using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorfisme
{
    class Huis
    {
        public List<Kamer> Kamers = new List<Kamer>();
        public Huis(Kamer kamer)
        {
            if (Kamers == null) Kamers = new List<Kamer>();
            Kamers.Add(kamer);
        }
        public Huis(List<Kamer> kamers)
        {
            if (Kamers == null) Kamers = new List<Kamer>();
            foreach (Kamer kamer in kamers)
            {
                Kamers.Add(kamer);
            }
        }
        public double BerekenOpp()
        {
            double Totaal = 0;
            if (Kamers != null)
            {
                foreach (Kamer kamer in Kamers)
                {
                    Totaal += kamer.Oppervlakte;
                }
            }
            return Totaal;
        }
        public double BerekenPrijs()
        {
            double Totaal = 0;
            if (Kamers != null)
            {
                foreach (Kamer kamer in Kamers)
                {
                    Totaal += kamer.Prijs;
                }
            }
            return Totaal;
        }
        public void TekenHuis()
        {
            foreach (Kamer kamer in Kamers)
            {
                kamer.TekenKamer();
            }
        }
    }
    abstract class Kamer
    {
        public int Oppervlakte { get { return Lengte * Breedte; }  }
        public int Lengte { get; set; }
        public int Breedte { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public string Naam { get; set; }
        public virtual double Prijs { get; set; }
        public Kamer(string naam, int lengte, int breedte, int x, int y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            Y = y;
            X = x;
        }

        abstract public void TekenKamer();

        protected void TekenKamerProtected(byte kleur)
        {
            int cursTop = Console.CursorTop;
            int cursLeft = Console.CursorLeft;
            int count = 0;
            char c;
            byte curFKleur = (byte)Console.ForegroundColor;
            Console.SetCursorPosition(Y, X);
            Console.ForegroundColor = (ConsoleColor)kleur;
            for (int i = 0; i < Lengte; i++)
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int j = 0; j < Breedte; j++)
                {
                    c = ' ';
                    if ((i == 0) && (j == 0)) c = '┌';
                    if ((i == Lengte - 1) && (j == Breedte - 1)) c = '┘';
                    if ((i == Lengte - 1) && (j == 0)) c = '╘';
                    if ((i == 0) && (j == Breedte - 1)) c = '┐';
                    if (c == ' ')
                    {
                        if ((i == 0) || (i==Lengte-1)) c = '─';
                        if ((j == 0) || (j==Breedte-1)) c = '│';
                    }
                    if ((c == ' ') && (count < Naam.Length)) c = Naam[count++];
                    stringBuilder.Append(c);
                }
                Console.SetCursorPosition(Y, X+i);
                Console.Write(stringBuilder);
            }
            Console.SetCursorPosition(cursLeft,cursTop);
            Console.ForegroundColor = (ConsoleColor)curFKleur;
        }
    }
    class Badkamer : Kamer
    {
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }

        public Badkamer(string naam, int lengte, int breedte, int x, int y) : base(naam,lengte,breedte,x,y)
        {
            Lengte = lengte;
            Breedte = breedte;
            Naam = naam;
            X = x;
            Y = y;
            Prijs = 500;
        }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Cyan);
        }
    }
    class Gang : Kamer
    {
        private const byte prijsPerVierkanteMeter = 10;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public Gang(string naam, int lengte, int breedte, int x, int y) : base(naam, lengte, breedte, x, y)
        {
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Naam = naam;
            Prijs = Math.Round((double)Oppervlakte * prijsPerVierkanteMeter);
        }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Yellow);
        }
    }
    class Salon : Kamer
    {
        private bool schouwAanwezig;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public bool SchouwAanwezig { get; set; }
        public Salon(string naam, int lengte, int breedte, int x, int y, bool schouwAanwezig = false): base(naam, lengte, breedte, x, y)
        {
            X = x;
            Y = y;
            Lengte = lengte;
            Breedte = breedte;
            SchouwAanwezig = schouwAanwezig;
            Naam = naam;
            if (schouwAanwezig) Prijs = 500;
            else Prijs = 300;
        }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.DarkRed);
        }
    }
    class Slaapkamer : Kamer
    {
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Cyan);
        }
        public Slaapkamer(string naam, int lengte, int breedte, int x, int y):base(naam,lengte,breedte,x,y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Prijs = 400;
        }
    }
    class Garage : Kamer
    {
        private const byte prijsPerVierkanteMeter = 15;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.White);
        }
        public Garage(string naam, int lengte, int breedte, int x, int y) : base(naam, lengte, breedte, x, y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Prijs = Math.Round((double)Oppervlakte * prijsPerVierkanteMeter);
        }
    }
    class Terras : Kamer
    {
        private const byte prijsPerVierkanteMeter = 7;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Magenta);
        }
        public Terras(string naam, int lengte, int breedte, int x, int y) : base(naam, lengte, breedte, x, y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Prijs = Math.Round((double)Oppervlakte * prijsPerVierkanteMeter);
        }
    }
    class Zwembad : Kamer
    {
        private const byte prijsPerVierkanteMeter = 50;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Blue);
        }
        public Zwembad(string naam, int lengte, int breedte, int x, int y) : base(naam, lengte, breedte, x, y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Prijs = Math.Round((double)Oppervlakte * prijsPerVierkanteMeter);
        }
    }
    class Tuin : Kamer
    {
        private const byte prijsPerVierkanteMeter = 3;
        public override double Prijs { get => base.Prijs; set => base.Prijs = value; }
        public override void TekenKamer()
        {
            TekenKamerProtected((byte)ConsoleColor.Green);
        }
        public Tuin(string naam, int lengte, int breedte, int x, int y) : base(naam, lengte, breedte, x, y)
        {
            Naam = naam;
            Lengte = lengte;
            Breedte = breedte;
            X = x;
            Y = y;
            Prijs = Math.Round((double)Oppervlakte * prijsPerVierkanteMeter);
        }

    }

}
