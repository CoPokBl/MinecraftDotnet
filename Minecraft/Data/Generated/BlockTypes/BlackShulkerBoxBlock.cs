using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlackShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13681,
                Cardinal.East => 13682,
                Cardinal.South => 13683,
                Cardinal.West => 13684,
                Cardinal.Up => 13685,
                Cardinal.Down => 13686,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13681 => new BlackShulkerBoxBlock(Identifier, Cardinal.North),
            13682 => new BlackShulkerBoxBlock(Identifier, Cardinal.East),
            13683 => new BlackShulkerBoxBlock(Identifier, Cardinal.South),
            13684 => new BlackShulkerBoxBlock(Identifier, Cardinal.West),
            13685 => new BlackShulkerBoxBlock(Identifier, Cardinal.Up),
            13686 => new BlackShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
