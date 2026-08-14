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
public record PurpurStairsBlock(Identifier Identifier, Direction Facing, TopBottom Half, StairShape Shape, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IStairShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:stair", "block.minecraft.purpur_stairs", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:purpur_stairs", BlockInfo.VanillaOnly, "minecraft:blocks/purpur_stairs");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 16, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, null, "minecraft:water", BlockShapes.S90, BlockShapes.S90, BlockShapes.S1, BlockShapes.S90, BlockShapes.S90, BlockShapes.S90);
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

    public BlockStateInfo StateInfo => States[StateId - 14716];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                            true => 14716,
                            false => 14717,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14718,
                            false => 14719,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14720,
                            false => 14721,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14722,
                            false => 14723,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14724,
                            false => 14725,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14726,
                            false => 14727,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14728,
                            false => 14729,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14730,
                            false => 14731,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14732,
                            false => 14733,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14734,
                            false => 14735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14736,
                            false => 14737,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14738,
                            false => 14739,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14740,
                            false => 14741,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14742,
                            false => 14743,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14744,
                            false => 14745,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14746,
                            false => 14747,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14748,
                            false => 14749,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14750,
                            false => 14751,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14752,
                            false => 14753,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14754,
                            false => 14755,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14756,
                            false => 14757,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14758,
                            false => 14759,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14760,
                            false => 14761,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14762,
                            false => 14763,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14764,
                            false => 14765,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14766,
                            false => 14767,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14768,
                            false => 14769,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14770,
                            false => 14771,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14772,
                            false => 14773,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14774,
                            false => 14775,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14776,
                            false => 14777,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14778,
                            false => 14779,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14780,
                            false => 14781,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14782,
                            false => 14783,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14784,
                            false => 14785,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    TopBottom.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14786,
                            false => 14787,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14788,
                            false => 14789,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14790,
                            false => 14791,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14792,
                            false => 14793,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14794,
                            false => 14795,
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
            14716 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, true),
            14717 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.Straight, false),
            14718 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, true),
            14719 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerLeft, false),
            14720 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, true),
            14721 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.InnerRight, false),
            14722 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, true),
            14723 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterLeft, false),
            14724 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, true),
            14725 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Top, StairShape.OuterRight, false),
            14726 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, true),
            14727 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.Straight, false),
            14728 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, true),
            14729 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerLeft, false),
            14730 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, true),
            14731 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.InnerRight, false),
            14732 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, true),
            14733 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterLeft, false),
            14734 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, true),
            14735 => new PurpurStairsBlock(Identifier, Direction.North, TopBottom.Bottom, StairShape.OuterRight, false),
            14736 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, true),
            14737 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.Straight, false),
            14738 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, true),
            14739 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerLeft, false),
            14740 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, true),
            14741 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.InnerRight, false),
            14742 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, true),
            14743 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterLeft, false),
            14744 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, true),
            14745 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Top, StairShape.OuterRight, false),
            14746 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, true),
            14747 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.Straight, false),
            14748 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, true),
            14749 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerLeft, false),
            14750 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, true),
            14751 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.InnerRight, false),
            14752 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, true),
            14753 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterLeft, false),
            14754 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, true),
            14755 => new PurpurStairsBlock(Identifier, Direction.South, TopBottom.Bottom, StairShape.OuterRight, false),
            14756 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, true),
            14757 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.Straight, false),
            14758 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, true),
            14759 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerLeft, false),
            14760 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, true),
            14761 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.InnerRight, false),
            14762 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, true),
            14763 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterLeft, false),
            14764 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, true),
            14765 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Top, StairShape.OuterRight, false),
            14766 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, true),
            14767 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.Straight, false),
            14768 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, true),
            14769 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerLeft, false),
            14770 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, true),
            14771 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.InnerRight, false),
            14772 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, true),
            14773 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterLeft, false),
            14774 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, true),
            14775 => new PurpurStairsBlock(Identifier, Direction.West, TopBottom.Bottom, StairShape.OuterRight, false),
            14776 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, true),
            14777 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.Straight, false),
            14778 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, true),
            14779 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerLeft, false),
            14780 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, true),
            14781 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.InnerRight, false),
            14782 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, true),
            14783 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterLeft, false),
            14784 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, true),
            14785 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Top, StairShape.OuterRight, false),
            14786 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, true),
            14787 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.Straight, false),
            14788 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, true),
            14789 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerLeft, false),
            14790 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, true),
            14791 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.InnerRight, false),
            14792 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, true),
            14793 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterLeft, false),
            14794 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, true),
            14795 => new PurpurStairsBlock(Identifier, Direction.East, TopBottom.Bottom, StairShape.OuterRight, false),
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
