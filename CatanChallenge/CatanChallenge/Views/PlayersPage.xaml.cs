using CatanChallenge.Model;
using System;
using System.Linq;
using Xamarin.Forms;

namespace CatanChallenge.Views
{
    public partial class PlayersPage : ContentPage
    {
        public PlayersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetPlayersAsync();
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                Player player = (Player)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(PlayerEntryPage)}?{nameof(PlayerEntryPage.ItemId)}={player.Id.ToString()}");
            }
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(PlayerEntryPage));
        }
    }
}