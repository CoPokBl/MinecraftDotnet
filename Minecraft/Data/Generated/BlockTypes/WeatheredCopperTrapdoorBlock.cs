using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1058;
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
    public Identifier? Item => "minecraft:weathered_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26525,
                                false => 26526,
                            },
                            false => Waterlogged switch {
                                true => 26527,
                                false => 26528,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26529,
                                false => 26530,
                            },
                            false => Waterlogged switch {
                                true => 26531,
                                false => 26532,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26533,
                                false => 26534,
                            },
                            false => Waterlogged switch {
                                true => 26535,
                                false => 26536,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26537,
                                false => 26538,
                            },
                            false => Waterlogged switch {
                                true => 26539,
                                false => 26540,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26541,
                                false => 26542,
                            },
                            false => Waterlogged switch {
                                true => 26543,
                                false => 26544,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26545,
                                false => 26546,
                            },
                            false => Waterlogged switch {
                                true => 26547,
                                false => 26548,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26549,
                                false => 26550,
                            },
                            false => Waterlogged switch {
                                true => 26551,
                                false => 26552,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26553,
                                false => 26554,
                            },
                            false => Waterlogged switch {
                                true => 26555,
                                false => 26556,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26557,
                                false => 26558,
                            },
                            false => Waterlogged switch {
                                true => 26559,
                                false => 26560,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26561,
                                false => 26562,
                            },
                            false => Waterlogged switch {
                                true => 26563,
                                false => 26564,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26565,
                                false => 26566,
                            },
                            false => Waterlogged switch {
                                true => 26567,
                                false => 26568,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26569,
                                false => 26570,
                            },
                            false => Waterlogged switch {
                                true => 26571,
                                false => 26572,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26573,
                                false => 26574,
                            },
                            false => Waterlogged switch {
                                true => 26575,
                                false => 26576,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26577,
                                false => 26578,
                            },
                            false => Waterlogged switch {
                                true => 26579,
                                false => 26580,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26581,
                                false => 26582,
                            },
                            false => Waterlogged switch {
                                true => 26583,
                                false => 26584,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26585,
                                false => 26586,
                            },
                            false => Waterlogged switch {
                                true => 26587,
                                false => 26588,
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
            26525 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26526 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26527 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26528 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26529 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26530 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26531 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26532 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26533 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26534 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26535 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26536 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26537 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26538 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26539 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26540 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26541 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26542 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26543 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26544 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26545 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26546 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26547 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26548 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26549 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26550 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26551 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26552 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26553 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26554 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26555 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26556 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26557 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26558 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26559 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26560 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26561 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26562 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26563 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26564 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26565 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26566 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26567 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26568 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26569 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26570 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26571 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26572 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26573 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26574 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26575 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26576 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26577 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26578 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26579 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26580 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26581 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26582 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26583 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26584 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26585 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26586 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26587 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26588 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
