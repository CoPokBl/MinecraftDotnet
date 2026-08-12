using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, OakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
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
    public string SoundType => "shelf";
    public Identifier? BlockEntity => "minecraft:shelf";
    public Identifier? Item => "minecraft:oak_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3112,
                            false => 3113,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3114,
                            false => 3115,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3116,
                            false => 3117,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3118,
                            false => 3119,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3120,
                            false => 3121,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3122,
                            false => 3123,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3124,
                            false => 3125,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3126,
                            false => 3127,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3128,
                            false => 3129,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3130,
                            false => 3131,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3132,
                            false => 3133,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3134,
                            false => 3135,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3136,
                            false => 3137,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3138,
                            false => 3139,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3140,
                            false => 3141,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3142,
                            false => 3143,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3144,
                            false => 3145,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3146,
                            false => 3147,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3148,
                            false => 3149,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3150,
                            false => 3151,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3152,
                            false => 3153,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3154,
                            false => 3155,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3156,
                            false => 3157,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3158,
                            false => 3159,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3160,
                            false => 3161,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3162,
                            false => 3163,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3164,
                            false => 3165,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3166,
                            false => 3167,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3168,
                            false => 3169,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3170,
                            false => 3171,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3172,
                            false => 3173,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3174,
                            false => 3175,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3112 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3113 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3114 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3115 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3116 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3117 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3118 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3119 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3120 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3121 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3122 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3123 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3124 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3125 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3126 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3127 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3128 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3129 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3130 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3131 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3132 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3133 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3134 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3135 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3136 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3137 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3138 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3139 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3140 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3141 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3142 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3143 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3144 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3145 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3146 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3147 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3148 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3149 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3150 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3151 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3152 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3153 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3154 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3155 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3156 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3157 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3158 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3159 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3160 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3161 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3162 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3163 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3164 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3165 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3166 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3167 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3168 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3169 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3170 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3171 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3172 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3173 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3174 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3175 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            SideChainValue = properties.Contains("side_chain") ? SideChainFromString(properties["side_chain"].GetString()) : SideChainValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("side_chain", new StringTag(SideChainToName(SideChainValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum SideChain {
        Unconnected,
        Right,
        Center,
        Left,
    }

    public static SideChain SideChainFromString(string value) {
        return value switch {
            "unconnected" => SideChain.Unconnected,
            "right" => SideChain.Right,
            "center" => SideChain.Center,
            "left" => SideChain.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SideChain.")
        };
    }

    public static string SideChainToName(SideChain value) {
        return value switch {
            SideChain.Unconnected => "unconnected",
            SideChain.Right => "right",
            SideChain.Center => "center",
            SideChain.Left => "left",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SideChain value.")
        };
    }
}
