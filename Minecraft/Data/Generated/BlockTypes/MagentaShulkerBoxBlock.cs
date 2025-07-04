using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13603,
                Cardinal.East => 13604,
                Cardinal.South => 13605,
                Cardinal.West => 13606,
                Cardinal.Up => 13607,
                Cardinal.Down => 13608,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13603 => new MagentaShulkerBoxBlock(Identifier, Cardinal.North),
            13604 => new MagentaShulkerBoxBlock(Identifier, Cardinal.East),
            13605 => new MagentaShulkerBoxBlock(Identifier, Cardinal.South),
            13606 => new MagentaShulkerBoxBlock(Identifier, Cardinal.West),
            13607 => new MagentaShulkerBoxBlock(Identifier, Cardinal.Up),
            13608 => new MagentaShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
