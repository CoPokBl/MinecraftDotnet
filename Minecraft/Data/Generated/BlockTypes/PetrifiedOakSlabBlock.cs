using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PetrifiedOakSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12141,
                    false => 12142,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12143,
                    false => 12144,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12145,
                    false => 12146,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12141 => new PetrifiedOakSlabBlock(Identifier, SlabType.Top, true),
            12142 => new PetrifiedOakSlabBlock(Identifier, SlabType.Top, false),
            12143 => new PetrifiedOakSlabBlock(Identifier, SlabType.Bottom, true),
            12144 => new PetrifiedOakSlabBlock(Identifier, SlabType.Bottom, false),
            12145 => new PetrifiedOakSlabBlock(Identifier, SlabType.Double, true),
            12146 => new PetrifiedOakSlabBlock(Identifier, SlabType.Double, false),
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
