using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CarvedPumpkinBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 6045,
                Direction.South => 6046,
                Direction.West => 6047,
                Direction.East => 6048,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            6045 => new CarvedPumpkinBlock(Identifier, Direction.North),
            6046 => new CarvedPumpkinBlock(Identifier, Direction.South),
            6047 => new CarvedPumpkinBlock(Identifier, Direction.West),
            6048 => new CarvedPumpkinBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
