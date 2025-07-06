using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothQuartzSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15147,
                    false => 15148,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15149,
                    false => 15150,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15151,
                    false => 15152,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15147 => new SmoothQuartzSlabBlock(Identifier, SlabType.Top, true),
            15148 => new SmoothQuartzSlabBlock(Identifier, SlabType.Top, false),
            15149 => new SmoothQuartzSlabBlock(Identifier, SlabType.Bottom, true),
            15150 => new SmoothQuartzSlabBlock(Identifier, SlabType.Bottom, false),
            15151 => new SmoothQuartzSlabBlock(Identifier, SlabType.Double, true),
            15152 => new SmoothQuartzSlabBlock(Identifier, SlabType.Double, false),
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
