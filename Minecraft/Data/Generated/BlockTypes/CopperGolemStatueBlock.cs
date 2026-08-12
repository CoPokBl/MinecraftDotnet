using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperGolemStatueBlock(Identifier Identifier, CopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_golem_statue";
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
    public Identifier? Item => "minecraft:copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29760,
                        false => 29761,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29762,
                        false => 29763,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29764,
                        false => 29765,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29766,
                        false => 29767,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29768,
                        false => 29769,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29770,
                        false => 29771,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29772,
                        false => 29773,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29774,
                        false => 29775,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29776,
                        false => 29777,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29778,
                        false => 29779,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29780,
                        false => 29781,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29782,
                        false => 29783,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29784,
                        false => 29785,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29786,
                        false => 29787,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29788,
                        false => 29789,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29790,
                        false => 29791,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29760 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29761 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29762 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29763 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29764 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29765 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29766 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29767 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29768 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29769 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29770 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29771 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29772 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29773 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29774 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29775 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29776 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29777 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29778 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29779 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29780 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29781 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29782 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29783 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29784 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29785 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29786 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29787 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29788 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29789 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29790 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29791 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CopperGolemPoseValue = properties.Contains("copper_golem_pose") ? CopperGolemPoseFromString(properties["copper_golem_pose"].GetString()) : CopperGolemPoseValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("copper_golem_pose", new StringTag(CopperGolemPoseToName(CopperGolemPoseValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
