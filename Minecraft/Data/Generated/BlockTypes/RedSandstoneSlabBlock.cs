using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record RedSandstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12183,
                    false => 12184,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12185,
                    false => 12186,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12187,
                    false => 12188,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            12183 => new RedSandstoneSlabBlock(Identifier, SlabType.Top, true),
            12184 => new RedSandstoneSlabBlock(Identifier, SlabType.Top, false),
            12185 => new RedSandstoneSlabBlock(Identifier, SlabType.Bottom, true),
            12186 => new RedSandstoneSlabBlock(Identifier, SlabType.Bottom, false),
            12187 => new RedSandstoneSlabBlock(Identifier, SlabType.Double, true),
            12188 => new RedSandstoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
