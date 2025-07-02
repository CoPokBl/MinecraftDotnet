using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PurpurSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12195,
                    false => 12196,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12197,
                    false => 12198,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12199,
                    false => 12200,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12195 => new PurpurSlabBlock(Identifier, SlabType.Top, true),
            12196 => new PurpurSlabBlock(Identifier, SlabType.Top, false),
            12197 => new PurpurSlabBlock(Identifier, SlabType.Bottom, true),
            12198 => new PurpurSlabBlock(Identifier, SlabType.Bottom, false),
            12199 => new PurpurSlabBlock(Identifier, SlabType.Double, true),
            12200 => new PurpurSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
