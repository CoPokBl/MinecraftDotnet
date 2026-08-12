using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperGolemStatueBlock(Identifier Identifier, OxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:oxidized_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29856,
                        false => 29857,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29858,
                        false => 29859,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29860,
                        false => 29861,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29862,
                        false => 29863,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29864,
                        false => 29865,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29866,
                        false => 29867,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29868,
                        false => 29869,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29870,
                        false => 29871,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29872,
                        false => 29873,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29874,
                        false => 29875,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29876,
                        false => 29877,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29878,
                        false => 29879,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29880,
                        false => 29881,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29882,
                        false => 29883,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29884,
                        false => 29885,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29886,
                        false => 29887,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29856 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29857 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29858 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29859 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29860 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29861 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29862 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29863 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29864 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29865 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29866 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29867 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29868 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29869 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29870 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29871 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29872 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29873 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29874 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29875 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29876 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29877 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29878 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29879 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29880 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29881 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29882 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29883 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29884 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29885 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29886 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29887 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
