using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperGolemStatueBlock(Identifier Identifier, WeatheredCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:weathered_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29824,
                        false => 29825,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29826,
                        false => 29827,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29828,
                        false => 29829,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29830,
                        false => 29831,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29832,
                        false => 29833,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29834,
                        false => 29835,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29836,
                        false => 29837,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29838,
                        false => 29839,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29840,
                        false => 29841,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29842,
                        false => 29843,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29844,
                        false => 29845,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29846,
                        false => 29847,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29848,
                        false => 29849,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29850,
                        false => 29851,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29852,
                        false => 29853,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29854,
                        false => 29855,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29824 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29825 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29826 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29827 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29828 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29829 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29830 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29831 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29832 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29833 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29834 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29835 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29836 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29837 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29838 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29839 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29840 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29841 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29842 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29843 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29844 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29845 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29846 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29847 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29848 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29849 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29850 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29851 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29852 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29853 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29854 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29855 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
