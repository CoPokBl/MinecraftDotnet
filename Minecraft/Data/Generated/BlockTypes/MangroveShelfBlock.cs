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
public record MangroveShelfBlock(Identifier Identifier, Direction Facing, bool Powered, MangroveShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:mangrove_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 28, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4540];

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
                            true => 4540,
                            false => 4541,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4542,
                            false => 4543,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4544,
                            false => 4545,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4546,
                            false => 4547,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4548,
                            false => 4549,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4550,
                            false => 4551,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4552,
                            false => 4553,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4554,
                            false => 4555,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4556,
                            false => 4557,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4558,
                            false => 4559,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4560,
                            false => 4561,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4562,
                            false => 4563,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4564,
                            false => 4565,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4566,
                            false => 4567,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4568,
                            false => 4569,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4570,
                            false => 4571,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4572,
                            false => 4573,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4574,
                            false => 4575,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4576,
                            false => 4577,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4578,
                            false => 4579,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4580,
                            false => 4581,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4582,
                            false => 4583,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4584,
                            false => 4585,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4586,
                            false => 4587,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4588,
                            false => 4589,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4590,
                            false => 4591,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4592,
                            false => 4593,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4594,
                            false => 4595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4596,
                            false => 4597,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4598,
                            false => 4599,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4600,
                            false => 4601,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4602,
                            false => 4603,
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
            4540 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4541 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4542 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4543 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4544 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4545 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4546 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4547 => new MangroveShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4548 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4549 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4550 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4551 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4552 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4553 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4554 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4555 => new MangroveShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4556 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4557 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4558 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4559 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4560 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4561 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4562 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4563 => new MangroveShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4564 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4565 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4566 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4567 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4568 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4569 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4570 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4571 => new MangroveShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4572 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4573 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4574 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4575 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4576 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4577 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4578 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4579 => new MangroveShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4580 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4581 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4582 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4583 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4584 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4585 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4586 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4587 => new MangroveShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4588 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4589 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4590 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4591 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4592 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4593 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4594 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4595 => new MangroveShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4596 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4597 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4598 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4599 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4600 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4601 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4602 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4603 => new MangroveShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
