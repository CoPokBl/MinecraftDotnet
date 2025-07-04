using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedWallBannerBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 11960,
                Direction.South => 11961,
                Direction.West => 11962,
                Direction.East => 11963,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11960 => new RedWallBannerBlock(Identifier, Direction.North),
            11961 => new RedWallBannerBlock(Identifier, Direction.South),
            11962 => new RedWallBannerBlock(Identifier, Direction.West),
            11963 => new RedWallBannerBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
