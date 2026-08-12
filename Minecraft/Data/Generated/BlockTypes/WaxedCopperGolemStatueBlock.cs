using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperGolemStatueBlock(Identifier Identifier, WaxedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_golem_statue";
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
    public Identifier? Item => "minecraft:waxed_copper_golem_statue";
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
    public string TranslationKey => "block.minecraft.waxed_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29888,
                        false => 29889,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29890,
                        false => 29891,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29892,
                        false => 29893,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29894,
                        false => 29895,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29896,
                        false => 29897,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29898,
                        false => 29899,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29900,
                        false => 29901,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29902,
                        false => 29903,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29904,
                        false => 29905,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29906,
                        false => 29907,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29908,
                        false => 29909,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29910,
                        false => 29911,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29912,
                        false => 29913,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29914,
                        false => 29915,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29916,
                        false => 29917,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29918,
                        false => 29919,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29888 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29889 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29890 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29891 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29892 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29893 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29894 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29895 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29896 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29897 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29898 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29899 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29900 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29901 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29902 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29903 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29904 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29905 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29906 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29907 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29908 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29909 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29910 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29911 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29912 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29913 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29914 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29915 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29916 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29917 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29918 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29919 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
