using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:iron_bars", "block.minecraft.waxed_copper_bars", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_copper_bars", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.Normal, 0, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S370, BlockShapes.S370, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S371, CollisionShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S371, CollisionShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S372, CollisionShape = BlockShapes.S372 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S373, CollisionShape = BlockShapes.S373 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S372, CollisionShape = BlockShapes.S372 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S373, CollisionShape = BlockShapes.S373 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S374, CollisionShape = BlockShapes.S374 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S375, CollisionShape = BlockShapes.S375 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S374, CollisionShape = BlockShapes.S374 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S375, CollisionShape = BlockShapes.S375 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S376, CollisionShape = BlockShapes.S376 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S377, CollisionShape = BlockShapes.S377 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S376, CollisionShape = BlockShapes.S376 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S377, CollisionShape = BlockShapes.S377 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S378, CollisionShape = BlockShapes.S378 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S379, CollisionShape = BlockShapes.S379 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S378, CollisionShape = BlockShapes.S378 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S379, CollisionShape = BlockShapes.S379 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S380, CollisionShape = BlockShapes.S380 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S381, CollisionShape = BlockShapes.S381 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S380, CollisionShape = BlockShapes.S380 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S381, CollisionShape = BlockShapes.S381 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S382, CollisionShape = BlockShapes.S382 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S383, CollisionShape = BlockShapes.S383 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S382, CollisionShape = BlockShapes.S382 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S383, CollisionShape = BlockShapes.S383 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S384, CollisionShape = BlockShapes.S384 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S385, CollisionShape = BlockShapes.S385 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S384, CollisionShape = BlockShapes.S384 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S385, CollisionShape = BlockShapes.S385 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 8118];

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
                                true => 8118,
                                false => 8119,
                            },
                            false => West switch {
                                true => 8120,
                                false => 8121,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8122,
                                false => 8123,
                            },
                            false => West switch {
                                true => 8124,
                                false => 8125,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8126,
                                false => 8127,
                            },
                            false => West switch {
                                true => 8128,
                                false => 8129,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8130,
                                false => 8131,
                            },
                            false => West switch {
                                true => 8132,
                                false => 8133,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8134,
                                false => 8135,
                            },
                            false => West switch {
                                true => 8136,
                                false => 8137,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8138,
                                false => 8139,
                            },
                            false => West switch {
                                true => 8140,
                                false => 8141,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8142,
                                false => 8143,
                            },
                            false => West switch {
                                true => 8144,
                                false => 8145,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8146,
                                false => 8147,
                            },
                            false => West switch {
                                true => 8148,
                                false => 8149,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8118 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, true),
            8119 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, false),
            8120 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, true),
            8121 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, false),
            8122 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, true),
            8123 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, false),
            8124 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, true),
            8125 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, false),
            8126 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, true),
            8127 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, false),
            8128 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, true),
            8129 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, false),
            8130 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, true),
            8131 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, false),
            8132 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, true),
            8133 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, false),
            8134 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, true),
            8135 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, false),
            8136 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, true),
            8137 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, false),
            8138 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, true),
            8139 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, false),
            8140 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, true),
            8141 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, false),
            8142 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, true),
            8143 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, false),
            8144 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, true),
            8145 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, false),
            8146 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, true),
            8147 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, false),
            8148 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, true),
            8149 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, false),
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
