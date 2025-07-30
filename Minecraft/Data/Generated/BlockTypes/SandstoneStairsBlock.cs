using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SandstoneStairsBlock(Identifier Identifier, Direction Facing, SandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 366;
    public double Hardness => 0.8;
    public double ExplosionResistance => 0.8;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8215,
                            false => 8216,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8217,
                            false => 8218,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8219,
                            false => 8220,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8221,
                            false => 8222,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8223,
                            false => 8224,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8225,
                            false => 8226,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8227,
                            false => 8228,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8229,
                            false => 8230,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8231,
                            false => 8232,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8233,
                            false => 8234,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8235,
                            false => 8236,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8237,
                            false => 8238,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8239,
                            false => 8240,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8241,
                            false => 8242,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8243,
                            false => 8244,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8245,
                            false => 8246,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8247,
                            false => 8248,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8249,
                            false => 8250,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8251,
                            false => 8252,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8253,
                            false => 8254,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8255,
                            false => 8256,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8257,
                            false => 8258,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8259,
                            false => 8260,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8261,
                            false => 8262,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8263,
                            false => 8264,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8265,
                            false => 8266,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8267,
                            false => 8268,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8269,
                            false => 8270,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8271,
                            false => 8272,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8273,
                            false => 8274,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8275,
                            false => 8276,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8277,
                            false => 8278,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8279,
                            false => 8280,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8281,
                            false => 8282,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8283,
                            false => 8284,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8285,
                            false => 8286,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8287,
                            false => 8288,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8289,
                            false => 8290,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8291,
                            false => 8292,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8293,
                            false => 8294,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8215 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8216 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8217 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8218 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8219 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8220 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8221 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8222 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8223 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8224 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8225 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8226 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8227 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8228 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8229 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8230 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8231 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8232 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8233 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8234 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8235 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8236 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8237 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8238 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8239 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8240 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8241 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8242 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8243 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8244 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8245 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8246 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8247 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8248 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8249 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8250 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8251 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8252 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8253 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8254 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8255 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8256 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8257 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8258 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8259 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8260 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8261 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8262 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8263 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8264 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8265 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8266 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8267 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8268 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8269 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8270 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8271 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8272 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8273 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8274 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8275 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8276 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8277 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8278 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8279 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8280 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8281 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8282 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8283 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8284 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8285 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8286 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8287 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8288 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8289 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8290 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8291 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8292 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8293 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8294 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("shape", Shape.ToName()),
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
