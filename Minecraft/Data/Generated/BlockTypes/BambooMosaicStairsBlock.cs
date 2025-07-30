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
    public int ProtocolId => 490;
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
                            true => 11173,
                            false => 11174,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11175,
                            false => 11176,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11177,
                            false => 11178,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11179,
                            false => 11180,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11181,
                            false => 11182,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11183,
                            false => 11184,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11185,
                            false => 11186,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11187,
                            false => 11188,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11189,
                            false => 11190,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11191,
                            false => 11192,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11193,
                            false => 11194,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11195,
                            false => 11196,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11197,
                            false => 11198,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11199,
                            false => 11200,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11201,
                            false => 11202,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11203,
                            false => 11204,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11205,
                            false => 11206,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11207,
                            false => 11208,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11209,
                            false => 11210,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11211,
                            false => 11212,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11213,
                            false => 11214,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11215,
                            false => 11216,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11217,
                            false => 11218,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11219,
                            false => 11220,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11221,
                            false => 11222,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11223,
                            false => 11224,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11225,
                            false => 11226,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11227,
                            false => 11228,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11229,
                            false => 11230,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11231,
                            false => 11232,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11233,
                            false => 11234,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11235,
                            false => 11236,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11237,
                            false => 11238,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11239,
                            false => 11240,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11241,
                            false => 11242,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11243,
                            false => 11244,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11245,
                            false => 11246,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11247,
                            false => 11248,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11249,
                            false => 11250,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11251,
                            false => 11252,
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
            11173 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11174 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11175 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11176 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11177 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11178 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11179 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11180 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11181 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11182 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11183 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11184 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11185 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11186 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11187 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11188 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11189 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11190 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11191 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11192 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11193 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11194 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11195 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11196 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11197 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11198 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11199 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11200 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11201 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11202 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11203 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11204 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11205 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11206 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11207 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11208 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11209 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11210 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11211 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11212 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11213 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11214 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11215 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11216 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11217 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11218 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11219 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11220 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11221 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11222 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11223 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11224 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11225 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11226 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11227 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11228 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11229 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11230 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11231 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11232 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11233 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11234 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11235 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11236 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11237 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11238 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11239 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11240 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11241 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11242 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11243 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11244 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11245 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11246 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11247 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11248 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11249 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11250 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11251 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11252 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
