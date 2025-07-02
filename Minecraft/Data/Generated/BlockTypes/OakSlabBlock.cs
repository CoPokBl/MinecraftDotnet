using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record OakSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12051,
                    false => 12052,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12053,
                    false => 12054,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12055,
                    false => 12056,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12051 => new OakSlabBlock(Identifier, SlabType.Top, true),
            12052 => new OakSlabBlock(Identifier, SlabType.Top, false),
            12053 => new OakSlabBlock(Identifier, SlabType.Bottom, true),
            12054 => new OakSlabBlock(Identifier, SlabType.Bottom, false),
            12055 => new OakSlabBlock(Identifier, SlabType.Double, true),
            12056 => new OakSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
