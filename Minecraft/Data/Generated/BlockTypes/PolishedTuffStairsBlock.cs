using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, PolishedTuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_tuff_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_tuff_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 43, "polished_tuff", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 23870];

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
                            true => 23870,
                            false => 23871,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23872,
                            false => 23873,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23874,
                            false => 23875,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23876,
                            false => 23877,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23878,
                            false => 23879,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23880,
                            false => 23881,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23882,
                            false => 23883,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23884,
                            false => 23885,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23886,
                            false => 23887,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23888,
                            false => 23889,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23890,
                            false => 23891,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23892,
                            false => 23893,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23894,
                            false => 23895,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23896,
                            false => 23897,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23898,
                            false => 23899,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23900,
                            false => 23901,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23902,
                            false => 23903,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23904,
                            false => 23905,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23906,
                            false => 23907,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23908,
                            false => 23909,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23910,
                            false => 23911,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23912,
                            false => 23913,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23914,
                            false => 23915,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23916,
                            false => 23917,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23918,
                            false => 23919,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23920,
                            false => 23921,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23922,
                            false => 23923,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23924,
                            false => 23925,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23926,
                            false => 23927,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23928,
                            false => 23929,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23930,
                            false => 23931,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23932,
                            false => 23933,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23934,
                            false => 23935,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23936,
                            false => 23937,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23938,
                            false => 23939,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23940,
                            false => 23941,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23942,
                            false => 23943,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23944,
                            false => 23945,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23946,
                            false => 23947,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23948,
                            false => 23949,
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
            23870 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23871 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23872 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23873 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23874 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23875 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23876 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23877 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23878 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23879 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23880 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23881 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23882 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23883 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23884 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23885 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            23886 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            23887 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            23888 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            23889 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            23890 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            23891 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            23892 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            23893 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            23894 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            23895 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            23896 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            23897 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            23898 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23899 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23900 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23901 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23902 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23903 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23904 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23905 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23906 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23907 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23908 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23909 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23910 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23911 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23912 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23913 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23914 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23915 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23916 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23917 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23918 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23919 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23920 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23921 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23922 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23923 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23924 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23925 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23926 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23927 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23928 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23929 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23930 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23931 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23932 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23933 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23934 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23935 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23936 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23937 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23938 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23939 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23940 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23941 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23942 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23943 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23944 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23945 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23946 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23947 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23948 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23949 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
