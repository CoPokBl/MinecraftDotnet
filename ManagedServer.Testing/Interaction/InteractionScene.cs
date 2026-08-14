using ManagedServer.Entities.Types;
using ManagedServer.Features;
using ManagedServer.Interaction;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Interaction;

/// <summary>
/// A player standing on a stone floor who can right click a block, for the fixtures that measure the
/// <c>useItemOn</c> sequence.
/// <p/>
/// Unlike the placement fixtures this drives a real <see cref="Player.HandlePacket"/> rather than
/// calling a rule, because what is being measured is the <b>order</b> of the stages and which of them
/// ran, which only exists on that path.
/// </summary>
public sealed class InteractionScene {
    /// <summary>Height of the floor above the bottom of the world, not a world Y.</summary>
    private const int FloorIndex = 64;

    private sealed class FloorTerrain : ITerrainProvider {
        public void GetChunk(ref ChunkData chunk) {
            for (int x = 0; x < 16; x++) {
                for (int z = 0; z < 16; z++) {
                    chunk.SetBlock(x, FloorIndex, z, Block.Stone.StateId);
                }
            }

            chunk.PackData();
        }
    }

    /// <summary>Keeps everything sent to the player, so a fixture can count acks and block updates.</summary>
    private sealed class RecordingConnection : PlayerConnection {
        public readonly List<MinecraftPacket> Sent = [];

        protected override void SendPacketInternal(MinecraftPacket packet) => Sent.Add(packet);
        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() { }
    }

    public readonly ManagedMinecraftServer Server;
    public readonly World World;
    public readonly Player Player;
    public readonly int FloorY;

    private readonly RecordingConnection _connection;

    public InteractionScene(params ScopedFeature[] features) {
        Server = ManagedMinecraftServer.New();
        Server.LogAction = _ => { };

        foreach (ScopedFeature feature in features) {
            Server.FeatureHandler.AddFeature(feature);
        }

        World = Server.CreateWorld(new FloorTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
        for (int x = -1; x <= 1; x++) {
            for (int z = -1; z <= 1; z++) {
                World.LoadChunk(new Vec2<int>(x, z)).Wait(TimeSpan.FromSeconds(30));
            }
        }

        FloorY = World.Dimension.MinY + FloorIndex;

        _connection = new RecordingConnection();
        Player = new Player(Server, _connection, "tester") {
            GameMode = GameMode.Survival
        };
        Player.SetWorld(World);
        Player.Position = new Vec3<double>(0.5, FloorY + 1, 4.5);
        Player.Yaw = Angle.FromDegrees(180);
    }

    /// <summary>Registers a feature after construction, so a fixture can control registration order.</summary>
    public void AddFeature(ScopedFeature feature) => Server.FeatureHandler.AddFeature(feature);

    /// <summary>The floor cell at the origin.</summary>
    public Vec3<int> Floor => new(0, FloorY, 0);

    /// <summary>The cell directly above the floor at the origin, where a placement would land.</summary>
    public Vec3<int> Above => new(0, FloorY + 1, 0);

    public IBlock BlockAt(Vec3<int> pos) => World.GetBlock(pos);

    public void Set(Vec3<int> pos, IBlock block) => World.SetBlock(pos, block);

    public void HoldMainHand(ItemStack stack) => Player.SetItemInHand(Hand.MainHand, stack);

    public void HoldOffHand(ItemStack stack) => Player.SetItemInHand(Hand.OffHand, stack);

    public void Crouch(bool crouching = true) => Player.Crouching = crouching;

    /// <summary>
    /// Right clicks the top face of <paramref name="target"/>, the way a client does when the player
    /// is looking down at it.
    /// </summary>
    public void RightClick(Vec3<int> target, Hand hand = Hand.MainHand, BlockFace face = BlockFace.PosY,
        int sequence = 1) {
        Player.HandlePacket(new ServerBoundUseItemOnPacket {
            ActiveHand = hand,
            Position = target,
            Face = face,
            CursorPosition = new Vec3<float>(0.5f, 1f, 0.5f),
            InsideBlock = false,
            WorldBorderHit = false,
            Sequence = sequence
        });
    }

    /// <summary>Everything sent to the player since the scene was built.</summary>
    public IReadOnlyList<MinecraftPacket> Sent => _connection.Sent;

    public void ClearSent() => _connection.Sent.Clear();

    public int CountSent<T>() where T : MinecraftPacket => _connection.Sent.Count(p => p is T);

    /// <summary>
    /// A stand in for a block whose interaction a consumer supplies themselves, which is what
    /// <c>SkyWarsChestsFeature</c> is. Answers on the stage a real <c>ChestBlock</c> answers on.
    /// </summary>
    public sealed class ChestOpeningFeature(IBlock chest) : ScopedFeature {
        public int Opened { get; private set; }

        public override void Register() {
            AddEventHandler<Events.PlayerBlockInteractEvent>(e => {
                if (e.Result.ConsumesAction || e.Stage != InteractStage.UseWithoutItem) {
                    return;
                }

                if (!IBlock.SimilarTo(e.Block, chest)) {
                    return;
                }

                Opened++;
                e.Result = InteractionResult.Success;
            });
        }
    }
}
