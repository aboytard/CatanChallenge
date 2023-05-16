using CatanChallenge.Views;
using Xamarin.Forms;

namespace CatanChallenge
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlayerEntryPage), typeof(PlayerEntryPage));
        }
    }
}