using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Telerik.Charting;
using Telerik.Windows.Controls.ChartView;

namespace CR_DeckAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush Brush_TabSelected = new SolidColorBrush(System.Windows.Media.Color.FromRgb(37, 160, 218));
        private SolidColorBrush Brush_TabUnselected = new SolidColorBrush(System.Windows.Media.Color.FromRgb(202, 221, 228));

        List<SeasonSummary> DeckSummaries = new List<SeasonSummary>();

        List<int> ChartYVals = new List<int>();
        List<string> ChartXVals = new List<string>();

        List<List<int>> CardTrend_ChartYVals = new List<List<int>>();
        List<List<string>> CardTrend_ChartXVals = new List<List<string>>();
        List<string> CardTrend_SeriesNames = new List<string>();

        public ObservableCollection<SeasonSummary> DeckSummaries_Visible { get; set; } = new ObservableCollection<SeasonSummary>();
        public ObservableCollection<CardReport> SelectedDecks_Visible { get; set; } = new ObservableCollection<CardReport>();

        public MainWindow()
        {
            InitializeComponent();
            startTest();
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
           // List<Deck> importList11 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\11.txt"));
            //List<Deck> importList12 = IO.DeckList_Import(Path.Combine(Environment.CurrentDirectory, @"RawData\12.txt"));

            /*
             List<Deck> importList3 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\3.txt");
             List<Deck> importList4 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\4.txt");
             List<Deck> importList6 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\6.txt");
             List<Deck> importList7 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\7.txt");
             List<Deck> importList8 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\8.txt");
             List<Deck> importList9 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\9.txt");
             List<Deck> importList10 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\10.txt");
          */


            DeckSummaries.Add(new SeasonSummary(importList1, 1));
            DeckSummaries.Add(new SeasonSummary(importList3, 3));
            DeckSummaries.Add(new SeasonSummary(importList4, 4));
            DeckSummaries.Add(new SeasonSummary(importList6, 6));
            DeckSummaries.Add(new SeasonSummary(importList7, 7));
            DeckSummaries.Add(new SeasonSummary(importList8, 8));
            DeckSummaries.Add(new SeasonSummary(importList9, 9));
            DeckSummaries.Add(new SeasonSummary(importList10, 10));
         //   DeckSummaries.Add(new SeasonSummary(importList11, 11));
         //   DeckSummaries.Add(new SeasonSummary(importList12, 12));

            for (int i = 0; i < DeckSummaries.Count; i++)
            {
                DeckSummaries_Visible.Add(DeckSummaries[i]);
            }
            //Seasons_GridView.Rebind();
            // TestProtocol.startTest();
        }

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

        public void Gridview_SelectionChanged2(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (e.AddedItems.Count > 0) //make sure we have some items
            {
                //find the event, the name, and the index in our collection
                var tmpEvent = (CardReport) e.AddedItems[0];
                var name = tmpEvent.Name;
                int tmpIndex = -1;
                for (int i = 0; i < SelectedDecks_Visible.Count; i++)
                {
                    if (SelectedDecks_Visible[i].Name == name) { tmpIndex = i; break; }
                }
                //do something about it!
                if (tmpIndex > -1)
                {
                    ChartYVals.Clear();
                    ChartXVals.Clear();
                    for (int i = 0; i < DeckSummaries.Count; i++)
                    {
                        ChartYVals.Add(DeckSummaries[i].HowManyOfCard(name));
                        ChartXVals.Add(DeckSummaries[i].SeasonNumber.ToString());
                    }

                    updateChart();
                }
                else
                {
                    MessageBox.Show("Unknown Selection: " + name); //somehow we selected something not in the bound list
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
                        MessageBox.Show("Unknown Selection: " ); //somehow we selected something not in the bound list
                    }
                }
                updateChart();

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


    }
}
