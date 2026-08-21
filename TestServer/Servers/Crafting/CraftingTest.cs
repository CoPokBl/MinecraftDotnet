using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features.Impl;
using ManagedServer.Inventories;
using ManagedServer.Recipes;
using ManagedServer.Terrain.Data;
using ManagedServer.Features;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Schemas;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.Crafting;

/// <summary>
/// Crafting demo: the two by two in your own inventory and the three by three of a crafting table,
/// running the vanilla recipes.
/// <p/>
/// A demo rather than a test because the result slot is <b>client predicted</b>: the client draws its
/// own ghost recipe and then whatever the server puts in slot zero, so a result that is right but
/// late looks like a flickering slot. A fixture on this side cannot see that.
/// <p/>
/// The recipes are fetched at startup rather than shipped, because nothing Mojang wrote lives in this
/// repository. Here the pack is the vanilla server jar, cached after the first download.
/// </summary>
public static class CraftingTest {
    private static readonly Vec3<double> SpawnPos = new(0.5, CraftingMapProvider.FloorY + 1, 0.5);

    /// <summary>Enough of the common ingredients to reach most of the recipe tree.</summary>
    private static readonly ItemStack[] Hotbar = [
        new(Item.OakLog, 64),
        new(Item.OakPlanks, 64),
        new(Item.Stick, 64),
        new(Item.Cobblestone, 64),
        new(Item.IronIngot, 64),
        new(Item.Diamond, 64),
        new(Item.Redstone, 64),
        new(Item.Wheat, 64),
        new(Item.Sugar, 64)
    ];

    /// <summary>
    /// The rest of a cake, which is the demo's crafting remainder: its three buckets come back. Three
    /// separate stacks of milk, because a bucket does not stack and the recipe wants three at once.
    /// </summary>
    private static readonly ItemStack[] Pantry = [
        new(Item.MilkBucket),
        new(Item.MilkBucket),
        new(Item.MilkBucket),
        new(Item.Egg, 16)
    ];

    public static async Task Start() {
        Console.WriteLine("Fetching the vanilla datapack for its recipes...");
        IDatapackSource pack = await VanillaDatapack.Download();

        ManagedMinecraftServer server = ManagedMinecraftServer.New(
            ManagedMinecraftServer.BasicsBundle,
            ManagedMinecraftServer.BlockRulesBundle,
            ManagedMinecraftServer.BlockInteractionsBundle);

        DatapackCraftingRecipes recipes = DatapackCraftingRecipes.Load(pack, server.Registry);
        foreach (string line in recipes.DescribeDeclined()) {
            Console.WriteLine(line);
        }

        Console.WriteLine($"{recipes.Recipes.Count} crafting recipes loaded.");

        // Not in any bundle, and its recipes are an argument: nothing here ships a default.
        server.FeatureHandler.AddFeature(new CraftingFeature(recipes));

        World world = server.CreateWorld(new GeneratorTerrainProvider(new CraftingMapProvider()));

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            // Survival, because the point is spending ingredients you actually have.
            e.GameMode = GameMode.Survival;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(SpawnPos);
            GiveKit(e.Player);
            Welcome(e.Player);
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            e.Cancelled = true;

            if (e.RawMessage.Trim().ToLowerInvariant() != "kit") {
                return;
            }

            GiveKit(e.Player);
            Tell(e.Player, "&aHere you go.");
        });

        server.Start();
        await server.ListenTcp(25565);
    }

    private static void GiveKit(Player player) {
        for (int slot = 0; slot < Hotbar.Length; slot++) {
            player.Inventory.SetHotbarItem(slot, Hotbar[slot]);
        }

        for (int slot = 0; slot < Pantry.Length; slot++) {
            player.Inventory[PlayerInventory.MainInventorySlots[slot]] = Pantry[slot];
        }
    }

    private static void Welcome(Player player) {
        Tell(player, "");
        Tell(player, "&6&lCrafting");
        Tell(player, "&7Your own &f2x2&7 is in your inventory screen; the &f3x3&7 is the table in front of you.");
        Tell(player, "&7Left click the result to take one, shift click to take the lot, a number key");
        Tell(player, "&7to send one to that hotbar slot, Q to throw it.");
        Tell(player, "&7Try a &fcake&7 in the table: &fmilk&7 across the top, &fsugar egg sugar&7, then");
        Tell(player, "&f  wheat&7 across the bottom. The three buckets come back to you empty.");
        Tell(player, "&7Say &fkit&7 for more ingredients.");
        Tell(player, "");
    }

    private static void Tell(Player player, string message) {
        player.SendMessage(TextComponent.FromLegacyString(message));
    }
}

/// <summary>A stone yard with a crafting table to stand at, and nothing else.</summary>
public class CraftingMapProvider : IGenerator {
    public const int FloorY = 0;
    private const int Radius = 16;

    /// <summary>Directly in front of spawn.</summary>
    private static readonly Vec3<int> TablePos = new(0, FloorY + 1, 3);

    public void Generate(IGenerationUnit unit) {
        unit.Modifier.SetAll(BlockAt);
    }

    private static IBlock BlockAt(int x, int y, int z) {
        if (Math.Abs(x) > Radius || Math.Abs(z) > Radius) {
            return Block.Air;
        }

        if (new Vec3<int>(x, y, z) == TablePos) {
            return Block.CraftingTable;
        }

        return y == FloorY ? Block.SmoothStone : Block.Air;
    }
}
