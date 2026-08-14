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
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.dark_oak_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:dark_oak_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 26, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 2920];

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
                            true => 2920,
                            false => 2921,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2922,
                            false => 2923,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2924,
                            false => 2925,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2926,
                            false => 2927,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2928,
                            false => 2929,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2930,
                            false => 2931,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2932,
                            false => 2933,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2934,
                            false => 2935,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2936,
                            false => 2937,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2938,
                            false => 2939,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2940,
                            false => 2941,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2942,
                            false => 2943,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2944,
                            false => 2945,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2946,
                            false => 2947,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2948,
                            false => 2949,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2950,
                            false => 2951,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2952,
                            false => 2953,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2954,
                            false => 2955,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2956,
                            false => 2957,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2958,
                            false => 2959,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2960,
                            false => 2961,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2962,
                            false => 2963,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2964,
                            false => 2965,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2966,
                            false => 2967,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2968,
                            false => 2969,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2970,
                            false => 2971,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2972,
                            false => 2973,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2974,
                            false => 2975,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2976,
                            false => 2977,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2978,
                            false => 2979,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2980,
                            false => 2981,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2982,
                            false => 2983,
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
            2920 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2921 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2922 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2923 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2924 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2925 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2926 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2927 => new DarkOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2928 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2929 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2930 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2931 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2932 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2933 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2934 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2935 => new DarkOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2936 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2937 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2938 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2939 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2940 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2941 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2942 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2943 => new DarkOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2944 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2945 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2946 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2947 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2948 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2949 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2950 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2951 => new DarkOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2952 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2953 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2954 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2955 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2956 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2957 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2958 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2959 => new DarkOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2960 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2961 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2962 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2963 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2964 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2965 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2966 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2967 => new DarkOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2968 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2969 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2970 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2971 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2972 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2973 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2974 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2975 => new DarkOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2976 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2977 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2978 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2979 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2980 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2981 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2982 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2983 => new DarkOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
