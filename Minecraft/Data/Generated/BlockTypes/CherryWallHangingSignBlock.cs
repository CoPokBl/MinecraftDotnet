using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5738,
                    false => 5739,
                },
                Direction.South => Waterlogged switch {
                    true => 5740,
                    false => 5741,
                },
                Direction.West => Waterlogged switch {
                    true => 5742,
                    false => 5743,
                },
                Direction.East => Waterlogged switch {
                    true => 5744,
                    false => 5745,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5738 => new CherryWallHangingSignBlock(Identifier, Direction.North, true),
            5739 => new CherryWallHangingSignBlock(Identifier, Direction.North, false),
            5740 => new CherryWallHangingSignBlock(Identifier, Direction.South, true),
            5741 => new CherryWallHangingSignBlock(Identifier, Direction.South, false),
            5742 => new CherryWallHangingSignBlock(Identifier, Direction.West, true),
            5743 => new CherryWallHangingSignBlock(Identifier, Direction.West, false),
            5744 => new CherryWallHangingSignBlock(Identifier, Direction.East, true),
            5745 => new CherryWallHangingSignBlock(Identifier, Direction.East, false),
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
