using TestServer.Servers.Everything;
using TestServer.Servers.MlgRush;

if (args.Length == 0) {
    Console.WriteLine("Please specify a gamemode.");
    return 1;
}

switch (args[0]) {
    case "mlgrush":
        await MlgRush.Start();
        break;
    
    case "testing":
        // await Everything.Start();
        break;
    
    default:
        Console.WriteLine("Invalid gamemode specified.");
        return 1;
}

await Task.Delay(-1);
return 0;