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
        public string Name { get {return myCard.Name; } }

        public int Cost { get { return myCard.Cost; } }

        public CardRarity Rarity { get { return myCard.Rarity; } }

        public int NumberPresent { get; set; } = 0;

        public int Arena { get { return myCard.Arena; } }

        public Card myCard { get; set; }// = new Card();


        public override string ToString()
        {
            return Name + " " + NumberPresent;
        }

        public CardReport(string name)
        {

            myCard = new Card(name);
            //this.Name = name.ToLower();

            //initFieldsFromName();
        }

    }
}
