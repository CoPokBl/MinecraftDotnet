using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {
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
    public Identifier? Item => "minecraft:birch_door";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_door";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14124,
                                false => 14125,
                            },
                            false => Powered switch {
                                true => 14126,
                                false => 14127,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14128,
                                false => 14129,
                            },
                            false => Powered switch {
                                true => 14130,
                                false => 14131,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14132,
                                false => 14133,
                            },
                            false => Powered switch {
                                true => 14134,
                                false => 14135,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14136,
                                false => 14137,
                            },
                            false => Powered switch {
                                true => 14138,
                                false => 14139,
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
                                true => 14140,
                                false => 14141,
                            },
                            false => Powered switch {
                                true => 14142,
                                false => 14143,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14144,
                                false => 14145,
                            },
                            false => Powered switch {
                                true => 14146,
                                false => 14147,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14148,
                                false => 14149,
                            },
                            false => Powered switch {
                                true => 14150,
                                false => 14151,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14152,
                                false => 14153,
                            },
                            false => Powered switch {
                                true => 14154,
                                false => 14155,
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
                                true => 14156,
                                false => 14157,
                            },
                            false => Powered switch {
                                true => 14158,
                                false => 14159,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14160,
                                false => 14161,
                            },
                            false => Powered switch {
                                true => 14162,
                                false => 14163,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14164,
                                false => 14165,
                            },
                            false => Powered switch {
                                true => 14166,
                                false => 14167,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14168,
                                false => 14169,
                            },
                            false => Powered switch {
                                true => 14170,
                                false => 14171,
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
                                true => 14172,
                                false => 14173,
                            },
                            false => Powered switch {
                                true => 14174,
                                false => 14175,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14176,
                                false => 14177,
                            },
                            false => Powered switch {
                                true => 14178,
                                false => 14179,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 14180,
                                false => 14181,
                            },
                            false => Powered switch {
                                true => 14182,
                                false => 14183,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 14184,
                                false => 14185,
                            },
                            false => Powered switch {
                                true => 14186,
                                false => 14187,
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
            14124 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            14125 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            14126 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            14127 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            14128 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            14129 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            14130 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            14131 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            14132 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            14133 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            14134 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            14135 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            14136 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            14137 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            14138 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            14139 => new BirchDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            14140 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            14141 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            14142 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            14143 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            14144 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            14145 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            14146 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            14147 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            14148 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            14149 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            14150 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            14151 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            14152 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            14153 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            14154 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            14155 => new BirchDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            14156 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            14157 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            14158 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            14159 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            14160 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            14161 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            14162 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            14163 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            14164 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            14165 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            14166 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            14167 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            14168 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            14169 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            14170 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            14171 => new BirchDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            14172 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            14173 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            14174 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            14175 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            14176 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            14177 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            14178 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            14179 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            14180 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            14181 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            14182 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            14183 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            14184 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            14185 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            14186 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            14187 => new BirchDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
