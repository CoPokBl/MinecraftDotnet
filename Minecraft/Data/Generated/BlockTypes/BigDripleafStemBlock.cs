using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BigDripleafStemBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 25936,
                    false => 25937,
                },
                Direction.South => Waterlogged switch {
                    true => 25938,
                    false => 25939,
                },
                Direction.West => Waterlogged switch {
                    true => 25940,
                    false => 25941,
                },
                Direction.East => Waterlogged switch {
                    true => 25942,
                    false => 25943,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25936 => new BigDripleafStemBlock(Identifier, Direction.North, true),
            25937 => new BigDripleafStemBlock(Identifier, Direction.North, false),
            25938 => new BigDripleafStemBlock(Identifier, Direction.South, true),
            25939 => new BigDripleafStemBlock(Identifier, Direction.South, false),
            25940 => new BigDripleafStemBlock(Identifier, Direction.West, true),
            25941 => new BigDripleafStemBlock(Identifier, Direction.West, false),
            25942 => new BigDripleafStemBlock(Identifier, Direction.East, true),
            25943 => new BigDripleafStemBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
