using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperGolemStatueBlock(Identifier Identifier, WaxedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:copper_golem_statue", "block.minecraft.waxed_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_copper_golem_statue", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 15, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29888];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


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
