using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GreatQuotes.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = ((App)Application.Current).Quotes;
        }

        private void OnQuoteSelected(object sender, ItemClickEventArgs e)
        {
            var quote = (GreatQuote) e.ClickedItem;
            this.Frame.Navigate(typeof (QuoteDetailsPage), quote);
        }

        private void OnAddQuote(object sender, RoutedEventArgs e)
        {
            var quote = new GreatQuote();
            ((App)Application.Current).Quotes.Add(quote);
            this.Frame.Navigate(typeof (EditQuotePage), quote);
        }
    }
}
