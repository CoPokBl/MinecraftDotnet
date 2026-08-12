using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooStairsBlock(Identifier Identifier, Direction Facing, BambooStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.bamboo_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S90, CollisionShape = BlockShapes.S90, OcclusionShape = BlockShapes.S90, VisualShape = BlockShapes.S90 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S91, CollisionShape = BlockShapes.S91, OcclusionShape = BlockShapes.S91, VisualShape = BlockShapes.S91 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S92, CollisionShape = BlockShapes.S92, OcclusionShape = BlockShapes.S92, VisualShape = BlockShapes.S92 };
    private static readonly BlockStateInfo I10 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S93, CollisionShape = BlockShapes.S93, OcclusionShape = BlockShapes.S93, VisualShape = BlockShapes.S93 };
    private static readonly BlockStateInfo I12 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S94, CollisionShape = BlockShapes.S94, OcclusionShape = BlockShapes.S94, VisualShape = BlockShapes.S94 };
    private static readonly BlockStateInfo I14 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S95, CollisionShape = BlockShapes.S95, OcclusionShape = BlockShapes.S95, VisualShape = BlockShapes.S95 };
    private static readonly BlockStateInfo I16 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S96, CollisionShape = BlockShapes.S96, OcclusionShape = BlockShapes.S96, VisualShape = BlockShapes.S96 };
    private static readonly BlockStateInfo I18 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S97, CollisionShape = BlockShapes.S97, OcclusionShape = BlockShapes.S97, VisualShape = BlockShapes.S97 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S98, CollisionShape = BlockShapes.S98, OcclusionShape = BlockShapes.S98, VisualShape = BlockShapes.S98 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S99, CollisionShape = BlockShapes.S99, OcclusionShape = BlockShapes.S99, VisualShape = BlockShapes.S99 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I25 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S100, CollisionShape = BlockShapes.S100, OcclusionShape = BlockShapes.S100, VisualShape = BlockShapes.S100 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S101, CollisionShape = BlockShapes.S101, OcclusionShape = BlockShapes.S101, VisualShape = BlockShapes.S101 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I29 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S102, CollisionShape = BlockShapes.S102, OcclusionShape = BlockShapes.S102, VisualShape = BlockShapes.S102 };
    private static readonly BlockStateInfo I30 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S103, CollisionShape = BlockShapes.S103, OcclusionShape = BlockShapes.S103, VisualShape = BlockShapes.S103 };
    private static readonly BlockStateInfo I32 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I33 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S104, CollisionShape = BlockShapes.S104, OcclusionShape = BlockShapes.S104, VisualShape = BlockShapes.S104 };
    private static readonly BlockStateInfo I34 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I35 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S105, CollisionShape = BlockShapes.S105, OcclusionShape = BlockShapes.S105, VisualShape = BlockShapes.S105 };
    private static readonly BlockStateInfo I36 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I37 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S106, CollisionShape = BlockShapes.S106, OcclusionShape = BlockShapes.S106, VisualShape = BlockShapes.S106 };
    private static readonly BlockStateInfo I38 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I39 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S107, CollisionShape = BlockShapes.S107, OcclusionShape = BlockShapes.S107, VisualShape = BlockShapes.S107 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I41 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S108, CollisionShape = BlockShapes.S108, OcclusionShape = BlockShapes.S108, VisualShape = BlockShapes.S108 };
    private static readonly BlockStateInfo I42 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I43 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S109, CollisionShape = BlockShapes.S109, OcclusionShape = BlockShapes.S109, VisualShape = BlockShapes.S109 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I45 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S110, CollisionShape = BlockShapes.S110, OcclusionShape = BlockShapes.S110, VisualShape = BlockShapes.S110 };
    private static readonly BlockStateInfo I46 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo I47 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S111, CollisionShape = BlockShapes.S111, OcclusionShape = BlockShapes.S111, VisualShape = BlockShapes.S111 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I24, I25, I2, I3, I28, I29, I6, I7, I42, I43, I34, I35, I12, I13, I38, I39, I16, I17, I44, I45, I4, I5, I22, I23, I8, I9, I26, I27, I46, I47, I14, I15, I32, I33, I18, I19, I36, I37
    ];

    public BlockStateInfo StateInfo => States[StateId - 12372];

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
                            true => 12372,
                            false => 12373,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12374,
                            false => 12375,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12376,
                            false => 12377,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12378,
                            false => 12379,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12380,
                            false => 12381,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12382,
                            false => 12383,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12384,
                            false => 12385,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12386,
                            false => 12387,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12388,
                            false => 12389,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12390,
                            false => 12391,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12392,
                            false => 12393,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12394,
                            false => 12395,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12396,
                            false => 12397,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12398,
                            false => 12399,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12400,
                            false => 12401,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12402,
                            false => 12403,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12404,
                            false => 12405,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12406,
                            false => 12407,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12408,
                            false => 12409,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12410,
                            false => 12411,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12412,
                            false => 12413,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12414,
                            false => 12415,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12416,
                            false => 12417,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12418,
                            false => 12419,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12420,
                            false => 12421,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12422,
                            false => 12423,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12424,
                            false => 12425,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12426,
                            false => 12427,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12428,
                            false => 12429,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12430,
                            false => 12431,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12432,
                            false => 12433,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12434,
                            false => 12435,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12436,
                            false => 12437,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12438,
                            false => 12439,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12440,
                            false => 12441,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12442,
                            false => 12443,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12444,
                            false => 12445,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12446,
                            false => 12447,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12448,
                            false => 12449,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12450,
                            false => 12451,
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
            12372 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12373 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12374 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12375 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12376 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12377 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12378 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12379 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12380 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12381 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12382 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12383 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12384 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12385 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12386 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12387 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12388 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12389 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12390 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12391 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12392 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12393 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12394 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12395 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12396 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12397 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12398 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12399 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12400 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12401 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12402 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12403 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12404 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12405 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12406 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12407 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12408 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12409 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12410 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12411 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12412 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12413 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12414 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12415 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12416 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12417 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12418 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12419 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12420 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12421 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12422 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12423 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12424 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12425 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12426 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12427 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12428 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12429 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12430 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12431 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12432 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12433 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12434 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12435 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12436 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12437 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12438 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12439 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12440 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12441 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12442 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12443 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12444 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12445 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12446 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12447 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12448 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12449 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12450 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12451 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
