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
public record PaleOakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, PaleOakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:pale_oak_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 14, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4668];

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
                            true => 4668,
                            false => 4669,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4670,
                            false => 4671,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4672,
                            false => 4673,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4674,
                            false => 4675,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4676,
                            false => 4677,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4678,
                            false => 4679,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4680,
                            false => 4681,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4682,
                            false => 4683,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4684,
                            false => 4685,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4686,
                            false => 4687,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4688,
                            false => 4689,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4690,
                            false => 4691,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4692,
                            false => 4693,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4694,
                            false => 4695,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4696,
                            false => 4697,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4698,
                            false => 4699,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4700,
                            false => 4701,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4702,
                            false => 4703,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4704,
                            false => 4705,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4706,
                            false => 4707,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4708,
                            false => 4709,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4710,
                            false => 4711,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4712,
                            false => 4713,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4714,
                            false => 4715,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4716,
                            false => 4717,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4718,
                            false => 4719,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4720,
                            false => 4721,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4722,
                            false => 4723,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4724,
                            false => 4725,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4726,
                            false => 4727,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4728,
                            false => 4729,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4730,
                            false => 4731,
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
            4668 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4669 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4670 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4671 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4672 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4673 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4674 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4675 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4676 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4677 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4678 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4679 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4680 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4681 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4682 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4683 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4684 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4685 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4686 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4687 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4688 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4689 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4690 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4691 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4692 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4693 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4694 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4695 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4696 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4697 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4698 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4699 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4700 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4701 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4702 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4703 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4704 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4705 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4706 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4707 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4708 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4709 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4710 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4711 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4712 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4713 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4714 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4715 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4716 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4717 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4718 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4719 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4720 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4721 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4722 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4723 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4724 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4725 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4726 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4727 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4728 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4729 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4730 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4731 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
