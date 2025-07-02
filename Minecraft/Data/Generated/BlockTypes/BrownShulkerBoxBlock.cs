using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BrownShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13663,
                Cardinal.East => 13664,
                Cardinal.South => 13665,
                Cardinal.West => 13666,
                Cardinal.Up => 13667,
                Cardinal.Down => 13668,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13663 => new BrownShulkerBoxBlock(Identifier, Cardinal.North),
            13664 => new BrownShulkerBoxBlock(Identifier, Cardinal.East),
            13665 => new BrownShulkerBoxBlock(Identifier, Cardinal.South),
            13666 => new BrownShulkerBoxBlock(Identifier, Cardinal.West),
            13667 => new BrownShulkerBoxBlock(Identifier, Cardinal.Up),
            13668 => new BrownShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
