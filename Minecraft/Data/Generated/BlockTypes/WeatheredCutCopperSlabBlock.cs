using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WeatheredCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24310,
                    false => 24311,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24312,
                    false => 24313,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24314,
                    false => 24315,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            24310 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24311 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24312 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24313 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24314 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24315 => new WeatheredCutCopperSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
