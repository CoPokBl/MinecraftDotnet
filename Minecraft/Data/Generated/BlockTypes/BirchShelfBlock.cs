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
public record BirchShelfBlock(Identifier Identifier, Direction Facing, bool Powered, BirchShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.birch_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:birch_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/birch_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 2, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 2728];

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
                            true => 2728,
                            false => 2729,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2730,
                            false => 2731,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2732,
                            false => 2733,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2734,
                            false => 2735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2736,
                            false => 2737,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2738,
                            false => 2739,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2740,
                            false => 2741,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2742,
                            false => 2743,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2744,
                            false => 2745,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2746,
                            false => 2747,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2748,
                            false => 2749,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2750,
                            false => 2751,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2752,
                            false => 2753,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2754,
                            false => 2755,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2756,
                            false => 2757,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2758,
                            false => 2759,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2760,
                            false => 2761,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2762,
                            false => 2763,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2764,
                            false => 2765,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2766,
                            false => 2767,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2768,
                            false => 2769,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2770,
                            false => 2771,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2772,
                            false => 2773,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2774,
                            false => 2775,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2776,
                            false => 2777,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2778,
                            false => 2779,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2780,
                            false => 2781,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2782,
                            false => 2783,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2784,
                            false => 2785,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2786,
                            false => 2787,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2788,
                            false => 2789,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2790,
                            false => 2791,
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
            2728 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2729 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2730 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2731 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2732 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2733 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2734 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2735 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2736 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2737 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2738 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2739 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2740 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2741 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2742 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2743 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2744 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2745 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2746 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2747 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2748 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2749 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2750 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2751 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2752 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2753 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2754 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2755 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2756 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2757 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2758 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2759 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2760 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2761 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2762 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2763 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2764 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2765 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2766 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2767 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2768 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2769 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2770 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2771 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2772 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2773 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2774 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2775 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2776 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2777 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2778 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2779 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2780 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2781 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2782 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2783 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2784 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2785 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2786 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2787 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2788 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2789 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2790 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2791 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
