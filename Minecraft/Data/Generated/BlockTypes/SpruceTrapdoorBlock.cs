using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceTrapdoorBlock(Identifier Identifier, Direction Facing, SpruceTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 302;
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
    public Identifier? Item => "minecraft:spruce_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6204,
                                false => 6205,
                            },
                            false => Waterlogged switch {
                                true => 6206,
                                false => 6207,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6208,
                                false => 6209,
                            },
                            false => Waterlogged switch {
                                true => 6210,
                                false => 6211,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6212,
                                false => 6213,
                            },
                            false => Waterlogged switch {
                                true => 6214,
                                false => 6215,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6216,
                                false => 6217,
                            },
                            false => Waterlogged switch {
                                true => 6218,
                                false => 6219,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6220,
                                false => 6221,
                            },
                            false => Waterlogged switch {
                                true => 6222,
                                false => 6223,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6224,
                                false => 6225,
                            },
                            false => Waterlogged switch {
                                true => 6226,
                                false => 6227,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6228,
                                false => 6229,
                            },
                            false => Waterlogged switch {
                                true => 6230,
                                false => 6231,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6232,
                                false => 6233,
                            },
                            false => Waterlogged switch {
                                true => 6234,
                                false => 6235,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6236,
                                false => 6237,
                            },
                            false => Waterlogged switch {
                                true => 6238,
                                false => 6239,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6240,
                                false => 6241,
                            },
                            false => Waterlogged switch {
                                true => 6242,
                                false => 6243,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6244,
                                false => 6245,
                            },
                            false => Waterlogged switch {
                                true => 6246,
                                false => 6247,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6248,
                                false => 6249,
                            },
                            false => Waterlogged switch {
                                true => 6250,
                                false => 6251,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6252,
                                false => 6253,
                            },
                            false => Waterlogged switch {
                                true => 6254,
                                false => 6255,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6256,
                                false => 6257,
                            },
                            false => Waterlogged switch {
                                true => 6258,
                                false => 6259,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6260,
                                false => 6261,
                            },
                            false => Waterlogged switch {
                                true => 6262,
                                false => 6263,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6264,
                                false => 6265,
                            },
                            false => Waterlogged switch {
                                true => 6266,
                                false => 6267,
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
            6204 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6205 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6206 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6207 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6208 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6209 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6210 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6211 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6212 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6213 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6214 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6215 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6216 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6217 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6218 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6219 => new SpruceTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6220 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6221 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6222 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6223 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6224 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6225 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6226 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6227 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6228 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6229 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6230 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6231 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6232 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6233 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6234 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6235 => new SpruceTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6236 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6237 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6238 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6239 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6240 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6241 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6242 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6243 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6244 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6245 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6246 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6247 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6248 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6249 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6250 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6251 => new SpruceTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6252 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6253 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6254 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6255 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6256 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6257 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6258 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6259 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6260 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6261 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6262 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6263 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6264 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6265 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6266 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6267 => new SpruceTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
