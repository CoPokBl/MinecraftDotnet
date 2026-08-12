using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickStairsBlock(Identifier Identifier, Direction Facing, NetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.nether_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:nether_brick_stairs", BlockInfo.VanillaOnly);
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

    public BlockStateInfo StateInfo => States[StateId - 9367];

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
                            true => 9367,
                            false => 9368,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9369,
                            false => 9370,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9371,
                            false => 9372,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9373,
                            false => 9374,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9375,
                            false => 9376,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9377,
                            false => 9378,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9379,
                            false => 9380,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9381,
                            false => 9382,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9383,
                            false => 9384,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9385,
                            false => 9386,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9387,
                            false => 9388,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9389,
                            false => 9390,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9391,
                            false => 9392,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9393,
                            false => 9394,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9395,
                            false => 9396,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9397,
                            false => 9398,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9399,
                            false => 9400,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9401,
                            false => 9402,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9403,
                            false => 9404,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9405,
                            false => 9406,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9407,
                            false => 9408,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9409,
                            false => 9410,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9411,
                            false => 9412,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9413,
                            false => 9414,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9415,
                            false => 9416,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9417,
                            false => 9418,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9419,
                            false => 9420,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9421,
                            false => 9422,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9423,
                            false => 9424,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9425,
                            false => 9426,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9427,
                            false => 9428,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9429,
                            false => 9430,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9431,
                            false => 9432,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9433,
                            false => 9434,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9435,
                            false => 9436,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9437,
                            false => 9438,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9439,
                            false => 9440,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9441,
                            false => 9442,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9443,
                            false => 9444,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9445,
                            false => 9446,
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
            9367 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9368 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9369 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9370 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9371 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9372 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9373 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9374 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9375 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9376 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9377 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9378 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9379 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9380 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9381 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9382 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9383 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9384 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9385 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9386 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9387 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9388 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9389 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9390 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9391 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9392 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9393 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9394 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9395 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9396 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9397 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9398 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9399 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9400 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9401 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9402 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9403 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9404 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9405 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9406 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9407 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9408 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9409 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9410 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9411 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9412 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9413 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9414 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9415 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9416 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9417 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9418 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9419 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9420 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9421 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9422 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9423 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9424 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9425 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9426 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9427 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9428 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9429 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9430 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9431 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9432 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9433 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9434 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9435 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9436 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9437 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9438 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9439 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9440 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9441 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9442 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9443 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9444 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9445 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9446 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
