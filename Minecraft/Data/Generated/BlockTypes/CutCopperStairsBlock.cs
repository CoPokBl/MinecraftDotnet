using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutCopperStairsBlock(Identifier Identifier, Direction Facing, CutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:weathering_copper_stair";
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
    public Identifier? Item => "minecraft:cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24224,
                            false => 24225,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24226,
                            false => 24227,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24228,
                            false => 24229,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24230,
                            false => 24231,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24232,
                            false => 24233,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24234,
                            false => 24235,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24236,
                            false => 24237,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24238,
                            false => 24239,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24240,
                            false => 24241,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24242,
                            false => 24243,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24244,
                            false => 24245,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24246,
                            false => 24247,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24248,
                            false => 24249,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24250,
                            false => 24251,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24252,
                            false => 24253,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24254,
                            false => 24255,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24256,
                            false => 24257,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24258,
                            false => 24259,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24260,
                            false => 24261,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24262,
                            false => 24263,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24264,
                            false => 24265,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24266,
                            false => 24267,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24268,
                            false => 24269,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24270,
                            false => 24271,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24272,
                            false => 24273,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24274,
                            false => 24275,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24276,
                            false => 24277,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24278,
                            false => 24279,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24280,
                            false => 24281,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24282,
                            false => 24283,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24284,
                            false => 24285,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24286,
                            false => 24287,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24288,
                            false => 24289,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24290,
                            false => 24291,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24292,
                            false => 24293,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24294,
                            false => 24295,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24296,
                            false => 24297,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24298,
                            false => 24299,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24300,
                            false => 24301,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24302,
                            false => 24303,
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
            24224 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24225 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24226 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24227 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24228 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24229 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24230 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24231 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24232 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24233 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24234 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24235 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24236 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24237 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24238 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24239 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24240 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24241 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24242 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24243 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24244 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24245 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24246 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24247 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24248 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24249 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24250 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24251 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24252 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24253 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24254 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24255 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24256 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24257 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24258 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24259 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24260 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24261 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24262 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24263 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24264 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24265 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24266 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24267 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24268 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24269 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24270 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24271 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24272 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24273 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24274 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24275 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24276 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24277 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24278 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24279 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24280 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24281 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24282 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24283 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24284 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24285 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24286 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24287 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24288 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24289 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24290 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24291 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24292 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24293 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24294 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24295 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24296 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24297 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24298 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24299 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24300 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24301 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24302 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24303 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
