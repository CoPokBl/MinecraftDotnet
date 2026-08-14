using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedShelfBlock(Identifier Identifier, Direction Facing, bool Powered, WarpedShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.warped_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:warped_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/warped_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 56, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 3304];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
    public ICollisionBox SupportShape => StateInfo.SupportShape;
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
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3304,
                            false => 3305,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3306,
                            false => 3307,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3308,
                            false => 3309,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3310,
                            false => 3311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3312,
                            false => 3313,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3314,
                            false => 3315,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3316,
                            false => 3317,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3318,
                            false => 3319,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3320,
                            false => 3321,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3322,
                            false => 3323,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3324,
                            false => 3325,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3326,
                            false => 3327,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3328,
                            false => 3329,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3330,
                            false => 3331,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3332,
                            false => 3333,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3334,
                            false => 3335,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3336,
                            false => 3337,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3338,
                            false => 3339,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3340,
                            false => 3341,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3342,
                            false => 3343,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3344,
                            false => 3345,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3346,
                            false => 3347,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3348,
                            false => 3349,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3350,
                            false => 3351,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3352,
                            false => 3353,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3354,
                            false => 3355,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3356,
                            false => 3357,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3358,
                            false => 3359,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3360,
                            false => 3361,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3362,
                            false => 3363,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3364,
                            false => 3365,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3366,
                            false => 3367,
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
            3304 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3305 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3306 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3307 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3308 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3309 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3310 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3311 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3312 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3313 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3314 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3315 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3316 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3317 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3318 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3319 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3320 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3321 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3322 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3323 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3324 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3325 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3326 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3327 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3328 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3329 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3330 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3331 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3332 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3333 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3334 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3335 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3336 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3337 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3338 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3339 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3340 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3341 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3342 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3343 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3344 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3345 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3346 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3347 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3348 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3349 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3350 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3351 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3352 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3353 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3354 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3355 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3356 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3357 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3358 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3359 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3360 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3361 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3362 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3363 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3364 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3365 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3366 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3367 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
