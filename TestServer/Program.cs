using Minecraft.Data.Generated;
using Minecraft.Registry.Templates;
using TestServer.Servers.AnvilTesting;
using TestServer.Servers.BlockSumoFFA;
using TestServer.Servers.Everything;
using TestServer.Servers.MlgRush;
using TestServer.Servers.SkyWarsLuckyBlock;
using TestServer.Servers.Transferer;

// File.WriteAllBytes("polar.polar", PolarLoader.CreateWorld(new AnvilLoader("anvil", VanillaRegistry.Data)));
// return 0;

foreach (var subReg in VanillaRegistry.Data.SubRegistries) {
    if (subReg is IProtocolTypeRegistry reg) {
        for (int i = 0; i < reg.Count; i++) {
            if (!reg.Contains(i)) {
                Console.WriteLine($"No {reg.GetType().Name} for " + i + "");
            }
        }
        Console.WriteLine("Count: " + reg.Count);
    }
}


return 0;

if (args.Length == 0) {
    Console.WriteLine("Please specify a gamemode.");
    return 1;
}

switch (args[0]) {
    case "mlgrush":
        await MlgRush.Start();
        break;
    
    case "testing":
        await Everything.Start();
        break;
    
    case "anvil":
        await AnvilTesting.Start();
        break;
    
    case "blocksumoffa":
        await BlockSumoFfa.Start();
        break;
    
    case "skywars":
        await SkyWarsLuckyBlock.Start();
        break;
    
    case "transfer":
        await TransferTest.Start();
        break;
    
    default:
        Console.WriteLine("Invalid gamemode specified.");
        return 1;
}

return 0;
