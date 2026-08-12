using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_blackstone_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 22657];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22657,
                            false => 22658,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22659,
                            false => 22660,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22661,
                            false => 22662,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22663,
                            false => 22664,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22665,
                            false => 22666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22667,
                            false => 22668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22669,
                            false => 22670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22671,
                            false => 22672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22673,
                            false => 22674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22675,
                            false => 22676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22677,
                            false => 22678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22679,
                            false => 22680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22681,
                            false => 22682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22683,
                            false => 22684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22685,
                            false => 22686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22687,
                            false => 22688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22689,
                            false => 22690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22691,
                            false => 22692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22693,
                            false => 22694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22695,
                            false => 22696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22697,
                            false => 22698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22699,
                            false => 22700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22701,
                            false => 22702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22703,
                            false => 22704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22705,
                            false => 22706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22707,
                            false => 22708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22709,
                            false => 22710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22711,
                            false => 22712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22713,
                            false => 22714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22715,
                            false => 22716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22717,
                            false => 22718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22719,
                            false => 22720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22721,
                            false => 22722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22723,
                            false => 22724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22725,
                            false => 22726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22727,
                            false => 22728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22729,
                            false => 22730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22731,
                            false => 22732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22733,
                            false => 22734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22735,
                            false => 22736,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22657 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22658 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22659 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22660 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22661 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22662 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22663 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22664 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22665 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22666 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22667 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22668 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22669 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22670 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22671 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22672 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22673 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22674 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22675 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22676 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22677 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22678 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22679 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22680 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22681 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22682 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22683 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22684 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22685 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22686 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22687 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22688 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22689 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22690 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22691 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22692 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22693 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22694 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22695 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22696 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22697 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22698 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22699 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22700 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22701 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22702 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22703 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22704 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22705 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22706 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22707 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22708 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22709 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22710 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22711 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22712 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22713 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22714 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22715 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22716 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22717 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22718 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22719 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22720 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22721 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22722 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22723 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22724 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22725 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22726 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22727 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22728 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22729 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22730 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22731 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22732 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22733 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22734 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22735 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22736 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
