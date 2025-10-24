using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownMushroomBlockBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:huge_mushroom";
    public int ProtocolId => 337;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:brown_mushroom_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.brown_mushroom_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7565,
                                    false => 7566,
                                },
                                false => West switch {
                                    true => 7567,
                                    false => 7568,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7569,
                                    false => 7570,
                                },
                                false => West switch {
                                    true => 7571,
                                    false => 7572,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7573,
                                    false => 7574,
                                },
                                false => West switch {
                                    true => 7575,
                                    false => 7576,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7577,
                                    false => 7578,
                                },
                                false => West switch {
                                    true => 7579,
                                    false => 7580,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7581,
                                    false => 7582,
                                },
                                false => West switch {
                                    true => 7583,
                                    false => 7584,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7585,
                                    false => 7586,
                                },
                                false => West switch {
                                    true => 7587,
                                    false => 7588,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7589,
                                    false => 7590,
                                },
                                false => West switch {
                                    true => 7591,
                                    false => 7592,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7593,
                                    false => 7594,
                                },
                                false => West switch {
                                    true => 7595,
                                    false => 7596,
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
                                    true => 7597,
                                    false => 7598,
                                },
                                false => West switch {
                                    true => 7599,
                                    false => 7600,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7601,
                                    false => 7602,
                                },
                                false => West switch {
                                    true => 7603,
                                    false => 7604,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7605,
                                    false => 7606,
                                },
                                false => West switch {
                                    true => 7607,
                                    false => 7608,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7609,
                                    false => 7610,
                                },
                                false => West switch {
                                    true => 7611,
                                    false => 7612,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7613,
                                    false => 7614,
                                },
                                false => West switch {
                                    true => 7615,
                                    false => 7616,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7617,
                                    false => 7618,
                                },
                                false => West switch {
                                    true => 7619,
                                    false => 7620,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7621,
                                    false => 7622,
                                },
                                false => West switch {
                                    true => 7623,
                                    false => 7624,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7625,
                                    false => 7626,
                                },
                                false => West switch {
                                    true => 7627,
                                    false => 7628,
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
            7565 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, true),
            7566 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, true, false),
            7567 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, true),
            7568 => new BrownMushroomBlockBlock(Identifier, true, true, true, true, false, false),
            7569 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, true),
            7570 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, true, false),
            7571 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, true),
            7572 => new BrownMushroomBlockBlock(Identifier, true, true, true, false, false, false),
            7573 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, true),
            7574 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, true, false),
            7575 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, true),
            7576 => new BrownMushroomBlockBlock(Identifier, true, true, false, true, false, false),
            7577 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, true),
            7578 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, true, false),
            7579 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, true),
            7580 => new BrownMushroomBlockBlock(Identifier, true, true, false, false, false, false),
            7581 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, true),
            7582 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, true, false),
            7583 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, true),
            7584 => new BrownMushroomBlockBlock(Identifier, true, false, true, true, false, false),
            7585 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, true),
            7586 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, true, false),
            7587 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, true),
            7588 => new BrownMushroomBlockBlock(Identifier, true, false, true, false, false, false),
            7589 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, true),
            7590 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, true, false),
            7591 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, true),
            7592 => new BrownMushroomBlockBlock(Identifier, true, false, false, true, false, false),
            7593 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, true),
            7594 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, true, false),
            7595 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, true),
            7596 => new BrownMushroomBlockBlock(Identifier, true, false, false, false, false, false),
            7597 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, true),
            7598 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, true, false),
            7599 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, true),
            7600 => new BrownMushroomBlockBlock(Identifier, false, true, true, true, false, false),
            7601 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, true),
            7602 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, true, false),
            7603 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, true),
            7604 => new BrownMushroomBlockBlock(Identifier, false, true, true, false, false, false),
            7605 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, true),
            7606 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, true, false),
            7607 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, true),
            7608 => new BrownMushroomBlockBlock(Identifier, false, true, false, true, false, false),
            7609 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, true),
            7610 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, true, false),
            7611 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, true),
            7612 => new BrownMushroomBlockBlock(Identifier, false, true, false, false, false, false),
            7613 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, true),
            7614 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, true, false),
            7615 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, true),
            7616 => new BrownMushroomBlockBlock(Identifier, false, false, true, true, false, false),
            7617 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, true),
            7618 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, true, false),
            7619 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, true),
            7620 => new BrownMushroomBlockBlock(Identifier, false, false, true, false, false, false),
            7621 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, true),
            7622 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, true, false),
            7623 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, true),
            7624 => new BrownMushroomBlockBlock(Identifier, false, false, false, true, false, false),
            7625 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, true),
            7626 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, true, false),
            7627 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, true),
            7628 => new BrownMushroomBlockBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.ChildrenMap.ContainsKey("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("down", Down.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
