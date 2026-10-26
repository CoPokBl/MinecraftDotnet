using Minecraft.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Rules;

/// <summary>
/// The blocks that grow a connection towards each horizontal neighbour: fences, iron bars and glass
/// panes.
/// <p/>
/// <c>CrossCollisionBlock</c>, the class they share, has no <c>getStateForPlacement</c> of its own;
/// each subclass writes the same loop with a different predicate. That predicate is the only thing
/// that differs, so it is what the subclasses here override.
/// <p/>
/// Placement and <see cref="UpdateShape"/> go through the same predicate deliberately. Vanilla writes
/// it twice, once over four neighbours and once over the one that changed, and if the two disagreed a
/// fence would connect when placed and then let go the moment anything near it moved.
/// </summary>
public abstract class CrossCollisionPlacementRule : IBlockPlacementRule {
    public abstract BlockClass VanillaClass { get; }

    /// <summary>
    /// Whether this block connects to <paramref name="neighbour"/> across <paramref name="towards"/>,
    /// which points from this block at the neighbour.
    /// </summary>
    /// <remarks>
    /// Public because the generator's own shape settle asks it too: it takes the neighbour rather than
    /// an <see cref="IPlacementLevel"/>, so it is the one part of this rule a caller without a world can
    /// reuse, and a second copy of "what a fence joins" would be a second thing to update.
    /// </remarks>
    public abstract bool ConnectsTo(MinecraftRegistry registry, IBlock self, IBlock neighbour,
        bool faceSturdy, BlockFace towards);

    public IBlock? GetStateForPlacement(IBlock block, IBlockPlaceContext context) {
        if (block is not IFaceConnected) {
            return block;
        }

        IPlacementLevel world = context.World;
        MinecraftRegistry registry = world.Registry;
        Vec3<int> pos = context.PlacePos;
        IBlock state = block;

        foreach (BlockFace face in Directions.Horizontal) {
            Vec3<int> neighbourPos = pos.GetBlockTowards(face);
            IBlock neighbour = world.GetBlock(neighbourPos);
            bool sturdy = PlacementHelpers.FaceSturdy(world, neighbourPos, face.Opposite());
            state = ((IFaceConnected)state).WithConnection(face,
                ConnectsTo(registry, block, neighbour, sturdy, face));
        }

        return PlacementHelpers.Waterlog(state, context);
    }

    public IBlock UpdateShape(IBlock block, IPlacementLevel world, Vec3<int> pos, BlockFace toNeighbour,
        Vec3<int> neighbourPos, IBlock neighbourState) {
        // Only the one side that changed is recomputed, which is what makes a long fence line cheap
        // to update. A vertical neighbour changes nothing.
        if (!Directions.IsHorizontal(toNeighbour) || block is not IFaceConnected connected) {
            return block;
        }

        bool sturdy = PlacementHelpers.FaceSturdy(world, neighbourPos, toNeighbour.Opposite());
        return connected.WithConnection(toNeighbour,
            ConnectsTo(world.Registry, block, neighbourState, sturdy, toNeighbour));
    }
}

/// <summary>
/// <c>FenceBlock</c>. Connects to anything with a solid face that is not an exception, to another
/// fence of the same wood-or-not kind, and to a fence gate standing across it.
/// </summary>
public sealed class FencePlacementRule : CrossCollisionPlacementRule {
    private static readonly Identifier Fences = "minecraft:fences";
    private static readonly Identifier WoodenFences = "minecraft:wooden_fences";

    public override BlockClass VanillaClass => BlockClass.FenceBlock;

    public override bool ConnectsTo(MinecraftRegistry registry, IBlock self, IBlock neighbour,
        bool faceSturdy, BlockFace towards) {
        bool sameFence = IsSameFence(registry, self, neighbour);
        bool gate = BlockClasses.Is(neighbour.Identifier, BlockClass.FenceGateBlock)
                    && PlacementHelpers.GateConnectsTo(neighbour, towards);
        return (!PlacementHelpers.IsExceptionForConnection(registry, neighbour) && faceSturdy)
               || sameFence
               || gate;
    }

    /// <summary>
    /// <c>FenceBlock.isSameFence</c>: a fence, and wooden if and only if this one is. That is what
    /// keeps a nether brick fence from joining an oak one.
    /// </summary>
    private static bool IsSameFence(MinecraftRegistry registry, IBlock self, IBlock neighbour) {
        return PlacementHelpers.InTag(registry, Fences, neighbour.Identifier)
               && PlacementHelpers.InTag(registry, WoodenFences, neighbour.Identifier)
                   == PlacementHelpers.InTag(registry, WoodenFences, self.Identifier);
    }
}

/// <summary>
/// <c>IronBarsBlock</c>, which glass panes and stained glass panes extend. Connects to a solid face,
/// to other bars and panes, and to walls.
/// </summary>
public sealed class IronBarsPlacementRule : CrossCollisionPlacementRule {
    private static readonly Identifier Walls = "minecraft:walls";

    public override BlockClass VanillaClass => BlockClass.IronBarsBlock;

    public override bool ConnectsTo(MinecraftRegistry registry, IBlock self, IBlock neighbour,
        bool faceSturdy, BlockFace towards) {
        return (!PlacementHelpers.IsExceptionForConnection(registry, neighbour) && faceSturdy)
               || BlockClasses.Is(neighbour.Identifier, BlockClass.IronBarsBlock)
               || PlacementHelpers.InTag(registry, Walls, neighbour.Identifier);
    }
}
