using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4874,
                    false => 4875,
                },
                Direction.South => Waterlogged switch {
                    true => 4876,
                    false => 4877,
                },
                Direction.West => Waterlogged switch {
                    true => 4878,
                    false => 4879,
                },
                Direction.East => Waterlogged switch {
                    true => 4880,
                    false => 4881,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4874 => new BirchWallSignBlock(Identifier, Direction.North, true),
            4875 => new BirchWallSignBlock(Identifier, Direction.North, false),
            4876 => new BirchWallSignBlock(Identifier, Direction.South, true),
            4877 => new BirchWallSignBlock(Identifier, Direction.South, false),
            4878 => new BirchWallSignBlock(Identifier, Direction.West, true),
            4879 => new BirchWallSignBlock(Identifier, Direction.West, false),
            4880 => new BirchWallSignBlock(Identifier, Direction.East, true),
            4881 => new BirchWallSignBlock(Identifier, Direction.East, false),
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
