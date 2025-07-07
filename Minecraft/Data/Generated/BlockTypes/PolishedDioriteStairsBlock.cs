using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDioriteStairsBlock(Identifier Identifier, Direction Facing, PolishedDioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public double Hardness => 1.5;
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
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_diorite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.polished_diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14225,
                            false => 14226,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14227,
                            false => 14228,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14229,
                            false => 14230,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14231,
                            false => 14232,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14233,
                            false => 14234,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14235,
                            false => 14236,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14237,
                            false => 14238,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14239,
                            false => 14240,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14241,
                            false => 14242,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14243,
                            false => 14244,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14245,
                            false => 14246,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14247,
                            false => 14248,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14249,
                            false => 14250,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14251,
                            false => 14252,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14253,
                            false => 14254,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14255,
                            false => 14256,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14257,
                            false => 14258,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14259,
                            false => 14260,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14261,
                            false => 14262,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14263,
                            false => 14264,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14265,
                            false => 14266,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14267,
                            false => 14268,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14269,
                            false => 14270,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14271,
                            false => 14272,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14273,
                            false => 14274,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14275,
                            false => 14276,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14277,
                            false => 14278,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14279,
                            false => 14280,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14281,
                            false => 14282,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14283,
                            false => 14284,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14285,
                            false => 14286,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14287,
                            false => 14288,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14289,
                            false => 14290,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14291,
                            false => 14292,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14293,
                            false => 14294,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14295,
                            false => 14296,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14297,
                            false => 14298,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14299,
                            false => 14300,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14301,
                            false => 14302,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14303,
                            false => 14304,
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
            14225 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14226 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14227 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14228 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14229 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14230 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14231 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14232 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14233 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14234 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14235 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14236 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14237 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14238 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14239 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14240 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14241 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14242 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14243 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14244 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14245 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14246 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14247 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14248 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14249 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14250 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14251 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14252 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14253 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14254 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14255 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14256 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14257 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14258 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14259 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14260 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14261 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14262 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14263 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14264 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14265 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14266 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14267 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14268 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14269 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14270 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14271 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14272 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14273 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14274 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14275 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14276 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14277 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14278 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14279 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14280 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14281 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14282 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14283 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14284 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14285 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14286 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14287 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14288 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14289 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14290 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14291 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14292 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14293 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14294 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14295 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14296 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14297 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14298 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14299 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14300 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14301 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14302 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14303 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14304 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
