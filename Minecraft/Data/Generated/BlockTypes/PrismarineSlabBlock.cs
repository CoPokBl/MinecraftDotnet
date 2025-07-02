using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PrismarineSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 11595,
                    false => 11596,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 11597,
                    false => 11598,
                },
                SlabType.Double => Waterlogged switch {
                    true => 11599,
                    false => 11600,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            11595 => new PrismarineSlabBlock(Identifier, SlabType.Top, true),
            11596 => new PrismarineSlabBlock(Identifier, SlabType.Top, false),
            11597 => new PrismarineSlabBlock(Identifier, SlabType.Bottom, true),
            11598 => new PrismarineSlabBlock(Identifier, SlabType.Bottom, false),
            11599 => new PrismarineSlabBlock(Identifier, SlabType.Double, true),
            11600 => new PrismarineSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
