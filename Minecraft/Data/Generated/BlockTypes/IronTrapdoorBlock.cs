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
public record IronTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.iron_trapdoor", 5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:iron_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/iron_trapdoor");
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.Normal, 6, "iron", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I4 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I4, I5, I4, I5, I6, I7, I6, I7, I2, I3, I2, I3, I6, I7, I6, I7, I4, I5, I4, I5, I8, I9, I8, I9, I2, I3, I2, I3, I8, I9, I8, I9, I4, I5, I4, I5, I10, I11, I10, I11, I2, I3, I2, I3, I10, I11, I10, I11, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 12567];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(TopBottom half) => this with { Half = half };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12567,
                                false => 12568,
                            },
                            false => Waterlogged switch {
                                true => 12569,
                                false => 12570,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12571,
                                false => 12572,
                            },
                            false => Waterlogged switch {
                                true => 12573,
                                false => 12574,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12575,
                                false => 12576,
                            },
                            false => Waterlogged switch {
                                true => 12577,
                                false => 12578,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12579,
                                false => 12580,
                            },
                            false => Waterlogged switch {
                                true => 12581,
                                false => 12582,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12583,
                                false => 12584,
                            },
                            false => Waterlogged switch {
                                true => 12585,
                                false => 12586,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12587,
                                false => 12588,
                            },
                            false => Waterlogged switch {
                                true => 12589,
                                false => 12590,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12591,
                                false => 12592,
                            },
                            false => Waterlogged switch {
                                true => 12593,
                                false => 12594,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12595,
                                false => 12596,
                            },
                            false => Waterlogged switch {
                                true => 12597,
                                false => 12598,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12599,
                                false => 12600,
                            },
                            false => Waterlogged switch {
                                true => 12601,
                                false => 12602,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12603,
                                false => 12604,
                            },
                            false => Waterlogged switch {
                                true => 12605,
                                false => 12606,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12607,
                                false => 12608,
                            },
                            false => Waterlogged switch {
                                true => 12609,
                                false => 12610,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12611,
                                false => 12612,
                            },
                            false => Waterlogged switch {
                                true => 12613,
                                false => 12614,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12615,
                                false => 12616,
                            },
                            false => Waterlogged switch {
                                true => 12617,
                                false => 12618,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12619,
                                false => 12620,
                            },
                            false => Waterlogged switch {
                                true => 12621,
                                false => 12622,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12623,
                                false => 12624,
                            },
                            false => Waterlogged switch {
                                true => 12625,
                                false => 12626,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12627,
                                false => 12628,
                            },
                            false => Waterlogged switch {
                                true => 12629,
                                false => 12630,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12567 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            12568 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            12569 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            12570 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            12571 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            12572 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            12573 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            12574 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            12575 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            12576 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            12577 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            12578 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            12579 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            12580 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            12581 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            12582 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            12583 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            12584 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            12585 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            12586 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            12587 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            12588 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            12589 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            12590 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            12591 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            12592 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            12593 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            12594 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            12595 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            12596 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            12597 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            12598 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            12599 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            12600 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            12601 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            12602 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            12603 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            12604 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            12605 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            12606 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            12607 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            12608 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            12609 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            12610 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            12611 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            12612 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            12613 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            12614 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            12615 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            12616 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            12617 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            12618 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            12619 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            12620 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            12621 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            12622 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            12623 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            12624 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            12625 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            12626 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            12627 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            12628 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            12629 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            12630 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
