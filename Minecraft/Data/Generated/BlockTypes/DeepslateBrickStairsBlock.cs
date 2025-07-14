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

    public Identifier Category => "minecraft:stair";
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
                            true => 27233,
                            false => 27234,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27235,
                            false => 27236,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27237,
                            false => 27238,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27239,
                            false => 27240,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27241,
                            false => 27242,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27243,
                            false => 27244,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27245,
                            false => 27246,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27247,
                            false => 27248,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27249,
                            false => 27250,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27251,
                            false => 27252,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27253,
                            false => 27254,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27255,
                            false => 27256,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27257,
                            false => 27258,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27259,
                            false => 27260,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27261,
                            false => 27262,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27263,
                            false => 27264,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27265,
                            false => 27266,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27267,
                            false => 27268,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27269,
                            false => 27270,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27271,
                            false => 27272,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27273,
                            false => 27274,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27275,
                            false => 27276,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27277,
                            false => 27278,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27279,
                            false => 27280,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27281,
                            false => 27282,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27283,
                            false => 27284,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27285,
                            false => 27286,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27287,
                            false => 27288,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27289,
                            false => 27290,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27291,
                            false => 27292,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27293,
                            false => 27294,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27295,
                            false => 27296,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27297,
                            false => 27298,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27299,
                            false => 27300,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27301,
                            false => 27302,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27303,
                            false => 27304,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27305,
                            false => 27306,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27307,
                            false => 27308,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27309,
                            false => 27310,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27311,
                            false => 27312,
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
            27233 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27234 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27235 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27236 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27237 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27238 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27239 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27240 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27241 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27242 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27243 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27244 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27245 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27246 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27247 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27248 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27249 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27250 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27251 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27252 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27253 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27254 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27255 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27256 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27257 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27258 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27259 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27260 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27261 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27262 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27263 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27264 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            27265 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            27266 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            27267 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            27268 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            27269 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            27270 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            27271 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            27272 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            27273 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            27274 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            27275 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            27276 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            27277 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            27278 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            27279 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            27280 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            27281 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            27282 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            27283 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            27284 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            27285 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            27286 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            27287 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            27288 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            27289 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            27290 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            27291 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            27292 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            27293 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            27294 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            27295 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            27296 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            27297 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            27298 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            27299 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            27300 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            27301 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            27302 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            27303 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            27304 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            27305 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            27306 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            27307 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            27308 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            27309 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            27310 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            27311 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            27312 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
