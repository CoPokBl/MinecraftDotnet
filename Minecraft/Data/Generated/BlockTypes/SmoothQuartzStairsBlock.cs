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
public record SmoothQuartzStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.smooth_quartz_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:smooth_quartz_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/smooth_quartz_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 14, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 19293];

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
                            true => 19293,
                            false => 19294,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19295,
                            false => 19296,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19297,
                            false => 19298,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19299,
                            false => 19300,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19301,
                            false => 19302,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19303,
                            false => 19304,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19305,
                            false => 19306,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19307,
                            false => 19308,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19309,
                            false => 19310,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19311,
                            false => 19312,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19313,
                            false => 19314,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19315,
                            false => 19316,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19317,
                            false => 19318,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19319,
                            false => 19320,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19321,
                            false => 19322,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19323,
                            false => 19324,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19325,
                            false => 19326,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19327,
                            false => 19328,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19329,
                            false => 19330,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19331,
                            false => 19332,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19333,
                            false => 19334,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19335,
                            false => 19336,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19337,
                            false => 19338,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19339,
                            false => 19340,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19341,
                            false => 19342,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19343,
                            false => 19344,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19345,
                            false => 19346,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19347,
                            false => 19348,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19349,
                            false => 19350,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19351,
                            false => 19352,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19353,
                            false => 19354,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19355,
                            false => 19356,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19357,
                            false => 19358,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19359,
                            false => 19360,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19361,
                            false => 19362,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19363,
                            false => 19364,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19365,
                            false => 19366,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19367,
                            false => 19368,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19369,
                            false => 19370,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19371,
                            false => 19372,
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
            19293 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            19294 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            19295 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            19296 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            19297 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            19298 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            19299 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            19300 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            19301 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            19302 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            19303 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            19304 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            19305 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            19306 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            19307 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            19308 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            19309 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            19310 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            19311 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            19312 => new SmoothQuartzStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            19313 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            19314 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            19315 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            19316 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            19317 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            19318 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            19319 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            19320 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            19321 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            19322 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            19323 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            19324 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            19325 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            19326 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            19327 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            19328 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            19329 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            19330 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            19331 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            19332 => new SmoothQuartzStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            19333 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            19334 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            19335 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            19336 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            19337 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            19338 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            19339 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            19340 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            19341 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            19342 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            19343 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            19344 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            19345 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            19346 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            19347 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            19348 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            19349 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            19350 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            19351 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            19352 => new SmoothQuartzStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            19353 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            19354 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            19355 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            19356 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            19357 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            19358 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            19359 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            19360 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            19361 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            19362 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            19363 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            19364 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            19365 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            19366 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            19367 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            19368 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            19369 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            19370 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            19371 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            19372 => new SmoothQuartzStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
