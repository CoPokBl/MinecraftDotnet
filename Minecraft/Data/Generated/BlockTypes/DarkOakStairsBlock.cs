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
public record DarkOakStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 26, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91, SupportShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92, SupportShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93, SupportShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94, SupportShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95, SupportShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96, SupportShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97, SupportShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98, SupportShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99, SupportShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100, SupportShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101, SupportShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102, SupportShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103, SupportShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104, SupportShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105, SupportShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106, SupportShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107, SupportShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108, SupportShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109, SupportShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110, SupportShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111, SupportShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, OcclusionShape = BlockShapes.S112, VisualShape = BlockShapes.S112, SupportShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, OcclusionShape = BlockShapes.S113, VisualShape = BlockShapes.S113, SupportShape = BlockShapes.S113 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 13899];

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
                            true => 13899,
                            false => 13900,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13901,
                            false => 13902,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13903,
                            false => 13904,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13905,
                            false => 13906,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13907,
                            false => 13908,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13909,
                            false => 13910,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13911,
                            false => 13912,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13913,
                            false => 13914,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13915,
                            false => 13916,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13917,
                            false => 13918,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13919,
                            false => 13920,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13921,
                            false => 13922,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13923,
                            false => 13924,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13925,
                            false => 13926,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13927,
                            false => 13928,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13929,
                            false => 13930,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13931,
                            false => 13932,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13933,
                            false => 13934,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13935,
                            false => 13936,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13937,
                            false => 13938,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13939,
                            false => 13940,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13941,
                            false => 13942,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13943,
                            false => 13944,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13945,
                            false => 13946,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13947,
                            false => 13948,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13949,
                            false => 13950,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13951,
                            false => 13952,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13953,
                            false => 13954,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13955,
                            false => 13956,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13957,
                            false => 13958,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13959,
                            false => 13960,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13961,
                            false => 13962,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13963,
                            false => 13964,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13965,
                            false => 13966,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13967,
                            false => 13968,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13969,
                            false => 13970,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13971,
                            false => 13972,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13973,
                            false => 13974,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13975,
                            false => 13976,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13977,
                            false => 13978,
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
            13899 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            13900 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            13901 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            13902 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            13903 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            13904 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            13905 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            13906 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            13907 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            13908 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            13909 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            13910 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            13911 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            13912 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            13913 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            13914 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            13915 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            13916 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            13917 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            13918 => new DarkOakStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            13919 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            13920 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            13921 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            13922 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            13923 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            13924 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            13925 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            13926 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            13927 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            13928 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            13929 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            13930 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            13931 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            13932 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            13933 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            13934 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            13935 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            13936 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            13937 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            13938 => new DarkOakStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            13939 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            13940 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            13941 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            13942 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            13943 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            13944 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            13945 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            13946 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            13947 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            13948 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            13949 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            13950 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            13951 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            13952 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            13953 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            13954 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            13955 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            13956 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            13957 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            13958 => new DarkOakStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            13959 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            13960 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            13961 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            13962 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            13963 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            13964 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            13965 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            13966 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            13967 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            13968 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            13969 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            13970 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            13971 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            13972 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            13973 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            13974 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            13975 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            13976 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            13977 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            13978 => new DarkOakStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
