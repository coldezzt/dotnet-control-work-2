using CoolChat.Application.Abstractions.Repositories;
using CoolChat.Domain.Abstractions.Services;
using CoolChat.Domain.Entities;

namespace CoolChat.Application.Services;

public class MessageService(IMessageRepository messageRepository) : IMessageService
{
    public async Task<List<Message>> GetMessagesListAsync()
    {
        return await messageRepository.GetMessagesList();
    }

    public async Task<Message> SendMessage(Message m)
    {
        var dbMessage = await messageRepository.SendMessage(m);
        return dbMessage;
    }
}