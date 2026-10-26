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
public record MushroomStemBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("block.minecraft.mushroom_stem", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mushroom_stem", BlockInfo.VanillaOnly, "minecraft:blocks/mushroom_stem");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 15, PushReaction.PushPull, 3, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
                                    true => 9628,
                                    false => 9629,
                                },
                                false => West switch {
                                    true => 9630,
                                    false => 9631,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9632,
                                    false => 9633,
                                },
                                false => West switch {
                                    true => 9634,
                                    false => 9635,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9636,
                                    false => 9637,
                                },
                                false => West switch {
                                    true => 9638,
                                    false => 9639,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9640,
                                    false => 9641,
                                },
                                false => West switch {
                                    true => 9642,
                                    false => 9643,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9644,
                                    false => 9645,
                                },
                                false => West switch {
                                    true => 9646,
                                    false => 9647,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9648,
                                    false => 9649,
                                },
                                false => West switch {
                                    true => 9650,
                                    false => 9651,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9652,
                                    false => 9653,
                                },
                                false => West switch {
                                    true => 9654,
                                    false => 9655,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9656,
                                    false => 9657,
                                },
                                false => West switch {
                                    true => 9658,
                                    false => 9659,
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
                                    true => 9660,
                                    false => 9661,
                                },
                                false => West switch {
                                    true => 9662,
                                    false => 9663,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9664,
                                    false => 9665,
                                },
                                false => West switch {
                                    true => 9666,
                                    false => 9667,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9668,
                                    false => 9669,
                                },
                                false => West switch {
                                    true => 9670,
                                    false => 9671,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9672,
                                    false => 9673,
                                },
                                false => West switch {
                                    true => 9674,
                                    false => 9675,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9676,
                                    false => 9677,
                                },
                                false => West switch {
                                    true => 9678,
                                    false => 9679,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9680,
                                    false => 9681,
                                },
                                false => West switch {
                                    true => 9682,
                                    false => 9683,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 9684,
                                    false => 9685,
                                },
                                false => West switch {
                                    true => 9686,
                                    false => 9687,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 9688,
                                    false => 9689,
                                },
                                false => West switch {
                                    true => 9690,
                                    false => 9691,
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
            9628 => new MushroomStemBlock(Identifier, true, true, true, true, true, true),
            9629 => new MushroomStemBlock(Identifier, true, true, true, true, true, false),
            9630 => new MushroomStemBlock(Identifier, true, true, true, true, false, true),
            9631 => new MushroomStemBlock(Identifier, true, true, true, true, false, false),
            9632 => new MushroomStemBlock(Identifier, true, true, true, false, true, true),
            9633 => new MushroomStemBlock(Identifier, true, true, true, false, true, false),
            9634 => new MushroomStemBlock(Identifier, true, true, true, false, false, true),
            9635 => new MushroomStemBlock(Identifier, true, true, true, false, false, false),
            9636 => new MushroomStemBlock(Identifier, true, true, false, true, true, true),
            9637 => new MushroomStemBlock(Identifier, true, true, false, true, true, false),
            9638 => new MushroomStemBlock(Identifier, true, true, false, true, false, true),
            9639 => new MushroomStemBlock(Identifier, true, true, false, true, false, false),
            9640 => new MushroomStemBlock(Identifier, true, true, false, false, true, true),
            9641 => new MushroomStemBlock(Identifier, true, true, false, false, true, false),
            9642 => new MushroomStemBlock(Identifier, true, true, false, false, false, true),
            9643 => new MushroomStemBlock(Identifier, true, true, false, false, false, false),
            9644 => new MushroomStemBlock(Identifier, true, false, true, true, true, true),
            9645 => new MushroomStemBlock(Identifier, true, false, true, true, true, false),
            9646 => new MushroomStemBlock(Identifier, true, false, true, true, false, true),
            9647 => new MushroomStemBlock(Identifier, true, false, true, true, false, false),
            9648 => new MushroomStemBlock(Identifier, true, false, true, false, true, true),
            9649 => new MushroomStemBlock(Identifier, true, false, true, false, true, false),
            9650 => new MushroomStemBlock(Identifier, true, false, true, false, false, true),
            9651 => new MushroomStemBlock(Identifier, true, false, true, false, false, false),
            9652 => new MushroomStemBlock(Identifier, true, false, false, true, true, true),
            9653 => new MushroomStemBlock(Identifier, true, false, false, true, true, false),
            9654 => new MushroomStemBlock(Identifier, true, false, false, true, false, true),
            9655 => new MushroomStemBlock(Identifier, true, false, false, true, false, false),
            9656 => new MushroomStemBlock(Identifier, true, false, false, false, true, true),
            9657 => new MushroomStemBlock(Identifier, true, false, false, false, true, false),
            9658 => new MushroomStemBlock(Identifier, true, false, false, false, false, true),
            9659 => new MushroomStemBlock(Identifier, true, false, false, false, false, false),
            9660 => new MushroomStemBlock(Identifier, false, true, true, true, true, true),
            9661 => new MushroomStemBlock(Identifier, false, true, true, true, true, false),
            9662 => new MushroomStemBlock(Identifier, false, true, true, true, false, true),
            9663 => new MushroomStemBlock(Identifier, false, true, true, true, false, false),
            9664 => new MushroomStemBlock(Identifier, false, true, true, false, true, true),
            9665 => new MushroomStemBlock(Identifier, false, true, true, false, true, false),
            9666 => new MushroomStemBlock(Identifier, false, true, true, false, false, true),
            9667 => new MushroomStemBlock(Identifier, false, true, true, false, false, false),
            9668 => new MushroomStemBlock(Identifier, false, true, false, true, true, true),
            9669 => new MushroomStemBlock(Identifier, false, true, false, true, true, false),
            9670 => new MushroomStemBlock(Identifier, false, true, false, true, false, true),
            9671 => new MushroomStemBlock(Identifier, false, true, false, true, false, false),
            9672 => new MushroomStemBlock(Identifier, false, true, false, false, true, true),
            9673 => new MushroomStemBlock(Identifier, false, true, false, false, true, false),
            9674 => new MushroomStemBlock(Identifier, false, true, false, false, false, true),
            9675 => new MushroomStemBlock(Identifier, false, true, false, false, false, false),
            9676 => new MushroomStemBlock(Identifier, false, false, true, true, true, true),
            9677 => new MushroomStemBlock(Identifier, false, false, true, true, true, false),
            9678 => new MushroomStemBlock(Identifier, false, false, true, true, false, true),
            9679 => new MushroomStemBlock(Identifier, false, false, true, true, false, false),
            9680 => new MushroomStemBlock(Identifier, false, false, true, false, true, true),
            9681 => new MushroomStemBlock(Identifier, false, false, true, false, true, false),
            9682 => new MushroomStemBlock(Identifier, false, false, true, false, false, true),
            9683 => new MushroomStemBlock(Identifier, false, false, true, false, false, false),
            9684 => new MushroomStemBlock(Identifier, false, false, false, true, true, true),
            9685 => new MushroomStemBlock(Identifier, false, false, false, true, true, false),
            9686 => new MushroomStemBlock(Identifier, false, false, false, true, false, true),
            9687 => new MushroomStemBlock(Identifier, false, false, false, true, false, false),
            9688 => new MushroomStemBlock(Identifier, false, false, false, false, true, true),
            9689 => new MushroomStemBlock(Identifier, false, false, false, false, true, false),
            9690 => new MushroomStemBlock(Identifier, false, false, false, false, false, true),
            9691 => new MushroomStemBlock(Identifier, false, false, false, false, false, false),
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
