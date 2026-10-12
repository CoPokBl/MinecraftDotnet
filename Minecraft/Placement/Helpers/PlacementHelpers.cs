using NBT;
using NBT.Tags;
using System.Collections.Concurrent;
using Minecraft.Fluids;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement.Helpers;

/// <summary>
/// The lines that appear in more than one of vanilla's <c>getStateForPlacement</c> bodies.
/// <p/>
/// Helpers rather than composable rules, because that is how vanilla shares them: the waterlog line
/// is copy pasted into 44 separate methods, not factored into a base class or an interface. Modelling
/// them as rules that run around the block's own rule would invent an ordering vanilla does not have,
/// and would apply them to blocks vanilla does not apply them to.
/// </summary>
public static class PlacementHelpers {
    private static readonly Identifier Water = "minecraft:water";

    /// <summary>
    /// <c>setValue(WATERLOGGED, level.getFluidState(pos).is(Fluids.WATER))</c>.
    /// <p/>
    /// Called from the rules that want it, never applied wholesale. Of the 46 block classes that have
    /// a <c>waterlogged</c> property, 44 waterlog on placement and two do not:
    /// <c>LightBlock</c> and <c>BigDripleafStemBlock</c> both fall through to the base
    /// <c>getStateForPlacement</c>, so a light block placed in water comes out dry. Those two have no
    /// rule, so they never reach this.
    /// </summary>
    public static IBlock Waterlog(IBlock block, IBlockPlaceContext context) {
        if (block is not IWaterlogged waterloggable) {
            return block;
        }

        return waterloggable.WithWaterlogged(context.World.GetBlock(context.PlacePos).Fluid == Water);
    }

    /// <summary>
    /// <c>level.getFluidState(pos).is(Fluids.WATER)</c>, the test <see cref="Waterlog"/> makes, for
    /// the rules that ask it about somewhere other than where the block is going.
    /// </summary>
    public static bool IsWaterAt(IPlacementLevel world, Vec3<int> pos) {
        return world.GetBlock(pos).Fluid == Water;
    }

    /// <summary>
    /// <c>fluidState.is(FluidTags.WATER) &amp;&amp; fluidState.isFull()</c>, ie. an amount of eight.
    /// Coral, conduits and seagrass ask this rather than the plain water test, so they refuse a cell
    /// holding a thinning flow even though it is water.
    /// </summary>
    public static bool IsFullWaterAt(IPlacementLevel world, Vec3<int> pos) {
        FluidState fluid = FluidState.Of(world.GetBlock(pos));
        return fluid.Kind == FluidKind.Water && fluid.Amount == 8;
    }

    /// <summary>
    /// <c>fluidState.isSourceOfType(Fluids.WATER)</c>. Stricter again than
    /// <see cref="IsFullWaterAt"/>: a falling flow is full and is not a source.
    /// </summary>
    public static bool IsWaterSourceAt(IPlacementLevel world, Vec3<int> pos) {
        return FluidState.Of(world.GetBlock(pos)) is { Kind: FluidKind.Water, Source: true };
    }

    /// <summary>
    /// <c>MultifaceBlock.canAttachTo</c>: whether the neighbour across <paramref name="towards"/>
    /// presents a full face back. Either its support shape or its collision shape will do, which is
    /// wider than <see cref="FaceSturdy"/> and is why glow lichen sticks to a block whose support
    /// shape is empty.
    /// </summary>
    public static bool CanAttachTo(IPlacementLevel world, Vec3<int> pos, BlockFace towards) {
        return CanAttachTo(world.GetBlock(pos.GetBlockTowards(towards)), towards);
    }

    /// <summary>
    /// The four argument <c>canAttachTo</c>, which takes the neighbour instead of finding it.
    /// <p/>
    /// Worth having separately because two callers pass a neighbour that is <b>not</b> the one across
    /// <paramref name="towards"/> from anywhere they hold: <c>VineBlock.getUpdatedState</c> asks the
    /// block above about <c>DOWN</c>, meaning that block's <b>up</b> face, and going through the
    /// position form instead quietly asks a different block about a different face.
    /// </summary>
    public static bool CanAttachTo(IBlock neighbour, BlockFace towards) {
        BlockFace against = towards.Opposite();
        return ShapeSupport.IsFaceFull(neighbour.SupportShape, against)
               || ShapeSupport.IsFaceFull(neighbour.CollisionShape, against);
    }

    /// <summary>
    /// Which half of its cube a block placed by this click fills, the expression stairs, slabs and
    /// trapdoors share verbatim: bottom unless the clicked face is down, or the face is not up and
    /// the click landed above the halfway line.
    /// <p/>
    /// The comparison is against the block's own Y, not the world's, so it is the fractional part of
    /// where the cursor was.
    /// </summary>
    public static TopBottom HalfFromClick(IBlockPlaceContext context) {
        BlockFace face = context.ClickedFace;
        bool bottom = face != BlockFace.NegY
                      && (face == BlockFace.PosY
                          || !(context.ClickLocation.Y - context.PlacePos.Y > 0.5));
        return bottom ? TopBottom.Bottom : TopBottom.Top;
    }

    /// <summary>
    /// The attachment search: walk <c>getNearestLookingDirections</c>, build a candidate state per
    /// direction, and take the first that can survive where it is going. Null when none can, which
    /// is vanilla refusing to place at all.
    /// <p/>
    /// Fourteen blocks place this way, from wall torches to buttons to coral fans, and the order the
    /// candidates are tried in is what decides which wall a torch lands on.
    /// </summary>
    /// <param name="candidate">
    /// The state to try for a face, or null to skip that face. Wall torches skip the vertical faces
    /// this way; buttons build a floor or ceiling state instead.
    /// </param>
    public static IBlock? FirstSurviving(IBlockPlaceContext context, IBlockPlacementRule rule,
        Func<BlockFace, IBlock?> candidate) {
        foreach (BlockFace face in context.NearestLookingDirections) {
            IBlock? state = candidate(face);
            if (state is not null && rule.CanSurvive(state, context.World, context.PlacePos)) {
                return state;
            }
        }

        return null;
    }

    /// <summary>
    /// <c>BlockState.isFaceSturdy(level, pos, face)</c>: whether the block at <paramref name="pos"/>
    /// presents enough of a face towards <paramref name="face"/> for something to attach to it.
    /// <p/>
    /// The default is <c>SupportType.FULL</c>, which is vanilla's own default and what the great
    /// majority of callers want. Pass the type explicitly where the block does: they are different
    /// questions, not degrees of strictness, and a lantern asking the full face would refuse to hang
    /// from a chain.
    /// </summary>
    public static bool FaceSturdy(IPlacementLevel world, Vec3<int> pos, BlockFace face,
        SupportType type = SupportType.Full) {
        return ShapeSupport.IsFaceSturdy(world.GetBlock(pos), face, type);
    }

    /// <summary>
    /// <c>Block.canSupportCenter</c>: the centre column test, plus the one carve out vanilla puts in
    /// front of it. A block in <c>unstable_bottom_center</c> (the hanging roots and the like) never
    /// supports anything hanging under it whatever its shape says.
    /// </summary>
    public static bool SupportsCenter(IPlacementLevel world, Vec3<int> pos, BlockFace face) {
        IBlock block = world.GetBlock(pos);
        if (face == BlockFace.NegY
            && world.IsInBlockTag(UnstableBottomCenter, block.Identifier)) {
            return false;
        }

        return ShapeSupport.IsFaceSturdy(block, face, SupportType.Center);
    }

    /// <summary>
    /// <c>Block.canSupportRigidBlock</c>: the outer frame of an upward face, which is what a rail and
    /// a repeater stand on. Only ever asked of the block below, so it takes no direction.
    /// </summary>
    public static bool SupportsRigid(IPlacementLevel world, Vec3<int> below) {
        return ShapeSupport.IsFaceSturdy(world.GetBlock(below), BlockFace.PosY, SupportType.Rigid);
    }

    /// <summary>
    /// <c>VegetationBlock.canSurvive</c> through its default <c>mayPlaceOn</c>: the block below is in
    /// <c>supports_vegetation</c>. A tag rather than a shape, which is why a flower goes on grass and
    /// not on stone however solid the stone is.
    /// </summary>
    public static bool SupportsVegetation(IPlacementLevel world, Vec3<int> pos) {
        return world.IsInBlockTag(VegetationTag,
            world.GetBlock(pos.WithY(pos.Y - 1)).Identifier);
    }

    private static readonly Identifier VegetationTag = "minecraft:supports_vegetation";

    private static readonly Identifier UnstableBottomCenter = "minecraft:unstable_bottom_center";

    /// <summary>
    /// <c>Level.getMaxY</c>, the highest Y a block can be at. Vanilla is
    /// <c>getMinY() + getHeight() - 1</c>, and the two cell blocks compare against it with a strict
    /// less than, so the top row of the world is one short of the room a door needs.
    /// </summary>
    public static int MaxY(IPlacementLevel world) {
        return world.MinY + world.Height - 1;
    }

    /// <summary>
    /// Whether a block is in a tag, resolved once per tag and cached. Resolving one walks the tag's
    /// values through the registry, and the connection rules ask about three tags per neighbour per
    /// side, which is four neighbours every time a fence is placed or updated.
    /// </summary>
    private static readonly ConcurrentDictionary<(Identifier Tag, Identifier Block), bool> TagCache = new();

    public static bool InTag(MinecraftRegistry registry, Identifier tag, Identifier block) {
        return TagCache.GetOrAdd((tag, block), key => {
            if (!registry.Blocks.Tags.Contains(key.Tag)) {
                return false;
            }

            foreach (Identifier value in registry.Blocks.Tags[key.Tag].GetValueIds(registry)) {
                if (value.Equals(key.Block)) {
                    return true;
                }
            }

            return false;
        });
    }

    private static readonly Identifier ShulkerBoxes = "minecraft:shulker_boxes";

    private static readonly Identifier[] ConnectionExceptions = [
        "minecraft:barrier", "minecraft:carved_pumpkin", "minecraft:jack_o_lantern",
        "minecraft:melon", "minecraft:pumpkin"
    ];

    /// <summary>
    /// <c>Block.isExceptionForConnection</c>: the blocks a fence, a wall or a pane will not connect to
    /// even though they have a solid face. Leaves, barriers, the two pumpkins, the carved pumpkin,
    /// melons and the shulker boxes.
    /// <p/>
    /// It is what stops a fence line growing a stub towards a nearby tree.
    /// </summary>
    public static bool IsExceptionForConnection(MinecraftRegistry registry, IBlock block) {
        if (BlockClasses.Is(block.Identifier, BlockClass.LeavesBlock)) {
            return true;
        }

        foreach (Identifier exception in ConnectionExceptions) {
            if (block.Identifier.Equals(exception)) {
                return true;
            }
        }

        return InTag(registry, ShulkerBoxes, block.Identifier);
    }

    /// <summary>
    /// <c>RotationSegment.convertToSegment</c>: a yaw as one of sixteen steps, which is what a
    /// standing sign, a banner and a floor skull are turned to.
    /// <p/>
    /// Vanilla is <c>SegmentedAnglePrecision(4).fromDegrees</c>, ie.
    /// <c>Math.round(degrees * 16f / 360f) &amp; 15</c>. Two things have to survive the translation.
    /// It is <b>float</b> arithmetic, and Java's <c>Math.round(float)</c> is
    /// <c>floor(x + 0.5f)</c>, which rounds a half upwards rather than to even the way C#'s
    /// <c>Math.Round</c> would. A sign placed at exactly 11.25 degrees lands on a different segment
    /// under either change.
    /// </summary>
    public static int RotationSegment(float degrees) {
        return (int)MathF.Floor(degrees * (16f / 360f) + 0.5f) & 15;
    }

    /// <summary>
    /// <c>RotationSegment.convertToSegment(Direction)</c>: a whole direction as one of the sixteen
    /// steps, <c>get2DDataValue() &lt;&lt; 2</c>.
    /// <p/>
    /// It is <b>not</b> the inverse of <see cref="DirectionOfSegment"/>, and that is vanilla's, not a
    /// slip here. This sends south to 0 and north to 8; that one reads 0 back as north and 8 as
    /// south. The pair composes to a half turn, which is the same half turn the sign rules apply by
    /// hand when they take a yaw rather than a direction.
    /// </summary>
    public static int SegmentOfDirection(Direction direction) {
        return direction.To2DDataValue() << 2;
    }

    /// <summary>
    /// <c>RotationSegment.convertToDirection</c>: the four steps that land exactly on an axis, and
    /// null for the twelve in between. A hanging sign under another one reads it to decide whether
    /// the two are lined up.
    /// </summary>
    public static Direction? DirectionOfSegment(int segment) => segment switch {
        0 => Direction.North,
        4 => Direction.East,
        8 => Direction.South,
        12 => Direction.West,
        _ => null
    };

    /// <summary>
    /// Reads a state property by name, for a test or a diagnostic that wants an arbitrary one.
    /// <p/>
    /// <b>No placement rule uses this any more, and none should.</b> Every property a rule touches
    /// has a generated interface in <c>Minecraft/Data/Blocks/Properties</c>; the setter that used to
    /// live beside this is gone because it round tripped the whole state through NBT on the
    /// <c>updateShape</c> cascade. This is kept only because it reads rather than writes, and because
    /// a test asserting on a property the block does not have wants the throw below rather than a
    /// silently absent value.
    /// </summary>
    public static string PropertyOf(IBlock block, string property) {
        CompoundTag state = block.ToStateNbt();
        if (!state.Contains(property)) {
            throw new ArgumentException(
                $"{block.Identifier} has no '{property}' property to read.", nameof(property));
        }

        return state[property].GetString();
    }

    /// <summary>
    /// <c>FenceGateBlock.connectsToDirection</c>: a gate connects along the axis it is not facing, so
    /// a fence running north to south meets a gate that faces east.
    /// </summary>
    public static bool GateConnectsTo(IBlock gate, BlockFace towards) {
        if (gate is not IHorizontalFacing facing || !Directions.IsHorizontal(towards)) {
            return false;
        }

        return Directions.SameAxis(facing.Facing, towards.ToDirection().ClockWise());
    }
}
