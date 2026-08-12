using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceShelfBlock(Identifier Identifier, Direction Facing, bool Powered, SpruceShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.spruce_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:spruce_shelf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 34, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S81, BlockShapes.S81, BlockShapes.S1, BlockShapes.S81, BlockShapes.S81);
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

    public BlockStateInfo StateInfo => States[StateId - 3240];

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
                            true => 3240,
                            false => 3241,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3242,
                            false => 3243,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3244,
                            false => 3245,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3246,
                            false => 3247,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3248,
                            false => 3249,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3250,
                            false => 3251,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3252,
                            false => 3253,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3254,
                            false => 3255,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3256,
                            false => 3257,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3258,
                            false => 3259,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3260,
                            false => 3261,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3262,
                            false => 3263,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3264,
                            false => 3265,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3266,
                            false => 3267,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3268,
                            false => 3269,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3270,
                            false => 3271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3272,
                            false => 3273,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3274,
                            false => 3275,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3276,
                            false => 3277,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3278,
                            false => 3279,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3280,
                            false => 3281,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3282,
                            false => 3283,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3284,
                            false => 3285,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3286,
                            false => 3287,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3288,
                            false => 3289,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3290,
                            false => 3291,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3292,
                            false => 3293,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3294,
                            false => 3295,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3296,
                            false => 3297,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3298,
                            false => 3299,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3300,
                            false => 3301,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3302,
                            false => 3303,
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
            3240 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3241 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3242 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3243 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3244 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3245 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3246 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3247 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3248 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3249 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3250 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3251 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3252 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3253 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3254 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3255 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3256 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3257 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3258 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3259 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3260 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3261 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3262 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3263 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3264 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3265 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3266 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3267 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3268 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3269 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3270 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3271 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3272 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3273 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3274 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3275 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3276 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3277 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3278 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3279 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3280 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3281 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3282 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3283 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3284 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3285 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3286 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3287 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3288 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3289 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3290 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3291 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3292 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3293 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3294 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3295 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3296 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3297 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3298 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3299 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3300 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3301 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3302 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3303 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
