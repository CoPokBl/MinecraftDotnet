using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedTrapdoorBlock(Identifier Identifier, Direction Facing, WarpedTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_trapdoor";
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
    public string TranslationKey => "block.minecraft.warped_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21178,
                                false => 21179,
                            },
                            false => Waterlogged switch {
                                true => 21180,
                                false => 21181,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21182,
                                false => 21183,
                            },
                            false => Waterlogged switch {
                                true => 21184,
                                false => 21185,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21186,
                                false => 21187,
                            },
                            false => Waterlogged switch {
                                true => 21188,
                                false => 21189,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21190,
                                false => 21191,
                            },
                            false => Waterlogged switch {
                                true => 21192,
                                false => 21193,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21194,
                                false => 21195,
                            },
                            false => Waterlogged switch {
                                true => 21196,
                                false => 21197,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21198,
                                false => 21199,
                            },
                            false => Waterlogged switch {
                                true => 21200,
                                false => 21201,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21202,
                                false => 21203,
                            },
                            false => Waterlogged switch {
                                true => 21204,
                                false => 21205,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21206,
                                false => 21207,
                            },
                            false => Waterlogged switch {
                                true => 21208,
                                false => 21209,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21210,
                                false => 21211,
                            },
                            false => Waterlogged switch {
                                true => 21212,
                                false => 21213,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21214,
                                false => 21215,
                            },
                            false => Waterlogged switch {
                                true => 21216,
                                false => 21217,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21218,
                                false => 21219,
                            },
                            false => Waterlogged switch {
                                true => 21220,
                                false => 21221,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21222,
                                false => 21223,
                            },
                            false => Waterlogged switch {
                                true => 21224,
                                false => 21225,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21226,
                                false => 21227,
                            },
                            false => Waterlogged switch {
                                true => 21228,
                                false => 21229,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21230,
                                false => 21231,
                            },
                            false => Waterlogged switch {
                                true => 21232,
                                false => 21233,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21234,
                                false => 21235,
                            },
                            false => Waterlogged switch {
                                true => 21236,
                                false => 21237,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21238,
                                false => 21239,
                            },
                            false => Waterlogged switch {
                                true => 21240,
                                false => 21241,
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
            21178 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            21179 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            21180 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            21181 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            21182 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            21183 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            21184 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            21185 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            21186 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            21187 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            21188 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            21189 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            21190 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            21191 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            21192 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            21193 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            21194 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            21195 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            21196 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            21197 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            21198 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            21199 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            21200 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            21201 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            21202 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            21203 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            21204 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            21205 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            21206 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            21207 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            21208 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            21209 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            21210 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            21211 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            21212 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            21213 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            21214 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            21215 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            21216 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            21217 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            21218 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            21219 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            21220 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            21221 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            21222 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            21223 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            21224 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            21225 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            21226 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            21227 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            21228 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            21229 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            21230 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            21231 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            21232 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            21233 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            21234 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            21235 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            21236 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            21237 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            21238 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            21239 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            21240 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            21241 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
