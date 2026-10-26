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
public record MangroveLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 491];

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

    public IBlock WithDistance(int distance) => this with { Distance = distance };

    public IBlock WithPersistent(bool persistent) => this with { Persistent = persistent };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 491,
                        false => 492,
                    },
                    false => Waterlogged switch {
                        true => 493,
                        false => 494,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 495,
                        false => 496,
                    },
                    false => Waterlogged switch {
                        true => 497,
                        false => 498,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 499,
                        false => 500,
                    },
                    false => Waterlogged switch {
                        true => 501,
                        false => 502,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 503,
                        false => 504,
                    },
                    false => Waterlogged switch {
                        true => 505,
                        false => 506,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 507,
                        false => 508,
                    },
                    false => Waterlogged switch {
                        true => 509,
                        false => 510,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 511,
                        false => 512,
                    },
                    false => Waterlogged switch {
                        true => 513,
                        false => 514,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 515,
                        false => 516,
                    },
                    false => Waterlogged switch {
                        true => 517,
                        false => 518,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            491 => new MangroveLeavesBlock(Identifier, 1, true, true),
            492 => new MangroveLeavesBlock(Identifier, 1, true, false),
            493 => new MangroveLeavesBlock(Identifier, 1, false, true),
            494 => new MangroveLeavesBlock(Identifier, 1, false, false),
            495 => new MangroveLeavesBlock(Identifier, 2, true, true),
            496 => new MangroveLeavesBlock(Identifier, 2, true, false),
            497 => new MangroveLeavesBlock(Identifier, 2, false, true),
            498 => new MangroveLeavesBlock(Identifier, 2, false, false),
            499 => new MangroveLeavesBlock(Identifier, 3, true, true),
            500 => new MangroveLeavesBlock(Identifier, 3, true, false),
            501 => new MangroveLeavesBlock(Identifier, 3, false, true),
            502 => new MangroveLeavesBlock(Identifier, 3, false, false),
            503 => new MangroveLeavesBlock(Identifier, 4, true, true),
            504 => new MangroveLeavesBlock(Identifier, 4, true, false),
            505 => new MangroveLeavesBlock(Identifier, 4, false, true),
            506 => new MangroveLeavesBlock(Identifier, 4, false, false),
            507 => new MangroveLeavesBlock(Identifier, 5, true, true),
            508 => new MangroveLeavesBlock(Identifier, 5, true, false),
            509 => new MangroveLeavesBlock(Identifier, 5, false, true),
            510 => new MangroveLeavesBlock(Identifier, 5, false, false),
            511 => new MangroveLeavesBlock(Identifier, 6, true, true),
            512 => new MangroveLeavesBlock(Identifier, 6, true, false),
            513 => new MangroveLeavesBlock(Identifier, 6, false, true),
            514 => new MangroveLeavesBlock(Identifier, 6, false, false),
            515 => new MangroveLeavesBlock(Identifier, 7, true, true),
            516 => new MangroveLeavesBlock(Identifier, 7, true, false),
            517 => new MangroveLeavesBlock(Identifier, 7, false, true),
            518 => new MangroveLeavesBlock(Identifier, 7, false, false),
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
