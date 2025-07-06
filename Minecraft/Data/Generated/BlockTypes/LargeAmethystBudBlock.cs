using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LargeAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 22073,
                    false => 22074,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22075,
                    false => 22076,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22077,
                    false => 22078,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22079,
                    false => 22080,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22081,
                    false => 22082,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22083,
                    false => 22084,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22073 => new LargeAmethystBudBlock(Identifier, Cardinal.North, true),
            22074 => new LargeAmethystBudBlock(Identifier, Cardinal.North, false),
            22075 => new LargeAmethystBudBlock(Identifier, Cardinal.East, true),
            22076 => new LargeAmethystBudBlock(Identifier, Cardinal.East, false),
            22077 => new LargeAmethystBudBlock(Identifier, Cardinal.South, true),
            22078 => new LargeAmethystBudBlock(Identifier, Cardinal.South, false),
            22079 => new LargeAmethystBudBlock(Identifier, Cardinal.West, true),
            22080 => new LargeAmethystBudBlock(Identifier, Cardinal.West, false),
            22081 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, true),
            22082 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, false),
            22083 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, true),
            22084 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
