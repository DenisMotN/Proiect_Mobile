using Proiect_Mobile.Models; 

namespace Proiect_Mobile;

public partial class LiatPage : ContentPage
{
	public LiatPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var glist = (GameList)BindingContext;
        glist.Date = DateTime.UtcNow;
        await App.Database.SaveGameListAsync(glist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var glist = (GameList)BindingContext;
        await App.Database.DeleteGameListAsync(glist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GamePage((GameList)
       this.BindingContext)
        {
            BindingContext = new Game()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var gamel = (GameList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(gamel.ID);
    }

}