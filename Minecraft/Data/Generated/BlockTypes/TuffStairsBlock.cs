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
public record TuffStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.tuff_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:tuff_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 43, "tuff", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 23459];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
                            true => 23459,
                            false => 23460,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23461,
                            false => 23462,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23463,
                            false => 23464,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23465,
                            false => 23466,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23467,
                            false => 23468,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23469,
                            false => 23470,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23471,
                            false => 23472,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23473,
                            false => 23474,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23475,
                            false => 23476,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23477,
                            false => 23478,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23479,
                            false => 23480,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23481,
                            false => 23482,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23483,
                            false => 23484,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23485,
                            false => 23486,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23487,
                            false => 23488,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23489,
                            false => 23490,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23491,
                            false => 23492,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23493,
                            false => 23494,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23495,
                            false => 23496,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23497,
                            false => 23498,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23499,
                            false => 23500,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23501,
                            false => 23502,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23503,
                            false => 23504,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23505,
                            false => 23506,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23507,
                            false => 23508,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23509,
                            false => 23510,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23511,
                            false => 23512,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23513,
                            false => 23514,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23515,
                            false => 23516,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23517,
                            false => 23518,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23519,
                            false => 23520,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23521,
                            false => 23522,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23523,
                            false => 23524,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23525,
                            false => 23526,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23527,
                            false => 23528,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23529,
                            false => 23530,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23531,
                            false => 23532,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23533,
                            false => 23534,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23535,
                            false => 23536,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23537,
                            false => 23538,
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
            23459 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            23460 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            23461 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            23462 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            23463 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            23464 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            23465 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            23466 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            23467 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            23468 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            23469 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            23470 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            23471 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            23472 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            23473 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            23474 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            23475 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            23476 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            23477 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            23478 => new TuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            23479 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            23480 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            23481 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            23482 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            23483 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            23484 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            23485 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            23486 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            23487 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            23488 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            23489 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            23490 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            23491 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            23492 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            23493 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            23494 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            23495 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            23496 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            23497 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            23498 => new TuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            23499 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            23500 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            23501 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            23502 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            23503 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            23504 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            23505 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            23506 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            23507 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            23508 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            23509 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            23510 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            23511 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            23512 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            23513 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            23514 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            23515 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            23516 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            23517 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            23518 => new TuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            23519 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            23520 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            23521 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            23522 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            23523 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            23524 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            23525 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            23526 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            23527 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            23528 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            23529 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            23530 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            23531 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            23532 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            23533 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            23534 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            23535 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            23536 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            23537 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            23538 => new TuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
