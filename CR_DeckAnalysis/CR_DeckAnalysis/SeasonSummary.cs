using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_DeckAnalysis
{
    public class SeasonSummary
    {
        public int SeasonNumber { get; set; }
        public List<Deck> Top100Decks { get; set; } = new List<Deck>();

        public override string ToString()
        {
            return "#: " + SeasonNumber +  ", Avg. Cost: " + AvgCost + ", % Legendary: " + Pct_Legendary + ", % Epic: " + Pct_Epic + ", % Rare: " + Pct_Rare;
        }


        public double AvgCost { get; set; } = -1;
        public double Pct_Legendary { get; set; } = -1;
        public double Pct_Epic { get; set; } = -1;
        public double Pct_Rare { get; set; } = -1;
        public double Pct_Common { get; set; } = -1;

        public SeasonSummary(List<Deck> deckList, int seasonNum)
        {
            this.SeasonNumber = seasonNum;
            this.Top100Decks = deckList;

            initMetrics();
        }

        private void initMetrics()
        {
            AvgCost = Top100Decks.Sum(item => item.AvgCost()) / Top100Decks.Count;

            Pct_Legendary = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Legendary)) / Top100Decks.Count;

            Pct_Epic = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Epic)) / Top100Decks.Count;

            Pct_Rare = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Rare)) / Top100Decks.Count;

            Pct_Common = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Common)) / Top100Decks.Count;

        }


    }
}
