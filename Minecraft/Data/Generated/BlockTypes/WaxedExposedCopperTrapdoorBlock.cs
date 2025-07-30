using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 1022;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_exposed_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25544,
                                false => 25545,
                            },
                            false => Waterlogged switch {
                                true => 25546,
                                false => 25547,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25548,
                                false => 25549,
                            },
                            false => Waterlogged switch {
                                true => 25550,
                                false => 25551,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25552,
                                false => 25553,
                            },
                            false => Waterlogged switch {
                                true => 25554,
                                false => 25555,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25556,
                                false => 25557,
                            },
                            false => Waterlogged switch {
                                true => 25558,
                                false => 25559,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25560,
                                false => 25561,
                            },
                            false => Waterlogged switch {
                                true => 25562,
                                false => 25563,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25564,
                                false => 25565,
                            },
                            false => Waterlogged switch {
                                true => 25566,
                                false => 25567,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25568,
                                false => 25569,
                            },
                            false => Waterlogged switch {
                                true => 25570,
                                false => 25571,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25572,
                                false => 25573,
                            },
                            false => Waterlogged switch {
                                true => 25574,
                                false => 25575,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25576,
                                false => 25577,
                            },
                            false => Waterlogged switch {
                                true => 25578,
                                false => 25579,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25580,
                                false => 25581,
                            },
                            false => Waterlogged switch {
                                true => 25582,
                                false => 25583,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25584,
                                false => 25585,
                            },
                            false => Waterlogged switch {
                                true => 25586,
                                false => 25587,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25588,
                                false => 25589,
                            },
                            false => Waterlogged switch {
                                true => 25590,
                                false => 25591,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25592,
                                false => 25593,
                            },
                            false => Waterlogged switch {
                                true => 25594,
                                false => 25595,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25596,
                                false => 25597,
                            },
                            false => Waterlogged switch {
                                true => 25598,
                                false => 25599,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25600,
                                false => 25601,
                            },
                            false => Waterlogged switch {
                                true => 25602,
                                false => 25603,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25604,
                                false => 25605,
                            },
                            false => Waterlogged switch {
                                true => 25606,
                                false => 25607,
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
            25544 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25545 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25546 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25547 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25548 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25549 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25550 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25551 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25552 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25553 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25554 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25555 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25556 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25557 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25558 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25559 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25560 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25561 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25562 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25563 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25564 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25565 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25566 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25567 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25568 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25569 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25570 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25571 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25572 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25573 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25574 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25575 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25576 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25577 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25578 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25579 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25580 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25581 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25582 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25583 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25584 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25585 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25586 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25587 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25588 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25589 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25590 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25591 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25592 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25593 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25594 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25595 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25596 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25597 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25598 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25599 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25600 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25601 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25602 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25603 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25604 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25605 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25606 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25607 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
