using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5778,
                    false => 5779,
                },
                Direction.South => Waterlogged switch {
                    true => 5780,
                    false => 5781,
                },
                Direction.West => Waterlogged switch {
                    true => 5782,
                    false => 5783,
                },
                Direction.East => Waterlogged switch {
                    true => 5784,
                    false => 5785,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5778 => new CrimsonWallHangingSignBlock(Identifier, Direction.North, true),
            5779 => new CrimsonWallHangingSignBlock(Identifier, Direction.North, false),
            5780 => new CrimsonWallHangingSignBlock(Identifier, Direction.South, true),
            5781 => new CrimsonWallHangingSignBlock(Identifier, Direction.South, false),
            5782 => new CrimsonWallHangingSignBlock(Identifier, Direction.West, true),
            5783 => new CrimsonWallHangingSignBlock(Identifier, Direction.West, false),
            5784 => new CrimsonWallHangingSignBlock(Identifier, Direction.East, true),
            5785 => new CrimsonWallHangingSignBlock(Identifier, Direction.East, false),
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
