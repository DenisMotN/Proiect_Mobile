using Proiect_Mobile.Models;

namespace Proiect_Mobile;

public partial class GamePage : ContentPage
{
    GameList gl;
    public GamePage(GameList glist)
    {
        InitializeComponent();
        gl = glist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var game = (Game)BindingContext;
        await App.Database.SaveGameAsync(game);
        listView.ItemsSource = await App.Database.GetGamesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var game = (Game)BindingContext;
        await App.Database.DeleteGameAsync(game);
        listView.ItemsSource = await App.Database.GetGamesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGamesAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Game g;
        if (listView.SelectedItem != null)
        {
            g = listView.SelectedItem as Game;
            var lg = new ListGame()
            {
                GameListID = gl.ID,
                GameID = g.ID
            };
            await App.Database.SaveListGameAsync(lg);
            g.ListGames = new List<ListGame> { lg };
            await Navigation.PopAsync();

        }
    }
}