using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12117,
                    false => 12118,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12119,
                    false => 12120,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12121,
                    false => 12122,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12117 => new StoneSlabBlock(Identifier, SlabType.Top, true),
            12118 => new StoneSlabBlock(Identifier, SlabType.Top, false),
            12119 => new StoneSlabBlock(Identifier, SlabType.Bottom, true),
            12120 => new StoneSlabBlock(Identifier, SlabType.Bottom, false),
            12121 => new StoneSlabBlock(Identifier, SlabType.Double, true),
            12122 => new StoneSlabBlock(Identifier, SlabType.Double, false),
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
