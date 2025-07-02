using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BellBlock(Identifier Identifier, BellBlock.Attachment AttachmentValue, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return AttachmentValue switch {
                Attachment.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 19494,
                        false => 19495,
                    },
                    Direction.South => Powered switch {
                        true => 19496,
                        false => 19497,
                    },
                    Direction.West => Powered switch {
                        true => 19498,
                        false => 19499,
                    },
                    Direction.East => Powered switch {
                        true => 19500,
                        false => 19501,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 19502,
                        false => 19503,
                    },
                    Direction.South => Powered switch {
                        true => 19504,
                        false => 19505,
                    },
                    Direction.West => Powered switch {
                        true => 19506,
                        false => 19507,
                    },
                    Direction.East => Powered switch {
                        true => 19508,
                        false => 19509,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 19510,
                        false => 19511,
                    },
                    Direction.South => Powered switch {
                        true => 19512,
                        false => 19513,
                    },
                    Direction.West => Powered switch {
                        true => 19514,
                        false => 19515,
                    },
                    Direction.East => Powered switch {
                        true => 19516,
                        false => 19517,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 19518,
                        false => 19519,
                    },
                    Direction.South => Powered switch {
                        true => 19520,
                        false => 19521,
                    },
                    Direction.West => Powered switch {
                        true => 19522,
                        false => 19523,
                    },
                    Direction.East => Powered switch {
                        true => 19524,
                        false => 19525,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(AttachmentValue), AttachmentValue, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19494 => new BellBlock(Identifier, Attachment.Floor, Direction.North, true),
            19495 => new BellBlock(Identifier, Attachment.Floor, Direction.North, false),
            19496 => new BellBlock(Identifier, Attachment.Floor, Direction.South, true),
            19497 => new BellBlock(Identifier, Attachment.Floor, Direction.South, false),
            19498 => new BellBlock(Identifier, Attachment.Floor, Direction.West, true),
            19499 => new BellBlock(Identifier, Attachment.Floor, Direction.West, false),
            19500 => new BellBlock(Identifier, Attachment.Floor, Direction.East, true),
            19501 => new BellBlock(Identifier, Attachment.Floor, Direction.East, false),
            19502 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, true),
            19503 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, false),
            19504 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, true),
            19505 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, false),
            19506 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, true),
            19507 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, false),
            19508 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, true),
            19509 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, false),
            19510 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, true),
            19511 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, false),
            19512 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, true),
            19513 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, false),
            19514 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, true),
            19515 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, false),
            19516 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, true),
            19517 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, false),
            19518 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, true),
            19519 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, false),
            19520 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, true),
            19521 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, false),
            19522 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, true),
            19523 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, false),
            19524 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, true),
            19525 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Attachment {
        Floor,
        Ceiling,
        SingleWall,
        DoubleWall,
    }
}
