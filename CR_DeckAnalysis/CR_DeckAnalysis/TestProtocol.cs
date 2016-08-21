using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_DeckAnalysis
{
    public static class TestProtocol
    {

        public static void startTest()
        {
            bool isExportTest = false;

            if (isExportTest)
            {
                List<Deck> deckList = new List<Deck>();
                int season = 2;

                Card p = new Card("princess");
                Card m = new Card("miner");
                Card mp = new Card("mini pekka");
                Card g = new Card("giant");
                Card mi = new Card("minions");
                Card z = new Card("zap");
                Card po = new Card("poison");
                Card a = new Card("arrows");

                for (int j = 0; j < 100; j++)
                {
                    Deck d = new Deck(season, j + 1);
                    d.addCard(p);
                    d.addCard(m);
                    d.addCard(mp);
                    d.addCard(mi);
                    d.addCard(g);
                    d.addCard(po);
                    d.addCard(z);
                    d.addCard(a);

                    deckList.Add(d);
                }

                IO.DeckList_Export(deckList, "C:\\Users\\odle.so.1\\Desktop\\decklist");
            }
            else
            {
                List<Deck> importList = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\10.txt");
            }



        
        }
    }
}
