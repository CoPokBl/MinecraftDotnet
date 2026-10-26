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
public record QuartzStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.quartz_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:quartz_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/quartz_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 14, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 13095];

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
                            true => 13095,
                            false => 13096,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13097,
                            false => 13098,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13099,
                            false => 13100,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13101,
                            false => 13102,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13103,
                            false => 13104,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13105,
                            false => 13106,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13107,
                            false => 13108,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13109,
                            false => 13110,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13111,
                            false => 13112,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13113,
                            false => 13114,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13115,
                            false => 13116,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13117,
                            false => 13118,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13119,
                            false => 13120,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13121,
                            false => 13122,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13123,
                            false => 13124,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13125,
                            false => 13126,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13127,
                            false => 13128,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13129,
                            false => 13130,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13131,
                            false => 13132,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13133,
                            false => 13134,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13135,
                            false => 13136,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13137,
                            false => 13138,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13139,
                            false => 13140,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13141,
                            false => 13142,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13143,
                            false => 13144,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13145,
                            false => 13146,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13147,
                            false => 13148,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13149,
                            false => 13150,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13151,
                            false => 13152,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13153,
                            false => 13154,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13155,
                            false => 13156,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13157,
                            false => 13158,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13159,
                            false => 13160,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13161,
                            false => 13162,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13163,
                            false => 13164,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13165,
                            false => 13166,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13167,
                            false => 13168,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13169,
                            false => 13170,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13171,
                            false => 13172,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13173,
                            false => 13174,
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
            13095 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            13096 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            13097 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            13098 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            13099 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            13100 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            13101 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            13102 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            13103 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            13104 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            13105 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            13106 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            13107 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            13108 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            13109 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            13110 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            13111 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            13112 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            13113 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            13114 => new QuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            13115 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            13116 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            13117 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            13118 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            13119 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            13120 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            13121 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            13122 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            13123 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            13124 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            13125 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            13126 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            13127 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            13128 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            13129 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            13130 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            13131 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            13132 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            13133 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            13134 => new QuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            13135 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            13136 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            13137 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            13138 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            13139 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            13140 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            13141 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            13142 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            13143 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            13144 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            13145 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            13146 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            13147 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            13148 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            13149 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            13150 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            13151 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            13152 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            13153 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            13154 => new QuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            13155 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            13156 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            13157 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            13158 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            13159 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            13160 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            13161 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            13162 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            13163 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            13164 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            13165 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            13166 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            13167 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            13168 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            13169 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            13170 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            13171 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            13172 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            13173 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            13174 => new QuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
