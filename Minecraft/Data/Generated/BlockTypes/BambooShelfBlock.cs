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
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:bamboo_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 18, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4156];

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
                            true => 4156,
                            false => 4157,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4158,
                            false => 4159,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4160,
                            false => 4161,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4162,
                            false => 4163,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4164,
                            false => 4165,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4166,
                            false => 4167,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4168,
                            false => 4169,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4170,
                            false => 4171,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4172,
                            false => 4173,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4174,
                            false => 4175,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4176,
                            false => 4177,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4178,
                            false => 4179,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4180,
                            false => 4181,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4182,
                            false => 4183,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4184,
                            false => 4185,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4186,
                            false => 4187,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4188,
                            false => 4189,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4190,
                            false => 4191,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4192,
                            false => 4193,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4194,
                            false => 4195,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4196,
                            false => 4197,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4198,
                            false => 4199,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4200,
                            false => 4201,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4202,
                            false => 4203,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4204,
                            false => 4205,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4206,
                            false => 4207,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4208,
                            false => 4209,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4210,
                            false => 4211,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4212,
                            false => 4213,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4214,
                            false => 4215,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4216,
                            false => 4217,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4218,
                            false => 4219,
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
            4156 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4157 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4158 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4159 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4160 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4161 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4162 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4163 => new BambooShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4164 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4165 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4166 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4167 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4168 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4169 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4170 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4171 => new BambooShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4172 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4173 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4174 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4175 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4176 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4177 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4178 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4179 => new BambooShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4180 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4181 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4182 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4183 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4184 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4185 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4186 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4187 => new BambooShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4188 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4189 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4190 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4191 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4192 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4193 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4194 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4195 => new BambooShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4196 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4197 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4198 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4199 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4200 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4201 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4202 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4203 => new BambooShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4204 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4205 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4206 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4207 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4208 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4209 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4210 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4211 => new BambooShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4212 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4213 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4214 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4215 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4216 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4217 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4218 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4219 => new BambooShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
