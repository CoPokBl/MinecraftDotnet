using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12153,
                    false => 12154,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12155,
                    false => 12156,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12157,
                    false => 12158,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12153 => new BrickSlabBlock(Identifier, SlabType.Top, true),
            12154 => new BrickSlabBlock(Identifier, SlabType.Top, false),
            12155 => new BrickSlabBlock(Identifier, SlabType.Bottom, true),
            12156 => new BrickSlabBlock(Identifier, SlabType.Bottom, false),
            12157 => new BrickSlabBlock(Identifier, SlabType.Double, true),
            12158 => new BrickSlabBlock(Identifier, SlabType.Double, false),
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
