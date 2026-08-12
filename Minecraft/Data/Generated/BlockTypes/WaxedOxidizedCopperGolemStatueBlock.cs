using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperGolemStatueBlock(Identifier Identifier, WaxedOxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_golem_statue";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29984,
                        false => 29985,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29986,
                        false => 29987,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29988,
                        false => 29989,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29990,
                        false => 29991,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29992,
                        false => 29993,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29994,
                        false => 29995,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29996,
                        false => 29997,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29998,
                        false => 29999,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 30000,
                        false => 30001,
                    },
                    Direction.South => Waterlogged switch {
                        true => 30002,
                        false => 30003,
                    },
                    Direction.West => Waterlogged switch {
                        true => 30004,
                        false => 30005,
                    },
                    Direction.East => Waterlogged switch {
                        true => 30006,
                        false => 30007,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 30008,
                        false => 30009,
                    },
                    Direction.South => Waterlogged switch {
                        true => 30010,
                        false => 30011,
                    },
                    Direction.West => Waterlogged switch {
                        true => 30012,
                        false => 30013,
                    },
                    Direction.East => Waterlogged switch {
                        true => 30014,
                        false => 30015,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29984 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29985 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29986 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29987 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29988 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29989 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29990 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29991 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29992 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29993 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29994 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29995 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29996 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29997 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29998 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29999 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            30000 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            30001 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            30002 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            30003 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            30004 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            30005 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            30006 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            30007 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            30008 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            30009 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            30010 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            30011 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            30012 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            30013 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            30014 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            30015 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
