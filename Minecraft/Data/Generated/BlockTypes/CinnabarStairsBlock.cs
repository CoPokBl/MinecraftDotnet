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
public record CinnabarStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cinnabar_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cinnabar_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cinnabar_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 28, "cinnabar", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 29290];

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
                            true => 29290,
                            false => 29291,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29292,
                            false => 29293,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29294,
                            false => 29295,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29296,
                            false => 29297,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29298,
                            false => 29299,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29300,
                            false => 29301,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29302,
                            false => 29303,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29304,
                            false => 29305,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29306,
                            false => 29307,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29308,
                            false => 29309,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29310,
                            false => 29311,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29312,
                            false => 29313,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29314,
                            false => 29315,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29316,
                            false => 29317,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29318,
                            false => 29319,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29320,
                            false => 29321,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29322,
                            false => 29323,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29324,
                            false => 29325,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29326,
                            false => 29327,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29328,
                            false => 29329,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29330,
                            false => 29331,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29332,
                            false => 29333,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29334,
                            false => 29335,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29336,
                            false => 29337,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29338,
                            false => 29339,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29340,
                            false => 29341,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29342,
                            false => 29343,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29344,
                            false => 29345,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29346,
                            false => 29347,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29348,
                            false => 29349,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29350,
                            false => 29351,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29352,
                            false => 29353,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29354,
                            false => 29355,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29356,
                            false => 29357,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29358,
                            false => 29359,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 29360,
                            false => 29361,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 29362,
                            false => 29363,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 29364,
                            false => 29365,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 29366,
                            false => 29367,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 29368,
                            false => 29369,
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
            29290 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            29291 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            29292 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            29293 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            29294 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            29295 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            29296 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            29297 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            29298 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            29299 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            29300 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            29301 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            29302 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            29303 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            29304 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            29305 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            29306 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            29307 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            29308 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            29309 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            29310 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            29311 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            29312 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            29313 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            29314 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            29315 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            29316 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            29317 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            29318 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            29319 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            29320 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            29321 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            29322 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            29323 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            29324 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            29325 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            29326 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            29327 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            29328 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            29329 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            29330 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            29331 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            29332 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            29333 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            29334 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            29335 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            29336 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            29337 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            29338 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            29339 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            29340 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            29341 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            29342 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            29343 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            29344 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            29345 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            29346 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            29347 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            29348 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            29349 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            29350 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            29351 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            29352 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            29353 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            29354 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            29355 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            29356 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            29357 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            29358 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            29359 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            29360 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            29361 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            29362 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            29363 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            29364 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            29365 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            29366 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            29367 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            29368 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            29369 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
