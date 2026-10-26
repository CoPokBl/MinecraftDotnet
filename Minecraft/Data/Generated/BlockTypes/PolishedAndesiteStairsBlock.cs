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
public record PolishedAndesiteStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_andesite_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_andesite_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_andesite_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 19613];

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
                            true => 19613,
                            false => 19614,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19615,
                            false => 19616,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19617,
                            false => 19618,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19619,
                            false => 19620,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19621,
                            false => 19622,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19623,
                            false => 19624,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19625,
                            false => 19626,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19627,
                            false => 19628,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19629,
                            false => 19630,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19631,
                            false => 19632,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19633,
                            false => 19634,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19635,
                            false => 19636,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19637,
                            false => 19638,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19639,
                            false => 19640,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19641,
                            false => 19642,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19643,
                            false => 19644,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19645,
                            false => 19646,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19647,
                            false => 19648,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19649,
                            false => 19650,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19651,
                            false => 19652,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19653,
                            false => 19654,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19655,
                            false => 19656,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19657,
                            false => 19658,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19659,
                            false => 19660,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19661,
                            false => 19662,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19663,
                            false => 19664,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19665,
                            false => 19666,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19667,
                            false => 19668,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19669,
                            false => 19670,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19671,
                            false => 19672,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19673,
                            false => 19674,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19675,
                            false => 19676,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19677,
                            false => 19678,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19679,
                            false => 19680,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19681,
                            false => 19682,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 19683,
                            false => 19684,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 19685,
                            false => 19686,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 19687,
                            false => 19688,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 19689,
                            false => 19690,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 19691,
                            false => 19692,
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
            19613 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            19614 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            19615 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            19616 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            19617 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            19618 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            19619 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            19620 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            19621 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            19622 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            19623 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            19624 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            19625 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            19626 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            19627 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            19628 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            19629 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            19630 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            19631 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            19632 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            19633 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            19634 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            19635 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            19636 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            19637 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            19638 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            19639 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            19640 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            19641 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            19642 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            19643 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            19644 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            19645 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            19646 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            19647 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            19648 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            19649 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            19650 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            19651 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            19652 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            19653 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            19654 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            19655 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            19656 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            19657 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            19658 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            19659 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            19660 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            19661 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            19662 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            19663 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            19664 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            19665 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            19666 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            19667 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            19668 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            19669 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            19670 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            19671 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            19672 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            19673 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            19674 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            19675 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            19676 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            19677 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            19678 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            19679 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            19680 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            19681 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            19682 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            19683 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            19684 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            19685 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            19686 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            19687 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            19688 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            19689 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            19690 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            19691 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            19692 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
