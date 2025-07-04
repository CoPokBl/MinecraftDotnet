using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 20147,
                        false => 20148,
                    },
                    Direction.South => Powered switch {
                        true => 20149,
                        false => 20150,
                    },
                    Direction.West => Powered switch {
                        true => 20151,
                        false => 20152,
                    },
                    Direction.East => Powered switch {
                        true => 20153,
                        false => 20154,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20155,
                        false => 20156,
                    },
                    Direction.South => Powered switch {
                        true => 20157,
                        false => 20158,
                    },
                    Direction.West => Powered switch {
                        true => 20159,
                        false => 20160,
                    },
                    Direction.East => Powered switch {
                        true => 20161,
                        false => 20162,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20163,
                        false => 20164,
                    },
                    Direction.South => Powered switch {
                        true => 20165,
                        false => 20166,
                    },
                    Direction.West => Powered switch {
                        true => 20167,
                        false => 20168,
                    },
                    Direction.East => Powered switch {
                        true => 20169,
                        false => 20170,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20147 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            20148 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            20149 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            20150 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            20151 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            20152 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            20153 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            20154 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            20155 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            20156 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            20157 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            20158 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            20159 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            20160 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            20161 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            20162 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            20163 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            20164 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            20165 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            20166 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            20167 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            20168 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            20169 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            20170 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
