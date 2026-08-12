using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneBrickStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_blackstone_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 22252];

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
                            true => 22252,
                            false => 22253,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22254,
                            false => 22255,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22256,
                            false => 22257,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22258,
                            false => 22259,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22260,
                            false => 22261,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22262,
                            false => 22263,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22264,
                            false => 22265,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22266,
                            false => 22267,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22268,
                            false => 22269,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22270,
                            false => 22271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22272,
                            false => 22273,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22274,
                            false => 22275,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22276,
                            false => 22277,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22278,
                            false => 22279,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22280,
                            false => 22281,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22282,
                            false => 22283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22284,
                            false => 22285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22286,
                            false => 22287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22288,
                            false => 22289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22290,
                            false => 22291,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22292,
                            false => 22293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22294,
                            false => 22295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22296,
                            false => 22297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22298,
                            false => 22299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22300,
                            false => 22301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22302,
                            false => 22303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22304,
                            false => 22305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22306,
                            false => 22307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22308,
                            false => 22309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22310,
                            false => 22311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22312,
                            false => 22313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22314,
                            false => 22315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22316,
                            false => 22317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22318,
                            false => 22319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22320,
                            false => 22321,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22322,
                            false => 22323,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22324,
                            false => 22325,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22326,
                            false => 22327,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22328,
                            false => 22329,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22330,
                            false => 22331,
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
            22252 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22253 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22254 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22255 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22256 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22257 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22258 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22259 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22260 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22261 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22262 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22263 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22264 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22265 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22266 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22267 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22268 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22269 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22270 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22271 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22272 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22273 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22274 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22275 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22276 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22277 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22278 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22279 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22280 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22281 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22282 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22283 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22284 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22285 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22286 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22287 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22288 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22289 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22290 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22291 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22292 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22293 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22294 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22295 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22296 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22297 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22298 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22299 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22300 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22301 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22302 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22303 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22304 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22305 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22306 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22307 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22308 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22309 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22310 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22311 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22312 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22313 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22314 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22315 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22316 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22317 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22318 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22319 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22320 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22321 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22322 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22323 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22324 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22325 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22326 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22327 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22328 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22329 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22330 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22331 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
