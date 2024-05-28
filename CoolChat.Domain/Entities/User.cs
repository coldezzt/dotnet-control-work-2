using CoolChat.Domain.Abstractions.Entities;

namespace CoolChat.Domain.Entities;

public class User : IEntity
{
    public long Id { get; set; }
    public string Name { get; set; }

    public List<Message> Messages { get; set; }
}