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
public record WeatheredCutCopperStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.weathered_cut_copper_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_cut_copper_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/weathered_cut_copper_stairs");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 56, "copper", NoteBlockInstrument.TrumpetWeathered, false, true, true, false, false, false, false, true, false, false, true, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 31325];

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
                            true => 31325,
                            false => 31326,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31327,
                            false => 31328,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31329,
                            false => 31330,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31331,
                            false => 31332,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31333,
                            false => 31334,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31335,
                            false => 31336,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31337,
                            false => 31338,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31339,
                            false => 31340,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31341,
                            false => 31342,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31343,
                            false => 31344,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31345,
                            false => 31346,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31347,
                            false => 31348,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31349,
                            false => 31350,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31351,
                            false => 31352,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31353,
                            false => 31354,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31355,
                            false => 31356,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31357,
                            false => 31358,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31359,
                            false => 31360,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31361,
                            false => 31362,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31363,
                            false => 31364,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31365,
                            false => 31366,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31367,
                            false => 31368,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31369,
                            false => 31370,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31371,
                            false => 31372,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31373,
                            false => 31374,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31375,
                            false => 31376,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31377,
                            false => 31378,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31379,
                            false => 31380,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31381,
                            false => 31382,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31383,
                            false => 31384,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31385,
                            false => 31386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31387,
                            false => 31388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31389,
                            false => 31390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31391,
                            false => 31392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31393,
                            false => 31394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31395,
                            false => 31396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31397,
                            false => 31398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31399,
                            false => 31400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31401,
                            false => 31402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31403,
                            false => 31404,
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
            31325 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            31326 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            31327 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            31328 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            31329 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            31330 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            31331 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            31332 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            31333 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            31334 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            31335 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            31336 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            31337 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            31338 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            31339 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            31340 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            31341 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            31342 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            31343 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            31344 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            31345 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            31346 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            31347 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            31348 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            31349 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            31350 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            31351 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            31352 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            31353 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            31354 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            31355 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            31356 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            31357 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            31358 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            31359 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            31360 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            31361 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            31362 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            31363 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            31364 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            31365 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            31366 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            31367 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            31368 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            31369 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            31370 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            31371 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            31372 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            31373 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            31374 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            31375 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            31376 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            31377 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            31378 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            31379 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            31380 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            31381 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            31382 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            31383 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            31384 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            31385 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            31386 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            31387 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            31388 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            31389 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            31390 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            31391 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            31392 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            31393 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            31394 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            31395 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            31396 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            31397 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            31398 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            31399 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            31400 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            31401 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            31402 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            31403 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            31404 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
