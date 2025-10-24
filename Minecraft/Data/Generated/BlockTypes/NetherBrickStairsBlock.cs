using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickStairsBlock(Identifier Identifier, Direction Facing, NetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 382;
    public double Hardness => 2;
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
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:nether_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.nether_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9166,
                            false => 9167,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9168,
                            false => 9169,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9170,
                            false => 9171,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9172,
                            false => 9173,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9174,
                            false => 9175,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9176,
                            false => 9177,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9178,
                            false => 9179,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9180,
                            false => 9181,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9182,
                            false => 9183,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9184,
                            false => 9185,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9186,
                            false => 9187,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9188,
                            false => 9189,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9190,
                            false => 9191,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9192,
                            false => 9193,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9194,
                            false => 9195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9196,
                            false => 9197,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9198,
                            false => 9199,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9200,
                            false => 9201,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9202,
                            false => 9203,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9204,
                            false => 9205,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9206,
                            false => 9207,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9208,
                            false => 9209,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9210,
                            false => 9211,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9212,
                            false => 9213,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9214,
                            false => 9215,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9216,
                            false => 9217,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9218,
                            false => 9219,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9220,
                            false => 9221,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9222,
                            false => 9223,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9224,
                            false => 9225,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9226,
                            false => 9227,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9228,
                            false => 9229,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9230,
                            false => 9231,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9232,
                            false => 9233,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9234,
                            false => 9235,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9236,
                            false => 9237,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9238,
                            false => 9239,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9240,
                            false => 9241,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9242,
                            false => 9243,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9244,
                            false => 9245,
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
            9166 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9167 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9168 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9169 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9170 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9171 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9172 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9173 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9174 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9175 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9176 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9177 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9178 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9179 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9180 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9181 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9182 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9183 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9184 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9185 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9186 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9187 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9188 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9189 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9190 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9191 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9192 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9193 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9194 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9195 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9196 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9197 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9198 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9199 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9200 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9201 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9202 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9203 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9204 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9205 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9206 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9207 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9208 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9209 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9210 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9211 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9212 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9213 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9214 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9215 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9216 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9217 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9218 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9219 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9220 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9221 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9222 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9223 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9224 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9225 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9226 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9227 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9228 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9229 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9230 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9231 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9232 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9233 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9234 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9235 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9236 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9237 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9238 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9239 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9240 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9241 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9242 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9243 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9244 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9245 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
