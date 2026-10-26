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
public record ExposedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.exposed_copper_bars", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_copper_bars", BlockInfo.VanillaOnly, "minecraft:blocks/exposed_copper_bars");
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.PushPull, 0, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S372, BlockShapes.S372, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S372);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S373, CollisionShape = BlockShapes.S373, SupportShape = BlockShapes.S373 };
    private static readonly BlockStateInfo I2 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S373, CollisionShape = BlockShapes.S373, SupportShape = BlockShapes.S373 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S374, CollisionShape = BlockShapes.S374, SupportShape = BlockShapes.S374 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S375, CollisionShape = BlockShapes.S375, SupportShape = BlockShapes.S375 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S374, CollisionShape = BlockShapes.S374, SupportShape = BlockShapes.S374 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S375, CollisionShape = BlockShapes.S375, SupportShape = BlockShapes.S375 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S376, CollisionShape = BlockShapes.S376, SupportShape = BlockShapes.S376 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S377, CollisionShape = BlockShapes.S377, SupportShape = BlockShapes.S377 };
    private static readonly BlockStateInfo I10 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S376, CollisionShape = BlockShapes.S376, SupportShape = BlockShapes.S376 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S377, CollisionShape = BlockShapes.S377, SupportShape = BlockShapes.S377 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S378, CollisionShape = BlockShapes.S378, SupportShape = BlockShapes.S378 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S379, CollisionShape = BlockShapes.S379, SupportShape = BlockShapes.S379 };
    private static readonly BlockStateInfo I14 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S378, CollisionShape = BlockShapes.S378, SupportShape = BlockShapes.S378 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S379, CollisionShape = BlockShapes.S379, SupportShape = BlockShapes.S379 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S380, CollisionShape = BlockShapes.S380, SupportShape = BlockShapes.S380 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S381, CollisionShape = BlockShapes.S381, SupportShape = BlockShapes.S381 };
    private static readonly BlockStateInfo I18 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S380, CollisionShape = BlockShapes.S380, SupportShape = BlockShapes.S380 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S381, CollisionShape = BlockShapes.S381, SupportShape = BlockShapes.S381 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S382, CollisionShape = BlockShapes.S382, SupportShape = BlockShapes.S382 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S383, CollisionShape = BlockShapes.S383, SupportShape = BlockShapes.S383 };
    private static readonly BlockStateInfo I22 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S382, CollisionShape = BlockShapes.S382, SupportShape = BlockShapes.S382 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S383, CollisionShape = BlockShapes.S383, SupportShape = BlockShapes.S383 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S384, CollisionShape = BlockShapes.S384, SupportShape = BlockShapes.S384 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S385, CollisionShape = BlockShapes.S385, SupportShape = BlockShapes.S385 };
    private static readonly BlockStateInfo I26 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S384, CollisionShape = BlockShapes.S384, SupportShape = BlockShapes.S384 };
    private static readonly BlockStateInfo I27 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S385, CollisionShape = BlockShapes.S385, SupportShape = BlockShapes.S385 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S386, CollisionShape = BlockShapes.S386, SupportShape = BlockShapes.S386 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S387, CollisionShape = BlockShapes.S387, SupportShape = BlockShapes.S387 };
    private static readonly BlockStateInfo I30 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S386, CollisionShape = BlockShapes.S386, SupportShape = BlockShapes.S386 };
    private static readonly BlockStateInfo I31 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S387, CollisionShape = BlockShapes.S387, SupportShape = BlockShapes.S387 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 9756];

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
                                true => 9756,
                                false => 9757,
                            },
                            false => West switch {
                                true => 9758,
                                false => 9759,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9760,
                                false => 9761,
                            },
                            false => West switch {
                                true => 9762,
                                false => 9763,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9764,
                                false => 9765,
                            },
                            false => West switch {
                                true => 9766,
                                false => 9767,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9768,
                                false => 9769,
                            },
                            false => West switch {
                                true => 9770,
                                false => 9771,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9772,
                                false => 9773,
                            },
                            false => West switch {
                                true => 9774,
                                false => 9775,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9776,
                                false => 9777,
                            },
                            false => West switch {
                                true => 9778,
                                false => 9779,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9780,
                                false => 9781,
                            },
                            false => West switch {
                                true => 9782,
                                false => 9783,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9784,
                                false => 9785,
                            },
                            false => West switch {
                                true => 9786,
                                false => 9787,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9756 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, true),
            9757 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, false),
            9758 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, true),
            9759 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, false),
            9760 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, true),
            9761 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, false),
            9762 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, true),
            9763 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, false),
            9764 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, true),
            9765 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, false),
            9766 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, true),
            9767 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, false),
            9768 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, true),
            9769 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, false),
            9770 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, true),
            9771 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, false),
            9772 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, true),
            9773 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, false),
            9774 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, true),
            9775 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, false),
            9776 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, true),
            9777 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, false),
            9778 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, true),
            9779 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, false),
            9780 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, true),
            9781 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, false),
            9782 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, true),
            9783 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, false),
            9784 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, true),
            9785 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, false),
            9786 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, true),
            9787 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, false),
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
