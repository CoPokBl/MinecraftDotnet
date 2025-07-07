using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BellBlock(Identifier Identifier, BellBlock.Attachment AttachmentValue, Direction Facing, bool Powered) : IBlock {

    public double Hardness => 5;
    public double ExplosionResistance => 5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "anvil";
    public Identifier? BlockEntity => "minecraft:bell";
    public Identifier? Item => "minecraft:bell";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.25] -> [1.0, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.25] -> [1.0, 1.0, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.25] -> [1.0, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.25] -> [1.0, 1.0, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 30;
    public string TranslationKey => "block.minecraft.bell";
    public bool CanRespawnIn => false;


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
    
    public IBlock WithState(uint state) {
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
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AttachmentValue = AttachmentFromString(properties["attachment"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
    public enum Attachment {
        Floor,
        Ceiling,
        SingleWall,
        DoubleWall,
    }

    public static Attachment AttachmentFromString(string value) {
        return value switch {
            "floor" => Attachment.Floor,
            "ceiling" => Attachment.Ceiling,
            "single_wall" => Attachment.SingleWall,
            "double_wall" => Attachment.DoubleWall,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Attachment.")
        };
    }
}
