using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SandstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12129,
                    false => 12130,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12131,
                    false => 12132,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12133,
                    false => 12134,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12129 => new SandstoneSlabBlock(Identifier, SlabType.Top, true),
            12130 => new SandstoneSlabBlock(Identifier, SlabType.Top, false),
            12131 => new SandstoneSlabBlock(Identifier, SlabType.Bottom, true),
            12132 => new SandstoneSlabBlock(Identifier, SlabType.Bottom, false),
            12133 => new SandstoneSlabBlock(Identifier, SlabType.Double, true),
            12134 => new SandstoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Type = SlabTypeExtensions.FromString(properties["type"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
