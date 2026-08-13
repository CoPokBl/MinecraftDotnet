using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace Minecraft.Data.Blocks.Properties;

/// <summary>
/// A block carrying a boolean connection per face, vanilla's <c>PROPERTY_BY_DIRECTION</c>. Fences,
/// iron bars and glass panes have the four horizontals; chorus plant and the multiface blocks have
/// all six; fire has five.
/// <p/>
/// Indexed by face rather than exposed as four properties because that is how vanilla reads it:
/// <c>CrossCollisionBlock</c> and <c>MultifaceBlock</c> both keep a direction to property map and
/// loop over it, and so does the <c>updateShape</c> that recomputes exactly the one side whose
/// neighbour changed.
/// </summary>
public interface IFaceConnected : IBlock {
    /// <summary>Whether this block has a connection property for the face at all.</summary>
    public bool HasFace(BlockFace face);

    /// <summary>
    /// Whether the block connects on the face. False for a face it has no property for, which is
    /// what vanilla's map lookup returning null amounts to at every call site.
    /// </summary>
    public bool Connected(BlockFace face);

    /// <summary>
    /// The state with that face's connection set. Unchanged for a face the block has no property
    /// for, so a caller looping over all six does not have to filter first.
    /// </summary>
    public IBlock WithConnection(BlockFace face, bool connected);
}

/// <summary>
/// A wall's four horizontal sides, vanilla's <c>WallBlock</c>. 33 blocks.
/// <p/>
/// Separate from <see cref="IFaceConnected"/> because a wall side has a height rather than being on
/// or off: a wall next to a solid block goes <c>TALL</c>, next to another wall it usually goes
/// <c>LOW</c>, and the difference is visible. Walls also carry a boolean <c>up</c> for the centre
/// post, so they implement both interfaces.
/// </summary>
public interface IWallConnected : IBlock {
    /// <summary>The side's height. <c>None</c> for a vertical face, which a wall has no side for.</summary>
    public WallSide Side(BlockFace face);

    /// <summary>The state with that side set. Unchanged for a vertical face.</summary>
    public IBlock WithSide(BlockFace face, WallSide side);
}
