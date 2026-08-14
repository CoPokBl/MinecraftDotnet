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
public record OakTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I4 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I4, I5, I4, I5, I6, I7, I6, I7, I2, I3, I2, I3, I6, I7, I6, I7, I4, I5, I4, I5, I8, I9, I8, I9, I2, I3, I2, I3, I8, I9, I8, I9, I4, I5, I4, I5, I10, I11, I10, I11, I2, I3, I2, I3, I10, I11, I10, I11, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 7114];

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

    public IBlock WithHalf(TopBottom half) => this with { Half = half };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7114,
                                false => 7115,
                            },
                            false => Waterlogged switch {
                                true => 7116,
                                false => 7117,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7118,
                                false => 7119,
                            },
                            false => Waterlogged switch {
                                true => 7120,
                                false => 7121,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7122,
                                false => 7123,
                            },
                            false => Waterlogged switch {
                                true => 7124,
                                false => 7125,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7126,
                                false => 7127,
                            },
                            false => Waterlogged switch {
                                true => 7128,
                                false => 7129,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7130,
                                false => 7131,
                            },
                            false => Waterlogged switch {
                                true => 7132,
                                false => 7133,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7134,
                                false => 7135,
                            },
                            false => Waterlogged switch {
                                true => 7136,
                                false => 7137,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7138,
                                false => 7139,
                            },
                            false => Waterlogged switch {
                                true => 7140,
                                false => 7141,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7142,
                                false => 7143,
                            },
                            false => Waterlogged switch {
                                true => 7144,
                                false => 7145,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7146,
                                false => 7147,
                            },
                            false => Waterlogged switch {
                                true => 7148,
                                false => 7149,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7150,
                                false => 7151,
                            },
                            false => Waterlogged switch {
                                true => 7152,
                                false => 7153,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7154,
                                false => 7155,
                            },
                            false => Waterlogged switch {
                                true => 7156,
                                false => 7157,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7158,
                                false => 7159,
                            },
                            false => Waterlogged switch {
                                true => 7160,
                                false => 7161,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7162,
                                false => 7163,
                            },
                            false => Waterlogged switch {
                                true => 7164,
                                false => 7165,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7166,
                                false => 7167,
                            },
                            false => Waterlogged switch {
                                true => 7168,
                                false => 7169,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7170,
                                false => 7171,
                            },
                            false => Waterlogged switch {
                                true => 7172,
                                false => 7173,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7174,
                                false => 7175,
                            },
                            false => Waterlogged switch {
                                true => 7176,
                                false => 7177,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7114 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7115 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7116 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7117 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7118 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7119 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7120 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7121 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7122 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7123 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7124 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7125 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7126 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7127 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7128 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7129 => new OakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7130 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7131 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7132 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7133 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7134 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7135 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7136 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7137 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7138 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7139 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7140 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7141 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7142 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7143 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7144 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7145 => new OakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7146 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7147 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7148 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7149 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7150 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7151 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7152 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7153 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7154 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7155 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7156 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7157 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7158 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7159 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7160 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7161 => new OakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7162 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7163 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7164 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7165 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7166 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7167 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7168 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7169 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7170 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7171 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7172 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7173 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7174 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7175 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7176 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7177 => new OakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
