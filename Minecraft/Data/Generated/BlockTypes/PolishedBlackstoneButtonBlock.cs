using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PolishedBlackstoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 21402,
                        false => 21403,
                    },
                    Direction.South => Powered switch {
                        true => 21404,
                        false => 21405,
                    },
                    Direction.West => Powered switch {
                        true => 21406,
                        false => 21407,
                    },
                    Direction.East => Powered switch {
                        true => 21408,
                        false => 21409,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 21410,
                        false => 21411,
                    },
                    Direction.South => Powered switch {
                        true => 21412,
                        false => 21413,
                    },
                    Direction.West => Powered switch {
                        true => 21414,
                        false => 21415,
                    },
                    Direction.East => Powered switch {
                        true => 21416,
                        false => 21417,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 21418,
                        false => 21419,
                    },
                    Direction.South => Powered switch {
                        true => 21420,
                        false => 21421,
                    },
                    Direction.West => Powered switch {
                        true => 21422,
                        false => 21423,
                    },
                    Direction.East => Powered switch {
                        true => 21424,
                        false => 21425,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            21402 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            21403 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            21404 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            21405 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            21406 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            21407 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            21408 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            21409 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            21410 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            21411 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            21412 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            21413 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            21414 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            21415 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            21416 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            21417 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            21418 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            21419 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            21420 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            21421 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            21422 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            21423 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            21424 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            21425 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
