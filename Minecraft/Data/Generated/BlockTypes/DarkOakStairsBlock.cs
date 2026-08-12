using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakStairsBlock(Identifier Identifier, Direction Facing, DarkOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.dark_oak_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 26, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 12132];

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
                            true => 12132,
                            false => 12133,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12134,
                            false => 12135,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12136,
                            false => 12137,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12138,
                            false => 12139,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12140,
                            false => 12141,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12142,
                            false => 12143,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12144,
                            false => 12145,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12146,
                            false => 12147,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12148,
                            false => 12149,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12150,
                            false => 12151,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12152,
                            false => 12153,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12154,
                            false => 12155,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12156,
                            false => 12157,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12158,
                            false => 12159,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12160,
                            false => 12161,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12162,
                            false => 12163,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12164,
                            false => 12165,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12166,
                            false => 12167,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12168,
                            false => 12169,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12170,
                            false => 12171,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12172,
                            false => 12173,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12174,
                            false => 12175,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12176,
                            false => 12177,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12178,
                            false => 12179,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12180,
                            false => 12181,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12182,
                            false => 12183,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12184,
                            false => 12185,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12186,
                            false => 12187,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12188,
                            false => 12189,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12190,
                            false => 12191,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12192,
                            false => 12193,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12194,
                            false => 12195,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12196,
                            false => 12197,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12198,
                            false => 12199,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12200,
                            false => 12201,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12202,
                            false => 12203,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12204,
                            false => 12205,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12206,
                            false => 12207,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12208,
                            false => 12209,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12210,
                            false => 12211,
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
            12132 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12133 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12134 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12135 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12136 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12137 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12138 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12139 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12140 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12141 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12142 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12143 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12144 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12145 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12146 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12147 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12148 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12149 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12150 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12151 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12152 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12153 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12154 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12155 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12156 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12157 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12158 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12159 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12160 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12161 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12162 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12163 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12164 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12165 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12166 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12167 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12168 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12169 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12170 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12171 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12172 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12173 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12174 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12175 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12176 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12177 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12178 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12179 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12180 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12181 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12182 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12183 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12184 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12185 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12186 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12187 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12188 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12189 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12190 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12191 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12192 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12193 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12194 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12195 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12196 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12197 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12198 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12199 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12200 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12201 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12202 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12203 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12204 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12205 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12206 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12207 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12208 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12209 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12210 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12211 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
