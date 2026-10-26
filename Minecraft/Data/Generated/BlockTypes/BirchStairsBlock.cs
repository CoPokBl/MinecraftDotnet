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
public record BirchStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.birch_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/birch_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 2, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 11550];

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
                            true => 11550,
                            false => 11551,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11552,
                            false => 11553,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11554,
                            false => 11555,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11556,
                            false => 11557,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11558,
                            false => 11559,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11560,
                            false => 11561,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11562,
                            false => 11563,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11564,
                            false => 11565,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11566,
                            false => 11567,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11568,
                            false => 11569,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11570,
                            false => 11571,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11572,
                            false => 11573,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11574,
                            false => 11575,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11576,
                            false => 11577,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11578,
                            false => 11579,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11580,
                            false => 11581,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11582,
                            false => 11583,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11584,
                            false => 11585,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11586,
                            false => 11587,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11588,
                            false => 11589,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11590,
                            false => 11591,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11592,
                            false => 11593,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11594,
                            false => 11595,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11596,
                            false => 11597,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11598,
                            false => 11599,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11600,
                            false => 11601,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11602,
                            false => 11603,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11604,
                            false => 11605,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11606,
                            false => 11607,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11608,
                            false => 11609,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11610,
                            false => 11611,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11612,
                            false => 11613,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11614,
                            false => 11615,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11616,
                            false => 11617,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11618,
                            false => 11619,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11620,
                            false => 11621,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11622,
                            false => 11623,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11624,
                            false => 11625,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11626,
                            false => 11627,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11628,
                            false => 11629,
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
            11550 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            11551 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            11552 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            11553 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            11554 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            11555 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            11556 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            11557 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            11558 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            11559 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            11560 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            11561 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            11562 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            11563 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            11564 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            11565 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            11566 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            11567 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            11568 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            11569 => new BirchStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            11570 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            11571 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            11572 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            11573 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            11574 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            11575 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            11576 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            11577 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            11578 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            11579 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            11580 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            11581 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            11582 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            11583 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            11584 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            11585 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            11586 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            11587 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            11588 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            11589 => new BirchStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            11590 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            11591 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            11592 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            11593 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            11594 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            11595 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            11596 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            11597 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            11598 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            11599 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            11600 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            11601 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            11602 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            11603 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            11604 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            11605 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            11606 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            11607 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            11608 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            11609 => new BirchStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            11610 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            11611 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            11612 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            11613 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            11614 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            11615 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            11616 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            11617 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            11618 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            11619 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            11620 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            11621 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            11622 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            11623 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            11624 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            11625 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            11626 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            11627 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            11628 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            11629 => new BirchStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
