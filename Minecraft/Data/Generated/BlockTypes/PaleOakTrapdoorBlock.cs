using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakTrapdoorBlock(Identifier Identifier, Direction Facing, PaleOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.pale_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 14, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7562];

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
                                true => 7562,
                                false => 7563,
                            },
                            false => Waterlogged switch {
                                true => 7564,
                                false => 7565,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7566,
                                false => 7567,
                            },
                            false => Waterlogged switch {
                                true => 7568,
                                false => 7569,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7570,
                                false => 7571,
                            },
                            false => Waterlogged switch {
                                true => 7572,
                                false => 7573,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7574,
                                false => 7575,
                            },
                            false => Waterlogged switch {
                                true => 7576,
                                false => 7577,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7578,
                                false => 7579,
                            },
                            false => Waterlogged switch {
                                true => 7580,
                                false => 7581,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7582,
                                false => 7583,
                            },
                            false => Waterlogged switch {
                                true => 7584,
                                false => 7585,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7586,
                                false => 7587,
                            },
                            false => Waterlogged switch {
                                true => 7588,
                                false => 7589,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7590,
                                false => 7591,
                            },
                            false => Waterlogged switch {
                                true => 7592,
                                false => 7593,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7594,
                                false => 7595,
                            },
                            false => Waterlogged switch {
                                true => 7596,
                                false => 7597,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7598,
                                false => 7599,
                            },
                            false => Waterlogged switch {
                                true => 7600,
                                false => 7601,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7602,
                                false => 7603,
                            },
                            false => Waterlogged switch {
                                true => 7604,
                                false => 7605,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7606,
                                false => 7607,
                            },
                            false => Waterlogged switch {
                                true => 7608,
                                false => 7609,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7610,
                                false => 7611,
                            },
                            false => Waterlogged switch {
                                true => 7612,
                                false => 7613,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7614,
                                false => 7615,
                            },
                            false => Waterlogged switch {
                                true => 7616,
                                false => 7617,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7618,
                                false => 7619,
                            },
                            false => Waterlogged switch {
                                true => 7620,
                                false => 7621,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7622,
                                false => 7623,
                            },
                            false => Waterlogged switch {
                                true => 7624,
                                false => 7625,
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
            7562 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7563 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7564 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7565 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7566 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7567 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7568 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7569 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7570 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7571 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7572 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7573 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7574 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7575 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7576 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7577 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7578 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7579 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7580 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7581 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7582 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7583 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7584 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7585 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7586 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7587 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7588 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7589 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7590 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7591 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7592 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7593 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7594 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7595 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7596 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7597 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7598 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7599 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7600 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7601 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7602 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7603 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7604 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7605 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7606 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7607 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7608 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7609 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7610 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7611 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7612 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7613 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7614 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7615 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7616 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7617 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7618 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7619 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7620 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7621 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7622 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7623 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7624 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7625 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
