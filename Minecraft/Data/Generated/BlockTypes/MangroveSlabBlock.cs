using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MangroveSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12099,
                    false => 12100,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12101,
                    false => 12102,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12103,
                    false => 12104,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12099 => new MangroveSlabBlock(Identifier, SlabType.Top, true),
            12100 => new MangroveSlabBlock(Identifier, SlabType.Top, false),
            12101 => new MangroveSlabBlock(Identifier, SlabType.Bottom, true),
            12102 => new MangroveSlabBlock(Identifier, SlabType.Bottom, false),
            12103 => new MangroveSlabBlock(Identifier, SlabType.Double, true),
            12104 => new MangroveSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
