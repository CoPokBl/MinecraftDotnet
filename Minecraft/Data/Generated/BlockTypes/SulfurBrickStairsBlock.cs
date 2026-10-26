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
public record SulfurBrickStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.sulfur_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sulfur_brick_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/sulfur_brick_stairs");
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

    public BlockStateInfo StateInfo => States[StateId - 28878];

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
                            true => 28878,
                            false => 28879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28880,
                            false => 28881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28882,
                            false => 28883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28884,
                            false => 28885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28886,
                            false => 28887,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28888,
                            false => 28889,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28890,
                            false => 28891,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28892,
                            false => 28893,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28894,
                            false => 28895,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28896,
                            false => 28897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28898,
                            false => 28899,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28900,
                            false => 28901,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28902,
                            false => 28903,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28904,
                            false => 28905,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28906,
                            false => 28907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28908,
                            false => 28909,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28910,
                            false => 28911,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28912,
                            false => 28913,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28914,
                            false => 28915,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28916,
                            false => 28917,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28918,
                            false => 28919,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28920,
                            false => 28921,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28922,
                            false => 28923,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28924,
                            false => 28925,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28926,
                            false => 28927,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28928,
                            false => 28929,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28930,
                            false => 28931,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28932,
                            false => 28933,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28934,
                            false => 28935,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28936,
                            false => 28937,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28938,
                            false => 28939,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28940,
                            false => 28941,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28942,
                            false => 28943,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28944,
                            false => 28945,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28946,
                            false => 28947,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28948,
                            false => 28949,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28950,
                            false => 28951,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28952,
                            false => 28953,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28954,
                            false => 28955,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28956,
                            false => 28957,
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
            28878 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            28879 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            28880 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            28881 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            28882 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            28883 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            28884 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            28885 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            28886 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            28887 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            28888 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            28889 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            28890 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            28891 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            28892 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            28893 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            28894 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            28895 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            28896 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            28897 => new SulfurBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            28898 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            28899 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            28900 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            28901 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            28902 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            28903 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            28904 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            28905 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            28906 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            28907 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            28908 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            28909 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            28910 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            28911 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            28912 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            28913 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            28914 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            28915 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            28916 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            28917 => new SulfurBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            28918 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            28919 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            28920 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            28921 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            28922 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            28923 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            28924 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            28925 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            28926 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            28927 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            28928 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            28929 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            28930 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            28931 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            28932 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            28933 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            28934 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            28935 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            28936 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            28937 => new SulfurBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            28938 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            28939 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            28940 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            28941 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            28942 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            28943 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            28944 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            28945 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            28946 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            28947 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            28948 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            28949 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            28950 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            28951 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            28952 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            28953 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            28954 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            28955 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            28956 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            28957 => new SulfurBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
