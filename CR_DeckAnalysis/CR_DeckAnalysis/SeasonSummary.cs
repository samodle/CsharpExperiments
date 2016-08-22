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

        public SeasonSummary(List<Deck> deckList, int seasonNum)
        {

        }
    }
}
