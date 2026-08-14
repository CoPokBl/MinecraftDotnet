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
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.cherry_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:cherry_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 36, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 2792];

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
                            true => 2792,
                            false => 2793,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2794,
                            false => 2795,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2796,
                            false => 2797,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2798,
                            false => 2799,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2800,
                            false => 2801,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2802,
                            false => 2803,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2804,
                            false => 2805,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2806,
                            false => 2807,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2808,
                            false => 2809,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2810,
                            false => 2811,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2812,
                            false => 2813,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2814,
                            false => 2815,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2816,
                            false => 2817,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2818,
                            false => 2819,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2820,
                            false => 2821,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2822,
                            false => 2823,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2824,
                            false => 2825,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2826,
                            false => 2827,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2828,
                            false => 2829,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2830,
                            false => 2831,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2832,
                            false => 2833,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2834,
                            false => 2835,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2836,
                            false => 2837,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2838,
                            false => 2839,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2840,
                            false => 2841,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2842,
                            false => 2843,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2844,
                            false => 2845,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2846,
                            false => 2847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2848,
                            false => 2849,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2850,
                            false => 2851,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2852,
                            false => 2853,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2854,
                            false => 2855,
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
            2792 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2793 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2794 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2795 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2796 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2797 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2798 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2799 => new CherryShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2800 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2801 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2802 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2803 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2804 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2805 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2806 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2807 => new CherryShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2808 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2809 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2810 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2811 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2812 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2813 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2814 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2815 => new CherryShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2816 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2817 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2818 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2819 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2820 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2821 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2822 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2823 => new CherryShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2824 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2825 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2826 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2827 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2828 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2829 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2830 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2831 => new CherryShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2832 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2833 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2834 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2835 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2836 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2837 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2838 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2839 => new CherryShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2840 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2841 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2842 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2843 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2844 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2845 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2846 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2847 => new CherryShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2848 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2849 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2850 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2851 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2852 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2853 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2854 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2855 => new CherryShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
