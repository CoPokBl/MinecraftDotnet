using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CobblestoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12147,
                    false => 12148,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12149,
                    false => 12150,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12151,
                    false => 12152,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12147 => new CobblestoneSlabBlock(Identifier, SlabType.Top, true),
            12148 => new CobblestoneSlabBlock(Identifier, SlabType.Top, false),
            12149 => new CobblestoneSlabBlock(Identifier, SlabType.Bottom, true),
            12150 => new CobblestoneSlabBlock(Identifier, SlabType.Bottom, false),
            12151 => new CobblestoneSlabBlock(Identifier, SlabType.Double, true),
            12152 => new CobblestoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
