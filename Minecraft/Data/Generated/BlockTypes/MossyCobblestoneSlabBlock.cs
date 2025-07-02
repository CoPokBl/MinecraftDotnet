using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MossyCobblestoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15129,
                    false => 15130,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15131,
                    false => 15132,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15133,
                    false => 15134,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15129 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Top, true),
            15130 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Top, false),
            15131 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Bottom, true),
            15132 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Bottom, false),
            15133 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Double, true),
            15134 => new MossyCobblestoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
