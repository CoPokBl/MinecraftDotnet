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
public record CherryLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 20, "cherry_leaves", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 407];

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
                        true => 407,
                        false => 408,
                    },
                    false => Waterlogged switch {
                        true => 409,
                        false => 410,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 411,
                        false => 412,
                    },
                    false => Waterlogged switch {
                        true => 413,
                        false => 414,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 415,
                        false => 416,
                    },
                    false => Waterlogged switch {
                        true => 417,
                        false => 418,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 419,
                        false => 420,
                    },
                    false => Waterlogged switch {
                        true => 421,
                        false => 422,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 423,
                        false => 424,
                    },
                    false => Waterlogged switch {
                        true => 425,
                        false => 426,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 427,
                        false => 428,
                    },
                    false => Waterlogged switch {
                        true => 429,
                        false => 430,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 431,
                        false => 432,
                    },
                    false => Waterlogged switch {
                        true => 433,
                        false => 434,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            407 => new CherryLeavesBlock(Identifier, 1, true, true),
            408 => new CherryLeavesBlock(Identifier, 1, true, false),
            409 => new CherryLeavesBlock(Identifier, 1, false, true),
            410 => new CherryLeavesBlock(Identifier, 1, false, false),
            411 => new CherryLeavesBlock(Identifier, 2, true, true),
            412 => new CherryLeavesBlock(Identifier, 2, true, false),
            413 => new CherryLeavesBlock(Identifier, 2, false, true),
            414 => new CherryLeavesBlock(Identifier, 2, false, false),
            415 => new CherryLeavesBlock(Identifier, 3, true, true),
            416 => new CherryLeavesBlock(Identifier, 3, true, false),
            417 => new CherryLeavesBlock(Identifier, 3, false, true),
            418 => new CherryLeavesBlock(Identifier, 3, false, false),
            419 => new CherryLeavesBlock(Identifier, 4, true, true),
            420 => new CherryLeavesBlock(Identifier, 4, true, false),
            421 => new CherryLeavesBlock(Identifier, 4, false, true),
            422 => new CherryLeavesBlock(Identifier, 4, false, false),
            423 => new CherryLeavesBlock(Identifier, 5, true, true),
            424 => new CherryLeavesBlock(Identifier, 5, true, false),
            425 => new CherryLeavesBlock(Identifier, 5, false, true),
            426 => new CherryLeavesBlock(Identifier, 5, false, false),
            427 => new CherryLeavesBlock(Identifier, 6, true, true),
            428 => new CherryLeavesBlock(Identifier, 6, true, false),
            429 => new CherryLeavesBlock(Identifier, 6, false, true),
            430 => new CherryLeavesBlock(Identifier, 6, false, false),
            431 => new CherryLeavesBlock(Identifier, 7, true, true),
            432 => new CherryLeavesBlock(Identifier, 7, true, false),
            433 => new CherryLeavesBlock(Identifier, 7, false, true),
            434 => new CherryLeavesBlock(Identifier, 7, false, false),
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
