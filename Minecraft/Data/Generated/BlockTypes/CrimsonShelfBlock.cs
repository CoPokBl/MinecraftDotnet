using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonShelfBlock(Identifier Identifier, Direction Facing, bool Powered, CrimsonShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.crimson_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:crimson_shelf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 53, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S81, BlockShapes.S81, BlockShapes.S1, BlockShapes.S81, BlockShapes.S81);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 2856];

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
                            true => 2856,
                            false => 2857,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2858,
                            false => 2859,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2860,
                            false => 2861,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2862,
                            false => 2863,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2864,
                            false => 2865,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2866,
                            false => 2867,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2868,
                            false => 2869,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2870,
                            false => 2871,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2872,
                            false => 2873,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2874,
                            false => 2875,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2876,
                            false => 2877,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2878,
                            false => 2879,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2880,
                            false => 2881,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2882,
                            false => 2883,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2884,
                            false => 2885,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2886,
                            false => 2887,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2888,
                            false => 2889,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2890,
                            false => 2891,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2892,
                            false => 2893,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2894,
                            false => 2895,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2896,
                            false => 2897,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2898,
                            false => 2899,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2900,
                            false => 2901,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2902,
                            false => 2903,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2904,
                            false => 2905,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2906,
                            false => 2907,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2908,
                            false => 2909,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2910,
                            false => 2911,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2912,
                            false => 2913,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2914,
                            false => 2915,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2916,
                            false => 2917,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2918,
                            false => 2919,
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
            2856 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2857 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2858 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2859 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2860 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2861 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2862 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2863 => new CrimsonShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2864 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2865 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2866 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2867 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2868 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2869 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2870 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2871 => new CrimsonShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2872 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2873 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2874 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2875 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2876 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2877 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2878 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2879 => new CrimsonShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2880 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2881 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2882 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2883 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2884 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2885 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2886 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2887 => new CrimsonShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2888 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2889 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2890 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2891 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2892 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2893 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2894 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2895 => new CrimsonShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2896 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2897 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2898 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2899 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2900 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2901 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2902 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2903 => new CrimsonShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2904 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2905 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2906 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2907 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2908 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2909 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2910 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2911 => new CrimsonShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2912 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2913 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2914 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2915 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2916 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2917 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2918 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2919 => new CrimsonShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
