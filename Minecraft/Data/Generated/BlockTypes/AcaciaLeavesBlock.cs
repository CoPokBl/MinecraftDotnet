using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.acacia_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S1, BlockShapes.S77);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 364];

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
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 364,
                        false => 365,
                    },
                    false => Waterlogged switch {
                        true => 366,
                        false => 367,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 368,
                        false => 369,
                    },
                    false => Waterlogged switch {
                        true => 370,
                        false => 371,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 372,
                        false => 373,
                    },
                    false => Waterlogged switch {
                        true => 374,
                        false => 375,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 376,
                        false => 377,
                    },
                    false => Waterlogged switch {
                        true => 378,
                        false => 379,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 380,
                        false => 381,
                    },
                    false => Waterlogged switch {
                        true => 382,
                        false => 383,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 384,
                        false => 385,
                    },
                    false => Waterlogged switch {
                        true => 386,
                        false => 387,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 388,
                        false => 389,
                    },
                    false => Waterlogged switch {
                        true => 390,
                        false => 391,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            364 => new AcaciaLeavesBlock(Identifier, 1, true, true),
            365 => new AcaciaLeavesBlock(Identifier, 1, true, false),
            366 => new AcaciaLeavesBlock(Identifier, 1, false, true),
            367 => new AcaciaLeavesBlock(Identifier, 1, false, false),
            368 => new AcaciaLeavesBlock(Identifier, 2, true, true),
            369 => new AcaciaLeavesBlock(Identifier, 2, true, false),
            370 => new AcaciaLeavesBlock(Identifier, 2, false, true),
            371 => new AcaciaLeavesBlock(Identifier, 2, false, false),
            372 => new AcaciaLeavesBlock(Identifier, 3, true, true),
            373 => new AcaciaLeavesBlock(Identifier, 3, true, false),
            374 => new AcaciaLeavesBlock(Identifier, 3, false, true),
            375 => new AcaciaLeavesBlock(Identifier, 3, false, false),
            376 => new AcaciaLeavesBlock(Identifier, 4, true, true),
            377 => new AcaciaLeavesBlock(Identifier, 4, true, false),
            378 => new AcaciaLeavesBlock(Identifier, 4, false, true),
            379 => new AcaciaLeavesBlock(Identifier, 4, false, false),
            380 => new AcaciaLeavesBlock(Identifier, 5, true, true),
            381 => new AcaciaLeavesBlock(Identifier, 5, true, false),
            382 => new AcaciaLeavesBlock(Identifier, 5, false, true),
            383 => new AcaciaLeavesBlock(Identifier, 5, false, false),
            384 => new AcaciaLeavesBlock(Identifier, 6, true, true),
            385 => new AcaciaLeavesBlock(Identifier, 6, true, false),
            386 => new AcaciaLeavesBlock(Identifier, 6, false, true),
            387 => new AcaciaLeavesBlock(Identifier, 6, false, false),
            388 => new AcaciaLeavesBlock(Identifier, 7, true, true),
            389 => new AcaciaLeavesBlock(Identifier, 7, true, false),
            390 => new AcaciaLeavesBlock(Identifier, 7, false, true),
            391 => new AcaciaLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = properties.Contains("distance") ? int.Parse(properties["distance"].GetString()) : Distance,
            Persistent = properties.Contains("persistent") ? properties["persistent"].GetString() == "true" : Persistent,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("distance", new StringTag(Distance.ToString())),
            ("persistent", new StringTag(Persistent.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
