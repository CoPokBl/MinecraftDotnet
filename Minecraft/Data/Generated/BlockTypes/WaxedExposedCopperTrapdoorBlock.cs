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
    public int ProtocolId => 1060;
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
                                true => 26653,
                                false => 26654,
                            },
                            false => Waterlogged switch {
                                true => 26655,
                                false => 26656,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26657,
                                false => 26658,
                            },
                            false => Waterlogged switch {
                                true => 26659,
                                false => 26660,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26661,
                                false => 26662,
                            },
                            false => Waterlogged switch {
                                true => 26663,
                                false => 26664,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26665,
                                false => 26666,
                            },
                            false => Waterlogged switch {
                                true => 26667,
                                false => 26668,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26669,
                                false => 26670,
                            },
                            false => Waterlogged switch {
                                true => 26671,
                                false => 26672,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26673,
                                false => 26674,
                            },
                            false => Waterlogged switch {
                                true => 26675,
                                false => 26676,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26677,
                                false => 26678,
                            },
                            false => Waterlogged switch {
                                true => 26679,
                                false => 26680,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26681,
                                false => 26682,
                            },
                            false => Waterlogged switch {
                                true => 26683,
                                false => 26684,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26685,
                                false => 26686,
                            },
                            false => Waterlogged switch {
                                true => 26687,
                                false => 26688,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26689,
                                false => 26690,
                            },
                            false => Waterlogged switch {
                                true => 26691,
                                false => 26692,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26693,
                                false => 26694,
                            },
                            false => Waterlogged switch {
                                true => 26695,
                                false => 26696,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26697,
                                false => 26698,
                            },
                            false => Waterlogged switch {
                                true => 26699,
                                false => 26700,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26701,
                                false => 26702,
                            },
                            false => Waterlogged switch {
                                true => 26703,
                                false => 26704,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26705,
                                false => 26706,
                            },
                            false => Waterlogged switch {
                                true => 26707,
                                false => 26708,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26709,
                                false => 26710,
                            },
                            false => Waterlogged switch {
                                true => 26711,
                                false => 26712,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26713,
                                false => 26714,
                            },
                            false => Waterlogged switch {
                                true => 26715,
                                false => 26716,
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
            26653 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26654 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26655 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26656 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26657 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26658 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26659 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26660 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26661 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26662 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26663 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26664 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26665 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26666 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26667 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26668 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26669 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26670 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26671 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26672 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26673 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26674 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26675 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26676 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26677 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26678 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26679 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26680 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26681 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26682 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26683 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26684 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26685 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26686 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26687 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26688 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26689 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26690 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26691 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26692 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26693 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26694 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26695 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26696 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26697 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26698 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26699 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26700 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26701 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26702 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26703 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26704 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26705 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26706 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26707 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26708 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26709 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26710 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26711 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26712 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26713 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26714 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26715 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26716 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
