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
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.cinnabar_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cinnabar_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/cinnabar_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 28, "cinnabar", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 25933];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                            true => 25933,
                            false => 25934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25935,
                            false => 25936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25937,
                            false => 25938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25939,
                            false => 25940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25941,
                            false => 25942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25943,
                            false => 25944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25945,
                            false => 25946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25947,
                            false => 25948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25949,
                            false => 25950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25951,
                            false => 25952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25953,
                            false => 25954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25955,
                            false => 25956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25957,
                            false => 25958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25959,
                            false => 25960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25961,
                            false => 25962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25963,
                            false => 25964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25965,
                            false => 25966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25967,
                            false => 25968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25969,
                            false => 25970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25971,
                            false => 25972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25973,
                            false => 25974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25975,
                            false => 25976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25977,
                            false => 25978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25979,
                            false => 25980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25981,
                            false => 25982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25983,
                            false => 25984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25985,
                            false => 25986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25987,
                            false => 25988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25989,
                            false => 25990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25991,
                            false => 25992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25993,
                            false => 25994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25995,
                            false => 25996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25997,
                            false => 25998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25999,
                            false => 26000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26001,
                            false => 26002,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26003,
                            false => 26004,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26005,
                            false => 26006,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26007,
                            false => 26008,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26009,
                            false => 26010,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26011,
                            false => 26012,
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
            25933 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            25934 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            25935 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            25936 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            25937 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            25938 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            25939 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            25940 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            25941 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            25942 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            25943 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            25944 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            25945 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            25946 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            25947 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            25948 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            25949 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            25950 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            25951 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            25952 => new CinnabarStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            25953 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            25954 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            25955 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            25956 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            25957 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            25958 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            25959 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            25960 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            25961 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            25962 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            25963 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            25964 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            25965 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            25966 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            25967 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            25968 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            25969 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            25970 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            25971 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            25972 => new CinnabarStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            25973 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            25974 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            25975 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            25976 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            25977 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            25978 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            25979 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            25980 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            25981 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            25982 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            25983 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            25984 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            25985 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            25986 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            25987 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            25988 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            25989 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            25990 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            25991 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            25992 => new CinnabarStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            25993 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            25994 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            25995 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            25996 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            25997 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            25998 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            25999 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            26000 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            26001 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            26002 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            26003 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            26004 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            26005 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            26006 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            26007 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            26008 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            26009 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            26010 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            26011 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            26012 => new CinnabarStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
