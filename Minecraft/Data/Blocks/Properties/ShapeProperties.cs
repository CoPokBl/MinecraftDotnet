using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Data.Blocks.Properties;

/// <summary>
/// A block filling the top or bottom of its own cube, vanilla's <c>Half</c>. 85 blocks, the stairs
/// and the trapdoors.
/// <p/>
/// Placement decides it from the click point with an expression stairs, slabs and trapdoors share
/// verbatim: bottom unless the clicked face is <c>DOWN</c>, or the face is not <c>UP</c> and the
/// click landed above the halfway line.
/// </summary>
public interface IHalved : IBlock {
    public TopBottom Half { get; }

    public IBlock WithHalf(TopBottom half);
}

/// <summary>
/// The lower or upper cell of a two block tall block, vanilla's <c>DoubleBlockHalf</c>. 31 blocks:
/// doors, double plants and the dripleafs.
/// <p/>
/// Not <see cref="IHalved"/>. This one is decided by which of the two cells the state is, so
/// placement writes <c>LOWER</c> and then <c>setPlacedBy</c> writes the <c>UPPER</c> above it,
/// having already refused to place at all if that cell could not be replaced.
/// </summary>
public interface IDoubleHalved : IBlock {
    public BlockHalf Half { get; }

    public IBlock WithHalf(BlockHalf half);
}

/// <summary>
/// A slab, vanilla's <c>SlabBlock.TYPE</c>. 68 blocks.
/// <p/>
/// <c>DOUBLE</c> is what makes slab merging work, and it is reached through
/// <c>canBeReplaced</c> rather than through placement: the slab already there says it can be
/// replaced, which makes the context report the clicked position as the placement position, which
/// makes <c>getStateForPlacement</c> find itself there and return a double.
/// </summary>
public interface ISlabTyped : IBlock {
    public SlabType Type { get; }

    public IBlock WithType(SlabType type);
}

/// <summary>
/// A stair's corner shape, vanilla's <c>StairBlock.SHAPE</c>. 64 blocks.
/// <p/>
/// Placement computes it last, after facing and half are settled, by looking at the stairs in front
/// of and behind the new one. It is then recomputed by <c>updateShape</c> on every horizontal
/// neighbour change, so the placement rule and the shape update have to agree or a stair will
/// change corner the moment anything is placed beside it.
/// </summary>
public interface IStairShaped : IBlock {
    public StairShape Shape { get; }

    public IBlock WithShape(StairShape shape);
}

/// <summary>
/// Which end of a bed a state is, vanilla's <c>AbstractBedBlock.PART</c>. 17 blocks. The foot is placed and
/// the head is written by <c>setPlacedBy</c>, like the two cell plants but sideways.
/// </summary>
public interface IBedParted : IBlock {
    public BedPart Part { get; }

    public IBlock WithPart(BedPart part);
}

/// <summary>
/// Which side a door is hinged on, vanilla's <c>DoorBlock.HINGE</c>. 21 blocks.
/// <p/>
/// Vanilla's <c>getHinge</c> counts solid blocks and existing doors to the left and to the right,
/// and breaks a tie with the fractional part of the click coordinates, so two doors placed side by
/// side face each other.
/// </summary>
public interface IHinged : IBlock {
    public LeftRight Hinge { get; }

    public IBlock WithHinge(LeftRight hinge);
}
