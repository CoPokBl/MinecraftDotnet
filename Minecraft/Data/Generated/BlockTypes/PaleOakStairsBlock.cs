using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakStairsBlock(Identifier Identifier, Direction Facing, PaleOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.pale_oak_stairs", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_stairs", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 14, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88);
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

    public BlockStateInfo StateInfo => States[StateId - 12212];

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
                            true => 12212,
                            false => 12213,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12214,
                            false => 12215,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12216,
                            false => 12217,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12218,
                            false => 12219,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12220,
                            false => 12221,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12222,
                            false => 12223,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12224,
                            false => 12225,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12226,
                            false => 12227,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12228,
                            false => 12229,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12230,
                            false => 12231,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12232,
                            false => 12233,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12234,
                            false => 12235,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12236,
                            false => 12237,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12238,
                            false => 12239,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12240,
                            false => 12241,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12242,
                            false => 12243,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12244,
                            false => 12245,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12246,
                            false => 12247,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12248,
                            false => 12249,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12250,
                            false => 12251,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12252,
                            false => 12253,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12254,
                            false => 12255,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12256,
                            false => 12257,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12258,
                            false => 12259,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12260,
                            false => 12261,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12262,
                            false => 12263,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12264,
                            false => 12265,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12266,
                            false => 12267,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12268,
                            false => 12269,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12270,
                            false => 12271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12272,
                            false => 12273,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12274,
                            false => 12275,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12276,
                            false => 12277,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12278,
                            false => 12279,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12280,
                            false => 12281,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12282,
                            false => 12283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12284,
                            false => 12285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12286,
                            false => 12287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12288,
                            false => 12289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12290,
                            false => 12291,
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
            12212 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12213 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12214 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12215 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12216 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12217 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12218 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12219 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12220 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12221 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12222 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12223 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12224 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12225 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12226 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12227 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12228 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12229 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12230 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12231 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12232 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12233 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12234 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12235 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12236 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12237 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12238 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12239 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12240 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12241 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12242 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12243 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12244 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12245 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12246 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12247 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12248 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12249 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12250 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12251 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12252 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12253 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12254 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12255 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12256 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12257 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12258 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12259 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12260 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12261 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12262 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12263 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12264 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12265 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12266 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12267 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12268 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12269 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12270 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12271 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12272 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12273 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12274 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12275 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12276 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12277 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12278 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12279 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12280 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12281 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12282 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12283 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12284 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12285 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12286 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12287 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12288 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12289 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12290 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12291 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
