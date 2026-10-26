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
public record AcaciaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.acacia_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 379];

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
                        true => 379,
                        false => 380,
                    },
                    false => Waterlogged switch {
                        true => 381,
                        false => 382,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 383,
                        false => 384,
                    },
                    false => Waterlogged switch {
                        true => 385,
                        false => 386,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 387,
                        false => 388,
                    },
                    false => Waterlogged switch {
                        true => 389,
                        false => 390,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 391,
                        false => 392,
                    },
                    false => Waterlogged switch {
                        true => 393,
                        false => 394,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 395,
                        false => 396,
                    },
                    false => Waterlogged switch {
                        true => 397,
                        false => 398,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 399,
                        false => 400,
                    },
                    false => Waterlogged switch {
                        true => 401,
                        false => 402,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 403,
                        false => 404,
                    },
                    false => Waterlogged switch {
                        true => 405,
                        false => 406,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            379 => new AcaciaLeavesBlock(Identifier, 1, true, true),
            380 => new AcaciaLeavesBlock(Identifier, 1, true, false),
            381 => new AcaciaLeavesBlock(Identifier, 1, false, true),
            382 => new AcaciaLeavesBlock(Identifier, 1, false, false),
            383 => new AcaciaLeavesBlock(Identifier, 2, true, true),
            384 => new AcaciaLeavesBlock(Identifier, 2, true, false),
            385 => new AcaciaLeavesBlock(Identifier, 2, false, true),
            386 => new AcaciaLeavesBlock(Identifier, 2, false, false),
            387 => new AcaciaLeavesBlock(Identifier, 3, true, true),
            388 => new AcaciaLeavesBlock(Identifier, 3, true, false),
            389 => new AcaciaLeavesBlock(Identifier, 3, false, true),
            390 => new AcaciaLeavesBlock(Identifier, 3, false, false),
            391 => new AcaciaLeavesBlock(Identifier, 4, true, true),
            392 => new AcaciaLeavesBlock(Identifier, 4, true, false),
            393 => new AcaciaLeavesBlock(Identifier, 4, false, true),
            394 => new AcaciaLeavesBlock(Identifier, 4, false, false),
            395 => new AcaciaLeavesBlock(Identifier, 5, true, true),
            396 => new AcaciaLeavesBlock(Identifier, 5, true, false),
            397 => new AcaciaLeavesBlock(Identifier, 5, false, true),
            398 => new AcaciaLeavesBlock(Identifier, 5, false, false),
            399 => new AcaciaLeavesBlock(Identifier, 6, true, true),
            400 => new AcaciaLeavesBlock(Identifier, 6, true, false),
            401 => new AcaciaLeavesBlock(Identifier, 6, false, true),
            402 => new AcaciaLeavesBlock(Identifier, 6, false, false),
            403 => new AcaciaLeavesBlock(Identifier, 7, true, true),
            404 => new AcaciaLeavesBlock(Identifier, 7, true, false),
            405 => new AcaciaLeavesBlock(Identifier, 7, false, true),
            406 => new AcaciaLeavesBlock(Identifier, 7, false, false),
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
