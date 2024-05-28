using CoolChat.Domain.Entities;
using CoolChat.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace CoolChat.WebAPI.Controllers.Hubs;

public class ChatHub(ApplicationDbContext db) : Hub
{
    public override Task OnConnectedAsync()
    {
        Clients.Caller.SendAsync("LoadHistory", db.Messages).Wait();
        return base.OnConnectedAsync();
    }
    
    public async Task SendMessageAsync(string username, string message)
    {
        var m = new Message
        {
            Username = username,
            Content = message
        };
        
        db.Messages.Add(m);
        
        if (Clients is not null)
            await Clients.All.SendAsync("ReceiveMessage", m);
        
        Console.WriteLine(m.ToString());
    }
}