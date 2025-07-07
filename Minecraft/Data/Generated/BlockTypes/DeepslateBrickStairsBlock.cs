using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateBrickStairsBlock(Identifier Identifier, Direction Facing, DeepslateBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public double Hardness => 3.5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "deepslate_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:deepslate_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.deepslate_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27201,
                            false => 27202,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27203,
                            false => 27204,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27205,
                            false => 27206,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27207,
                            false => 27208,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27209,
                            false => 27210,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27211,
                            false => 27212,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27213,
                            false => 27214,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27215,
                            false => 27216,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27217,
                            false => 27218,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27219,
                            false => 27220,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27221,
                            false => 27222,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27223,
                            false => 27224,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27225,
                            false => 27226,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27227,
                            false => 27228,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27229,
                            false => 27230,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27231,
                            false => 27232,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27233,
                            false => 27234,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27235,
                            false => 27236,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27237,
                            false => 27238,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27239,
                            false => 27240,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27241,
                            false => 27242,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27243,
                            false => 27244,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27245,
                            false => 27246,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27247,
                            false => 27248,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27249,
                            false => 27250,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27251,
                            false => 27252,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27253,
                            false => 27254,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27255,
                            false => 27256,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27257,
                            false => 27258,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27259,
                            false => 27260,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27261,
                            false => 27262,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27263,
                            false => 27264,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27265,
                            false => 27266,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27267,
                            false => 27268,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27269,
                            false => 27270,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27271,
                            false => 27272,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27273,
                            false => 27274,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27275,
                            false => 27276,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27277,
                            false => 27278,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27279,
                            false => 27280,
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
            27201 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27202 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27203 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27204 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27205 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27206 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27207 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27208 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27209 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27210 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27211 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27212 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27213 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27214 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27215 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27216 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27217 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27218 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27219 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27220 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27221 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27222 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27223 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27224 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27225 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27226 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27227 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27228 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27229 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27230 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27231 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27232 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            27233 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            27234 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            27235 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            27236 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            27237 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            27238 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            27239 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            27240 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            27241 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            27242 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            27243 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            27244 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            27245 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            27246 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            27247 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            27248 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            27249 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            27250 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            27251 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            27252 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            27253 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            27254 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            27255 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            27256 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            27257 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            27258 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            27259 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            27260 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            27261 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            27262 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            27263 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            27264 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            27265 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            27266 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            27267 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            27268 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            27269 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            27270 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            27271 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            27272 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            27273 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            27274 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            27275 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            27276 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            27277 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            27278 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            27279 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            27280 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
