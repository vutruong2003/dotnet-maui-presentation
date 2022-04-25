namespace MAUI_Demo_01.Pages;

public partial class ForgotPassword : ContentPage
{
	private readonly ForgotPasswordViewModel _viewModel;

    public ForgotPassword(ForgotPasswordViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        _viewModel.OnAppearing();

        if (GlobalConfig.Desktop)
        {
            mainGrid.MaximumWidthRequest = 460;
        }

        base.OnAppearing();
    }
}