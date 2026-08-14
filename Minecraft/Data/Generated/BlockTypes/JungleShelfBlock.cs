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
public record JungleShelfBlock(Identifier Identifier, Direction Facing, bool Powered, JungleShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:shelf", "block.minecraft.jungle_shelf", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:jungle_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 10, "shelf", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
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

    public BlockStateInfo StateInfo => States[StateId - 2984];

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
                            true => 2984,
                            false => 2985,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2986,
                            false => 2987,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2988,
                            false => 2989,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2990,
                            false => 2991,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 2992,
                            false => 2993,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 2994,
                            false => 2995,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 2996,
                            false => 2997,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 2998,
                            false => 2999,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3000,
                            false => 3001,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3002,
                            false => 3003,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3004,
                            false => 3005,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3006,
                            false => 3007,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3008,
                            false => 3009,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3010,
                            false => 3011,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3012,
                            false => 3013,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3014,
                            false => 3015,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3016,
                            false => 3017,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3018,
                            false => 3019,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3020,
                            false => 3021,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3022,
                            false => 3023,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3024,
                            false => 3025,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3026,
                            false => 3027,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3028,
                            false => 3029,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3030,
                            false => 3031,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3032,
                            false => 3033,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3034,
                            false => 3035,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3036,
                            false => 3037,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3038,
                            false => 3039,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 3040,
                            false => 3041,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 3042,
                            false => 3043,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 3044,
                            false => 3045,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 3046,
                            false => 3047,
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
            2984 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            2985 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            2986 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            2987 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            2988 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            2989 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            2990 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            2991 => new JungleShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            2992 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            2993 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            2994 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            2995 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            2996 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            2997 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            2998 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            2999 => new JungleShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            3000 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            3001 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            3002 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            3003 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            3004 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            3005 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            3006 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            3007 => new JungleShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            3008 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            3009 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            3010 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            3011 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            3012 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            3013 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            3014 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            3015 => new JungleShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            3016 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            3017 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            3018 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            3019 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            3020 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            3021 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            3022 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            3023 => new JungleShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            3024 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            3025 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            3026 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            3027 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            3028 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            3029 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            3030 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            3031 => new JungleShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            3032 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            3033 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            3034 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            3035 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            3036 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            3037 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            3038 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            3039 => new JungleShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            3040 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            3041 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            3042 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            3043 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            3044 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            3045 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            3046 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            3047 => new JungleShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
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
