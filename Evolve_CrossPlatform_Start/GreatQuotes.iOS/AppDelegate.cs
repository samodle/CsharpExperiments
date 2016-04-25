using System;

using Foundation;
using UIKit;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		QuoteLoader quoteLoader;
		public static List<GreatQuote> Quotes { get; private set; }
		public override UIWindow Window { get; set; }

		public override void FinishedLaunching(UIApplication application)
		{
			quoteLoader = new QuoteLoader();
			Quotes = quoteLoader.Load().ToList();
		}

		public override async void DidEnterBackground(UIApplication application)
		{
			CancellationTokenSource cts = new CancellationTokenSource();

			var taskId = UIApplication.SharedApplication.BeginBackgroundTask(() => cts.Cancel());

			try {
				await Task.Run(() => {
					quoteLoader.Save(Quotes);
				}, cts.Token);
			}
			catch (Exception ex) {
				Debug.WriteLine(ex.Message);
			}
			finally {
				UIApplication.SharedApplication.EndBackgroundTask(taskId);
			}
		}
	}
}

