using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5730,
                    false => 5731,
                },
                Direction.South => Waterlogged switch {
                    true => 5732,
                    false => 5733,
                },
                Direction.West => Waterlogged switch {
                    true => 5734,
                    false => 5735,
                },
                Direction.East => Waterlogged switch {
                    true => 5736,
                    false => 5737,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5730 => new AcaciaWallHangingSignBlock(Identifier, Direction.North, true),
            5731 => new AcaciaWallHangingSignBlock(Identifier, Direction.North, false),
            5732 => new AcaciaWallHangingSignBlock(Identifier, Direction.South, true),
            5733 => new AcaciaWallHangingSignBlock(Identifier, Direction.South, false),
            5734 => new AcaciaWallHangingSignBlock(Identifier, Direction.West, true),
            5735 => new AcaciaWallHangingSignBlock(Identifier, Direction.West, false),
            5736 => new AcaciaWallHangingSignBlock(Identifier, Direction.East, true),
            5737 => new AcaciaWallHangingSignBlock(Identifier, Direction.East, false),
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
