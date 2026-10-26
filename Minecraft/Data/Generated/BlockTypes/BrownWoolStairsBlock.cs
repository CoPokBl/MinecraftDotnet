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
public record BrownWoolStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.brown_wool_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:brown_wool_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/brown_wool_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 26, "wool", NoteBlockInstrument.Guitar, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 3385];

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
                            true => 3385,
                            false => 3386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3387,
                            false => 3388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3389,
                            false => 3390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3391,
                            false => 3392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3393,
                            false => 3394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3395,
                            false => 3396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3397,
                            false => 3398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3399,
                            false => 3400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3401,
                            false => 3402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3403,
                            false => 3404,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3405,
                            false => 3406,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3407,
                            false => 3408,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3409,
                            false => 3410,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3411,
                            false => 3412,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3413,
                            false => 3414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3415,
                            false => 3416,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3417,
                            false => 3418,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3419,
                            false => 3420,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3421,
                            false => 3422,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3423,
                            false => 3424,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3425,
                            false => 3426,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3427,
                            false => 3428,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3429,
                            false => 3430,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3431,
                            false => 3432,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3433,
                            false => 3434,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3435,
                            false => 3436,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3437,
                            false => 3438,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3439,
                            false => 3440,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3441,
                            false => 3442,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3443,
                            false => 3444,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3445,
                            false => 3446,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3447,
                            false => 3448,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3449,
                            false => 3450,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3451,
                            false => 3452,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3453,
                            false => 3454,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3455,
                            false => 3456,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3457,
                            false => 3458,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3459,
                            false => 3460,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3461,
                            false => 3462,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3463,
                            false => 3464,
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
            3385 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            3386 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            3387 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            3388 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            3389 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            3390 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            3391 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            3392 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            3393 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            3394 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            3395 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            3396 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            3397 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            3398 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            3399 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            3400 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            3401 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            3402 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            3403 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            3404 => new BrownWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            3405 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            3406 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            3407 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            3408 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            3409 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            3410 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            3411 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            3412 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            3413 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            3414 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            3415 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            3416 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            3417 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            3418 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            3419 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            3420 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            3421 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            3422 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            3423 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            3424 => new BrownWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            3425 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            3426 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            3427 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            3428 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            3429 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            3430 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            3431 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            3432 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            3433 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            3434 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            3435 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            3436 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            3437 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            3438 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            3439 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            3440 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            3441 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            3442 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            3443 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            3444 => new BrownWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            3445 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            3446 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            3447 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            3448 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            3449 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            3450 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            3451 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            3452 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            3453 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            3454 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            3455 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            3456 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            3457 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            3458 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            3459 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            3460 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            3461 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            3462 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            3463 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            3464 => new BrownWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
