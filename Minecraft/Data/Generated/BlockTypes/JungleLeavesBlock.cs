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
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.jungle_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:jungle_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 336];

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

    public IBlock WithDistance(int distance) => this with { Distance = distance };

    public IBlock WithPersistent(bool persistent) => this with { Persistent = persistent };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 336,
                        false => 337,
                    },
                    false => Waterlogged switch {
                        true => 338,
                        false => 339,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 340,
                        false => 341,
                    },
                    false => Waterlogged switch {
                        true => 342,
                        false => 343,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 344,
                        false => 345,
                    },
                    false => Waterlogged switch {
                        true => 346,
                        false => 347,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 348,
                        false => 349,
                    },
                    false => Waterlogged switch {
                        true => 350,
                        false => 351,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 352,
                        false => 353,
                    },
                    false => Waterlogged switch {
                        true => 354,
                        false => 355,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 356,
                        false => 357,
                    },
                    false => Waterlogged switch {
                        true => 358,
                        false => 359,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 360,
                        false => 361,
                    },
                    false => Waterlogged switch {
                        true => 362,
                        false => 363,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            336 => new JungleLeavesBlock(Identifier, 1, true, true),
            337 => new JungleLeavesBlock(Identifier, 1, true, false),
            338 => new JungleLeavesBlock(Identifier, 1, false, true),
            339 => new JungleLeavesBlock(Identifier, 1, false, false),
            340 => new JungleLeavesBlock(Identifier, 2, true, true),
            341 => new JungleLeavesBlock(Identifier, 2, true, false),
            342 => new JungleLeavesBlock(Identifier, 2, false, true),
            343 => new JungleLeavesBlock(Identifier, 2, false, false),
            344 => new JungleLeavesBlock(Identifier, 3, true, true),
            345 => new JungleLeavesBlock(Identifier, 3, true, false),
            346 => new JungleLeavesBlock(Identifier, 3, false, true),
            347 => new JungleLeavesBlock(Identifier, 3, false, false),
            348 => new JungleLeavesBlock(Identifier, 4, true, true),
            349 => new JungleLeavesBlock(Identifier, 4, true, false),
            350 => new JungleLeavesBlock(Identifier, 4, false, true),
            351 => new JungleLeavesBlock(Identifier, 4, false, false),
            352 => new JungleLeavesBlock(Identifier, 5, true, true),
            353 => new JungleLeavesBlock(Identifier, 5, true, false),
            354 => new JungleLeavesBlock(Identifier, 5, false, true),
            355 => new JungleLeavesBlock(Identifier, 5, false, false),
            356 => new JungleLeavesBlock(Identifier, 6, true, true),
            357 => new JungleLeavesBlock(Identifier, 6, true, false),
            358 => new JungleLeavesBlock(Identifier, 6, false, true),
            359 => new JungleLeavesBlock(Identifier, 6, false, false),
            360 => new JungleLeavesBlock(Identifier, 7, true, true),
            361 => new JungleLeavesBlock(Identifier, 7, true, false),
            362 => new JungleLeavesBlock(Identifier, 7, false, true),
            363 => new JungleLeavesBlock(Identifier, 7, false, false),
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
