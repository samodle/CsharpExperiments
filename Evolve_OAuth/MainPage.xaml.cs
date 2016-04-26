using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Auth;
using System.Linq;

namespace ComicBook
{
	public partial class MainPage : ContentPage
	{
		const string 	ServiceId  = "ComicBook";
		const string 	Scope	   = "profile";

		public MainPage ()
		{
			InitializeComponent ();

			implicitButton.Clicked += ImplicitButtonClicked;
			authorizationCodeButton.Clicked += AuthorizationCodeButtonClicked;
			getProfileButton.Clicked += GetProfileButtonClicked;
			refreshButton.Clicked += RefreshButtonClicked;
		}

		void ImplicitButtonClicked (object sender, EventArgs e)
		{
		}
			
		void AuthorizationCodeButtonClicked (object sender, EventArgs e)
		{
		}

		void GetProfileButtonClicked (object sender, EventArgs e)
		{
		}

		void RefreshButtonClicked (object sender, EventArgs e)
		{
		}
	}
}