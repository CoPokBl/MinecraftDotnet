using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Interaction;

/// <summary>
/// Vanilla's <c>BlockHitResult</c>, as much of it as a right click carries.
/// <p/>
/// The click that produces one here comes off <c>use_item_on</c> rather than off a raycast, so
/// <see cref="Location"/> is the packet's cursor with the block position added back on. The two are
/// in different spaces and a rule that reads the hit point subtracts a block position off it again,
/// so mixing them up moves the answer by a whole block at a negative coordinate. See
/// <c>FluidRaycast</c> for the raycast that produces the same thing the other way.
/// </summary>
/// <param name="Position">The block that was clicked, not the one beside it.</param>
/// <param name="Face">Which face of it, <c>BlockHitResult.getDirection</c>.</param>
/// <param name="Location">The hit point in world coordinates, <c>BlockHitResult.getLocation</c>.</param>
/// <param name="Inside">Whether the player's eyes are inside the block's bounds.</param>
public readonly record struct BlockHit(
    Vec3<int> Position,
    BlockFace Face,
    Vec3<double> Location,
    bool Inside);
