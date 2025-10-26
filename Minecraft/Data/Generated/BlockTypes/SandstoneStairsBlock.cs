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
    public int ProtocolId => 396;
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
                            true => 9292,
                            false => 9293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9294,
                            false => 9295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9296,
                            false => 9297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9298,
                            false => 9299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9300,
                            false => 9301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9302,
                            false => 9303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9304,
                            false => 9305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9306,
                            false => 9307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9308,
                            false => 9309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9310,
                            false => 9311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9312,
                            false => 9313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9314,
                            false => 9315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9316,
                            false => 9317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9318,
                            false => 9319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9320,
                            false => 9321,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9322,
                            false => 9323,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9324,
                            false => 9325,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9326,
                            false => 9327,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9328,
                            false => 9329,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9330,
                            false => 9331,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9332,
                            false => 9333,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9334,
                            false => 9335,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9336,
                            false => 9337,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9338,
                            false => 9339,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9340,
                            false => 9341,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9342,
                            false => 9343,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9344,
                            false => 9345,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9346,
                            false => 9347,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9348,
                            false => 9349,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9350,
                            false => 9351,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9352,
                            false => 9353,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9354,
                            false => 9355,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9356,
                            false => 9357,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9358,
                            false => 9359,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9360,
                            false => 9361,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9362,
                            false => 9363,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9364,
                            false => 9365,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9366,
                            false => 9367,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9368,
                            false => 9369,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9370,
                            false => 9371,
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
            9292 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9293 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9294 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9295 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9296 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9297 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9298 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9299 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9300 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9301 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9302 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9303 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9304 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9305 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9306 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9307 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9308 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9309 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9310 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9311 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9312 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9313 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9314 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9315 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9316 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9317 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9318 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9319 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9320 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9321 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9322 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9323 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9324 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9325 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9326 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9327 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9328 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9329 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9330 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9331 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9332 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9333 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9334 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9335 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9336 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9337 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9338 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9339 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9340 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9341 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9342 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9343 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9344 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9345 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9346 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9347 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9348 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9349 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9350 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9351 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9352 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9353 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9354 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9355 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9356 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9357 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9358 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9359 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9360 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9361 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9362 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9363 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9364 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9365 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9366 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9367 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9368 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9369 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9370 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9371 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
