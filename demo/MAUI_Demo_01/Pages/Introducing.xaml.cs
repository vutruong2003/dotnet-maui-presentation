namespace MAUI_Demo_01.Pages;

public partial class Introducing : ContentPage
{
	private IntroducingViewModel _viewModel => BindingContext as IntroducingViewModel;

	public Introducing()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        _viewModel.OnAppearing();
        _viewModel.Slider = slider;
        _viewModel.Indicator = indicatorView;

        base.OnAppearing();
    }
}