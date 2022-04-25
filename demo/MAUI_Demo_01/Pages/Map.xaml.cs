namespace MAUI_Demo_01.Pages;

public partial class Map : ContentPage
{
	public Map()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PopModalAsync();
    }
}