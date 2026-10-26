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
public record SpruceShelfBlock(Identifier Identifier, Direction Facing, bool Powered, SpruceShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:spruce_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 34, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4796];

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
                            true => 4796,
                            false => 4797,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4798,
                            false => 4799,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4800,
                            false => 4801,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4802,
                            false => 4803,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4804,
                            false => 4805,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4806,
                            false => 4807,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4808,
                            false => 4809,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4810,
                            false => 4811,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4812,
                            false => 4813,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4814,
                            false => 4815,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4816,
                            false => 4817,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4818,
                            false => 4819,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4820,
                            false => 4821,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4822,
                            false => 4823,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4824,
                            false => 4825,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4826,
                            false => 4827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4828,
                            false => 4829,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4830,
                            false => 4831,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4832,
                            false => 4833,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4834,
                            false => 4835,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4836,
                            false => 4837,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4838,
                            false => 4839,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4840,
                            false => 4841,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4842,
                            false => 4843,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4844,
                            false => 4845,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4846,
                            false => 4847,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4848,
                            false => 4849,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4850,
                            false => 4851,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4852,
                            false => 4853,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4854,
                            false => 4855,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4856,
                            false => 4857,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4858,
                            false => 4859,
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
            4796 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4797 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4798 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4799 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4800 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4801 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4802 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4803 => new SpruceShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4804 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4805 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4806 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4807 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4808 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4809 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4810 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4811 => new SpruceShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4812 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4813 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4814 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4815 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4816 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4817 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4818 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4819 => new SpruceShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4820 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4821 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4822 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4823 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4824 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4825 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4826 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4827 => new SpruceShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4828 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4829 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4830 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4831 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4832 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4833 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4834 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4835 => new SpruceShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4836 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4837 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4838 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4839 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4840 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4841 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4842 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4843 => new SpruceShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4844 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4845 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4846 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4847 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4848 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4849 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4850 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4851 => new SpruceShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4852 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4853 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4854 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4855 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4856 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4857 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4858 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4859 => new SpruceShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
