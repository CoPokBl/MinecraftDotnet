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
public record PrismarineStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.prismarine_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:prismarine_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/prismarine_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 23, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 12634];

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
                            true => 12634,
                            false => 12635,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12636,
                            false => 12637,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12638,
                            false => 12639,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12640,
                            false => 12641,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12642,
                            false => 12643,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12644,
                            false => 12645,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12646,
                            false => 12647,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12648,
                            false => 12649,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12650,
                            false => 12651,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12652,
                            false => 12653,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12654,
                            false => 12655,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12656,
                            false => 12657,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12658,
                            false => 12659,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12660,
                            false => 12661,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12662,
                            false => 12663,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12664,
                            false => 12665,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12666,
                            false => 12667,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12668,
                            false => 12669,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12670,
                            false => 12671,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12672,
                            false => 12673,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12674,
                            false => 12675,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12676,
                            false => 12677,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12678,
                            false => 12679,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12680,
                            false => 12681,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12682,
                            false => 12683,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12684,
                            false => 12685,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12686,
                            false => 12687,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12688,
                            false => 12689,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12690,
                            false => 12691,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12692,
                            false => 12693,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12694,
                            false => 12695,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12696,
                            false => 12697,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12698,
                            false => 12699,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12700,
                            false => 12701,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12702,
                            false => 12703,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12704,
                            false => 12705,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12706,
                            false => 12707,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12708,
                            false => 12709,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12710,
                            false => 12711,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12712,
                            false => 12713,
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
            12634 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            12635 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            12636 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            12637 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            12638 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            12639 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            12640 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            12641 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            12642 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            12643 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            12644 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            12645 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            12646 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            12647 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            12648 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            12649 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            12650 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            12651 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            12652 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            12653 => new PrismarineStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            12654 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            12655 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            12656 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            12657 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            12658 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            12659 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            12660 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            12661 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            12662 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            12663 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            12664 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            12665 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            12666 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            12667 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            12668 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            12669 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            12670 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            12671 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            12672 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            12673 => new PrismarineStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            12674 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            12675 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            12676 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            12677 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            12678 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            12679 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            12680 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            12681 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            12682 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            12683 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            12684 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            12685 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            12686 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            12687 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            12688 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            12689 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            12690 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            12691 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            12692 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            12693 => new PrismarineStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            12694 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            12695 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            12696 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            12697 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            12698 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            12699 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            12700 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            12701 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            12702 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            12703 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            12704 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            12705 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            12706 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            12707 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            12708 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            12709 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            12710 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            12711 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            12712 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            12713 => new PrismarineStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
