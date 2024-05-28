namespace CoolChat.Domain.Entities;

public class Message
{
    public string Username { get; set; }
    public string Content { get; set; }

    public override string ToString()
    {
        return Username + ": " + Content;
    }
}

