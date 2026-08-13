using ManagedServer.Physics;
using ManagedServer.Placement.Helpers;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement.Rules;

/// <summary>
/// <c>WallBlock</c>. Like a fence, except a side has a height rather than being on or off, and there
/// is a centre post that comes and goes.
/// <p/>
/// A side that connects is <c>TALL</c> when the block above covers that side's strip and <c>LOW</c>
/// otherwise, and the post is raised at a corner, at an end, and under anything that covers the
/// middle. All three of those are decided by what the block above reaches down over, which is why
/// every path through this rule reads the block above and not just the four sides.
/// </summary>
public sealed class WallPlacementRule : IBlockPlacementRule {
    private static readonly Identifier Walls = "minecraft:walls";
    private static readonly Identifier WallPostOverride = "minecraft:wall_post_override";

    public BlockClass VanillaClass => BlockClass.WallBlock;

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IWallConnected) {
            return block;
        }

        World world = context.World;
        MinecraftRegistry registry = world.Server.Registry;
        Vec3<int> pos = context.PlacePos;

        bool[] connections = new bool[Directions.Horizontal.Length];
        for (int i = 0; i < Directions.Horizontal.Length; i++) {
            BlockFace face = Directions.Horizontal[i];
            Vec3<int> neighbourPos = pos.GetBlockTowards(face);
            connections[i] = ConnectsTo(registry, world.GetBlock(neighbourPos),
                PlacementHelpers.FaceSturdy(world, neighbourPos, face.Opposite()), face);
        }

        IBlock state = PlacementHelpers.Waterlog(block, context);
        return Settle(registry, state, world.GetBlock(pos.WithY(pos.Y + 1)), connections);
    }

    public IBlock UpdateShape(IBlock block, World world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        if (toNeighbour == BlockFace.NegY || block is not IWallConnected wall) {
            return block;
        }

        MinecraftRegistry registry = world.Server.Registry;

        // Which sides are connected is kept, since only the changed side can have changed, but the
        // heights and the post are all worked out again against whatever is above.
        bool[] connections = new bool[Directions.Horizontal.Length];
        for (int i = 0; i < Directions.Horizontal.Length; i++) {
            BlockFace face = Directions.Horizontal[i];
            if (face == toNeighbour) {
                connections[i] = ConnectsTo(registry, neighbourState,
                    PlacementHelpers.FaceSturdy(world, neighbourPos, face.Opposite()), face);
            }
            else {
                connections[i] = wall.Side(face) != WallSide.None;
            }
        }

        IBlock above = toNeighbour == BlockFace.PosY ? neighbourState : world.GetBlock(pos.WithY(pos.Y + 1));
        return Settle(registry, block, above, connections);
    }

    /// <summary>
    /// <c>WallBlock.updateShape</c>'s private half: turn the four connection flags into side heights
    /// against what is above, then decide the post.
    /// </summary>
    private static IBlock Settle(MinecraftRegistry registry, IBlock block, IBlock above, bool[] connections) {
        IBlock state = block;
        for (int i = 0; i < Directions.Horizontal.Length; i++) {
            BlockFace face = Directions.Horizontal[i];
            WallSide side = !connections[i]
                ? WallSide.None
                : Covers(above, SideStrip(face)) ? WallSide.Tall : WallSide.Low;
            state = ((IWallConnected)state).WithSide(face, side);
        }

        bool post = ShouldRaisePost(registry, (IWallConnected)state, above);
        return state is IFaceConnected connected ? connected.WithConnection(BlockFace.PosY, post) : state;
    }

    /// <summary>
    /// <c>WallBlock.shouldRaisePost</c>. A post under another post, at a corner, at an end, or in
    /// isolation. A straight run of two tall sides has no post; anything else falls back to whether
    /// the block above covers the middle.
    /// </summary>
    private static bool ShouldRaisePost(MinecraftRegistry registry, IWallConnected state, IBlock above) {
        if (BlockClasses.Is(above.Identifier, BlockClass.WallBlock)
            && above is IFaceConnected { } aboveConnected && aboveConnected.Connected(BlockFace.PosY)) {
            return true;
        }

        WallSide north = state.Side(BlockFace.NegZ);
        WallSide south = state.Side(BlockFace.PosZ);
        WallSide east = state.Side(BlockFace.PosX);
        WallSide west = state.Side(BlockFace.NegX);
        bool northNone = north == WallSide.None;
        bool southNone = south == WallSide.None;
        bool eastNone = east == WallSide.None;
        bool westNone = west == WallSide.None;

        bool hasCorner = (northNone && southNone && westNone && eastNone)
                         || northNone != southNone
                         || westNone != eastNone;
        if (hasCorner) {
            return true;
        }

        bool hasHighWall = (north == WallSide.Tall && south == WallSide.Tall)
                           || (east == WallSide.Tall && west == WallSide.Tall);
        if (hasHighWall) {
            return false;
        }

        return PlacementHelpers.InTag(registry, WallPostOverride, above.Identifier)
               || Covers(above, PostColumn);
    }

    /// <summary>
    /// <c>WallBlock.connectsTo</c>, nearly the same shape as a fence's. The clause a fence does not
    /// have is <c>instanceof IronBarsBlock</c>, which is what joins a wall to bars and to every glass
    /// pane: those are not in the <c>walls</c> tag and are an exception for connection, so without it
    /// a wall meets a pane and stays a bare post.
    /// </summary>
    private static bool ConnectsTo(MinecraftRegistry registry, IBlock neighbour, bool faceSturdy, BlockFace towards) {
        bool gate = BlockClasses.Is(neighbour.Identifier, BlockClass.FenceGateBlock)
                    && PlacementHelpers.GateConnectsTo(neighbour, towards);
        return PlacementHelpers.InTag(registry, Walls, neighbour.Identifier)
               || (!PlacementHelpers.IsExceptionForConnection(registry, neighbour) && faceSturdy)
               || BlockClasses.Is(neighbour.Identifier, BlockClass.IronBarsBlock)
               || gate;
    }

    /// <summary>The centre column vanilla tests the post against, <c>Block.column(2, 0, 16)</c>.</summary>
    private static readonly (double MinX, double MinZ, double MaxX, double MaxZ) PostColumn =
        (7 / 16.0, 7 / 16.0, 9 / 16.0, 9 / 16.0);

    /// <summary>
    /// The strip vanilla tests a side against, <c>Block.boxZ(2, 16, 0, 9)</c> rotated to the face: two
    /// pixels wide down the middle, running from that edge to just past the centre.
    /// </summary>
    private static (double MinX, double MinZ, double MaxX, double MaxZ) SideStrip(BlockFace face) => face switch {
        BlockFace.NegZ => (7 / 16.0, 0, 9 / 16.0, 9 / 16.0),
        BlockFace.PosZ => (7 / 16.0, 7 / 16.0, 9 / 16.0, 1),
        BlockFace.NegX => (0, 7 / 16.0, 9 / 16.0, 9 / 16.0),
        _ => (7 / 16.0, 7 / 16.0, 1, 9 / 16.0)
    };

    /// <summary>
    /// <c>WallBlock.isCovered</c>: whether the down face of the block above contains the whole of a
    /// test strip.
    /// <p/>
    /// The test shapes span the full height of their block, and so does the face shape, so the y
    /// axis never decides anything and the strips are written above as their footprint.
    /// </summary>
    private static bool Covers(IBlock above, (double MinX, double MinZ, double MaxX, double MaxZ) test) {
        Box[] region = [new Box(test.MinX, 0, test.MinZ, test.MaxX, 1, test.MaxZ)];
        return ShapeSupport.Contains(ShapeSupport.FaceShape(above.CollisionShape, BlockFace.NegY), region);
    }
}
