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
public record ExposedCopperGolemStatueBlock(Identifier Identifier, ExposedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_golem_statue", "block.minecraft.exposed_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:exposed_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/exposed_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 44, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29792];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
