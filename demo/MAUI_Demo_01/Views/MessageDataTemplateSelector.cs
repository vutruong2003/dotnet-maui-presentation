namespace MAUI_Demo_01.Views;

public class MessageDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate SenderMessageTemplate { get; set; }
    public DataTemplate ReceiverMessageTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var message = (MessageModel)item;

        if (message.Sender == null)
            return ReceiverMessageTemplate;

        return SenderMessageTemplate;
    }
}
