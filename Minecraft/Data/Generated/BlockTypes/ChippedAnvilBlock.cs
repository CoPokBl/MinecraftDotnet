using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ChippedAnvilBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 9920,
                Direction.South => 9921,
                Direction.West => 9922,
                Direction.East => 9923,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            9920 => new ChippedAnvilBlock(Identifier, Direction.North),
            9921 => new ChippedAnvilBlock(Identifier, Direction.South),
            9922 => new ChippedAnvilBlock(Identifier, Direction.West),
            9923 => new ChippedAnvilBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
