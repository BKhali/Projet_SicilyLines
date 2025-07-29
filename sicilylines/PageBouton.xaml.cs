namespace sicilylines;

public partial class PageBouton : ContentPage
{
    Client oui;
	public PageBouton(Client c)
	{
        oui = c;
        InitializeComponent();
	}

    private async void ListReservationsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new reservation(oui));
    }

    private async void ModifyCoordinatesButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Compte(oui));
    }
}