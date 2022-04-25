namespace MAUI_Demo_01.ViewModels;

public partial class ChatDetailViewModel : BaseViewModel
{
    [ObservableProperty]
    private UserChatModel user;

    [ObservableProperty]
    private ObservableCollection<MessageModel> _messages;

    [ObservableProperty]
    private string _message = "";

    private readonly IMessageService _messageService;

    public ChatDetailViewModel(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Initialize(MessageModel message)
    {
        User = message.Sender;
        Messages = new ObservableCollection<MessageModel>(_messageService.GetMessages(User));
    }

    [ICommand]
    private async Task GoBack()
    {
        await Shell.Current.Navigation.PopToRootAsync();
    }

    [ICommand]
    private async Task Send()
    {
        if (string.IsNullOrEmpty(_message))
        {
            return;
        }

        var result = _messageService.SendMessage(_message);
        Messages.Add(result);

        Message = "";
    }
}
