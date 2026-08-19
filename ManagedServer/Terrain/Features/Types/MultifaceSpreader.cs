using ManagedServer.Placement.Helpers;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>MultifaceSpreader</c> as the sculk vein configures it: how a vein creeps from the face it is on
/// onto the faces around it.
/// </summary>
/// <remarks>
/// Only the sculk vein's configuration is here, since that is the only caller in the feature pass.
/// Glow lichen and the pale moss carpet use the same machinery upstream with different rules, and
/// their features do not need it.
/// <p/>
/// <b>The three spread types are tried in order and the first that fits wins.</b> Same position is a
/// second face on the block the vein is already on, same plane is the neighbour in the direction of
/// travel keeping the face it came from, and wrap around goes round a corner onto the far side. Trying
/// them in any other order gives a vein that creeps but never turns a corner the way vanilla's does.
/// </remarks>
internal static class MultifaceSpreader {
    private static readonly Identifier FireTag = "minecraft:fire";
    private static readonly Identifier WaterTag = "minecraft:water";

    /// <summary>Where a spread lands, and which face of it the vein takes.</summary>
    private readonly record struct SpreadPos(Vec3<int> Pos, BlockFace Face);

    private enum SpreadType {
        SamePosition,
        SamePlane,
        WrapAround
    }

    private static readonly SpreadType[] DefaultOrder =
        [SpreadType.SamePosition, SpreadType.SamePlane, SpreadType.WrapAround];

    private static readonly SpreadType[] SameSpaceOnly = [SpreadType.SamePosition];

    /// <summary>
    /// <c>spreadAll</c>: every face of the source, towards every direction. Returns how many landed,
    /// which is what the caller turns into "did anything spread".
    /// </summary>
    public static long SpreadAll(IFeatureLevel level, uint state, Vec3<int> pos) {
        return SpreadAll(level, state, pos, DefaultOrder);
    }

    /// <summary>
    /// The same over the same position only, which is what a charge standing on a block that is not
    /// sculk uses to grow a vein where it stands.
    /// </summary>
    public static long SpreadAllSameSpace(IFeatureLevel level, Vec3<int> pos) {
        return SpreadAll(level, level.GetState(pos.X, pos.Y, pos.Z), pos, SameSpaceOnly);
    }

    private static long SpreadAll(IFeatureLevel level, uint state, Vec3<int> pos, SpreadType[] order) {
        long spread = 0;

        foreach (BlockFace face in SculkSpreader.Faces) {
            if (!CanSpreadFrom(level, state, face)) {
                continue;
            }

            foreach (BlockFace towards in SculkSpreader.Faces) {
                if (SpreadOne(level, state, pos, face, towards, order)) {
                    spread++;
                }
            }
        }

        return spread;
    }

    private static bool SpreadOne(IFeatureLevel level, uint state, Vec3<int> pos, BlockFace from,
        BlockFace towards, SpreadType[] order) {

        if (Axis(towards) == Axis(from)) {
            return false;
        }

        // A block that is not itself a vein is a valid source from any face, which is how a vein
        // appears on a freshly placed sculk block at all.
        if (!IsOtherBlockValidAsSource(level, state)
            && (!HasFace(level, state, from) || HasFace(level, state, towards))) {

            return false;
        }

        foreach (SpreadType type in order) {
            SpreadPos target = PositionFor(type, pos, towards, from);

            if (!CanSpreadInto(level, pos, target)) {
                continue;
            }

            uint existing = level.GetState(target.Pos.X, target.Pos.Y, target.Pos.Z);
            if (StateForPlacement(level, existing, target) is not { } placed) {
                return false;
            }

            level.SetState(target.Pos.X, target.Pos.Y, target.Pos.Z, placed);
            return true;
        }

        return false;
    }

    private static SpreadPos PositionFor(SpreadType type, Vec3<int> pos, BlockFace towards,
        BlockFace from) {

        return type switch {
            SpreadType.SamePosition => new SpreadPos(pos, towards),
            SpreadType.SamePlane => new SpreadPos(pos + SculkSpreader.Step(towards), from),
            _ => new SpreadPos(pos + SculkSpreader.Step(towards) + SculkSpreader.Step(from),
                SculkSpreader.Opposite(towards))
        };
    }

    private static bool CanSpreadFrom(IFeatureLevel level, uint state, BlockFace face) {
        return IsOtherBlockValidAsSource(level, state) || HasFace(level, state, face);
    }

    /// <summary>Anything that is not already a vein, which is the sculk vein's own override.</summary>
    private static bool IsOtherBlockValidAsSource(IFeatureLevel level, uint state) {
        return !level.Registry.Blocks.GetByStateId(state).Identifier.Equals(Block.SculkVein.Identifier);
    }

    private static bool CanSpreadInto(IFeatureLevel level, Vec3<int> source, SpreadPos target) {
        uint existing = level.GetState(target.Pos.X, target.Pos.Y, target.Pos.Z);

        return SculkStateCanBeReplaced(level, source, target.Pos, target.Face, existing)
            && IsValidStateForPlacement(level, existing, target);
    }

    /// <summary>
    /// <c>SculkVeinSpreaderConfig.stateCanBeReplaced</c>, which is the vein's own and not the default
    /// one: the vein feature spreads through this too, because a block's spreader carries its config.
    /// </summary>
    /// <remarks>
    /// The distance two test is the part that is easy to drop: a wrap around lands two blocks away,
    /// and it is refused when the block the vein would have to reach through has a solid face towards
    /// it. Without it a vein grows through a wall.
    /// </remarks>
    internal static bool SculkStateCanBeReplaced(IFeatureLevel level, Vec3<int> source,
        Vec3<int> targetPos, BlockFace targetFace, uint existing) {

        Vec3<int> behind = targetPos + SculkSpreader.Step(targetFace);
        Identifier against = level.Registry.Blocks
            .GetByStateId(level.GetState(behind.X, behind.Y, behind.Z)).Identifier;

        if (against.Equals(Block.Sculk.Identifier) || against.Equals(Block.SculkCatalyst.Identifier)
            || against.Equals(Block.MovingPiston.Identifier)) {

            return false;
        }

        Vec3<int> delta = targetPos - source;
        if (Math.Abs(delta.X) + Math.Abs(delta.Y) + Math.Abs(delta.Z) == 2) {
            Vec3<int> through = source + SculkSpreader.Step(SculkSpreader.Opposite(targetFace));

            if (SculkPatchFeature.IsFaceSturdy(level, through, targetFace)) {
                return false;
            }
        }

        // Any fluid other than water stops it, and water only where it is what the block holds.
        if (level.Blocks.HasFluidAt(existing) && !level.Blocks.IsIn(WaterTag, existing)) {
            return false;
        }

        if (level.Blocks.IsIn(FireTag, existing)) {
            return false;
        }

        return level.Blocks.IsReplaceable(existing)
            || DefaultStateCanBeReplaced(level, Block.SculkVein.Identifier, existing);
    }

    /// <summary>
    /// <c>MultifaceSpreader.DefaultSpreaderConfig.stateCanBeReplaced</c>: air, the block being spread,
    /// or a water source.
    /// </summary>
    internal static bool DefaultStateCanBeReplaced(IFeatureLevel level, Identifier placeBlock,
        uint existing) {

        Identifier id = level.Registry.Blocks.GetByStateId(existing).Identifier;

        return level.Blocks.IsAir(existing)
            || id.Equals(placeBlock)
            || (id.Equals(Block.Water.Identifier) && level.Blocks.HasFluidAt(existing));
    }

    private static bool IsValidStateForPlacement(IFeatureLevel level, uint existing, SpreadPos target) {
        if (level.Registry.Blocks.GetByStateId(existing).Identifier.Equals(Block.SculkVein.Identifier)
            && HasFace(level, existing, target.Face)) {

            return false;
        }

        return CanAttachTo(level, target.Pos, target.Face);
    }

    /// <summary><c>getStateForPlacement</c>: the existing vein with one more face, or a new one.</summary>
    private static uint? StateForPlacement(IFeatureLevel level, uint existing, SpreadPos target) {
        IBlock current = level.Registry.Blocks.GetByStateId(existing);

        IBlock built;
        if (current.Identifier.Equals(Block.SculkVein.Identifier)) {
            built = current;
        } else if (level.Blocks.HasFluidAt(existing) && Block.SculkVein is IWaterlogged waterlogged) {
            built = waterlogged.WithWaterlogged(true);
        } else {
            built = Block.SculkVein;
        }

        return built is IFaceConnected connected
            ? connected.WithConnection(target.Face, true).StateId
            : null;
    }

    internal static bool HasFace(IFeatureLevel level, uint state, BlockFace face) {
        return level.Registry.Blocks.GetByStateId(state) is IFaceConnected connected
            && connected.Connected(face);
    }

    private static bool CanAttachTo(IFeatureLevel level, Vec3<int> pos, BlockFace towards) {
        Vec3<int> neighbour = pos + SculkSpreader.Step(towards);
        IBlock block = level.Registry.Blocks
            .GetByStateId(level.GetState(neighbour.X, neighbour.Y, neighbour.Z));

        BlockFace against = SculkSpreader.Opposite(towards);
        return ShapeSupport.IsFaceFull(block.SupportShape, against)
            || ShapeSupport.IsFaceFull(block.CollisionShape, against);
    }

    private static int Axis(BlockFace face) => face switch {
        BlockFace.NegX or BlockFace.PosX => 0,
        BlockFace.NegY or BlockFace.PosY => 1,
        _ => 2
    };
}
