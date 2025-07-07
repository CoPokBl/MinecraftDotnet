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
                                true => 6396,
                                false => 6397,
                            },
                            false => Waterlogged switch {
                                true => 6398,
                                false => 6399,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6400,
                                false => 6401,
                            },
                            false => Waterlogged switch {
                                true => 6402,
                                false => 6403,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6404,
                                false => 6405,
                            },
                            false => Waterlogged switch {
                                true => 6406,
                                false => 6407,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6408,
                                false => 6409,
                            },
                            false => Waterlogged switch {
                                true => 6410,
                                false => 6411,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6412,
                                false => 6413,
                            },
                            false => Waterlogged switch {
                                true => 6414,
                                false => 6415,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6416,
                                false => 6417,
                            },
                            false => Waterlogged switch {
                                true => 6418,
                                false => 6419,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6420,
                                false => 6421,
                            },
                            false => Waterlogged switch {
                                true => 6422,
                                false => 6423,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6424,
                                false => 6425,
                            },
                            false => Waterlogged switch {
                                true => 6426,
                                false => 6427,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6428,
                                false => 6429,
                            },
                            false => Waterlogged switch {
                                true => 6430,
                                false => 6431,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6432,
                                false => 6433,
                            },
                            false => Waterlogged switch {
                                true => 6434,
                                false => 6435,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6436,
                                false => 6437,
                            },
                            false => Waterlogged switch {
                                true => 6438,
                                false => 6439,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6440,
                                false => 6441,
                            },
                            false => Waterlogged switch {
                                true => 6442,
                                false => 6443,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6444,
                                false => 6445,
                            },
                            false => Waterlogged switch {
                                true => 6446,
                                false => 6447,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6448,
                                false => 6449,
                            },
                            false => Waterlogged switch {
                                true => 6450,
                                false => 6451,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6452,
                                false => 6453,
                            },
                            false => Waterlogged switch {
                                true => 6454,
                                false => 6455,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6456,
                                false => 6457,
                            },
                            false => Waterlogged switch {
                                true => 6458,
                                false => 6459,
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
            6396 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6397 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6398 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6399 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6400 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6401 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6402 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6403 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6404 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6405 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6406 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6407 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6408 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6409 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6410 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6411 => new AcaciaTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6412 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6413 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6414 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6415 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6416 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6417 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6418 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6419 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6420 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6421 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6422 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6423 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6424 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6425 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6426 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6427 => new AcaciaTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6428 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6429 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6430 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6431 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6432 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6433 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6434 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6435 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6436 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6437 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6438 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6439 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6440 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6441 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6442 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6443 => new AcaciaTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6444 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6445 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6446 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6447 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6448 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6449 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6450 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6451 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6452 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6453 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6454 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6455 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6456 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6457 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6458 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6459 => new AcaciaTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
