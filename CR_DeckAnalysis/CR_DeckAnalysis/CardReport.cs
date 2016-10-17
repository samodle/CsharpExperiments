﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_DeckAnalysis
{

    public class CardGroupReport
    {
        public string Name1 { get; set; } = "";
        public string Name2 { get; set; } = "";
        public string Name3 { get; set; } = "";
        public string Name4 { get; set; } = "";
        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                if (Name3 == "")
                    return Name1 + " + " + Name2 ;
                else if(Name4 == "")
                    return Name1 + " + " + Name2 + " + " + Name3;
                else 
                    return Name1 + " + " + Name2 + " + " + Name3 + " + " + Name4;

            }
        }
        public double AvgNumberPresent { get; set; } = 0;
        public int LastNumberPresent { get; set; } = 0;

        public CardGroupReport() { }
        public CardGroupReport(string name1, string name2)
            {
            this.Name1 = name1;
            this.Name2 = name2;
            }
        public CardGroupReport(string name1, string name2, string name3)
        {
            this.Name1 = name1;
            this.Name2 = name2;
            this.Name3 = name3;
        }
        public CardGroupReport(string name1, string name2, string name3, string name4)
        {
            this.Name1 = name1;
            this.Name2 = name2;
            this.Name3 = name3;
            this.Name4 = name4;
        }


        public override string ToString()
        {
            return DisplayName + " Avg: " + AvgNumberPresent + " Last: " + LastNumberPresent;
        }

    }


    public class CardReport
    {
        public string Name { get; set; } = "";

        public int Cost { get; set; } = -1;

        public CardRarity Rarity { get; set; }

        public int NumberPresent { get; set; } = 0;


        public override string ToString()
        {
            return Name + " " + NumberPresent;
        }

        public CardReport(string name)
        {
            this.Name = name.ToLower();

            initFieldsFromName();
        }

        public void initFieldsFromName()
        {
            switch (this.Name)
            {
                case "mirror":
                    Cost = -100;
                    Rarity = CardRarity.Epic;
                    break;

                case "ice spirit":
                    Cost = 1;
                    Rarity = CardRarity.Common;
                    break;

                case "skeletons":
                    Cost = 1;
                    Rarity = CardRarity.Common;
                    break;

                case "fire spirits":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    break;

                case "goblins":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    break;

                case "zap":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    break;

                case "spear goblins":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    break;

                case "minions":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "arrows":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "bomber":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "cannon":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "archers":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "knight":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    break;

                case "tesla":
                    Cost = 4;
                    Rarity = CardRarity.Common;
                    break;

                case "mortar":
                    Cost = 4;
                    Rarity = CardRarity.Common;
                    break;

                case "minion horde":
                    Cost = 5;
                    Rarity = CardRarity.Common;
                    break;

                case "barbarians":
                    Cost = 5;
                    Rarity = CardRarity.Common;
                    break;

                case "royal giant":
                    Cost = 6;
                    Rarity = CardRarity.Common;
                    break;

                case "tombstone":
                    Cost = 3;
                    Rarity = CardRarity.Rare;
                    break;

                case "mini pekka":
                    Name = "mini p.e.k.k.a";
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "mini p.e.k.k.a":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "valkyrie":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "musketeer":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "fireball":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "furnace":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "hog rider":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    break;

                case "wizard":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "giant":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "bomb tower":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "inferno tower":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "inferno":
                    Name = "inferno tower";
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "goblin hut":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "elixir collector":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "rocket":
                    Cost = 6;
                    Rarity = CardRarity.Rare;
                    break;

                case "barbarian hut":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "three musketeers":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    break;

                case "rage":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    break;

                case "goblin barrel":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    break;

                case "guards":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    break;

                case "dark prince":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    break;

                case "poison":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    break;

                case "baby dragon":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    break;

                case "skeleton army":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    break;

                case "freeze":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    break;

                case "prince":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    break;

                case "witch":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    break;

                case "balloon":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    break;

                case "lightning":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    break;

                case "bowler":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    break;

                case "giant skeleton":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    break;

                case "x-bow":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    break;

                case "pekka":
                    Name = "p.e.k.k.a";
                    Cost = 7;
                    Rarity = CardRarity.Epic;
                    break;

                case "p.e.k.k.a":
                    Cost = 7;
                    Rarity = CardRarity.Epic;
                    break;

                case "golem":
                    Cost = 8;
                    Rarity = CardRarity.Epic;
                    break;

                case "log":
                    Cost = 2;
                    Rarity = CardRarity.Legendary;
                    break;

                case "miner":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    break;

                case "princess":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    break;

                case "ice wizard":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    break;

                case "lumberjack":
                    Cost = 4;
                    Rarity = CardRarity.Legendary;
                    break;

                case "sparky":
                    Cost = 6;
                    Rarity = CardRarity.Legendary;
                    break;

                case "lava hound":
                    Cost = 7;
                    Rarity = CardRarity.Legendary;
                    break;

                case "mega minion":
                    Cost = 3;
                    Rarity = CardRarity.Rare;
                    break;

                case "inferno dragon":
                    Cost = 4;
                    Rarity = CardRarity.Legendary;
                    break;

                default:
                    /// Console.Write(this.Name);
                  //  Cost = 50;
                   // Rarity = CardRarity.Common;
                   // break;
                   throw new Exception("Unknown Name: " + this.Name);
            }
        }


    }
}
