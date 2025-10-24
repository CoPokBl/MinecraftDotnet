using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffStairsBlock(Identifier Identifier, Direction Facing, TuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 984;
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
    public string SoundType => "tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23257,
                            false => 23258,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23259,
                            false => 23260,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23261,
                            false => 23262,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23263,
                            false => 23264,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23265,
                            false => 23266,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23267,
                            false => 23268,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23269,
                            false => 23270,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23271,
                            false => 23272,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23273,
                            false => 23274,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23275,
                            false => 23276,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23277,
                            false => 23278,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23279,
                            false => 23280,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23281,
                            false => 23282,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23283,
                            false => 23284,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23285,
                            false => 23286,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23287,
                            false => 23288,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23289,
                            false => 23290,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23291,
                            false => 23292,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23293,
                            false => 23294,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23295,
                            false => 23296,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23297,
                            false => 23298,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23299,
                            false => 23300,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23301,
                            false => 23302,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23303,
                            false => 23304,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23305,
                            false => 23306,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23307,
                            false => 23308,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23309,
                            false => 23310,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23311,
                            false => 23312,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23313,
                            false => 23314,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23315,
                            false => 23316,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23317,
                            false => 23318,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23319,
                            false => 23320,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23321,
                            false => 23322,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23323,
                            false => 23324,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23325,
                            false => 23326,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23327,
                            false => 23328,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23329,
                            false => 23330,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23331,
                            false => 23332,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23333,
                            false => 23334,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23335,
                            false => 23336,
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
            23257 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23258 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23259 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23260 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23261 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23262 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23263 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23264 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23265 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23266 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23267 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23268 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23269 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23270 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23271 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23272 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            23273 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            23274 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            23275 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            23276 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            23277 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            23278 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            23279 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            23280 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            23281 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            23282 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            23283 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            23284 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            23285 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23286 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23287 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23288 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23289 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23290 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23291 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23292 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23293 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23294 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23295 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23296 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23297 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23298 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23299 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23300 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23301 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23302 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23303 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23304 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23305 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23306 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23307 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23308 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23309 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23310 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23311 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23312 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23313 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23314 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23315 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23316 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23317 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23318 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23319 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23320 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23321 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23322 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23323 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23324 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23325 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23326 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23327 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23328 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23329 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23330 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23331 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23332 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23333 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23334 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23335 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23336 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
