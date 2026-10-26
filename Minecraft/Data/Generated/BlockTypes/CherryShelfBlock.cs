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
public record CherryShelfBlock(Identifier Identifier, Direction Facing, bool Powered, CherryShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:cherry_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 36, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 4284];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
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
                            true => 4284,
                            false => 4285,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4286,
                            false => 4287,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4288,
                            false => 4289,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4290,
                            false => 4291,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4292,
                            false => 4293,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4294,
                            false => 4295,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4296,
                            false => 4297,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4298,
                            false => 4299,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4300,
                            false => 4301,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4302,
                            false => 4303,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4304,
                            false => 4305,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4306,
                            false => 4307,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4308,
                            false => 4309,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4310,
                            false => 4311,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4312,
                            false => 4313,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4314,
                            false => 4315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4316,
                            false => 4317,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4318,
                            false => 4319,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4320,
                            false => 4321,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4322,
                            false => 4323,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4324,
                            false => 4325,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4326,
                            false => 4327,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4328,
                            false => 4329,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4330,
                            false => 4331,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4332,
                            false => 4333,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4334,
                            false => 4335,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4336,
                            false => 4337,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4338,
                            false => 4339,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4340,
                            false => 4341,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4342,
                            false => 4343,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4344,
                            false => 4345,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4346,
                            false => 4347,
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
            4284 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4285 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4286 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4287 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4288 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4289 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4290 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4291 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4292 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4293 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4294 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4295 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4296 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4297 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4298 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4299 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4300 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4301 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4302 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4303 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4304 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4305 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4306 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4307 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4308 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4309 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4310 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4311 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4312 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4313 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4314 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4315 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4316 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4317 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4318 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4319 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4320 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4321 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4322 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4323 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4324 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4325 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4326 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4327 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4328 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4329 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4330 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4331 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4332 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4333 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4334 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4335 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4336 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4337 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4338 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4339 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4340 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4341 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4342 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4343 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4344 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4345 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4346 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4347 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
