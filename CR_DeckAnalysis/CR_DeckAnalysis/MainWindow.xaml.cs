using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public MainWindow()
        {
            InitializeComponent();
        }
        public void startTest(object o, EventArgs e)
        {

            List<Deck> importList1 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\1.txt");
            //List<Deck> importList2 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\2.txt");
            List<Deck> importList3 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\3.txt");
            List<Deck> importList4 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\4.txt");
            //List<Deck> importList5 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\5.txt");
            List<Deck> importList6 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\6.txt");
            List<Deck> importList7 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\7.txt");
            List<Deck> importList8 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\8.txt");
            List<Deck> importList9 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\9.txt");
            List<Deck> importList10 = IO.DeckList_Import("C:\\Users\\odle.so.1\\Source\\Repos\\CsharpExperiments\\CR_DeckAnalysis\\10.txt");


            DeckSummaries.Add(new SeasonSummary(importList1, 1));
            DeckSummaries.Add(new SeasonSummary(importList3, 3));
            DeckSummaries.Add(new SeasonSummary(importList4, 4));
            DeckSummaries.Add(new SeasonSummary(importList6, 6));
            DeckSummaries.Add(new SeasonSummary(importList7, 7));
            DeckSummaries.Add(new SeasonSummary(importList8, 8));
            DeckSummaries.Add(new SeasonSummary(importList9, 9));
            DeckSummaries.Add(new SeasonSummary(importList10, 10));






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


    }
}
