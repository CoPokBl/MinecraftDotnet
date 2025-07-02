using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GreenShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13669,
                Cardinal.East => 13670,
                Cardinal.South => 13671,
                Cardinal.West => 13672,
                Cardinal.Up => 13673,
                Cardinal.Down => 13674,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13669 => new GreenShulkerBoxBlock(Identifier, Cardinal.North),
            13670 => new GreenShulkerBoxBlock(Identifier, Cardinal.East),
            13671 => new GreenShulkerBoxBlock(Identifier, Cardinal.South),
            13672 => new GreenShulkerBoxBlock(Identifier, Cardinal.West),
            13673 => new GreenShulkerBoxBlock(Identifier, Cardinal.Up),
            13674 => new GreenShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
