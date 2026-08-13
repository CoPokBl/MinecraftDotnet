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
public record MangroveLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:mangrove_leaves", "block.minecraft.mangrove_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 476];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 476,
                        false => 477,
                    },
                    false => Waterlogged switch {
                        true => 478,
                        false => 479,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 480,
                        false => 481,
                    },
                    false => Waterlogged switch {
                        true => 482,
                        false => 483,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 484,
                        false => 485,
                    },
                    false => Waterlogged switch {
                        true => 486,
                        false => 487,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 488,
                        false => 489,
                    },
                    false => Waterlogged switch {
                        true => 490,
                        false => 491,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 492,
                        false => 493,
                    },
                    false => Waterlogged switch {
                        true => 494,
                        false => 495,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 496,
                        false => 497,
                    },
                    false => Waterlogged switch {
                        true => 498,
                        false => 499,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 500,
                        false => 501,
                    },
                    false => Waterlogged switch {
                        true => 502,
                        false => 503,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            476 => new MangroveLeavesBlock(Identifier, 1, true, true),
            477 => new MangroveLeavesBlock(Identifier, 1, true, false),
            478 => new MangroveLeavesBlock(Identifier, 1, false, true),
            479 => new MangroveLeavesBlock(Identifier, 1, false, false),
            480 => new MangroveLeavesBlock(Identifier, 2, true, true),
            481 => new MangroveLeavesBlock(Identifier, 2, true, false),
            482 => new MangroveLeavesBlock(Identifier, 2, false, true),
            483 => new MangroveLeavesBlock(Identifier, 2, false, false),
            484 => new MangroveLeavesBlock(Identifier, 3, true, true),
            485 => new MangroveLeavesBlock(Identifier, 3, true, false),
            486 => new MangroveLeavesBlock(Identifier, 3, false, true),
            487 => new MangroveLeavesBlock(Identifier, 3, false, false),
            488 => new MangroveLeavesBlock(Identifier, 4, true, true),
            489 => new MangroveLeavesBlock(Identifier, 4, true, false),
            490 => new MangroveLeavesBlock(Identifier, 4, false, true),
            491 => new MangroveLeavesBlock(Identifier, 4, false, false),
            492 => new MangroveLeavesBlock(Identifier, 5, true, true),
            493 => new MangroveLeavesBlock(Identifier, 5, true, false),
            494 => new MangroveLeavesBlock(Identifier, 5, false, true),
            495 => new MangroveLeavesBlock(Identifier, 5, false, false),
            496 => new MangroveLeavesBlock(Identifier, 6, true, true),
            497 => new MangroveLeavesBlock(Identifier, 6, true, false),
            498 => new MangroveLeavesBlock(Identifier, 6, false, true),
            499 => new MangroveLeavesBlock(Identifier, 6, false, false),
            500 => new MangroveLeavesBlock(Identifier, 7, true, true),
            501 => new MangroveLeavesBlock(Identifier, 7, true, false),
            502 => new MangroveLeavesBlock(Identifier, 7, false, true),
            503 => new MangroveLeavesBlock(Identifier, 7, false, false),
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
