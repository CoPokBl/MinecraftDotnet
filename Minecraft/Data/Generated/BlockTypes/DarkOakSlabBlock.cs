using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DarkOakSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12087,
                    false => 12088,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12089,
                    false => 12090,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12091,
                    false => 12092,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12087 => new DarkOakSlabBlock(Identifier, SlabType.Top, true),
            12088 => new DarkOakSlabBlock(Identifier, SlabType.Top, false),
            12089 => new DarkOakSlabBlock(Identifier, SlabType.Bottom, true),
            12090 => new DarkOakSlabBlock(Identifier, SlabType.Bottom, false),
            12091 => new DarkOakSlabBlock(Identifier, SlabType.Double, true),
            12092 => new DarkOakSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
