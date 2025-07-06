using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LadderBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4750,
                    false => 4751,
                },
                Direction.South => Waterlogged switch {
                    true => 4752,
                    false => 4753,
                },
                Direction.West => Waterlogged switch {
                    true => 4754,
                    false => 4755,
                },
                Direction.East => Waterlogged switch {
                    true => 4756,
                    false => 4757,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4750 => new LadderBlock(Identifier, Direction.North, true),
            4751 => new LadderBlock(Identifier, Direction.North, false),
            4752 => new LadderBlock(Identifier, Direction.South, true),
            4753 => new LadderBlock(Identifier, Direction.South, false),
            4754 => new LadderBlock(Identifier, Direction.West, true),
            4755 => new LadderBlock(Identifier, Direction.West, false),
            4756 => new LadderBlock(Identifier, Direction.East, true),
            4757 => new LadderBlock(Identifier, Direction.East, false),
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
