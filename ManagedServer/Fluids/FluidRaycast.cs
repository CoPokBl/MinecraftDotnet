using ManagedServer.Entities.Types;
using Minecraft.Physics;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;
using Entry = ManagedServer.Fluids.FluidBlockData.Entry;

namespace ManagedServer.Fluids;

/// <summary>
/// A port of <c>BlockGetter.clip</c> and the <c>Item.getPlayerPOVHitResult</c> that calls it, which a
/// bucket needs because it acts on <c>use_item</c> rather than on the block the client said it clicked.
/// A filled bucket looks with <c>ClipContext.Fluid.NONE</c> and sees straight through fluids, an empty
/// one looks with <c>SOURCE_ONLY</c> and stops at the surface of one.
/// <p/>
/// Three things about the vanilla clip are easy to get wrong and all three change which block a bucket
/// fills. It reads the <b>outline</b> shape (<c>ClipContext.Block.OUTLINE</c> is
/// <c>BlockStateBase::getShape</c>), not the collision shape, so a torch or a flower stops the ray even
/// though nothing collides with them. The face comes from the box that was actually struck, not from
/// the block boundary the ray last crossed, which is a different answer for every shape that does not
/// reach its own boundary. And the interaction shape can override that face without moving the hit.
/// </summary>
public static class FluidRaycast {
    /// <param name="Pos">The block that was hit.</param>
    /// <param name="Face">
    /// The side of it the ray came in through, which is the side a bucket empties onto.
    /// </param>
    public readonly record struct Hit(Vec3<int> Pos, BlockFace Face);

    /// <summary>
    /// What the player is aiming at, or null when nothing is within reach.
    /// </summary>
    /// <param name="stopAtFluidSources">
    /// Whether a fluid source counts as something to hit, which is the difference between an empty
    /// bucket and a full one.
    /// </param>
    public static Hit? Look(FluidSimulation fluids, Player player, bool stopAtFluidSources) {
        Vec3<double> from = player.Position.WithY(player.Position.Y + player.EyeHeight);

        // Player.blockInteractionRange, which is 4.5 and half a block more in creative.
        double reach = player.GetAttributeValue(Attribute.BlockInteractionRange);
        return Clip(fluids, from, from + player.Direction * reach, stopAtFluidSources);
    }

    /// <summary>
    /// <c>BlockGetter.clip</c>: the nearest of the block shape and the fluid shape, over the blocks the
    /// ray passes through in order.
    /// </summary>
    public static Hit? Clip(FluidSimulation fluids, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        return Clip(fluids.GetState, from, to, stopAtFluidSources);
    }

    /// <inheritdoc cref="Clip(FluidSimulation,Vec3{double},Vec3{double},bool)"/>
    /// <param name="states">
    /// The block at a position. Taking the lookup rather than a world is what lets the conformance
    /// fixture replay a scene without standing one up.
    /// </param>
    public static Hit? Clip(Func<Vec3<int>, Entry> states, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        return BlockClip.TraverseBlocks(from, to, pos => ClipBlock(states, pos, from, to, stopAtFluidSources));
    }

    /// <summary>
    /// One block's worth of <c>BlockGetter.clip</c>: the block shape and the fluid shape are clipped
    /// separately and the nearer one wins, the block shape taking a tie.
    /// </summary>
    private static Hit? ClipBlock(Func<Vec3<int>, Entry> states, Vec3<int> pos, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        Entry state = states(pos);

        BlockClip.ShapeHit? block = ClipWithInteractionOverride(state, pos, from, to);
        BlockClip.ShapeHit? fluid = stopAtFluidSources && state.Fluid.Source
            ? BlockClip.ClipShape(FluidBoxes(states, state, pos), pos, from, to)
            : null;

        double blockScale = block?.Scale ?? double.MaxValue;
        double fluidScale = fluid?.Scale ?? double.MaxValue;

        BlockClip.ShapeHit? nearest = blockScale <= fluidScale ? block : fluid;
        return nearest == null ? null : new Hit(pos, nearest.Value.Face);
    }

    /// <summary>
    /// <c>BlockGetter.clipWithInteractionOverride</c>: a nearer interaction shape replaces the face of
    /// the hit without replacing the hit itself.
    /// </summary>
    private static BlockClip.ShapeHit? ClipWithInteractionOverride(Entry state, Vec3<int> pos, Vec3<double> from, Vec3<double> to) {
        BlockClip.ShapeHit? result = BlockClip.ClipShape(Moved(state, state.OutlineBoxes, BlockShapeOffsets.Block, pos), pos, from, to);
        if (result == null) {
            return null;
        }

        BlockClip.ShapeHit? over = BlockClip.ClipShape(Moved(state, state.InteractionBoxes, BlockShapeOffsets.Interaction, pos), pos, from, to);
        return over != null && over.Value.Scale < result.Value.Scale
            ? result.Value with { Face = over.Value.Face }
            : result;
    }

    /// <summary>
    /// The shape a fluid presents to a ray, <c>FlowingFluid.getShape</c>: a box as tall as the fluid,
    /// which is the whole block when the same fluid sits above it.
    /// <p/>
    /// Vanilla caches that box per fluid state with the level and position of whichever call built it
    /// first, so upstream the height is really decided once per fluid and reused everywhere. That is a
    /// bug rather than a rule, and it is not reproducible anyway since it depends on which block the
    /// server happened to ask about first, so this answers per position as the method reads.
    /// </summary>
    private static Box[] FluidBoxes(Func<Vec3<int>, Entry> states, Entry state, Vec3<int> pos) {
        bool sameAbove = states(FluidDirections.Above(pos)).Fluid.IsSame(state.Fluid.Kind);
        double height = sameAbove ? 1.0 : state.Fluid.OwnHeight;
        return [new Box(0, 0, 0, 1, height, 1)];
    }

    /// <summary>
    /// The shape moved by the hash of the position it sits at, which the stored shapes have taken out.
    /// <p/>
    /// Only for the shapes that actually carry the offset. Having one is a property of the block and
    /// using it is a property of each shape: <c>short_grass</c> has an offset and its <c>getShape</c>
    /// returns the unmoved shape, so moving it here would put the outline somewhere vanilla never
    /// clips against.
    /// </summary>
    private static Box[] Moved(Entry state, Box[] boxes, BlockShapeOffsets shape, Vec3<int> pos) {
        if (state.Offsets == null || boxes.Length == 0 || !state.Offsets.Offsets(shape)) {
            return boxes;
        }

        Vec3<double> offset = state.Offsets.ShapeOffset(pos);
        Box[] moved = new Box[boxes.Length];
        for (int i = 0; i < boxes.Length; i++) {
            moved[i] = boxes[i].Translate(offset);
        }

        return moved;
    }
}
