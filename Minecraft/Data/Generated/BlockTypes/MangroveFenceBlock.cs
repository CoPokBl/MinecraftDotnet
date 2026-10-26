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
public record MangroveFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_fence", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_fence", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_fence");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 28, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S21, BlockShapes.S22, BlockShapes.S1, BlockShapes.S23, BlockShapes.S21, BlockShapes.S22);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S24, CollisionShape = BlockShapes.S25, OcclusionShape = BlockShapes.S26, VisualShape = BlockShapes.S24, SupportShape = BlockShapes.S25 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S24, CollisionShape = BlockShapes.S25, OcclusionShape = BlockShapes.S26, VisualShape = BlockShapes.S24, SupportShape = BlockShapes.S25 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S27, CollisionShape = BlockShapes.S28, OcclusionShape = BlockShapes.S29, VisualShape = BlockShapes.S27, SupportShape = BlockShapes.S28 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S30, CollisionShape = BlockShapes.S31, OcclusionShape = BlockShapes.S32, VisualShape = BlockShapes.S30, SupportShape = BlockShapes.S31 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S27, CollisionShape = BlockShapes.S28, OcclusionShape = BlockShapes.S29, VisualShape = BlockShapes.S27, SupportShape = BlockShapes.S28 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S30, CollisionShape = BlockShapes.S31, OcclusionShape = BlockShapes.S32, VisualShape = BlockShapes.S30, SupportShape = BlockShapes.S31 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S33, CollisionShape = BlockShapes.S34, OcclusionShape = BlockShapes.S35, VisualShape = BlockShapes.S33, SupportShape = BlockShapes.S34 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S36, CollisionShape = BlockShapes.S37, OcclusionShape = BlockShapes.S38, VisualShape = BlockShapes.S36, SupportShape = BlockShapes.S37 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S33, CollisionShape = BlockShapes.S34, OcclusionShape = BlockShapes.S35, VisualShape = BlockShapes.S33, SupportShape = BlockShapes.S34 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S36, CollisionShape = BlockShapes.S37, OcclusionShape = BlockShapes.S38, VisualShape = BlockShapes.S36, SupportShape = BlockShapes.S37 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S41, VisualShape = BlockShapes.S39, SupportShape = BlockShapes.S40 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S42, CollisionShape = BlockShapes.S43, OcclusionShape = BlockShapes.S44, VisualShape = BlockShapes.S42, SupportShape = BlockShapes.S43 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S41, VisualShape = BlockShapes.S39, SupportShape = BlockShapes.S40 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S42, CollisionShape = BlockShapes.S43, OcclusionShape = BlockShapes.S44, VisualShape = BlockShapes.S42, SupportShape = BlockShapes.S43 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S45, CollisionShape = BlockShapes.S46, OcclusionShape = BlockShapes.S47, VisualShape = BlockShapes.S45, SupportShape = BlockShapes.S46 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S50, VisualShape = BlockShapes.S48, SupportShape = BlockShapes.S49 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S45, CollisionShape = BlockShapes.S46, OcclusionShape = BlockShapes.S47, VisualShape = BlockShapes.S45, SupportShape = BlockShapes.S46 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S50, VisualShape = BlockShapes.S48, SupportShape = BlockShapes.S49 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S51, CollisionShape = BlockShapes.S52, OcclusionShape = BlockShapes.S53, VisualShape = BlockShapes.S51, SupportShape = BlockShapes.S52 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S54, CollisionShape = BlockShapes.S55, OcclusionShape = BlockShapes.S56, VisualShape = BlockShapes.S54, SupportShape = BlockShapes.S55 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S51, CollisionShape = BlockShapes.S52, OcclusionShape = BlockShapes.S53, VisualShape = BlockShapes.S51, SupportShape = BlockShapes.S52 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S54, CollisionShape = BlockShapes.S55, OcclusionShape = BlockShapes.S56, VisualShape = BlockShapes.S54, SupportShape = BlockShapes.S55 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S57, CollisionShape = BlockShapes.S58, OcclusionShape = BlockShapes.S59, VisualShape = BlockShapes.S57, SupportShape = BlockShapes.S58 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S60, CollisionShape = BlockShapes.S61, OcclusionShape = BlockShapes.S62, VisualShape = BlockShapes.S60, SupportShape = BlockShapes.S61 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S57, CollisionShape = BlockShapes.S58, OcclusionShape = BlockShapes.S59, VisualShape = BlockShapes.S57, SupportShape = BlockShapes.S58 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S60, CollisionShape = BlockShapes.S61, OcclusionShape = BlockShapes.S62, VisualShape = BlockShapes.S60, SupportShape = BlockShapes.S61 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S63, CollisionShape = BlockShapes.S64, OcclusionShape = BlockShapes.S65, VisualShape = BlockShapes.S63, SupportShape = BlockShapes.S64 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S67, OcclusionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S67 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S63, CollisionShape = BlockShapes.S64, OcclusionShape = BlockShapes.S65, VisualShape = BlockShapes.S63, SupportShape = BlockShapes.S64 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S67, OcclusionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S67 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 15875];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };

    public bool HasFace(BlockFace face) => face is BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 15875,
                                false => 15876,
                            },
                            false => West switch {
                                true => 15877,
                                false => 15878,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 15879,
                                false => 15880,
                            },
                            false => West switch {
                                true => 15881,
                                false => 15882,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 15883,
                                false => 15884,
                            },
                            false => West switch {
                                true => 15885,
                                false => 15886,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 15887,
                                false => 15888,
                            },
                            false => West switch {
                                true => 15889,
                                false => 15890,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 15891,
                                false => 15892,
                            },
                            false => West switch {
                                true => 15893,
                                false => 15894,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 15895,
                                false => 15896,
                            },
                            false => West switch {
                                true => 15897,
                                false => 15898,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 15899,
                                false => 15900,
                            },
                            false => West switch {
                                true => 15901,
                                false => 15902,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 15903,
                                false => 15904,
                            },
                            false => West switch {
                                true => 15905,
                                false => 15906,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15875 => new MangroveFenceBlock(Identifier, true, true, true, true, true),
            15876 => new MangroveFenceBlock(Identifier, true, true, true, true, false),
            15877 => new MangroveFenceBlock(Identifier, true, true, true, false, true),
            15878 => new MangroveFenceBlock(Identifier, true, true, true, false, false),
            15879 => new MangroveFenceBlock(Identifier, true, true, false, true, true),
            15880 => new MangroveFenceBlock(Identifier, true, true, false, true, false),
            15881 => new MangroveFenceBlock(Identifier, true, true, false, false, true),
            15882 => new MangroveFenceBlock(Identifier, true, true, false, false, false),
            15883 => new MangroveFenceBlock(Identifier, true, false, true, true, true),
            15884 => new MangroveFenceBlock(Identifier, true, false, true, true, false),
            15885 => new MangroveFenceBlock(Identifier, true, false, true, false, true),
            15886 => new MangroveFenceBlock(Identifier, true, false, true, false, false),
            15887 => new MangroveFenceBlock(Identifier, true, false, false, true, true),
            15888 => new MangroveFenceBlock(Identifier, true, false, false, true, false),
            15889 => new MangroveFenceBlock(Identifier, true, false, false, false, true),
            15890 => new MangroveFenceBlock(Identifier, true, false, false, false, false),
            15891 => new MangroveFenceBlock(Identifier, false, true, true, true, true),
            15892 => new MangroveFenceBlock(Identifier, false, true, true, true, false),
            15893 => new MangroveFenceBlock(Identifier, false, true, true, false, true),
            15894 => new MangroveFenceBlock(Identifier, false, true, true, false, false),
            15895 => new MangroveFenceBlock(Identifier, false, true, false, true, true),
            15896 => new MangroveFenceBlock(Identifier, false, true, false, true, false),
            15897 => new MangroveFenceBlock(Identifier, false, true, false, false, true),
            15898 => new MangroveFenceBlock(Identifier, false, true, false, false, false),
            15899 => new MangroveFenceBlock(Identifier, false, false, true, true, true),
            15900 => new MangroveFenceBlock(Identifier, false, false, true, true, false),
            15901 => new MangroveFenceBlock(Identifier, false, false, true, false, true),
            15902 => new MangroveFenceBlock(Identifier, false, false, true, false, false),
            15903 => new MangroveFenceBlock(Identifier, false, false, false, true, true),
            15904 => new MangroveFenceBlock(Identifier, false, false, false, true, false),
            15905 => new MangroveFenceBlock(Identifier, false, false, false, false, true),
            15906 => new MangroveFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
