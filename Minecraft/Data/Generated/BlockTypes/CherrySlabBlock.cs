using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherrySlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12081,
                    false => 12082,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12083,
                    false => 12084,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12085,
                    false => 12086,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12081 => new CherrySlabBlock(Identifier, SlabType.Top, true),
            12082 => new CherrySlabBlock(Identifier, SlabType.Top, false),
            12083 => new CherrySlabBlock(Identifier, SlabType.Bottom, true),
            12084 => new CherrySlabBlock(Identifier, SlabType.Bottom, false),
            12085 => new CherrySlabBlock(Identifier, SlabType.Double, true),
            12086 => new CherrySlabBlock(Identifier, SlabType.Double, false),
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
