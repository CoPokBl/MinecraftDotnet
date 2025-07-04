using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 22933,
                    false => 22934,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 22935,
                    false => 22936,
                },
                SlabType.Double => Waterlogged switch {
                    true => 22937,
                    false => 22938,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22933 => new TuffBrickSlabBlock(Identifier, SlabType.Top, true),
            22934 => new TuffBrickSlabBlock(Identifier, SlabType.Top, false),
            22935 => new TuffBrickSlabBlock(Identifier, SlabType.Bottom, true),
            22936 => new TuffBrickSlabBlock(Identifier, SlabType.Bottom, false),
            22937 => new TuffBrickSlabBlock(Identifier, SlabType.Double, true),
            22938 => new TuffBrickSlabBlock(Identifier, SlabType.Double, false),
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
