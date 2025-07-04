using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmokerBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 19443,
                    false => 19444,
                },
                Direction.South => Lit switch {
                    true => 19445,
                    false => 19446,
                },
                Direction.West => Lit switch {
                    true => 19447,
                    false => 19448,
                },
                Direction.East => Lit switch {
                    true => 19449,
                    false => 19450,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19443 => new SmokerBlock(Identifier, Direction.North, true),
            19444 => new SmokerBlock(Identifier, Direction.North, false),
            19445 => new SmokerBlock(Identifier, Direction.South, true),
            19446 => new SmokerBlock(Identifier, Direction.South, false),
            19447 => new SmokerBlock(Identifier, Direction.West, true),
            19448 => new SmokerBlock(Identifier, Direction.West, false),
            19449 => new SmokerBlock(Identifier, Direction.East, true),
            19450 => new SmokerBlock(Identifier, Direction.East, false),
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
