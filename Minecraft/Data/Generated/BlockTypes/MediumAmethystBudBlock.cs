using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MediumAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 22085,
                    false => 22086,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22087,
                    false => 22088,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22089,
                    false => 22090,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22091,
                    false => 22092,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22093,
                    false => 22094,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22095,
                    false => 22096,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22085 => new MediumAmethystBudBlock(Identifier, Cardinal.North, true),
            22086 => new MediumAmethystBudBlock(Identifier, Cardinal.North, false),
            22087 => new MediumAmethystBudBlock(Identifier, Cardinal.East, true),
            22088 => new MediumAmethystBudBlock(Identifier, Cardinal.East, false),
            22089 => new MediumAmethystBudBlock(Identifier, Cardinal.South, true),
            22090 => new MediumAmethystBudBlock(Identifier, Cardinal.South, false),
            22091 => new MediumAmethystBudBlock(Identifier, Cardinal.West, true),
            22092 => new MediumAmethystBudBlock(Identifier, Cardinal.West, false),
            22093 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, true),
            22094 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, false),
            22095 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, true),
            22096 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, false),
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
