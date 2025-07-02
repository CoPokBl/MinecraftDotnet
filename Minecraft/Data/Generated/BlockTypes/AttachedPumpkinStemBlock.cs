using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record AttachedPumpkinStemBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 7056,
                Direction.South => 7057,
                Direction.West => 7058,
                Direction.East => 7059,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            7056 => new AttachedPumpkinStemBlock(Identifier, Direction.North),
            7057 => new AttachedPumpkinStemBlock(Identifier, Direction.South),
            7058 => new AttachedPumpkinStemBlock(Identifier, Direction.West),
            7059 => new AttachedPumpkinStemBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
