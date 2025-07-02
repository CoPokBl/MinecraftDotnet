using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record YellowShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13615,
                Cardinal.East => 13616,
                Cardinal.South => 13617,
                Cardinal.West => 13618,
                Cardinal.Up => 13619,
                Cardinal.Down => 13620,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13615 => new YellowShulkerBoxBlock(Identifier, Cardinal.North),
            13616 => new YellowShulkerBoxBlock(Identifier, Cardinal.East),
            13617 => new YellowShulkerBoxBlock(Identifier, Cardinal.South),
            13618 => new YellowShulkerBoxBlock(Identifier, Cardinal.West),
            13619 => new YellowShulkerBoxBlock(Identifier, Cardinal.Up),
            13620 => new YellowShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
