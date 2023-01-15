using Proiect_Mobile.Models;

namespace Proiect_Mobile;

public partial class GameListEntryPage : ContentPage
{
	public GameListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGameListsAsync();
    }
    async void OnGameListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LiatPage
        {
            BindingContext = new GameList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new LiatPage
            {
                BindingContext = e.SelectedItem as GameList
            });
        }
    }
}