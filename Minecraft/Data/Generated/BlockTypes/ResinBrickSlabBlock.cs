using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ResinBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 7725,
                    false => 7726,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 7727,
                    false => 7728,
                },
                SlabType.Double => Waterlogged switch {
                    true => 7729,
                    false => 7730,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            7725 => new ResinBrickSlabBlock(Identifier, SlabType.Top, true),
            7726 => new ResinBrickSlabBlock(Identifier, SlabType.Top, false),
            7727 => new ResinBrickSlabBlock(Identifier, SlabType.Bottom, true),
            7728 => new ResinBrickSlabBlock(Identifier, SlabType.Bottom, false),
            7729 => new ResinBrickSlabBlock(Identifier, SlabType.Double, true),
            7730 => new ResinBrickSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
