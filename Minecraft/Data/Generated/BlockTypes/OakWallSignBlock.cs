using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4858,
                    false => 4859,
                },
                Direction.South => Waterlogged switch {
                    true => 4860,
                    false => 4861,
                },
                Direction.West => Waterlogged switch {
                    true => 4862,
                    false => 4863,
                },
                Direction.East => Waterlogged switch {
                    true => 4864,
                    false => 4865,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4858 => new OakWallSignBlock(Identifier, Direction.North, true),
            4859 => new OakWallSignBlock(Identifier, Direction.North, false),
            4860 => new OakWallSignBlock(Identifier, Direction.South, true),
            4861 => new OakWallSignBlock(Identifier, Direction.South, false),
            4862 => new OakWallSignBlock(Identifier, Direction.West, true),
            4863 => new OakWallSignBlock(Identifier, Direction.West, false),
            4864 => new OakWallSignBlock(Identifier, Direction.East, true),
            4865 => new OakWallSignBlock(Identifier, Direction.East, false),
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
