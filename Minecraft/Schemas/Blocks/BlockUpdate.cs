using Minecraft.Data.Blocks;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas.Blocks;

public readonly struct BlockUpdate
{
    public required IBlock Block { get; init; }
    public required Vec3<int> Location { get; init; }
}
