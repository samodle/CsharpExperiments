using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace WebSearch.Data
{
	public class HtmlToText
	{
        public string ConvertHtml(string html, out string title)
		{
            HtmlDocument doc = new HtmlDocument 
            {
                OptionCheckSyntax = false,
                OptionUseIdAttribute = false,
            };

            doc.LoadHtml( html );
		
            title = doc.DocumentNode.Descendants("title").SingleOrDefault()?.InnerText;

            using (StringWriter sw = new StringWriter())
            {
                ConvertTo(doc.DocumentNode, sw);
                sw.Flush();
                return sw.ToString();
            }
		}

        public void ConvertTo(HtmlNode node, TextWriter outputWriter)
		{
			string html;
			switch (node.NodeType)
			{
				case HtmlNodeType.Comment:
					break;
				case HtmlNodeType.Document:
					ConvertContentTo( node, outputWriter );
					break;
                case HtmlNodeType.Text:
                    string parentName = node.ParentNode.Name;
                    if (parentName != "script" && parentName != "style") {
                        html = ((HtmlTextNode)node).Text;
                        if (!HtmlNode.IsOverlappedClosingElement(html)
                            && html.Trim().Length > 0) 
                        {
                            string output;
                            try 
                            {
                                output = HtmlEntity.DeEntitize(html);
                            }
                            catch 
                            {
                                output = html;
                            }

                            outputWriter.Write(output);
                            if (!output.EndsWith(" "))
                                outputWriter.Write(" ");
                        }
                    }
					break;
				case HtmlNodeType.Element:
					switch ( node.Name )
					{
						case "p":
                        case "br":
							outputWriter.Write(" ");
							break;
					}
					if (node.HasChildNodes)
						ConvertContentTo( node, outputWriter );
					break;
			}
		}

		void ConvertContentTo(HtmlNode node, TextWriter outText)
		{
			foreach (HtmlNode subnode in node.ChildNodes)
				ConvertTo( subnode, outText );
		}
	}
}
