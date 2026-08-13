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
public record BambooShelfBlock(Identifier Identifier, Direction Facing, bool Powered, BambooShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.bamboo_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:bamboo_shelf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 18, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 2664];

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
                            true => 2664,
                            false => 2665,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2666,
                            false => 2667,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2668,
                            false => 2669,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2670,
                            false => 2671,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2672,
                            false => 2673,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2674,
                            false => 2675,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2676,
                            false => 2677,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2678,
                            false => 2679,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2680,
                            false => 2681,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2682,
                            false => 2683,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2684,
                            false => 2685,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2686,
                            false => 2687,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2688,
                            false => 2689,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2690,
                            false => 2691,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2692,
                            false => 2693,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2694,
                            false => 2695,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2696,
                            false => 2697,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2698,
                            false => 2699,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2700,
                            false => 2701,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2702,
                            false => 2703,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2704,
                            false => 2705,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2706,
                            false => 2707,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2708,
                            false => 2709,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2710,
                            false => 2711,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2712,
                            false => 2713,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2714,
                            false => 2715,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2716,
                            false => 2717,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2718,
                            false => 2719,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2720,
                            false => 2721,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2722,
                            false => 2723,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2724,
                            false => 2725,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2726,
                            false => 2727,
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
            2664 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2665 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2666 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2667 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2668 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2669 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2670 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2671 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2672 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2673 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2674 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2675 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2676 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2677 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2678 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2679 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2680 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2681 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2682 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2683 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2684 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2685 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2686 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2687 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2688 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2689 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2690 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2691 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2692 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2693 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2694 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2695 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2696 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2697 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2698 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2699 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2700 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2701 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2702 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2703 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2704 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2705 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2706 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2707 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2708 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2709 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2710 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2711 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2712 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2713 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2714 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2715 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2716 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2717 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2718 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2719 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2720 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2721 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2722 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2723 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2724 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2725 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2726 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2727 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
