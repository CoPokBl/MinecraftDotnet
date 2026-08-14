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
public record DarkOakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.dark_oak_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 420];

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
                        true => 420,
                        false => 421,
                    },
                    false => Waterlogged switch {
                        true => 422,
                        false => 423,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 424,
                        false => 425,
                    },
                    false => Waterlogged switch {
                        true => 426,
                        false => 427,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 428,
                        false => 429,
                    },
                    false => Waterlogged switch {
                        true => 430,
                        false => 431,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 432,
                        false => 433,
                    },
                    false => Waterlogged switch {
                        true => 434,
                        false => 435,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 436,
                        false => 437,
                    },
                    false => Waterlogged switch {
                        true => 438,
                        false => 439,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 440,
                        false => 441,
                    },
                    false => Waterlogged switch {
                        true => 442,
                        false => 443,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 444,
                        false => 445,
                    },
                    false => Waterlogged switch {
                        true => 446,
                        false => 447,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            420 => new DarkOakLeavesBlock(Identifier, 1, true, true),
            421 => new DarkOakLeavesBlock(Identifier, 1, true, false),
            422 => new DarkOakLeavesBlock(Identifier, 1, false, true),
            423 => new DarkOakLeavesBlock(Identifier, 1, false, false),
            424 => new DarkOakLeavesBlock(Identifier, 2, true, true),
            425 => new DarkOakLeavesBlock(Identifier, 2, true, false),
            426 => new DarkOakLeavesBlock(Identifier, 2, false, true),
            427 => new DarkOakLeavesBlock(Identifier, 2, false, false),
            428 => new DarkOakLeavesBlock(Identifier, 3, true, true),
            429 => new DarkOakLeavesBlock(Identifier, 3, true, false),
            430 => new DarkOakLeavesBlock(Identifier, 3, false, true),
            431 => new DarkOakLeavesBlock(Identifier, 3, false, false),
            432 => new DarkOakLeavesBlock(Identifier, 4, true, true),
            433 => new DarkOakLeavesBlock(Identifier, 4, true, false),
            434 => new DarkOakLeavesBlock(Identifier, 4, false, true),
            435 => new DarkOakLeavesBlock(Identifier, 4, false, false),
            436 => new DarkOakLeavesBlock(Identifier, 5, true, true),
            437 => new DarkOakLeavesBlock(Identifier, 5, true, false),
            438 => new DarkOakLeavesBlock(Identifier, 5, false, true),
            439 => new DarkOakLeavesBlock(Identifier, 5, false, false),
            440 => new DarkOakLeavesBlock(Identifier, 6, true, true),
            441 => new DarkOakLeavesBlock(Identifier, 6, true, false),
            442 => new DarkOakLeavesBlock(Identifier, 6, false, true),
            443 => new DarkOakLeavesBlock(Identifier, 6, false, false),
            444 => new DarkOakLeavesBlock(Identifier, 7, true, true),
            445 => new DarkOakLeavesBlock(Identifier, 7, true, false),
            446 => new DarkOakLeavesBlock(Identifier, 7, false, true),
            447 => new DarkOakLeavesBlock(Identifier, 7, false, false),
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
