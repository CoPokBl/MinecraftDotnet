using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BarrelBlock(Identifier Identifier, Cardinal Facing, bool Open) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Open switch {
                    true => 19431,
                    false => 19432,
                },
                Cardinal.East => Open switch {
                    true => 19433,
                    false => 19434,
                },
                Cardinal.South => Open switch {
                    true => 19435,
                    false => 19436,
                },
                Cardinal.West => Open switch {
                    true => 19437,
                    false => 19438,
                },
                Cardinal.Up => Open switch {
                    true => 19439,
                    false => 19440,
                },
                Cardinal.Down => Open switch {
                    true => 19441,
                    false => 19442,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19431 => new BarrelBlock(Identifier, Cardinal.North, true),
            19432 => new BarrelBlock(Identifier, Cardinal.North, false),
            19433 => new BarrelBlock(Identifier, Cardinal.East, true),
            19434 => new BarrelBlock(Identifier, Cardinal.East, false),
            19435 => new BarrelBlock(Identifier, Cardinal.South, true),
            19436 => new BarrelBlock(Identifier, Cardinal.South, false),
            19437 => new BarrelBlock(Identifier, Cardinal.West, true),
            19438 => new BarrelBlock(Identifier, Cardinal.West, false),
            19439 => new BarrelBlock(Identifier, Cardinal.Up, true),
            19440 => new BarrelBlock(Identifier, Cardinal.Up, false),
            19441 => new BarrelBlock(Identifier, Cardinal.Down, true),
            19442 => new BarrelBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Open = properties["open"].GetString() == "true",
        };
    }
    
}
