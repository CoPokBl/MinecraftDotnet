using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PinkShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13627,
                Cardinal.East => 13628,
                Cardinal.South => 13629,
                Cardinal.West => 13630,
                Cardinal.Up => 13631,
                Cardinal.Down => 13632,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13627 => new PinkShulkerBoxBlock(Identifier, Cardinal.North),
            13628 => new PinkShulkerBoxBlock(Identifier, Cardinal.East),
            13629 => new PinkShulkerBoxBlock(Identifier, Cardinal.South),
            13630 => new PinkShulkerBoxBlock(Identifier, Cardinal.West),
            13631 => new PinkShulkerBoxBlock(Identifier, Cardinal.Up),
            13632 => new PinkShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
