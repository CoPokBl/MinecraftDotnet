using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SmoothSandstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15141,
                    false => 15142,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15143,
                    false => 15144,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15145,
                    false => 15146,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15141 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Top, true),
            15142 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Top, false),
            15143 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Bottom, true),
            15144 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Bottom, false),
            15145 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Double, true),
            15146 => new SmoothSandstoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
