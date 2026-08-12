using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickStairsBlock(Identifier Identifier, Direction Facing, ResinBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.resin_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:resin_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 37, "resin_bricks", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 8923];

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
                            true => 8923,
                            false => 8924,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8925,
                            false => 8926,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8927,
                            false => 8928,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8929,
                            false => 8930,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8931,
                            false => 8932,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8933,
                            false => 8934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8935,
                            false => 8936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8937,
                            false => 8938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8939,
                            false => 8940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8941,
                            false => 8942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8943,
                            false => 8944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8945,
                            false => 8946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8947,
                            false => 8948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8949,
                            false => 8950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8951,
                            false => 8952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8953,
                            false => 8954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8955,
                            false => 8956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8957,
                            false => 8958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8959,
                            false => 8960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8961,
                            false => 8962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8963,
                            false => 8964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8965,
                            false => 8966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8967,
                            false => 8968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8969,
                            false => 8970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8971,
                            false => 8972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8973,
                            false => 8974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8975,
                            false => 8976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8977,
                            false => 8978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8979,
                            false => 8980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8981,
                            false => 8982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8983,
                            false => 8984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8985,
                            false => 8986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8987,
                            false => 8988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8989,
                            false => 8990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8991,
                            false => 8992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8993,
                            false => 8994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8995,
                            false => 8996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8997,
                            false => 8998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8999,
                            false => 9000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9001,
                            false => 9002,
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
            8923 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8924 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8925 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8926 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8927 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8928 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8929 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8930 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8931 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8932 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8933 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8934 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8935 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8936 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8937 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8938 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8939 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8940 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8941 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8942 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8943 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8944 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8945 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8946 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8947 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8948 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8949 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8950 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8951 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8952 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8953 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8954 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8955 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8956 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8957 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8958 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8959 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8960 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8961 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8962 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8963 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8964 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8965 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8966 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8967 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8968 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8969 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8970 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8971 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8972 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8973 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8974 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8975 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8976 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8977 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8978 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8979 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8980 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8981 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8982 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8983 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8984 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8985 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8986 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8987 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8988 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8989 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8990 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8991 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8992 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8993 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8994 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8995 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8996 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8997 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8998 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8999 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9000 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9001 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9002 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
