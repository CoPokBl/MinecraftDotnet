using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedGraniteStairsBlock(Identifier Identifier, Direction Facing, PolishedGraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_granite_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_granite_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 10, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 15296];

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
                            true => 15296,
                            false => 15297,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15298,
                            false => 15299,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15300,
                            false => 15301,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15302,
                            false => 15303,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15304,
                            false => 15305,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15306,
                            false => 15307,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15308,
                            false => 15309,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15310,
                            false => 15311,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15312,
                            false => 15313,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15314,
                            false => 15315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15316,
                            false => 15317,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15318,
                            false => 15319,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15320,
                            false => 15321,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15322,
                            false => 15323,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15324,
                            false => 15325,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15326,
                            false => 15327,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15328,
                            false => 15329,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15330,
                            false => 15331,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15332,
                            false => 15333,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15334,
                            false => 15335,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15336,
                            false => 15337,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15338,
                            false => 15339,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15340,
                            false => 15341,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15342,
                            false => 15343,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15344,
                            false => 15345,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15346,
                            false => 15347,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15348,
                            false => 15349,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15350,
                            false => 15351,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15352,
                            false => 15353,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15354,
                            false => 15355,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15356,
                            false => 15357,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15358,
                            false => 15359,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15360,
                            false => 15361,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15362,
                            false => 15363,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15364,
                            false => 15365,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15366,
                            false => 15367,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15368,
                            false => 15369,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15370,
                            false => 15371,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15372,
                            false => 15373,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15374,
                            false => 15375,
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
            15296 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15297 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15298 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15299 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15300 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15301 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15302 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15303 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15304 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15305 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15306 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15307 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15308 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15309 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15310 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15311 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15312 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15313 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15314 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15315 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15316 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15317 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15318 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15319 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15320 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15321 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15322 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15323 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15324 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15325 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15326 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15327 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15328 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15329 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15330 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15331 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15332 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15333 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15334 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15335 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15336 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15337 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15338 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15339 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15340 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15341 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15342 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15343 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15344 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15345 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15346 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15347 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15348 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15349 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15350 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15351 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15352 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15353 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15354 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15355 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15356 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15357 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15358 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15359 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15360 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15361 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15362 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15363 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15364 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15365 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15366 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15367 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15368 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15369 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15370 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15371 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15372 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15373 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15374 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15375 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
