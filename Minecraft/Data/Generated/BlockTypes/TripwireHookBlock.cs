using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TripwireHookBlock(Identifier Identifier, bool Attached, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Facing switch {
                    Direction.North => Powered switch {
                        true => 8305,
                        false => 8306,
                    },
                    Direction.South => Powered switch {
                        true => 8307,
                        false => 8308,
                    },
                    Direction.West => Powered switch {
                        true => 8309,
                        false => 8310,
                    },
                    Direction.East => Powered switch {
                        true => 8311,
                        false => 8312,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Powered switch {
                        true => 8313,
                        false => 8314,
                    },
                    Direction.South => Powered switch {
                        true => 8315,
                        false => 8316,
                    },
                    Direction.West => Powered switch {
                        true => 8317,
                        false => 8318,
                    },
                    Direction.East => Powered switch {
                        true => 8319,
                        false => 8320,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8305 => new TripwireHookBlock(Identifier, true, Direction.North, true),
            8306 => new TripwireHookBlock(Identifier, true, Direction.North, false),
            8307 => new TripwireHookBlock(Identifier, true, Direction.South, true),
            8308 => new TripwireHookBlock(Identifier, true, Direction.South, false),
            8309 => new TripwireHookBlock(Identifier, true, Direction.West, true),
            8310 => new TripwireHookBlock(Identifier, true, Direction.West, false),
            8311 => new TripwireHookBlock(Identifier, true, Direction.East, true),
            8312 => new TripwireHookBlock(Identifier, true, Direction.East, false),
            8313 => new TripwireHookBlock(Identifier, false, Direction.North, true),
            8314 => new TripwireHookBlock(Identifier, false, Direction.North, false),
            8315 => new TripwireHookBlock(Identifier, false, Direction.South, true),
            8316 => new TripwireHookBlock(Identifier, false, Direction.South, false),
            8317 => new TripwireHookBlock(Identifier, false, Direction.West, true),
            8318 => new TripwireHookBlock(Identifier, false, Direction.West, false),
            8319 => new TripwireHookBlock(Identifier, false, Direction.East, true),
            8320 => new TripwireHookBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
