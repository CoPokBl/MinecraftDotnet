using System.Diagnostics;
using System.Globalization;
using ClientLib;
using ClientLib.Player;
using ClientLib.Testing;
using Minecraft.Packets.Play.ClientBound;

namespace TestClient;

/// <summary>
/// Walks a headless client through every kind of movement on a vanilla server and counts the times
/// the server disagreed. Terrain is built over RCON high above spawn, so the route is the same every
/// run whatever the world generated.
/// <p/>
/// Usage: <c>movement [host:port] [rconPort] [rconPassword]</c>. The server must allow RCON and run
/// in offline mode; a disagreement shows up as a <c>player_position</c> the scenario did not ask for,
/// and as "moved wrongly" in the server log.
/// </summary>
public static class MovementScenario {
    public static async Task<int> Run(string[] args) {
        string server = args.Length > 0 ? args[0] : "localhost:25570";
        int rconPort = args.Length > 1 ? int.Parse(args[1]) : 25575;
        string rconPassword = args.Length > 2 ? args[2] : "clienttest";
        string host = server.Split(':')[0];
        int port = server.Contains(':') ? int.Parse(server.Split(':')[1]) : 25565;
        const string name = "Mover";

        using Rcon rcon = new(host, rconPort, rconPassword);
        rcon.Run($"op {name}");
        rcon.Run($"gamemode survival {name}");
        rcon.Run($"effect clear {name}");

        MinecraftClient client = new(new ClientOptions { Username = name, ViewDistance = 6 });
        int teleportsSeen = 0;
        int teleportsExpected = 0;
        List<string> unexpected = [];
        string phase = "join";
        client.PacketReceived += packet => {
            if (packet is ClientBoundSynchronisePlayerPositionPacket sync) {
                teleportsSeen++;
                if (teleportsSeen > teleportsExpected) {
                    unexpected.Add($"{phase}: corrected to {sync.Position.X:F3} {sync.Position.Y:F3} {sync.Position.Z:F3}");
                    teleportsExpected = teleportsSeen;
                }
            }
        };
        client.Log += message => {
            if (message.StartsWith("Disconnected", StringComparison.Ordinal) || message.StartsWith("[network]", StringComparison.Ordinal)) {
                Console.WriteLine(message);
            }
        };

        // The join itself sends one teleport, and the server may resend it before the client loads.
        teleportsExpected = 2;
        await client.Connect(host, port);

        Stopwatch clock = Stopwatch.StartNew();
        while (!client.ClientLoaded) {
            client.ProcessPackets();
            client.Tick();
            if (client.Phase == ClientPhase.Disconnected || clock.Elapsed > TimeSpan.FromSeconds(30)) {
                Console.WriteLine($"Never loaded: {client.DisconnectReason}");
                return 1;
            }
            await Task.Delay(50);
        }

        LocalPlayer player = client.Player!;
        int ox = (int)Math.Floor(player.Position.X);
        int oz = (int)Math.Floor(player.Position.Z);
        const int y = 200;
        string F(double v) => v.ToString(CultureInfo.InvariantCulture);
        void Command(string command) {
            string reply = rcon.Run(command);
            if (reply.Length > 0 && !reply.StartsWith("Successfully", StringComparison.Ordinal)
                && !reply.StartsWith("Teleported", StringComparison.Ordinal) && !reply.StartsWith("Set ", StringComparison.Ordinal)
                && !reply.StartsWith("Applied", StringComparison.Ordinal) && !reply.StartsWith("Changed", StringComparison.Ordinal)) {
                Console.WriteLine($"  rcon {command}: {reply}");
            }
        }
        void Teleport(double x, double ty, double z, float yaw) {
            teleportsExpected++;
            Command($"tp {name} {F(x)} {F(ty)} {F(z)} {F(yaw)} 0");
        }

        // A stone platform, a slab step, a one block step, a ladder, cobwebs, and a water pool beside it.
        Command($"fill {ox - 12} {y - 1} {oz - 6} {ox + 12} {y - 1} {oz + 60} stone");
        Command($"fill {ox - 12} {y} {oz - 6} {ox + 12} {y + 8} {oz + 60} air");
        Command($"fill {ox - 3} {y} {oz + 30} {ox + 3} {y} {oz + 30} stone_slab");
        Command($"fill {ox - 3} {y} {oz + 34} {ox + 3} {y} {oz + 60} stone");
        Command($"fill {ox + 8} {y} {oz + 10} {ox + 8} {y + 6} {oz + 10} stone");
        Command($"fill {ox + 8} {y} {oz + 11} {ox + 8} {y + 6} {oz + 11} ladder[facing=south]");
        Command($"fill {ox - 8} {y} {oz + 10} {ox - 8} {y + 1} {oz + 12} cobweb");
        Command($"fill {ox - 13} {y - 6} {oz + 70} {ox + 13} {y - 1} {oz + 100} stone");
        Command($"fill {ox - 12} {y - 5} {oz + 71} {ox + 12} {y - 1} {oz + 99} water");
        // Surfaces that change friction, speed, jump and bounce, and a lava pool, behind the platform.
        Command($"fill {ox - 6} {y - 1} {oz - 40} {ox - 6} {y - 1} {oz - 10} ice");
        Command($"fill {ox - 3} {y - 1} {oz - 40} {ox - 3} {y - 1} {oz - 10} soul_sand");
        Command($"fill {ox} {y - 1} {oz - 40} {ox} {y - 1} {oz - 10} honey_block");
        Command($"fill {ox + 3} {y - 1} {oz - 40} {ox + 3} {y - 1} {oz - 10} slime_block");
        Command($"fill {ox - 12} {y - 1} {oz - 40} {ox + 12} {y - 1} {oz - 11} stone replace air");
        Command($"fill {ox - 12} {y} {oz - 40} {ox + 12} {y + 10} {oz - 7} air");
        Command($"fill {ox + 20} {y - 6} {oz - 6} {ox + 30} {y - 1} {oz + 6} stone");
        Command($"fill {ox + 21} {y - 5} {oz - 5} {ox + 29} {y - 1} {oz + 5} lava");
        Command("time set day");
        Command("weather clear");

        ScriptedInput script = new();
        script
            .Idle("settle", 40)
            .Do("tp platform", () => Teleport(ox + 0.5, y, oz + 0.5, 0))
            .Idle("land", 40)
            .Hold("walk", new PlayerInput(Forward: true), 40, 0)
            .Hold("strafe left", new PlayerInput(Left: true), 30, 0)
            .Hold("strafe right", new PlayerInput(Right: true), 30, 0)
            .Hold("back", new PlayerInput(Backward: true), 30, 0)
            .Hold("diagonal", new PlayerInput(Forward: true, Right: true), 20, 0)
            .Hold("jump walk", new PlayerInput(Forward: true, Jump: true), 40, 0)
            .Idle("stop", 20)
            .Do("tp start", () => Teleport(ox + 0.5, y, oz - 5.5, 0))
            .Idle("land", 20)
            .Hold("sprint", new PlayerInput(Forward: true, Sprint: true), 25, 0)
            .Hold("sprint jump", new PlayerInput(Forward: true, Sprint: true, Jump: true), 30, 0)
            .Hold("over the slab and step", new PlayerInput(Forward: true, Jump: true), 40, 0)
            .Idle("stop", 20)
            .Do("tp double tap", () => Teleport(ox + 0.5, y, oz + 0.5, 0))
            .Idle("land", 20)
            .Hold("tap", new PlayerInput(Forward: true), 2, 0)
            .Idle("release", 2)
            .Hold("double tap sprint", new PlayerInput(Forward: true), 30, 0)
            .Idle("stop", 20)
            .Do("tp edge", () => Teleport(ox + 10.5, y, oz + 0.5, 0))
            .Idle("land", 20)
            .Hold("sneak to the edge", new PlayerInput(Left: true, Shift: true), 80, 0)
            .Hold("sneak along the edge", new PlayerInput(Forward: true, Left: true, Shift: true), 40, 0)
            .Hold("stand up", PlayerInput.None, 10, 0)
            .Do("tp ladder", () => Teleport(ox + 8.5, y, oz + 13.5, 180))
            .Idle("land", 20)
            .Hold("climb", new PlayerInput(Forward: true), 60, 180)
            .Hold("hold on", new PlayerInput(Shift: true), 20, 180)
            .Hold("slide down", PlayerInput.None, 40, 180)
            .Do("tp web", () => Teleport(ox - 7.5, y, oz + 8.5, 0))
            .Idle("land", 20)
            .Hold("through the web", new PlayerInput(Forward: true), 80, 0)
            .Do("creative", () => Command($"gamemode creative {name}"))
            .Do("tp fly", () => Teleport(ox + 0.5, y, oz + 0.5, 0))
            .Idle("land", 20)
            .Hold("tap jump", new PlayerInput(Jump: true), 1)
            .Idle("release", 2)
            .Hold("double jump", new PlayerInput(Jump: true), 1)
            .Hold("rise", new PlayerInput(Jump: true), 15)
            .Hold("fly", new PlayerInput(Forward: true), 30, 0)
            .Hold("sprint fly", new PlayerInput(Forward: true, Sprint: true), 30, 0)
            .Hold("descend", new PlayerInput(Shift: true), 60)
            .Idle("landed", 20)
            .Do("survival", () => Command($"gamemode survival {name}"))
            .Do("tp water", () => Teleport(ox + 0.5, y - 2, oz + 75.5, 0))
            .Idle("sink", 30)
            .Hold("swim up", new PlayerInput(Jump: true), 30, 0, 0)
            .Hold("wade", new PlayerInput(Forward: true), 30, 0, 0)
            .Hold("sprint swim", new PlayerInput(Forward: true, Sprint: true), 50, 0, 30)
            .Hold("swim up", new PlayerInput(Forward: true, Sprint: true), 30, 0, -40)
            .Hold("sink with shift", new PlayerInput(Shift: true), 20, 0, 0)
            .Hold("tread", new PlayerInput(Jump: true), 40, 0, 0)
            .Hold("leave", new PlayerInput(Forward: true, Jump: true), 120, 180, 0)
            .Do("tp ice", () => Teleport(ox - 5.5, y, oz - 39.5, 0))
            .Idle("land", 20)
            .Hold("ice sprint", new PlayerInput(Forward: true, Sprint: true), 20, 0)
            .Idle("ice slide", 40)
            .Do("tp soul sand", () => Teleport(ox - 2.5, y, oz - 39.5, 0))
            .Idle("land", 20)
            .Hold("soul sand walk", new PlayerInput(Forward: true), 40, 0)
            .Do("tp honey", () => Teleport(ox + 0.5, y, oz - 39.5, 0))
            .Idle("land", 20)
            .Hold("honey jump", new PlayerInput(Forward: true, Jump: true), 40, 0)
            .Do("tp slime", () => Teleport(ox + 3.5, y + 8, oz - 30.5, 0))
            .Idle("bounce", 80)
            .Hold("slime walk", new PlayerInput(Forward: true), 30, 0)
            .Do("creative", () => Command($"gamemode creative {name}"))
            .Do("tp lava", () => Teleport(ox + 25.5, y - 2, oz + 0.5, 90))
            .Idle("sink in lava", 30)
            .Hold("lava swim", new PlayerInput(Forward: true), 40, 90)
            .Hold("lava rise", new PlayerInput(Jump: true), 40, 90)
            .Hold("lava leave", new PlayerInput(Forward: true, Jump: true), 60, 90)
            .Do("survival", () => Command($"gamemode survival {name}"))
            .Idle("done", 40);

        TimeSpan tick = TimeSpan.FromMilliseconds(50);
        TimeSpan next = clock.Elapsed;
        string lastPhase = "";
        while (!script.Finished && client.Phase != ClientPhase.Disconnected) {
            client.ProcessPackets();
            while (clock.Elapsed >= next) {
                phase = script.CurrentLabel ?? "end";
                script.Apply(player);
                phase = script.CurrentLabel ?? "end";
                if (phase != lastPhase) {
                    Console.WriteLine($"{phase,-24} at {F(Math.Round(player.Position.X - ox, 3))} {F(Math.Round(player.Position.Y, 3))} {F(Math.Round(player.Position.Z - oz, 3))} ground={player.OnGround} water={player.IsInWater} swim={player.Swimming} fly={player.Flying} sprint={player.Sprinting} pose={player.Pose}");
                    lastPhase = phase;
                }
                client.Tick();
                next += tick;
            }
            await Task.Delay(2);
        }

        Console.WriteLine($"Teleports: {teleportsSeen} received, {teleportsExpected - unexpected.Count} expected, {unexpected.Count} unexpected");
        foreach (string line in unexpected) {
            Console.WriteLine($"  {line}");
        }
        bool kicked = client.Phase == ClientPhase.Disconnected;
        Console.WriteLine(kicked ? $"Disconnected: {client.DisconnectReason}" : "Still connected");
        client.Disconnect("Done");
        return unexpected.Count == 0 && !kicked ? 0 : 1;
    }
}
