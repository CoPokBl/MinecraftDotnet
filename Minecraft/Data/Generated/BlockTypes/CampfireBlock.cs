using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:campfire", "block.minecraft.campfire", 2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:campfire", "minecraft:campfire", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 15, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S409, BlockShapes.S409, BlockShapes.S1, BlockShapes.S1, BlockShapes.S409);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 20877];

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
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20877,
                            false => 20878,
                        },
                        false => Waterlogged switch {
                            true => 20879,
                            false => 20880,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20881,
                            false => 20882,
                        },
                        false => Waterlogged switch {
                            true => 20883,
                            false => 20884,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20885,
                            false => 20886,
                        },
                        false => Waterlogged switch {
                            true => 20887,
                            false => 20888,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20889,
                            false => 20890,
                        },
                        false => Waterlogged switch {
                            true => 20891,
                            false => 20892,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20893,
                            false => 20894,
                        },
                        false => Waterlogged switch {
                            true => 20895,
                            false => 20896,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20897,
                            false => 20898,
                        },
                        false => Waterlogged switch {
                            true => 20899,
                            false => 20900,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20901,
                            false => 20902,
                        },
                        false => Waterlogged switch {
                            true => 20903,
                            false => 20904,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20905,
                            false => 20906,
                        },
                        false => Waterlogged switch {
                            true => 20907,
                            false => 20908,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20877 => new CampfireBlock(Identifier, Direction.North, true, true, true),
            20878 => new CampfireBlock(Identifier, Direction.North, true, true, false),
            20879 => new CampfireBlock(Identifier, Direction.North, true, false, true),
            20880 => new CampfireBlock(Identifier, Direction.North, true, false, false),
            20881 => new CampfireBlock(Identifier, Direction.North, false, true, true),
            20882 => new CampfireBlock(Identifier, Direction.North, false, true, false),
            20883 => new CampfireBlock(Identifier, Direction.North, false, false, true),
            20884 => new CampfireBlock(Identifier, Direction.North, false, false, false),
            20885 => new CampfireBlock(Identifier, Direction.South, true, true, true),
            20886 => new CampfireBlock(Identifier, Direction.South, true, true, false),
            20887 => new CampfireBlock(Identifier, Direction.South, true, false, true),
            20888 => new CampfireBlock(Identifier, Direction.South, true, false, false),
            20889 => new CampfireBlock(Identifier, Direction.South, false, true, true),
            20890 => new CampfireBlock(Identifier, Direction.South, false, true, false),
            20891 => new CampfireBlock(Identifier, Direction.South, false, false, true),
            20892 => new CampfireBlock(Identifier, Direction.South, false, false, false),
            20893 => new CampfireBlock(Identifier, Direction.West, true, true, true),
            20894 => new CampfireBlock(Identifier, Direction.West, true, true, false),
            20895 => new CampfireBlock(Identifier, Direction.West, true, false, true),
            20896 => new CampfireBlock(Identifier, Direction.West, true, false, false),
            20897 => new CampfireBlock(Identifier, Direction.West, false, true, true),
            20898 => new CampfireBlock(Identifier, Direction.West, false, true, false),
            20899 => new CampfireBlock(Identifier, Direction.West, false, false, true),
            20900 => new CampfireBlock(Identifier, Direction.West, false, false, false),
            20901 => new CampfireBlock(Identifier, Direction.East, true, true, true),
            20902 => new CampfireBlock(Identifier, Direction.East, true, true, false),
            20903 => new CampfireBlock(Identifier, Direction.East, true, false, true),
            20904 => new CampfireBlock(Identifier, Direction.East, true, false, false),
            20905 => new CampfireBlock(Identifier, Direction.East, false, true, true),
            20906 => new CampfireBlock(Identifier, Direction.East, false, true, false),
            20907 => new CampfireBlock(Identifier, Direction.East, false, false, true),
            20908 => new CampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            SignalFire = properties.Contains("signal_fire") ? properties["signal_fire"].GetString() == "true" : SignalFire,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("signal_fire", new StringTag(SignalFire.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
