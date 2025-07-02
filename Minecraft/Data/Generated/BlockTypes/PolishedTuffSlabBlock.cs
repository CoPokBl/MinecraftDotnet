using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedTuffSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 22521,
                    false => 22522,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 22523,
                    false => 22524,
                },
                SlabType.Double => Waterlogged switch {
                    true => 22525,
                    false => 22526,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            22521 => new PolishedTuffSlabBlock(Identifier, SlabType.Top, true),
            22522 => new PolishedTuffSlabBlock(Identifier, SlabType.Top, false),
            22523 => new PolishedTuffSlabBlock(Identifier, SlabType.Bottom, true),
            22524 => new PolishedTuffSlabBlock(Identifier, SlabType.Bottom, false),
            22525 => new PolishedTuffSlabBlock(Identifier, SlabType.Double, true),
            22526 => new PolishedTuffSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
