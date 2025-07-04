using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12063,
                    false => 12064,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12065,
                    false => 12066,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12067,
                    false => 12068,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12063 => new BirchSlabBlock(Identifier, SlabType.Top, true),
            12064 => new BirchSlabBlock(Identifier, SlabType.Top, false),
            12065 => new BirchSlabBlock(Identifier, SlabType.Bottom, true),
            12066 => new BirchSlabBlock(Identifier, SlabType.Bottom, false),
            12067 => new BirchSlabBlock(Identifier, SlabType.Double, true),
            12068 => new BirchSlabBlock(Identifier, SlabType.Double, false),
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
