using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5794,
                    false => 5795,
                },
                Direction.South => Waterlogged switch {
                    true => 5796,
                    false => 5797,
                },
                Direction.West => Waterlogged switch {
                    true => 5798,
                    false => 5799,
                },
                Direction.East => Waterlogged switch {
                    true => 5800,
                    false => 5801,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5794 => new BambooWallHangingSignBlock(Identifier, Direction.North, true),
            5795 => new BambooWallHangingSignBlock(Identifier, Direction.North, false),
            5796 => new BambooWallHangingSignBlock(Identifier, Direction.South, true),
            5797 => new BambooWallHangingSignBlock(Identifier, Direction.South, false),
            5798 => new BambooWallHangingSignBlock(Identifier, Direction.West, true),
            5799 => new BambooWallHangingSignBlock(Identifier, Direction.West, false),
            5800 => new BambooWallHangingSignBlock(Identifier, Direction.East, true),
            5801 => new BambooWallHangingSignBlock(Identifier, Direction.East, false),
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
