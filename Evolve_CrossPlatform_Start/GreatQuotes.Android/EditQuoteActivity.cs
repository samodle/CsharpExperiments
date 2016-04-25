using Android.App;
using Android.OS;
using Android.Widget;

namespace GreatQuotes
{
	[Activity(Label = "@string/edit_quote")]			
	public class EditQuoteActivity : Activity
	{
		int quoteIndex;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			quoteIndex = Intent.Extras.GetInt("quoteIndex");
			var quote = QuoteManager.Instance.Quotes[quoteIndex];

			SetContentView(Resource.Layout.EditQuote);

			TextView quoteText = FindViewById<TextView>(Resource.Id.quoteText);
			TextView authorText = FindViewById<TextView>(Resource.Id.authorText);

			quoteText.Text = quote.QuoteText;
			authorText.Text = quote.Author;

            Button saveButton = FindViewById<Button>(Resource.Id.saveButton);
            saveButton.Click += (sender, e) => 
            {
                if (string.IsNullOrEmpty(quoteText.Text)
                    || string.IsNullOrEmpty(authorText.Text))
                {
                    new AlertDialog.Builder(this)
                        .SetTitle("Validation problem")
                        .SetMessage("Please set an author and a quote.")
                        .SetPositiveButton("OK", delegate{})
                        .Show();
                    return;
                }
                quote.QuoteText = quoteText.Text;
                quote.Author = authorText.Text;
                Finish();
            };
		}

		protected override void OnPause()
		{
			base.OnPause();
			App.Save();
		}
	}
}

