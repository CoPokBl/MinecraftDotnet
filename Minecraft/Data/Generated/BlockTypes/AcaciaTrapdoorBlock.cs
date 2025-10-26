using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaTrapdoorBlock(Identifier Identifier, Direction Facing, AcaciaTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 319;
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
    public Identifier? Item => "minecraft:acacia_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7169,
                                false => 7170,
                            },
                            false => Waterlogged switch {
                                true => 7171,
                                false => 7172,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7173,
                                false => 7174,
                            },
                            false => Waterlogged switch {
                                true => 7175,
                                false => 7176,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7177,
                                false => 7178,
                            },
                            false => Waterlogged switch {
                                true => 7179,
                                false => 7180,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7181,
                                false => 7182,
                            },
                            false => Waterlogged switch {
                                true => 7183,
                                false => 7184,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7185,
                                false => 7186,
                            },
                            false => Waterlogged switch {
                                true => 7187,
                                false => 7188,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7189,
                                false => 7190,
                            },
                            false => Waterlogged switch {
                                true => 7191,
                                false => 7192,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7193,
                                false => 7194,
                            },
                            false => Waterlogged switch {
                                true => 7195,
                                false => 7196,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7197,
                                false => 7198,
                            },
                            false => Waterlogged switch {
                                true => 7199,
                                false => 7200,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7201,
                                false => 7202,
                            },
                            false => Waterlogged switch {
                                true => 7203,
                                false => 7204,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7205,
                                false => 7206,
                            },
                            false => Waterlogged switch {
                                true => 7207,
                                false => 7208,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7209,
                                false => 7210,
                            },
                            false => Waterlogged switch {
                                true => 7211,
                                false => 7212,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7213,
                                false => 7214,
                            },
                            false => Waterlogged switch {
                                true => 7215,
                                false => 7216,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7217,
                                false => 7218,
                            },
                            false => Waterlogged switch {
                                true => 7219,
                                false => 7220,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7221,
                                false => 7222,
                            },
                            false => Waterlogged switch {
                                true => 7223,
                                false => 7224,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7225,
                                false => 7226,
                            },
                            false => Waterlogged switch {
                                true => 7227,
                                false => 7228,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7229,
                                false => 7230,
                            },
                            false => Waterlogged switch {
                                true => 7231,
                                false => 7232,
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
            7169 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7170 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7171 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7172 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7173 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7174 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7175 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7176 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7177 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7178 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7179 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7180 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7181 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7182 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7183 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7184 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7185 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7186 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7187 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7188 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7189 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7190 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7191 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7192 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7193 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7194 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7195 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7196 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7197 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7198 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7199 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7200 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7201 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7202 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7203 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7204 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7205 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7206 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7207 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7208 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7209 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7210 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7211 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7212 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7213 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7214 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7215 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7216 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7217 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7218 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7219 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7220 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7221 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7222 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7223 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7224 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7225 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7226 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7227 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7228 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7229 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7230 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7231 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7232 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
