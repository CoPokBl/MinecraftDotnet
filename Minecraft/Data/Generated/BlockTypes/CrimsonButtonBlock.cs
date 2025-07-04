using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 20123,
                        false => 20124,
                    },
                    Direction.South => Powered switch {
                        true => 20125,
                        false => 20126,
                    },
                    Direction.West => Powered switch {
                        true => 20127,
                        false => 20128,
                    },
                    Direction.East => Powered switch {
                        true => 20129,
                        false => 20130,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20131,
                        false => 20132,
                    },
                    Direction.South => Powered switch {
                        true => 20133,
                        false => 20134,
                    },
                    Direction.West => Powered switch {
                        true => 20135,
                        false => 20136,
                    },
                    Direction.East => Powered switch {
                        true => 20137,
                        false => 20138,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20139,
                        false => 20140,
                    },
                    Direction.South => Powered switch {
                        true => 20141,
                        false => 20142,
                    },
                    Direction.West => Powered switch {
                        true => 20143,
                        false => 20144,
                    },
                    Direction.East => Powered switch {
                        true => 20145,
                        false => 20146,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20123 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            20124 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            20125 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            20126 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            20127 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            20128 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            20129 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            20130 => new CrimsonButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            20131 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            20132 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            20133 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            20134 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            20135 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            20136 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            20137 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            20138 => new CrimsonButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            20139 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            20140 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            20141 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            20142 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            20143 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            20144 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            20145 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            20146 => new CrimsonButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
