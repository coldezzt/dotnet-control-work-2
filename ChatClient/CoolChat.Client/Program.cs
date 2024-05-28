namespace CoolChat.Client;

public class Program
{
    private static string _username = "user";
    
    public static async Task Main()
    {
        var hubClient = new HubClient("http://localhost:5231/chat");
        await hubClient.ConnectAsync();

        Console.WriteLine("Entered chat!");
        do
        {
            var message = Console.ReadLine();
            await hubClient.SendMessageAsync(_username, message);
        } while (true);
    }
}