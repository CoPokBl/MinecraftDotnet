using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlastFurnaceBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 19451,
                    false => 19452,
                },
                Direction.South => Lit switch {
                    true => 19453,
                    false => 19454,
                },
                Direction.West => Lit switch {
                    true => 19455,
                    false => 19456,
                },
                Direction.East => Lit switch {
                    true => 19457,
                    false => 19458,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19451 => new BlastFurnaceBlock(Identifier, Direction.North, true),
            19452 => new BlastFurnaceBlock(Identifier, Direction.North, false),
            19453 => new BlastFurnaceBlock(Identifier, Direction.South, true),
            19454 => new BlastFurnaceBlock(Identifier, Direction.South, false),
            19455 => new BlastFurnaceBlock(Identifier, Direction.West, true),
            19456 => new BlastFurnaceBlock(Identifier, Direction.West, false),
            19457 => new BlastFurnaceBlock(Identifier, Direction.East, true),
            19458 => new BlastFurnaceBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}
