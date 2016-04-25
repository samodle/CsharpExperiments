using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using WebSearch.Data;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WebSearch.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
	{
        private SynchronizationContext UIcontext;

        public event PropertyChangedEventHandler PropertyChanged = delegate {};
        public Command Search { get; private set; }
        public Command<SearchResultViewModel> VisitSelectedSite { get; private set; }
		public IList<SearchResultViewModel> SearchResults { get; private set; }

		public string SearchText {
			get { return searchText; }
            set	
            { 
                if (SetPropertyValue(ref searchText, value)) 
                {
                    Search.ChangeCanExecute();
                }
            }
		}

        public string StatsText {
			get { return statsText; }
            set { 
                if (SetPropertyValue(ref statsText, value))
                {
                    Debug.WriteLine(value);
                } 
            }
		}

        public bool NoTermsFound {
            get { return noTermsFound; }
            set { SetPropertyValue(ref noTermsFound, value); }
        }

		public bool IsSearching {
            get { return isSearching; }
            set 
            { 
                if (SetPropertyValue(ref isSearching, value)) 
                {
                   Device.BeginInvokeOnMainThread(Search.ChangeCanExecute);
                }
            }
        }

        public void setIsSearchingWithContext(bool value, SynchronizationContext ctx)
        {

            ctx.Post(unused =>
            {
                if (SetPropertyValue(ref isSearching, value))
                {
                    Search.ChangeCanExecute();
                }
            }, null);
        }

		public MainViewModel()
		{
            Search = new Command(
                OnSearch, 
                () => !IsSearching && !string.IsNullOrWhiteSpace(SearchText));

            VisitSelectedSite = new Command<SearchResultViewModel>(
                r => Device.OpenUri(new Uri(r.SearchUrl.Url, UriKind.Absolute)), 
                r => r != null);
			
            SearchResults = new ObservableCollection<SearchResultViewModel>();
            SearchText = StatsText = string.Empty;
		}

        async void OnSearch()
		{
            SynchronizationContext ctx = SynchronizationContext.Current;

            Stopwatch timer = Stopwatch.StartNew();

			IsSearching = true;
			SearchResults.Clear();
            currentTarget = string.Empty;
            StatsText = string.Empty;
            NoTermsFound = false;

            currentDownloadCount = 0;
			totalDownloadCount = SearchUrl.Urls.Length;

            var pendingUrlTasks = SearchUrl.Urls
           .Select(url => downloader.DownloadHtmlAsync(url))
           .ToList();

 

           // foreach (var searchUrl in SearchUrl.Urls)
           while(pendingUrlTasks.Any())
            {
                //var result = await downloader.DownloadHtmlAsync(searchUrl).ConfigureAwait(false);


                var currentResult = await Task.WhenAny(pendingUrlTasks).ConfigureAwait(false);

                pendingUrlTasks.Remove(currentResult);
                var result = currentResult.Result;

                currentDownloadCount++;
                currentTarget = new Uri(result.SearchUrl.Url).Host;
                StatsText = string.Format("{0} of {1} - {2}", currentDownloadCount, totalDownloadCount, currentTarget);

                if (!string.IsNullOrWhiteSpace(result.Data))
                {
                    try
                    {
                        var srvm = SearchEngine.Search(SearchText, result.Data, result.SearchUrl);

                        if (srvm != null)
                        {
                          //  Device.BeginInvokeOnMainThread(() => SearchResults.Add(srvm));

                            ctx.Post(unused =>
                            {
                                SearchResults.Add(srvm);
                            }, null);
                            
                        }
                     
                    } catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    //THIS WAS FROM THE SECOND EXERCISE
                    /*    var srvm = await Task.Run(() => {
                            try
                           {
                                return SearchEngine.Search(SearchText, result.Data, result.SearchUrl);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                            return null;
                        });
                      */


        }
    }
              isSearching = false;
          //  setIsSearchingWithContext(false, ctx);

            NoTermsFound = !SearchResults.Any();
            DisplayTimer(timer);
		}

        bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!Object.Equals(field,value)) 
            {
                field = value;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        void DisplayTimer(Stopwatch timer)
        {
            timer.Stop();
            Device.BeginInvokeOnMainThread(async () => await Application.Current.MainPage
                .DisplayAlert("Debug", 
                    string.Format("Total Time: {0}", timer.Elapsed), "OK"));
        }

        string currentTarget = string.Empty;
        int currentDownloadCount;
        int totalDownloadCount;
        string searchText;
        string statsText;
        bool isSearching;
        bool noTermsFound;
        Downloader downloader = new Downloader();
	}
}