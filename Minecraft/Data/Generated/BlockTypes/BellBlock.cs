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

    public Identifier Category => "minecraft:bell";
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
                        true => 19526,
                        false => 19527,
                    },
                    Direction.South => Powered switch {
                        true => 19528,
                        false => 19529,
                    },
                    Direction.West => Powered switch {
                        true => 19530,
                        false => 19531,
                    },
                    Direction.East => Powered switch {
                        true => 19532,
                        false => 19533,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 19534,
                        false => 19535,
                    },
                    Direction.South => Powered switch {
                        true => 19536,
                        false => 19537,
                    },
                    Direction.West => Powered switch {
                        true => 19538,
                        false => 19539,
                    },
                    Direction.East => Powered switch {
                        true => 19540,
                        false => 19541,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 19542,
                        false => 19543,
                    },
                    Direction.South => Powered switch {
                        true => 19544,
                        false => 19545,
                    },
                    Direction.West => Powered switch {
                        true => 19546,
                        false => 19547,
                    },
                    Direction.East => Powered switch {
                        true => 19548,
                        false => 19549,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 19550,
                        false => 19551,
                    },
                    Direction.South => Powered switch {
                        true => 19552,
                        false => 19553,
                    },
                    Direction.West => Powered switch {
                        true => 19554,
                        false => 19555,
                    },
                    Direction.East => Powered switch {
                        true => 19556,
                        false => 19557,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(AttachmentValue), AttachmentValue, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19526 => new BellBlock(Identifier, Attachment.Floor, Direction.North, true),
            19527 => new BellBlock(Identifier, Attachment.Floor, Direction.North, false),
            19528 => new BellBlock(Identifier, Attachment.Floor, Direction.South, true),
            19529 => new BellBlock(Identifier, Attachment.Floor, Direction.South, false),
            19530 => new BellBlock(Identifier, Attachment.Floor, Direction.West, true),
            19531 => new BellBlock(Identifier, Attachment.Floor, Direction.West, false),
            19532 => new BellBlock(Identifier, Attachment.Floor, Direction.East, true),
            19533 => new BellBlock(Identifier, Attachment.Floor, Direction.East, false),
            19534 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, true),
            19535 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, false),
            19536 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, true),
            19537 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, false),
            19538 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, true),
            19539 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, false),
            19540 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, true),
            19541 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, false),
            19542 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, true),
            19543 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, false),
            19544 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, true),
            19545 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, false),
            19546 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, true),
            19547 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, false),
            19548 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, true),
            19549 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, false),
            19550 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, true),
            19551 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, false),
            19552 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, true),
            19553 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, false),
            19554 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, true),
            19555 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, false),
            19556 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, true),
            19557 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, false),
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
