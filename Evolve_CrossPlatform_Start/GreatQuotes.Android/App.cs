using Android.App;
using System;
using Android.Runtime;
using System.Collections.Generic;
using System.Linq;

namespace GreatQuotes
{
	[Application(Icon="@drawable/icon", Label="@string/app_name")]
	public class App : Application
	{
		static QuoteLoader quoteLoader;
        //	public static List<GreatQuote> Quotes { get; private set; }

        readonly SimpleContainer container = new SimpleContainer();

		public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
		{
		}

        public override void OnCreate()
        {
            //this was the original not factory model code
            /*	base.OnCreate();
                quoteLoader = new QuoteLoader();
                Quotes = quoteLoader.Load().ToList();
                */

            //  QuoteLoaderFactory.Create = () => new QuoteLoader();


            container.Register<IQuoteLoader, QuoteLoader>();
            container.Create<QuoteManager>();


            ServiceLocator.Instance.Add<ITextToSpeech, TextToSpeechService>();
            base.OnCreate();



        }


		public static void Save()
		{
            QuoteManager.Instance.Save();
			//original ->quoteLoader.Save(Quotes);
		}
	}
}

