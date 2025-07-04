using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobbledDeepslateSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 26048,
                    false => 26049,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 26050,
                    false => 26051,
                },
                SlabType.Double => Waterlogged switch {
                    true => 26052,
                    false => 26053,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26048 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Top, true),
            26049 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Top, false),
            26050 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Bottom, true),
            26051 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Bottom, false),
            26052 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Double, true),
            26053 => new CobbledDeepslateSlabBlock(Identifier, SlabType.Double, false),
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
