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
public record SandstoneStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.sandstone_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sandstone_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/sandstone_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 2, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 11235];

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
                            true => 11235,
                            false => 11236,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11237,
                            false => 11238,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11239,
                            false => 11240,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11241,
                            false => 11242,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11243,
                            false => 11244,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11245,
                            false => 11246,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11247,
                            false => 11248,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11249,
                            false => 11250,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11251,
                            false => 11252,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11253,
                            false => 11254,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11255,
                            false => 11256,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11257,
                            false => 11258,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11259,
                            false => 11260,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11261,
                            false => 11262,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11263,
                            false => 11264,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11265,
                            false => 11266,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11267,
                            false => 11268,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11269,
                            false => 11270,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11271,
                            false => 11272,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11273,
                            false => 11274,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11275,
                            false => 11276,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11277,
                            false => 11278,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11279,
                            false => 11280,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11281,
                            false => 11282,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11283,
                            false => 11284,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11285,
                            false => 11286,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11287,
                            false => 11288,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11289,
                            false => 11290,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11291,
                            false => 11292,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11293,
                            false => 11294,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11295,
                            false => 11296,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11297,
                            false => 11298,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11299,
                            false => 11300,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11301,
                            false => 11302,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11303,
                            false => 11304,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11305,
                            false => 11306,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11307,
                            false => 11308,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11309,
                            false => 11310,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11311,
                            false => 11312,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11313,
                            false => 11314,
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
            11235 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            11236 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            11237 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            11238 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            11239 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            11240 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            11241 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            11242 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            11243 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            11244 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            11245 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            11246 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            11247 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            11248 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            11249 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            11250 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            11251 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            11252 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            11253 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            11254 => new SandstoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            11255 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            11256 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            11257 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            11258 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            11259 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            11260 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            11261 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            11262 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            11263 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            11264 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            11265 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            11266 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            11267 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            11268 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            11269 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            11270 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            11271 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            11272 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            11273 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            11274 => new SandstoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            11275 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            11276 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            11277 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            11278 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            11279 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            11280 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            11281 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            11282 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            11283 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            11284 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            11285 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            11286 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            11287 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            11288 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            11289 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            11290 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            11291 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            11292 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            11293 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            11294 => new SandstoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            11295 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            11296 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            11297 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            11298 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            11299 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            11300 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            11301 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            11302 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            11303 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            11304 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            11305 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            11306 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            11307 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            11308 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            11309 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            11310 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            11311 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            11312 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            11313 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            11314 => new SandstoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
