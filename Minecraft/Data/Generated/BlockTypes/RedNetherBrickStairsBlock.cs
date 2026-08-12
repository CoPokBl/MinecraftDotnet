using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedNetherBrickStairsBlock(Identifier Identifier, Direction Facing, RedNetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.red_nether_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_nether_brick_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 35, "nether_bricks", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 16176];

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
                            true => 16176,
                            false => 16177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16178,
                            false => 16179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16180,
                            false => 16181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16182,
                            false => 16183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16184,
                            false => 16185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16186,
                            false => 16187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16188,
                            false => 16189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16190,
                            false => 16191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16192,
                            false => 16193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16194,
                            false => 16195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16196,
                            false => 16197,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16198,
                            false => 16199,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16200,
                            false => 16201,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16202,
                            false => 16203,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16204,
                            false => 16205,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16206,
                            false => 16207,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16208,
                            false => 16209,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16210,
                            false => 16211,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16212,
                            false => 16213,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16214,
                            false => 16215,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16216,
                            false => 16217,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16218,
                            false => 16219,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16220,
                            false => 16221,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16222,
                            false => 16223,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16224,
                            false => 16225,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16226,
                            false => 16227,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16228,
                            false => 16229,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16230,
                            false => 16231,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16232,
                            false => 16233,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16234,
                            false => 16235,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16236,
                            false => 16237,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16238,
                            false => 16239,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16240,
                            false => 16241,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16242,
                            false => 16243,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16244,
                            false => 16245,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16246,
                            false => 16247,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16248,
                            false => 16249,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16250,
                            false => 16251,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16252,
                            false => 16253,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16254,
                            false => 16255,
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
            16176 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16177 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16178 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16179 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16180 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16181 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16182 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16183 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16184 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16185 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16186 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16187 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16188 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16189 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16190 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16191 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16192 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16193 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16194 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16195 => new RedNetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16196 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16197 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16198 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16199 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16200 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16201 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16202 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16203 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16204 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16205 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16206 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16207 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16208 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16209 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16210 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16211 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16212 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16213 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16214 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16215 => new RedNetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16216 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16217 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16218 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16219 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16220 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16221 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16222 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16223 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16224 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16225 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16226 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16227 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16228 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16229 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16230 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16231 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16232 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16233 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16234 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16235 => new RedNetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16236 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16237 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16238 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16239 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16240 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16241 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16242 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16243 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16244 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16245 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16246 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16247 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16248 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16249 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16250 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16251 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16252 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16253 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16254 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16255 => new RedNetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
