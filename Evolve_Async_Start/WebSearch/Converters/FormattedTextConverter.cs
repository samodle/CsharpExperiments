using System;
using Xamarin.Forms;
using WebSearch.ViewModels;

namespace WebSearch.Converters
{
    public class FormattedTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            LocatedText locText = value as LocatedText;
            if (locText == null)
                return value;

            string text = (locText.Text ?? "");

            if (targetType != typeof(FormattedString))
                throw new Exception("FormattedTextConverter must be used with FormattedText.");

            string searchTerm = locText.Owner.Term;
            if (string.IsNullOrWhiteSpace(searchTerm))
                return text;

            FormattedString formatString = new FormattedString();

            int index = 0, lastIndex = 0;
            while (index >= 0 && lastIndex < text.Length-1) {
                index = text.IndexOf(searchTerm, lastIndex, StringComparison.CurrentCultureIgnoreCase);
                if (index >= 0) {
                    string span = text.Substring(lastIndex, index - lastIndex);
                    formatString.Spans.Add(new Span { Text = span, ForegroundColor = Color.Black });
                    span = text.Substring(index, searchTerm.Length);
                    formatString.Spans.Add(new Span { Text = span, BackgroundColor = Color.Yellow, ForegroundColor = Color.Black });
                    lastIndex = index + searchTerm.Length;
                }
            }
            if (lastIndex < text.Length-1)
                formatString.Spans.Add(new Span { Text = text.Substring(lastIndex), ForegroundColor = Color.Black });

            return formatString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

