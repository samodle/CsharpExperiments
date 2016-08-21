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

        public MainWindow()
        {
            InitializeComponent();
        }
        public void startTest(object o, EventArgs e)
        {
            TestProtocol.startTest();
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
