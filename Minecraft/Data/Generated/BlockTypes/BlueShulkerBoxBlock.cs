using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlueShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13657,
                Cardinal.East => 13658,
                Cardinal.South => 13659,
                Cardinal.West => 13660,
                Cardinal.Up => 13661,
                Cardinal.Down => 13662,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13657 => new BlueShulkerBoxBlock(Identifier, Cardinal.North),
            13658 => new BlueShulkerBoxBlock(Identifier, Cardinal.East),
            13659 => new BlueShulkerBoxBlock(Identifier, Cardinal.South),
            13660 => new BlueShulkerBoxBlock(Identifier, Cardinal.West),
            13661 => new BlueShulkerBoxBlock(Identifier, Cardinal.Up),
            13662 => new BlueShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
