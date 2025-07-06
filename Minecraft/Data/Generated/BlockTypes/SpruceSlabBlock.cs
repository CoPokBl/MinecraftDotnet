using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12057,
                    false => 12058,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12059,
                    false => 12060,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12061,
                    false => 12062,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12057 => new SpruceSlabBlock(Identifier, SlabType.Top, true),
            12058 => new SpruceSlabBlock(Identifier, SlabType.Top, false),
            12059 => new SpruceSlabBlock(Identifier, SlabType.Bottom, true),
            12060 => new SpruceSlabBlock(Identifier, SlabType.Bottom, false),
            12061 => new SpruceSlabBlock(Identifier, SlabType.Double, true),
            12062 => new SpruceSlabBlock(Identifier, SlabType.Double, false),
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
