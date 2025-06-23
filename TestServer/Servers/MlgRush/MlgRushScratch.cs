// using Minecraft;
// using Minecraft.Implementations.Events;
// using Minecraft.Implementations.Server;
// using Minecraft.Implementations.Server.Connections;
// using Minecraft.Implementations.Server.Events;
// using Minecraft.Implementations.Server.Features;
// using Minecraft.Implementations.Server.Managed.Entities.Events;
// using Minecraft.Implementations.Server.Managed.Entities.Types;
// using Minecraft.Implementations.Server.Worlds;
// using Minecraft.Implementations.Server.Worlds.TerrainProviders;
// using Minecraft.NBT.Text;
// using Minecraft.Packets;
// using Minecraft.Packets.Play.ClientBound;
// using Minecraft.Packets.Status.ClientBound;
// using Minecraft.Schemas;
// using Minecraft.Schemas.Sound;
//
// namespace TestServer.Servers.MlgRush;
//
// public static class MlgRushScratch {
//
//     public static async Task Start() {
//         Console.WriteLine("Creating world...");
//         // World world = new(new TestingProvider(), 32, 2, 10);
//         World world = new(new EventNode<IServerEvent>(), new SpawnCachedTerrainProvider(new MlgRushMapProvider(), 4), 4, 2, 10);
//         Console.WriteLine("World created!");
//
//         Dictionary<PlayerConnection, int> playerIds = new();
//
//         MinecraftServer lobby = new(
//             new PlayerInfoFeature(),
//             new ServerListPingFeature(connection => new ClientBoundStatusResponsePacket(
//                 "dotnet",
//                 connection.Handshake!.ProtocolVersion,
//                 1,
//                 1,
//                 [new SamplePlayer("Potato", "4566e69f-c907-48ee-8d71-d7ba5aa00d20")],
//                 "MLG Rush",
//                 preventsChatReports: true)),
//             new PlayerLoginFeature(loginPacketProvider:con => {
//                 int id = Random.Shared.Next();
//                 playerIds.Add(con, id);
//                 con.Disconnected += () => playerIds.Remove(con);
//                 return new ClientBoundLoginPacket(
//                     id,
//                     true,
//                     ["minecraft:overworld"],
//                     5,
//                     32,
//                     8,
//                     false,
//                     true,
//                     false,
//                     0,
//                     "minecraft:overworld",
//                     0,
//                     0x00,
//                     0x00,
//                     false,
//                     false,
//                     null,
//                     4,
//                     64,
//                     false
//                 );
//             }),
//             new PingRespondFeature()
//         );
//
//         CancellationTokenSource cts = new();
//
//         bool run = true;
//         Console.CancelKeyPress += (_, _) => {
//             Console.WriteLine("Stopping...");
//             run = false;
//         };
//         
//         ManualResetEvent gotPlayer = new(false);
//
//         Queue<PlayerConnection> connectionQueue = new();
//         TcpMinecraftListener listener = new(connection => {
//             lobby.AddConnection(connection);
//             connection.Events.OnFirst<PlayerLoginFeature.PlayerLoginEvent>(e => {
//                 connectionQueue.Enqueue(e.Connection);
//                 gotPlayer.Set();
//             });
//         }, cts.Token);
//         
//         Console.WriteLine("Server ready, listening...");
//         _ = listener.Listen();
//
//         const bool lifeAfterBed = true;
//         
//         while (run) {
//             PlayerConnection c1 = null!;
//             PlayerConnection c2 = null!;
//             
//             MinecraftServer server = null!;
//             server = new MinecraftServer(
//                 new PlayerInfoFeature(),
//                 new SimpleChatFeature(),
//                 new HeartbeatsFeature(3000),
//                 new TabListFeature(
//                     updatePeriod:1000, 
//                     headerProvider:() => TextComponent.Text("MLG Rush").WithColor(TextColor.Hex("#EE7026")).WithBold(true), 
//                     footerProvider:() => TextComponent.Text("play.a.game").WithColor(TextColor.Red).WithItalic(true)),
//                 new SimpleEntitiesFeature(),
//                 new BlockBreakingFeature(false),
//                 new PlaceOneBlockFeature(con => {
//                     return con == c1 ? 2104 : 2107;  // c1: blue, c2: red
//                 }, 5),
//                 new SimpleCombatFeature(500)
//             );
//             server.Events.AddListener<PlayerLoginFeature.PlayerLoginEvent>(e => {
//                 e.Connection.SendPackets(
//                     new ClientBoundSynchronisePlayerPositionPacket(0, new PlayerPosition(new Vec3(0, -100, 0), Vec3.Zero, Angle.Zero, Angle.Zero), TeleportFlags.None));
//             });
//
//             // Get two players in
//             for (int i = 0; i < 2; i++) {
//                 while (true) {
//                     gotPlayer.WaitOne();
//                     gotPlayer.Reset();
//                     if (!connectionQueue.TryDequeue(out PlayerConnection? con)) continue;
//                     server.AddConnection(con);
//                     break;
//                 }
//             }
//
//             c1 = server.Connections[0];
//             c2 = server.Connections[1];
//             
//             server.Feature<TabListFeature>()!.RegisterPlayer(c1);
//             server.Feature<TabListFeature>()!.RegisterPlayer(c2);
//
//             SimpleEntitiesFeature entities = server.Feature<SimpleEntitiesFeature>()!;
//
//             void Win(bool p1Won) {
//                 PlayerConnection winner = p1Won ? c1 : c2;
//                 PlayerConnection loser = p1Won ? c2 : c1;
//                 
//                 winner.Kick(TextComponent.Text("YOU WON!!!!").WithBold().WithColor(TextColor.Gold));
//                 loser.Kick(TextComponent.Text("You lose, L").WithBold().WithColor(TextColor.Red));
//             }
//
//             void BroadcastMsg(TextComponent msg) {
//                 c1.SendSystemMessage(msg);
//                 c2.SendSystemMessage(msg);
//             }
//
//             void BroadcastPacket(MinecraftPacket packet) {
//                 c1.SendPacket(packet);
//                 c2.SendPacket(packet);
//             }
//
//             bool p1HasBed = true;
//             bool p2HasBed = true;
//             
//             // Create players
//             PlayerEntity p1 = new(c1, PlayerInfoFeature.GetInfo(c1).Username.ThrowIfNull());
//             PlayerEntity p2 = new(c2, PlayerInfoFeature.GetInfo(c2).Username.ThrowIfNull());
//             entities.Spawn(p1, playerIds[c1]);
//             entities.Spawn(p2, playerIds[c2]);
//             
//             world.AddPlayer(p1);
//             world.AddPlayer(p2);
//             
//             await entities.InformNewPlayer(c1);
//             await entities.InformNewPlayer(c2);
//
//             PlayerPosition p1Spawn = new(new Vec3(MlgRushMapProvider.P1SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(-90), Angle.Zero);
//             PlayerPosition p2Spawn = new(new Vec3(MlgRushMapProvider.P2SpawnX, 0, 0.5), Vec3.Zero, Angle.FromDegrees(90), Angle.Zero);
//             
//             // Start the game
//             p1.Teleport(p1Spawn);
//             p2.Teleport(p2Spawn);
//             
//             // Give them both blocks
//             ClientBoundSetContainerSlotPacket giveItemPacket = new(0, 0, 36, new Slot(64, 175));
//             c1.SendPacket(giveItemPacket);
//             c2.SendPacket(giveItemPacket);
//
//             const int dieLevel = -10;
//             server.Events.AddListener<EntityMoveEvent>(e => {
//                 if (!(e.NewPos.Y < dieLevel)) return;
//
//                 if (lifeAfterBed) {  // check for final kill
//                     if ((e.Entity == p1 && !p1HasBed) || (e.Entity == p2 && !p2HasBed)) {
//                         Win(e.Entity == p2);
//                     }
//                 }
//                 
//                 // Move them away for the other player to prevent tp blocking breaking
//                 e.Entity.SendToViewers(new ClientBoundTeleportEntityPacket(e.Entity.NetId, new Vec3(0, -100, 0), Vec3.Zero, 0, 0, false));
//                 
//                 e.Entity.Teleport(e.Entity == p1 ? p1Spawn : p2Spawn);
//                 ((PlayerEntity)e.Entity).Connection.SendPacket(giveItemPacket);
//                 
//                 // play nice sound
//                 PlayerEntity killer = e.Entity == p1 ? p2 : p1;
//                 killer.Connection.SendPacket(new ClientBoundEntitySoundEffectPacket(525, SoundCategory.Players,
//                     e.Entity.NetId, 1f, 1f, 0));
//
//                 TextComponent msg = $"{((PlayerEntity)e.Entity).Name} was killed by {killer.Name}";
//                 BroadcastMsg(msg);
//             });
//             
//             // Win condition
//             server.Events.AddListener<BlockBreakingFeature.BlockBreakEvent>(e => {
//                 if (!(e.Position.Equals(MlgRushMapProvider.P1BedPosClient) || e.Position.Equals(MlgRushMapProvider.P2BedPosClient))) {
//                     return;  // not a bed
//                 }
//
//                 bool p1Bed = e.Position.Equals(MlgRushMapProvider.P1BedPosClient);
//
//                 if (p1Bed && e.Connection == c1 || !p1Bed && e.Connection == c2) {  // they broke their own bed
//                     e.Connection.SendSystemMessage(TextComponent.Text("You can't break your own bed idiot")
//                         .WithColor(TextColor.Red)
//                         .WithBold());
//                     e.Connection.SendPacket(new ClientBoundBlockUpdatePacket(e.Position, (int)MlgRushMapProvider.WhiteWool));
//                     e.Cancelled = true;
//                     return;
//                 }
//                 
//                 // a bed broke and it was the player person
//                 if (!lifeAfterBed) {
//                     Win(!p1Bed);
//                     return;
//                 }
//                 
//                 // remove the bed
//                 if (p1Bed) {
//                     p1HasBed = false;
//                     BroadcastMsg($"{p1.Name} has lost their bed!");
//                 }
//                 else {
//                     p2HasBed = false;
//                     BroadcastMsg($"{p2.Name} has lost their bed!");
//                 }
//                 
//                 BroadcastPacket(new ClientBoundSoundEffectPacket(496, SoundCategory.Master, (p1Bed ? p2 : p1).Position, 1f, 1f, 0));
//             });
//             
//         }
//         
//         Console.WriteLine("Bye!");
//     }
// }