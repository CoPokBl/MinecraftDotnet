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
public record PolishedDioriteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_diorite_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_diorite_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_diorite_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 14, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 18893];

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
                            true => 18893,
                            false => 18894,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18895,
                            false => 18896,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18897,
                            false => 18898,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18899,
                            false => 18900,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18901,
                            false => 18902,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18903,
                            false => 18904,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18905,
                            false => 18906,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18907,
                            false => 18908,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18909,
                            false => 18910,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18911,
                            false => 18912,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18913,
                            false => 18914,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18915,
                            false => 18916,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18917,
                            false => 18918,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18919,
                            false => 18920,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18921,
                            false => 18922,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18923,
                            false => 18924,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18925,
                            false => 18926,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18927,
                            false => 18928,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18929,
                            false => 18930,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18931,
                            false => 18932,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18933,
                            false => 18934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18935,
                            false => 18936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18937,
                            false => 18938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18939,
                            false => 18940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18941,
                            false => 18942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18943,
                            false => 18944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18945,
                            false => 18946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18947,
                            false => 18948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18949,
                            false => 18950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18951,
                            false => 18952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18953,
                            false => 18954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18955,
                            false => 18956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18957,
                            false => 18958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18959,
                            false => 18960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18961,
                            false => 18962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 18963,
                            false => 18964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 18965,
                            false => 18966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 18967,
                            false => 18968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 18969,
                            false => 18970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 18971,
                            false => 18972,
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
            18893 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            18894 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            18895 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            18896 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            18897 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            18898 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            18899 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            18900 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            18901 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            18902 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            18903 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            18904 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            18905 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            18906 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            18907 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            18908 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            18909 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            18910 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            18911 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            18912 => new PolishedDioriteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            18913 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            18914 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            18915 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            18916 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            18917 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            18918 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            18919 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            18920 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            18921 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            18922 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            18923 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            18924 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            18925 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            18926 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            18927 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            18928 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            18929 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            18930 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            18931 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            18932 => new PolishedDioriteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            18933 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            18934 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            18935 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            18936 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            18937 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            18938 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            18939 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            18940 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            18941 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            18942 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            18943 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            18944 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            18945 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            18946 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            18947 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            18948 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            18949 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            18950 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            18951 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            18952 => new PolishedDioriteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            18953 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            18954 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            18955 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            18956 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            18957 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            18958 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            18959 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            18960 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            18961 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            18962 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            18963 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            18964 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            18965 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            18966 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            18967 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            18968 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            18969 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            18970 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            18971 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            18972 => new PolishedDioriteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
