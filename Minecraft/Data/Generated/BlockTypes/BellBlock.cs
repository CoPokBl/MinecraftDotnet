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
    public int ProtocolId => 846;
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
                        true => 20603,
                        false => 20604,
                    },
                    Direction.South => Powered switch {
                        true => 20605,
                        false => 20606,
                    },
                    Direction.West => Powered switch {
                        true => 20607,
                        false => 20608,
                    },
                    Direction.East => Powered switch {
                        true => 20609,
                        false => 20610,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20611,
                        false => 20612,
                    },
                    Direction.South => Powered switch {
                        true => 20613,
                        false => 20614,
                    },
                    Direction.West => Powered switch {
                        true => 20615,
                        false => 20616,
                    },
                    Direction.East => Powered switch {
                        true => 20617,
                        false => 20618,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20619,
                        false => 20620,
                    },
                    Direction.South => Powered switch {
                        true => 20621,
                        false => 20622,
                    },
                    Direction.West => Powered switch {
                        true => 20623,
                        false => 20624,
                    },
                    Direction.East => Powered switch {
                        true => 20625,
                        false => 20626,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20627,
                        false => 20628,
                    },
                    Direction.South => Powered switch {
                        true => 20629,
                        false => 20630,
                    },
                    Direction.West => Powered switch {
                        true => 20631,
                        false => 20632,
                    },
                    Direction.East => Powered switch {
                        true => 20633,
                        false => 20634,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(AttachmentValue), AttachmentValue, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20603 => new BellBlock(Identifier, Attachment.Floor, Direction.North, true),
            20604 => new BellBlock(Identifier, Attachment.Floor, Direction.North, false),
            20605 => new BellBlock(Identifier, Attachment.Floor, Direction.South, true),
            20606 => new BellBlock(Identifier, Attachment.Floor, Direction.South, false),
            20607 => new BellBlock(Identifier, Attachment.Floor, Direction.West, true),
            20608 => new BellBlock(Identifier, Attachment.Floor, Direction.West, false),
            20609 => new BellBlock(Identifier, Attachment.Floor, Direction.East, true),
            20610 => new BellBlock(Identifier, Attachment.Floor, Direction.East, false),
            20611 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, true),
            20612 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, false),
            20613 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, true),
            20614 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, false),
            20615 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, true),
            20616 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, false),
            20617 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, true),
            20618 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, false),
            20619 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, true),
            20620 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, false),
            20621 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, true),
            20622 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, false),
            20623 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, true),
            20624 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, false),
            20625 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, true),
            20626 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, false),
            20627 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, true),
            20628 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, false),
            20629 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, true),
            20630 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, false),
            20631 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, true),
            20632 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, false),
            20633 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, true),
            20634 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AttachmentValue = properties.ChildrenMap.ContainsKey("attachment") ? AttachmentFromString(properties["attachment"].GetString()) : AttachmentValue,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("attachment", AttachmentToName(AttachmentValue)),
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
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

    public static string AttachmentToName(Attachment value) {
        return value switch {
            Attachment.Floor => "floor",
            Attachment.Ceiling => "ceiling",
            Attachment.SingleWall => "single_wall",
            Attachment.DoubleWall => "double_wall",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Attachment value.")
        };
    }
}
