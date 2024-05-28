using CoolChat.Domain.Abstractions.Entities;

namespace CoolChat.Domain.Entities;

public class Message : IEntity
{
    public long Id { get; set; }
    
    public long AuthorId { get; set; }
    public User Author { get; set; }
    
    public string Content { get; set; }
}

