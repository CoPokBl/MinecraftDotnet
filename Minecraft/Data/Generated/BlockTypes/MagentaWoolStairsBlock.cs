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
public record MagentaWoolStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.magenta_wool_stairs", 0.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:magenta_wool_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/magenta_wool_stairs");
    private static readonly BlockStateInfo I0 = new(0.8f, 0, 1, PushReaction.PushPull, 16, "wool", NoteBlockInstrument.Guitar, false, true, false, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 2585];

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
                            true => 2585,
                            false => 2586,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2587,
                            false => 2588,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2589,
                            false => 2590,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2591,
                            false => 2592,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2593,
                            false => 2594,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2595,
                            false => 2596,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2597,
                            false => 2598,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2599,
                            false => 2600,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2601,
                            false => 2602,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2603,
                            false => 2604,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2605,
                            false => 2606,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2607,
                            false => 2608,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2609,
                            false => 2610,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2611,
                            false => 2612,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2613,
                            false => 2614,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2615,
                            false => 2616,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2617,
                            false => 2618,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2619,
                            false => 2620,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2621,
                            false => 2622,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2623,
                            false => 2624,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2625,
                            false => 2626,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2627,
                            false => 2628,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2629,
                            false => 2630,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2631,
                            false => 2632,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2633,
                            false => 2634,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2635,
                            false => 2636,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2637,
                            false => 2638,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2639,
                            false => 2640,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2641,
                            false => 2642,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2643,
                            false => 2644,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2645,
                            false => 2646,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2647,
                            false => 2648,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2649,
                            false => 2650,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2651,
                            false => 2652,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2653,
                            false => 2654,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 2655,
                            false => 2656,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 2657,
                            false => 2658,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 2659,
                            false => 2660,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 2661,
                            false => 2662,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 2663,
                            false => 2664,
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
            2585 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            2586 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            2587 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            2588 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            2589 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            2590 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            2591 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            2592 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            2593 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            2594 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            2595 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            2596 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            2597 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            2598 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            2599 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            2600 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            2601 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            2602 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            2603 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            2604 => new MagentaWoolStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            2605 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            2606 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            2607 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            2608 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            2609 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            2610 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            2611 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            2612 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            2613 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            2614 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            2615 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            2616 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            2617 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            2618 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            2619 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            2620 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            2621 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            2622 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            2623 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            2624 => new MagentaWoolStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            2625 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            2626 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            2627 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            2628 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            2629 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            2630 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            2631 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            2632 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            2633 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            2634 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            2635 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            2636 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            2637 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            2638 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            2639 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            2640 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            2641 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            2642 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            2643 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            2644 => new MagentaWoolStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            2645 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            2646 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            2647 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            2648 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            2649 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            2650 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            2651 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            2652 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            2653 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            2654 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            2655 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            2656 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            2657 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            2658 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            2659 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            2660 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            2661 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            2662 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            2663 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            2664 => new MagentaWoolStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
