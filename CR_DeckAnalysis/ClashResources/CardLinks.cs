using System;
using System.Collections.Generic;
using System.Text;

namespace ClashResources
{
    public static class CardLinks
    {
        public static List<Tuple<string, string, string>> getCardLinks()
        {
            List<Tuple<string, string, string>> tmpList = new List<Tuple<string, string, string>>();

            tmpList.Add(new Tuple<string, string, string>("sparky", "https://www.youtube.com/watch?v=WxErDxZ60Wc", "How To Counter Sparky"));
            tmpList.Add(new Tuple<string, string, string>("guards", "https://www.youtube.com/watch?v=PZvaq0CCRk8&list=PLz3utPLAut6GKZADTdg3zK6lh20D0KB6Z&index=7", "How To Use/Counter Sparky"));
            tmpList.Add(new Tuple<string, string, string>("miner", "https://www.youtube.com/watch?v=a-0S0M_CIq0&list=PLz3utPLAut6HAIeljNAfVYfQ_BL4G4ivS&index=9", "How To Use/Counter Miner"));
            tmpList.Add(new Tuple<string, string, string>("golem", "https://www.youtube.com/watch?v=WZ8VZdjDcJM&list=PLz3utPLAut6HAIeljNAfVYfQ_BL4G4ivS&index=10", "How To Counter Golem"));
            tmpList.Add(new Tuple<string, string, string>("princess", "https://www.reddit.com/r/ClashRoyale/comments/57x333/daily_card_discussion_oct_17_2016_princess/", "Card Discussion"));
            tmpList.Add(new Tuple<string, string, string>("giant", "https://www.reddit.com/r/ClashRoyale/comments/54wt9l/daily_discussion_sept_28_2016_giant/", "Card Discussion"));
            tmpList.Add(new Tuple<string, string, string>("mirror", "http://clashroyale.wikia.com/wiki/Mirror", "Stats/Overview"));
            tmpList.Add(new Tuple<string, string, string>("rage", "http://clashroyale.wikia.com/wiki/Rage", "Stats/Overview"));
            tmpList.Add(new Tuple<string, string, string>("arrows", "http://clashroyale.wikia.com/wiki/Arrows", "Stats/Overview"));
            tmpList.Add(new Tuple<string, string, string>("ice spirit", "https://www.youtube.com/watch?v=eXTidAqy5aU&index=8&list=PLz3utPLAut6GKZADTdg3zK6lh20D0KB6Z", "How To Use/Counter"));
            //   tmpList.Add(new Tuple<string, string, string>("", "", ""));
            //   https://www.youtube.com/watch?v=eXTidAqy5aU&index=8&list=PLz3utPLAut6GKZADTdg3zK6lh20D0KB6Z

            return tmpList;
        }
    }
}
