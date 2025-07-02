using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SmoothStoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12123,
                    false => 12124,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12125,
                    false => 12126,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12127,
                    false => 12128,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12123 => new SmoothStoneSlabBlock(Identifier, SlabType.Top, true),
            12124 => new SmoothStoneSlabBlock(Identifier, SlabType.Top, false),
            12125 => new SmoothStoneSlabBlock(Identifier, SlabType.Bottom, true),
            12126 => new SmoothStoneSlabBlock(Identifier, SlabType.Bottom, false),
            12127 => new SmoothStoneSlabBlock(Identifier, SlabType.Double, true),
            12128 => new SmoothStoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
