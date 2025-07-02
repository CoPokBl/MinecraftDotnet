using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CrimsonSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 19691,
                    false => 19692,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 19693,
                    false => 19694,
                },
                SlabType.Double => Waterlogged switch {
                    true => 19695,
                    false => 19696,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19691 => new CrimsonSlabBlock(Identifier, SlabType.Top, true),
            19692 => new CrimsonSlabBlock(Identifier, SlabType.Top, false),
            19693 => new CrimsonSlabBlock(Identifier, SlabType.Bottom, true),
            19694 => new CrimsonSlabBlock(Identifier, SlabType.Bottom, false),
            19695 => new CrimsonSlabBlock(Identifier, SlabType.Double, true),
            19696 => new CrimsonSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
