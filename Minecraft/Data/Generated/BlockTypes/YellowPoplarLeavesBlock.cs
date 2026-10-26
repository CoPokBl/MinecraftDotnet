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
public record YellowPoplarLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.yellow_poplar_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:yellow_poplar_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/yellow_poplar_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 18, "poplar_leaves", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 575];

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
                        true => 575,
                        false => 576,
                    },
                    false => Waterlogged switch {
                        true => 577,
                        false => 578,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 579,
                        false => 580,
                    },
                    false => Waterlogged switch {
                        true => 581,
                        false => 582,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 583,
                        false => 584,
                    },
                    false => Waterlogged switch {
                        true => 585,
                        false => 586,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 587,
                        false => 588,
                    },
                    false => Waterlogged switch {
                        true => 589,
                        false => 590,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 591,
                        false => 592,
                    },
                    false => Waterlogged switch {
                        true => 593,
                        false => 594,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 595,
                        false => 596,
                    },
                    false => Waterlogged switch {
                        true => 597,
                        false => 598,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 599,
                        false => 600,
                    },
                    false => Waterlogged switch {
                        true => 601,
                        false => 602,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            575 => new YellowPoplarLeavesBlock(Identifier, 1, true, true),
            576 => new YellowPoplarLeavesBlock(Identifier, 1, true, false),
            577 => new YellowPoplarLeavesBlock(Identifier, 1, false, true),
            578 => new YellowPoplarLeavesBlock(Identifier, 1, false, false),
            579 => new YellowPoplarLeavesBlock(Identifier, 2, true, true),
            580 => new YellowPoplarLeavesBlock(Identifier, 2, true, false),
            581 => new YellowPoplarLeavesBlock(Identifier, 2, false, true),
            582 => new YellowPoplarLeavesBlock(Identifier, 2, false, false),
            583 => new YellowPoplarLeavesBlock(Identifier, 3, true, true),
            584 => new YellowPoplarLeavesBlock(Identifier, 3, true, false),
            585 => new YellowPoplarLeavesBlock(Identifier, 3, false, true),
            586 => new YellowPoplarLeavesBlock(Identifier, 3, false, false),
            587 => new YellowPoplarLeavesBlock(Identifier, 4, true, true),
            588 => new YellowPoplarLeavesBlock(Identifier, 4, true, false),
            589 => new YellowPoplarLeavesBlock(Identifier, 4, false, true),
            590 => new YellowPoplarLeavesBlock(Identifier, 4, false, false),
            591 => new YellowPoplarLeavesBlock(Identifier, 5, true, true),
            592 => new YellowPoplarLeavesBlock(Identifier, 5, true, false),
            593 => new YellowPoplarLeavesBlock(Identifier, 5, false, true),
            594 => new YellowPoplarLeavesBlock(Identifier, 5, false, false),
            595 => new YellowPoplarLeavesBlock(Identifier, 6, true, true),
            596 => new YellowPoplarLeavesBlock(Identifier, 6, true, false),
            597 => new YellowPoplarLeavesBlock(Identifier, 6, false, true),
            598 => new YellowPoplarLeavesBlock(Identifier, 6, false, false),
            599 => new YellowPoplarLeavesBlock(Identifier, 7, true, true),
            600 => new YellowPoplarLeavesBlock(Identifier, 7, true, false),
            601 => new YellowPoplarLeavesBlock(Identifier, 7, false, true),
            602 => new YellowPoplarLeavesBlock(Identifier, 7, false, false),
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
