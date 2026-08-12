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
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.oak_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:oak_shelf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 13, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S81, BlockShapes.S81, BlockShapes.S1, BlockShapes.S81, BlockShapes.S81);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 3112];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


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
