using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FurnaceBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 4358,
                    false => 4359,
                },
                Direction.South => Lit switch {
                    true => 4360,
                    false => 4361,
                },
                Direction.West => Lit switch {
                    true => 4362,
                    false => 4363,
                },
                Direction.East => Lit switch {
                    true => 4364,
                    false => 4365,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4358 => new FurnaceBlock(Identifier, Direction.North, true),
            4359 => new FurnaceBlock(Identifier, Direction.North, false),
            4360 => new FurnaceBlock(Identifier, Direction.South, true),
            4361 => new FurnaceBlock(Identifier, Direction.South, false),
            4362 => new FurnaceBlock(Identifier, Direction.West, true),
            4363 => new FurnaceBlock(Identifier, Direction.West, false),
            4364 => new FurnaceBlock(Identifier, Direction.East, true),
            4365 => new FurnaceBlock(Identifier, Direction.East, false),
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
