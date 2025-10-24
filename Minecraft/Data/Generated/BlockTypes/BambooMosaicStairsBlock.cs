using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooMosaicStairsBlock(Identifier Identifier, Direction Facing, BambooMosaicStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 520;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_mosaic_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_mosaic_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12250,
                            false => 12251,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12252,
                            false => 12253,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12254,
                            false => 12255,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12256,
                            false => 12257,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12258,
                            false => 12259,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12260,
                            false => 12261,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12262,
                            false => 12263,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12264,
                            false => 12265,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12266,
                            false => 12267,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12268,
                            false => 12269,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12270,
                            false => 12271,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12272,
                            false => 12273,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12274,
                            false => 12275,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12276,
                            false => 12277,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12278,
                            false => 12279,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12280,
                            false => 12281,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12282,
                            false => 12283,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12284,
                            false => 12285,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12286,
                            false => 12287,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12288,
                            false => 12289,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12290,
                            false => 12291,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12292,
                            false => 12293,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12294,
                            false => 12295,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12296,
                            false => 12297,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12298,
                            false => 12299,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12300,
                            false => 12301,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12302,
                            false => 12303,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12304,
                            false => 12305,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12306,
                            false => 12307,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12308,
                            false => 12309,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12310,
                            false => 12311,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12312,
                            false => 12313,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12314,
                            false => 12315,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12316,
                            false => 12317,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12318,
                            false => 12319,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12320,
                            false => 12321,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12322,
                            false => 12323,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12324,
                            false => 12325,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12326,
                            false => 12327,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12328,
                            false => 12329,
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
            12250 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12251 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12252 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12253 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12254 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12255 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12256 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12257 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12258 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12259 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12260 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12261 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12262 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12263 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12264 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12265 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12266 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12267 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12268 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12269 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12270 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12271 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12272 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12273 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12274 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12275 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12276 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12277 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12278 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12279 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12280 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12281 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12282 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12283 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12284 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12285 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12286 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12287 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12288 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12289 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12290 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12291 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12292 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12293 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12294 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12295 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12296 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12297 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12298 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12299 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12300 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12301 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12302 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12303 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12304 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12305 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12306 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12307 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12308 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12309 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12310 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12311 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12312 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12313 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12314 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12315 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12316 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12317 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12318 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12319 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12320 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12321 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12322 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12323 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12324 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12325 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12326 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12327 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12328 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12329 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
