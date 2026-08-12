using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:fence", "block.minecraft.dark_oak_fence", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_fence", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 26, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S21, BlockShapes.S22, BlockShapes.S1, BlockShapes.S23, BlockShapes.S21);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S24, CollisionShape = BlockShapes.S25, OcclusionShape = BlockShapes.S26, VisualShape = BlockShapes.S24 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S24, CollisionShape = BlockShapes.S25, OcclusionShape = BlockShapes.S26, VisualShape = BlockShapes.S24 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S27, CollisionShape = BlockShapes.S28, OcclusionShape = BlockShapes.S29, VisualShape = BlockShapes.S27 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S30, CollisionShape = BlockShapes.S31, OcclusionShape = BlockShapes.S32, VisualShape = BlockShapes.S30 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S27, CollisionShape = BlockShapes.S28, OcclusionShape = BlockShapes.S29, VisualShape = BlockShapes.S27 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S30, CollisionShape = BlockShapes.S31, OcclusionShape = BlockShapes.S32, VisualShape = BlockShapes.S30 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S33, CollisionShape = BlockShapes.S34, OcclusionShape = BlockShapes.S35, VisualShape = BlockShapes.S33 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S36, CollisionShape = BlockShapes.S37, OcclusionShape = BlockShapes.S38, VisualShape = BlockShapes.S36 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S33, CollisionShape = BlockShapes.S34, OcclusionShape = BlockShapes.S35, VisualShape = BlockShapes.S33 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S36, CollisionShape = BlockShapes.S37, OcclusionShape = BlockShapes.S38, VisualShape = BlockShapes.S36 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S41, VisualShape = BlockShapes.S39 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S42, CollisionShape = BlockShapes.S43, OcclusionShape = BlockShapes.S44, VisualShape = BlockShapes.S42 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S41, VisualShape = BlockShapes.S39 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S42, CollisionShape = BlockShapes.S43, OcclusionShape = BlockShapes.S44, VisualShape = BlockShapes.S42 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S45, CollisionShape = BlockShapes.S46, OcclusionShape = BlockShapes.S47, VisualShape = BlockShapes.S45 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S50, VisualShape = BlockShapes.S48 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S45, CollisionShape = BlockShapes.S46, OcclusionShape = BlockShapes.S47, VisualShape = BlockShapes.S45 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S50, VisualShape = BlockShapes.S48 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S51, CollisionShape = BlockShapes.S52, OcclusionShape = BlockShapes.S53, VisualShape = BlockShapes.S51 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S54, CollisionShape = BlockShapes.S55, OcclusionShape = BlockShapes.S56, VisualShape = BlockShapes.S54 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S51, CollisionShape = BlockShapes.S52, OcclusionShape = BlockShapes.S53, VisualShape = BlockShapes.S51 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S54, CollisionShape = BlockShapes.S55, OcclusionShape = BlockShapes.S56, VisualShape = BlockShapes.S54 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S57, CollisionShape = BlockShapes.S58, OcclusionShape = BlockShapes.S59, VisualShape = BlockShapes.S57 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S60, CollisionShape = BlockShapes.S61, OcclusionShape = BlockShapes.S62, VisualShape = BlockShapes.S60 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S57, CollisionShape = BlockShapes.S58, OcclusionShape = BlockShapes.S59, VisualShape = BlockShapes.S57 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S60, CollisionShape = BlockShapes.S61, OcclusionShape = BlockShapes.S62, VisualShape = BlockShapes.S60 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S63, CollisionShape = BlockShapes.S64, OcclusionShape = BlockShapes.S65, VisualShape = BlockShapes.S63 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S67, OcclusionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S63, CollisionShape = BlockShapes.S64, OcclusionShape = BlockShapes.S65, VisualShape = BlockShapes.S63 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S67, OcclusionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 13932];

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
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13932,
                                false => 13933,
                            },
                            false => West switch {
                                true => 13934,
                                false => 13935,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13936,
                                false => 13937,
                            },
                            false => West switch {
                                true => 13938,
                                false => 13939,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13940,
                                false => 13941,
                            },
                            false => West switch {
                                true => 13942,
                                false => 13943,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13944,
                                false => 13945,
                            },
                            false => West switch {
                                true => 13946,
                                false => 13947,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13948,
                                false => 13949,
                            },
                            false => West switch {
                                true => 13950,
                                false => 13951,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13952,
                                false => 13953,
                            },
                            false => West switch {
                                true => 13954,
                                false => 13955,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13956,
                                false => 13957,
                            },
                            false => West switch {
                                true => 13958,
                                false => 13959,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13960,
                                false => 13961,
                            },
                            false => West switch {
                                true => 13962,
                                false => 13963,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13932 => new DarkOakFenceBlock(Identifier, true, true, true, true, true),
            13933 => new DarkOakFenceBlock(Identifier, true, true, true, true, false),
            13934 => new DarkOakFenceBlock(Identifier, true, true, true, false, true),
            13935 => new DarkOakFenceBlock(Identifier, true, true, true, false, false),
            13936 => new DarkOakFenceBlock(Identifier, true, true, false, true, true),
            13937 => new DarkOakFenceBlock(Identifier, true, true, false, true, false),
            13938 => new DarkOakFenceBlock(Identifier, true, true, false, false, true),
            13939 => new DarkOakFenceBlock(Identifier, true, true, false, false, false),
            13940 => new DarkOakFenceBlock(Identifier, true, false, true, true, true),
            13941 => new DarkOakFenceBlock(Identifier, true, false, true, true, false),
            13942 => new DarkOakFenceBlock(Identifier, true, false, true, false, true),
            13943 => new DarkOakFenceBlock(Identifier, true, false, true, false, false),
            13944 => new DarkOakFenceBlock(Identifier, true, false, false, true, true),
            13945 => new DarkOakFenceBlock(Identifier, true, false, false, true, false),
            13946 => new DarkOakFenceBlock(Identifier, true, false, false, false, true),
            13947 => new DarkOakFenceBlock(Identifier, true, false, false, false, false),
            13948 => new DarkOakFenceBlock(Identifier, false, true, true, true, true),
            13949 => new DarkOakFenceBlock(Identifier, false, true, true, true, false),
            13950 => new DarkOakFenceBlock(Identifier, false, true, true, false, true),
            13951 => new DarkOakFenceBlock(Identifier, false, true, true, false, false),
            13952 => new DarkOakFenceBlock(Identifier, false, true, false, true, true),
            13953 => new DarkOakFenceBlock(Identifier, false, true, false, true, false),
            13954 => new DarkOakFenceBlock(Identifier, false, true, false, false, true),
            13955 => new DarkOakFenceBlock(Identifier, false, true, false, false, false),
            13956 => new DarkOakFenceBlock(Identifier, false, false, true, true, true),
            13957 => new DarkOakFenceBlock(Identifier, false, false, true, true, false),
            13958 => new DarkOakFenceBlock(Identifier, false, false, true, false, true),
            13959 => new DarkOakFenceBlock(Identifier, false, false, true, false, false),
            13960 => new DarkOakFenceBlock(Identifier, false, false, false, true, true),
            13961 => new DarkOakFenceBlock(Identifier, false, false, false, true, false),
            13962 => new DarkOakFenceBlock(Identifier, false, false, false, false, true),
            13963 => new DarkOakFenceBlock(Identifier, false, false, false, false, false),
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
