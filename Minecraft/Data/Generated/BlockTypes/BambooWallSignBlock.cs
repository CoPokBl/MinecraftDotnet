using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4930,
                    false => 4931,
                },
                Direction.South => Waterlogged switch {
                    true => 4932,
                    false => 4933,
                },
                Direction.West => Waterlogged switch {
                    true => 4934,
                    false => 4935,
                },
                Direction.East => Waterlogged switch {
                    true => 4936,
                    false => 4937,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4930 => new BambooWallSignBlock(Identifier, Direction.North, true),
            4931 => new BambooWallSignBlock(Identifier, Direction.North, false),
            4932 => new BambooWallSignBlock(Identifier, Direction.South, true),
            4933 => new BambooWallSignBlock(Identifier, Direction.South, false),
            4934 => new BambooWallSignBlock(Identifier, Direction.West, true),
            4935 => new BambooWallSignBlock(Identifier, Direction.West, false),
            4936 => new BambooWallSignBlock(Identifier, Direction.East, true),
            4937 => new BambooWallSignBlock(Identifier, Direction.East, false),
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
