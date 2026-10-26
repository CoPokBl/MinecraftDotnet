using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features.Basic;
using ManagedServer.Fluids;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Packets;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Fluids;

/// <summary>
/// Where a water bucket puts its water, which is <c>BucketItem.emptyContents</c> and is more than
/// "the block in front of the one that was clicked".
/// <p/>
/// The two that are easy to get wrong both turn on vanilla passing the hit result down and nulling it
/// on the retry: a crouching player skips the position they aimed at, and the retry then takes it
/// anyway when that position is its own fallback. Getting that wrong is invisible against a dry floor,
/// where the target is air and the crouch check never runs, and only shows up against a block that is
/// already under flowing water.
/// </summary>
[TestFixture]
public class BucketPlacementTest {
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

    /// <summary>A player needs one, and nothing here reads what was sent.</summary>
    private sealed class SilentConnection : PlayerConnection {
        protected override void SendPacketInternal(MinecraftPacket packet) { }
        public override void InitialiseEncryption() { }
        public override Task HandlePackets() => Task.CompletedTask;
        public override void Disconnect() { }
    }

    private sealed class Scene {
        public readonly World World;
        public readonly FluidSimulation Fluids;
        public readonly Player Player;
        public readonly int FloorY;

        private ulong _tick;

        public Scene() {
            ManagedMinecraftServer server = ManagedMinecraftServer.New();
            server.LogAction = _ => { };

            LiquidsFeature liquids = new();
            server.FeatureHandler.AddFeature(liquids);
            server.FeatureHandler.AddFeature(new BucketsFeature());

            World = server.CreateWorld(new FloorTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
            for (int x = -1; x <= 1; x++) {
                for (int z = -1; z <= 1; z++) {
                    World.LoadChunk(new Vec2<int>(x, z)).Wait(TimeSpan.FromSeconds(30));
                }
            }

            FloorY = World.Dimension.MinY + FloorIndex;
            Fluids = liquids.GetSimulation(World);

            Player = new Player(server, new SilentConnection(), "tester") {
                GameMode = GameMode.Creative
            };
            Player.SetWorld(World);
            Player.SetItemInHand(Hand.MainHand, new ItemStack(Item.WaterBucket, 1));
        }

        /// <summary>Pours a source at <paramref name="x"/> and lets it spread across the floor.</summary>
        public void Flood(int x) {
            Vec3<int> pos = Above(x);
            World.SetBlock(pos, Block.Water);
            Fluids.QueueExternalChange(pos);
            for (int i = 0; i < 400; i++) {
                Fluids.Tick(++_tick);
            }
        }

        public Vec3<int> Above(int x) => new(x, FloorY + 1, 0);

        /// <summary>Stands the player east of the floor and points them west and down at it.</summary>
        public void Aim(double pitch, bool crouching = false) {
            Player.Position = new Vec3<double>(6.5, FloorY + 1, 0.5);
            Player.Yaw = Angle.FromDegrees(90);
            Player.Pitch = Angle.FromDegrees(pitch);
            Player.Crouching = crouching;
        }

        public void UseBucket() {
            Player.Events.CallEvent(new PlayerPacketHandleEvent {
                Player = Player,
                World = World,
                Packet = new ServerBoundUseItemPacket {
                    UsedHand = Hand.MainHand,
                    Sequence = 1,
                    Yaw = (float)Player.Yaw.Degrees,
                    Pitch = (float)Player.Pitch.Degrees
                }
            });
        }

        /// <summary>The legacy level of the water at a position, or null when there is none.</summary>
        public int? WaterLevel(Vec3<int> pos) => World.GetBlock(pos) is WaterBlock water ? water.Level : null;

        public bool IsWaterlogged(Vec3<int> pos) => World.GetBlock(pos).Fluid != null;
    }

    [TestCase(false, TestName = "FlowingWaterBecomesASource")]
    [TestCase(true, TestName = "FlowingWaterBecomesASourceWhileCrouching")]
    public void FlowingWaterBecomesASource(bool crouching) {
        Scene scene = new();
        scene.Flood(0);
        scene.Aim(60, crouching);

        // The block being aimed at is the floor at x=5, so the water goes in the block above it, which
        // the flood already filled with flowing water.
        Assert.That(scene.WaterLevel(scene.Above(5)), Is.EqualTo(5), "the floor was not flooded");

        scene.UseBucket();

        Assert.That(scene.WaterLevel(scene.Above(5)), Is.EqualTo(0));
    }

    [Test]
    public void WaterloggableBlockTakesTheWater() {
        Scene scene = new();
        scene.World.SetBlock(scene.Above(5), Block.StoneSlab);
        scene.Aim(38);

        scene.UseBucket();

        Assert.Multiple(() => {
            Assert.That(scene.IsWaterlogged(scene.Above(5)), Is.True);
            Assert.That(scene.WaterLevel(new Vec3<int>(5, scene.FloorY + 2, 0)), Is.Null,
                "the water went above the slab instead of into it");
        });
    }

    /// <summary>
    /// Crouching is the whole of what the shift check is for: it skips the block that would have been
    /// waterlogged and fills the one in front of it instead.
    /// </summary>
    [Test]
    public void CrouchingSkipsWaterloggingAndFillsTheBlockInFront() {
        Scene scene = new();
        scene.World.SetBlock(scene.Above(5), Block.StoneSlab);
        scene.Aim(38, crouching: true);

        scene.UseBucket();

        Assert.Multiple(() => {
            Assert.That(scene.IsWaterlogged(scene.Above(5)), Is.False);
            Assert.That(scene.WaterLevel(new Vec3<int>(5, scene.FloorY + 2, 0)), Is.EqualTo(0));
        });
    }
}
