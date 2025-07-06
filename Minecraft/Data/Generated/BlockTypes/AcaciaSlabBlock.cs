using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12075,
                    false => 12076,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12077,
                    false => 12078,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12079,
                    false => 12080,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12075 => new AcaciaSlabBlock(Identifier, SlabType.Top, true),
            12076 => new AcaciaSlabBlock(Identifier, SlabType.Top, false),
            12077 => new AcaciaSlabBlock(Identifier, SlabType.Bottom, true),
            12078 => new AcaciaSlabBlock(Identifier, SlabType.Bottom, false),
            12079 => new AcaciaSlabBlock(Identifier, SlabType.Double, true),
            12080 => new AcaciaSlabBlock(Identifier, SlabType.Double, false),
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
