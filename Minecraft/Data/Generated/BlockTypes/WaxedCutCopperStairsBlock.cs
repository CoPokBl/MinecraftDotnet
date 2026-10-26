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
public record WaxedCutCopperStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_cut_copper_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_cut_copper_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_cut_copper_stairs");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Trumpet, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 31485];

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
                            true => 31485,
                            false => 31486,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31487,
                            false => 31488,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31489,
                            false => 31490,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31491,
                            false => 31492,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31493,
                            false => 31494,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31495,
                            false => 31496,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31497,
                            false => 31498,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31499,
                            false => 31500,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31501,
                            false => 31502,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31503,
                            false => 31504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31505,
                            false => 31506,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31507,
                            false => 31508,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31509,
                            false => 31510,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31511,
                            false => 31512,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31513,
                            false => 31514,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31515,
                            false => 31516,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31517,
                            false => 31518,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31519,
                            false => 31520,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31521,
                            false => 31522,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31523,
                            false => 31524,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31525,
                            false => 31526,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31527,
                            false => 31528,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31529,
                            false => 31530,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31531,
                            false => 31532,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31533,
                            false => 31534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31535,
                            false => 31536,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31537,
                            false => 31538,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31539,
                            false => 31540,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31541,
                            false => 31542,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31543,
                            false => 31544,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31545,
                            false => 31546,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31547,
                            false => 31548,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31549,
                            false => 31550,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31551,
                            false => 31552,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31553,
                            false => 31554,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31555,
                            false => 31556,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31557,
                            false => 31558,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31559,
                            false => 31560,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31561,
                            false => 31562,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31563,
                            false => 31564,
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
            31485 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            31486 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            31487 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            31488 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            31489 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            31490 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            31491 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            31492 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            31493 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            31494 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            31495 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            31496 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            31497 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            31498 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            31499 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            31500 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            31501 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            31502 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            31503 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            31504 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            31505 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            31506 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            31507 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            31508 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            31509 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            31510 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            31511 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            31512 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            31513 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            31514 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            31515 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            31516 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            31517 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            31518 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            31519 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            31520 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            31521 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            31522 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            31523 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            31524 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            31525 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            31526 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            31527 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            31528 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            31529 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            31530 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            31531 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            31532 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            31533 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            31534 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            31535 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            31536 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            31537 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            31538 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            31539 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            31540 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            31541 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            31542 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            31543 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            31544 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            31545 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            31546 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            31547 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            31548 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            31549 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            31550 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            31551 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            31552 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            31553 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            31554 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            31555 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            31556 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            31557 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            31558 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            31559 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            31560 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            31561 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            31562 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            31563 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            31564 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
