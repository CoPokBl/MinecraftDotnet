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
public record GrayWoolStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.gray_wool_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:gray_wool_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/gray_wool_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 21, "wool", NoteBlockInstrument.Guitar, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 2985];

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
                            true => 2985,
                            false => 2986,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2987,
                            false => 2988,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2989,
                            false => 2990,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2991,
                            false => 2992,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2993,
                            false => 2994,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2995,
                            false => 2996,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2997,
                            false => 2998,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2999,
                            false => 3000,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3001,
                            false => 3002,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3003,
                            false => 3004,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3005,
                            false => 3006,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3007,
                            false => 3008,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3009,
                            false => 3010,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3011,
                            false => 3012,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3013,
                            false => 3014,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3015,
                            false => 3016,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3017,
                            false => 3018,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3019,
                            false => 3020,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3021,
                            false => 3022,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3023,
                            false => 3024,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3025,
                            false => 3026,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3027,
                            false => 3028,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3029,
                            false => 3030,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3031,
                            false => 3032,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3033,
                            false => 3034,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3035,
                            false => 3036,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3037,
                            false => 3038,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3039,
                            false => 3040,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3041,
                            false => 3042,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3043,
                            false => 3044,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3045,
                            false => 3046,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3047,
                            false => 3048,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3049,
                            false => 3050,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3051,
                            false => 3052,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3053,
                            false => 3054,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3055,
                            false => 3056,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3057,
                            false => 3058,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3059,
                            false => 3060,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3061,
                            false => 3062,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3063,
                            false => 3064,
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
            2985 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            2986 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            2987 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            2988 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            2989 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            2990 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            2991 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            2992 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            2993 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            2994 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            2995 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            2996 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            2997 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            2998 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            2999 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            3000 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            3001 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            3002 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            3003 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            3004 => new GrayWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            3005 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            3006 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            3007 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            3008 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            3009 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            3010 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            3011 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            3012 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            3013 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            3014 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            3015 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            3016 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            3017 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            3018 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            3019 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            3020 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            3021 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            3022 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            3023 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            3024 => new GrayWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            3025 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            3026 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            3027 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            3028 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            3029 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            3030 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            3031 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            3032 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            3033 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            3034 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            3035 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            3036 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            3037 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            3038 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            3039 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            3040 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            3041 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            3042 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            3043 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            3044 => new GrayWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            3045 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            3046 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            3047 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            3048 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            3049 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            3050 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            3051 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            3052 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            3053 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            3054 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            3055 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            3056 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            3057 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            3058 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            3059 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            3060 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            3061 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            3062 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            3063 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            3064 => new GrayWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
