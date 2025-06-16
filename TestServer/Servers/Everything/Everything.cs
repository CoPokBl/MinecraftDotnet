using Minecraft.Implementations.Server;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Worlds;
using Minecraft.NBT.Text;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace TestServer.Servers.Everything;

public class Everything {

    public static async Task Start() {
        Console.WriteLine("Creating world...");
        // World world = new(new TestingProvider(), 32, 2, 10);
        World world = new(new CoolProvider(), 32, 2, 10);
        Console.WriteLine("World created!");

        MinecraftServer server = new([
            new PlayerInfoFeature(),
            new SimpleChatFeature(),
            new HeartbeatsFeature(3000),
            new PingRespondFeature(),
            new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket(
                "dotnet",
                connection.Handshake!.ProtocolVersion,
                -6969,
                -69,
                [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
                connection.Handshake!.Hostname switch {
                    "copokbl-pc" => "Hello §cAdam/Michael§r, welcome to my server",
                    "localhost" => "Hello me, have fun testing",
                    _ => $"Hello World! You are using §c{connection.Handshake!.Hostname}§r to connect"
                },
                preventsChatReports: true)),
            new SpawnWorldFeature(world),
            new PlayerLoginFeature(),
            new TabListFeature(
                updatePeriod:1000, 
                headerProvider:() => TextComponent.Text("Epic Gaming Server").WithColor(TextColor.Hex("#EE7026")).WithBold(true), 
                footerProvider:() => TextComponent.Text("mc.gofuckyourself.net").WithColor(TextColor.Red).WithItalic(true)),
            new SimpleEntitiesFeature(),
            new SimplePlayerEntitiesFeature(),
            new BlockBreakingFeature()
        ]);

        CancellationTokenSource cts = new();
        TcpMinecraftListener listener = new(connection => {
            server.AddConnection(connection);
            // cts.Cancel();
        }, cts.Token);

        server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
            Console.WriteLine("Sending player info");
            Guid id = Guid.NewGuid();
            e.Connection.SendPackets(
                new ClientBoundBundleDelimiterPacket(),
                new ClientBoundPlayerInfoUpdatePacket(new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer)
                    .WithPlayer(id, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                        Name = TextColor.LegacyColorCodePrefix + "cAdam",
                        Properties = []
                    })),
                new ClientBoundSpawnEntityPacket(7, id, 148, new Vec3(0, 30, 0), Angle.Zero,
                Angle.Zero, Angle.Zero, 0, SVec3.Zero),
                new ClientBoundSetEntityMetadataPacket(7, new PlayerMeta {
                    CustomName = TextComponent.Text("Adam"),
                    CustomNameVisible = true
                }),
                // new ClientBoundSetEntityMetadataPacket(7, new PlayerMeta {
                //     AdditionalHearts = 0,
                //     AirTicks = 0,
                //     ArrowsInEntity = 3,
                //     BeeStingersInEntity = 2,
                //     CustomName = TextComponent.Text("Adam").WithColor(TextColor.Red),
                //     CustomNameVisible = true,
                //     HandStates = HandState.None,
                //     Health = 20f,
                //     IsPotionAmbient = false,
                //     Score = 0,
                //     SkinFlags = SkinParts.All,
                //     MainHand = DominantHand.Right,
                //     Particles = [],
                //     SleepingBed = null,
                //     Status = EntityStatus.None,
                //     Silent = false,
                //     NoGravity = true,
                //     Pose = EntityPose.Standing,
                //     TicksInPowderedSnow = 0
                // }),
                new ClientBoundBundleDelimiterPacket());
        });

        server.Events.AddListener<SimpleChatFeature.SimpleChatEvent>(e => {
            // string[] parts = e.Msg.Split(",");
            // Vec3 pos = new(double.Parse(parts[0]), double.Parse(parts[1]), double.Parse(parts[2]));
            // server.Feature<SimpleEntitiesFeature>()!.Spawn(new Entity(97) {
            //     Position = pos
            // });
            e.Connection.SendPacket(new ClientBoundSynchronisePlayerPositionPacket(
                Random.Shared.Next(), new PlayerPosition(new Vec3(0, 100, 0), Vec3.Zero, Angle.Zero, Angle.Zero),
                TeleportFlags.None));
        });

        Console.WriteLine("Server ready, listening...");
        await listener.Listen();
    }
}