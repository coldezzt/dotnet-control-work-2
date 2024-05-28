using CoolChat.Domain.Abstractions.Entities;

namespace CoolChat.Domain.Entities;

public class Message : IEntity
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Content { get; set; }
}

