using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OrangeShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13597,
                Cardinal.East => 13598,
                Cardinal.South => 13599,
                Cardinal.West => 13600,
                Cardinal.Up => 13601,
                Cardinal.Down => 13602,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13597 => new OrangeShulkerBoxBlock(Identifier, Cardinal.North),
            13598 => new OrangeShulkerBoxBlock(Identifier, Cardinal.East),
            13599 => new OrangeShulkerBoxBlock(Identifier, Cardinal.South),
            13600 => new OrangeShulkerBoxBlock(Identifier, Cardinal.West),
            13601 => new OrangeShulkerBoxBlock(Identifier, Cardinal.Up),
            13602 => new OrangeShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
