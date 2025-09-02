using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas.Vec;

namespace TestServer.Servers.Everything;

/// <summary>
/// General testing server for various library features.
/// </summary>
public static class Everything {

    public static async Task Start() {
        ManagedMinecraftServer server = ManagedMinecraftServer.NewBasic();

        // World world = server.CreateWorld(new PolarLoader("parkour.polar", VanillaRegistry.Data));
        World world = server.CreateWorld(new AnvilLoader("parkourlobby", VanillaRegistry.Data));
        // World world = server.CreateWorld(new CoolProvider());

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3<double>(1005, 69, 1022));

            // server.Scheduler.ScheduleTask(20 * 10, () => {
            //     e.Player.Teleport(new Vec3<double>(1005, 70, 1022));
            // });
            
            e.Player.SendPacket(new ClientBoundPlayerAbilitiesPacket {
                Flags = ClientBoundPlayerAbilitiesPacket.Abilities.AllowFlying | ClientBoundPlayerAbilitiesPacket.Abilities.Flying,
                FlyingSpeed = 0.1f,
                FovModifier = 1f
            });
        });

        NpcEntity npc = new() {
            // Position = new Vec3<double>(1005, 69, 1024)
            Position = new Vec3<double>()
        };
        npc.SetWorld(world);

        server.Events.AddListener<PlayerChatEvent>(e => {
            switch (e.RawMessage) {
                case "l":
                    e.Player.Teleport(new Vec3<double>(1005, 69, 1022));
                    break;
                
                case "z":
                    e.Player.Teleport(new Vec3<double>());
                    break;
            }
            
            // e.Player.SendMessage(world.GetBlock(new Vec3<int>(1005, 68, 1022)).Identifier.ToString());
        });
        
        server.Start();
        Console.WriteLine("Server started.");
        await server.ListenTcp(25565);
    }
}
