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
public record PolishedSulfurStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_sulfur_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_sulfur_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_sulfur_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 18, "sulfur", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 28467];

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
                            true => 28467,
                            false => 28468,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28469,
                            false => 28470,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28471,
                            false => 28472,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28473,
                            false => 28474,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28475,
                            false => 28476,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28477,
                            false => 28478,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28479,
                            false => 28480,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28481,
                            false => 28482,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28483,
                            false => 28484,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28485,
                            false => 28486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28487,
                            false => 28488,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28489,
                            false => 28490,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28491,
                            false => 28492,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28493,
                            false => 28494,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28495,
                            false => 28496,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28497,
                            false => 28498,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28499,
                            false => 28500,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28501,
                            false => 28502,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28503,
                            false => 28504,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28505,
                            false => 28506,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28507,
                            false => 28508,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28509,
                            false => 28510,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28511,
                            false => 28512,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28513,
                            false => 28514,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28515,
                            false => 28516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28517,
                            false => 28518,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28519,
                            false => 28520,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28521,
                            false => 28522,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28523,
                            false => 28524,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28525,
                            false => 28526,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28527,
                            false => 28528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28529,
                            false => 28530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28531,
                            false => 28532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28533,
                            false => 28534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28535,
                            false => 28536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28537,
                            false => 28538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28539,
                            false => 28540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28541,
                            false => 28542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28543,
                            false => 28544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28545,
                            false => 28546,
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
            28467 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            28468 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            28469 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            28470 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            28471 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            28472 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            28473 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            28474 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            28475 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            28476 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            28477 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            28478 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            28479 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            28480 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            28481 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            28482 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            28483 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            28484 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            28485 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            28486 => new PolishedSulfurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            28487 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            28488 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            28489 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            28490 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            28491 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            28492 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            28493 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            28494 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            28495 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            28496 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            28497 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            28498 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            28499 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            28500 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            28501 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            28502 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            28503 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            28504 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            28505 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            28506 => new PolishedSulfurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            28507 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            28508 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            28509 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            28510 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            28511 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            28512 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            28513 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            28514 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            28515 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            28516 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            28517 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            28518 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            28519 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            28520 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            28521 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            28522 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            28523 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            28524 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            28525 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            28526 => new PolishedSulfurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            28527 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            28528 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            28529 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            28530 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            28531 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            28532 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            28533 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            28534 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            28535 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            28536 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            28537 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            28538 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            28539 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            28540 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            28541 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            28542 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            28543 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            28544 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            28545 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            28546 => new PolishedSulfurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
