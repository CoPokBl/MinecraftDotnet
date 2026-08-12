using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_door";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:oxidized_copper_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_copper_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28688,
                                false => 28689,
                            },
                            false => Powered switch {
                                true => 28690,
                                false => 28691,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28692,
                                false => 28693,
                            },
                            false => Powered switch {
                                true => 28694,
                                false => 28695,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28696,
                                false => 28697,
                            },
                            false => Powered switch {
                                true => 28698,
                                false => 28699,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28700,
                                false => 28701,
                            },
                            false => Powered switch {
                                true => 28702,
                                false => 28703,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28704,
                                false => 28705,
                            },
                            false => Powered switch {
                                true => 28706,
                                false => 28707,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28708,
                                false => 28709,
                            },
                            false => Powered switch {
                                true => 28710,
                                false => 28711,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28712,
                                false => 28713,
                            },
                            false => Powered switch {
                                true => 28714,
                                false => 28715,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28716,
                                false => 28717,
                            },
                            false => Powered switch {
                                true => 28718,
                                false => 28719,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28720,
                                false => 28721,
                            },
                            false => Powered switch {
                                true => 28722,
                                false => 28723,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28724,
                                false => 28725,
                            },
                            false => Powered switch {
                                true => 28726,
                                false => 28727,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28728,
                                false => 28729,
                            },
                            false => Powered switch {
                                true => 28730,
                                false => 28731,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28732,
                                false => 28733,
                            },
                            false => Powered switch {
                                true => 28734,
                                false => 28735,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28736,
                                false => 28737,
                            },
                            false => Powered switch {
                                true => 28738,
                                false => 28739,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28740,
                                false => 28741,
                            },
                            false => Powered switch {
                                true => 28742,
                                false => 28743,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 28744,
                                false => 28745,
                            },
                            false => Powered switch {
                                true => 28746,
                                false => 28747,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 28748,
                                false => 28749,
                            },
                            false => Powered switch {
                                true => 28750,
                                false => 28751,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            28688 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            28689 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            28690 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            28691 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            28692 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            28693 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            28694 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            28695 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            28696 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            28697 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            28698 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            28699 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            28700 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            28701 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            28702 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            28703 => new OxidizedCopperDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            28704 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            28705 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            28706 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            28707 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            28708 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            28709 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            28710 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            28711 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            28712 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            28713 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            28714 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            28715 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            28716 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            28717 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            28718 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            28719 => new OxidizedCopperDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            28720 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            28721 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            28722 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            28723 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            28724 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            28725 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            28726 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            28727 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            28728 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            28729 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            28730 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            28731 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            28732 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            28733 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            28734 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            28735 => new OxidizedCopperDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            28736 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            28737 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            28738 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            28739 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            28740 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            28741 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            28742 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            28743 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            28744 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            28745 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            28746 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            28747 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            28748 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            28749 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            28750 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            28751 => new OxidizedCopperDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Hinge = properties.Contains("hinge") ? LeftRightExtensions.FromString(properties["hinge"].GetString()) : Hinge,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("hinge", new StringTag(Hinge.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
