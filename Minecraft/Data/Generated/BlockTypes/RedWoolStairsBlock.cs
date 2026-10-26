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
public record RedWoolStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.red_wool_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_wool_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/red_wool_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 28, "wool", NoteBlockInstrument.Guitar, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 3545];

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
                            true => 3545,
                            false => 3546,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3547,
                            false => 3548,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3549,
                            false => 3550,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3551,
                            false => 3552,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3553,
                            false => 3554,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3555,
                            false => 3556,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3557,
                            false => 3558,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3559,
                            false => 3560,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3561,
                            false => 3562,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3563,
                            false => 3564,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3565,
                            false => 3566,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3567,
                            false => 3568,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3569,
                            false => 3570,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3571,
                            false => 3572,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3573,
                            false => 3574,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3575,
                            false => 3576,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3577,
                            false => 3578,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3579,
                            false => 3580,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3581,
                            false => 3582,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3583,
                            false => 3584,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3585,
                            false => 3586,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3587,
                            false => 3588,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3589,
                            false => 3590,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3591,
                            false => 3592,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3593,
                            false => 3594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3595,
                            false => 3596,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3597,
                            false => 3598,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3599,
                            false => 3600,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3601,
                            false => 3602,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3603,
                            false => 3604,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3605,
                            false => 3606,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3607,
                            false => 3608,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3609,
                            false => 3610,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3611,
                            false => 3612,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3613,
                            false => 3614,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3615,
                            false => 3616,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3617,
                            false => 3618,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3619,
                            false => 3620,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3621,
                            false => 3622,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3623,
                            false => 3624,
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
            3545 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            3546 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            3547 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            3548 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            3549 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            3550 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            3551 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            3552 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            3553 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            3554 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            3555 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            3556 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            3557 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            3558 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            3559 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            3560 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            3561 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            3562 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            3563 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            3564 => new RedWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            3565 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            3566 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            3567 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            3568 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            3569 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            3570 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            3571 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            3572 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            3573 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            3574 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            3575 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            3576 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            3577 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            3578 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            3579 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            3580 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            3581 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            3582 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            3583 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            3584 => new RedWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            3585 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            3586 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            3587 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            3588 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            3589 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            3590 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            3591 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            3592 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            3593 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            3594 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            3595 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            3596 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            3597 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            3598 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            3599 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            3600 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            3601 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            3602 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            3603 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            3604 => new RedWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            3605 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            3606 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            3607 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            3608 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            3609 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            3610 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            3611 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            3612 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            3613 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            3614 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            3615 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            3616 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            3617 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            3618 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            3619 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            3620 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            3621 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            3622 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            3623 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            3624 => new RedWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
