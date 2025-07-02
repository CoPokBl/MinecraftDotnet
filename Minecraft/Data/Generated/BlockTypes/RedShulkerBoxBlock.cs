using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record RedShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13675,
                Cardinal.East => 13676,
                Cardinal.South => 13677,
                Cardinal.West => 13678,
                Cardinal.Up => 13679,
                Cardinal.Down => 13680,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13675 => new RedShulkerBoxBlock(Identifier, Cardinal.North),
            13676 => new RedShulkerBoxBlock(Identifier, Cardinal.East),
            13677 => new RedShulkerBoxBlock(Identifier, Cardinal.South),
            13678 => new RedShulkerBoxBlock(Identifier, Cardinal.West),
            13679 => new RedShulkerBoxBlock(Identifier, Cardinal.Up),
            13680 => new RedShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
