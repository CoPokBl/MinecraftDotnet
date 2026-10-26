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
public record DeepslateTileStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.deepslate_tile_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:deepslate_tile_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/deepslate_tile_stairs");
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 1, PushReaction.PushPull, 59, "deepslate_tiles", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 34599];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(TopBottom half) => this with { Half = half };

    public IBlock WithShape(StairShape shape) => this with { Shape = shape };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34599,
                            false => 34600,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34601,
                            false => 34602,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34603,
                            false => 34604,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34605,
                            false => 34606,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34607,
                            false => 34608,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34609,
                            false => 34610,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34611,
                            false => 34612,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34613,
                            false => 34614,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34615,
                            false => 34616,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34617,
                            false => 34618,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34619,
                            false => 34620,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34621,
                            false => 34622,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34623,
                            false => 34624,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34625,
                            false => 34626,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34627,
                            false => 34628,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34629,
                            false => 34630,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34631,
                            false => 34632,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34633,
                            false => 34634,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34635,
                            false => 34636,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34637,
                            false => 34638,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34639,
                            false => 34640,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34641,
                            false => 34642,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34643,
                            false => 34644,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34645,
                            false => 34646,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34647,
                            false => 34648,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34649,
                            false => 34650,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34651,
                            false => 34652,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34653,
                            false => 34654,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34655,
                            false => 34656,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34657,
                            false => 34658,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34659,
                            false => 34660,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34661,
                            false => 34662,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34663,
                            false => 34664,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34665,
                            false => 34666,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34667,
                            false => 34668,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 34669,
                            false => 34670,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 34671,
                            false => 34672,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 34673,
                            false => 34674,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 34675,
                            false => 34676,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 34677,
                            false => 34678,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            34599 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            34600 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            34601 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            34602 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            34603 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            34604 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            34605 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            34606 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            34607 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            34608 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            34609 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            34610 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            34611 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            34612 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            34613 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            34614 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            34615 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            34616 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            34617 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            34618 => new DeepslateTileStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            34619 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            34620 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            34621 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            34622 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            34623 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            34624 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            34625 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            34626 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            34627 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            34628 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            34629 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            34630 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            34631 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            34632 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            34633 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            34634 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            34635 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            34636 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            34637 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            34638 => new DeepslateTileStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            34639 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            34640 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            34641 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            34642 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            34643 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            34644 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            34645 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            34646 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            34647 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            34648 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            34649 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            34650 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            34651 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            34652 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            34653 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            34654 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            34655 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            34656 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            34657 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            34658 => new DeepslateTileStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            34659 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            34660 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            34661 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            34662 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            34663 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            34664 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            34665 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            34666 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            34667 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            34668 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            34669 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            34670 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            34671 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            34672 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            34673 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            34674 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            34675 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            34676 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            34677 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            34678 => new DeepslateTileStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
