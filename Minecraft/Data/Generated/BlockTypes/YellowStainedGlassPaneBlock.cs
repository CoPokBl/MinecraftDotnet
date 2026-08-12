using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stained_glass_pane", "block.minecraft.yellow_stained_glass_pane", 0.3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:yellow_stained_glass_pane", BlockInfo.VanillaOnly);
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

    public BlockStateInfo StateInfo => States[StateId - 11588];

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
                                true => 11588,
                                false => 11589,
                            },
                            false => West switch {
                                true => 11590,
                                false => 11591,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11592,
                                false => 11593,
                            },
                            false => West switch {
                                true => 11594,
                                false => 11595,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11596,
                                false => 11597,
                            },
                            false => West switch {
                                true => 11598,
                                false => 11599,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11600,
                                false => 11601,
                            },
                            false => West switch {
                                true => 11602,
                                false => 11603,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11604,
                                false => 11605,
                            },
                            false => West switch {
                                true => 11606,
                                false => 11607,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11608,
                                false => 11609,
                            },
                            false => West switch {
                                true => 11610,
                                false => 11611,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11612,
                                false => 11613,
                            },
                            false => West switch {
                                true => 11614,
                                false => 11615,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11616,
                                false => 11617,
                            },
                            false => West switch {
                                true => 11618,
                                false => 11619,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11588 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11589 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11590 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11591 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11592 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11593 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11594 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11595 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11596 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11597 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11598 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11599 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11600 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11601 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11602 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11603 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11604 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11605 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11606 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11607 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11608 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11609 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11610 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11611 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11612 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11613 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11614 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11615 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11616 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11617 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11618 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11619 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
