using ManagedServer.Viewables;
using ManagedServer;
using ManagedServer.Entities.Types;
using Minecraft.Schemas;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.Placement;

/// <summary>
/// Block placement demo. Everything here is decided by
/// <c>ManagedMinecraftServer.BlockPlacementRules</c>, a port of vanilla's
/// <c>Block.getStateForPlacement</c> and the hooks around it.
/// <p/>
/// The point of a demo rather than a test is that placement is <b>client predicted</b>. The client
/// works out the same state locally and draws it straight away, so a rule that disagrees with vanilla
/// shows up as a block that appears and then visibly changes a moment later. A test on this side
/// cannot see that; standing in the world and placing blocks can.
/// <p/>
/// Say <c>kit</c> to get the blocks back, <c>clear</c> to wipe what you have built.
/// </summary>
public static class PlacementTest {
    private static readonly Vec3<double> SpawnPos = new(0.5, PlacementMapProvider.FloorY + 1, 0.5);

    /// <summary>
    /// One block per family of rule, in the order the tour below walks through them. Nine, because
    /// that is a hotbar; the rest arrive through <c>kit</c> pages.
    /// </summary>
    private static readonly IItem[][] Kits = [
        [
            Item.OakStairs, Item.OakSlab, Item.OakTrapdoor, Item.OakLog, Item.OakFence,
            Item.CobblestoneWall, Item.GlassPane, Item.OakDoor, Item.WhiteBed
        ],
        [
            Item.Torch, Item.Lever, Item.StoneButton, Item.Ladder, Item.Lantern,
            Item.OakSign, Item.WhiteBanner, Item.SkeletonSkull, Item.WhiteCandle
        ],
        [
            Item.Furnace, Item.Observer, Item.Piston, Item.Hopper, Item.EndRod,
            Item.IronChain, Item.LightningRod, Item.Rail, Item.Sunflower
        ]
    ];

    public static async Task Start() {
        // BasicsBundle lets a player place a block; BlockRulesBundle is what decides the state it
        // lands in. Without the second, everything here places its default state.
        ManagedMinecraftServer server = ManagedMinecraftServer.New(
            ManagedMinecraftServer.BasicsBundle,
            ManagedMinecraftServer.BlockRulesBundle);

        World world = server.CreateWorld(new PlacementMapProvider());

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            // Creative, so the kit never runs out and the tour is about placement and nothing else.
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(SpawnPos);
            GiveKit(e.Player, 0);
            Welcome(e.Player);
        });

        server.Events.AddListener<PlayerChatEvent>(e => {
            e.Cancelled = true;
            HandleCommand(world, e.Player, e.RawMessage.Trim().ToLowerInvariant());
        });

        server.Start();
        await server.ListenTcp(25565);
    }

    private static void HandleCommand(World world, Player player, string message) {
        switch (message) {
            case "kit" or "kit 1":
                GiveKit(player, 0);
                Tell(player, "&aShapes and connections.");
                break;

            case "kit 2":
                GiveKit(player, 1);
                Tell(player, "&aThings that attach to surfaces.");
                break;

            case "kit 3":
                GiveKit(player, 2);
                Tell(player, "&aFacing, and the odd ones.");
                break;

            case "clear":
                Tell(player, "&7Rejoin to reset the yard.");
                break;

            case "help":
                Welcome(player);
                break;

            default:
                Tell(player, "&7Say &fkit&7, &fkit 2&7, &fkit 3&7 or &fhelp&7.");
                break;
        }
    }

    private static void GiveKit(Player player, int page) {
        IItem[] kit = Kits[page];
        for (int slot = 0; slot < 9; slot++) {
            player.Inventory.SetHotbarItem(slot, slot < kit.Length
                ? new ItemStack(kit[slot], 64)
                : ItemStack.Air);
        }
    }

    /// <summary>
    /// The tour. Each line is one thing to try and what it is actually demonstrating, because a stair
    /// facing the right way looks like nothing happening unless you know it could have gone wrong.
    /// </summary>
    private static void Welcome(Player player) {
        Tell(player, "&aBlock placement demo. &7Say &fkit 2&7 and &fkit 3&7 for the other blocks.");
        Tell(player, "");
        Tell(player, "&e Shapes &7(kit 1)");
        Tell(player, "&7  Stairs face away from you, and take their half from where on the block you click.");
        Tell(player, "&7  Put two stairs across each other and they corner. Break one and the other straightens.");
        Tell(player, "&7  Click the top of a slab in the row south of you with another oak slab: it doubles.");
        Tell(player, "&7  A spruce slab on the same slab does not, it stacks. Only matching slabs merge.");
        Tell(player, "&7  A log lies along whichever face you hit. Fences and walls join up as you lay them.");
        Tell(player, "&7  A wall goes tall under a solid block and low under open sky.");
        Tell(player, "&7  A door needs two blocks of room and writes its own top half.");
        Tell(player, "&7  Two doors side by side hinge towards each other. A bed lays out away from you.");
        Tell(player, "");
        Tell(player, "&e Attaching &7(kit 2) &7- use the brick wall to the north");
        Tell(player, "&7  Aim at the wall for a wall torch, at the floor for a standing one.");
        Tell(player, "&7  Levers and buttons take floor, wall or ceiling from where you aimed.");
        Tell(player, "&7  A lantern hangs from a ceiling and stands on a floor.");
        Tell(player, "&7  Signs, banners and skulls turn to one of sixteen steps, from your exact yaw.");
        Tell(player, "&7  Candles stack to four. Sneak to place a separate one instead of adding.");
        Tell(player, "");
        Tell(player, "&e Water &7- the pool to the east");
        Tell(player, "&7  Slabs, stairs, fences and signs come out waterlogged when placed into it.");
        Tell(player, "&7  Doubling a waterlogged slab clears the water, because a full block has no room.");
        Tell(player, "");
        Tell(player, "&e Replacing &7- the snow and grass to the south");
        Tell(player, "&7  Blocks go into them, not beside them. Snow one layer deep gives way to anything.");
        Tell(player, "");
        Tell(player, "&e Facing &7(kit 3)");
        Tell(player, "&7  A furnace turns its front to you; an observer and a piston point away from you.");
        Tell(player, "&7  End rods and lightning rods point out of the face you clicked, in any direction.");
        Tell(player, "&7  A hopper points at the block you clicked, except upwards, which becomes down.");
        Tell(player, "");
        Tell(player, "&8Placement is client predicted: if a block appears and then changes, a rule is wrong.");
    }

    private static void Tell(Player player, string message) {
        player.SendMessage(TextComponent.FromLegacyString(message));
    }
}
