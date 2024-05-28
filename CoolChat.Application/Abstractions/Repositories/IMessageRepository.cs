using CoolChat.Domain.Entities;

namespace CoolChat.Application.Abstractions.Repositories;

public interface IMessageRepository
{
    Task<List<Message>> GetMessagesList();
    Task<Message> SendMessage(Message message);
}