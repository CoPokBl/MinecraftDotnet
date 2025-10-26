using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedShelfBlock(Identifier Identifier, Direction Facing, bool Powered, WarpedShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:shelf";
    public int ProtocolId => 190;
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
    public Identifier? Item => "minecraft:warped_shelf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.6875] -> [1.0, 0.25, 1.0], AABB[0.0, 0.25, 0.8125] -> [1.0, 1.0, 1.0], AABB[0.0, 0.75, 0.6875] -> [1.0, 1.0, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.warped_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3103,
                            false => 3104,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3105,
                            false => 3106,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3107,
                            false => 3108,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3109,
                            false => 3110,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3111,
                            false => 3112,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3113,
                            false => 3114,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3115,
                            false => 3116,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3117,
                            false => 3118,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3119,
                            false => 3120,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3121,
                            false => 3122,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3123,
                            false => 3124,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3125,
                            false => 3126,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3127,
                            false => 3128,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3129,
                            false => 3130,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3131,
                            false => 3132,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3133,
                            false => 3134,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3135,
                            false => 3136,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3137,
                            false => 3138,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3139,
                            false => 3140,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3141,
                            false => 3142,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3143,
                            false => 3144,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3145,
                            false => 3146,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3147,
                            false => 3148,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3149,
                            false => 3150,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3151,
                            false => 3152,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3153,
                            false => 3154,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3155,
                            false => 3156,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3157,
                            false => 3158,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3159,
                            false => 3160,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3161,
                            false => 3162,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3163,
                            false => 3164,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3165,
                            false => 3166,
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
            3103 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3104 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3105 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3106 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3107 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3108 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3109 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3110 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3111 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3112 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3113 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3114 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3115 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3116 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3117 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3118 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3119 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3120 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3121 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3122 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3123 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3124 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3125 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3126 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3127 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3128 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3129 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3130 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3131 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3132 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3133 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3134 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3135 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3136 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3137 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3138 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3139 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3140 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3141 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3142 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3143 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3144 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3145 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3146 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3147 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3148 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3149 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3150 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3151 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3152 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3153 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3154 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3155 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3156 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3157 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3158 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3159 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3160 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3161 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3162 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3163 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3164 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3165 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3166 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            SideChainValue = properties.ChildrenMap.ContainsKey("side_chain") ? SideChainFromString(properties["side_chain"].GetString()) : SideChainValue,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("side_chain", SideChainToName(SideChainValue)),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
