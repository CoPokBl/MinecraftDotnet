using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedAndesiteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15171,
                    false => 15172,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15173,
                    false => 15174,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15175,
                    false => 15176,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15171 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Top, true),
            15172 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Top, false),
            15173 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Bottom, true),
            15174 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Bottom, false),
            15175 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Double, true),
            15176 => new PolishedAndesiteSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
