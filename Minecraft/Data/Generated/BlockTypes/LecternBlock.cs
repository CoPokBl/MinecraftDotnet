using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LecternBlock(Identifier Identifier, Direction Facing, bool HasBook, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HasBook switch {
                    true => Powered switch {
                        true => 19473,
                        false => 19474,
                    },
                    false => Powered switch {
                        true => 19475,
                        false => 19476,
                    },
                },
                Direction.South => HasBook switch {
                    true => Powered switch {
                        true => 19477,
                        false => 19478,
                    },
                    false => Powered switch {
                        true => 19479,
                        false => 19480,
                    },
                },
                Direction.West => HasBook switch {
                    true => Powered switch {
                        true => 19481,
                        false => 19482,
                    },
                    false => Powered switch {
                        true => 19483,
                        false => 19484,
                    },
                },
                Direction.East => HasBook switch {
                    true => Powered switch {
                        true => 19485,
                        false => 19486,
                    },
                    false => Powered switch {
                        true => 19487,
                        false => 19488,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19473 => new LecternBlock(Identifier, Direction.North, true, true),
            19474 => new LecternBlock(Identifier, Direction.North, true, false),
            19475 => new LecternBlock(Identifier, Direction.North, false, true),
            19476 => new LecternBlock(Identifier, Direction.North, false, false),
            19477 => new LecternBlock(Identifier, Direction.South, true, true),
            19478 => new LecternBlock(Identifier, Direction.South, true, false),
            19479 => new LecternBlock(Identifier, Direction.South, false, true),
            19480 => new LecternBlock(Identifier, Direction.South, false, false),
            19481 => new LecternBlock(Identifier, Direction.West, true, true),
            19482 => new LecternBlock(Identifier, Direction.West, true, false),
            19483 => new LecternBlock(Identifier, Direction.West, false, true),
            19484 => new LecternBlock(Identifier, Direction.West, false, false),
            19485 => new LecternBlock(Identifier, Direction.East, true, true),
            19486 => new LecternBlock(Identifier, Direction.East, true, false),
            19487 => new LecternBlock(Identifier, Direction.East, false, true),
            19488 => new LecternBlock(Identifier, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HasBook = properties["has_book"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
