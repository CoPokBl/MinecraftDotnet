using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AmethystClusterBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 22061,
                    false => 22062,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22063,
                    false => 22064,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22065,
                    false => 22066,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22067,
                    false => 22068,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22069,
                    false => 22070,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22071,
                    false => 22072,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22061 => new AmethystClusterBlock(Identifier, Cardinal.North, true),
            22062 => new AmethystClusterBlock(Identifier, Cardinal.North, false),
            22063 => new AmethystClusterBlock(Identifier, Cardinal.East, true),
            22064 => new AmethystClusterBlock(Identifier, Cardinal.East, false),
            22065 => new AmethystClusterBlock(Identifier, Cardinal.South, true),
            22066 => new AmethystClusterBlock(Identifier, Cardinal.South, false),
            22067 => new AmethystClusterBlock(Identifier, Cardinal.West, true),
            22068 => new AmethystClusterBlock(Identifier, Cardinal.West, false),
            22069 => new AmethystClusterBlock(Identifier, Cardinal.Up, true),
            22070 => new AmethystClusterBlock(Identifier, Cardinal.Up, false),
            22071 => new AmethystClusterBlock(Identifier, Cardinal.Down, true),
            22072 => new AmethystClusterBlock(Identifier, Cardinal.Down, false),
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
