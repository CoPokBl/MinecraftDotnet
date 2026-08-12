using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, OxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:oxidized_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.oxidized_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29200,
                                false => 29201,
                            },
                            false => Waterlogged switch {
                                true => 29202,
                                false => 29203,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29204,
                                false => 29205,
                            },
                            false => Waterlogged switch {
                                true => 29206,
                                false => 29207,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29208,
                                false => 29209,
                            },
                            false => Waterlogged switch {
                                true => 29210,
                                false => 29211,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29212,
                                false => 29213,
                            },
                            false => Waterlogged switch {
                                true => 29214,
                                false => 29215,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29216,
                                false => 29217,
                            },
                            false => Waterlogged switch {
                                true => 29218,
                                false => 29219,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29220,
                                false => 29221,
                            },
                            false => Waterlogged switch {
                                true => 29222,
                                false => 29223,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29224,
                                false => 29225,
                            },
                            false => Waterlogged switch {
                                true => 29226,
                                false => 29227,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29228,
                                false => 29229,
                            },
                            false => Waterlogged switch {
                                true => 29230,
                                false => 29231,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29232,
                                false => 29233,
                            },
                            false => Waterlogged switch {
                                true => 29234,
                                false => 29235,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29236,
                                false => 29237,
                            },
                            false => Waterlogged switch {
                                true => 29238,
                                false => 29239,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29240,
                                false => 29241,
                            },
                            false => Waterlogged switch {
                                true => 29242,
                                false => 29243,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29244,
                                false => 29245,
                            },
                            false => Waterlogged switch {
                                true => 29246,
                                false => 29247,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29248,
                                false => 29249,
                            },
                            false => Waterlogged switch {
                                true => 29250,
                                false => 29251,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29252,
                                false => 29253,
                            },
                            false => Waterlogged switch {
                                true => 29254,
                                false => 29255,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29256,
                                false => 29257,
                            },
                            false => Waterlogged switch {
                                true => 29258,
                                false => 29259,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29260,
                                false => 29261,
                            },
                            false => Waterlogged switch {
                                true => 29262,
                                false => 29263,
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
            29200 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29201 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29202 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29203 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29204 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29205 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29206 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29207 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29208 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29209 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29210 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29211 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29212 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29213 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29214 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29215 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29216 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29217 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29218 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29219 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29220 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29221 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29222 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29223 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29224 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29225 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29226 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29227 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29228 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29229 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29230 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29231 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29232 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29233 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29234 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29235 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29236 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29237 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29238 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29239 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29240 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29241 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29242 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29243 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29244 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29245 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29246 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29247 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29248 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29249 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29250 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29251 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29252 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29253 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29254 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29255 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29256 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29257 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29258 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29259 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29260 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29261 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29262 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29263 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
