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
public record JungleStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.jungle_stairs", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:jungle_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_stairs");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 10, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 11630];

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
                            true => 11630,
                            false => 11631,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11632,
                            false => 11633,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11634,
                            false => 11635,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11636,
                            false => 11637,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11638,
                            false => 11639,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11640,
                            false => 11641,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11642,
                            false => 11643,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11644,
                            false => 11645,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11646,
                            false => 11647,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11648,
                            false => 11649,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11650,
                            false => 11651,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11652,
                            false => 11653,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11654,
                            false => 11655,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11656,
                            false => 11657,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11658,
                            false => 11659,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11660,
                            false => 11661,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11662,
                            false => 11663,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11664,
                            false => 11665,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11666,
                            false => 11667,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11668,
                            false => 11669,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11670,
                            false => 11671,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11672,
                            false => 11673,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11674,
                            false => 11675,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11676,
                            false => 11677,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11678,
                            false => 11679,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11680,
                            false => 11681,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11682,
                            false => 11683,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11684,
                            false => 11685,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11686,
                            false => 11687,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11688,
                            false => 11689,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11690,
                            false => 11691,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11692,
                            false => 11693,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11694,
                            false => 11695,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11696,
                            false => 11697,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11698,
                            false => 11699,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11700,
                            false => 11701,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11702,
                            false => 11703,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11704,
                            false => 11705,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11706,
                            false => 11707,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11708,
                            false => 11709,
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
            11630 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            11631 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            11632 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            11633 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            11634 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            11635 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            11636 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            11637 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            11638 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            11639 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            11640 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            11641 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            11642 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            11643 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            11644 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            11645 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            11646 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            11647 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            11648 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            11649 => new JungleStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            11650 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            11651 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            11652 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            11653 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            11654 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            11655 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            11656 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            11657 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            11658 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            11659 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            11660 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            11661 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            11662 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            11663 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            11664 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            11665 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            11666 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            11667 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            11668 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            11669 => new JungleStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            11670 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            11671 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            11672 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            11673 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            11674 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            11675 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            11676 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            11677 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            11678 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            11679 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            11680 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            11681 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            11682 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            11683 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            11684 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            11685 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            11686 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            11687 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            11688 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            11689 => new JungleStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            11690 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            11691 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            11692 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            11693 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            11694 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            11695 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            11696 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            11697 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            11698 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            11699 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            11700 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            11701 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            11702 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            11703 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            11704 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            11705 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            11706 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            11707 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            11708 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            11709 => new JungleStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
