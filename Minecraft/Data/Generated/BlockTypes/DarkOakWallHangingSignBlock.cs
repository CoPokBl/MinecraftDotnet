using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5754,
                    false => 5755,
                },
                Direction.South => Waterlogged switch {
                    true => 5756,
                    false => 5757,
                },
                Direction.West => Waterlogged switch {
                    true => 5758,
                    false => 5759,
                },
                Direction.East => Waterlogged switch {
                    true => 5760,
                    false => 5761,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5754 => new DarkOakWallHangingSignBlock(Identifier, Direction.North, true),
            5755 => new DarkOakWallHangingSignBlock(Identifier, Direction.North, false),
            5756 => new DarkOakWallHangingSignBlock(Identifier, Direction.South, true),
            5757 => new DarkOakWallHangingSignBlock(Identifier, Direction.South, false),
            5758 => new DarkOakWallHangingSignBlock(Identifier, Direction.West, true),
            5759 => new DarkOakWallHangingSignBlock(Identifier, Direction.West, false),
            5760 => new DarkOakWallHangingSignBlock(Identifier, Direction.East, true),
            5761 => new DarkOakWallHangingSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
