namespace CoolChat.Client;

public class Program
{
    private static string _username = "user";
    
    public static async Task Main()
    {
        var url = "http://127.0.0.1:5231/";
        var server = new Server;

        // Map the default hub url (/signalr)
        server.MapHubs();

        // Start the server
        server.Start();

        Console.WriteLine("Server running on {0}", url);

        // Keep going until somebody hits 'x'
        while (true) {
            var ki = Console.ReadKey(true);
            if (ki.Key == ConsoleKey.X) {
                break;
            }
        }
        
        /*do
        {
            var entered = Console.ReadLine();
            if (entered.Any(char.IsLetter))
            {
                _username = entered;
                break;
            }

            Console.WriteLine("Name should contain only letters!!!");
        } while (true);
        
        var hubClient = new ChatHub("http://localhost:5231/chat");
        await hubClient.ConnectAsync();

        Console.WriteLine("Entered chat!");
        do
        {
            var message = Console.ReadLine();
            await hubClient.SendMessage(_username, message);
        } while (true);*/
    }
}