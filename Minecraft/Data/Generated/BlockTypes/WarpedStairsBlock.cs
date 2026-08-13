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
public record WarpedStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.warped_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 56, "nether_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 21386];

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
                            true => 21386,
                            false => 21387,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21388,
                            false => 21389,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21390,
                            false => 21391,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21392,
                            false => 21393,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21394,
                            false => 21395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21396,
                            false => 21397,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21398,
                            false => 21399,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21400,
                            false => 21401,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21402,
                            false => 21403,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21404,
                            false => 21405,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21406,
                            false => 21407,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21408,
                            false => 21409,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21410,
                            false => 21411,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21412,
                            false => 21413,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21414,
                            false => 21415,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21416,
                            false => 21417,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21418,
                            false => 21419,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21420,
                            false => 21421,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21422,
                            false => 21423,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21424,
                            false => 21425,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21426,
                            false => 21427,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21428,
                            false => 21429,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21430,
                            false => 21431,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21432,
                            false => 21433,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21434,
                            false => 21435,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21436,
                            false => 21437,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21438,
                            false => 21439,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21440,
                            false => 21441,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21442,
                            false => 21443,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21444,
                            false => 21445,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21446,
                            false => 21447,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21448,
                            false => 21449,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21450,
                            false => 21451,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21452,
                            false => 21453,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21454,
                            false => 21455,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21456,
                            false => 21457,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21458,
                            false => 21459,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21460,
                            false => 21461,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21462,
                            false => 21463,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21464,
                            false => 21465,
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
            21386 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            21387 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            21388 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            21389 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            21390 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            21391 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            21392 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            21393 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            21394 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            21395 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            21396 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            21397 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            21398 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            21399 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            21400 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            21401 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            21402 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            21403 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            21404 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            21405 => new WarpedStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            21406 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            21407 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            21408 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            21409 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            21410 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            21411 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            21412 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            21413 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            21414 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            21415 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            21416 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            21417 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            21418 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            21419 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            21420 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            21421 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            21422 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            21423 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            21424 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            21425 => new WarpedStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            21426 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            21427 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            21428 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            21429 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            21430 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            21431 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            21432 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            21433 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            21434 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            21435 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            21436 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            21437 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            21438 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            21439 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            21440 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            21441 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            21442 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            21443 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            21444 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            21445 => new WarpedStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            21446 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            21447 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            21448 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            21449 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            21450 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            21451 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            21452 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            21453 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            21454 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            21455 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            21456 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            21457 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            21458 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            21459 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            21460 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            21461 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            21462 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            21463 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            21464 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            21465 => new WarpedStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
