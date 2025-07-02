using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record AndesiteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15159,
                    false => 15160,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15161,
                    false => 15162,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15163,
                    false => 15164,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15159 => new AndesiteSlabBlock(Identifier, SlabType.Top, true),
            15160 => new AndesiteSlabBlock(Identifier, SlabType.Top, false),
            15161 => new AndesiteSlabBlock(Identifier, SlabType.Bottom, true),
            15162 => new AndesiteSlabBlock(Identifier, SlabType.Bottom, false),
            15163 => new AndesiteSlabBlock(Identifier, SlabType.Double, true),
            15164 => new AndesiteSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
