using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 1061;
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26717,
                                false => 26718,
                            },
                            false => Waterlogged switch {
                                true => 26719,
                                false => 26720,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26721,
                                false => 26722,
                            },
                            false => Waterlogged switch {
                                true => 26723,
                                false => 26724,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26725,
                                false => 26726,
                            },
                            false => Waterlogged switch {
                                true => 26727,
                                false => 26728,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26729,
                                false => 26730,
                            },
                            false => Waterlogged switch {
                                true => 26731,
                                false => 26732,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26733,
                                false => 26734,
                            },
                            false => Waterlogged switch {
                                true => 26735,
                                false => 26736,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26737,
                                false => 26738,
                            },
                            false => Waterlogged switch {
                                true => 26739,
                                false => 26740,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26741,
                                false => 26742,
                            },
                            false => Waterlogged switch {
                                true => 26743,
                                false => 26744,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26745,
                                false => 26746,
                            },
                            false => Waterlogged switch {
                                true => 26747,
                                false => 26748,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26749,
                                false => 26750,
                            },
                            false => Waterlogged switch {
                                true => 26751,
                                false => 26752,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26753,
                                false => 26754,
                            },
                            false => Waterlogged switch {
                                true => 26755,
                                false => 26756,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26757,
                                false => 26758,
                            },
                            false => Waterlogged switch {
                                true => 26759,
                                false => 26760,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26761,
                                false => 26762,
                            },
                            false => Waterlogged switch {
                                true => 26763,
                                false => 26764,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26765,
                                false => 26766,
                            },
                            false => Waterlogged switch {
                                true => 26767,
                                false => 26768,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26769,
                                false => 26770,
                            },
                            false => Waterlogged switch {
                                true => 26771,
                                false => 26772,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26773,
                                false => 26774,
                            },
                            false => Waterlogged switch {
                                true => 26775,
                                false => 26776,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26777,
                                false => 26778,
                            },
                            false => Waterlogged switch {
                                true => 26779,
                                false => 26780,
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
            26717 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26718 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26719 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26720 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26721 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26722 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26723 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26724 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26725 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26726 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26727 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26728 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26729 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26730 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26731 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26732 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26733 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26734 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26735 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26736 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26737 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26738 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26739 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26740 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26741 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26742 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26743 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26744 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26745 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26746 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26747 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26748 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26749 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26750 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26751 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26752 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26753 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26754 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26755 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26756 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26757 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26758 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26759 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26760 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26761 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26762 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26763 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26764 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26765 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26766 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26767 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26768 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26769 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26770 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26771 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26772 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26773 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26774 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26775 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26776 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26777 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26778 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26779 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26780 => new WaxedOxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
