using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record MossyStoneBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15117,
                    false => 15118,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15119,
                    false => 15120,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15121,
                    false => 15122,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            15117 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Top, true),
            15118 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Top, false),
            15119 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Bottom, true),
            15120 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Bottom, false),
            15121 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Double, true),
            15122 => new MossyStoneBrickSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
