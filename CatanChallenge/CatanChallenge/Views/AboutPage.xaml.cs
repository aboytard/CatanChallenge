using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CatanChallenge.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            // Put the real website of catan
            await Launcher.OpenAsync("https://www.catan.com/understand-catan/game-rules");
        }
    }
}