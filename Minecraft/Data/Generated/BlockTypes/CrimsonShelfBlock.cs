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
public record CrimsonShelfBlock(Identifier Identifier, Direction Facing, bool Powered, CrimsonShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.crimson_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:crimson_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 53, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 4348];

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
                            true => 4348,
                            false => 4349,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4350,
                            false => 4351,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4352,
                            false => 4353,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4354,
                            false => 4355,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4356,
                            false => 4357,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4358,
                            false => 4359,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4360,
                            false => 4361,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4362,
                            false => 4363,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4364,
                            false => 4365,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4366,
                            false => 4367,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4368,
                            false => 4369,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4370,
                            false => 4371,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4372,
                            false => 4373,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4374,
                            false => 4375,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4376,
                            false => 4377,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4378,
                            false => 4379,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4380,
                            false => 4381,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4382,
                            false => 4383,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4384,
                            false => 4385,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4386,
                            false => 4387,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4388,
                            false => 4389,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4390,
                            false => 4391,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4392,
                            false => 4393,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4394,
                            false => 4395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4396,
                            false => 4397,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4398,
                            false => 4399,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4400,
                            false => 4401,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4402,
                            false => 4403,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4404,
                            false => 4405,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4406,
                            false => 4407,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4408,
                            false => 4409,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4410,
                            false => 4411,
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
            4348 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4349 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4350 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4351 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4352 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4353 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4354 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4355 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4356 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4357 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4358 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4359 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4360 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4361 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4362 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4363 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4364 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4365 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4366 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4367 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4368 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4369 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4370 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4371 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4372 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4373 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4374 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4375 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4376 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4377 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4378 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4379 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4380 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4381 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4382 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4383 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4384 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4385 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4386 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4387 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4388 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4389 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4390 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4391 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4392 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4393 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4394 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4395 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4396 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4397 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4398 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4399 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4400 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4401 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4402 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4403 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4404 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4405 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4406 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4407 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4408 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4409 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4410 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4411 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
