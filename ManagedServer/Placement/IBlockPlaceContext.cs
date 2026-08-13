using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Placement;

/// <summary>
/// Everything a placement rule is allowed to know, vanilla's <c>BlockPlaceContext</c> over its
/// <c>UseOnContext</c>.
/// <p/>
/// An interface rather than a struct because vanilla has two implementations that differ only in
/// these accessors: <c>BlockPlaceContext</c> for a player and <c>DirectionalPlaceContext</c> for a
/// dispenser, which never offsets, is never sneaking and takes its look direction from the
/// dispenser's facing. Rules are written against the accessors, so they work for both without
/// knowing which they have.
/// </summary>
public interface IBlockPlaceContext {
    public World World { get; }

    /// <summary>The player placing, or null for a dispenser.</summary>
    public Player? Player { get; }

    public ItemStack ItemInHand { get; }

    public Hand Hand { get; }

    /// <summary>The block that was clicked on, before any offset. Vanilla's hit result position.</summary>
    public Vec3<int> HitPos { get; }

    /// <summary>
    /// Where the block actually goes. The clicked position when the block there said it could be
    /// replaced, otherwise the one across the clicked face.
    /// <p/>
    /// This one accessor is the whole difference between placing into tall grass and placing beside
    /// it, and it is also what makes slab doubling work: a slab that says it can be replaced leaves
    /// this pointing at itself, so <c>getStateForPlacement</c> looks up the block here, finds the
    /// slab, and returns a double.
    /// </summary>
    public Vec3<int> PlacePos { get; }

    /// <summary>The face of <see cref="HitPos"/> that was clicked.</summary>
    public BlockFace ClickedFace { get; }

    /// <summary>
    /// The exact point on the block that was clicked, in world coordinates. Stairs, slabs and
    /// trapdoors all decide their half from whether its Y is more than half way up the block.
    /// </summary>
    public Vec3<double> ClickLocation { get; }

    /// <summary>Whether the click started inside the block's own shape.</summary>
    public bool IsInside { get; }

    /// <summary>
    /// Whether the block at <see cref="HitPos"/> is being replaced rather than placed against.
    /// Slabs, snow, ladders and trapdoors read it to tell "I clicked the block I am merging into"
    /// apart from "I clicked its neighbour".
    /// </summary>
    public bool ReplacingClickedOnBlock { get; }

    /// <summary>
    /// The player's horizontal facing, vanilla's <c>getHorizontalDirection</c>. North when there is
    /// no player.
    /// <p/>
    /// Whether a block uses this or its opposite is per block class and cannot be inherited: of the
    /// classes that place by it, 11 use it as is and 21 use the opposite.
    /// </summary>
    public Direction HorizontalDirection { get; }

    /// <summary>The player's yaw, vanilla's <c>getRotation</c>. Signs and floor skulls need all of it.</summary>
    public float Rotation { get; }

    /// <summary>Whether the placer is sneaking. Always false for a dispenser.</summary>
    public bool IsSecondaryUseActive { get; }

    /// <summary>
    /// The six faces ordered by how closely they line up with the look direction, except that when
    /// the clicked block is not being replaced the opposite of the clicked face is moved to the
    /// front. Every attachable block places by walking this and taking the first candidate that
    /// survives, which is why a torch aimed at a wall lands on that wall rather than on the floor.
    /// </summary>
    public BlockFace[] NearestLookingDirections { get; }

    /// <summary>The first of <see cref="NearestLookingDirections"/> without the clicked face rotation.</summary>
    public BlockFace NearestLookingDirection { get; }

    /// <summary>Up or down, whichever the placer is looking more towards. Only dripstone uses it.</summary>
    public BlockFace NearestLookingVerticalDirection { get; }

    /// <summary>
    /// Whether anything can go at <see cref="PlacePos"/> at all, vanilla's <c>canPlace</c>: either
    /// the clicked block is being replaced, or whatever is at the destination says it can be.
    /// </summary>
    public bool CanPlace();

    /// <summary>
    /// Whether the block at an arbitrary position would let itself be replaced by this placement,
    /// <c>level.getBlockState(pos).canBeReplaced(context)</c>.
    /// <p/>
    /// Every two cell block asks it of its partner cell before agreeing to be placed at all, which is
    /// why a door will go into tall grass but not into stone.
    /// </summary>
    public bool CanReplaceAt(Vec3<int> pos);

    /// <summary>
    /// The same context aimed somewhere else, vanilla's static <c>BlockPlaceContext.at</c>. Only
    /// scaffolding needs it, to walk along a direction looking for a free spot, but it is on the
    /// interface because that walk happens before the rule runs.
    /// </summary>
    public IBlockPlaceContext At(Vec3<int> pos, BlockFace face);

    /// <summary>The block at <see cref="PlacePos"/>, which is what is being replaced.</summary>
    public IBlock BlockAtPlacePos => World.GetBlock(PlacePos);
}
