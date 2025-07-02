using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedGraniteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15105,
                    false => 15106,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15107,
                    false => 15108,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15109,
                    false => 15110,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15105 => new PolishedGraniteSlabBlock(Identifier, SlabType.Top, true),
            15106 => new PolishedGraniteSlabBlock(Identifier, SlabType.Top, false),
            15107 => new PolishedGraniteSlabBlock(Identifier, SlabType.Bottom, true),
            15108 => new PolishedGraniteSlabBlock(Identifier, SlabType.Bottom, false),
            15109 => new PolishedGraniteSlabBlock(Identifier, SlabType.Double, true),
            15110 => new PolishedGraniteSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
