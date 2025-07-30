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
    public int ProtocolId => 946;
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
                            true => 22148,
                            false => 22149,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22150,
                            false => 22151,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22152,
                            false => 22153,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22154,
                            false => 22155,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22156,
                            false => 22157,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22158,
                            false => 22159,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22160,
                            false => 22161,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22162,
                            false => 22163,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22164,
                            false => 22165,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22166,
                            false => 22167,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22168,
                            false => 22169,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22170,
                            false => 22171,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22172,
                            false => 22173,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22174,
                            false => 22175,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22176,
                            false => 22177,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22178,
                            false => 22179,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22180,
                            false => 22181,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22182,
                            false => 22183,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22184,
                            false => 22185,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22186,
                            false => 22187,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22188,
                            false => 22189,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22190,
                            false => 22191,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22192,
                            false => 22193,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22194,
                            false => 22195,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22196,
                            false => 22197,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22198,
                            false => 22199,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22200,
                            false => 22201,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22202,
                            false => 22203,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22204,
                            false => 22205,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22206,
                            false => 22207,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22208,
                            false => 22209,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22210,
                            false => 22211,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22212,
                            false => 22213,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22214,
                            false => 22215,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22216,
                            false => 22217,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22218,
                            false => 22219,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22220,
                            false => 22221,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22222,
                            false => 22223,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22224,
                            false => 22225,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22226,
                            false => 22227,
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
            22148 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22149 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22150 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22151 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22152 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22153 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22154 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22155 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22156 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22157 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22158 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22159 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22160 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22161 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22162 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22163 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22164 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22165 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22166 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22167 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22168 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22169 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22170 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22171 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22172 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22173 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22174 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22175 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22176 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22177 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22178 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22179 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22180 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22181 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22182 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22183 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22184 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22185 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22186 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22187 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22188 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22189 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22190 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22191 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22192 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22193 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22194 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22195 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22196 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22197 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22198 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22199 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22200 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22201 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22202 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22203 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22204 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22205 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22206 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22207 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22208 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22209 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22210 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22211 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22212 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22213 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22214 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22215 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22216 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22217 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22218 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22219 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22220 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22221 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22222 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22223 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22224 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22225 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22226 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22227 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
