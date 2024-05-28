using CoolChat.Domain.Entities;

namespace CoolChat.Infrastructure;

public class ApplicationDbContext
{
    public readonly List<Message> Messages = new();
}