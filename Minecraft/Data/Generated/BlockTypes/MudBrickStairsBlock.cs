using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MudBrickStairsBlock(Identifier Identifier, Direction Facing, MudBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.mud_brick_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mud_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 44, "mud_bricks", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 8838];

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
                            true => 8838,
                            false => 8839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8840,
                            false => 8841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8842,
                            false => 8843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8844,
                            false => 8845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8846,
                            false => 8847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8848,
                            false => 8849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8850,
                            false => 8851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8852,
                            false => 8853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8854,
                            false => 8855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8856,
                            false => 8857,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8858,
                            false => 8859,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8860,
                            false => 8861,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8862,
                            false => 8863,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8864,
                            false => 8865,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8866,
                            false => 8867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8868,
                            false => 8869,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8870,
                            false => 8871,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8872,
                            false => 8873,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8874,
                            false => 8875,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8876,
                            false => 8877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8878,
                            false => 8879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8880,
                            false => 8881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8882,
                            false => 8883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8884,
                            false => 8885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8886,
                            false => 8887,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8888,
                            false => 8889,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8890,
                            false => 8891,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8892,
                            false => 8893,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8894,
                            false => 8895,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8896,
                            false => 8897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8898,
                            false => 8899,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8900,
                            false => 8901,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8902,
                            false => 8903,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8904,
                            false => 8905,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8906,
                            false => 8907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8908,
                            false => 8909,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8910,
                            false => 8911,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8912,
                            false => 8913,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8914,
                            false => 8915,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8916,
                            false => 8917,
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
            8838 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8839 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8840 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8841 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8842 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8843 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8844 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8845 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8846 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8847 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8848 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8849 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8850 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8851 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8852 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8853 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8854 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8855 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8856 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8857 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8858 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8859 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8860 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8861 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8862 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8863 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8864 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8865 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8866 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8867 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8868 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8869 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8870 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8871 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8872 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8873 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8874 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8875 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8876 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8877 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8878 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8879 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8880 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8881 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8882 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8883 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8884 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8885 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8886 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8887 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8888 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8889 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8890 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8891 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8892 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8893 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8894 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8895 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8896 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8897 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8898 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8899 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8900 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8901 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8902 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8903 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8904 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8905 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8906 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8907 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8908 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8909 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8910 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8911 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8912 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8913 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8914 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8915 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8916 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8917 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
