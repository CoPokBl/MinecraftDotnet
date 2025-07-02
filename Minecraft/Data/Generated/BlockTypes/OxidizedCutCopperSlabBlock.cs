using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OxidizedCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24304,
                    false => 24305,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24306,
                    false => 24307,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24308,
                    false => 24309,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            24304 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24305 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24306 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24307 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24308 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24309 => new OxidizedCutCopperSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
