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
public record DarkOakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, DarkOakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:dark_oak_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 26, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4412];

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
                            true => 4412,
                            false => 4413,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4414,
                            false => 4415,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4416,
                            false => 4417,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4418,
                            false => 4419,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4420,
                            false => 4421,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4422,
                            false => 4423,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4424,
                            false => 4425,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4426,
                            false => 4427,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4428,
                            false => 4429,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4430,
                            false => 4431,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4432,
                            false => 4433,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4434,
                            false => 4435,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4436,
                            false => 4437,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4438,
                            false => 4439,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4440,
                            false => 4441,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4442,
                            false => 4443,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4444,
                            false => 4445,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4446,
                            false => 4447,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4448,
                            false => 4449,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4450,
                            false => 4451,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4452,
                            false => 4453,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4454,
                            false => 4455,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4456,
                            false => 4457,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4458,
                            false => 4459,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4460,
                            false => 4461,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4462,
                            false => 4463,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4464,
                            false => 4465,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4466,
                            false => 4467,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4468,
                            false => 4469,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4470,
                            false => 4471,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4472,
                            false => 4473,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4474,
                            false => 4475,
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
            4412 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4413 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4414 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4415 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4416 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4417 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4418 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4419 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4420 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4421 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4422 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4423 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4424 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4425 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4426 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4427 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4428 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4429 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4430 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4431 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4432 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4433 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4434 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4435 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4436 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4437 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4438 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4439 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4440 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4441 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4442 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4443 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4444 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4445 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4446 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4447 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4448 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4449 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4450 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4451 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4452 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4453 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4454 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4455 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4456 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4457 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4458 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4459 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4460 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4461 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4462 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4463 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4464 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4465 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4466 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4467 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4468 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4469 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4470 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4471 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4472 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4473 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4474 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4475 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
