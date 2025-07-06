using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5770,
                    false => 5771,
                },
                Direction.South => Waterlogged switch {
                    true => 5772,
                    false => 5773,
                },
                Direction.West => Waterlogged switch {
                    true => 5774,
                    false => 5775,
                },
                Direction.East => Waterlogged switch {
                    true => 5776,
                    false => 5777,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5770 => new MangroveWallHangingSignBlock(Identifier, Direction.North, true),
            5771 => new MangroveWallHangingSignBlock(Identifier, Direction.North, false),
            5772 => new MangroveWallHangingSignBlock(Identifier, Direction.South, true),
            5773 => new MangroveWallHangingSignBlock(Identifier, Direction.South, false),
            5774 => new MangroveWallHangingSignBlock(Identifier, Direction.West, true),
            5775 => new MangroveWallHangingSignBlock(Identifier, Direction.West, false),
            5776 => new MangroveWallHangingSignBlock(Identifier, Direction.East, true),
            5777 => new MangroveWallHangingSignBlock(Identifier, Direction.East, false),
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
