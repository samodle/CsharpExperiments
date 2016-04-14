using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinUniversitry
{
    [Activity(Label = "XamarinUniversitry", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ListView instructorList = FindViewById<ListView>(Resource.Id.instructorListView);
            instructorList.ItemClick += OnItemClick;
            instructorList.Adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1,InstructorData.Instructors);
        }

        void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var instructor = InstructorData.Instructors[e.Position];

            var dialogue = new AlertDialog.Builder(this);
            dialogue.SetMessage(instructor.Name);
            dialogue.SetNeutralButton("OK", delegate { });
            dialogue.Show();
        }

    }
}

