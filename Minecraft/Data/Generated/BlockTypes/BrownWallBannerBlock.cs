using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownWallBannerBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 11952,
                Direction.South => 11953,
                Direction.West => 11954,
                Direction.East => 11955,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11952 => new BrownWallBannerBlock(Identifier, Direction.North),
            11953 => new BrownWallBannerBlock(Identifier, Direction.South),
            11954 => new BrownWallBannerBlock(Identifier, Direction.West),
            11955 => new BrownWallBannerBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
