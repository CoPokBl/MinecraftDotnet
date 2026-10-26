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
public record PolishedBlackstoneBrickStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.polished_blackstone_brick_stairs", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_brick_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/polished_blackstone_brick_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 25609];

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
                            true => 25609,
                            false => 25610,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25611,
                            false => 25612,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25613,
                            false => 25614,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25615,
                            false => 25616,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25617,
                            false => 25618,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25619,
                            false => 25620,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25621,
                            false => 25622,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25623,
                            false => 25624,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25625,
                            false => 25626,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25627,
                            false => 25628,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25629,
                            false => 25630,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25631,
                            false => 25632,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25633,
                            false => 25634,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25635,
                            false => 25636,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25637,
                            false => 25638,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25639,
                            false => 25640,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25641,
                            false => 25642,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25643,
                            false => 25644,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25645,
                            false => 25646,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25647,
                            false => 25648,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25649,
                            false => 25650,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25651,
                            false => 25652,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25653,
                            false => 25654,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25655,
                            false => 25656,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25657,
                            false => 25658,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25659,
                            false => 25660,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25661,
                            false => 25662,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25663,
                            false => 25664,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25665,
                            false => 25666,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25667,
                            false => 25668,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25669,
                            false => 25670,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25671,
                            false => 25672,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25673,
                            false => 25674,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25675,
                            false => 25676,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25677,
                            false => 25678,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25679,
                            false => 25680,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25681,
                            false => 25682,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25683,
                            false => 25684,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25685,
                            false => 25686,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25687,
                            false => 25688,
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
            25609 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            25610 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            25611 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            25612 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            25613 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            25614 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            25615 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            25616 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            25617 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            25618 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            25619 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            25620 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            25621 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            25622 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            25623 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            25624 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            25625 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            25626 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            25627 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            25628 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            25629 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            25630 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            25631 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            25632 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            25633 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            25634 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            25635 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            25636 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            25637 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            25638 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            25639 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            25640 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            25641 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            25642 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            25643 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            25644 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            25645 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            25646 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            25647 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            25648 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            25649 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            25650 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            25651 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            25652 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            25653 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            25654 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            25655 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            25656 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            25657 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            25658 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            25659 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            25660 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            25661 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            25662 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            25663 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            25664 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            25665 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            25666 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            25667 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            25668 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            25669 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            25670 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            25671 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            25672 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            25673 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            25674 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            25675 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            25676 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            25677 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            25678 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            25679 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            25680 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            25681 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            25682 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            25683 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            25684 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            25685 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            25686 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            25687 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            25688 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
