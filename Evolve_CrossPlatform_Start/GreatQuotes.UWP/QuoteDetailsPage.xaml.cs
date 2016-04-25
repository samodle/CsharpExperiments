using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GreatQuotes.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuoteDetailsPage : Page
    {
        public QuoteDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = e.Parameter as GreatQuote;
        }

        private void OnEditQuote(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (EditQuotePage), this.DataContext);
        }
    }
}
