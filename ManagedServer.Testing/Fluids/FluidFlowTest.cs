using ManagedServer.Fluids;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Fluids;

/// <summary>
/// What the fluid port has to get right, stated as the things everyone knows vanilla does: water
/// reaches seven blocks on the flat and lava three, two sources with a gap fill the gap in, water
/// picks the direction of the nearest hole, a fluid falls before it spreads, and lava meeting water
/// turns to stone.
/// <p/>
/// These are outcomes rather than a step by step trace, which is deliberate. Each number comes out of
/// the drop off, the slope search and the source conversion agreeing with each other, so a port that
/// gets one of them wrong lands somewhere else.
/// </summary>
[TestFixture]
public class FluidFlowTest {
    /// <summary>Height of the floor above the bottom of the world, not a world Y.</summary>
    private const int FloorIndex = 64;

    /// <summary>A stone floor and air above it.</summary>
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

    /// <summary>
    /// A world with the floor in it and a simulation over it, driven by hand rather than by a running
    /// server so that a test can say exactly how many ticks have passed.
    /// </summary>
    private sealed class Scene {
        public readonly World World;
        public readonly FluidSimulation Fluids;
        public readonly int FloorY;

        private ulong _tick;

        public Scene() {
            ManagedMinecraftServer server = ManagedMinecraftServer.New();
            World = server.CreateWorld(new FloorTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
            FloorY = World.Dimension.MinY + FloorIndex;
            Fluids = new FluidSimulation(World);

            // The simulation treats an unloaded chunk as a wall, so everything the tests touch has to
            // be in before anything flows.
            for (int x = -1; x <= 1; x++) {
                for (int z = -1; z <= 1; z++) {
                    World.LoadChunk(new Vec2<int>(x, z)).Wait(TimeSpan.FromSeconds(30));
                }
            }
        }

        public Vec3<int> Above(int x, int z) => new(x, FloorY + 1, z);

        /// <summary>Writes a block without telling the simulation, the way the terrain would have.</summary>
        public void Set(Vec3<int> pos, IBlock block) => World.SetBlock(pos, block);

        /// <summary>Places a block the way a player would, then lets the flow settle.</summary>
        public void Place(Vec3<int> pos, IBlock block, int ticks = 400) {
            World.SetBlock(pos, block);
            Fluids.QueueExternalChange(pos);
            Settle(ticks);
        }

        public void Settle(int ticks = 400) {
            for (int i = 0; i < ticks; i++) {
                Fluids.Tick(++_tick);
            }
        }

        public int? WaterLevel(Vec3<int> pos) => World.GetBlock(pos) is WaterBlock water ? water.Level : null;

        public int? LavaLevel(Vec3<int> pos) => World.GetBlock(pos) is LavaBlock lava ? lava.Level : null;

        public string BlockAt(Vec3<int> pos) => World.GetBlock(pos).Identifier.ToString();
    }

    [Test]
    public void WaterOnAFlatFloorReachesSevenBlocks() {
        Scene scene = new();
        Vec3<int> source = scene.Above(0, 0);

        scene.Place(source, Block.Water);

        Assert.Multiple(() => {
            Assert.That(scene.WaterLevel(source), Is.EqualTo(0), "the source stopped being a source");

            // Water loses an eighth of a block a step, and the legacy level counts that loss up.
            for (int distance = 1; distance <= 7; distance++) {
                Assert.That(scene.WaterLevel(scene.Above(distance, 0)), Is.EqualTo(distance),
                    $"water {distance} blocks east");
                Assert.That(scene.WaterLevel(scene.Above(-distance, 0)), Is.EqualTo(distance),
                    $"water {distance} blocks west");
                Assert.That(scene.WaterLevel(scene.Above(0, distance)), Is.EqualTo(distance),
                    $"water {distance} blocks south");
            }

            Assert.That(scene.WaterLevel(scene.Above(8, 0)), Is.Null, "water reached eight blocks");
        });
    }

    [Test]
    public void LavaOnAFlatFloorReachesThreeBlocks() {
        Scene scene = new();

        scene.Place(scene.Above(0, 0), Block.Lava, 2000);

        Assert.Multiple(() => {
            Assert.That(scene.LavaLevel(scene.Above(0, 0)), Is.EqualTo(0));

            // Lava drops off two eighths a block outside the nether, so the levels go 2, 4, 6.
            Assert.That(scene.LavaLevel(scene.Above(1, 0)), Is.EqualTo(2));
            Assert.That(scene.LavaLevel(scene.Above(2, 0)), Is.EqualTo(4));
            Assert.That(scene.LavaLevel(scene.Above(3, 0)), Is.EqualTo(6));
            Assert.That(scene.LavaLevel(scene.Above(4, 0)), Is.Null, "lava reached four blocks");
        });
    }

    [Test]
    public void FastLavaReachesSevenBlocksTheWayItDoesInTheNether() {
        Scene scene = new();
        scene.Fluids.FastLava = true;

        scene.Place(scene.Above(0, 0), Block.Lava, 2000);

        Assert.Multiple(() => {
            Assert.That(scene.LavaLevel(scene.Above(7, 0)), Is.EqualTo(7));
            Assert.That(scene.LavaLevel(scene.Above(8, 0)), Is.Null);
        });
    }

    [Test]
    public void TwoSourcesWithAGapFillTheGapIn() {
        Scene scene = new();

        scene.Place(scene.Above(0, 0), Block.Water);
        scene.Place(scene.Above(2, 0), Block.Water);

        Assert.That(scene.WaterLevel(scene.Above(1, 0)), Is.EqualTo(0),
            "the block between two sources did not become one");
    }

    [Test]
    public void LavaDoesNotConvertToASourceTheWayWaterDoes() {
        Scene scene = new();

        scene.Place(scene.Above(0, 0), Block.Lava, 2000);
        scene.Place(scene.Above(4, 0), Block.Lava, 2000);

        Assert.That(scene.LavaLevel(scene.Above(2, 0)), Is.Not.EqualTo(0),
            "lava converted to a source with the game rule off");
    }

    [Test]
    public void WaterRunsAtTheNearestHoleAndNowhereElse() {
        Scene scene = new();

        // One block of the floor missing three blocks east, which is inside water's slope search.
        scene.Set(new Vec3<int>(3, scene.FloorY, 0), Block.Air);
        scene.Place(scene.Above(0, 0), Block.Water);

        Assert.Multiple(() => {
            Assert.That(scene.WaterLevel(scene.Above(1, 0)), Is.EqualTo(1), "water did not head for the hole");
            Assert.That(scene.WaterLevel(scene.Above(-1, 0)), Is.Null, "water spread away from the hole");
            Assert.That(scene.WaterLevel(scene.Above(0, 1)), Is.Null, "water spread away from the hole");
            Assert.That(scene.WaterLevel(new Vec3<int>(3, scene.FloorY, 0)), Is.EqualTo(8),
                "water did not fall down the hole");
        });
    }

    [Test]
    public void WaterFallingDownAShaftStartsAgainAtFullStrengthWhereItLands() {
        Scene scene = new();

        // A shaft three blocks tall with the bottom of it open, so the only thing the source can do is
        // fall and the only place the water can spread is the floor.
        for (int y = scene.FloorY + 2; y <= scene.FloorY + 4; y++) {
            scene.Set(new Vec3<int>(1, y, 0), Block.Stone);
            scene.Set(new Vec3<int>(-1, y, 0), Block.Stone);
            scene.Set(new Vec3<int>(0, y, 1), Block.Stone);
            scene.Set(new Vec3<int>(0, y, -1), Block.Stone);
        }

        scene.Place(new Vec3<int>(0, scene.FloorY + 4, 0), Block.Water, 600);

        Assert.Multiple(() => {
            // Falling water is legacy level 8, which is the falling flag rather than an amount.
            Assert.That(scene.WaterLevel(new Vec3<int>(0, scene.FloorY + 3, 0)), Is.EqualTo(8));
            Assert.That(scene.WaterLevel(scene.Above(0, 0)), Is.EqualTo(8));

            // Where it lands it starts from a full block again, so it still reaches seven.
            Assert.That(scene.WaterLevel(scene.Above(7, 0)), Is.EqualTo(7));
            Assert.That(scene.WaterLevel(scene.Above(8, 0)), Is.Null);
        });
    }

    [Test]
    public void AFullBlockStopsWater() {
        Scene scene = new();

        scene.Set(scene.Above(2, 0), Block.Stone);
        scene.Place(scene.Above(0, 0), Block.Water);

        Assert.Multiple(() => {
            Assert.That(scene.WaterLevel(scene.Above(1, 0)), Is.EqualTo(1));
            Assert.That(scene.BlockAt(scene.Above(2, 0)), Is.EqualTo("minecraft:stone"),
                "water replaced a full block");
        });
    }

    [Test]
    public void FlowingWaterCannotWaterlogButASourceCan() {
        Scene scene = new();

        scene.Set(scene.Above(2, 0), Block.OakStairs);
        scene.Place(scene.Above(0, 0), Block.Water);

        // SimpleWaterloggedBlock.canPlaceLiquid takes the source alone, so a level flowing past leaves
        // the stairs dry.
        Assert.That(scene.World.GetBlock(scene.Above(2, 0)).Fluid, Is.Null,
            "flowing water waterlogged a stairs block");
    }

    [Test]
    public void WaterWashesFireAway() {
        Scene scene = new();
        Vec3<int> fire = scene.Above(2, 0);

        scene.Set(fire, Block.Fire);
        scene.Place(scene.Above(0, 0), Block.Water);

        Assert.That(scene.World.GetBlock(fire), Is.InstanceOf<WaterBlock>(), "the fire survived the water");
    }

    [Test]
    public void FlowingLavaMeetingWaterTurnsToCobblestone() {
        Scene scene = new();

        scene.Place(scene.Above(0, 0), Block.Lava, 2000);
        scene.Place(scene.Above(3, 0), Block.Water, 2000);

        Assert.That(scene.BlockAt(scene.Above(2, 0)), Is.EqualTo("minecraft:cobblestone"));
    }

    [Test]
    public void ALavaSourceMeetingWaterTurnsToObsidian() {
        Scene scene = new();
        Vec3<int> lava = scene.Above(0, 0);

        scene.Place(lava, Block.Lava, 2000);
        scene.Place(scene.Above(1, 0), Block.Water, 2000);

        Assert.That(scene.BlockAt(lava), Is.EqualTo("minecraft:obsidian"));
    }

    /// <summary>
    /// Water arriving above lava quenches it through <c>LiquidBlock.shouldSpreadLiquid</c>, which looks
    /// up and sideways for water but never down, so the lava is obsidian before the water above it ever
    /// gets a chance to spread into it.
    /// </summary>
    [Test]
    public void WaterFallingOnALavaSourceTurnsItToObsidian() {
        Scene scene = new();
        Vec3<int> lava = scene.Above(0, 0);

        scene.Place(lava, Block.Lava, 2000);
        scene.Place(new Vec3<int>(0, scene.FloorY + 3, 0), Block.Water, 600);

        Assert.That(scene.BlockAt(lava), Is.EqualTo("minecraft:obsidian"));
    }

    /// <summary>
    /// The other way round is <c>LavaFluid.spreadTo</c>'s own case, which is the only one that makes
    /// stone.
    /// </summary>
    [Test]
    public void LavaFallingOnWaterTurnsItToStone() {
        Scene scene = new();
        Vec3<int> water = scene.Above(0, 0);

        scene.Place(water, Block.Water, 400);
        scene.Place(new Vec3<int>(0, scene.FloorY + 3, 0), Block.Lava, 2000);

        Assert.That(scene.BlockAt(water), Is.EqualTo("minecraft:stone"));
    }
}
