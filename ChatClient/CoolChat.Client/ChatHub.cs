using CoolChat.Client.Entities;
using Microsoft.AspNet.SignalR.Client;

namespace CoolChat.Client;

public class ChatHub(string chatUrl)
{
    private HubConnection _conn { get; set; }
    private IHubProxy _hubProxy { get; set; }
    
    public async Task ConnectAsync()
    {
        _conn = new HubConnection(chatUrl);
        Console.WriteLine(_conn.Url);
        _hubProxy = _conn.CreateHubProxy("ChatHubProxy");
        _hubProxy.On("LoadHistory", messages => ReceiveMessages(messages));
        _hubProxy.On("ReceiveMessage", message => ReceiveMessages(message));
        
        await _conn.Start();
    }

    public async Task SendMessage(string username, string message)
    {
        var msg = new Message
        {
            Username = username,
            Content = message
        };
        await _hubProxy.Invoke("SendMessage", message);
    }

    private void ReceiveMessages(params Message[] messages)
    {
        foreach (var m in messages)
        {
            Console.WriteLine();
            Console.WriteLine(m.ToString());
        }
    }
}