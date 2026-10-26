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
public record OxidizedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock, IWaterlogged, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.oxidized_copper_bars", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oxidized_copper_bars", BlockInfo.VanillaOnly, "minecraft:blocks/oxidized_copper_bars");
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.PushPull, 0, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S372, BlockShapes.S372, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S372);
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

    public BlockStateInfo StateInfo => States[StateId - 9820];

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
                                true => 9820,
                                false => 9821,
                            },
                            false => West switch {
                                true => 9822,
                                false => 9823,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9824,
                                false => 9825,
                            },
                            false => West switch {
                                true => 9826,
                                false => 9827,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9828,
                                false => 9829,
                            },
                            false => West switch {
                                true => 9830,
                                false => 9831,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9832,
                                false => 9833,
                            },
                            false => West switch {
                                true => 9834,
                                false => 9835,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9836,
                                false => 9837,
                            },
                            false => West switch {
                                true => 9838,
                                false => 9839,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9840,
                                false => 9841,
                            },
                            false => West switch {
                                true => 9842,
                                false => 9843,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9844,
                                false => 9845,
                            },
                            false => West switch {
                                true => 9846,
                                false => 9847,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9848,
                                false => 9849,
                            },
                            false => West switch {
                                true => 9850,
                                false => 9851,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9820 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, true),
            9821 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, false),
            9822 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, true),
            9823 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, false),
            9824 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, true),
            9825 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, false),
            9826 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, true),
            9827 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, false),
            9828 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, true),
            9829 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, false),
            9830 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, true),
            9831 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, false),
            9832 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, true),
            9833 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, false),
            9834 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, true),
            9835 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, false),
            9836 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, true),
            9837 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, false),
            9838 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, true),
            9839 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, false),
            9840 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, true),
            9841 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, false),
            9842 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, true),
            9843 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, false),
            9844 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, true),
            9845 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, false),
            9846 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, true),
            9847 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, false),
            9848 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, true),
            9849 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, false),
            9850 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, true),
            9851 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, false),
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
