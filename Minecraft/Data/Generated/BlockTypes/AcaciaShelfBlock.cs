using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaShelfBlock(Identifier Identifier, Direction Facing, bool Powered, AcaciaShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.acacia_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:acacia_shelf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 15, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S81, BlockShapes.S81, BlockShapes.S1, BlockShapes.S81, BlockShapes.S81);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S82, CollisionShape = BlockShapes.S82, OcclusionShape = BlockShapes.S82, VisualShape = BlockShapes.S82 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S83, CollisionShape = BlockShapes.S83, OcclusionShape = BlockShapes.S83, VisualShape = BlockShapes.S83 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 2600];

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
                            true => 2600,
                            false => 2601,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2602,
                            false => 2603,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2604,
                            false => 2605,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2606,
                            false => 2607,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2608,
                            false => 2609,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2610,
                            false => 2611,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2612,
                            false => 2613,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2614,
                            false => 2615,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2616,
                            false => 2617,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2618,
                            false => 2619,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2620,
                            false => 2621,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2622,
                            false => 2623,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2624,
                            false => 2625,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2626,
                            false => 2627,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2628,
                            false => 2629,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2630,
                            false => 2631,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2632,
                            false => 2633,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2634,
                            false => 2635,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2636,
                            false => 2637,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2638,
                            false => 2639,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2640,
                            false => 2641,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2642,
                            false => 2643,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2644,
                            false => 2645,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2646,
                            false => 2647,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2648,
                            false => 2649,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2650,
                            false => 2651,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2652,
                            false => 2653,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2654,
                            false => 2655,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2656,
                            false => 2657,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2658,
                            false => 2659,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2660,
                            false => 2661,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2662,
                            false => 2663,
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
            2600 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2601 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2602 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2603 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2604 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2605 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2606 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2607 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2608 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2609 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2610 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2611 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2612 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2613 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2614 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2615 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            2616 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            2617 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            2618 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            2619 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            2620 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            2621 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            2622 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            2623 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            2624 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            2625 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            2626 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            2627 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            2628 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            2629 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            2630 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            2631 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            2632 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            2633 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            2634 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            2635 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            2636 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            2637 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            2638 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            2639 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            2640 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            2641 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            2642 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            2643 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            2644 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            2645 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            2646 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            2647 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            2648 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            2649 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            2650 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            2651 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            2652 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            2653 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            2654 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            2655 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            2656 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            2657 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            2658 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            2659 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            2660 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            2661 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            2662 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            2663 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
