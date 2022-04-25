namespace MAUI_Demo_01.Pages;

public partial class Chat : ContentPage
{
	private readonly ChatViewModel _viewModel;
	
    public Chat(ChatViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
		_viewModel.OnAppearing();

		base.OnAppearing();
    }
}