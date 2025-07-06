using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4922,
                    false => 4923,
                },
                Direction.South => Waterlogged switch {
                    true => 4924,
                    false => 4925,
                },
                Direction.West => Waterlogged switch {
                    true => 4926,
                    false => 4927,
                },
                Direction.East => Waterlogged switch {
                    true => 4928,
                    false => 4929,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4922 => new MangroveWallSignBlock(Identifier, Direction.North, true),
            4923 => new MangroveWallSignBlock(Identifier, Direction.North, false),
            4924 => new MangroveWallSignBlock(Identifier, Direction.South, true),
            4925 => new MangroveWallSignBlock(Identifier, Direction.South, false),
            4926 => new MangroveWallSignBlock(Identifier, Direction.West, true),
            4927 => new MangroveWallSignBlock(Identifier, Direction.West, false),
            4928 => new MangroveWallSignBlock(Identifier, Direction.East, true),
            4929 => new MangroveWallSignBlock(Identifier, Direction.East, false),
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
