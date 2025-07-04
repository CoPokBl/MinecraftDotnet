using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeadBrainCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13884,
                    false => 13885,
                },
                Direction.South => Waterlogged switch {
                    true => 13886,
                    false => 13887,
                },
                Direction.West => Waterlogged switch {
                    true => 13888,
                    false => 13889,
                },
                Direction.East => Waterlogged switch {
                    true => 13890,
                    false => 13891,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13884 => new DeadBrainCoralWallFanBlock(Identifier, Direction.North, true),
            13885 => new DeadBrainCoralWallFanBlock(Identifier, Direction.North, false),
            13886 => new DeadBrainCoralWallFanBlock(Identifier, Direction.South, true),
            13887 => new DeadBrainCoralWallFanBlock(Identifier, Direction.South, false),
            13888 => new DeadBrainCoralWallFanBlock(Identifier, Direction.West, true),
            13889 => new DeadBrainCoralWallFanBlock(Identifier, Direction.West, false),
            13890 => new DeadBrainCoralWallFanBlock(Identifier, Direction.East, true),
            13891 => new DeadBrainCoralWallFanBlock(Identifier, Direction.East, false),
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
