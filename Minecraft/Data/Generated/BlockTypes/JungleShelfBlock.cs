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
public record JungleShelfBlock(Identifier Identifier, Direction Facing, bool Powered, JungleShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.jungle_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:jungle_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 10, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4476];

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
                            true => 4476,
                            false => 4477,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4478,
                            false => 4479,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4480,
                            false => 4481,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4482,
                            false => 4483,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4484,
                            false => 4485,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4486,
                            false => 4487,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4488,
                            false => 4489,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4490,
                            false => 4491,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4492,
                            false => 4493,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4494,
                            false => 4495,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4496,
                            false => 4497,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4498,
                            false => 4499,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4500,
                            false => 4501,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4502,
                            false => 4503,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4504,
                            false => 4505,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4506,
                            false => 4507,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4508,
                            false => 4509,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4510,
                            false => 4511,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4512,
                            false => 4513,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4514,
                            false => 4515,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4516,
                            false => 4517,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4518,
                            false => 4519,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4520,
                            false => 4521,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4522,
                            false => 4523,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4524,
                            false => 4525,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4526,
                            false => 4527,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4528,
                            false => 4529,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4530,
                            false => 4531,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4532,
                            false => 4533,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4534,
                            false => 4535,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4536,
                            false => 4537,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4538,
                            false => 4539,
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
            4476 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4477 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4478 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4479 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4480 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4481 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4482 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4483 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4484 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4485 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4486 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4487 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4488 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4489 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4490 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4491 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4492 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4493 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4494 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4495 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4496 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4497 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4498 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4499 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4500 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4501 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4502 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4503 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4504 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4505 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4506 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4507 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4508 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4509 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4510 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4511 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4512 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4513 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4514 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4515 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4516 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4517 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4518 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4519 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4520 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4521 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4522 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4523 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4524 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4525 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4526 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4527 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4528 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4529 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4530 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4531 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4532 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4533 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4534 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4535 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4536 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4537 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4538 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4539 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
