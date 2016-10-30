using CR_DeckAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClashResources
{
    public static class DeckList
    {
        public static List<Deck> getRecommendedDecks()
        {

            var r = new List<Deck>();

            r.Add(new Deck("Mortar","Mortar, Barbarians, Minion Horde, Skeletons, Arrows, Fireball, Inferno Tower, Elixir Collector"));
            r.Add(new Deck("HogCycle", "Hog Rider, Princess, Mini Pekka, Ice Spirit, Skeletons, Zap, Fireball, Elixir Collector"));
            r.Add(new Deck("GWRage", "Giant, Witch, Rage, Mini Pekka, Musketeer, Minions, Fire Spirits, Zap"));
            r.Add(new Deck("Payfecta", "Miner, Ice Wizard, Princess, Mini Pekka, Zap, Inferno Tower, Goblins, Fire Spirits"));


            return r;
        }
    }
}
