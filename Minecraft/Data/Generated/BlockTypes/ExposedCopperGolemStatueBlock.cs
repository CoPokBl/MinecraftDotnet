using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperGolemStatueBlock(Identifier Identifier, ExposedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_golem_statue";
    public int ProtocolId => 1088;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper_golem_statue";
    public Identifier? BlockEntity => "minecraft:copper_golem_statue";
    public Identifier? Item => "minecraft:exposed_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27117,
                        false => 27118,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27119,
                        false => 27120,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27121,
                        false => 27122,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27123,
                        false => 27124,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27125,
                        false => 27126,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27127,
                        false => 27128,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27129,
                        false => 27130,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27131,
                        false => 27132,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27133,
                        false => 27134,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27135,
                        false => 27136,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27137,
                        false => 27138,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27139,
                        false => 27140,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27141,
                        false => 27142,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27143,
                        false => 27144,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27145,
                        false => 27146,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27147,
                        false => 27148,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27117 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27118 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27119 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27120 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27121 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27122 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27123 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27124 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27125 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27126 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27127 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27128 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27129 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27130 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27131 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27132 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27133 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27134 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27135 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27136 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27137 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27138 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27139 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27140 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27141 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27142 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27143 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27144 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27145 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27146 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27147 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27148 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CopperGolemPoseValue = properties.ChildrenMap.ContainsKey("copper_golem_pose") ? CopperGolemPoseFromString(properties["copper_golem_pose"].GetString()) : CopperGolemPoseValue,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("copper_golem_pose", CopperGolemPoseToName(CopperGolemPoseValue)),
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
    public enum CopperGolemPose {
        Standing,
        Sitting,
        Running,
        Star,
    }

    public static CopperGolemPose CopperGolemPoseFromString(string value) {
        return value switch {
            "standing" => CopperGolemPose.Standing,
            "sitting" => CopperGolemPose.Sitting,
            "running" => CopperGolemPose.Running,
            "star" => CopperGolemPose.Star,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for CopperGolemPose.")
        };
    }

    public static string CopperGolemPoseToName(CopperGolemPose value) {
        return value switch {
            CopperGolemPose.Standing => "standing",
            CopperGolemPose.Sitting => "sitting",
            CopperGolemPose.Running => "running",
            CopperGolemPose.Star => "star",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopperGolemPose value.")
        };
    }
}
