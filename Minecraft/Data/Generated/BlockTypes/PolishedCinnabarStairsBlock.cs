using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedCinnabarStairsBlock(Identifier Identifier, Direction Facing, PolishedCinnabarStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_cinnabar_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_cinnabar_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 28, "cinnabar", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 26344];

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
                            true => 26344,
                            false => 26345,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26346,
                            false => 26347,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26348,
                            false => 26349,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26350,
                            false => 26351,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26352,
                            false => 26353,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26354,
                            false => 26355,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26356,
                            false => 26357,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26358,
                            false => 26359,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26360,
                            false => 26361,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26362,
                            false => 26363,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26364,
                            false => 26365,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26366,
                            false => 26367,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26368,
                            false => 26369,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26370,
                            false => 26371,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26372,
                            false => 26373,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26374,
                            false => 26375,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26376,
                            false => 26377,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26378,
                            false => 26379,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26380,
                            false => 26381,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26382,
                            false => 26383,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26384,
                            false => 26385,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26386,
                            false => 26387,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26388,
                            false => 26389,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26390,
                            false => 26391,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26392,
                            false => 26393,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26394,
                            false => 26395,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26396,
                            false => 26397,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26398,
                            false => 26399,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26400,
                            false => 26401,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26402,
                            false => 26403,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26404,
                            false => 26405,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26406,
                            false => 26407,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26408,
                            false => 26409,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26410,
                            false => 26411,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26412,
                            false => 26413,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26414,
                            false => 26415,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26416,
                            false => 26417,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26418,
                            false => 26419,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26420,
                            false => 26421,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26422,
                            false => 26423,
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
            26344 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26345 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26346 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26347 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26348 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26349 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26350 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26351 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26352 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26353 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26354 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26355 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26356 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26357 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26358 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26359 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26360 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26361 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26362 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26363 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26364 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26365 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26366 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26367 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26368 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26369 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26370 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26371 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26372 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26373 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26374 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26375 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26376 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26377 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26378 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26379 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26380 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26381 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26382 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26383 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26384 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26385 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26386 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26387 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26388 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26389 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26390 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26391 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26392 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26393 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26394 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26395 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26396 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26397 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26398 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26399 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26400 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26401 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26402 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26403 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26404 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26405 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26406 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26407 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26408 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26409 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26410 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26411 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26412 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26413 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26414 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26415 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26416 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26417 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26418 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26419 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26420 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26421 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26422 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26423 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
