using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MudBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12165,
                    false => 12166,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12167,
                    false => 12168,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12169,
                    false => 12170,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12165 => new MudBrickSlabBlock(Identifier, SlabType.Top, true),
            12166 => new MudBrickSlabBlock(Identifier, SlabType.Top, false),
            12167 => new MudBrickSlabBlock(Identifier, SlabType.Bottom, true),
            12168 => new MudBrickSlabBlock(Identifier, SlabType.Bottom, false),
            12169 => new MudBrickSlabBlock(Identifier, SlabType.Double, true),
            12170 => new MudBrickSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
