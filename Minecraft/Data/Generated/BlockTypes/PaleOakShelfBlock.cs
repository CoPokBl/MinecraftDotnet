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
    public int ProtocolId => 188;
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
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.pale_oak_shelf";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2975,
                            false => 2976,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2977,
                            false => 2978,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2979,
                            false => 2980,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2981,
                            false => 2982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2983,
                            false => 2984,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2985,
                            false => 2986,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2987,
                            false => 2988,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2989,
                            false => 2990,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2991,
                            false => 2992,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2993,
                            false => 2994,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2995,
                            false => 2996,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2997,
                            false => 2998,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2999,
                            false => 3000,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3001,
                            false => 3002,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3003,
                            false => 3004,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3005,
                            false => 3006,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3007,
                            false => 3008,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3009,
                            false => 3010,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3011,
                            false => 3012,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3013,
                            false => 3014,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3015,
                            false => 3016,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3017,
                            false => 3018,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3019,
                            false => 3020,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3021,
                            false => 3022,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3023,
                            false => 3024,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3025,
                            false => 3026,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3027,
                            false => 3028,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3029,
                            false => 3030,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3031,
                            false => 3032,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3033,
                            false => 3034,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3035,
                            false => 3036,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3037,
                            false => 3038,
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
            2975 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2976 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2977 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2978 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2979 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2980 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2981 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2982 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2983 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2984 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2985 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2986 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2987 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2988 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2989 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2990 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2991 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2992 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2993 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2994 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2995 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2996 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2997 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2998 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2999 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3000 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3001 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3002 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3003 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3004 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3005 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3006 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3007 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3008 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3009 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3010 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3011 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3012 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3013 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3014 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3015 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3016 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3017 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3018 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3019 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3020 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3021 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3022 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3023 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3024 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3025 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3026 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3027 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3028 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3029 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3030 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3031 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3032 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3033 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3034 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3035 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3036 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3037 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3038 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
