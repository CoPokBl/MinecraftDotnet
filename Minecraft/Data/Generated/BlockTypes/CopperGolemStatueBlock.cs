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
public record CopperGolemStatueBlock(Identifier Identifier, CopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_golem_statue", "block.minecraft.copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:copper_golem_statue", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 15, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29760];

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
