using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveTrapdoorBlock(Identifier Identifier, Direction Facing, MangroveTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mangrove_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7626,
                                false => 7627,
                            },
                            false => Waterlogged switch {
                                true => 7628,
                                false => 7629,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7630,
                                false => 7631,
                            },
                            false => Waterlogged switch {
                                true => 7632,
                                false => 7633,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7634,
                                false => 7635,
                            },
                            false => Waterlogged switch {
                                true => 7636,
                                false => 7637,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7638,
                                false => 7639,
                            },
                            false => Waterlogged switch {
                                true => 7640,
                                false => 7641,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7642,
                                false => 7643,
                            },
                            false => Waterlogged switch {
                                true => 7644,
                                false => 7645,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7646,
                                false => 7647,
                            },
                            false => Waterlogged switch {
                                true => 7648,
                                false => 7649,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7650,
                                false => 7651,
                            },
                            false => Waterlogged switch {
                                true => 7652,
                                false => 7653,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7654,
                                false => 7655,
                            },
                            false => Waterlogged switch {
                                true => 7656,
                                false => 7657,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7658,
                                false => 7659,
                            },
                            false => Waterlogged switch {
                                true => 7660,
                                false => 7661,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7662,
                                false => 7663,
                            },
                            false => Waterlogged switch {
                                true => 7664,
                                false => 7665,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7666,
                                false => 7667,
                            },
                            false => Waterlogged switch {
                                true => 7668,
                                false => 7669,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7670,
                                false => 7671,
                            },
                            false => Waterlogged switch {
                                true => 7672,
                                false => 7673,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7674,
                                false => 7675,
                            },
                            false => Waterlogged switch {
                                true => 7676,
                                false => 7677,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7678,
                                false => 7679,
                            },
                            false => Waterlogged switch {
                                true => 7680,
                                false => 7681,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7682,
                                false => 7683,
                            },
                            false => Waterlogged switch {
                                true => 7684,
                                false => 7685,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7686,
                                false => 7687,
                            },
                            false => Waterlogged switch {
                                true => 7688,
                                false => 7689,
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
            7626 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7627 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7628 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7629 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7630 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7631 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7632 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7633 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7634 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7635 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7636 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7637 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7638 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7639 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7640 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7641 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7642 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7643 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7644 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7645 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7646 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7647 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7648 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7649 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7650 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7651 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7652 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7653 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7654 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7655 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7656 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7657 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7658 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7659 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7660 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7661 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7662 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7663 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7664 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7665 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7666 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7667 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7668 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7669 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7670 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7671 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7672 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7673 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7674 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7675 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7676 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7677 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7678 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7679 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7680 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7681 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7682 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7683 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7684 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7685 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7686 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7687 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7688 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7689 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
