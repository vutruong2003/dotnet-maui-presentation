namespace MAUI_Demo_01.Pages;

public partial class Register : ContentPage
{
	private readonly RegisterViewModel _viewModel;

	public Register(RegisterViewModel viewModel)
	{
		_viewModel = viewModel;

		BindingContext = _viewModel;

		InitializeComponent();
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