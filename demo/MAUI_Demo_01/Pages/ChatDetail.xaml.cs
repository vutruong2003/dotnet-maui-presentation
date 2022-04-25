namespace MAUI_Demo_01.Pages;

public partial class ChatDetail : ContentPage
{
	private readonly ChatDetailViewModel _viewModel;

    public ChatDetail(ChatDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    public void Initialize(MessageModel message)
    {
        _viewModel.Initialize(message);

        Title = message?.Sender?.Name;
    }

    protected override void OnAppearing()
    {
        _viewModel.OnAppearing();

        base.OnAppearing();
    }
}