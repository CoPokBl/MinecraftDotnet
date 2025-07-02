using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedDioriteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15123,
                    false => 15124,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15125,
                    false => 15126,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15127,
                    false => 15128,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15123 => new PolishedDioriteSlabBlock(Identifier, SlabType.Top, true),
            15124 => new PolishedDioriteSlabBlock(Identifier, SlabType.Top, false),
            15125 => new PolishedDioriteSlabBlock(Identifier, SlabType.Bottom, true),
            15126 => new PolishedDioriteSlabBlock(Identifier, SlabType.Bottom, false),
            15127 => new PolishedDioriteSlabBlock(Identifier, SlabType.Double, true),
            15128 => new PolishedDioriteSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
