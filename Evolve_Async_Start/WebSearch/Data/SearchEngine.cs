using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WebSearch.ViewModels;
using System.Collections.Generic;

namespace WebSearch.Data
{
	public static class SearchEngine
	{
        public static SearchResultViewModel Search(string term, string htmlSource, SearchUrl url)
		{
            if (term == null || htmlSource == null)
                return null;

            string title;
			HtmlToText converter = new HtmlToText();
            string text = converter.ConvertHtml( htmlSource, out title );

            var foundTerms = LocateTerms(text, term).Distinct().ToList();
            if (foundTerms.Any())
            {
                return new SearchResultViewModel(foundTerms) 
                {
                    ArticleTitle = FixupTitle(title ?? GetTitle(htmlSource)),
                    Term = term,
                    SearchUrl = url,
                };
            }

			return null;
		}

        static IEnumerable<string> LocateTerms(string fullText, string term)
		{
			int index = 0;
			fullText = fullText.Replace("\r\n", " ");
            while (index >= 0 && index < fullText.Length-1)
			{
                index = fullText.IndexOf(term, index, StringComparison.OrdinalIgnoreCase);
                if (index >= 0) 
                {
                    yield return GetSentence(fullText, index, term);
                    index++;
                }
			}
		}

        static string GetSentence(string text, int index, string term)
		{
            int start = Math.Max( 0, index - (term.Length+5) );
            int end = Math.Min( text.Length - 1, index + term.Length + 65 );

			try
			{
                string sample = text.Substring( start, end - start )
                                    .Replace("\n", " ")
                                    .Trim();
                return index > 0 ? "... " + sample : sample;
			}
			catch ( Exception x)
			{
				Debug.WriteLine( x );
				return "n/a";
			}
		}

        static string FixupTitle(string str)
        {
            return str
                .Trim('\r', '\n', ' ')
                .Replace("&amp;", "&")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&nbsp;", " ");
        }

		static string GetTitle(string htmlSource)
		{
            Regex regex = new Regex( @"(?<=<title.*>)([\s\S]*)(?=</title>)" );
			Match match = regex.Match( htmlSource );
			return match.Success ? match.Value : "n/a";
		}
	}
}