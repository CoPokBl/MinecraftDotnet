using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedAndesiteStairsBlock(Identifier Identifier, Direction Facing, PolishedAndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.polished_andesite_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_andesite_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 16256];

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
                            true => 16256,
                            false => 16257,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16258,
                            false => 16259,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16260,
                            false => 16261,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16262,
                            false => 16263,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16264,
                            false => 16265,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16266,
                            false => 16267,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16268,
                            false => 16269,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16270,
                            false => 16271,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16272,
                            false => 16273,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16274,
                            false => 16275,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16276,
                            false => 16277,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16278,
                            false => 16279,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16280,
                            false => 16281,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16282,
                            false => 16283,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16284,
                            false => 16285,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16286,
                            false => 16287,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16288,
                            false => 16289,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16290,
                            false => 16291,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16292,
                            false => 16293,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16294,
                            false => 16295,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16296,
                            false => 16297,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16298,
                            false => 16299,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16300,
                            false => 16301,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16302,
                            false => 16303,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16304,
                            false => 16305,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16306,
                            false => 16307,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16308,
                            false => 16309,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16310,
                            false => 16311,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16312,
                            false => 16313,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16314,
                            false => 16315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16316,
                            false => 16317,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16318,
                            false => 16319,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16320,
                            false => 16321,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16322,
                            false => 16323,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16324,
                            false => 16325,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16326,
                            false => 16327,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16328,
                            false => 16329,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16330,
                            false => 16331,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16332,
                            false => 16333,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16334,
                            false => 16335,
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
            16256 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16257 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16258 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16259 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16260 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16261 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16262 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16263 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16264 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16265 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16266 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16267 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16268 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16269 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16270 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16271 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16272 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16273 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16274 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16275 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16276 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16277 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16278 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16279 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16280 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16281 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16282 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16283 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16284 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16285 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16286 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16287 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16288 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16289 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16290 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16291 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16292 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16293 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16294 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16295 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16296 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16297 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16298 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16299 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16300 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16301 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16302 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16303 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16304 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16305 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16306 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16307 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16308 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16309 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16310 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16311 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16312 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16313 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16314 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16315 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16316 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16317 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16318 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16319 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16320 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16321 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16322 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16323 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16324 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16325 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16326 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16327 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16328 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16329 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16330 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16331 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16332 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16333 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16334 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16335 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
