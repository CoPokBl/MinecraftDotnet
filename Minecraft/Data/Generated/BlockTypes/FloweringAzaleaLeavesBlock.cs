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
public record FloweringAzaleaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.flowering_azalea_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:flowering_azalea_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/flowering_azalea_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "azalea_leaves", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 631];

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
                        true => 631,
                        false => 632,
                    },
                    false => Waterlogged switch {
                        true => 633,
                        false => 634,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 635,
                        false => 636,
                    },
                    false => Waterlogged switch {
                        true => 637,
                        false => 638,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 639,
                        false => 640,
                    },
                    false => Waterlogged switch {
                        true => 641,
                        false => 642,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 643,
                        false => 644,
                    },
                    false => Waterlogged switch {
                        true => 645,
                        false => 646,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 647,
                        false => 648,
                    },
                    false => Waterlogged switch {
                        true => 649,
                        false => 650,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 651,
                        false => 652,
                    },
                    false => Waterlogged switch {
                        true => 653,
                        false => 654,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 655,
                        false => 656,
                    },
                    false => Waterlogged switch {
                        true => 657,
                        false => 658,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            631 => new FloweringAzaleaLeavesBlock(Identifier, 1, true, true),
            632 => new FloweringAzaleaLeavesBlock(Identifier, 1, true, false),
            633 => new FloweringAzaleaLeavesBlock(Identifier, 1, false, true),
            634 => new FloweringAzaleaLeavesBlock(Identifier, 1, false, false),
            635 => new FloweringAzaleaLeavesBlock(Identifier, 2, true, true),
            636 => new FloweringAzaleaLeavesBlock(Identifier, 2, true, false),
            637 => new FloweringAzaleaLeavesBlock(Identifier, 2, false, true),
            638 => new FloweringAzaleaLeavesBlock(Identifier, 2, false, false),
            639 => new FloweringAzaleaLeavesBlock(Identifier, 3, true, true),
            640 => new FloweringAzaleaLeavesBlock(Identifier, 3, true, false),
            641 => new FloweringAzaleaLeavesBlock(Identifier, 3, false, true),
            642 => new FloweringAzaleaLeavesBlock(Identifier, 3, false, false),
            643 => new FloweringAzaleaLeavesBlock(Identifier, 4, true, true),
            644 => new FloweringAzaleaLeavesBlock(Identifier, 4, true, false),
            645 => new FloweringAzaleaLeavesBlock(Identifier, 4, false, true),
            646 => new FloweringAzaleaLeavesBlock(Identifier, 4, false, false),
            647 => new FloweringAzaleaLeavesBlock(Identifier, 5, true, true),
            648 => new FloweringAzaleaLeavesBlock(Identifier, 5, true, false),
            649 => new FloweringAzaleaLeavesBlock(Identifier, 5, false, true),
            650 => new FloweringAzaleaLeavesBlock(Identifier, 5, false, false),
            651 => new FloweringAzaleaLeavesBlock(Identifier, 6, true, true),
            652 => new FloweringAzaleaLeavesBlock(Identifier, 6, true, false),
            653 => new FloweringAzaleaLeavesBlock(Identifier, 6, false, true),
            654 => new FloweringAzaleaLeavesBlock(Identifier, 6, false, false),
            655 => new FloweringAzaleaLeavesBlock(Identifier, 7, true, true),
            656 => new FloweringAzaleaLeavesBlock(Identifier, 7, true, false),
            657 => new FloweringAzaleaLeavesBlock(Identifier, 7, false, true),
            658 => new FloweringAzaleaLeavesBlock(Identifier, 7, false, false),
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
