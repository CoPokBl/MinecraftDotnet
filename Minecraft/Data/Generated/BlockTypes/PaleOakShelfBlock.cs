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
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.pale_oak_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:pale_oak_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 14, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 3176];

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
                            true => 3176,
                            false => 3177,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3178,
                            false => 3179,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3180,
                            false => 3181,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3182,
                            false => 3183,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3184,
                            false => 3185,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3186,
                            false => 3187,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3188,
                            false => 3189,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3190,
                            false => 3191,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3192,
                            false => 3193,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3194,
                            false => 3195,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3196,
                            false => 3197,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3198,
                            false => 3199,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3200,
                            false => 3201,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3202,
                            false => 3203,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3204,
                            false => 3205,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3206,
                            false => 3207,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3208,
                            false => 3209,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3210,
                            false => 3211,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3212,
                            false => 3213,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3214,
                            false => 3215,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3216,
                            false => 3217,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3218,
                            false => 3219,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3220,
                            false => 3221,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3222,
                            false => 3223,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3224,
                            false => 3225,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3226,
                            false => 3227,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3228,
                            false => 3229,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3230,
                            false => 3231,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3232,
                            false => 3233,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3234,
                            false => 3235,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3236,
                            false => 3237,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3238,
                            false => 3239,
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
            3176 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            3177 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            3178 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            3179 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            3180 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            3181 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            3182 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            3183 => new PaleOakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            3184 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            3185 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            3186 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            3187 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            3188 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            3189 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            3190 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            3191 => new PaleOakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3192 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3193 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3194 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3195 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3196 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3197 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3198 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3199 => new PaleOakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3200 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3201 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3202 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3203 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3204 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3205 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3206 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3207 => new PaleOakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3208 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3209 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3210 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3211 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3212 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3213 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3214 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3215 => new PaleOakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3216 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3217 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3218 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3219 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3220 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3221 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3222 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3223 => new PaleOakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3224 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3225 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3226 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3227 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3228 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3229 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3230 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3231 => new PaleOakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3232 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3233 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3234 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3235 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3236 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3237 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3238 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3239 => new PaleOakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
