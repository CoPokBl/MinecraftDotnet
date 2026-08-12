using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobblestoneStairsBlock(Identifier Identifier, Direction Facing, CobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.cobblestone_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cobblestone_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 5747];

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
                            true => 5747,
                            false => 5748,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5749,
                            false => 5750,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5751,
                            false => 5752,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5753,
                            false => 5754,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5755,
                            false => 5756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5757,
                            false => 5758,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5759,
                            false => 5760,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5761,
                            false => 5762,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5763,
                            false => 5764,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5765,
                            false => 5766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5767,
                            false => 5768,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5769,
                            false => 5770,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5771,
                            false => 5772,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5773,
                            false => 5774,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5775,
                            false => 5776,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5777,
                            false => 5778,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5779,
                            false => 5780,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5781,
                            false => 5782,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5783,
                            false => 5784,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5785,
                            false => 5786,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5787,
                            false => 5788,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5789,
                            false => 5790,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5791,
                            false => 5792,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5793,
                            false => 5794,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5795,
                            false => 5796,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5797,
                            false => 5798,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5799,
                            false => 5800,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5801,
                            false => 5802,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5803,
                            false => 5804,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5805,
                            false => 5806,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5807,
                            false => 5808,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5809,
                            false => 5810,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5811,
                            false => 5812,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5813,
                            false => 5814,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5815,
                            false => 5816,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5817,
                            false => 5818,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5819,
                            false => 5820,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5821,
                            false => 5822,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5823,
                            false => 5824,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5825,
                            false => 5826,
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
            5747 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            5748 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            5749 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            5750 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            5751 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            5752 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            5753 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            5754 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            5755 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            5756 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            5757 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            5758 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            5759 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            5760 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            5761 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            5762 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            5763 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            5764 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            5765 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            5766 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            5767 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            5768 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            5769 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            5770 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            5771 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            5772 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            5773 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            5774 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            5775 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            5776 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            5777 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            5778 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            5779 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            5780 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            5781 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            5782 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            5783 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            5784 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            5785 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            5786 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            5787 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            5788 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            5789 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            5790 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            5791 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            5792 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            5793 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            5794 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            5795 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            5796 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            5797 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            5798 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            5799 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            5800 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            5801 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            5802 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            5803 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            5804 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            5805 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            5806 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            5807 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            5808 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            5809 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            5810 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            5811 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            5812 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            5813 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            5814 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            5815 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            5816 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            5817 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            5818 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            5819 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            5820 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            5821 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            5822 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            5823 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            5824 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            5825 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            5826 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
