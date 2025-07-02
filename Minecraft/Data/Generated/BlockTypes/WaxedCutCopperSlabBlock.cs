using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24674,
                    false => 24675,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24676,
                    false => 24677,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24678,
                    false => 24679,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            24674 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24675 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24676 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24677 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24678 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24679 => new WaxedCutCopperSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
