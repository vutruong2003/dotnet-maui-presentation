namespace MAUI_Demo_01.Pages;

public partial class Logout : ContentPage
{
	public Logout()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        GlobalConfig.AppToken = "";

        await Task.Delay(200);
        await Shell.Current.GoToAsync($"//{nameof(Login)}");
    }
}