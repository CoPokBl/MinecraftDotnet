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
public record CyanWoolStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cyan_wool_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cyan_wool_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cyan_wool_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 23, "wool", NoteBlockInstrument.Guitar, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 3145];

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
                            true => 3145,
                            false => 3146,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3147,
                            false => 3148,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3149,
                            false => 3150,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3151,
                            false => 3152,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3153,
                            false => 3154,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3155,
                            false => 3156,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3157,
                            false => 3158,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3159,
                            false => 3160,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3161,
                            false => 3162,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3163,
                            false => 3164,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3165,
                            false => 3166,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3167,
                            false => 3168,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3169,
                            false => 3170,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3171,
                            false => 3172,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3173,
                            false => 3174,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3175,
                            false => 3176,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3177,
                            false => 3178,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3179,
                            false => 3180,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3181,
                            false => 3182,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3183,
                            false => 3184,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3185,
                            false => 3186,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3187,
                            false => 3188,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3189,
                            false => 3190,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3191,
                            false => 3192,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3193,
                            false => 3194,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3195,
                            false => 3196,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3197,
                            false => 3198,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3199,
                            false => 3200,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3201,
                            false => 3202,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3203,
                            false => 3204,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3205,
                            false => 3206,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3207,
                            false => 3208,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3209,
                            false => 3210,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3211,
                            false => 3212,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3213,
                            false => 3214,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3215,
                            false => 3216,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3217,
                            false => 3218,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3219,
                            false => 3220,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3221,
                            false => 3222,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3223,
                            false => 3224,
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
            3145 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            3146 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            3147 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            3148 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            3149 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            3150 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            3151 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            3152 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            3153 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            3154 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            3155 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            3156 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            3157 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            3158 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            3159 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            3160 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            3161 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            3162 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            3163 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            3164 => new CyanWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            3165 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            3166 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            3167 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            3168 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            3169 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            3170 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            3171 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            3172 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            3173 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            3174 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            3175 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            3176 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            3177 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            3178 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            3179 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            3180 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            3181 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            3182 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            3183 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            3184 => new CyanWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            3185 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            3186 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            3187 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            3188 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            3189 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            3190 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            3191 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            3192 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            3193 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            3194 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            3195 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            3196 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            3197 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            3198 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            3199 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            3200 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            3201 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            3202 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            3203 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            3204 => new CyanWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            3205 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            3206 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            3207 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            3208 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            3209 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            3210 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            3211 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            3212 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            3213 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            3214 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            3215 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            3216 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            3217 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            3218 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            3219 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            3220 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            3221 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            3222 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            3223 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            3224 => new CyanWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
