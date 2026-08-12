using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:door";
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
    public Identifier? Item => "minecraft:spruce_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14060,
                                false => 14061,
                            },
                            false => Powered switch {
                                true => 14062,
                                false => 14063,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14064,
                                false => 14065,
                            },
                            false => Powered switch {
                                true => 14066,
                                false => 14067,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14068,
                                false => 14069,
                            },
                            false => Powered switch {
                                true => 14070,
                                false => 14071,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14072,
                                false => 14073,
                            },
                            false => Powered switch {
                                true => 14074,
                                false => 14075,
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
                                true => 14076,
                                false => 14077,
                            },
                            false => Powered switch {
                                true => 14078,
                                false => 14079,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14080,
                                false => 14081,
                            },
                            false => Powered switch {
                                true => 14082,
                                false => 14083,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14084,
                                false => 14085,
                            },
                            false => Powered switch {
                                true => 14086,
                                false => 14087,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14088,
                                false => 14089,
                            },
                            false => Powered switch {
                                true => 14090,
                                false => 14091,
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
                                true => 14092,
                                false => 14093,
                            },
                            false => Powered switch {
                                true => 14094,
                                false => 14095,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14096,
                                false => 14097,
                            },
                            false => Powered switch {
                                true => 14098,
                                false => 14099,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14100,
                                false => 14101,
                            },
                            false => Powered switch {
                                true => 14102,
                                false => 14103,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14104,
                                false => 14105,
                            },
                            false => Powered switch {
                                true => 14106,
                                false => 14107,
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
                                true => 14108,
                                false => 14109,
                            },
                            false => Powered switch {
                                true => 14110,
                                false => 14111,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14112,
                                false => 14113,
                            },
                            false => Powered switch {
                                true => 14114,
                                false => 14115,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14116,
                                false => 14117,
                            },
                            false => Powered switch {
                                true => 14118,
                                false => 14119,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14120,
                                false => 14121,
                            },
                            false => Powered switch {
                                true => 14122,
                                false => 14123,
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
            14060 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            14061 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            14062 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            14063 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            14064 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            14065 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            14066 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            14067 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            14068 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            14069 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            14070 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            14071 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            14072 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            14073 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            14074 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            14075 => new SpruceDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            14076 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            14077 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            14078 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            14079 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            14080 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            14081 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            14082 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            14083 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            14084 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            14085 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            14086 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            14087 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            14088 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            14089 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            14090 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            14091 => new SpruceDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            14092 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            14093 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            14094 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            14095 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            14096 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            14097 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            14098 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            14099 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            14100 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            14101 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            14102 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            14103 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            14104 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            14105 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            14106 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            14107 => new SpruceDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            14108 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            14109 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            14110 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            14111 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            14112 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            14113 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            14114 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            14115 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            14116 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            14117 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            14118 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            14119 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            14120 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            14121 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            14122 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            14123 => new SpruceDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
