using System.Diagnostics;
using ClientLib;
using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace TestClient;

/// <summary>
/// Drives every kind of container click against a vanilla server, in the player's inventory and in a
/// chest, and counts how often the server disagreed with the client's prediction. A disagreement on
/// the state id is a full <c>container_set_content</c>; one on a slot's contents or hash is a
/// <c>container_set_slot</c> for that slot. Both should be zero.
/// <p/>
/// Usage: <c>inventory [host:port] [rconPort] [rconPassword]</c>. The server must allow RCON and run
/// in offline mode.
/// </summary>
public static class InventoryScenario {
    public static async Task<int> Run(string[] args) {
        string server = args.Length > 0 ? args[0] : "localhost:25570";
        int rconPort = args.Length > 1 ? int.Parse(args[1]) : 25575;
        string rconPassword = args.Length > 2 ? args[2] : "clienttest";
        string host = server.Split(':')[0];
        int port = server.Contains(':') ? int.Parse(server.Split(':')[1]) : 25565;
        const string name = "Clicker";

        using Rcon rcon = new(host, rconPort, rconPassword);
        rcon.Run($"op {name}");
        rcon.Run("fill -3 199 -3 3 199 3 stone");
        rcon.Run("fill -3 200 -3 3 202 3 air");
        rcon.Run("setblock 1 200 0 chest");
        rcon.Run("data merge block 1 200 0 {Items:[]}");

        MinecraftClient client = new(new ClientOptions { Username = name, ViewDistance = 4 });
        List<string> disagreements = [];
        int resyncs = 0, corrections = 0;
        bool counting = false;
        string step = "";
        client.PacketReceived += packet => {
            if (!counting) {
                return;
            }
            switch (packet) {
                case ClientBoundSetContainerContentPacket content:
                    resyncs++;
                    disagreements.Add($"{step}: full resync of window {content.WindowId}");
                    break;
                case ClientBoundSetContainerSlotPacket slot:
                    corrections++;
                    disagreements.Add($"{step}: slot {slot.SlotId} of window {slot.WindowId} set to {slot.Data.Count} {slot.Data.Type.Identifier}");
                    break;
            }
        };
        client.Log += message => {
            if (message.StartsWith("Disconnected", StringComparison.Ordinal) || message.StartsWith("[network]", StringComparison.Ordinal)) {
                Console.WriteLine(message);
            }
        };

        await client.Connect(host, port);
        Stopwatch clock = Stopwatch.StartNew();
        while (!client.ClientLoaded && clock.Elapsed < TimeSpan.FromSeconds(30)) {
            Pump(client, 1);
        }
        if (!client.ClientLoaded) {
            Console.WriteLine("Never loaded");
            return 1;
        }

        rcon.Run($"gamemode survival {name}");
        rcon.Run($"tp {name} 0 200 0 -90 30");
        rcon.Run($"clear {name}");
        rcon.Run($"give {name} stone 64");
        rcon.Run($"give {name} stone 30");
        rcon.Run($"give {name} dirt 20");
        rcon.Run($"give {name} iron_chestplate");
        rcon.Run($"give {name} diamond_pickaxe[damage=100]");
        rcon.Run($"give {name} diamond_sword[custom_name='Bob']");
        rcon.Run($"give {name} iron_sword[enchantments={{sharpness:3}}]");
        rcon.Run($"give {name} oak_planks 8");
        Pump(client, 30);

        int clicks = 0;
        void Click(string label, int slot, int button, ContainerInput input) {
            if (slot == -1) {
                disagreements.Add($"{label}: the scenario found no slot to click");
                return;
            }
            clicks++;
            step = label;
            client.ClickContainer(slot, button, input);
            Pump(client, 4);
        }

        counting = true;
        int Find(string item, int start = 9, int end = 45) {
            for (int i = start; i < end; i++) {
                if (client.ActiveMenu.Slots[i].Item.Item.Identifier.Key == item) {
                    return i;
                }
            }
            return -1;
        }
        int Empty(int start, int end) {
            for (int i = start; i < end; i++) {
                if (!client.ActiveMenu.Slots[i].HasItem) {
                    return i;
                }
            }
            return -1;
        }

        // The player's own menu.
        int stone = Find("stone");
        Click("pick up", stone, 0, ContainerInput.Pickup);
        Click("put down", Empty(9, 36), 0, ContainerInput.Pickup);
        stone = Find("stone");
        Click("split", stone, 1, ContainerInput.Pickup);
        Click("place one", Empty(9, 36), 1, ContainerInput.Pickup);
        Click("place rest on own kind", Find("stone"), 0, ContainerInput.Pickup);
        int dirt = Find("dirt");
        Click("pick up dirt", dirt, 0, ContainerInput.Pickup);
        Click("swap with stone", Find("stone"), 0, ContainerInput.Pickup);
        Click("put down stone", Empty(9, 36), 0, ContainerInput.Pickup);
        Click("number key swap", Find("dirt"), 4, ContainerInput.Swap);
        Click("offhand swap", Find("stone"), 40, ContainerInput.Swap);
        Click("offhand back", 45, 40, ContainerInput.Swap);
        Click("shift click to main", Find("iron_sword", 36, 45) is var s1 and >= 0 ? s1 : Find("iron_sword"), 0, ContainerInput.QuickMove);
        Click("shift click armour on", Find("iron_chestplate"), 0, ContainerInput.QuickMove);
        Click("shift click armour off", 6, 0, ContainerInput.QuickMove);
        Click("shift click damaged pickaxe", Find("diamond_pickaxe"), 0, ContainerInput.QuickMove);
        Click("shift click named sword", Find("diamond_sword"), 0, ContainerInput.QuickMove);
        Click("shift click enchanted sword", Find("iron_sword"), 0, ContainerInput.QuickMove);

        Click("pick up stone for drag", Find("stone"), 0, ContainerInput.Pickup);
        int dragFirst = Empty(9, 36);
        Click("drag start", -999, ContainerMenu.QuickcraftMask(0, 0), ContainerInput.QuickCraft);
        Click("drag 1", dragFirst, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click("drag 2", dragFirst + 1, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click("drag 3", dragFirst + 2, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click("drag end", -999, ContainerMenu.QuickcraftMask(2, 0), ContainerInput.QuickCraft);
        if (!client.ActiveMenu.Carried.IsEmpty) {
            Click("right drag start", -999, ContainerMenu.QuickcraftMask(0, 1), ContainerInput.QuickCraft);
            Click("right drag 1", Empty(9, 36), ContainerMenu.QuickcraftMask(1, 1), ContainerInput.QuickCraft);
            Click("right drag end", -999, ContainerMenu.QuickcraftMask(2, 1), ContainerInput.QuickCraft);
        }
        if (!client.ActiveMenu.Carried.IsEmpty) {
            Click("put down remainder", Empty(9, 36), 0, ContainerInput.Pickup);
        }
        Click("collect for double click", Find("stone"), 0, ContainerInput.Pickup);
        Click("double click", Empty(9, 36), 0, ContainerInput.PickupAll);
        Click("put down collected", Empty(9, 36), 0, ContainerInput.Pickup);
        Click("throw one", Find("dirt"), 0, ContainerInput.Throw);
        Click("throw stack", Find("dirt"), 1, ContainerInput.Throw);

        // A crafting grid: two planks make sticks once the server fills the result.
        Click("planks up", Find("oak_planks"), 0, ContainerInput.Pickup);
        Click("plank into grid", 1, 1, ContainerInput.Pickup);
        Click("plank into grid below", 3, 1, ContainerInput.Pickup);
        Click("planks back", Empty(9, 36), 0, ContainerInput.Pickup);
        Pump(client, 6);
        if (client.ActiveMenu.Slots[0].HasItem) {
            Click("take craft", 0, 0, ContainerInput.Pickup);
            Click("put craft away", Empty(9, 36), 0, ContainerInput.Pickup);
        }
        else {
            disagreements.Add("craft: the server never filled the result slot");
        }
        // The server answers every grid change with the result slot, which is the server talking
        // rather than disagreeing, so those are counted apart.
        int craftResultUpdates = disagreements.Count(d => d.Contains("slot 0 of window 0"));

        step = "close inventory";
        client.CloseContainer();
        Pump(client, 6);

        // A chest.
        step = "open chest";
        counting = false;
        client.Send(new ServerBoundUseItemOnPacket {
            ActiveHand = Hand.MainHand,
            Position = new Vec3<int>(1, 200, 0),
            Face = BlockFace.PosY,
            CursorPosition = new Vec3<float>(0.5F, 1.0F, 0.5F),
            InsideBlock = false,
            WorldBorderHit = false,
            Sequence = 1
        });
        clock.Restart();
        while (client.OpenContainer == null && clock.Elapsed < TimeSpan.FromSeconds(5)) {
            Pump(client, 1);
        }
        Pump(client, 4);
        if (client.OpenContainer is not ChestMenu chest) {
            Console.WriteLine($"Chest did not open, got {client.OpenContainer?.GetType().Name ?? "nothing"}");
            return 1;
        }
        counting = true;
        int chestSize = chest.Rows * 9;
        int Inv(string item) => Find(item, chestSize, chestSize + 36);

        Click("shift into chest", Inv("stone"), 0, ContainerInput.QuickMove);
        Click("shift damaged pickaxe in", Inv("diamond_pickaxe"), 0, ContainerInput.QuickMove);
        Click("shift out of chest", Find("stone", 0, chestSize), 0, ContainerInput.QuickMove);
        Click("pick up for chest", Inv("stone"), 0, ContainerInput.Pickup);
        Click("drag into chest start", -999, ContainerMenu.QuickcraftMask(0, 0), ContainerInput.QuickCraft);
        Click("drag chest 1", 3, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click("drag chest 2", 4, ContainerMenu.QuickcraftMask(1, 0), ContainerInput.QuickCraft);
        Click("drag chest end", -999, ContainerMenu.QuickcraftMask(2, 0), ContainerInput.QuickCraft);
        if (!chest.Carried.IsEmpty) {
            Click("place leftover", Empty(chestSize, chestSize + 36), 0, ContainerInput.Pickup);
        }
        Click("number swap in chest", 3, 0, ContainerInput.Swap);
        Click("chest collect", Find("stone", 0, chestSize + 36), 0, ContainerInput.Pickup);
        Click("chest double click", Empty(0, chestSize), 0, ContainerInput.PickupAll);
        Click("chest put down", 10, 0, ContainerInput.Pickup);
        Click("shift named sword in", Inv("diamond_sword"), 0, ContainerInput.QuickMove);

        step = "close chest";
        client.CloseContainer();
        Pump(client, 6);
        counting = false;

        Console.WriteLine($"Clicks: {clicks}");
        Console.WriteLine($"Full resyncs: {resyncs}");
        Console.WriteLine($"Slot corrections: {corrections} ({craftResultUpdates} of them the crafting result the server computes)");
        foreach (string line in disagreements) {
            Console.WriteLine($"  {line}");
        }
        client.Disconnect("Done");
        return resyncs == 0 && corrections == craftResultUpdates ? 0 : 1;
    }

    private static void Pump(MinecraftClient client, int ticks) {
        for (int i = 0; i < ticks; i++) {
            client.ProcessPackets();
            client.Tick();
            Thread.Sleep(50);
        }
        client.ProcessPackets();
    }
}
