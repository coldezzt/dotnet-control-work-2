using CoolChat.Client.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace CoolChat.Client;

public class HubClient(string chatUrl)
{
    private HubConnection _conn { get; set; }
    
    public async Task ConnectAsync()
    {
        _conn = new HubConnectionBuilder()
            .WithUrl(chatUrl)
            .Build();
        
        _conn.On<List<Message>>("LoadHistory", messages => ReceiveMessages(messages.ToArray()));
        _conn.On<Message>("ReceiveMessage", message => ReceiveMessages(message));
        
        await _conn.StartAsync();
    }

    public async Task SendMessageAsync(string username, string message)
    {
        await _conn.InvokeAsync("SendMessageAsync", username, message);
    }

    private void ReceiveMessages(params Message[] messages)
    {
        foreach (var m in messages)
            Console.WriteLine(m.ToString());
    }
}