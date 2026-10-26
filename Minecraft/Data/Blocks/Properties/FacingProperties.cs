using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Data.Blocks.Properties;

/// <summary>
/// A block with a horizontal <c>facing</c>, vanilla's <c>HorizontalDirectionalBlock</c> property.
/// 293 blocks, the largest family after waterlogging.
/// <p/>
/// Whether placement faces the player or away from them is <b>per block class, not inherited</b>:
/// <c>HorizontalDirectionalBlock</c> does not override <c>getStateForPlacement</c> at all, and of
/// the classes that do, 11 use <c>getHorizontalDirection()</c> and 21 use its opposite. So a rule
/// has to say which, it cannot be read off the property.
/// </summary>
public interface IHorizontalFacing : IBlock {
    public Direction Facing { get; }

    public IBlock WithFacing(Direction facing);
}

/// <summary>
/// A block with a six way <c>facing</c>, vanilla's <c>DirectionalBlock</c> property. 41 blocks.
/// <p/>
/// Split again by where the direction comes from: the clicked face for amethyst, end rods and
/// shulker boxes, and <c>getNearestLookingDirection().getOpposite()</c> for pistons, dispensers,
/// observers, barrels and command blocks.
/// </summary>
public interface IDirectional : IBlock {
    public Cardinal Facing { get; }

    public IBlock WithFacing(Cardinal facing);
}

/// <summary>
/// A block with an <c>orientation</c>, vanilla's <c>FrontAndTop</c> property. Two blocks, the jigsaw
/// and the crafter.
/// <p/>
/// It is a <b>pair</b> of directions rather than one, which is what makes it its own family: a jigsaw
/// facing up still has a top, and that is what decides whether two pieces may be joined in a given
/// rotation. Only twelve of the 36 combinations exist, since the two directions must be perpendicular.
/// </summary>
public interface IOriented : IBlock {
    public Orientation Orientation { get; }

    public IBlock WithOrientation(Orientation orientation);
}

/// <summary>
/// A block with a <c>facing</c> that may be down or horizontal but never up, which is the hopper and
/// nothing else.
/// <p/>
/// Its own family because the missing value is the point: a hopper pointing up is a state that does
/// not exist, so the property cannot be a <see cref="IDirectional"/> without inventing one.
/// </summary>
public interface IHopperFacing : IBlock {
    public HopperDirection Facing { get; }

    public IBlock WithFacing(HopperDirection facing);
}

/// <summary>
/// A block with an <c>axis</c>, vanilla's <c>RotatedPillarBlock</c>. 68 blocks, and the simplest
/// placement rule in the game: <c>AXIS = context.getClickedFace().getAxis()</c>.
/// </summary>
public interface IAxisAligned : IBlock {
    public Axis Axis { get; }

    public IBlock WithAxis(Axis axis);
}

/// <summary>
/// A block that attaches to a floor, wall or ceiling, vanilla's
/// <c>FaceAttachedHorizontalDirectionalBlock</c>. 16 blocks: buttons, levers and the grindstone.
/// <p/>
/// Always paired with <see cref="IHorizontalFacing"/>, because the pair is what a wall mounted
/// button needs to know which wall it is on and which way round it sits.
/// </summary>
public interface IAttachFaced : IBlock {
    public AttachDirection Face { get; }

    public IBlock WithFace(AttachDirection face);
}

/// <summary>
/// A block with a sixteen step <c>rotation</c>: standing signs, banners and floor skulls. 47 blocks.
/// Placement reads it from the player's yaw rather than from a direction, which is why it is not a
/// <see cref="IHorizontalFacing"/>.
/// </summary>
public interface IRotated : IBlock {
    public int Rotation { get; }

    public IBlock WithRotation(int rotation);
}
