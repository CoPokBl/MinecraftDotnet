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
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_tuff_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_tuff_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_tuff_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 43, "polished_tuff", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 27227];

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
                            true => 27227,
                            false => 27228,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27229,
                            false => 27230,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27231,
                            false => 27232,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27233,
                            false => 27234,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27235,
                            false => 27236,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27237,
                            false => 27238,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27239,
                            false => 27240,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27241,
                            false => 27242,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27243,
                            false => 27244,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27245,
                            false => 27246,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27247,
                            false => 27248,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27249,
                            false => 27250,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27251,
                            false => 27252,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27253,
                            false => 27254,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27255,
                            false => 27256,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27257,
                            false => 27258,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27259,
                            false => 27260,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27261,
                            false => 27262,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27263,
                            false => 27264,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27265,
                            false => 27266,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27267,
                            false => 27268,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27269,
                            false => 27270,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27271,
                            false => 27272,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27273,
                            false => 27274,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27275,
                            false => 27276,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27277,
                            false => 27278,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27279,
                            false => 27280,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27281,
                            false => 27282,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27283,
                            false => 27284,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27285,
                            false => 27286,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27287,
                            false => 27288,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27289,
                            false => 27290,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27291,
                            false => 27292,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27293,
                            false => 27294,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27295,
                            false => 27296,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27297,
                            false => 27298,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27299,
                            false => 27300,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27301,
                            false => 27302,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27303,
                            false => 27304,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27305,
                            false => 27306,
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
            27227 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            27228 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            27229 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            27230 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            27231 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            27232 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            27233 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            27234 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            27235 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            27236 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            27237 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            27238 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            27239 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            27240 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            27241 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            27242 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            27243 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            27244 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            27245 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            27246 => new PolishedTuffStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            27247 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            27248 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            27249 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            27250 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            27251 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            27252 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            27253 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            27254 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            27255 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            27256 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            27257 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            27258 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            27259 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            27260 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            27261 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            27262 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            27263 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            27264 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            27265 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            27266 => new PolishedTuffStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            27267 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            27268 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            27269 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            27270 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            27271 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            27272 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            27273 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            27274 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            27275 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            27276 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            27277 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            27278 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            27279 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            27280 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            27281 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            27282 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            27283 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            27284 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            27285 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            27286 => new PolishedTuffStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            27287 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            27288 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            27289 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            27290 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            27291 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            27292 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            27293 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            27294 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            27295 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            27296 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            27297 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            27298 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            27299 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            27300 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            27301 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            27302 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            27303 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            27304 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            27305 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            27306 => new PolishedTuffStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
