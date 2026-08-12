using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, PaleOakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:pale_oak_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3176,
                            false => 3177,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3178,
                            false => 3179,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3180,
                            false => 3181,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3182,
                            false => 3183,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3184,
                            false => 3185,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3186,
                            false => 3187,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3188,
                            false => 3189,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3190,
                            false => 3191,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3192,
                            false => 3193,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3194,
                            false => 3195,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3196,
                            false => 3197,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3198,
                            false => 3199,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3200,
                            false => 3201,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3202,
                            false => 3203,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3204,
                            false => 3205,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3206,
                            false => 3207,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3208,
                            false => 3209,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3210,
                            false => 3211,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3212,
                            false => 3213,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3214,
                            false => 3215,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3216,
                            false => 3217,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3218,
                            false => 3219,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3220,
                            false => 3221,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3222,
                            false => 3223,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3224,
                            false => 3225,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3226,
                            false => 3227,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3228,
                            false => 3229,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3230,
                            false => 3231,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3232,
                            false => 3233,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3234,
                            false => 3235,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3236,
                            false => 3237,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3238,
                            false => 3239,
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
            3176 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3177 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3178 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3179 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3180 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3181 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3182 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3183 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3184 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3185 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3186 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3187 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3188 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3189 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3190 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3191 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3192 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3193 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3194 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3195 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3196 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3197 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3198 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3199 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3200 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3201 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3202 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3203 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3204 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3205 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3206 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3207 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3208 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3209 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3210 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3211 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3212 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3213 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3214 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3215 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3216 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3217 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3218 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3219 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3220 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3221 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3222 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3223 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3224 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3225 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3226 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3227 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3228 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3229 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3230 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3231 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3232 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3233 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3234 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3235 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3236 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3237 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3238 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3239 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
