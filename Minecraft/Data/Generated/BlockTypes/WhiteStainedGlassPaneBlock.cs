using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stained_glass_pane", "block.minecraft.white_stained_glass_pane", 0.3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:white_stained_glass_pane", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.3f, 0, 1, PushReaction.Normal, 0, "glass", NoteBlockInstrument.Hat, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S370, BlockShapes.S370, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 11460];

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
                                true => 11460,
                                false => 11461,
                            },
                            false => West switch {
                                true => 11462,
                                false => 11463,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11464,
                                false => 11465,
                            },
                            false => West switch {
                                true => 11466,
                                false => 11467,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11468,
                                false => 11469,
                            },
                            false => West switch {
                                true => 11470,
                                false => 11471,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11472,
                                false => 11473,
                            },
                            false => West switch {
                                true => 11474,
                                false => 11475,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11476,
                                false => 11477,
                            },
                            false => West switch {
                                true => 11478,
                                false => 11479,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11480,
                                false => 11481,
                            },
                            false => West switch {
                                true => 11482,
                                false => 11483,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11484,
                                false => 11485,
                            },
                            false => West switch {
                                true => 11486,
                                false => 11487,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11488,
                                false => 11489,
                            },
                            false => West switch {
                                true => 11490,
                                false => 11491,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11460 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11461 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11462 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11463 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11464 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11465 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11466 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11467 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11468 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11469 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11470 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11471 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11472 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11473 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11474 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11475 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11476 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11477 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11478 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11479 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11480 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11481 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11482 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11483 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11484 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11485 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11486 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11487 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11488 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11489 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11490 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11491 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
