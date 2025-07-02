using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record RedNetherBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15165,
                    false => 15166,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15167,
                    false => 15168,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15169,
                    false => 15170,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15165 => new RedNetherBrickSlabBlock(Identifier, SlabType.Top, true),
            15166 => new RedNetherBrickSlabBlock(Identifier, SlabType.Top, false),
            15167 => new RedNetherBrickSlabBlock(Identifier, SlabType.Bottom, true),
            15168 => new RedNetherBrickSlabBlock(Identifier, SlabType.Bottom, false),
            15169 => new RedNetherBrickSlabBlock(Identifier, SlabType.Double, true),
            15170 => new RedNetherBrickSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
