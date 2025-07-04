using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12093,
                    false => 12094,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12095,
                    false => 12096,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12097,
                    false => 12098,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12093 => new PaleOakSlabBlock(Identifier, SlabType.Top, true),
            12094 => new PaleOakSlabBlock(Identifier, SlabType.Top, false),
            12095 => new PaleOakSlabBlock(Identifier, SlabType.Bottom, true),
            12096 => new PaleOakSlabBlock(Identifier, SlabType.Bottom, false),
            12097 => new PaleOakSlabBlock(Identifier, SlabType.Double, true),
            12098 => new PaleOakSlabBlock(Identifier, SlabType.Double, false),
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
