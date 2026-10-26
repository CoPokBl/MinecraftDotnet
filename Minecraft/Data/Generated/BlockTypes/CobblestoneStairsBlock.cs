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
public record CobblestoneStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cobblestone_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cobblestone_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cobblestone_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 7335];

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
                            true => 7335,
                            false => 7336,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7337,
                            false => 7338,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7339,
                            false => 7340,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7341,
                            false => 7342,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7343,
                            false => 7344,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7345,
                            false => 7346,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7347,
                            false => 7348,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7349,
                            false => 7350,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7351,
                            false => 7352,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7353,
                            false => 7354,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7355,
                            false => 7356,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7357,
                            false => 7358,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7359,
                            false => 7360,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7361,
                            false => 7362,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7363,
                            false => 7364,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7365,
                            false => 7366,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7367,
                            false => 7368,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7369,
                            false => 7370,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7371,
                            false => 7372,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7373,
                            false => 7374,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7375,
                            false => 7376,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7377,
                            false => 7378,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7379,
                            false => 7380,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7381,
                            false => 7382,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7383,
                            false => 7384,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7385,
                            false => 7386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7387,
                            false => 7388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7389,
                            false => 7390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7391,
                            false => 7392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7393,
                            false => 7394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7395,
                            false => 7396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7397,
                            false => 7398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7399,
                            false => 7400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7401,
                            false => 7402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7403,
                            false => 7404,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7405,
                            false => 7406,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7407,
                            false => 7408,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7409,
                            false => 7410,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7411,
                            false => 7412,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7413,
                            false => 7414,
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
            7335 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            7336 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            7337 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            7338 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            7339 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            7340 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            7341 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            7342 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            7343 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            7344 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            7345 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            7346 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            7347 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            7348 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            7349 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            7350 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            7351 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            7352 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            7353 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            7354 => new CobblestoneStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            7355 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            7356 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            7357 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            7358 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            7359 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            7360 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            7361 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            7362 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            7363 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            7364 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            7365 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            7366 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            7367 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            7368 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            7369 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            7370 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            7371 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            7372 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            7373 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            7374 => new CobblestoneStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            7375 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            7376 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            7377 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            7378 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            7379 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            7380 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            7381 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            7382 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            7383 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            7384 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            7385 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            7386 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            7387 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            7388 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            7389 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            7390 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            7391 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            7392 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            7393 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            7394 => new CobblestoneStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            7395 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            7396 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            7397 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            7398 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            7399 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            7400 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            7401 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            7402 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            7403 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            7404 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            7405 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            7406 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            7407 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            7408 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            7409 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            7410 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            7411 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            7412 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            7413 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            7414 => new CobblestoneStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
