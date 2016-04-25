using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GreatQuotes.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditQuotePage : Page
    {
        private GreatQuote quote;

        public EditQuotePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            quote = e.Parameter as GreatQuote;
            DataContext = new GreatQuote(quote);
        }

        private async void OnSave(object sender, RoutedEventArgs e)
        {
            var vm = (GreatQuote) DataContext;
            if (!string.IsNullOrEmpty(vm.Author) && !string.IsNullOrEmpty(vm.QuoteText))
            {
                quote.Author = vm.Author;
                quote.QuoteText = vm.QuoteText;
                this.Frame.GoBack();
            }
            else
            {
                await new MessageDialog("Please complete the quote.", "Need more information").ShowAsync();
                quoteTextBox.Focus(FocusState.Programmatic);
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void OnDelete(object sender, RoutedEventArgs e)
        {
            var md = new MessageDialog("Are you sure you want to delete this quote?", "Delete quote");
            
            md.Commands.Add(new UICommand("Yes"));
            md.Commands.Add(new UICommand("No"));
            var result = await md.ShowAsync();
            if (result.Label == "Yes")
            {
                ((App) Application.Current).Quotes.Remove(quote);
                while (this.Frame.CanGoBack)
                    this.Frame.GoBack();
            }
        }
    }
}
