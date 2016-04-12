using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TipCalculator2
{
    [Activity(Label = "TipCalculator2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // int count = 1;
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            calculateButton.Click += OnCalculateClick;

        }

        void OnCalculateClick(object sender, EventArgs e)
        {
            double rawAmt;
            double tipAmt;
            double netAmt;
            string text = inputBill.Text;

            if (double.TryParse(text, out rawAmt))
            {
                tipAmt = rawAmt * 0.15;
                netAmt = rawAmt + tipAmt;
                outputTotal.Text = "$" + netAmt.ToString();
                outputTip.Text = "$" + tipAmt.ToString();
            }
            else
            {
                outputTip.Text = " ";
                outputTotal.Text = "Please Enter A Valid Number";
            }
        }

    }
}

