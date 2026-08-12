using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryStairsBlock(Identifier Identifier, Direction Facing, CherryStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.cherry_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 36, "cherry_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 12052];

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
                            true => 12052,
                            false => 12053,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12054,
                            false => 12055,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12056,
                            false => 12057,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12058,
                            false => 12059,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12060,
                            false => 12061,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12062,
                            false => 12063,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12064,
                            false => 12065,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12066,
                            false => 12067,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12068,
                            false => 12069,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12070,
                            false => 12071,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12072,
                            false => 12073,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12074,
                            false => 12075,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12076,
                            false => 12077,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12078,
                            false => 12079,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12080,
                            false => 12081,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12082,
                            false => 12083,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12084,
                            false => 12085,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12086,
                            false => 12087,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12088,
                            false => 12089,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12090,
                            false => 12091,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12092,
                            false => 12093,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12094,
                            false => 12095,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12096,
                            false => 12097,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12098,
                            false => 12099,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12100,
                            false => 12101,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12102,
                            false => 12103,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12104,
                            false => 12105,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12106,
                            false => 12107,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12108,
                            false => 12109,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12110,
                            false => 12111,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12112,
                            false => 12113,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12114,
                            false => 12115,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12116,
                            false => 12117,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12118,
                            false => 12119,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12120,
                            false => 12121,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12122,
                            false => 12123,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12124,
                            false => 12125,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12126,
                            false => 12127,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12128,
                            false => 12129,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12130,
                            false => 12131,
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
            12052 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12053 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12054 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12055 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12056 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12057 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12058 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12059 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12060 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12061 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12062 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12063 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12064 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12065 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12066 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12067 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12068 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12069 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12070 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12071 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12072 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12073 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12074 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12075 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12076 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12077 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12078 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12079 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12080 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12081 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12082 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12083 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12084 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12085 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12086 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12087 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12088 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12089 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12090 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12091 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12092 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12093 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12094 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12095 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12096 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12097 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12098 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12099 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12100 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12101 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12102 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12103 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12104 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12105 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12106 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12107 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12108 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12109 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12110 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12111 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12112 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12113 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12114 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12115 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12116 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12117 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12118 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12119 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12120 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12121 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12122 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12123 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12124 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12125 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12126 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12127 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12128 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12129 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12130 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12131 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
