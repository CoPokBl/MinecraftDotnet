using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeadBubbleCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13892,
                    false => 13893,
                },
                Direction.South => Waterlogged switch {
                    true => 13894,
                    false => 13895,
                },
                Direction.West => Waterlogged switch {
                    true => 13896,
                    false => 13897,
                },
                Direction.East => Waterlogged switch {
                    true => 13898,
                    false => 13899,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13892 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.North, true),
            13893 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.North, false),
            13894 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.South, true),
            13895 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.South, false),
            13896 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.West, true),
            13897 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.West, false),
            13898 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.East, true),
            13899 => new DeadBubbleCoralWallFanBlock(Identifier, Direction.East, false),
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
