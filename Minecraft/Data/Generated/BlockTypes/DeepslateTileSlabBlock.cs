using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record DeepslateTileSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 26870,
                    false => 26871,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 26872,
                    false => 26873,
                },
                SlabType.Double => Waterlogged switch {
                    true => 26874,
                    false => 26875,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            26870 => new DeepslateTileSlabBlock(Identifier, SlabType.Top, true),
            26871 => new DeepslateTileSlabBlock(Identifier, SlabType.Top, false),
            26872 => new DeepslateTileSlabBlock(Identifier, SlabType.Bottom, true),
            26873 => new DeepslateTileSlabBlock(Identifier, SlabType.Bottom, false),
            26874 => new DeepslateTileSlabBlock(Identifier, SlabType.Double, true),
            26875 => new DeepslateTileSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
