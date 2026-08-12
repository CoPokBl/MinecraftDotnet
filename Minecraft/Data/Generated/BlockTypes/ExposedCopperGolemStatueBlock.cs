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
                        true => 29792,
                        false => 29793,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29794,
                        false => 29795,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29796,
                        false => 29797,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29798,
                        false => 29799,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29800,
                        false => 29801,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29802,
                        false => 29803,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29804,
                        false => 29805,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29806,
                        false => 29807,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29808,
                        false => 29809,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29810,
                        false => 29811,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29812,
                        false => 29813,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29814,
                        false => 29815,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29816,
                        false => 29817,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29818,
                        false => 29819,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29820,
                        false => 29821,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29822,
                        false => 29823,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29792 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29793 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29794 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29795 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29796 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29797 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29798 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29799 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29800 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29801 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29802 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29803 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29804 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29805 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29806 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29807 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29808 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29809 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29810 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29811 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29812 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29813 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29814 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29815 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29816 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29817 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29818 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29819 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29820 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29821 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29822 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29823 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
