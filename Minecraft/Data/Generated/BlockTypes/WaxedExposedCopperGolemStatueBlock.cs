using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperGolemStatueBlock(Identifier Identifier, WaxedExposedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:copper_golem_statue", "block.minecraft.waxed_exposed_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_exposed_copper_golem_statue", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 44, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S505, BlockShapes.S505, BlockShapes.S1, BlockShapes.S1, BlockShapes.S505);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29920];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29920,
                        false => 29921,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29922,
                        false => 29923,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29924,
                        false => 29925,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29926,
                        false => 29927,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29928,
                        false => 29929,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29930,
                        false => 29931,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29932,
                        false => 29933,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29934,
                        false => 29935,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29936,
                        false => 29937,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29938,
                        false => 29939,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29940,
                        false => 29941,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29942,
                        false => 29943,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29944,
                        false => 29945,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29946,
                        false => 29947,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29948,
                        false => 29949,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29950,
                        false => 29951,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29920 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29921 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29922 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29923 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29924 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29925 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29926 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29927 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29928 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29929 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29930 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29931 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29932 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29933 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29934 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29935 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            29936 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            29937 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            29938 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            29939 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            29940 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            29941 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            29942 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            29943 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            29944 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            29945 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            29946 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            29947 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            29948 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            29949 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            29950 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            29951 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
