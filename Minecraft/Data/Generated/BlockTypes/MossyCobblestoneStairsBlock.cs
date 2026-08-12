using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyCobblestoneStairsBlock(Identifier Identifier, Direction Facing, MossyCobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.mossy_cobblestone_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mossy_cobblestone_stairs", BlockInfo.VanillaOnly);
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

    public BlockStateInfo StateInfo => States[StateId - 15616];

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
                            true => 15616,
                            false => 15617,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15618,
                            false => 15619,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15620,
                            false => 15621,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15622,
                            false => 15623,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15624,
                            false => 15625,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15626,
                            false => 15627,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15628,
                            false => 15629,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15630,
                            false => 15631,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15632,
                            false => 15633,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15634,
                            false => 15635,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15636,
                            false => 15637,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15638,
                            false => 15639,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15640,
                            false => 15641,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15642,
                            false => 15643,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15644,
                            false => 15645,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15646,
                            false => 15647,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15648,
                            false => 15649,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15650,
                            false => 15651,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15652,
                            false => 15653,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15654,
                            false => 15655,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15656,
                            false => 15657,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15658,
                            false => 15659,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15660,
                            false => 15661,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15662,
                            false => 15663,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15664,
                            false => 15665,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15666,
                            false => 15667,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15668,
                            false => 15669,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15670,
                            false => 15671,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15672,
                            false => 15673,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15674,
                            false => 15675,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15676,
                            false => 15677,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15678,
                            false => 15679,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15680,
                            false => 15681,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15682,
                            false => 15683,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15684,
                            false => 15685,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15686,
                            false => 15687,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15688,
                            false => 15689,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15690,
                            false => 15691,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15692,
                            false => 15693,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15694,
                            false => 15695,
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
            15616 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15617 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15618 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15619 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15620 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15621 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15622 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15623 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15624 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15625 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15626 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15627 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15628 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15629 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15630 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15631 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15632 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15633 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15634 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15635 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15636 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15637 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15638 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15639 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15640 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15641 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15642 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15643 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15644 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15645 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15646 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15647 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15648 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15649 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15650 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15651 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15652 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15653 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15654 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15655 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15656 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15657 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15658 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15659 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15660 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15661 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15662 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15663 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15664 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15665 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15666 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15667 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15668 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15669 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15670 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15671 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15672 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15673 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15674 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15675 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15676 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15677 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15678 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15679 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15680 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15681 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15682 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15683 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15684 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15685 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15686 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15687 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15688 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15689 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15690 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15691 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15692 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15693 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15694 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15695 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
