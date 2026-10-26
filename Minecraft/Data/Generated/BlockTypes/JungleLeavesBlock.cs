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
public record JungleLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.jungle_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:jungle_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 351];

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
                        true => 351,
                        false => 352,
                    },
                    false => Waterlogged switch {
                        true => 353,
                        false => 354,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 355,
                        false => 356,
                    },
                    false => Waterlogged switch {
                        true => 357,
                        false => 358,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 359,
                        false => 360,
                    },
                    false => Waterlogged switch {
                        true => 361,
                        false => 362,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 363,
                        false => 364,
                    },
                    false => Waterlogged switch {
                        true => 365,
                        false => 366,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 367,
                        false => 368,
                    },
                    false => Waterlogged switch {
                        true => 369,
                        false => 370,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 371,
                        false => 372,
                    },
                    false => Waterlogged switch {
                        true => 373,
                        false => 374,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 375,
                        false => 376,
                    },
                    false => Waterlogged switch {
                        true => 377,
                        false => 378,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            351 => new JungleLeavesBlock(Identifier, 1, true, true),
            352 => new JungleLeavesBlock(Identifier, 1, true, false),
            353 => new JungleLeavesBlock(Identifier, 1, false, true),
            354 => new JungleLeavesBlock(Identifier, 1, false, false),
            355 => new JungleLeavesBlock(Identifier, 2, true, true),
            356 => new JungleLeavesBlock(Identifier, 2, true, false),
            357 => new JungleLeavesBlock(Identifier, 2, false, true),
            358 => new JungleLeavesBlock(Identifier, 2, false, false),
            359 => new JungleLeavesBlock(Identifier, 3, true, true),
            360 => new JungleLeavesBlock(Identifier, 3, true, false),
            361 => new JungleLeavesBlock(Identifier, 3, false, true),
            362 => new JungleLeavesBlock(Identifier, 3, false, false),
            363 => new JungleLeavesBlock(Identifier, 4, true, true),
            364 => new JungleLeavesBlock(Identifier, 4, true, false),
            365 => new JungleLeavesBlock(Identifier, 4, false, true),
            366 => new JungleLeavesBlock(Identifier, 4, false, false),
            367 => new JungleLeavesBlock(Identifier, 5, true, true),
            368 => new JungleLeavesBlock(Identifier, 5, true, false),
            369 => new JungleLeavesBlock(Identifier, 5, false, true),
            370 => new JungleLeavesBlock(Identifier, 5, false, false),
            371 => new JungleLeavesBlock(Identifier, 6, true, true),
            372 => new JungleLeavesBlock(Identifier, 6, true, false),
            373 => new JungleLeavesBlock(Identifier, 6, false, true),
            374 => new JungleLeavesBlock(Identifier, 6, false, false),
            375 => new JungleLeavesBlock(Identifier, 7, true, true),
            376 => new JungleLeavesBlock(Identifier, 7, true, false),
            377 => new JungleLeavesBlock(Identifier, 7, false, true),
            378 => new JungleLeavesBlock(Identifier, 7, false, false),
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
