using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackstoneStairsBlock(Identifier Identifier, Direction Facing, BlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.blackstone_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:blackstone_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 21832];

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
                            true => 21832,
                            false => 21833,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21834,
                            false => 21835,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21836,
                            false => 21837,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21838,
                            false => 21839,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21840,
                            false => 21841,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21842,
                            false => 21843,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21844,
                            false => 21845,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21846,
                            false => 21847,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21848,
                            false => 21849,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21850,
                            false => 21851,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21852,
                            false => 21853,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21854,
                            false => 21855,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21856,
                            false => 21857,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21858,
                            false => 21859,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21860,
                            false => 21861,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21862,
                            false => 21863,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21864,
                            false => 21865,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21866,
                            false => 21867,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21868,
                            false => 21869,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21870,
                            false => 21871,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21872,
                            false => 21873,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21874,
                            false => 21875,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21876,
                            false => 21877,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21878,
                            false => 21879,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21880,
                            false => 21881,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21882,
                            false => 21883,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21884,
                            false => 21885,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21886,
                            false => 21887,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21888,
                            false => 21889,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21890,
                            false => 21891,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21892,
                            false => 21893,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21894,
                            false => 21895,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21896,
                            false => 21897,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21898,
                            false => 21899,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21900,
                            false => 21901,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21902,
                            false => 21903,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21904,
                            false => 21905,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21906,
                            false => 21907,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21908,
                            false => 21909,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21910,
                            false => 21911,
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
            21832 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21833 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21834 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21835 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21836 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21837 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21838 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21839 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21840 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21841 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21842 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21843 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21844 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21845 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21846 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21847 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21848 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21849 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21850 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21851 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21852 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21853 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21854 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21855 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21856 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21857 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21858 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21859 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21860 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21861 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21862 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21863 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21864 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21865 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21866 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21867 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21868 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21869 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21870 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21871 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21872 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21873 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21874 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21875 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21876 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21877 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21878 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21879 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21880 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21881 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21882 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21883 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21884 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21885 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21886 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21887 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21888 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21889 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21890 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21891 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21892 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21893 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21894 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21895 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21896 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21897 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21898 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21899 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21900 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21901 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21902 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21903 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21904 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21905 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21906 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21907 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21908 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21909 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21910 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21911 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
