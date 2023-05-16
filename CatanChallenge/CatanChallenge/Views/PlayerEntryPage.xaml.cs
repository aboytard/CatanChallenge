using System;
using System.IO;
using CatanChallenge;
using CatanChallenge.Model;
using Xamarin.Forms;

namespace CatanChallenge.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PlayerEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadPlayer(value);
            }
        }

        public PlayerEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Player.
            BindingContext = new Player();
        }

        async void LoadPlayer(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the player and set it as the BindingContext of the page.
                Player player = await App.Database.GetPlayerAsync(id);
                BindingContext = player;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var player = (Player)BindingContext;
            player.DateInscription = DateTime.UtcNow;
            if (string.IsNullOrEmpty(player.Description))
                await App.Database.SavePlayerAsync(player);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var player = (Player)BindingContext;
            await App.Database.DeleteNoteAsync(player);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void DisplayAlertClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "This is an alert.", "OK");
        }
    }
}