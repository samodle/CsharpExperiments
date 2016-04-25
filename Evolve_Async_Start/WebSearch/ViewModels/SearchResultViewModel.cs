using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WebSearch.Data;

namespace WebSearch.ViewModels
{
    public class LocatedText
    {
        public SearchResultViewModel Owner { get; private set; }
        public string Text { get; private set; }

        public LocatedText(SearchResultViewModel vm, string text)
        {
            Owner = vm;
            Text = text;
        }
    }

    public class SearchResultViewModel : IEnumerable<LocatedText>
    {
        public SearchUrl SearchUrl { get; set; }
        public string Term { get; set; }
        public string ArticleTitle { get; set; }
        public List<LocatedText> LocatedText { get; private set; }

        public SearchResultViewModel(IEnumerable<string> foundTerms)
        {
            LocatedText = new List<LocatedText>(
                foundTerms.Select(s => new LocatedText(this, s)));
        }

        public IEnumerator<LocatedText> GetEnumerator()
        {
            return LocatedText.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return LocatedText.GetEnumerator();
        }
    }
	
}