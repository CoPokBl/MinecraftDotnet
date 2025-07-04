using TestServer.Servers.AnvilTesting;
using TestServer.Servers.BlockSumo;
using TestServer.Servers.BlockSumoFFA;
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
    
    case "anvil":
        await AnvilTesting.Start();
        break;
    
    case "blocksumo":
        await BlockSumo.Start();
        break;
    
    case "blocksumoffa":
        await BlockSumoFfa.Start();
        break;
    
    default:
        Console.WriteLine("Invalid gamemode specified.");
        return 1;
}

await Task.Delay(-1);
return 0;
