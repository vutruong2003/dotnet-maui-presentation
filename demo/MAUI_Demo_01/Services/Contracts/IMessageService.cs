using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo_01.Services.Contracts
{
    public interface IMessageService
    {
        List<UserChatModel> GetUsers();
        List<MessageModel> GetChats();

        List<MessageModel> GetMessages(UserChatModel sender);

        MessageModel SendMessage(string message);
    }
}
