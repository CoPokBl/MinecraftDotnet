using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CyanShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13645,
                Cardinal.East => 13646,
                Cardinal.South => 13647,
                Cardinal.West => 13648,
                Cardinal.Up => 13649,
                Cardinal.Down => 13650,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13645 => new CyanShulkerBoxBlock(Identifier, Cardinal.North),
            13646 => new CyanShulkerBoxBlock(Identifier, Cardinal.East),
            13647 => new CyanShulkerBoxBlock(Identifier, Cardinal.South),
            13648 => new CyanShulkerBoxBlock(Identifier, Cardinal.West),
            13649 => new CyanShulkerBoxBlock(Identifier, Cardinal.Up),
            13650 => new CyanShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
