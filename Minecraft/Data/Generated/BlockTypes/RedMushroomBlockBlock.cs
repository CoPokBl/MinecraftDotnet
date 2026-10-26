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
public record RedMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.red_mushroom_block", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_mushroom_block", BlockInfo.VanillaOnly, "minecraft:blocks/red_mushroom_block");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 15, PushReaction.PushPull, 28, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
                                    true => 9564,
                                    false => 9565,
                                },
                                false => West switch {
                                    true => 9566,
                                    false => 9567,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9568,
                                    false => 9569,
                                },
                                false => West switch {
                                    true => 9570,
                                    false => 9571,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9572,
                                    false => 9573,
                                },
                                false => West switch {
                                    true => 9574,
                                    false => 9575,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9576,
                                    false => 9577,
                                },
                                false => West switch {
                                    true => 9578,
                                    false => 9579,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9580,
                                    false => 9581,
                                },
                                false => West switch {
                                    true => 9582,
                                    false => 9583,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9584,
                                    false => 9585,
                                },
                                false => West switch {
                                    true => 9586,
                                    false => 9587,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9588,
                                    false => 9589,
                                },
                                false => West switch {
                                    true => 9590,
                                    false => 9591,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9592,
                                    false => 9593,
                                },
                                false => West switch {
                                    true => 9594,
                                    false => 9595,
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
                                    true => 9596,
                                    false => 9597,
                                },
                                false => West switch {
                                    true => 9598,
                                    false => 9599,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9600,
                                    false => 9601,
                                },
                                false => West switch {
                                    true => 9602,
                                    false => 9603,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9604,
                                    false => 9605,
                                },
                                false => West switch {
                                    true => 9606,
                                    false => 9607,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9608,
                                    false => 9609,
                                },
                                false => West switch {
                                    true => 9610,
                                    false => 9611,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9612,
                                    false => 9613,
                                },
                                false => West switch {
                                    true => 9614,
                                    false => 9615,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9616,
                                    false => 9617,
                                },
                                false => West switch {
                                    true => 9618,
                                    false => 9619,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9620,
                                    false => 9621,
                                },
                                false => West switch {
                                    true => 9622,
                                    false => 9623,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9624,
                                    false => 9625,
                                },
                                false => West switch {
                                    true => 9626,
                                    false => 9627,
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
            9564 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            9565 => new RedMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            9566 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            9567 => new RedMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            9568 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            9569 => new RedMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            9570 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            9571 => new RedMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            9572 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            9573 => new RedMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            9574 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            9575 => new RedMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            9576 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            9577 => new RedMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            9578 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            9579 => new RedMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            9580 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            9581 => new RedMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            9582 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            9583 => new RedMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            9584 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            9585 => new RedMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            9586 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            9587 => new RedMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            9588 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            9589 => new RedMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            9590 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            9591 => new RedMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            9592 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            9593 => new RedMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            9594 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            9595 => new RedMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            9596 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            9597 => new RedMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            9598 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            9599 => new RedMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            9600 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            9601 => new RedMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            9602 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            9603 => new RedMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            9604 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            9605 => new RedMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            9606 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            9607 => new RedMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            9608 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            9609 => new RedMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            9610 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            9611 => new RedMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            9612 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            9613 => new RedMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            9614 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            9615 => new RedMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            9616 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            9617 => new RedMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            9618 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            9619 => new RedMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            9620 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            9621 => new RedMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            9622 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            9623 => new RedMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            9624 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            9625 => new RedMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            9626 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            9627 => new RedMushroomBlockBlock(Identifier, false, false, false, false, false, false),
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
