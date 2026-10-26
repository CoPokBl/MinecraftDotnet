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
public record RedNetherBrickStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.red_nether_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_nether_brick_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/red_nether_brick_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 35, "nether_bricks", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 19533];

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
                            true => 19533,
                            false => 19534,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19535,
                            false => 19536,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19537,
                            false => 19538,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19539,
                            false => 19540,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19541,
                            false => 19542,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19543,
                            false => 19544,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19545,
                            false => 19546,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19547,
                            false => 19548,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19549,
                            false => 19550,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19551,
                            false => 19552,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19553,
                            false => 19554,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19555,
                            false => 19556,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19557,
                            false => 19558,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19559,
                            false => 19560,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19561,
                            false => 19562,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19563,
                            false => 19564,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19565,
                            false => 19566,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19567,
                            false => 19568,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19569,
                            false => 19570,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19571,
                            false => 19572,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19573,
                            false => 19574,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19575,
                            false => 19576,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19577,
                            false => 19578,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19579,
                            false => 19580,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19581,
                            false => 19582,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19583,
                            false => 19584,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19585,
                            false => 19586,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19587,
                            false => 19588,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19589,
                            false => 19590,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19591,
                            false => 19592,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19593,
                            false => 19594,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19595,
                            false => 19596,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19597,
                            false => 19598,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19599,
                            false => 19600,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19601,
                            false => 19602,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19603,
                            false => 19604,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19605,
                            false => 19606,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19607,
                            false => 19608,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19609,
                            false => 19610,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19611,
                            false => 19612,
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
            19533 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            19534 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            19535 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            19536 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            19537 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            19538 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            19539 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            19540 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            19541 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            19542 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            19543 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            19544 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            19545 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            19546 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            19547 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            19548 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            19549 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            19550 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            19551 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            19552 => new RedNetherBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            19553 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            19554 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            19555 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            19556 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            19557 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            19558 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            19559 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            19560 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            19561 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            19562 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            19563 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            19564 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            19565 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            19566 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            19567 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            19568 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            19569 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            19570 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            19571 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            19572 => new RedNetherBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            19573 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            19574 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            19575 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            19576 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            19577 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            19578 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            19579 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            19580 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            19581 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            19582 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            19583 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            19584 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            19585 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            19586 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            19587 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            19588 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            19589 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            19590 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            19591 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            19592 => new RedNetherBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            19593 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            19594 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            19595 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            19596 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            19597 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            19598 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            19599 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            19600 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            19601 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            19602 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            19603 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            19604 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            19605 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            19606 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            19607 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            19608 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            19609 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            19610 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            19611 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            19612 => new RedNetherBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
