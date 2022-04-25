namespace MAUI_Demo_01.Pages;

public partial class Login : ContentPage
{
	private LoginViewModel _viewModel => BindingContext as LoginViewModel;

	public Login()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
		_viewModel?.OnAppearing();

        if (GlobalConfig.Desktop)
        {
            mainGrid.MaximumWidthRequest = 460;
        }

        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}