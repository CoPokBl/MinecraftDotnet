using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedExposedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_exposed_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28208,
                            false => 28209,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28210,
                            false => 28211,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28212,
                            false => 28213,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28214,
                            false => 28215,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28216,
                            false => 28217,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28218,
                            false => 28219,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28220,
                            false => 28221,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28222,
                            false => 28223,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28224,
                            false => 28225,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28226,
                            false => 28227,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28228,
                            false => 28229,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28230,
                            false => 28231,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28232,
                            false => 28233,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28234,
                            false => 28235,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28236,
                            false => 28237,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28238,
                            false => 28239,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28240,
                            false => 28241,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28242,
                            false => 28243,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28244,
                            false => 28245,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28246,
                            false => 28247,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28248,
                            false => 28249,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28250,
                            false => 28251,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28252,
                            false => 28253,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28254,
                            false => 28255,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28256,
                            false => 28257,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28258,
                            false => 28259,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28260,
                            false => 28261,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28262,
                            false => 28263,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28264,
                            false => 28265,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28266,
                            false => 28267,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28268,
                            false => 28269,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28270,
                            false => 28271,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28272,
                            false => 28273,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28274,
                            false => 28275,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28276,
                            false => 28277,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28278,
                            false => 28279,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28280,
                            false => 28281,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28282,
                            false => 28283,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28284,
                            false => 28285,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28286,
                            false => 28287,
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
            28208 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28209 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28210 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28211 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28212 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28213 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28214 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28215 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28216 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28217 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28218 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28219 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28220 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28221 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28222 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28223 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28224 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28225 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28226 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28227 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28228 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28229 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28230 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28231 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28232 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28233 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28234 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28235 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28236 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28237 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28238 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28239 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28240 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28241 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28242 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28243 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28244 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28245 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28246 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28247 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28248 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28249 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28250 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28251 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28252 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28253 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28254 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28255 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28256 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28257 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28258 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28259 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28260 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28261 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28262 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28263 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28264 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28265 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28266 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28267 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28268 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28269 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28270 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28271 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28272 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28273 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28274 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28275 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28276 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28277 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28278 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28279 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28280 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28281 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28282 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28283 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28284 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28285 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28286 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28287 => new WaxedExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
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
