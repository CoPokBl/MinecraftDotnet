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
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 768;
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
                            true => 14257,
                            false => 14258,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14259,
                            false => 14260,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14261,
                            false => 14262,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14263,
                            false => 14264,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14265,
                            false => 14266,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14267,
                            false => 14268,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14269,
                            false => 14270,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14271,
                            false => 14272,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14273,
                            false => 14274,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14275,
                            false => 14276,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14277,
                            false => 14278,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14279,
                            false => 14280,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14281,
                            false => 14282,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14283,
                            false => 14284,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14285,
                            false => 14286,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14287,
                            false => 14288,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14289,
                            false => 14290,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14291,
                            false => 14292,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14293,
                            false => 14294,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14295,
                            false => 14296,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14297,
                            false => 14298,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14299,
                            false => 14300,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14301,
                            false => 14302,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14303,
                            false => 14304,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14305,
                            false => 14306,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14307,
                            false => 14308,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14309,
                            false => 14310,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14311,
                            false => 14312,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14313,
                            false => 14314,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14315,
                            false => 14316,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14317,
                            false => 14318,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14319,
                            false => 14320,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14321,
                            false => 14322,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14323,
                            false => 14324,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14325,
                            false => 14326,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14327,
                            false => 14328,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14329,
                            false => 14330,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14331,
                            false => 14332,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14333,
                            false => 14334,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14335,
                            false => 14336,
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
            14257 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14258 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14259 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14260 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14261 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14262 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14263 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14264 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14265 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14266 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14267 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14268 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14269 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14270 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14271 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14272 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14273 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14274 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14275 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14276 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14277 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14278 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14279 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14280 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14281 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14282 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14283 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14284 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14285 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14286 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14287 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14288 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14289 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14290 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14291 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14292 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14293 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14294 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14295 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14296 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14297 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14298 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14299 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14300 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14301 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14302 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14303 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14304 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14305 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14306 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14307 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14308 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14309 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14310 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14311 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14312 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14313 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14314 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14315 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14316 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14317 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14318 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14319 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14320 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14321 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14322 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14323 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14324 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14325 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14326 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14327 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14328 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14329 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14330 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14331 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14332 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14333 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14334 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14335 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14336 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
