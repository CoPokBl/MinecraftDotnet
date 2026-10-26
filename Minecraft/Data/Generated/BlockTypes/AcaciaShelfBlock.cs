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
public record AcaciaShelfBlock(Identifier Identifier, Direction Facing, bool Powered, AcaciaShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.acacia_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:acacia_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 15, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4092];

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
                            true => 4092,
                            false => 4093,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4094,
                            false => 4095,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4096,
                            false => 4097,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4098,
                            false => 4099,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4100,
                            false => 4101,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4102,
                            false => 4103,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4104,
                            false => 4105,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4106,
                            false => 4107,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4108,
                            false => 4109,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4110,
                            false => 4111,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4112,
                            false => 4113,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4114,
                            false => 4115,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4116,
                            false => 4117,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4118,
                            false => 4119,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4120,
                            false => 4121,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4122,
                            false => 4123,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4124,
                            false => 4125,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4126,
                            false => 4127,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4128,
                            false => 4129,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4130,
                            false => 4131,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4132,
                            false => 4133,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4134,
                            false => 4135,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4136,
                            false => 4137,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4138,
                            false => 4139,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4140,
                            false => 4141,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4142,
                            false => 4143,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4144,
                            false => 4145,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4146,
                            false => 4147,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4148,
                            false => 4149,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4150,
                            false => 4151,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4152,
                            false => 4153,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4154,
                            false => 4155,
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
            4092 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4093 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4094 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4095 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4096 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4097 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4098 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4099 => new AcaciaShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4100 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4101 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4102 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4103 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4104 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4105 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4106 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4107 => new AcaciaShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4108 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4109 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4110 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4111 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4112 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4113 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4114 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4115 => new AcaciaShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4116 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4117 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4118 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4119 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4120 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4121 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4122 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4123 => new AcaciaShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4124 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4125 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4126 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4127 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4128 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4129 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4130 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4131 => new AcaciaShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4132 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4133 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4134 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4135 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4136 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4137 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4138 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4139 => new AcaciaShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4140 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4141 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4142 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4143 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4144 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4145 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4146 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4147 => new AcaciaShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4148 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4149 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4150 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4151 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4152 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4153 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4154 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4155 => new AcaciaShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
