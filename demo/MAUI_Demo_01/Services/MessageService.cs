namespace MAUI_Demo_01.Services;

public class MessageService : IMessageService
{
    readonly UserChatModel user1 = new()
    {
        Name = "Alaya Cordova",
        Image = "emoji1.png",
        Color = Color.FromArgb("#FFE0EC")
    };
    readonly UserChatModel user2 = new()
    {
        Name = "Cecily Trujillo",
        Image = "emoji2.png",
        Color = Color.FromArgb("#BFE9F2")
    };
    readonly UserChatModel user3 = new()
    {
        Name = "Eathan Sheridan",
        Image = "emoji3.png",
        Color = Color.FromArgb("#FFD6C4")
    };
    readonly UserChatModel user4 = new()
    {
        Name = "Komal Orr",
        Image = "emoji4.png",
        Color = Color.FromArgb("#C3C1E6")
    };
    readonly UserChatModel user5 = new()
    {
        Name = "Sariba Abood",
        Image = "emoji5.png",
        Color = Color.FromArgb("#FFE0EC")
    };
    readonly UserChatModel user6 = new()
    {
        Name = "Justin O'Moore",
        Image = "emoji6.png",
        Color = Color.FromArgb("#FFE5A6")
    };
    readonly UserChatModel user7 = new()
    {
        Name = "Alissia Shah",
        Image = "emoji7.png",
        Color = Color.FromArgb("#FFE0EC")
    };
    readonly UserChatModel user8 = new()
    {
        Name = "Antoni Whitney",
        Image = "emoji8.png",
        Color = Color.FromArgb("#FFE0EC")
    };
    readonly UserChatModel user9 = new()
    {
        Name = "Jaime Zuniga",
        Image = "emoji9.png",
        Color = Color.FromArgb("#C3C1E6")
    };
    readonly UserChatModel user10 = new()
    {
        Name = "Barbara Cherry",
        Image = "emoji10.png",
        Color = Color.FromArgb("#FF95A2")
    };

    private List<MessageModel> _messages;

    public List<UserChatModel> GetUsers()
    {
        return new List<UserChatModel>
            {
                user1, user2, user3, user4
            };
    }
    public List<MessageModel> GetChats()
    {
        return new List<MessageModel>
            {
                new MessageModel
                {
                  Sender = user6,
                  Time = "18:32",
                  Text = "Hey there! What\'s up? Is everything ok?",
                },
              new MessageModel
              {
                Sender = user1,
                Time = "14:05",
                Text = "Can I call you back later?, I\'m in a meeting.",
              },
              new MessageModel
              {
                Sender = user3,
                Time = "14:00",
                Text = "Yeah. Do you have any good song to recommend?",
              },
              new MessageModel
              {
                Sender = user2,
                Time = "13:35",
                Text = "Hi! I went shopping today and found a nice t-shirt.",
              },
              new MessageModel
              {
                Sender = user4,
                Time= "12:11",
                Text= "I passed you on the ride to work today, see you later.",
              },
            };
    }

    private void InitMessages()
    {
        if (_messages is not null) return;

        _messages = new List<MessageModel> {
              new MessageModel
              {
                Sender = null,
                Time = "18:42",
                Text = "Yeah I know. I\'m in the same position 😂",
              },
              new MessageModel
              {
                Sender = user1,
                Time = "18:39",
                Text = "It\'s hard to be productive, man 😞",
              },
              new MessageModel
              {
                Sender = user1,
                Time = "18:39",
                Text =
                    "Same here! Been watching YouTube for the past 5 hours despite of having so much to do! 😅",
              },
              new MessageModel
              {
                Sender = null,
                Time = "18:36",
                Text = "Nothing. Just chilling and watching YouTube. What about you?",
              },
              new MessageModel
              {
                Sender= user1,
                Time = "18:35",
                Text= "Hey there! What\'s up?",
              },
            };
    }

    public List<MessageModel> GetMessages(UserChatModel sender)
    {
        InitMessages();

        foreach(var message in _messages)
        {
            if (message.Sender is not null)
            {
                message.Sender = sender;
            }
        }

        return _messages;
    }

    public MessageModel SendMessage(string message)
    {
        InitMessages();

        var model = new MessageModel
        {
            Sender = null,
            Time = "Now",
            Text = message
        };

        _messages.Add(model);

        return model;
    }
}