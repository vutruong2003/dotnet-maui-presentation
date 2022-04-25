namespace MAUI_Demo_01.Pages;

public partial class Swipering : ContentPage
{
    private SwiperingViewModel _viewModel => BindingContext as SwiperingViewModel;

	public Swipering()
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