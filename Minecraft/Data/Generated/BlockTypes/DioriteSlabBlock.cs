using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DioriteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15177,
                    false => 15178,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15179,
                    false => 15180,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15181,
                    false => 15182,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15177 => new DioriteSlabBlock(Identifier, SlabType.Top, true),
            15178 => new DioriteSlabBlock(Identifier, SlabType.Top, false),
            15179 => new DioriteSlabBlock(Identifier, SlabType.Bottom, true),
            15180 => new DioriteSlabBlock(Identifier, SlabType.Bottom, false),
            15181 => new DioriteSlabBlock(Identifier, SlabType.Double, true),
            15182 => new DioriteSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
