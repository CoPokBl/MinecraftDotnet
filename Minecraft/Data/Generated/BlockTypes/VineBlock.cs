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
public record VineBlock(Identifier Identifier, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.vine", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:vine", BlockInfo.VanillaOnly, "minecraft:blocks/vine");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Popped, 7, "vine", NoteBlockInstrument.Harp, true, false, false, true, false, false, true, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S530, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S560 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 10092];

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

    public bool HasFace(BlockFace face) => face is BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.PosY => this with { Up = connected },
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
                        true => Up switch {
                            true => West switch {
                                true => 10092,
                                false => 10093,
                            },
                            false => West switch {
                                true => 10094,
                                false => 10095,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 10096,
                                false => 10097,
                            },
                            false => West switch {
                                true => 10098,
                                false => 10099,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 10100,
                                false => 10101,
                            },
                            false => West switch {
                                true => 10102,
                                false => 10103,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 10104,
                                false => 10105,
                            },
                            false => West switch {
                                true => 10106,
                                false => 10107,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 10108,
                                false => 10109,
                            },
                            false => West switch {
                                true => 10110,
                                false => 10111,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 10112,
                                false => 10113,
                            },
                            false => West switch {
                                true => 10114,
                                false => 10115,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 10116,
                                false => 10117,
                            },
                            false => West switch {
                                true => 10118,
                                false => 10119,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 10120,
                                false => 10121,
                            },
                            false => West switch {
                                true => 10122,
                                false => 10123,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10092 => new VineBlock(Identifier, true, true, true, true, true),
            10093 => new VineBlock(Identifier, true, true, true, true, false),
            10094 => new VineBlock(Identifier, true, true, true, false, true),
            10095 => new VineBlock(Identifier, true, true, true, false, false),
            10096 => new VineBlock(Identifier, true, true, false, true, true),
            10097 => new VineBlock(Identifier, true, true, false, true, false),
            10098 => new VineBlock(Identifier, true, true, false, false, true),
            10099 => new VineBlock(Identifier, true, true, false, false, false),
            10100 => new VineBlock(Identifier, true, false, true, true, true),
            10101 => new VineBlock(Identifier, true, false, true, true, false),
            10102 => new VineBlock(Identifier, true, false, true, false, true),
            10103 => new VineBlock(Identifier, true, false, true, false, false),
            10104 => new VineBlock(Identifier, true, false, false, true, true),
            10105 => new VineBlock(Identifier, true, false, false, true, false),
            10106 => new VineBlock(Identifier, true, false, false, false, true),
            10107 => new VineBlock(Identifier, true, false, false, false, false),
            10108 => new VineBlock(Identifier, false, true, true, true, true),
            10109 => new VineBlock(Identifier, false, true, true, true, false),
            10110 => new VineBlock(Identifier, false, true, true, false, true),
            10111 => new VineBlock(Identifier, false, true, true, false, false),
            10112 => new VineBlock(Identifier, false, true, false, true, true),
            10113 => new VineBlock(Identifier, false, true, false, true, false),
            10114 => new VineBlock(Identifier, false, true, false, false, true),
            10115 => new VineBlock(Identifier, false, true, false, false, false),
            10116 => new VineBlock(Identifier, false, false, true, true, true),
            10117 => new VineBlock(Identifier, false, false, true, true, false),
            10118 => new VineBlock(Identifier, false, false, true, false, true),
            10119 => new VineBlock(Identifier, false, false, true, false, false),
            10120 => new VineBlock(Identifier, false, false, false, true, true),
            10121 => new VineBlock(Identifier, false, false, false, true, false),
            10122 => new VineBlock(Identifier, false, false, false, false, true),
            10123 => new VineBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
