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
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_golem_statue", "block.minecraft.weathered_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:weathered_copper_golem_statue", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 56, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S505, BlockShapes.S505, BlockShapes.S1, BlockShapes.S1, BlockShapes.S505);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29824];

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
