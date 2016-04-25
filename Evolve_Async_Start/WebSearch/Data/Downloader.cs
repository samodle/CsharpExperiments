using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace WebSearch.Data
{
    public class DownloadResult
    {
        public SearchUrl SearchUrl { get; set; }
        public string Data { get; set; }
    }

    public class Downloader
    {
        async public Task<DownloadResult> DownloadHtmlAsync(SearchUrl searchUrl)
        {
            var result = new DownloadResult { SearchUrl = searchUrl };

            try
            {
                using (var client = new TimedWebClient())
                {
                    result.Data = await client.DownloadStringTaskAsync(new Uri(searchUrl.Url));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} failed: {1}", searchUrl.Url, ex.Message);
            }

            return result;
        }


        public DownloadResult DownloadHtml(SearchUrl searchUrl)
        {
            var result = new DownloadResult { SearchUrl = searchUrl };

            try
            {
                using (var client = new TimedWebClient())
                {
                    result.Data = client.DownloadString(new Uri(searchUrl.Url));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("{0} failed: {1}", searchUrl.Url, ex.Message);
            }

            return result;
        }

        private class TimedWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                // Drop timeout to 5sec vs. normal 30 for slow networks.
                WebRequest wr = base.GetWebRequest(address);
                wr.Timeout = 5000;
                return wr;
            }
        }
    }
}
