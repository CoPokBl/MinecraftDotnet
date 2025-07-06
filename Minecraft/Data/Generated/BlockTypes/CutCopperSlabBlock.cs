using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24322,
                    false => 24323,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24324,
                    false => 24325,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24326,
                    false => 24327,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24322 => new CutCopperSlabBlock(Identifier, SlabType.Top, true),
            24323 => new CutCopperSlabBlock(Identifier, SlabType.Top, false),
            24324 => new CutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24325 => new CutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24326 => new CutCopperSlabBlock(Identifier, SlabType.Double, true),
            24327 => new CutCopperSlabBlock(Identifier, SlabType.Double, false),
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
