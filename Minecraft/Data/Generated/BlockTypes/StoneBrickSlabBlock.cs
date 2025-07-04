using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12159,
                    false => 12160,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12161,
                    false => 12162,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12163,
                    false => 12164,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12159 => new StoneBrickSlabBlock(Identifier, SlabType.Top, true),
            12160 => new StoneBrickSlabBlock(Identifier, SlabType.Top, false),
            12161 => new StoneBrickSlabBlock(Identifier, SlabType.Bottom, true),
            12162 => new StoneBrickSlabBlock(Identifier, SlabType.Bottom, false),
            12163 => new StoneBrickSlabBlock(Identifier, SlabType.Double, true),
            12164 => new StoneBrickSlabBlock(Identifier, SlabType.Double, false),
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
