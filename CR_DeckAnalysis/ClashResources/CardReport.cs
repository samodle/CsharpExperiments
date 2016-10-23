using Newtonsoft.Json;
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

        public int Arena { get; set; } = -1;


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
                case "graveyard":
                    Cost = 5;
                    Rarity = CardRarity.Legendary;
                    Arena = 5;
                    break;

                case "mirror":
                    Cost = -100;
                    Rarity = CardRarity.Epic;
                    Arena = 5;
                    break;

                case "ice spirit":
                    Cost = 1;
                    Rarity = CardRarity.Common;
                    Arena = 8;
                    break;

                case "skeletons":
                    Cost = 1;
                    Rarity = CardRarity.Common;
                    Arena = 2;
                    break;

                case "fire spirits":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    Arena = 5;
                    break;

                case "goblins":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    Arena = 1;
                    break;

                case "zap":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    Arena = 5;
                    break;

                case "spear goblins":
                    Cost = 2;
                    Rarity = CardRarity.Common;
                    Arena = 1;
                    break;

                case "minions":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 2;
                    break;

                case "arrows":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 0;
                    break;

                case "bomber":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 0;
                    break;

                case "cannon":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 3;
                    break;

                case "archers":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 0;
                    break;

                case "knight":
                    Cost = 3;
                    Rarity = CardRarity.Common;
                    Arena = 0;
                    break;

                case "tesla":
                    Cost = 4;
                    Rarity = CardRarity.Common;
                    Arena = 4;
                    break;

                case "mortar":
                    Cost = 4;
                    Rarity = CardRarity.Common;
                    Arena = 6;
                    break;

                case "minion horde":
                    Cost = 5;
                    Rarity = CardRarity.Common;
                    Arena = 4;
                    break;

                case "barbarians":
                    Cost = 5;
                    Rarity = CardRarity.Common;
                    Arena = 3;
                    break;

                case "royal giant":
                    Cost = 6;
                    Rarity = CardRarity.Common;
                    Arena = 7;
                    break;

                case "tombstone":
                    Cost = 3;
                    Rarity = CardRarity.Rare;
                    Arena = 2;
                    break;

                case "mini pekka":
                    Name = "mini p.e.k.k.a";
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 0;
                    break;

                case "mini p.e.k.k.a":

                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 0;
                    break;

                case "valkyrie":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 1;
                    break;

                case "musketeer":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 0;
                    break;

                case "fireball":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 0;
                    break;

                case "furnace":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 5;
                    break;

                case "hog rider":
                    Cost = 4;
                    Rarity = CardRarity.Rare;
                    Arena = 4;
                    break;

                case "wizard":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 5;
                    break;

                case "giant":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 0;
                    break;

                case "bomb tower":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 2;
                    break;

                case "inferno tower":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 4;
                    break;

                case "inferno":
                    Name = "inferno tower";
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 4;
                    break;

                case "goblin hut":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 1;
                    break;

                case "elixir collector":
                    Cost = 6;
                    Rarity = CardRarity.Rare;
                    Arena = 6;
                    break;

                case "rocket":
                    Cost = 6;
                    Rarity = CardRarity.Rare;
                    Arena = 3;
                    break;

                case "barbarian hut":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 3;
                    break;

                case "three musketeers":
                    Cost = 5;
                    Rarity = CardRarity.Rare;
                    Arena = 7;
                    break;

                case "rage":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    Arena = 3;
                    break;

                case "goblin barrel":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    Arena = 1;
                    break;

                case "guards":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    Arena = 7;
                    break;

                case "dark prince":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    Arena = 7;
                    break;

                case "poison":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    Arena = 5;
                    break;

                case "baby dragon":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    Arena = 0;
                    break;

                case "skeleton army":
                    Cost = 3;
                    Rarity = CardRarity.Epic;
                    Arena = 0;
                    break;

                case "freeze":
                    Cost = 4;
                    Rarity = CardRarity.Epic;
                    Arena = 4;
                    break;

                case "prince":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    Arena = 0;
                    break;

                case "witch":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    Arena = 0;
                    break;

                case "balloon":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    Arena = 2;
                    break;

                case "lightning":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    Arena = 1;
                    break;

                case "bowler":
                    Cost = 5;
                    Rarity = CardRarity.Epic;
                    Arena = 8;
                    break;

                case "giant skeleton":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    Arena = 2;
                    break;

                case "x-bow":
                    Cost = 6;
                    Rarity = CardRarity.Epic;
                    Arena = 3;
                    break;

                case "pekka":
                    Name = "p.e.k.k.a";
                    Cost = 7;
                    Rarity = CardRarity.Epic;
                    Arena = 4;
                    break;

                case "p.e.k.k.a":
                    Arena = 4;
                    Cost = 7;
                    Rarity = CardRarity.Epic;
                    break;

                case "golem":
                    Cost = 8;
                    Rarity = CardRarity.Epic;
                    Arena = 6;
                    break;

                case "log":
                    Cost = 2;
                    Rarity = CardRarity.Legendary;
                    Arena = 6;
                    break;

                case "miner":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    Arena = 6;
                    break;

                case "princess":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    Arena = 7;
                    break;

                case "ice wizard":
                    Cost = 3;
                    Rarity = CardRarity.Legendary;
                    Arena = 5;
                    break;

                case "lumberjack":
                    Cost = 4;
                    Rarity = CardRarity.Legendary;
                    Arena = 8;
                    break;

                case "sparky":
                    Cost = 6;
                    Rarity = CardRarity.Legendary;
                    Arena = 6;
                    break;

                case "lava hound":
                    Cost = 7;
                    Rarity = CardRarity.Legendary;
                    Arena = 4;
                    break;

                case "mega minion":
                    Cost = 3;
                    Rarity = CardRarity.Rare;
                    Arena = 7;
                    break;

                case "inferno dragon":
                    Cost = 4;
                    Rarity = CardRarity.Legendary;
                    Arena = 4;
                    break;

                case "ice golem":
                    Cost = 2;
                    Rarity = CardRarity.Rare;
                    Arena = 8;
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
