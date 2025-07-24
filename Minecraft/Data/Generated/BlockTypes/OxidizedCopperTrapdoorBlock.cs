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

    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1019;
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
                                true => 25352,
                                false => 25353,
                            },
                            false => Waterlogged switch {
                                true => 25354,
                                false => 25355,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25356,
                                false => 25357,
                            },
                            false => Waterlogged switch {
                                true => 25358,
                                false => 25359,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25360,
                                false => 25361,
                            },
                            false => Waterlogged switch {
                                true => 25362,
                                false => 25363,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25364,
                                false => 25365,
                            },
                            false => Waterlogged switch {
                                true => 25366,
                                false => 25367,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25368,
                                false => 25369,
                            },
                            false => Waterlogged switch {
                                true => 25370,
                                false => 25371,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25372,
                                false => 25373,
                            },
                            false => Waterlogged switch {
                                true => 25374,
                                false => 25375,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25376,
                                false => 25377,
                            },
                            false => Waterlogged switch {
                                true => 25378,
                                false => 25379,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25380,
                                false => 25381,
                            },
                            false => Waterlogged switch {
                                true => 25382,
                                false => 25383,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25384,
                                false => 25385,
                            },
                            false => Waterlogged switch {
                                true => 25386,
                                false => 25387,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25388,
                                false => 25389,
                            },
                            false => Waterlogged switch {
                                true => 25390,
                                false => 25391,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25392,
                                false => 25393,
                            },
                            false => Waterlogged switch {
                                true => 25394,
                                false => 25395,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25396,
                                false => 25397,
                            },
                            false => Waterlogged switch {
                                true => 25398,
                                false => 25399,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25400,
                                false => 25401,
                            },
                            false => Waterlogged switch {
                                true => 25402,
                                false => 25403,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25404,
                                false => 25405,
                            },
                            false => Waterlogged switch {
                                true => 25406,
                                false => 25407,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25408,
                                false => 25409,
                            },
                            false => Waterlogged switch {
                                true => 25410,
                                false => 25411,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25412,
                                false => 25413,
                            },
                            false => Waterlogged switch {
                                true => 25414,
                                false => 25415,
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
            25352 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25353 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25354 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25355 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25356 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25357 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25358 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25359 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25360 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25361 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25362 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25363 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25364 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25365 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25366 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25367 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25368 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25369 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25370 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25371 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25372 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25373 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25374 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25375 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25376 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25377 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25378 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25379 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25380 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25381 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25382 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25383 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25384 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25385 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25386 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25387 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25388 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25389 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25390 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25391 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25392 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25393 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25394 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25395 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25396 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25397 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25398 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25399 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25400 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25401 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25402 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25403 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25404 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25405 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25406 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25407 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25408 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25409 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25410 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25411 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25412 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25413 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25414 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25415 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
}
