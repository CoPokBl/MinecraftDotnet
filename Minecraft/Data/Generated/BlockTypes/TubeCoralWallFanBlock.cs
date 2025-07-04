using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TubeCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13916,
                    false => 13917,
                },
                Direction.South => Waterlogged switch {
                    true => 13918,
                    false => 13919,
                },
                Direction.West => Waterlogged switch {
                    true => 13920,
                    false => 13921,
                },
                Direction.East => Waterlogged switch {
                    true => 13922,
                    false => 13923,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13916 => new TubeCoralWallFanBlock(Identifier, Direction.North, true),
            13917 => new TubeCoralWallFanBlock(Identifier, Direction.North, false),
            13918 => new TubeCoralWallFanBlock(Identifier, Direction.South, true),
            13919 => new TubeCoralWallFanBlock(Identifier, Direction.South, false),
            13920 => new TubeCoralWallFanBlock(Identifier, Direction.West, true),
            13921 => new TubeCoralWallFanBlock(Identifier, Direction.West, false),
            13922 => new TubeCoralWallFanBlock(Identifier, Direction.East, true),
            13923 => new TubeCoralWallFanBlock(Identifier, Direction.East, false),
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
