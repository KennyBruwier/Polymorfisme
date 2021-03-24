using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorfisme
{
    public class Magic
    {
        
    }
    public enum SpellEffect
    {
        burn,
        freeze,
        push,
        crush
    }

    public class Manager
    {
        public List<Card> cards = new List<Card>();
    }

    public class Card
    {
        public int cost;
    }

    public class CreatureCard : Card
    {
        public int attack;
        public int health;
        public CreatureCard(int attack, int health)
        {
            this.attack = attack;
            this.health = health;
        }
    }

    public class SpellCard : Card
    {
        public SpellEffect effect;
        public SpellCard(SpellEffect spellEffect)
        {
            effect = spellEffect;
        }
    }
    public class Land : Card
    {
        public string Terrain;
        public Land(string terrain)
        {
            Terrain = terrain;
        }
    }
    public class Articfact : Card
    {
        public string Artifact_effect;
        public Articfact(string effect)
        {
            Artifact_effect = effect;
        }
    }
}
