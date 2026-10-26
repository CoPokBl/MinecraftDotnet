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
public record BrownMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.brown_mushroom_block", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:brown_mushroom_block", BlockInfo.VanillaOnly, "minecraft:blocks/brown_mushroom_block");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 15, PushReaction.PushPull, 10, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

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

    public bool HasFace(BlockFace face) => face is BlockFace.NegY or BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.NegY => Down,
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.NegY => this with { Down = connected },
        BlockFace.PosY => this with { Up = connected },
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9500,
                                    false => 9501,
                                },
                                false => West switch {
                                    true => 9502,
                                    false => 9503,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9504,
                                    false => 9505,
                                },
                                false => West switch {
                                    true => 9506,
                                    false => 9507,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9508,
                                    false => 9509,
                                },
                                false => West switch {
                                    true => 9510,
                                    false => 9511,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9512,
                                    false => 9513,
                                },
                                false => West switch {
                                    true => 9514,
                                    false => 9515,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9516,
                                    false => 9517,
                                },
                                false => West switch {
                                    true => 9518,
                                    false => 9519,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9520,
                                    false => 9521,
                                },
                                false => West switch {
                                    true => 9522,
                                    false => 9523,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9524,
                                    false => 9525,
                                },
                                false => West switch {
                                    true => 9526,
                                    false => 9527,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9528,
                                    false => 9529,
                                },
                                false => West switch {
                                    true => 9530,
                                    false => 9531,
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9532,
                                    false => 9533,
                                },
                                false => West switch {
                                    true => 9534,
                                    false => 9535,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9536,
                                    false => 9537,
                                },
                                false => West switch {
                                    true => 9538,
                                    false => 9539,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9540,
                                    false => 9541,
                                },
                                false => West switch {
                                    true => 9542,
                                    false => 9543,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9544,
                                    false => 9545,
                                },
                                false => West switch {
                                    true => 9546,
                                    false => 9547,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9548,
                                    false => 9549,
                                },
                                false => West switch {
                                    true => 9550,
                                    false => 9551,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9552,
                                    false => 9553,
                                },
                                false => West switch {
                                    true => 9554,
                                    false => 9555,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9556,
                                    false => 9557,
                                },
                                false => West switch {
                                    true => 9558,
                                    false => 9559,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9560,
                                    false => 9561,
                                },
                                false => West switch {
                                    true => 9562,
                                    false => 9563,
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9500 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            9501 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            9502 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            9503 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            9504 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            9505 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            9506 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            9507 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            9508 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            9509 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            9510 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            9511 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            9512 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            9513 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            9514 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            9515 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            9516 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            9517 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            9518 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            9519 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            9520 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            9521 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            9522 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            9523 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            9524 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            9525 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            9526 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            9527 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            9528 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            9529 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            9530 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            9531 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            9532 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            9533 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            9534 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            9535 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            9536 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            9537 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            9538 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            9539 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            9540 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            9541 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            9542 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            9543 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            9544 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            9545 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            9546 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            9547 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            9548 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            9549 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            9550 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            9551 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            9552 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            9553 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            9554 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            9555 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            9556 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            9557 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            9558 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            9559 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            9560 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            9561 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            9562 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            9563 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.Contains("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("down", new StringTag(Down.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
