﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_DeckAnalysis
{
    public class Deck
    {
        #region Variables & Properties
        public int Rank { get; set; } = -1; //deck position in top 100
        public List<Card> Cards { get; set; } = new List<Card>();
        public int Season { get; set; } = -1;
        public string PlayerName { get; set; } = "";
        #endregion

        public bool doesContainCard(string cardName)
        {
            for(int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Name == cardName)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            if(Cards.Count < 8)
                return base.ToString();

            return Rank + ": " + Rank + ", Avg. Cost: " + AvgCost() ;
        }

        public string toString_Cards()
        {
            string x = "";
            for(int i = 0; i < Cards.Count - 1; i++)
            {
                x += Cards[i].Name + ", ";
            }
            x += Cards[Cards.Count - 1].Name;
            return x;
        }

        public void addCard(Card c)
        {
            Cards.Add(c);
        }

        public double getPctRarity(CardRarity rarity)
        {
            double tmpSum = 0.0;
            for(int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Rarity == rarity)
                    tmpSum += 1;
            }
            return tmpSum * 100 / 8;
        }

        public double AvgCost()
        {
         //   if (Cards.Count != 8)
         //       throw new Exception("Incomplete Deck");

            double workingSum = 0;
            bool containsMirror = false;

            for(int i = 0; i < Cards.Count; i++)
            {
                if(Cards[i].Name != "mirror")
                {
                    workingSum += Cards[i].Cost;
                }
                else
                {
                 //   if (containsMirror)
                 //       throw new Exception("Duplicate Card");

                    containsMirror = true;
                }
            }


            if (containsMirror)
            {
                double tmpAvg = workingSum / Cards.Count;
                workingSum += (tmpAvg + 1);
            }

            return workingSum / Cards.Count;

        }

        public Deck() { }
        public Deck(int season, int rank)
        {
            this.Season = season;
            this.Rank = rank;
            this.PlayerName = rank.ToString();
        }
        
    }
}