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
public record SmoothSandstoneStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.smooth_sandstone_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:smooth_sandstone_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/smooth_sandstone_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 2, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 19213];

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
                            true => 19213,
                            false => 19214,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19215,
                            false => 19216,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19217,
                            false => 19218,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19219,
                            false => 19220,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19221,
                            false => 19222,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19223,
                            false => 19224,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19225,
                            false => 19226,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19227,
                            false => 19228,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19229,
                            false => 19230,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19231,
                            false => 19232,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19233,
                            false => 19234,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19235,
                            false => 19236,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19237,
                            false => 19238,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19239,
                            false => 19240,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19241,
                            false => 19242,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19243,
                            false => 19244,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19245,
                            false => 19246,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19247,
                            false => 19248,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19249,
                            false => 19250,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19251,
                            false => 19252,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19253,
                            false => 19254,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19255,
                            false => 19256,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19257,
                            false => 19258,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19259,
                            false => 19260,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19261,
                            false => 19262,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19263,
                            false => 19264,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19265,
                            false => 19266,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19267,
                            false => 19268,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19269,
                            false => 19270,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19271,
                            false => 19272,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19273,
                            false => 19274,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19275,
                            false => 19276,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19277,
                            false => 19278,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19279,
                            false => 19280,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19281,
                            false => 19282,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19283,
                            false => 19284,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19285,
                            false => 19286,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19287,
                            false => 19288,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19289,
                            false => 19290,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19291,
                            false => 19292,
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
            19213 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            19214 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            19215 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            19216 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            19217 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            19218 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            19219 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            19220 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            19221 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            19222 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            19223 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            19224 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            19225 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            19226 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            19227 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            19228 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            19229 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            19230 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            19231 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            19232 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            19233 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            19234 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            19235 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            19236 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            19237 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            19238 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            19239 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            19240 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            19241 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            19242 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            19243 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            19244 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            19245 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            19246 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            19247 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            19248 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            19249 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            19250 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            19251 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            19252 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            19253 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            19254 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            19255 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            19256 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            19257 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            19258 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            19259 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            19260 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            19261 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            19262 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            19263 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            19264 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            19265 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            19266 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            19267 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            19268 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            19269 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            19270 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            19271 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            19272 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            19273 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            19274 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            19275 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            19276 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            19277 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            19278 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            19279 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            19280 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            19281 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            19282 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            19283 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            19284 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            19285 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            19286 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            19287 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            19288 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            19289 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            19290 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            19291 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            19292 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
