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
                        true => 20805,
                        false => 20806,
                    },
                    Direction.South => Powered switch {
                        true => 20807,
                        false => 20808,
                    },
                    Direction.West => Powered switch {
                        true => 20809,
                        false => 20810,
                    },
                    Direction.East => Powered switch {
                        true => 20811,
                        false => 20812,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20813,
                        false => 20814,
                    },
                    Direction.South => Powered switch {
                        true => 20815,
                        false => 20816,
                    },
                    Direction.West => Powered switch {
                        true => 20817,
                        false => 20818,
                    },
                    Direction.East => Powered switch {
                        true => 20819,
                        false => 20820,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20821,
                        false => 20822,
                    },
                    Direction.South => Powered switch {
                        true => 20823,
                        false => 20824,
                    },
                    Direction.West => Powered switch {
                        true => 20825,
                        false => 20826,
                    },
                    Direction.East => Powered switch {
                        true => 20827,
                        false => 20828,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20829,
                        false => 20830,
                    },
                    Direction.South => Powered switch {
                        true => 20831,
                        false => 20832,
                    },
                    Direction.West => Powered switch {
                        true => 20833,
                        false => 20834,
                    },
                    Direction.East => Powered switch {
                        true => 20835,
                        false => 20836,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(AttachmentValue), AttachmentValue, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20805 => new BellBlock(Identifier, Attachment.Floor, Direction.North, true),
            20806 => new BellBlock(Identifier, Attachment.Floor, Direction.North, false),
            20807 => new BellBlock(Identifier, Attachment.Floor, Direction.South, true),
            20808 => new BellBlock(Identifier, Attachment.Floor, Direction.South, false),
            20809 => new BellBlock(Identifier, Attachment.Floor, Direction.West, true),
            20810 => new BellBlock(Identifier, Attachment.Floor, Direction.West, false),
            20811 => new BellBlock(Identifier, Attachment.Floor, Direction.East, true),
            20812 => new BellBlock(Identifier, Attachment.Floor, Direction.East, false),
            20813 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, true),
            20814 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, false),
            20815 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, true),
            20816 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, false),
            20817 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, true),
            20818 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, false),
            20819 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, true),
            20820 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, false),
            20821 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, true),
            20822 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, false),
            20823 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, true),
            20824 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, false),
            20825 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, true),
            20826 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, false),
            20827 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, true),
            20828 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, false),
            20829 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, true),
            20830 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, false),
            20831 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, true),
            20832 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, false),
            20833 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, true),
            20834 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, false),
            20835 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, true),
            20836 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AttachmentValue = properties.Contains("attachment") ? AttachmentFromString(properties["attachment"].GetString()) : AttachmentValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attachment", new StringTag(AttachmentToName(AttachmentValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
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
