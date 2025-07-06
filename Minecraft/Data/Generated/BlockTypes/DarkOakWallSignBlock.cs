using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4906,
                    false => 4907,
                },
                Direction.South => Waterlogged switch {
                    true => 4908,
                    false => 4909,
                },
                Direction.West => Waterlogged switch {
                    true => 4910,
                    false => 4911,
                },
                Direction.East => Waterlogged switch {
                    true => 4912,
                    false => 4913,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4906 => new DarkOakWallSignBlock(Identifier, Direction.North, true),
            4907 => new DarkOakWallSignBlock(Identifier, Direction.North, false),
            4908 => new DarkOakWallSignBlock(Identifier, Direction.South, true),
            4909 => new DarkOakWallSignBlock(Identifier, Direction.South, false),
            4910 => new DarkOakWallSignBlock(Identifier, Direction.West, true),
            4911 => new DarkOakWallSignBlock(Identifier, Direction.West, false),
            4912 => new DarkOakWallSignBlock(Identifier, Direction.East, true),
            4913 => new DarkOakWallSignBlock(Identifier, Direction.East, false),
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
