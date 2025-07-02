using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record AttachedMelonStemBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 7060,
                Direction.South => 7061,
                Direction.West => 7062,
                Direction.East => 7063,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            7060 => new AttachedMelonStemBlock(Identifier, Direction.North),
            7061 => new AttachedMelonStemBlock(Identifier, Direction.South),
            7062 => new AttachedMelonStemBlock(Identifier, Direction.West),
            7063 => new AttachedMelonStemBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
