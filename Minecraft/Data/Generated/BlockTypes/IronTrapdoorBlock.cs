using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronTrapdoorBlock(Identifier Identifier, Direction Facing, IronTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.iron_trapdoor", 5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:iron_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.Normal, 6, "iron", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
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
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12567 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            12568 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            12569 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            12570 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            12571 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            12572 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            12573 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            12574 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            12575 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            12576 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            12577 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            12578 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            12579 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            12580 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            12581 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            12582 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            12583 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            12584 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            12585 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            12586 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            12587 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            12588 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            12589 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            12590 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            12591 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            12592 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            12593 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            12594 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            12595 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            12596 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            12597 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            12598 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            12599 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            12600 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            12601 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            12602 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            12603 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            12604 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            12605 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            12606 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            12607 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            12608 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            12609 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            12610 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            12611 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            12612 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            12613 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            12614 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            12615 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            12616 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            12617 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            12618 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            12619 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            12620 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            12621 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            12622 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            12623 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            12624 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            12625 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            12626 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            12627 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            12628 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            12629 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            12630 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
