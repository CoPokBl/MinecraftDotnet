using ManagedServer.Features.Basic;
using ManagedServer.Placement;
using ManagedServer.Worlds;
using ManagedServer.Worlds.Lighting;
using Minecraft.Data.Blocks;
using Minecraft.Data.Items;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Testing.Placement;

/// <summary>
/// A stone floor at a known height, the vanilla rules, and a way to click a block without a player
/// attached. Shared by every placement fixture, because the interesting cases are all "put these two
/// blocks next to each other and ask".
/// <p/>
/// The context takes a null player, which is the dispenser case, so a test that cares about facing
/// says what it wants by choosing the face it clicks.
/// </summary>
internal sealed class PlacementScene {
    public const int FloorIndex = 64;

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

    public readonly World World;
    public readonly BlockPlacementRules Rules;
    public readonly int FloorY;

    /// <param name="rules">
    /// Which of vanilla's rules to register. Null for all of them, which is what nearly every test
    /// wants; an empty list is a server that has the placement machinery and no opinions, which is
    /// what <c>BareServerTest</c> checks does nothing.
    /// </param>
    public PlacementScene(IReadOnlyList<IBlockPlacementRule>? rules = null) {
        ManagedMinecraftServer server = ManagedMinecraftServer.New();
        server.FeatureHandler.AddFeature(
            new VanillaPlacementRulesFeature(rules ?? VanillaPlacementRules.All));
        World = server.CreateWorld(new FloorTerrain(), "minecraft:overworld", new FullBrightLightingProvider());
        Rules = server.BlockPlacementRules;
        FloorY = World.Dimension.MinY + FloorIndex;

        for (int x = -1; x <= 1; x++) {
            for (int z = -1; z <= 1; z++) {
                World.LoadChunk(new Vec2<int>(x, z)).Wait(TimeSpan.FromSeconds(30));
            }
        }
    }

    public Vec3<int> Floor(int x, int z) => new(x, FloorY, z);

    public Vec3<int> Above(int x, int z) => new(x, FloorY + 1, z);

    public void Set(Vec3<int> pos, IBlock block) => World.SetBlock(pos, block);

    /// <summary>
    /// The state the rules would place, given a click on <paramref name="hit"/>'s
    /// <paramref name="face"/> at <paramref name="cursorY"/> up the block. Null when the rules
    /// refuse. Does not write anything.
    /// </summary>
    public IBlock? StateFor(IBlock block, Vec3<int> hit, BlockFace face, double cursorY = 0.5,
        IItem? item = null) {
        IBlockPlacementRule? rule = Rules.For(block, World);
        return rule is null ? block : rule.GetStateForPlacement(block, ContextFor(hit, face, cursorY, item));
    }

    /// <summary>The context a click on that face would build, for a caller driving a rule directly.</summary>
    public BlockPlaceContext ContextFor(Vec3<int> hit, BlockFace face, double cursorY = 0.5,
        IItem? item = null) {
        ItemStack stack = new(item ?? Item.Stone, 1);
        Vec3<double> click = new(hit.X + 0.5, hit.Y + cursorY, hit.Z + 0.5);
        return new BlockPlaceContext(World, null, Hand.MainHand, stack, hit, face, click, false);
    }

    /// <summary>Where a click on that face would put the block, after the replace decision.</summary>
    public Vec3<int> PlacePosFor(Vec3<int> hit, BlockFace face, IItem item, double cursorY = 0.5) {
        Vec3<double> click = new(hit.X + 0.5, hit.Y + cursorY, hit.Z + 0.5);
        return new BlockPlaceContext(World, null, Hand.MainHand, new ItemStack(item, 1), hit, face,
            click, false).PlacePos;
    }
}
