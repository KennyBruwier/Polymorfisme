using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorfisme
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Oefeningen = new List<string>();
            Console.OutputEncoding = Encoding.UTF8; // voor de euro sign
            Oefeningen = new List<string>();
            Oefeningen.Add("Exit");
            Oefeningen.Add("Dierentuin");
            Oefeningen.Add("Pokemons vergelijken");
            Oefeningen.Add("Magic");
            Oefeningen.Add("Een eigen huis");

            bool bExit = false;
            while (!bExit)
            {
                Console.Clear();
                Console.WriteLine("Overerving oefeningen:\n");
                switch (SelectMenu(false, Oefeningen.ToArray()) - 1)
                {
                    case 0: bExit = true; break;
                    case 1: Dierentuin(); break;
                    case 2: PokemonsVergelijken(); break;
                    case 3: Magic(); break;
                    case 4: EenEigenHuis(); break;
                    default:
                        break;
                }
            }

            void Dierentuin()
            {

                bool exit = false;
                string[] dierenNamen = { "Kat", "Hond", "Vis", "Koe", "q" };
                List<Dier> dieren = new List<Dier>();

                while (!exit)
                {
                    bool toevoegen = true;
                    while (toevoegen)
                    {
                        Console.Clear();
                        foreach (Dier dier in dieren)
                            dier.OverZicht();
                        Dier nieuwDier = null;
                        Console.WriteLine("\n\nDieren toevoegen:");
                        switch (SelectMenu(false, dierenNamen))
                        {
                            case 1:
                                nieuwDier = new Kat();
                                break;
                            case 2:
                                nieuwDier = new Hond();
                                break;
                            case 3:
                                nieuwDier = new Vis();
                                break;
                            case 4:
                                nieuwDier = new Koe();
                                break;
                            case 5:
                                toevoegen = false;
                                break;
                            default: exit = true; break;
                        }
                        if (nieuwDier != null)
                        {
                            nieuwDier.Naam = InputStr("Naam: ");
                            nieuwDier.Gewicht = InputInt("Gewicht: ");
                            dieren.Add(nieuwDier);
                        }
                    }

                    bool opnieuw = true;
                    while (opnieuw)
                    {
                        if (dieren != null)
                            foreach (Dier dier in dieren)
                                dier.OverZicht();
                        Console.WriteLine("\n\nMenu:");
                        switch (SelectMenu(false, "Dier verwijderen", "Gemiddelde gewicht", "Dier praten", "Opnieuw beginnen", "Exit"))
                        {
                            case 1:
                                {
                                    bool delete = true;
                                    while (delete)
                                    {
                                        List<string> dierNamen = new List<string>();
                                        foreach (Dier dier in dieren)
                                        {
                                            if ((dier.Naam != null) && (dier.Naam != ""))
                                                dierNamen.Add(dier.Naam);
                                        }
                                        dierNamen.Add("Exit");
                                        string dierToDelete = dierNamen[SelectMenu(true, dierNamen.ToArray()) - 1];
                                        if (dierToDelete == "Exit") delete = false;
                                        else
                                        {
                                            int indexToRemove = -1;
                                            foreach (Dier dier in dieren)
                                                if (dier.Naam == dierToDelete) indexToRemove = dieren.IndexOf(dier);
                                            if (indexToRemove != -1) dieren.RemoveAt(indexToRemove);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                {
                                    List<int> gewicht = new List<int>();
                                    foreach (Dier dier in dieren)
                                        if (dier.Gewicht != 0) gewicht.Add(dier.Gewicht);
                                    Console.WriteLine("Gemiddeld gewicht van al de dieren: " + Math.Round(gewicht.Average(), 1));
                                }
                                break;
                            case 3:
                                {
                                    Dier dierDatZegt = null;
                                    List<string> DierNamens;
                                    DierNamens = new List<string>();
                                    foreach (int  i in Enum.GetValues(typeof(DierSoort)))
                                    {
                                        DierNamens.Add(Enum.GetName(typeof(DierSoort), i)); 
                                    }
                                    switch(SelectMenu(false,DierNamens.ToArray()))
                                    {
                                        case 1: dierDatZegt = new Kat();
                                            break;
                                        case 2: dierDatZegt = new Hond();
                                            break;
                                        case 3: dierDatZegt = new Vis();
                                            break;
                                        case 4: dierDatZegt = new Koe();
                                            break;
                                        default: break;
                                    }
                                    if (dierDatZegt!= null)
                                    {
                                        foreach (Dier dier in dieren)
                                        {
                                            if (dier.GetType() == dierDatZegt.GetType()) dier.Zegt();
                                        }
                                    }
                                }
                                break;
                            case 4:
                                {
                                    opnieuw = false;
                                    dieren = new List<Dier>();
                                }
                                break;
                            case 5:
                                {
                                    opnieuw = false;
                                    exit = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            void PokemonsVergelijken()
            {
                Console.Clear();
                Pokemon[] mijnPokemons = new Pokemon[10];

                for (int i = 0; i < mijnPokemons.GetLength(0); i++)
                {
                    bool Aangemaakt = false;
                    mijnPokemons[i] = new Pokemon();
                    switch (i)
                    {
                        case 0:
                            {
                                mijnPokemons[i].Naam = "Bulbasaur";
                                mijnPokemons[i].Nummer = 1;
                                mijnPokemons[i].HP_Base = 45;
                                mijnPokemons[i].Attack_Base = 49;
                                mijnPokemons[i].Defense_Base = 49;
                                mijnPokemons[i].SpecialAttack_Base = 65;
                                mijnPokemons[i].SpecialDefense_Base = 65;
                                mijnPokemons[i].Speed_Base = 45;
                                Aangemaakt = true;
                            }
                            break;
                        case 1:
                            {
                                mijnPokemons[i].Naam = "Ivysaur";
                                mijnPokemons[i].Nummer = 2;
                                mijnPokemons[i].HP_Base = 60;
                                mijnPokemons[i].Attack_Base = 62;
                                mijnPokemons[i].Defense_Base = 63;
                                mijnPokemons[i].SpecialAttack_Base = 80;
                                mijnPokemons[i].SpecialDefense_Base = 80;
                                mijnPokemons[i].Speed_Base = 60;
                                Aangemaakt = true;
                            }
                            break;
                        case 2:
                            {
                                mijnPokemons[i].Naam = "Venusaur";
                                mijnPokemons[i].Nummer = 3;
                                mijnPokemons[i].HP_Base = 80;
                                mijnPokemons[i].Attack_Base = 82;
                                mijnPokemons[i].Defense_Base = 83;
                                mijnPokemons[i].SpecialAttack_Base = 100;
                                mijnPokemons[i].SpecialDefense_Base = 100;
                                mijnPokemons[i].Speed_Base = 80;
                                Aangemaakt = true;
                            }
                            break;
                        default: break;
                    }
                    if (Aangemaakt)
                    {
                        Console.WriteLine($"Pokemon {mijnPokemons[i].Naam} aangemaakt.\nGemiddelde score: {mijnPokemons[i].Average}\nTotaal score: {mijnPokemons[i].Total}");
                        Console.WriteLine(mijnPokemons[i].ToString());
                    }
                }
                Console.WriteLine("\nPokemons vergelijken:");
                Console.WriteLine($"is {mijnPokemons[0].Naam} gelijk aan {mijnPokemons[0].Naam}?\tantwoord: {mijnPokemons[0].Equals(mijnPokemons[0])}");
                Console.WriteLine($"is {mijnPokemons[0].Naam} gelijk aan {mijnPokemons[1].Naam}?\tantwoord: {mijnPokemons[0].Equals(mijnPokemons[1])}");
                Console.WriteLine($"is {mijnPokemons[0].Naam} gelijk aan {mijnPokemons[2].Naam}?\tantwoord: {mijnPokemons[0].Equals(mijnPokemons[2])}");

                Console.ReadKey();
            }
            void Magic()
            {
                Console.Clear();
                Manager manager = new Manager();
                CreatureCard creatureCard = new CreatureCard(20,30);
                SpellCard spellCard = new SpellCard(SpellEffect.burn);
                Land land = new Land("Mountains");
                Articfact articfact = new Articfact("Adds 3 mana of any single color of your choice to your mana pool, then is discarded. Tapping this artifact can be played as an interrupt");
                manager.cards.Add(creatureCard);
                manager.cards.Add(spellCard);
                manager.cards.Add(land);
                manager.cards.Add(articfact);

                foreach (Card card in manager.cards)
                {
                    Console.WriteLine($"Card {manager.cards.IndexOf(card)+1}");
                    if (card is CreatureCard)
                    {   
                        Console.WriteLine($"Creature card:\tHealth: {((CreatureCard)card).health} Attack: {((CreatureCard)card).attack}");
                    }
                    if (card is SpellCard)
                    {
                        Console.WriteLine($"Spell card:\tEffect: {((SpellCard)card).effect}");
                    }
                    if (card is Land)
                    {
                        Console.WriteLine($"Land card:\tEffect: {((Land)card).Terrain}");
                    }
                    if (card is Articfact)
                    {
                        Console.WriteLine($"Artifact card:\tEffect: {((Articfact)card).Artifact_effect}");
                    }
                    Console.WriteLine();
                }

                Console.ReadKey(true);

            }
            void EenEigenHuis()
            {
                ConsoleColor consoleColor;
                Console.Clear();
                List<Kamer> mijnKamers = new List<Kamer>();
                //mijnKamers.Add(new Badkamer("badkamer",5,5,15,30));
                //mijnKamers.Add(new Salon("Salon", 10, 10, 15, 20));
                //mijnKamers.Add(new Kamer("Slaapkamer 1", 5, 7, 15, 35));
                //mijnKamers.Add(new Kamer("Slaapkamer 2", 5, 7, 20, 35));
                //mijnKamers.Add(new Gang("Gang 1", 3, 22, 25, 20));
                //mijnKamers.Add(new Gang("Gang 2", 5, 5, 20, 30));
                mijnKamers.Add(new Badkamer("badkamer", 5, 5, 1, 65));
                mijnKamers.Add(new Salon("Salon", 10, 10, 1, 55));
                mijnKamers.Add(new Slaapkamer("Slaapkamer 1", 5, 7, 1, 70));
                mijnKamers.Add(new Slaapkamer("Slaapkamer 2", 5, 7, 6, 70));
                mijnKamers.Add(new Gang("Gang 1", 3, 22, 11, 55));
                mijnKamers.Add(new Gang("Gang 2", 5, 5, 6, 65));
                mijnKamers.Add(new Garage("Garage 1", 6, 22, 14, 55));
                mijnKamers.Add(new Tuin("Tuin",19, 20, 1, 77));
                mijnKamers.Add(new Zwembad("Zwembad", 5, 10, 10, 85));
                mijnKamers.Add(new Terras("Terras", 15, 7,4,78));
                Huis mijnHuis = new Huis(mijnKamers);
                Console.WriteLine("\tHuis bevat volgende kamers:\n");
                Console.WriteLine(string.Format("\t{0,-7} {1,-5}: {2,-16} {3,3} {4,-5}", "Klassen", "Index", "Naam", "Opp.", "Prijs"));
                foreach (Kamer kamer in mijnHuis.Kamers)
                {
                    string msg = string.Format("\t{4,-10} {0,2}: {1,-15} {2,3}m² {3,-5:0}€"
                                                , mijnHuis.Kamers.IndexOf(kamer) + 1, kamer.Naam, kamer.Oppervlakte, kamer.Prijs, kamer.GetType().ToString().Split('.')[1]);
                    Console.WriteLine(msg);
                }
                consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(string.Format("\t{0,31}{2,3}m² {1,-5:0}€", "Totaal ", mijnHuis.BerekenPrijs(),mijnHuis.BerekenOpp()));
                Console.ForegroundColor = consoleColor;
                mijnHuis.TekenHuis();
                Console.ReadKey(true);
            }

            int SelectMenu(bool clearScreen = true, params string[] menu)
            {
                int selection = 1;
                int cursTop = Console.CursorTop;
                int cursLeft = Console.CursorLeft;
                bool selected = false;
                ConsoleColor selectionForeground = Console.BackgroundColor;
                ConsoleColor selectionBackground = Console.ForegroundColor;

                if (clearScreen)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                }
                else
                {
                    cursTop = Console.CursorTop;
                    cursLeft = Console.CursorLeft;
                    Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.CursorVisible = false;

                while (!selected)
                {
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (selection == i + 1)
                        {
                            Console.ForegroundColor = selectionForeground;
                            Console.BackgroundColor = selectionBackground;
                        }
                        Console.WriteLine(string.Format("{0,5}:{1,-40}", i + 1, menu[i]));
                        Console.ResetColor();
                    }
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            selection++;
                            break;
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1: selection = 1; break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2: selection = 2; break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3: selection = 3 <= menu.Length ? 3 : menu.Length; break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4: selection = 4 <= menu.Length ? 4 : menu.Length; break;
                    }
                    selection = Math.Min(Math.Max(selection, 1), menu.Length);
                    if (clearScreen)
                        Console.SetCursorPosition(0, 0);
                    else Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.Clear();
                Console.CursorVisible = true;
                return selection;
            }
            string InputStrFormat(string inputFormat = "  :    :    :", int fixedLength = 14, char charStart = '0', char charEnd = '9')
            {
                string toReturn = inputFormat;
                bool exit = false;
                int cursX = Console.CursorLeft;
                int cursY = Console.CursorTop;
                int count = 0;

                foreach (char c in toReturn)
                {
                    if (c == ' ')
                    {

                    }
                }
                while ((toReturn.Length < fixedLength) && (!exit))
                {
                    Console.CursorLeft = cursX;
                    Console.CursorTop = cursY;
                    Console.WriteLine(toReturn, fixedLength);
                    char input = Console.ReadKey(true).KeyChar;
                    if ((input >= charStart) && (input <= charEnd))
                    {
                        //toReturn[0] = input;
                    }
                }

                return toReturn;
            }
            char InputChr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    Console.WriteLine(tekst[i]);
                return Console.ReadKey(true).KeyChar;
            }
            string InputStr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    if (tekst.GetLength(0) == 1) Console.Write(tekst[i]);
                    else Console.WriteLine(tekst[i]);
                return Console.ReadLine();
            }
            bool InputBool(string tekst = "j/n", bool Cyes = true, bool Cno = false)
            {
                Console.WriteLine(tekst);
                switch (Char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'y':
                    case 'j': return Cyes;
                    case 'n': return Cno;
                }
                return false;
            }
            int InputInt(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return int.Parse(Console.ReadLine());
            }
            double InputDbl(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return double.Parse(Console.ReadLine());
            }
        }
    }
}
