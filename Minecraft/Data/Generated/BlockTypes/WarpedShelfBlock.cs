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
    private static readonly BlockInfo Data = new("block.minecraft.warped_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:warped_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/warped_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 56, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4860];

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
                            true => 4860,
                            false => 4861,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4862,
                            false => 4863,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4864,
                            false => 4865,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4866,
                            false => 4867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4868,
                            false => 4869,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4870,
                            false => 4871,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4872,
                            false => 4873,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4874,
                            false => 4875,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4876,
                            false => 4877,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4878,
                            false => 4879,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4880,
                            false => 4881,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4882,
                            false => 4883,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4884,
                            false => 4885,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4886,
                            false => 4887,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4888,
                            false => 4889,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4890,
                            false => 4891,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4892,
                            false => 4893,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4894,
                            false => 4895,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4896,
                            false => 4897,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4898,
                            false => 4899,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4900,
                            false => 4901,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4902,
                            false => 4903,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4904,
                            false => 4905,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4906,
                            false => 4907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4908,
                            false => 4909,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4910,
                            false => 4911,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4912,
                            false => 4913,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4914,
                            false => 4915,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4916,
                            false => 4917,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4918,
                            false => 4919,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4920,
                            false => 4921,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4922,
                            false => 4923,
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
            4860 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4861 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4862 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4863 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4864 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4865 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4866 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4867 => new WarpedShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4868 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4869 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4870 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4871 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4872 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4873 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4874 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4875 => new WarpedShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4876 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4877 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4878 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4879 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4880 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4881 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4882 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4883 => new WarpedShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4884 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4885 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4886 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4887 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4888 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4889 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4890 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4891 => new WarpedShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4892 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4893 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4894 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4895 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4896 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4897 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4898 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4899 => new WarpedShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4900 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4901 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4902 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4903 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4904 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4905 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4906 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4907 => new WarpedShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4908 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4909 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4910 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4911 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4912 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4913 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4914 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4915 => new WarpedShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4916 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4917 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4918 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4919 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4920 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4921 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4922 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4923 => new WarpedShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
