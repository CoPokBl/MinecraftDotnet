using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCutCopperStairsBlock(Identifier Identifier, Direction Facing, OxidizedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:oxidized_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28048,
                            false => 28049,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28050,
                            false => 28051,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28052,
                            false => 28053,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28054,
                            false => 28055,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28056,
                            false => 28057,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28058,
                            false => 28059,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28060,
                            false => 28061,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28062,
                            false => 28063,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28064,
                            false => 28065,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28066,
                            false => 28067,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28068,
                            false => 28069,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28070,
                            false => 28071,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28072,
                            false => 28073,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28074,
                            false => 28075,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28076,
                            false => 28077,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28078,
                            false => 28079,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28080,
                            false => 28081,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28082,
                            false => 28083,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28084,
                            false => 28085,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28086,
                            false => 28087,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28088,
                            false => 28089,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28090,
                            false => 28091,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28092,
                            false => 28093,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28094,
                            false => 28095,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28096,
                            false => 28097,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28098,
                            false => 28099,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28100,
                            false => 28101,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28102,
                            false => 28103,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28104,
                            false => 28105,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28106,
                            false => 28107,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28108,
                            false => 28109,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28110,
                            false => 28111,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28112,
                            false => 28113,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28114,
                            false => 28115,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28116,
                            false => 28117,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28118,
                            false => 28119,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28120,
                            false => 28121,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28122,
                            false => 28123,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28124,
                            false => 28125,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28126,
                            false => 28127,
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
            28048 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28049 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28050 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28051 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28052 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28053 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28054 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28055 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28056 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28057 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28058 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28059 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28060 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28061 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28062 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28063 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28064 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28065 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28066 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28067 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28068 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28069 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28070 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28071 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28072 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28073 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28074 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28075 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28076 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28077 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28078 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28079 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28080 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28081 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28082 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28083 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28084 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28085 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28086 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28087 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28088 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28089 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28090 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28091 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28092 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28093 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28094 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28095 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28096 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28097 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28098 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28099 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28100 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28101 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28102 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28103 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28104 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28105 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28106 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28107 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28108 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28109 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28110 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28111 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28112 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28113 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28114 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28115 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28116 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28117 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28118 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28119 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28120 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28121 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28122 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28123 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28124 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28125 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28126 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28127 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
