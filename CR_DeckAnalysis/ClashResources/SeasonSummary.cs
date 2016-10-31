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
        public List<CardReport> CardData { get; set; } = new List<CardReport>();

        public override string ToString()
        {
            return "#: " + SeasonNumber +  ", Avg. Cost: " + AvgCost + ", % Legendary: " + Pct_Legendary + ", % Epic: " + Pct_Epic + ", % Rare: " + Pct_Rare;
        }

        public List<string> CardNames = new List<string>(new string[] { "mirror", "ice spirit", "skeletons","fire spirits", "goblins", "zap", "spear goblins","minions", "arrows", "bomber", "cannon", "archers", "knight", "tesla", "mortar","minion horde", "barbarians","royal giant", "tombstone", "mini p.e.k.k.a", "valkyrie", "musketeer", "fireball", "furnace","hog rider", "wizard", "giant","bomb tower", "inferno tower", "goblin hut", "elixir collector", "rocket","barbarian hut", "three musketeers", "rage", "goblin barrel", "guards", "dark prince", "poison","baby dragon", "skeleton army","freeze", "prince","witch", "balloon", "lightning", "bowler", "giant skeleton", "x-bow","p.e.k.k.a", "golem", "log","miner", "princess","ice wizard", "lumberjack","sparky","lava hound", "mega minion", "inferno dragon" , "graveyard", "ice golem"});

        public List<CardReport> getEmptyComprehensiveCardReport()
        {
            List<CardReport> tmpList = new List<CardReport>();

            for(int i = 0; i < CardNames.Count; i++)
            {
                tmpList.Add(new CardReport(CardNames[i]));
            }

            return tmpList;
        }

        public double AvgCost { get; set; } = -1;
        public double Pct_Legendary { get; set; } = -1;
        public double Pct_Epic { get; set; } = -1;
        public double Pct_Rare { get; set; } = -1;
        public double Pct_Common { get; set; } = -1;

        public double getRarity(CardRarity r)
        {
            switch (r)
            {
                case CardRarity.Common:
                    return Pct_Common;
                case CardRarity.Epic:
                    return Pct_Epic;
                case CardRarity.Rare:
                    return Pct_Rare;
                case CardRarity.Legendary:
                    return Pct_Legendary;

                default:
                    return -1;
            }
        }


        public SeasonSummary(List<Deck> deckList, int seasonNum)
        {
            this.SeasonNumber = seasonNum;
            this.Top100Decks = deckList;

            initMetrics();
        }

        public int HowManyOfCard(string cardName)
        {
            for(int i = 0; i < CardData.Count; i++)
            {
                if (CardData[i].Name == cardName)
                    return CardData[i].NumberPresent;
            }
            return -1;
        }

        public int HowManyDekcsUsingCards(string cardName1, string cardName2)
        {
            int retInt = 0;
            for(int i = 0; i < Top100Decks.Count; i++)
            {
                if (Top100Decks[i].doesContainCard(cardName1) && Top100Decks[i].doesContainCard(cardName2))
                    retInt++;
            }
            return retInt;
        }

        public int HowManyDekcsUsingCards(string cardName1, string cardName2, string cardName3)
        {
            int retInt = 0;
            for (int i = 0; i < Top100Decks.Count; i++)
            {
                if (Top100Decks[i].doesContainCard(cardName1) && Top100Decks[i].doesContainCard(cardName2) && Top100Decks[i].doesContainCard(cardName3))
                    retInt++;
            }
            return retInt;
        }

        public int HowManyDekcsUsingCards(string cardName1, string cardName2, string cardName3, string cardName4)
        {
            int retInt = 0;
            for (int i = 0; i < Top100Decks.Count; i++)
            {
                if (Top100Decks[i].doesContainCard(cardName1) && Top100Decks[i].doesContainCard(cardName2) && Top100Decks[i].doesContainCard(cardName3) && Top100Decks[i].doesContainCard(cardName4))
                    retInt++;
            }
            return retInt;
        }

        public List<int> WhichDecksAreSameAsDeck(Deck testDeck)
        {
            List<int> rList = new List<int>();
            for(int i = 0; i < Top100Decks.Count; i++)
            {
                if (Top100Decks[i].doesContainCard(testDeck.Cards[0].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[1].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[2].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[3].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[4].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[5].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[6].Name) && Top100Decks[i].doesContainCard(testDeck.Cards[7].Name))
                {
                    rList.Add(i);
                }
            }
            return rList;
        }

        private void initMetrics()
        {
            AvgCost = Top100Decks.Sum(item => item.AvgCost()) / Top100Decks.Count;

            Pct_Legendary = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Legendary)) / Top100Decks.Count;

            Pct_Epic = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Epic)) / Top100Decks.Count;

            Pct_Rare = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Rare)) / Top100Decks.Count;

            Pct_Common = Top100Decks.Sum(item => item.getPctRarity(CardRarity.Common)) / Top100Decks.Count;

            initCardData();
        }

        private void initCardData()
        {
            for(int cardInc = 0; cardInc < CardNames.Count; cardInc++)
            {
                CardReport tmpReport = new CardReport(CardNames[cardInc]);
                for(int deckInc = 0; deckInc < Top100Decks.Count; deckInc++)
                {
                    if (Top100Decks[deckInc].doesContainCard(CardNames[cardInc]))
                        tmpReport.NumberPresent++;
                }
                CardData.Add(tmpReport);
            }
        }


    }
}




