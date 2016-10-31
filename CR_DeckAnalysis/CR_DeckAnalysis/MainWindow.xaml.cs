using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

using System.Net;
using ClashResources;

namespace CR_DeckAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public static class CombExtns
    {

        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var remainingItems = list.AllExcept(startingElementIndex);

                    foreach (var permutationOfRemainder in remainingItems.Permute())
                    {
                        yield return startingElement.Concat(permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null)
            {
                yield break;
            }

            foreach (var item in secondSequence)
            {
                yield return item;
            }
        }

        private static IEnumerable<T> AllExcept<T>(this IEnumerable<T> sequence, int indexToSkip)
        {
            if (sequence == null)
            {
                yield break;
            }

            var index = 0;

            foreach (var item in sequence.Where(item => index++ != indexToSkip))
            {
                yield return item;
            }
        }






        public static List<List<T>> GetAllCombos<T>(this List<T> initialList)
        {
            var ret = new List<List<T>>();

            // The final number of sets will be 2^N (or 2^N - 1 if skipping empty set)
            int setCount = Convert.ToInt32(Math.Pow(2, initialList.Count));

            // Start at 1 if you do not want the empty set
            for (int mask = 0; mask < setCount; mask++)
            {
                var nestedList = new List<T>();
                for (int j = 0; j < initialList.Count; j++)
                {
                    // Each position in the initial list maps to a bit here
                    var pos = 1 << j;
                    if ((mask & pos) == pos) { nestedList.Add(initialList[j]); }
                }
                ret.Add(nestedList);
            }
            return ret;
        }
    }


    public partial class MainWindow : Window
    {
        private SolidColorBrush Brush_TabSelected = new SolidColorBrush(Color.FromRgb(37, 160, 218));
        private SolidColorBrush Brush_TabUnselected = new SolidColorBrush(Color.FromRgb(202, 221, 228));

        List<SeasonSummary> DeckSummaries = new List<SeasonSummary>();

        List<List<int>> CardTrend_ChartYVals = new List<List<int>>();
        List<List<string>> CardTrend_ChartXVals = new List<List<string>>();
        List<string> CardTrend_SeriesNames = new List<string>();

        public ObservableCollection<SeasonSummary> DeckSummaries_Visible { get; set; } = new ObservableCollection<SeasonSummary>();
        public ObservableCollection<CardReport> SelectedDecks_Visible { get; set; } = new ObservableCollection<CardReport>();


        //this is for pairs and trio's of cards
        public List<Tuple<string, string>> TopCardPairs = new List<Tuple<string, string>>();
        public List<Tuple<string, string, string>> TopCardTrios = new List<Tuple<string, string, string>>();
        public List<Tuple<string, string, string, string>> TopCardQuads = new List<Tuple<string, string, string, string>>();

        public List<List<double>> TopCardPairs_Usage = new List<List<double>>();
        public List<List<double>> TopCardTrios_Usage = new List<List<double>>();
        public List<List<double>> TopCardQuads_Usage = new List<List<double>>();

        public ObservableCollection<CardGroupReport> TopCardPairs_Display { get; set; } = new ObservableCollection<CardGroupReport>();
        public ObservableCollection<CardGroupReport> TopCardTrios_Display { get; set; } = new ObservableCollection<CardGroupReport>();
        public ObservableCollection<CardGroupReport> TopCardQuads_Display { get; set; } = new ObservableCollection<CardGroupReport>();




        public MainWindow()
        {
            InitializeComponent();
            //   startTest();


        }
        private void startTest(object sender, EventArgs e)
        {

            List<string> CardNames = new List<string>(new string[] { "spear goblins", "skeletons", "fire spirits", "goblins", "zap",  "minions", "ice spirit", "arrows", "bomber", "cannon", "archers", "knight", "tesla", "mortar", "minion horde", "barbarians", "royal giant", "tombstone", "mini p.e.k.k.a", "valkyrie", "musketeer", "fireball", "furnace", "hog rider", "wizard", "giant", "bomb tower", "inferno tower", "goblin hut", "elixir collector", "rocket", "barbarian hut", "three musketeers", "rage", "goblin barrel", "guards", "dark prince", "poison", "baby dragon", "skeleton army", "freeze", "prince", "witch", "balloon", "lightning", "bowler", "giant skeleton", "x-bow", "P.E.K.K.A", "golem", "the log", "miner", "princess", "ice wizard", "lumberjack", "sparky", "lava hound", "mega minion", "inferno dragon", "graveyard", "ice golem", "mirror" });

            // List<CardWebData> xx = new List<CardWebData>();

            var xxx = DeckList.getRecommendedDecks();



            List<Deck> dList = DeckList.getRecommendedDecks();

            for(int i = 0; i < dList.Count; i++)
            {
                var fileList = new string[8];
                for(int j = 0; j < dList[i].Cards.Count; j++)
                {
                    string c = dList[i].Cards[j].Name.Replace(' ', '-');
                    c = c.Replace(".", "");
                    fileList[j] = "C:/Users/odle.so.1/Downloads/cards/img/" + c + ".png";

                 //   System.Drawing.Image image =  System.Drawing.Image.FromFile("C:/Users/odle.so.1/Downloads/cards/img/" + c + ".png");
                 //   System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("img/" + c + ".png");
                }

                var im = ImageManip.CombineBitmap(fileList);
                im.Save("C:/Users/odle.so.1/Downloads/cards/img/decks/" +  dList[i].Nickname + ".png");
            }















            //var xy = WebCrawl.HtmlPull.htmlTest();

/*
            for(int i = 0; i < CardNames.Count; i++)
            {
                var x = WebCrawl.HtmlPull.getCardFromWebData(CardNames[i], getURLforCard(CardNames[i]));
                xx.Add(x);
            }
            */
           // var x = WebCrawl.HtmlPull.getCardFromWebData("stab gobs", "http://clashroyale.wikia.com/wiki/Spear_Goblins");



            // setCardImageSource("mini p.e.k.k.a");
            startTest();
            //  populateCardComboData();
        }

        private static string getURLforCard(string cardName)
        {
            if (cardName.Contains(" "))
            {
                string n = char.ToUpper(cardName[0]) + cardName.Substring(1);
                n = n.Replace(" ", "_");

                int i = n.IndexOf("_");

                string m = n.Substring(0, i + 1) + char.ToUpper(n[i+1]) + n.Substring(i+2);

                return "http://clashroyale.wikia.com/wiki/" + m;
            }
            else
            {
                return "http://clashroyale.wikia.com/wiki/" + char.ToUpper(cardName[0]) + cardName.Substring(1);
            }

        }


        public static string ReplaceAllSpaces(string str)
        {
            string str1 = str.Replace(".", "");
            return Regex.Replace(str1, @"\s+", "-");
        }

        public void startTest()
        {
            List<Deck> importList1 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\1.txt"));
            List<Deck> importList3 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\3.txt"));
            List<Deck> importList4 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\4.txt"));
            List<Deck> importList6 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\6.txt"));
            List<Deck> importList7 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\7.txt"));
            List<Deck> importList8 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\8.txt"));
            List<Deck> importList9 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\9.txt"));
            List<Deck> importList10 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\10.txt"));
            List<Deck> importList11 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\11.txt"));
            List<Deck> importList12 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\12.txt"));
            List<Deck> importList13 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\13.txt"));
            List<Deck> importList14 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\14.txt"));
            List<Deck> importList15 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\15.txt"));

            DeckSummaries.Add(new SeasonSummary(importList1, 1));
            DeckSummaries.Add(new SeasonSummary(importList3, 3));
            DeckSummaries.Add(new SeasonSummary(importList4, 4));
            DeckSummaries.Add(new SeasonSummary(importList6, 6));
            DeckSummaries.Add(new SeasonSummary(importList7, 7));
            DeckSummaries.Add(new SeasonSummary(importList8, 8));
            DeckSummaries.Add(new SeasonSummary(importList9, 9));
            DeckSummaries.Add(new SeasonSummary(importList10, 10));
            DeckSummaries.Add(new SeasonSummary(importList11, 11));
            DeckSummaries.Add(new SeasonSummary(importList12, 12));
            DeckSummaries.Add(new SeasonSummary(importList13, 13));
            DeckSummaries.Add(new SeasonSummary(importList14, 14));
            DeckSummaries.Add(new SeasonSummary(importList15, 15));

            for (int i = 0; i < DeckSummaries.Count; i++)
            {
                DeckSummaries_Visible.Add(DeckSummaries[i]);
            }

            var tmpList = DeckSummaries[0].getEmptyComprehensiveCardReport();
            for (int i = 0; i < tmpList.Count; i++)
            {
                SelectedDecks_Visible_T2.Add(tmpList[i]);
            }


            //   populateCardComboData();

        }

        private void populateCardComboData()
        {
            bool calculateCombinations = false;
            bool calculateDisplayReports = false;

            List<string> Names = DeckSummaries[0].CardNames;

            //get pairs names
            for (int i = 0; i < Names.Count - 1; i++)
            {
                for (int j = i + 1; j < Names.Count; j++)
                {
                    TopCardPairs.Add(new Tuple<string, string>(Names[i], Names[j]));
                }
            }

            //get pairs numbers
            for (int i = 0; i < TopCardPairs.Count; i++)
            {
                CardGroupReport tmpReport = new CardGroupReport(TopCardPairs[i].Item1, TopCardPairs[i].Item2);
                List<int> tmpList = new List<int>();
                for (int j = 0; j < DeckSummaries.Count; j++)
                {
                    tmpList.Add(DeckSummaries[j].HowManyDekcsUsingCards(TopCardPairs[i].Item1, TopCardPairs[i].Item2));
                }

                tmpReport.AvgNumberPresent = tmpList.Average();
                tmpReport.LastNumberPresent = tmpList[tmpList.Count - 1];

                TopCardPairs_Display.Add(tmpReport);
            }

            if (calculateCombinations)
            {
                //trios!
                for (int i = 0; i < TopCardPairs.Count; i++)
                {
                    for (int j = 0; j < Names.Count; j++)
                    {
                        if (Names[j] != TopCardPairs[i].Item1 && Names[j] != TopCardPairs[i].Item2)
                        {
                            bool weGood = true;
                            for (int k = 0; k < TopCardTrios.Count; k++)
                            {
                                if (Names[j] == TopCardTrios[k].Item1 || Names[j] == TopCardTrios[k].Item2 || Names[j] == TopCardTrios[k].Item3)
                                {
                                    if (TopCardPairs[i].Item1 == TopCardTrios[k].Item1 || TopCardPairs[i].Item1 == TopCardTrios[k].Item2 || TopCardPairs[i].Item1 == TopCardTrios[k].Item3)
                                    {
                                        if (TopCardPairs[i].Item2 == TopCardTrios[k].Item1 || TopCardPairs[i].Item2 == TopCardTrios[k].Item2 || TopCardPairs[i].Item2 == TopCardTrios[k].Item3)
                                        {
                                            weGood = false;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (weGood)
                                TopCardTrios.Add(new Tuple<string, string, string>(TopCardPairs[i].Item1, TopCardPairs[i].Item2, Names[j]));
                        }
                    }
                }
                for (int i = 0; i < TopCardTrios.Count; i++)
                {
                    CardGroupReport tmpReport = new CardGroupReport(TopCardTrios[i].Item1, TopCardTrios[i].Item2, TopCardTrios[i].Item3);
                    List<int> tmpList = new List<int>();
                    for (int j = 0; j < DeckSummaries.Count; j++)
                    {
                        tmpList.Add(DeckSummaries[j].HowManyDekcsUsingCards(TopCardTrios[i].Item1, TopCardTrios[i].Item2, TopCardTrios[i].Item3));
                    }

                    tmpReport.AvgNumberPresent = tmpList.Average();
                    tmpReport.LastNumberPresent = tmpList[tmpList.Count - 1];

                    TopCardTrios_Display.Add(tmpReport);
                }
            }
            else
            {
                //Path.Combine(Environment.CurrentDirectory, @"RawData\1.txt")
                TopCardTrios = IO.StringList_Import_3(Path.Combine(Environment.CurrentDirectory, @"AggData\cardTrios"));
                if (!calculateDisplayReports)
                {
                    TopCardTrios_Display = IO.CardGroupReports_Import(Path.Combine(Environment.CurrentDirectory, @"AggData\cardTriosREPORT"));
                    /*  ObservableCollection<CardGroupReport> tmpR = IO.CardGroupReports_Import(Path.Combine(Environment.CurrentDirectory, @"AggData\cardTriosREPORT"));
                      for (int i = 0; i < tmpR.Count; i++)
                      {
                          TopCardTrios_Display.Add(tmpR[i]);
                      }*/
                }
            }

            if (calculateDisplayReports)
            {
                for (int i = 0; i < TopCardTrios.Count; i++)
                {
                    CardGroupReport tmpReport = new CardGroupReport(TopCardTrios[i].Item1, TopCardTrios[i].Item2, TopCardTrios[i].Item3);
                    List<int> tmpList = new List<int>();
                    for (int j = 0; j < DeckSummaries.Count; j++)
                    {
                        tmpList.Add(DeckSummaries[j].HowManyDekcsUsingCards(TopCardTrios[i].Item1, TopCardTrios[i].Item2, TopCardTrios[i].Item3));
                    }

                    tmpReport.AvgNumberPresent = tmpList.Average();
                    tmpReport.LastNumberPresent = tmpList[tmpList.Count - 1];

                    TopCardTrios_Display.Add(tmpReport);
                }

                IO.CardGroupReports_Export(TopCardTrios_Display, "C:\\Users\\odle.so.1\\Desktop\\cardTriosREPORT");
            }

            if (calculateCombinations)
                IO.StringList_Export(TopCardTrios, "C:\\Users\\odle.so.1\\Desktop\\cardTrios");

            if (calculateCombinations)
            {
                //quads!
                for (int i = 0; i < TopCardTrios.Count; i++)
                {
                    for (int j = 0; j < Names.Count; j++)
                    {
                        if (Names[j] != TopCardTrios[i].Item1 && Names[j] != TopCardTrios[i].Item2 && Names[j] != TopCardTrios[i].Item3)
                        {
                            bool weGood = true;
                            for (int k = 0; k < TopCardQuads.Count; k++)
                            {
                                if (Names[j] == TopCardQuads[k].Item1 || Names[j] == TopCardQuads[k].Item2 || Names[j] == TopCardQuads[k].Item3 || Names[j] == TopCardQuads[k].Item4)
                                {
                                    if (TopCardTrios[i].Item1 == TopCardQuads[k].Item1 || TopCardTrios[i].Item1 == TopCardQuads[k].Item2 || TopCardTrios[i].Item1 == TopCardQuads[k].Item3 || TopCardTrios[i].Item1 == TopCardQuads[k].Item4)
                                    {
                                        if (TopCardTrios[i].Item2 == TopCardQuads[k].Item1 || TopCardTrios[i].Item2 == TopCardQuads[k].Item2 || TopCardTrios[i].Item2 == TopCardQuads[k].Item3 || TopCardTrios[i].Item2 == TopCardQuads[k].Item4)
                                        {
                                            if (TopCardTrios[i].Item3 == TopCardQuads[k].Item1 || TopCardTrios[i].Item3 == TopCardQuads[k].Item2 || TopCardTrios[i].Item3 == TopCardQuads[k].Item3 || TopCardTrios[i].Item3 == TopCardQuads[k].Item4)
                                            {
                                                weGood = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (weGood)
                                TopCardQuads.Add(new Tuple<string, string, string, string>(TopCardTrios[i].Item1, TopCardTrios[i].Item2, TopCardTrios[i].Item3, Names[j]));
                        }
                    }
                }

                for (int i = 0; i < TopCardQuads.Count; i++)
                {
                    CardGroupReport tmpReport = new CardGroupReport(TopCardQuads[i].Item1, TopCardQuads[i].Item2, TopCardQuads[i].Item3, TopCardQuads[i].Item4);
                    List<int> tmpList = new List<int>();
                    for (int j = 0; j < DeckSummaries.Count; j++)
                    {
                        tmpList.Add(DeckSummaries[j].HowManyDekcsUsingCards(TopCardQuads[i].Item1, TopCardQuads[i].Item2, TopCardQuads[i].Item3, TopCardQuads[i].Item4));
                    }

                    tmpReport.AvgNumberPresent = tmpList.Average();
                    tmpReport.LastNumberPresent = tmpList[tmpList.Count - 1];

                    TopCardQuads_Display.Add(tmpReport);
                }

            }
            else
            {
                TopCardQuads = IO.StringList_Import_4(Path.Combine(Environment.CurrentDirectory, @"AggData\cardQuads"));
                if (!calculateDisplayReports)
                {
                    ObservableCollection<CardGroupReport> tmpR = IO.CardGroupReports_Import(Path.Combine(Environment.CurrentDirectory, @"AggData\cardQuadsREPORT"));
                    //  for (int i = 0; i < tmpR.Count; i++)
                    // {
                    //    TopCardQuads_Display.Add(tmpR[i]);
                    // }
                    TopCardQuads_Display = new ObservableCollection<CardGroupReport>(tmpR);
                }
                // TopCardQuads_Display = IO.CardGroupReports_Import("C:\\Users\\odle.so.1\\Desktop\\cardQuadsREPORT");
            }

            if (calculateDisplayReports)
            {
                for (int i = 0; i < TopCardQuads.Count; i++)
                {
                    CardGroupReport tmpReport = new CardGroupReport(TopCardQuads[i].Item1, TopCardQuads[i].Item2, TopCardQuads[i].Item3, TopCardQuads[i].Item4);
                    List<int> tmpList = new List<int>();
                    for (int j = 0; j < DeckSummaries.Count; j++)
                    {
                        tmpList.Add(DeckSummaries[j].HowManyDekcsUsingCards(TopCardQuads[i].Item1, TopCardQuads[i].Item2, TopCardQuads[i].Item3, TopCardQuads[i].Item4));
                    }

                    tmpReport.AvgNumberPresent = tmpList.Average();
                    tmpReport.LastNumberPresent = tmpList[tmpList.Count - 1];

                    TopCardQuads_Display.Add(tmpReport);
                }
                IO.CardGroupReports_Export(TopCardQuads_Display, "C:\\Users\\odle.so.1\\Desktop\\cardQuadsREPORT");
            }

            if (calculateCombinations)
                IO.StringList_Export(TopCardQuads, "C:\\Users\\odle.so.1\\Desktop\\cardQuads");

            Cards_GridView_T5.ItemsSource = TopCardQuads_Display;
            Cards_GridView_T4.ItemsSource = TopCardTrios_Display;


        }


        /*

        // Generate permutations.
        private List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            // Make an array to hold the
            // permutation we are building.
            T[] current_permutation = new T[items.Count];

            // Make an array to tell whether
            // an item is in the current selection.
            bool[] in_selection = new bool[items.Count];

            // Make a result list.
            List<List<T>> results = new List<List<T>>();

            // Build the combinations recursively.
            PermuteItems<T>(items, in_selection,
                current_permutation, results, 0);

            // Return the results.
            return results;
        }

        // Recursively permute the items that are
        // not yet in the current selection.
        private void PermuteItems<T>(List<T> items, bool[] in_selection,
            T[] current_permutation, List<List<T>> results,
            int next_position)
        {
            // See if all of the positions are filled.
            if (next_position == items.Count)
            {
                // All of the positioned are filled.
                // Save this permutation.
                results.Add(current_permutation.ToList());
            }
            else
            {
                // Try options for the next position.
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        // Add this item to the current permutation.
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];

                        // Recursively fill the remaining positions.
                        PermuteItems<T>(items, in_selection,
                            current_permutation, results,
                            next_position + 1);

                        // Remove the item from the current permutation.
                        in_selection[i] = false;
                    }
                }
            }
        }
        */
        #region UI Nav
        private void MenuTabClicked(object sender, EventArgs e)
        {
            //set the tab colors 
            MenuTab.Background = Brush_TabSelected;
            RawDataTab.Background = Brush_TabUnselected;
            FinalDataTab.Background = Brush_TabUnselected;

            //hide and unhide accordingly
            MenuTabCanvas.Visibility = Visibility.Visible;
            RawTabCanvas.Visibility = Visibility.Hidden;
            FinalTabCanvas.Visibility = Visibility.Hidden;
        }

        private void RawTabClicked(object sender, EventArgs e)
        {
            if (true)
            {
                //   Cards_GridView_T5.ItemsSource = TopCardQuads_Display;
                //set the tab colors 
                MenuTab.Background = Brush_TabUnselected;
                RawDataTab.Background = Brush_TabSelected;
                FinalDataTab.Background = Brush_TabUnselected;

                //hide and unhide accordingly
                MenuTabCanvas.Visibility = Visibility.Hidden;
                RawTabCanvas.Visibility = Visibility.Visible;
                FinalTabCanvas.Visibility = Visibility.Hidden;
            }
        }

        private void FinalTabClicked(object sender, EventArgs e)
        {
            if (true)
            {
                //set the tab colors 
                MenuTab.Background = Brush_TabUnselected;
                RawDataTab.Background = Brush_TabUnselected;
                FinalDataTab.Background = Brush_TabSelected;

                //hide and unhide accordingly
                MenuTabCanvas.Visibility = Visibility.Hidden;
                RawTabCanvas.Visibility = Visibility.Hidden;
                FinalTabCanvas.Visibility = Visibility.Visible;
            }
            /*  else
              {
                  System.Windows.MessageBox.Show("You need to generate some output data before you do that!");
                  MenuTabClicked(new object(), new EventArgs());
              }*/
        }



        private void SingleClicked(object sender, EventArgs e)
        {
            //set the tab colors 
            SingleClick.Background = Brush_TabSelected;
            DoubleClick.Background = Brush_TabUnselected;
            TrippleClick.Background = Brush_TabUnselected;
            QuadClick.Background = Brush_TabUnselected;

            //hide and unhide accordingly
            Cards_GridView_T2.Visibility = Visibility.Visible;
            Cards_GridView_T3.Visibility = Visibility.Hidden;
            Cards_GridView_T4.Visibility = Visibility.Hidden;
            Cards_GridView_T5.Visibility = Visibility.Hidden;
        }

        private void DoubleClicked(object sender, EventArgs e)
        {
            //set the tab colors 
            SingleClick.Background = Brush_TabUnselected;
            DoubleClick.Background = Brush_TabSelected;
            TrippleClick.Background = Brush_TabUnselected;
            QuadClick.Background = Brush_TabUnselected;

            //hide and unhide accordingly
            Cards_GridView_T2.Visibility = Visibility.Hidden;
            Cards_GridView_T3.Visibility = Visibility.Visible;
            Cards_GridView_T4.Visibility = Visibility.Hidden;
            Cards_GridView_T5.Visibility = Visibility.Hidden;
        }

        private void TrippleClicked(object sender, EventArgs e)
        {
            //set the tab colors 
            SingleClick.Background = Brush_TabUnselected;
            DoubleClick.Background = Brush_TabUnselected;
            TrippleClick.Background = Brush_TabSelected;
            QuadClick.Background = Brush_TabUnselected;

            //hide and unhide accordingly
            Cards_GridView_T2.Visibility = Visibility.Hidden;
            Cards_GridView_T3.Visibility = Visibility.Hidden;
            Cards_GridView_T4.Visibility = Visibility.Visible;
            Cards_GridView_T5.Visibility = Visibility.Hidden;
        }

        private void QuadClicked(object sender, EventArgs e)
        {
            //set the tab colors 
            SingleClick.Background = Brush_TabUnselected;
            DoubleClick.Background = Brush_TabUnselected;
            TrippleClick.Background = Brush_TabUnselected;
            QuadClick.Background = Brush_TabSelected;

            //hide and unhide accordingly
            Cards_GridView_T2.Visibility = Visibility.Hidden;
            Cards_GridView_T3.Visibility = Visibility.Hidden;
            Cards_GridView_T4.Visibility = Visibility.Hidden;
            Cards_GridView_T5.Visibility = Visibility.Visible;
        }




        #endregion

        #region TAB 1


        #region Card Images Sources
        private void setCardImageSource(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage.Source = bitmap;
        }
        private void setCardImageSource1(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage1.Source = bitmap;
        }
        private void setCardImageSource2(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage2.Source = bitmap;
        }
        private void setCardImageSource3(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage3.Source = bitmap;
        }
        #endregion

        private void ChartTrackBallBehavior_InfoUpdated(object sender, TrackBallInfoEventArgs e)
        {
            var tmpString = "";
            foreach (DataPointInfo info in e.Context.DataPointInfos)
            {
                // info.DisplayHeader = "Custom data point header";
                tmpString += info.DataPoint.Label + Environment.NewLine;
            }

            e.Header = tmpString;
        }


        public void Gridview_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (e.AddedItems.Count > 0) //make sure we have some items
            {
                //find the event, the name, and the index in our collection
                var tmpEvent = (SeasonSummary) e.AddedItems[0];
                var seasonNumber = tmpEvent.SeasonNumber;
                int tmpIndex = -1;
                for (int i = 0; i < DeckSummaries_Visible.Count; i++)
                {
                    if (DeckSummaries_Visible[i].SeasonNumber == seasonNumber) { tmpIndex = i; break; }
                }
                //do something about it!
                if (tmpIndex > -1)
                {
                    SelectedDecks_Visible.Clear();
                    for (int i = 0; i < DeckSummaries_Visible[tmpIndex].CardData.Count; i++)
                    {
                        SelectedDecks_Visible.Add(DeckSummaries_Visible[tmpIndex].CardData[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Unknown Loss Selected: " + seasonNumber); //somehow we selected something not in the bound list
                }
            }
        }

        public void Gridview_SelectionChanged3(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            Telerik.Windows.Controls.RadGridView ppp = (Telerik.Windows.Controls.RadGridView) sender;
            //  if (e.AddedItems.Count > 0) //make sure we have some items
            if (ppp.SelectedItems.Count > 0)
            {

                List<CardReport> tmpEvents = new List<CardReport>();
                List<string> tmpNames = new List<string>();
                List<int> tmpIndices = new List<int>();

                CardTrend_SeriesNames.Clear();

                for (int ix = 0; ix < ppp.SelectedItems.Count; ix++)
                {
                    //find the event, the name, and the index in our collection
                    var tmpEvent = (CardReport) ppp.SelectedItems[ix];
                    // var name = tmpEvent.Name;
                    //int tmpIndex = -1;
                    tmpEvents.Add(tmpEvent);
                    tmpNames.Add(tmpEvent.Name);
                    CardTrend_SeriesNames.Add(tmpEvent.Name);
                    for (int i = 0; i < SelectedDecks_Visible.Count; i++)
                    {
                        if (SelectedDecks_Visible[i].Name == tmpEvent.Name) { tmpIndices.Add(i); break; }
                    }
                }

                CardTrend_ChartYVals.Clear();
                CardTrend_ChartXVals.Clear();

                for (int j = 0; j < tmpIndices.Count; j++)
                {
                    //do something about it!
                    if (tmpIndices[j] > -1)
                    {


                        var tmpYList = new List<int>();
                        var tmpXList = new List<string>();

                        for (int i = 0; i < DeckSummaries.Count; i++)
                        {
                            tmpYList.Add(DeckSummaries[i].HowManyOfCard(tmpNames[j]));
                            tmpXList.Add(DeckSummaries[i].SeasonNumber.ToString());
                        }

                        CardTrend_ChartXVals.Add(tmpXList);
                        CardTrend_ChartYVals.Add(tmpYList);
                    }
                    else
                    {
                        MessageBox.Show("Unknown Selection: "); //somehow we selected something not in the bound list
                    }
                }
                updateChart();

                if (tmpNames.Count == 1)
                {
                    setCardImageSource(tmpNames[0]);
                    setCardImageSource1("blank");
                    setCardImageSource2("blank");
                    setCardImageSource3("blank");
                }
                else if (tmpNames.Count == 2)
                {
                    setCardImageSource(tmpNames[0]);
                    setCardImageSource1(tmpNames[1]);
                    setCardImageSource2("blank");
                    setCardImageSource3("blank");
                }
                else if (tmpNames.Count == 3)
                {
                    setCardImageSource(tmpNames[0]);
                    setCardImageSource1(tmpNames[1]);
                    setCardImageSource2(tmpNames[2]);
                    setCardImageSource3("blank");
                }
                else
                {
                    setCardImageSource(tmpNames[0]);
                    setCardImageSource1(tmpNames[1]);
                    setCardImageSource2(tmpNames[2]);
                    setCardImageSource3(tmpNames[3]);
                }
            }
            else
            {
                setCardImageSource("blank");
                setCardImageSource1("blank");
                setCardImageSource2("blank");
                setCardImageSource3("blank");
            }
        }




        private void updateChart()
        {
            //make the chart
            var blankDataTemplate = new DataTemplate("");
            CardChart.Series.Clear();
            CardChart.Palette = getLineColors();

            CardChart.VerticalAxis = new LinearAxis();
            CardChart.VerticalAxis.Title = "# Cards";


            for (int j = 0; j < CardTrend_ChartYVals.Count; j++)
            {

                CategoricalSeries newSeries = new LineSeries();
                for (int i = 0; i < CardTrend_ChartXVals[j].Count; i++)
                {
                    double value = CardTrend_ChartYVals[j][i];
                    newSeries.DataPoints.Add(new CategoricalDataPoint { Value = value, Category = CardTrend_ChartXVals[j][i], Label = CardTrend_SeriesNames[j] + " " + CardTrend_ChartXVals[j][i] + ": " + value });
                }
                //new comment!!!
                newSeries.TrackBallInfoTemplate = blankDataTemplate;
                CardChart.Series.Add(newSeries);
            }

            //    Loss_LineChart.HorizontalAxis.LabelInterval = 6;
            //   Loss_LineChart.HorizontalAxis.LabelFitMode = AxisLabelFitMode.None;

        }


        #endregion

        #region TAB 2

        List<List<int>> CardTrend_ChartYVals_T2 = new List<List<int>>();
        List<List<string>> CardTrend_ChartXVals_T2 = new List<List<string>>();
        List<string> CardTrend_SeriesNames_T2 = new List<string>();

        public ObservableCollection<CardReport> SelectedDecks_Visible_T2 { get; set; } = new ObservableCollection<CardReport>();


        #region Card Images Sources
        private void setCardImageSource_T2(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage_T2.Source = bitmap;
        }
        private void setCardImageSource1_T2(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage1_T2.Source = bitmap;
        }
        private void setCardImageSource2_T2(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage2_T2.Source = bitmap;
        }
        private void setCardImageSource3_T2(string imageName)
        {
            var uri = new Uri("pack://application:,,,/img/" + ReplaceAllSpaces(imageName) + ".png");
            var bitmap = new BitmapImage(uri);

            cardImage3_T2.Source = bitmap;
        }
        #endregion



        private void ChartTrackBallBehavior_InfoUpdated_T2(object sender, TrackBallInfoEventArgs e)
        {
            var tmpString = "";
            foreach (DataPointInfo info in e.Context.DataPointInfos)
            {
                // info.DisplayHeader = "Custom data point header";
                tmpString += info.DataPoint.Label + Environment.NewLine;
            }

            e.Header = tmpString;
        }


        public void Gridview_SelectionChanged3_T2(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            Telerik.Windows.Controls.RadGridView ppp = (Telerik.Windows.Controls.RadGridView) sender;
            //  if (e.AddedItems.Count > 0) //make sure we have some items
            if (ppp.SelectedItems.Count > 0)
            {

                List<CardReport> tmpEvents = new List<CardReport>();
                List<string> tmpNames = new List<string>();
                List<int> tmpIndices = new List<int>();

                CardTrend_SeriesNames_T2.Clear();

                for (int ix = 0; ix < ppp.SelectedItems.Count; ix++)
                {
                    //find the event, the name, and the index in our collection
                    var tmpEvent = (CardReport) ppp.SelectedItems[ix];
                    // var name = tmpEvent.Name;
                    //int tmpIndex = -1;
                    tmpEvents.Add(tmpEvent);
                    tmpNames.Add(tmpEvent.Name);
                    CardTrend_SeriesNames_T2.Add(tmpEvent.Name);
                    for (int i = 0; i < SelectedDecks_Visible_T2.Count; i++)
                    {
                        if (SelectedDecks_Visible_T2[i].Name == tmpEvent.Name) { tmpIndices.Add(i); break; }
                    }
                }

                CardTrend_ChartYVals_T2.Clear();
                CardTrend_ChartXVals_T2.Clear();

                for (int j = 0; j < tmpIndices.Count; j++)
                {
                    //do something about it!
                    if (tmpIndices[j] > -1)
                    {


                        var tmpYList = new List<int>();
                        var tmpXList = new List<string>();

                        for (int i = 0; i < DeckSummaries.Count; i++)
                        {
                            tmpYList.Add(DeckSummaries[i].HowManyOfCard(tmpNames[j]));
                            tmpXList.Add(DeckSummaries[i].SeasonNumber.ToString());
                        }

                        CardTrend_ChartXVals_T2.Add(tmpXList);
                        CardTrend_ChartYVals_T2.Add(tmpYList);
                    }
                    else
                    {
                        MessageBox.Show("Unknown Selection: "); //somehow we selected something not in the bound list
                    }
                }
                updateChart_T2();

                if (tmpNames.Count == 1)
                {
                    setCardImageSource_T2(tmpNames[0]);
                    setCardImageSource1_T2("blank");
                    setCardImageSource2_T2("blank");
                    setCardImageSource3_T2("blank");
                }
                else if (tmpNames.Count == 2)
                {
                    setCardImageSource_T2(tmpNames[0]);
                    setCardImageSource1_T2(tmpNames[1]);
                    setCardImageSource2_T2("blank");
                    setCardImageSource3_T2("blank");
                }
                else if (tmpNames.Count == 3)
                {
                    setCardImageSource_T2(tmpNames[0]);
                    setCardImageSource1_T2(tmpNames[1]);
                    setCardImageSource2_T2(tmpNames[2]);
                    setCardImageSource3_T2("blank");
                }
                else
                {
                    setCardImageSource_T2(tmpNames[0]);
                    setCardImageSource1_T2(tmpNames[1]);
                    setCardImageSource2_T2(tmpNames[2]);
                    setCardImageSource3_T2(tmpNames[3]);
                }
            }
            else
            {
                setCardImageSource_T2("blank");
                setCardImageSource1_T2("blank");
                setCardImageSource2_T2("blank");
                setCardImageSource3_T2("blank");
            }
        }




        private void updateChart_T2()
        {
            //make the chart
            var blankDataTemplate = new DataTemplate("");
            CardChart_T2.Series.Clear();
            CardChart_T2.Palette = getLineColors();

            CardChart_T2.VerticalAxis = new LinearAxis();
            CardChart_T2.VerticalAxis.Title = "# Cards";


            for (int j = 0; j < CardTrend_ChartYVals_T2.Count; j++)
            {

                CategoricalSeries newSeries = new LineSeries();
                for (int i = 0; i < CardTrend_ChartXVals_T2[j].Count; i++)
                {
                    double value = CardTrend_ChartYVals_T2[j][i];
                    newSeries.DataPoints.Add(new CategoricalDataPoint { Value = value, Category = CardTrend_ChartXVals_T2[j][i], Label = CardTrend_SeriesNames_T2[j] + " " + CardTrend_ChartXVals_T2[j][i] + ": " + value });
                }
                //new comment!!!
                newSeries.TrackBallInfoTemplate = blankDataTemplate;
                CardChart_T2.Series.Add(newSeries);
            }

            //    Loss_LineChart.HorizontalAxis.LabelInterval = 6;
            //   Loss_LineChart.HorizontalAxis.LabelFitMode = AxisLabelFitMode.None;

        }


        #endregion



        public ChartPalette getLineColors()
        {
            var tmp = new ChartPalette();
            addPaletteEntry(ref tmp, 50, 205, 240);
            addPaletteEntry(ref tmp, 254, 118, 58);
            addPaletteEntry(ref tmp, 153, 192, 73);
            addPaletteEntry(ref tmp, 1, 149, 159);
            addPaletteEntry(ref tmp, 115, 127, 65);
            addPaletteEntry(ref tmp, 119, 199, 198);
            addPaletteEntry(ref tmp, 189, 171, 210);
            addPaletteEntry(ref tmp, 76, 74, 75);
            addPaletteEntry(ref tmp, 255, 175, 2);
            addPaletteEntry(ref tmp, 150, 76, 143);
            addPaletteEntry(ref tmp, 18, 135, 170);
            return tmp;
        }
        private void addPaletteEntry(ref ChartPalette palette, byte R, byte G, byte B)
        {
            var tmp = new PaletteEntry();
            tmp.Fill = new SolidColorBrush(Color.FromRgb(R, G, B));
            tmp.Stroke = new SolidColorBrush(Color.FromRgb(R, G, B));
            palette.GlobalEntries.Add(tmp);
        }








        public static class ImageManip
        {
            public static System.Drawing.Bitmap CombineBitmap(string[] files)
            {
                //read all images into memory
                List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
                System.Drawing.Bitmap finalImage = null;

                try
                {
                    int width = 0;
                    int height = 0;

                    foreach (string image in files)
                    {
                        //create a Bitmap from the file and add it to the list
                           System.Drawing.Image imageX =  System.Drawing.Image.FromFile(image);
                        //   System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("img/" + c + ".png");
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(imageX);

                        //update the size of the final bitmap
                        width += bitmap.Width;
                        height = bitmap.Height > height ? bitmap.Height : height;

                        images.Add(bitmap);
                    }

                    //create a bitmap to hold the combined image
                    finalImage = new System.Drawing.Bitmap(width, height);

                    //get a graphics object from the image so we can draw on it
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                    {
                        //set background color
                        g.Clear(System.Drawing.Color.Black);

                        //go through each image and draw it on the final image
                        int offset = 0;
                        foreach (System.Drawing.Bitmap image in images)
                        {
                            g.DrawImage(image,
                              new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                            offset += image.Width;
                        }
                    }

                    return finalImage;
                }
                catch (Exception ex)
                {
                    if (finalImage != null)
                        finalImage.Dispose();

                    throw ex;
                }
                finally
                {
                    //clean up memory
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        image.Dispose();
                    }
                }
            }
        }












    }
}
