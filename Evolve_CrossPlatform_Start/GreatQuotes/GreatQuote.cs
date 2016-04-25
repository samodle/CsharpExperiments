using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreatQuotes
{
    public class GreatQuote : INotifyPropertyChanged
    {
        private string _author;
        private string _quoteText;

        public string Author
        {
            get { return _author; }
            set { SetPropertyValue(ref _author, value); }
        }

        public string QuoteText
        {
            get { return _quoteText; }
            set { SetPropertyValue(ref _quoteText, value); }
        }

        public GreatQuote() : this("Unknown", "Quote goes here..")
        {
        }

        public GreatQuote(GreatQuote copy)
        {
            this.QuoteText = copy.QuoteText;
            this.Author = copy.Author;
        }

        public GreatQuote(string author, string quoteText)
        {
            Author = author;
            QuoteText = quoteText;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value) == false)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}