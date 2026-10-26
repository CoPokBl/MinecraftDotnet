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
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 435];

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
                        true => 435,
                        false => 436,
                    },
                    false => Waterlogged switch {
                        true => 437,
                        false => 438,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 439,
                        false => 440,
                    },
                    false => Waterlogged switch {
                        true => 441,
                        false => 442,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 443,
                        false => 444,
                    },
                    false => Waterlogged switch {
                        true => 445,
                        false => 446,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 447,
                        false => 448,
                    },
                    false => Waterlogged switch {
                        true => 449,
                        false => 450,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 451,
                        false => 452,
                    },
                    false => Waterlogged switch {
                        true => 453,
                        false => 454,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 455,
                        false => 456,
                    },
                    false => Waterlogged switch {
                        true => 457,
                        false => 458,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 459,
                        false => 460,
                    },
                    false => Waterlogged switch {
                        true => 461,
                        false => 462,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            435 => new DarkOakLeavesBlock(Identifier, 1, true, true),
            436 => new DarkOakLeavesBlock(Identifier, 1, true, false),
            437 => new DarkOakLeavesBlock(Identifier, 1, false, true),
            438 => new DarkOakLeavesBlock(Identifier, 1, false, false),
            439 => new DarkOakLeavesBlock(Identifier, 2, true, true),
            440 => new DarkOakLeavesBlock(Identifier, 2, true, false),
            441 => new DarkOakLeavesBlock(Identifier, 2, false, true),
            442 => new DarkOakLeavesBlock(Identifier, 2, false, false),
            443 => new DarkOakLeavesBlock(Identifier, 3, true, true),
            444 => new DarkOakLeavesBlock(Identifier, 3, true, false),
            445 => new DarkOakLeavesBlock(Identifier, 3, false, true),
            446 => new DarkOakLeavesBlock(Identifier, 3, false, false),
            447 => new DarkOakLeavesBlock(Identifier, 4, true, true),
            448 => new DarkOakLeavesBlock(Identifier, 4, true, false),
            449 => new DarkOakLeavesBlock(Identifier, 4, false, true),
            450 => new DarkOakLeavesBlock(Identifier, 4, false, false),
            451 => new DarkOakLeavesBlock(Identifier, 5, true, true),
            452 => new DarkOakLeavesBlock(Identifier, 5, true, false),
            453 => new DarkOakLeavesBlock(Identifier, 5, false, true),
            454 => new DarkOakLeavesBlock(Identifier, 5, false, false),
            455 => new DarkOakLeavesBlock(Identifier, 6, true, true),
            456 => new DarkOakLeavesBlock(Identifier, 6, true, false),
            457 => new DarkOakLeavesBlock(Identifier, 6, false, true),
            458 => new DarkOakLeavesBlock(Identifier, 6, false, false),
            459 => new DarkOakLeavesBlock(Identifier, 7, true, true),
            460 => new DarkOakLeavesBlock(Identifier, 7, true, false),
            461 => new DarkOakLeavesBlock(Identifier, 7, false, true),
            462 => new DarkOakLeavesBlock(Identifier, 7, false, false),
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
