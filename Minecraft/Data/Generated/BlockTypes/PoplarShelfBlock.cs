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
public record PoplarShelfBlock(Identifier Identifier, Direction Facing, bool Powered, PoplarShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:poplar_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 22, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4732];

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
                            true => 4732,
                            false => 4733,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4734,
                            false => 4735,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4736,
                            false => 4737,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4738,
                            false => 4739,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4740,
                            false => 4741,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4742,
                            false => 4743,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4744,
                            false => 4745,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4746,
                            false => 4747,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4748,
                            false => 4749,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4750,
                            false => 4751,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4752,
                            false => 4753,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4754,
                            false => 4755,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4756,
                            false => 4757,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4758,
                            false => 4759,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4760,
                            false => 4761,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4762,
                            false => 4763,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4764,
                            false => 4765,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4766,
                            false => 4767,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4768,
                            false => 4769,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4770,
                            false => 4771,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4772,
                            false => 4773,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4774,
                            false => 4775,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4776,
                            false => 4777,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4778,
                            false => 4779,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4780,
                            false => 4781,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4782,
                            false => 4783,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4784,
                            false => 4785,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4786,
                            false => 4787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4788,
                            false => 4789,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4790,
                            false => 4791,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4792,
                            false => 4793,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4794,
                            false => 4795,
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
            4732 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4733 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4734 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4735 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4736 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4737 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4738 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4739 => new PoplarShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4740 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4741 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4742 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4743 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4744 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4745 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4746 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4747 => new PoplarShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4748 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4749 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4750 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4751 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4752 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4753 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4754 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4755 => new PoplarShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4756 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4757 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4758 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4759 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4760 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4761 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4762 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4763 => new PoplarShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4764 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4765 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4766 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4767 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4768 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4769 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4770 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4771 => new PoplarShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4772 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4773 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4774 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4775 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4776 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4777 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4778 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4779 => new PoplarShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4780 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4781 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4782 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4783 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4784 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4785 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4786 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4787 => new PoplarShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4788 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4789 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4790 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4791 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4792 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4793 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4794 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4795 => new PoplarShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
