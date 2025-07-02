using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PurpleShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13651,
                Cardinal.East => 13652,
                Cardinal.South => 13653,
                Cardinal.West => 13654,
                Cardinal.Up => 13655,
                Cardinal.Down => 13656,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13651 => new PurpleShulkerBoxBlock(Identifier, Cardinal.North),
            13652 => new PurpleShulkerBoxBlock(Identifier, Cardinal.East),
            13653 => new PurpleShulkerBoxBlock(Identifier, Cardinal.South),
            13654 => new PurpleShulkerBoxBlock(Identifier, Cardinal.West),
            13655 => new PurpleShulkerBoxBlock(Identifier, Cardinal.Up),
            13656 => new PurpleShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
