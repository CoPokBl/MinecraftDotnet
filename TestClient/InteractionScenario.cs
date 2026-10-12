using System.Diagnostics;
using System.Globalization;
using ClientLib;
using ClientLib.Interaction;
using ClientLib.Player;
using Minecraft.Packets.Play.ClientBound;

namespace TestClient;

/// <summary>
/// Digs, places and attacks against a real server, checking dig times against vanilla's known break
/// times and that the server never puts a broken block back, which it does when a client finishes
/// a dig sooner than its own count allows.
/// </summary>
public static class InteractionScenario {
    private record DigCase(string Label, string Block, string Tool, int ExpectedTicks, string Effect = "");

    /// <summary>
    /// Expected ticks are <c>ceil(1 / progress)</c> with progress per tick from
    /// <c>getDestroyProgress</c>: tool speed over hardness over 30, or over 100 without the right tool.
    /// A dig that ends a break leaves <c>destroyDelay</c> at 5, which only counts down while digging,
    /// so every dig after one that finished slowly starts five ticks late; that is added when checking.
    /// </summary>
    private static readonly DigCase[] Cases = [
        new("dirt by hand", "dirt", "air", 15),
        new("stone by hand", "stone", "air", 150),
        new("stone, wooden pickaxe", "stone", "wooden_pickaxe", 23),
        new("stone, iron pickaxe", "stone", "iron_pickaxe", 8),
        new("oak log, stone axe", "oak_log", "stone_axe", 15),
        new("sand, iron shovel", "sand", "iron_shovel", 3),
        new("obsidian, diamond pickaxe", "obsidian", "diamond_pickaxe", 188),
        new("oak leaves, shears", "oak_leaves", "shears", 1),
        new("stone, wooden pickaxe, haste II", "stone", "wooden_pickaxe", 17, "haste 60 1"),
        new("cobweb, iron sword", "cobweb", "iron_sword", 8)
    ];

    public static async Task<int> Run(string[] args) {
        string server = args.Length > 0 ? args[0] : "localhost:25570";
        string host = server.Split(':')[0];
        int port = server.Contains(':') ? int.Parse(server.Split(':')[1]) : 25565;
        const string name = "Digger";
        using Rcon rcon = new(host, 25575, "clienttest");
        string F(double v) => v.ToString(CultureInfo.InvariantCulture);

        const int x = 60, y = 200, z = 60;
        rcon.Run($"forceload add {x - 16} {z - 16} {x + 16} {z + 16}");
        rcon.Run($"fill {x - 4} {y - 1} {z - 4} {x + 4} {y - 1} {z + 4} stone");
        rcon.Run($"fill {x - 4} {y} {z - 4} {x + 4} {y + 4} {z + 4} air");
        rcon.Run($"op {name}");
        rcon.Run($"gamemode survival {name}");

        MinecraftClient client = new(new ClientOptions { Username = name, ViewDistance = 4 });
        int restored = 0;
        client.PacketReceived += packet => {
            if (packet is ClientBoundBlockUpdatePacket update && update.Location.X == x && update.Location.Y == y && update.Location.Z == z - 2
                && !update.Block.Air) {
                restored++;
            }
        };
        await client.Connect(host, port);

        async Task Ticks(int count, Action? each = null) {
            for (int i = 0; i < count; i++) {
                client.ProcessPackets();
                each?.Invoke();
                client.Tick();
                await Task.Delay(50);
            }
        }

        Stopwatch clock = Stopwatch.StartNew();
        while (!client.ClientLoaded) {
            await Ticks(1);
            if (clock.Elapsed > TimeSpan.FromSeconds(30)) {
                Console.WriteLine("Never loaded");
                return 1;
            }
        }

        // Stand two blocks back and look at the middle of the target's near face.
        rcon.Run($"tp {name} {F(x + 0.5)} {y} {F(z + 0.5)} 180 {F(26.0)}");
        rcon.Run($"effect give {name} resistance 600 4 true");
        await Ticks(30);
        LocalPlayer player = client.Player!;

        int failures = 0;
        bool delayPending = false;
        foreach (DigCase c in Cases) {
            rcon.Run($"effect clear {name} haste");
            if (c.Effect.Length > 0) {
                rcon.Run($"effect give {name} {c.Effect} true");
            }
            rcon.Run($"item replace entity {name} weapon.mainhand with {c.Tool}");
            rcon.Run($"setblock {x} {y} {z - 2} {c.Block}");
            await Ticks(10);
            AimAt(player, x + 0.5, y + 0.5, z - 1.0);

            int restoredBefore = restored;
            int ticks = 0;
            bool first = true;
            while (ticks < 400 && !client.Level!.IsAir(client.Level.GetState(x, y, z - 2))) {
                await Ticks(1, () => {
                    if (first) {
                        client.Interactions.Keys.Attack.Press();
                    }
                    client.Interactions.Tick();
                    first = false;
                });
                ticks++;
            }
            client.Interactions.Keys.Attack.SetDown(false);
            await Ticks(10, () => client.Interactions.Tick());
            bool brokenOnServer = rcon.Run($"execute if block {x} {y} {z - 2} air").Contains("passed");
            // Summing a float progress can land a hair short of 1, which costs vanilla the same extra tick.
            int expected = c.ExpectedTicks + (delayPending && c.ExpectedTicks > 1 ? 5 : 0);
            bool good = ticks >= expected && ticks <= expected + 1 && restored == restoredBefore && brokenOnServer;
            delayPending = c.ExpectedTicks > 1 || delayPending;
            failures += good ? 0 : 1;
            Console.WriteLine($"{(good ? "ok  " : "FAIL")} {c.Label}: broke in {ticks} ticks, vanilla {expected}, " +
                              $"server {(brokenOnServer ? "agrees" : "disagrees")}, restores {restored - restoredBefore}");
        }

        // Place: stone in hand, right click the top of the floor in front.
        rcon.Run($"item replace entity {name} weapon.mainhand with stone 4");
        rcon.Run($"setblock {x} {y} {z - 2} air");
        await Ticks(10);
        AimAt(player, x + 0.5, y, z - 1.5);
        client.Interactions.Keys.Use.Press();
        await Ticks(1, () => client.Interactions.Tick());
        client.Interactions.Keys.Use.SetDown(false);
        await Ticks(20, () => client.Interactions.Tick());
        bool placed = rcon.Run($"execute if block {x} {y} {z - 2} stone").Contains("passed")
                      || rcon.Run($"execute if block {x} {y} {z - 1} stone").Contains("passed");
        Console.WriteLine($"{(placed ? "ok  " : "FAIL")} place stone: {(placed ? "the server has it" : "nothing placed")}");
        failures += placed ? 0 : 1;

        // Attack: a zombie that cannot move, hit once.
        rcon.Run($"fill {x - 1} {y} {z - 3} {x + 1} {y + 2} {z - 1} air");
        rcon.Run($"summon zombie {x}.5 {y} {z - 2}.5 {{NoAI:1b,Tags:[\"target\"],Rotation:[0f,0f]}}");
        rcon.Run($"item replace entity {name} weapon.mainhand with diamond_sword");
        await Ticks(20);
        AimAt(player, x + 0.5, y + 1.2, z - 2.5);
        int hurt = 0;
        client.PacketReceived += packet => {
            if (packet is ClientBoundHurtAnimationPacket or ClientBoundDamageEventPacket) {
                hurt++;
            }
        };
        client.Interactions.Keys.Attack.Press();
        await Ticks(1, () => client.Interactions.Tick());
        client.Interactions.Keys.Attack.SetDown(false);
        await Ticks(20, () => client.Interactions.Tick());
        bool hit = hurt > 0;
        Console.WriteLine($"{(hit ? "ok  " : "FAIL")} attack zombie: target {(client.Interactions.Target is EntityHitResult ? "entity" : "not entity")}, damage events {hurt}");
        failures += hit ? 0 : 1;
        rcon.Run("kill @e[tag=target]");

        client.Disconnect("Done");
        Console.WriteLine(failures == 0 ? "All interaction checks passed" : $"{failures} interaction checks failed");
        return failures == 0 ? 0 : 1;
    }

    /// <summary>Points the player's eyes at a world position.</summary>
    private static void AimAt(LocalPlayer player, double tx, double ty, double tz) {
        double ex = player.Position.X, ey = player.Position.Y + player.CurrentEyeHeight, ez = player.Position.Z;
        double dx = tx - ex, dy = ty - ey, dz = tz - ez;
        float yaw = (float)(Math.Atan2(-dx, dz) * 180.0 / Math.PI);
        float pitch = (float)(-Math.Atan2(dy, Math.Sqrt(dx * dx + dz * dz)) * 180.0 / Math.PI);
        player.YRot = yaw;
        player.XRot = pitch;
        player.YRotO = yaw;
        player.XRotO = pitch;
    }
}
