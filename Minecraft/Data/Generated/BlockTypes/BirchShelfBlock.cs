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
    private static readonly BlockInfo Data = new("block.minecraft.birch_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:birch_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/birch_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 2, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 4220];

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
                            true => 4220,
                            false => 4221,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4222,
                            false => 4223,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4224,
                            false => 4225,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4226,
                            false => 4227,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4228,
                            false => 4229,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4230,
                            false => 4231,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4232,
                            false => 4233,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4234,
                            false => 4235,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4236,
                            false => 4237,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4238,
                            false => 4239,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4240,
                            false => 4241,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4242,
                            false => 4243,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4244,
                            false => 4245,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4246,
                            false => 4247,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4248,
                            false => 4249,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4250,
                            false => 4251,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4252,
                            false => 4253,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4254,
                            false => 4255,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4256,
                            false => 4257,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4258,
                            false => 4259,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4260,
                            false => 4261,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4262,
                            false => 4263,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4264,
                            false => 4265,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4266,
                            false => 4267,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4268,
                            false => 4269,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4270,
                            false => 4271,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4272,
                            false => 4273,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4274,
                            false => 4275,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4276,
                            false => 4277,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4278,
                            false => 4279,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4280,
                            false => 4281,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4282,
                            false => 4283,
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
            4220 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4221 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4222 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4223 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4224 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4225 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4226 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4227 => new BirchShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4228 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4229 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4230 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4231 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4232 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4233 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4234 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4235 => new BirchShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4236 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4237 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4238 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4239 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4240 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4241 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4242 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4243 => new BirchShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4244 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4245 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4246 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4247 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4248 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4249 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4250 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4251 => new BirchShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4252 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4253 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4254 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4255 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4256 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4257 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4258 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4259 => new BirchShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4260 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4261 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4262 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4263 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4264 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4265 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4266 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4267 => new BirchShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4268 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4269 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4270 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4271 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4272 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4273 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4274 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4275 => new BirchShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4276 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4277 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4278 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4279 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4280 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4281 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4282 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4283 => new BirchShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
