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
public record RedPoplarLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.red_poplar_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_poplar_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/red_poplar_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 28, "poplar_leaves", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 519];

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
                        true => 519,
                        false => 520,
                    },
                    false => Waterlogged switch {
                        true => 521,
                        false => 522,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 523,
                        false => 524,
                    },
                    false => Waterlogged switch {
                        true => 525,
                        false => 526,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 527,
                        false => 528,
                    },
                    false => Waterlogged switch {
                        true => 529,
                        false => 530,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 531,
                        false => 532,
                    },
                    false => Waterlogged switch {
                        true => 533,
                        false => 534,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 535,
                        false => 536,
                    },
                    false => Waterlogged switch {
                        true => 537,
                        false => 538,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 539,
                        false => 540,
                    },
                    false => Waterlogged switch {
                        true => 541,
                        false => 542,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 543,
                        false => 544,
                    },
                    false => Waterlogged switch {
                        true => 545,
                        false => 546,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            519 => new RedPoplarLeavesBlock(Identifier, 1, true, true),
            520 => new RedPoplarLeavesBlock(Identifier, 1, true, false),
            521 => new RedPoplarLeavesBlock(Identifier, 1, false, true),
            522 => new RedPoplarLeavesBlock(Identifier, 1, false, false),
            523 => new RedPoplarLeavesBlock(Identifier, 2, true, true),
            524 => new RedPoplarLeavesBlock(Identifier, 2, true, false),
            525 => new RedPoplarLeavesBlock(Identifier, 2, false, true),
            526 => new RedPoplarLeavesBlock(Identifier, 2, false, false),
            527 => new RedPoplarLeavesBlock(Identifier, 3, true, true),
            528 => new RedPoplarLeavesBlock(Identifier, 3, true, false),
            529 => new RedPoplarLeavesBlock(Identifier, 3, false, true),
            530 => new RedPoplarLeavesBlock(Identifier, 3, false, false),
            531 => new RedPoplarLeavesBlock(Identifier, 4, true, true),
            532 => new RedPoplarLeavesBlock(Identifier, 4, true, false),
            533 => new RedPoplarLeavesBlock(Identifier, 4, false, true),
            534 => new RedPoplarLeavesBlock(Identifier, 4, false, false),
            535 => new RedPoplarLeavesBlock(Identifier, 5, true, true),
            536 => new RedPoplarLeavesBlock(Identifier, 5, true, false),
            537 => new RedPoplarLeavesBlock(Identifier, 5, false, true),
            538 => new RedPoplarLeavesBlock(Identifier, 5, false, false),
            539 => new RedPoplarLeavesBlock(Identifier, 6, true, true),
            540 => new RedPoplarLeavesBlock(Identifier, 6, true, false),
            541 => new RedPoplarLeavesBlock(Identifier, 6, false, true),
            542 => new RedPoplarLeavesBlock(Identifier, 6, false, false),
            543 => new RedPoplarLeavesBlock(Identifier, 7, true, true),
            544 => new RedPoplarLeavesBlock(Identifier, 7, true, false),
            545 => new RedPoplarLeavesBlock(Identifier, 7, false, true),
            546 => new RedPoplarLeavesBlock(Identifier, 7, false, false),
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
