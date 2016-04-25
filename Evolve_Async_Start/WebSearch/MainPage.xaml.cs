using Xamarin.Forms;
using WebSearch.ViewModels;

namespace WebSearch
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            InitializeComponent();
        }
    }
}

