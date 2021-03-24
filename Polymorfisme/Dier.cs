using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorfisme
{
    enum DierSoort
    {
        Kat,
        Hond,
        Vis,
        Koe
    }
    abstract class Dier
    {
        public int Gewicht { get; set; }
        public virtual string Naam { get; set; }

        public virtual DierSoort Soort { get; set; }

        abstract public void Zegt();

        public void OverZicht()
        {

            Console.WriteLine(string.Format("\t{0,-6}:{1,-30}\t{2,4}kg", Soort, Naam, Gewicht));
        }
        public void DierMsg(string msg)
        {
            int cursX = Console.CursorTop;
            int cursY = Console.CursorLeft;

            Console.SetCursorPosition((Console.WindowWidth / 2) - msg.Length / 2, Console.WindowHeight / 2);
            Console.Write(GetType().ToString().Split('.')[1]+ ": " +msg);
            Console.SetCursorPosition(cursY, cursX);
            Console.ReadKey(true);

        }

    }
    class Kat : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }
        public override void Zegt()
        {
            DierMsg("Who's the boss? You wish!");
        }
        public Kat(int gewicht, string naam = "Kat")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Kat;
        }
        public Kat()
        {
            Soort = DierSoort.Kat;
        }
    }
    class Hond : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }

        public override void Zegt()
        {
            DierMsg("Eten! eten! eten! ... waar is mijn eten!!!");
        }
        public Hond(int gewicht, string naam = "Hond")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Hond;
        }
        public Hond()
        {
            Soort = DierSoort.Hond;
        }
    }
    class Vis : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = value; }
        public override void Zegt()
        {
            DierMsg(" ....  ....  .... !#?! .... ");
        }
        public Vis(int gewicht, string naam = "Vis")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Vis;
        }
        public Vis()
        {
            Soort = DierSoort.Vis;
        }
    }
    class Koe : Dier
    {
        public override string Naam { get => base.Naam; set => base.Naam = value; }
        public override DierSoort Soort { get => base.Soort; set => base.Soort = DierSoort.Koe; }
        public override void Zegt()
        {
            DierMsg("LEEEEEEEEOOOOOO!");
        }
        public Koe(int gewicht, string naam = "Koe")
        {
            Naam = naam;
            Gewicht = gewicht;
            Soort = DierSoort.Koe;
        }
        public Koe()
        {
            Soort = DierSoort.Koe;
        }
    }
}
