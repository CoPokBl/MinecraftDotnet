using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, ExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_trapdoor";
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
    public Identifier? Item => "minecraft:exposed_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.exposed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29072,
                                false => 29073,
                            },
                            false => Waterlogged switch {
                                true => 29074,
                                false => 29075,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29076,
                                false => 29077,
                            },
                            false => Waterlogged switch {
                                true => 29078,
                                false => 29079,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29080,
                                false => 29081,
                            },
                            false => Waterlogged switch {
                                true => 29082,
                                false => 29083,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29084,
                                false => 29085,
                            },
                            false => Waterlogged switch {
                                true => 29086,
                                false => 29087,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29088,
                                false => 29089,
                            },
                            false => Waterlogged switch {
                                true => 29090,
                                false => 29091,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29092,
                                false => 29093,
                            },
                            false => Waterlogged switch {
                                true => 29094,
                                false => 29095,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29096,
                                false => 29097,
                            },
                            false => Waterlogged switch {
                                true => 29098,
                                false => 29099,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29100,
                                false => 29101,
                            },
                            false => Waterlogged switch {
                                true => 29102,
                                false => 29103,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29104,
                                false => 29105,
                            },
                            false => Waterlogged switch {
                                true => 29106,
                                false => 29107,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29108,
                                false => 29109,
                            },
                            false => Waterlogged switch {
                                true => 29110,
                                false => 29111,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29112,
                                false => 29113,
                            },
                            false => Waterlogged switch {
                                true => 29114,
                                false => 29115,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29116,
                                false => 29117,
                            },
                            false => Waterlogged switch {
                                true => 29118,
                                false => 29119,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29120,
                                false => 29121,
                            },
                            false => Waterlogged switch {
                                true => 29122,
                                false => 29123,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29124,
                                false => 29125,
                            },
                            false => Waterlogged switch {
                                true => 29126,
                                false => 29127,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29128,
                                false => 29129,
                            },
                            false => Waterlogged switch {
                                true => 29130,
                                false => 29131,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29132,
                                false => 29133,
                            },
                            false => Waterlogged switch {
                                true => 29134,
                                false => 29135,
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
            29072 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29073 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29074 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29075 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29076 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29077 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29078 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29079 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29080 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29081 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29082 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29083 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29084 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29085 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29086 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29087 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29088 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29089 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29090 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29091 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29092 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29093 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29094 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29095 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29096 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29097 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29098 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29099 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29100 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29101 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29102 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29103 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29104 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29105 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29106 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29107 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29108 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29109 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29110 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29111 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29112 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29113 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29114 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29115 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29116 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29117 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29118 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29119 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29120 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29121 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29122 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29123 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29124 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29125 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29126 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29127 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29128 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29129 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29130 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29131 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29132 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29133 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29134 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29135 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
