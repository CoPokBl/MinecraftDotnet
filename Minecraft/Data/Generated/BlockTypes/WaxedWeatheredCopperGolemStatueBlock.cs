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
public record WaxedWeatheredCopperGolemStatueBlock(Identifier Identifier, WaxedWeatheredCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:copper_golem_statue", "block.minecraft.waxed_weathered_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_weathered_copper_golem_statue", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 56, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29952];

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
                        true => 29952,
                        false => 29953,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29954,
                        false => 29955,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29956,
                        false => 29957,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29958,
                        false => 29959,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29960,
                        false => 29961,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29962,
                        false => 29963,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29964,
                        false => 29965,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29966,
                        false => 29967,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29968,
                        false => 29969,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29970,
                        false => 29971,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29972,
                        false => 29973,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29974,
                        false => 29975,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29976,
                        false => 29977,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29978,
                        false => 29979,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29980,
                        false => 29981,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29982,
                        false => 29983,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29952 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29953 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29954 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29955 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29956 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29957 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29958 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29959 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29960 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29961 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29962 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29963 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29964 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29965 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29966 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29967 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29968 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29969 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29970 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29971 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29972 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29973 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29974 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29975 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29976 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29977 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29978 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29979 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29980 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29981 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29982 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29983 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
