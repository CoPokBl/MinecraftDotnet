using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 9468,
                        false => 9469,
                    },
                    Direction.South => Powered switch {
                        true => 9470,
                        false => 9471,
                    },
                    Direction.West => Powered switch {
                        true => 9472,
                        false => 9473,
                    },
                    Direction.East => Powered switch {
                        true => 9474,
                        false => 9475,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 9476,
                        false => 9477,
                    },
                    Direction.South => Powered switch {
                        true => 9478,
                        false => 9479,
                    },
                    Direction.West => Powered switch {
                        true => 9480,
                        false => 9481,
                    },
                    Direction.East => Powered switch {
                        true => 9482,
                        false => 9483,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 9484,
                        false => 9485,
                    },
                    Direction.South => Powered switch {
                        true => 9486,
                        false => 9487,
                    },
                    Direction.West => Powered switch {
                        true => 9488,
                        false => 9489,
                    },
                    Direction.East => Powered switch {
                        true => 9490,
                        false => 9491,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9468 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            9469 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            9470 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            9471 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            9472 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            9473 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            9474 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            9475 => new JungleButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            9476 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            9477 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            9478 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            9479 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            9480 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            9481 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            9482 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            9483 => new JungleButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            9484 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            9485 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            9486 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            9487 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            9488 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            9489 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            9490 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            9491 => new JungleButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = AttachDirectionExtensions.FromString(properties["face"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
