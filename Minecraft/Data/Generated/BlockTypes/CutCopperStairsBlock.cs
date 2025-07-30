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
    public int ProtocolId => 988;
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
                            true => 24256,
                            false => 24257,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24258,
                            false => 24259,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24260,
                            false => 24261,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24262,
                            false => 24263,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24264,
                            false => 24265,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24266,
                            false => 24267,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24268,
                            false => 24269,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24270,
                            false => 24271,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24272,
                            false => 24273,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24274,
                            false => 24275,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24276,
                            false => 24277,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24278,
                            false => 24279,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24280,
                            false => 24281,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24282,
                            false => 24283,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24284,
                            false => 24285,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24286,
                            false => 24287,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24288,
                            false => 24289,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24290,
                            false => 24291,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24292,
                            false => 24293,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24294,
                            false => 24295,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24296,
                            false => 24297,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24298,
                            false => 24299,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24300,
                            false => 24301,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24302,
                            false => 24303,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24304,
                            false => 24305,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24306,
                            false => 24307,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24308,
                            false => 24309,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24310,
                            false => 24311,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24312,
                            false => 24313,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24314,
                            false => 24315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24316,
                            false => 24317,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24318,
                            false => 24319,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24320,
                            false => 24321,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24322,
                            false => 24323,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24324,
                            false => 24325,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24326,
                            false => 24327,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24328,
                            false => 24329,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24330,
                            false => 24331,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24332,
                            false => 24333,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24334,
                            false => 24335,
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
            24256 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24257 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24258 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24259 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24260 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24261 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24262 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24263 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24264 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24265 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24266 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24267 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24268 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24269 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24270 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24271 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24272 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24273 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24274 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24275 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24276 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24277 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24278 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24279 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24280 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24281 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24282 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24283 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24284 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24285 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24286 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24287 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24288 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24289 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24290 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24291 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24292 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24293 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24294 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24295 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24296 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24297 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24298 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24299 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24300 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24301 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24302 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24303 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24304 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24305 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24306 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24307 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24308 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24309 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24310 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24311 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24312 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24313 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24314 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24315 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24316 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24317 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24318 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24319 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24320 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24321 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24322 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24323 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24324 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24325 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24326 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24327 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24328 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24329 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24330 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24331 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24332 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24333 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24334 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24335 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
