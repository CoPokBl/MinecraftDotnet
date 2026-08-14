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
    private static readonly BlockInfo Data = new("minecraft:vine", "block.minecraft.vine", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:vine", BlockInfo.VanillaOnly, "minecraft:blocks/vine");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Destroy, 7, "vine", NoteBlockInstrument.Harp, true, false, false, false, true, false, false, true, false, false, false, true, false, false, true, true, false, true, [], null, BlockShapes.S529, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S530 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S531 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S532 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S533 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S534 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S535 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S536 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S537 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S538 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S539 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S540 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S541 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S542 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S543 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S544 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S545 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S546 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S547 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S548 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S549 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S550 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S551 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S552 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S553 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S554 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S555 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S556 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S557 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S558 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S559 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 8358];

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
                                true => 8358,
                                false => 8359,
                            },
                            false => West switch {
                                true => 8360,
                                false => 8361,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8362,
                                false => 8363,
                            },
                            false => West switch {
                                true => 8364,
                                false => 8365,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8366,
                                false => 8367,
                            },
                            false => West switch {
                                true => 8368,
                                false => 8369,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8370,
                                false => 8371,
                            },
                            false => West switch {
                                true => 8372,
                                false => 8373,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8374,
                                false => 8375,
                            },
                            false => West switch {
                                true => 8376,
                                false => 8377,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8378,
                                false => 8379,
                            },
                            false => West switch {
                                true => 8380,
                                false => 8381,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8382,
                                false => 8383,
                            },
                            false => West switch {
                                true => 8384,
                                false => 8385,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8386,
                                false => 8387,
                            },
                            false => West switch {
                                true => 8388,
                                false => 8389,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8358 => new VineBlock(Identifier, true, true, true, true, true),
            8359 => new VineBlock(Identifier, true, true, true, true, false),
            8360 => new VineBlock(Identifier, true, true, true, false, true),
            8361 => new VineBlock(Identifier, true, true, true, false, false),
            8362 => new VineBlock(Identifier, true, true, false, true, true),
            8363 => new VineBlock(Identifier, true, true, false, true, false),
            8364 => new VineBlock(Identifier, true, true, false, false, true),
            8365 => new VineBlock(Identifier, true, true, false, false, false),
            8366 => new VineBlock(Identifier, true, false, true, true, true),
            8367 => new VineBlock(Identifier, true, false, true, true, false),
            8368 => new VineBlock(Identifier, true, false, true, false, true),
            8369 => new VineBlock(Identifier, true, false, true, false, false),
            8370 => new VineBlock(Identifier, true, false, false, true, true),
            8371 => new VineBlock(Identifier, true, false, false, true, false),
            8372 => new VineBlock(Identifier, true, false, false, false, true),
            8373 => new VineBlock(Identifier, true, false, false, false, false),
            8374 => new VineBlock(Identifier, false, true, true, true, true),
            8375 => new VineBlock(Identifier, false, true, true, true, false),
            8376 => new VineBlock(Identifier, false, true, true, false, true),
            8377 => new VineBlock(Identifier, false, true, true, false, false),
            8378 => new VineBlock(Identifier, false, true, false, true, true),
            8379 => new VineBlock(Identifier, false, true, false, true, false),
            8380 => new VineBlock(Identifier, false, true, false, false, true),
            8381 => new VineBlock(Identifier, false, true, false, false, false),
            8382 => new VineBlock(Identifier, false, false, true, true, true),
            8383 => new VineBlock(Identifier, false, false, true, true, false),
            8384 => new VineBlock(Identifier, false, false, true, false, true),
            8385 => new VineBlock(Identifier, false, false, true, false, false),
            8386 => new VineBlock(Identifier, false, false, false, true, true),
            8387 => new VineBlock(Identifier, false, false, false, true, false),
            8388 => new VineBlock(Identifier, false, false, false, false, true),
            8389 => new VineBlock(Identifier, false, false, false, false, false),
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
