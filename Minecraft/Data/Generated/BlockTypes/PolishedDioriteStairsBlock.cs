using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDioriteStairsBlock(Identifier Identifier, Direction Facing, PolishedDioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_diorite_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_diorite_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 14, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 15536];

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
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15536,
                            false => 15537,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15538,
                            false => 15539,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15540,
                            false => 15541,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15542,
                            false => 15543,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15544,
                            false => 15545,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15546,
                            false => 15547,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15548,
                            false => 15549,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15550,
                            false => 15551,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15552,
                            false => 15553,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15554,
                            false => 15555,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15556,
                            false => 15557,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15558,
                            false => 15559,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15560,
                            false => 15561,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15562,
                            false => 15563,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15564,
                            false => 15565,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15566,
                            false => 15567,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15568,
                            false => 15569,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15570,
                            false => 15571,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15572,
                            false => 15573,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15574,
                            false => 15575,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15576,
                            false => 15577,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15578,
                            false => 15579,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15580,
                            false => 15581,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15582,
                            false => 15583,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15584,
                            false => 15585,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15586,
                            false => 15587,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15588,
                            false => 15589,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15590,
                            false => 15591,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15592,
                            false => 15593,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15594,
                            false => 15595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15596,
                            false => 15597,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15598,
                            false => 15599,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15600,
                            false => 15601,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15602,
                            false => 15603,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15604,
                            false => 15605,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15606,
                            false => 15607,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15608,
                            false => 15609,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15610,
                            false => 15611,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15612,
                            false => 15613,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15614,
                            false => 15615,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15536 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15537 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15538 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15539 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15540 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15541 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15542 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15543 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15544 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15545 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15546 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15547 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15548 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15549 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15550 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15551 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15552 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15553 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15554 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15555 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15556 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15557 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15558 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15559 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15560 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15561 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15562 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15563 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15564 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15565 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15566 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15567 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15568 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15569 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15570 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15571 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15572 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15573 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15574 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15575 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15576 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15577 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15578 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15579 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15580 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15581 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15582 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15583 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15584 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15585 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15586 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15587 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15588 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15589 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15590 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15591 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15592 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15593 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15594 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15595 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15596 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15597 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15598 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15599 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15600 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15601 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15602 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15603 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15604 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15605 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15606 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15607 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15608 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15609 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15610 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15611 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15612 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15613 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15614 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15615 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
