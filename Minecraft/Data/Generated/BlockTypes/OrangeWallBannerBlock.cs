using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeWallBannerBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 11908,
                Direction.South => 11909,
                Direction.West => 11910,
                Direction.East => 11911,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11908 => new OrangeWallBannerBlock(Identifier, Direction.North),
            11909 => new OrangeWallBannerBlock(Identifier, Direction.South),
            11910 => new OrangeWallBannerBlock(Identifier, Direction.West),
            11911 => new OrangeWallBannerBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
