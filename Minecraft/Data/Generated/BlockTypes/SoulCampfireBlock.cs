using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SoulCampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:campfire", "block.minecraft.soul_campfire", 2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:campfire", "minecraft:soul_campfire", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 10, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S409, BlockShapes.S409, BlockShapes.S1, BlockShapes.S1, BlockShapes.S409);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 20909];

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
                            true => 20909,
                            false => 20910,
                        },
                        false => Waterlogged switch {
                            true => 20911,
                            false => 20912,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20913,
                            false => 20914,
                        },
                        false => Waterlogged switch {
                            true => 20915,
                            false => 20916,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20917,
                            false => 20918,
                        },
                        false => Waterlogged switch {
                            true => 20919,
                            false => 20920,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20921,
                            false => 20922,
                        },
                        false => Waterlogged switch {
                            true => 20923,
                            false => 20924,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20925,
                            false => 20926,
                        },
                        false => Waterlogged switch {
                            true => 20927,
                            false => 20928,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20929,
                            false => 20930,
                        },
                        false => Waterlogged switch {
                            true => 20931,
                            false => 20932,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20933,
                            false => 20934,
                        },
                        false => Waterlogged switch {
                            true => 20935,
                            false => 20936,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 20937,
                            false => 20938,
                        },
                        false => Waterlogged switch {
                            true => 20939,
                            false => 20940,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20909 => new SoulCampfireBlock(Identifier, Direction.North, true, true, true),
            20910 => new SoulCampfireBlock(Identifier, Direction.North, true, true, false),
            20911 => new SoulCampfireBlock(Identifier, Direction.North, true, false, true),
            20912 => new SoulCampfireBlock(Identifier, Direction.North, true, false, false),
            20913 => new SoulCampfireBlock(Identifier, Direction.North, false, true, true),
            20914 => new SoulCampfireBlock(Identifier, Direction.North, false, true, false),
            20915 => new SoulCampfireBlock(Identifier, Direction.North, false, false, true),
            20916 => new SoulCampfireBlock(Identifier, Direction.North, false, false, false),
            20917 => new SoulCampfireBlock(Identifier, Direction.South, true, true, true),
            20918 => new SoulCampfireBlock(Identifier, Direction.South, true, true, false),
            20919 => new SoulCampfireBlock(Identifier, Direction.South, true, false, true),
            20920 => new SoulCampfireBlock(Identifier, Direction.South, true, false, false),
            20921 => new SoulCampfireBlock(Identifier, Direction.South, false, true, true),
            20922 => new SoulCampfireBlock(Identifier, Direction.South, false, true, false),
            20923 => new SoulCampfireBlock(Identifier, Direction.South, false, false, true),
            20924 => new SoulCampfireBlock(Identifier, Direction.South, false, false, false),
            20925 => new SoulCampfireBlock(Identifier, Direction.West, true, true, true),
            20926 => new SoulCampfireBlock(Identifier, Direction.West, true, true, false),
            20927 => new SoulCampfireBlock(Identifier, Direction.West, true, false, true),
            20928 => new SoulCampfireBlock(Identifier, Direction.West, true, false, false),
            20929 => new SoulCampfireBlock(Identifier, Direction.West, false, true, true),
            20930 => new SoulCampfireBlock(Identifier, Direction.West, false, true, false),
            20931 => new SoulCampfireBlock(Identifier, Direction.West, false, false, true),
            20932 => new SoulCampfireBlock(Identifier, Direction.West, false, false, false),
            20933 => new SoulCampfireBlock(Identifier, Direction.East, true, true, true),
            20934 => new SoulCampfireBlock(Identifier, Direction.East, true, true, false),
            20935 => new SoulCampfireBlock(Identifier, Direction.East, true, false, true),
            20936 => new SoulCampfireBlock(Identifier, Direction.East, true, false, false),
            20937 => new SoulCampfireBlock(Identifier, Direction.East, false, true, true),
            20938 => new SoulCampfireBlock(Identifier, Direction.East, false, true, false),
            20939 => new SoulCampfireBlock(Identifier, Direction.East, false, false, true),
            20940 => new SoulCampfireBlock(Identifier, Direction.East, false, false, false),
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
