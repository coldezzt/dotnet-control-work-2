using CoolChat.Domain.Entities;

namespace CoolChat.Domain.Abstractions.Services;

public interface IMessageService
{
    Task<List<Message>> GetMessagesListAsync();
    
    Task<Message> SendMessage(Message m);
}