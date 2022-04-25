namespace MAUI_Demo_01.ViewModels;

public partial class ChatViewModel : BaseViewModel
{
    [ObservableProperty]
    ObservableCollection<UserChatModel> users;

    [ObservableProperty]
    ObservableCollection<MessageModel> recentChat;

    private readonly IMessageService _messageService;
    private readonly IServiceProvider _serviceProvider;

    public ChatViewModel(IMessageService messageService, IServiceProvider serviceProvider)
    {
        _messageService = messageService;
        _serviceProvider = serviceProvider;
    }

    protected override Task OnModelAppearing()
    {
        Users = new ObservableCollection<UserChatModel>(_messageService.GetUsers());
        RecentChat = new ObservableCollection<MessageModel>(_messageService.GetChats());

        return base.OnModelAppearing();
    }

    [ICommand]
    private async void GoToDetail(MessageModel message)
    {
        var chatDetail = _serviceProvider.GetRequiredService<Pages.ChatDetail>();

        chatDetail.Initialize(message);

        await Shell.Current.Navigation.PushAsync(chatDetail);
    }
}