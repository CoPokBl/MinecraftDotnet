using ManagedServer.Placement;
using ManagedServer.Placement.Helpers;
using ManagedServer.Placement.Rules;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Blocks;

/// <summary>
/// <c>BlockState.updateShape</c> for the generator, as <c>StructureTemplate.updateShapeAtEdge</c>
/// drives it.
/// </summary>
/// <remarks>
/// A third transcription beside <see cref="FeatureSurvival"/> and <c>BlockPlacementRules</c>, and for
/// the same reason: the placement rules take a <c>World</c> and a generator has none. Keyed on the
/// vanilla class and resolved through <c>BlockClasses.Of</c> nearest first, so a new caller adds the
/// class it needs rather than a special case.
/// <p/>
/// <b>Only the classes whose answer the pass can be seen to depend on are here, and a block with no
/// entry is left alone.</b> That default is what keeps the list safe to grow: a class nobody has
/// transcribed keeps the state it was given, which is where every block started. The two callers ask
/// for different things. At a tree, the only state <c>updateShapeAtEdge</c> changes is a vine that has
/// lost what it hung from, since <c>LeavesBlock.updateShape</c> only schedules a tick and this build
/// settles that in <c>TreeFeature.UpdateLeaves</c> instead. A template brings the connecting blocks:
/// its stairs and fences are saved with whatever state they had where the build was cut from, so a
/// wreck's stairs arrive as <c>outer_right</c> and have to settle against what they landed on.
/// <p/>
/// A block whose rule turns out to matter is an entry to add, not a mechanism to build.
/// </remarks>
public static class FeatureShapeUpdate {
    /// <summary>
    /// The state the block becomes, or the state it already has. Air means destroy, as it does
    /// everywhere else.
    /// </summary>
    public static IBlock UpdateShape(IBlock block, IFeatureLevel level, Vec3<int> pos,
        BlockFace towards) {

        foreach (BlockClass vanillaClass in BlockClasses.Of(block.Identifier)) {
            if (vanillaClass == BlockClass.VineBlock) {
                return Vine(block, level, pos, towards);
            }

            if (vanillaClass == BlockClass.DoublePlantBlock) {
                return DoublePlant(block, level, pos, towards);
            }

            if (vanillaClass == BlockClass.StairBlock) {
                return Stairs(block, level, pos, towards);
            }

            if (vanillaClass == BlockClass.FenceBlock) {
                return CrossCollision(block, level, pos, towards, Fence);
            }

            if (vanillaClass == BlockClass.IronBarsBlock) {
                return CrossCollision(block, level, pos, towards, IronBars);
            }

            if (vanillaClass == BlockClass.WallBlock) {
                return Wall(block, level, pos, towards);
            }
        }

        return block;
    }

    /// <summary>
    /// <c>Block.updateFromNeighbourShapes</c>: the state a block settles to once every one of its six
    /// neighbours has had its say.
    /// </summary>
    /// <remarks>
    /// The order is vanilla's <c>UPDATE_SHAPE_ORDER</c> and not the enum's: west, east, north, south,
    /// down, up. Each step feeds the next, so a block whose rule reads more than the neighbour it was
    /// handed can answer differently depending on where in the six it is asked.
    /// </remarks>
    public static IBlock UpdateFromNeighbourShapes(IBlock block, IFeatureLevel level, Vec3<int> pos) {
        IBlock state = block;

        foreach (BlockFace face in UpdateOrder) {
            state = UpdateShape(state, level, pos, face);
        }

        return state;
    }

    /// <summary><c>BlockBehaviour.UPDATE_SHAPE_ORDER</c>.</summary>
    private static readonly BlockFace[] UpdateOrder = [
        BlockFace.NegX, BlockFace.PosX, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegY, BlockFace.PosY
    ];

    /// <summary>
    /// The connection rules, which are the placement rules' own: they take the neighbour rather than a
    /// world, so there is one transcription of what a fence joins rather than two.
    /// </summary>
    private static readonly FencePlacementRule Fence = new();
    private static readonly IronBarsPlacementRule IronBars = new();

    /// <summary>
    /// <c>StairBlock.updateShape</c>: a horizontal neighbour changing recomputes the corner shape.
    /// </summary>
    /// <remarks>
    /// Vanilla also schedules a water tick for a waterlogged stair, which belongs to a fluid
    /// simulation the generator does not have.
    /// </remarks>
    private static IBlock Stairs(IBlock block, IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
        return Directions.IsHorizontal(towards) && block is IStairShaped shaped
            ? shaped.WithShape(StairPlacementRule.ShapeAt(block, at => BlockAt(level, at), pos))
            : block;
    }

    /// <summary>
    /// <c>CrossCollisionBlock.updateShape</c>: only the side that changed is recomputed, and only a
    /// horizontal one changes anything.
    /// </summary>
    private static IBlock CrossCollision(IBlock block, IFeatureLevel level, Vec3<int> pos,
        BlockFace towards, CrossCollisionPlacementRule rule) {

        if (!Directions.IsHorizontal(towards) || block is not IFaceConnected connected) {
            return block;
        }

        IBlock neighbour = BlockAt(level, pos + Step(towards));
        bool sturdy = ShapeSupport.IsFaceSturdy(neighbour, Opposite(towards), SupportType.Full);

        return connected.WithConnection(towards,
            rule.ConnectsTo(level.Registry, block, neighbour, sturdy, towards));
    }

    /// <summary>
    /// <c>WallBlock.updateShape</c>: a side's height and the centre post are decided by what sits on
    /// top, so every update except the one from below reads the block above as well as the neighbour
    /// it was handed.
    /// </summary>
    private static IBlock Wall(IBlock block, IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
        if (towards == BlockFace.NegY) {
            return block;
        }

        IBlock neighbour = BlockAt(level, pos + Step(towards));

        return WallPlacementRule.Settled(level.Registry, block, towards, neighbour,
            ShapeSupport.IsFaceSturdy(neighbour, Opposite(towards), SupportType.Full),
            towards == BlockFace.PosY ? neighbour : BlockAt(level, pos.WithY(pos.Y + 1)));
    }

    private static IBlock BlockAt(IFeatureLevel level, Vec3<int> pos) {
        return level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
    }

    /// <summary>
    /// <c>DoublePlantBlock.updateShape</c>: a half whose partner cell no longer holds the other half
    /// of the same plant is destroyed, and otherwise the plant dies if it cannot survive.
    /// </summary>
    /// <remarks>
    /// The partner test only fires from the direction the partner is in, which is up for the lower
    /// half and down for the upper. That is what stops a plant taking itself apart when something
    /// changes on the side away from its other half.
    /// </remarks>
    private static IBlock DoublePlant(IBlock block, IFeatureLevel level, Vec3<int> pos,
        BlockFace towards) {

        if (block is not IDoubleHalved halved) {
            return block;
        }

        bool lower = halved.Half == BlockHalf.Lower;

        if (towards is BlockFace.NegY or BlockFace.PosY && lower == (towards == BlockFace.PosY)) {
            Vec3<int> partner = pos + Step(towards);
            IBlock other = level.Registry.Blocks
                .GetByStateId(level.GetState(partner.X, partner.Y, partner.Z));

            if (!other.Identifier.Equals(block.Identifier)
                || (other is IDoubleHalved side && side.Half == halved.Half)) {

                return Block.Air;
            }
        }

        return FeatureSurvival.CanSurvive(block, level, pos.X, pos.Y, pos.Z) ? block : Block.Air;
    }

    /// <summary>
    /// <c>VineBlock.updateShape</c>: recompute which faces still hold, and destroy the vine if none
    /// does.
    /// </summary>
    /// <remarks>
    /// An update from below is passed straight through, which is what lets a hanging vine keep
    /// hanging when the block under it changes.
    /// </remarks>
    private static IBlock Vine(IBlock block, IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
        if (towards == BlockFace.NegY) {
            return block;
        }

        IBlock updated = UpdatedVine(block, level, pos);
        return HasFaces(updated) ? updated : Block.Air;
    }

    /// <summary>
    /// <c>getUpdatedState</c>: each face the vine currently has is kept only if something still
    /// supports it.
    /// </summary>
    /// <remarks>
    /// The horizontal fallback is what holds a hanging column up: a face with nothing beside it
    /// survives while the vine directly above has the same face, so a column is anchored once at the
    /// top rather than at every block of it.
    /// </remarks>
    private static IBlock UpdatedVine(IBlock block, IFeatureLevel level, Vec3<int> pos) {
        if (block is not IFaceConnected vine) {
            return block;
        }

        Vec3<int> above = pos.WithY(pos.Y + 1);

        if (vine.Connected(BlockFace.PosY)) {
            vine = (IFaceConnected)vine.WithConnection(BlockFace.PosY,
                IsAcceptableNeighbour(level, above, BlockFace.NegY));
        }

        IBlock? overhead = null;

        foreach (BlockFace face in Directions.Horizontal) {
            if (!vine.Connected(face)) {
                continue;
            }

            bool supported = CanSupportAtFace(level, pos, face);

            if (!supported) {
                overhead ??= level.Registry.Blocks
                    .GetByStateId(level.GetState(above.X, above.Y, above.Z));

                supported = overhead is IFaceConnected connected
                    && overhead.Identifier.Equals(Block.Vine.Identifier)
                    && connected.Connected(face);
            }

            vine = (IFaceConnected)vine.WithConnection(face, supported);
        }

        return vine;
    }

    /// <summary><c>canSupportAtFace</c>.</summary>
    private static bool CanSupportAtFace(IFeatureLevel level, Vec3<int> pos, BlockFace face) {
        if (face == BlockFace.NegY) {
            return false;
        }

        Vec3<int> at = pos + Step(face);
        if (IsAcceptableNeighbour(level, at, face)) {
            return true;
        }

        if (face is BlockFace.PosY or BlockFace.NegY) {
            return false;
        }

        Vec3<int> above = pos.WithY(pos.Y + 1);
        IBlock overhead = level.Registry.Blocks.GetByStateId(level.GetState(above.X, above.Y, above.Z));

        return overhead.Identifier.Equals(Block.Vine.Identifier)
            && overhead is IFaceConnected connected
            && connected.Connected(face);
    }

    /// <summary><c>MultifaceBlock.canAttachTo</c>: either shape covering the face is enough.</summary>
    private static bool IsAcceptableNeighbour(IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
        IBlock block = level.Registry.Blocks.GetByStateId(level.GetState(pos.X, pos.Y, pos.Z));
        BlockFace against = Opposite(towards);

        return ShapeSupport.IsFaceFull(block.SupportShape, against)
            || ShapeSupport.IsFaceFull(block.CollisionShape, against);
    }

    private static bool HasFaces(IBlock block) {
        if (block is not IFaceConnected connected) {
            return false;
        }

        foreach (BlockFace face in FaceOrder) {
            if (connected.Connected(face)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>The five faces a vine has a property for; down is not one of them.</summary>
    private static readonly BlockFace[] FaceOrder = [
        BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];

    internal static Vec3<int> Step(BlockFace face) => face switch {
        BlockFace.NegY => new Vec3<int>(0, -1, 0),
        BlockFace.PosY => new Vec3<int>(0, 1, 0),
        BlockFace.NegZ => new Vec3<int>(0, 0, -1),
        BlockFace.PosZ => new Vec3<int>(0, 0, 1),
        BlockFace.NegX => new Vec3<int>(-1, 0, 0),
        _ => new Vec3<int>(1, 0, 0)
    };

    internal static BlockFace Opposite(BlockFace face) => face switch {
        BlockFace.NegY => BlockFace.PosY,
        BlockFace.PosY => BlockFace.NegY,
        BlockFace.NegZ => BlockFace.PosZ,
        BlockFace.PosZ => BlockFace.NegZ,
        BlockFace.NegX => BlockFace.PosX,
        _ => BlockFace.NegX
    };
}
