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
public record OxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_trapdoor", "block.minecraft.oxidized_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oxidized_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/oxidized_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 55, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29200];

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
                                true => 29200,
                                false => 29201,
                            },
                            false => Waterlogged switch {
                                true => 29202,
                                false => 29203,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29204,
                                false => 29205,
                            },
                            false => Waterlogged switch {
                                true => 29206,
                                false => 29207,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29208,
                                false => 29209,
                            },
                            false => Waterlogged switch {
                                true => 29210,
                                false => 29211,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29212,
                                false => 29213,
                            },
                            false => Waterlogged switch {
                                true => 29214,
                                false => 29215,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29216,
                                false => 29217,
                            },
                            false => Waterlogged switch {
                                true => 29218,
                                false => 29219,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29220,
                                false => 29221,
                            },
                            false => Waterlogged switch {
                                true => 29222,
                                false => 29223,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29224,
                                false => 29225,
                            },
                            false => Waterlogged switch {
                                true => 29226,
                                false => 29227,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29228,
                                false => 29229,
                            },
                            false => Waterlogged switch {
                                true => 29230,
                                false => 29231,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29232,
                                false => 29233,
                            },
                            false => Waterlogged switch {
                                true => 29234,
                                false => 29235,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29236,
                                false => 29237,
                            },
                            false => Waterlogged switch {
                                true => 29238,
                                false => 29239,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29240,
                                false => 29241,
                            },
                            false => Waterlogged switch {
                                true => 29242,
                                false => 29243,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29244,
                                false => 29245,
                            },
                            false => Waterlogged switch {
                                true => 29246,
                                false => 29247,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29248,
                                false => 29249,
                            },
                            false => Waterlogged switch {
                                true => 29250,
                                false => 29251,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29252,
                                false => 29253,
                            },
                            false => Waterlogged switch {
                                true => 29254,
                                false => 29255,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29256,
                                false => 29257,
                            },
                            false => Waterlogged switch {
                                true => 29258,
                                false => 29259,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29260,
                                false => 29261,
                            },
                            false => Waterlogged switch {
                                true => 29262,
                                false => 29263,
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
            29200 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29201 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29202 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29203 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29204 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29205 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29206 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29207 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29208 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29209 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29210 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29211 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29212 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29213 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29214 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29215 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29216 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29217 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29218 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29219 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29220 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29221 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29222 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29223 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29224 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29225 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29226 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29227 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29228 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29229 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29230 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29231 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29232 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29233 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29234 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29235 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29236 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29237 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29238 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29239 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29240 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29241 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29242 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29243 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29244 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29245 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29246 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29247 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29248 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29249 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29250 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29251 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29252 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29253 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29254 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29255 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29256 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29257 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29258 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29259 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29260 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29261 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29262 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29263 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
