using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AzaleaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:untinted_particle_leaves", "block.minecraft.azalea_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:azalea_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "azalea_leaves", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S1, BlockShapes.S77);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 504];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 504,
                        false => 505,
                    },
                    false => Waterlogged switch {
                        true => 506,
                        false => 507,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 508,
                        false => 509,
                    },
                    false => Waterlogged switch {
                        true => 510,
                        false => 511,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 512,
                        false => 513,
                    },
                    false => Waterlogged switch {
                        true => 514,
                        false => 515,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 516,
                        false => 517,
                    },
                    false => Waterlogged switch {
                        true => 518,
                        false => 519,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 520,
                        false => 521,
                    },
                    false => Waterlogged switch {
                        true => 522,
                        false => 523,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 524,
                        false => 525,
                    },
                    false => Waterlogged switch {
                        true => 526,
                        false => 527,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 528,
                        false => 529,
                    },
                    false => Waterlogged switch {
                        true => 530,
                        false => 531,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            504 => new AzaleaLeavesBlock(Identifier, 1, true, true),
            505 => new AzaleaLeavesBlock(Identifier, 1, true, false),
            506 => new AzaleaLeavesBlock(Identifier, 1, false, true),
            507 => new AzaleaLeavesBlock(Identifier, 1, false, false),
            508 => new AzaleaLeavesBlock(Identifier, 2, true, true),
            509 => new AzaleaLeavesBlock(Identifier, 2, true, false),
            510 => new AzaleaLeavesBlock(Identifier, 2, false, true),
            511 => new AzaleaLeavesBlock(Identifier, 2, false, false),
            512 => new AzaleaLeavesBlock(Identifier, 3, true, true),
            513 => new AzaleaLeavesBlock(Identifier, 3, true, false),
            514 => new AzaleaLeavesBlock(Identifier, 3, false, true),
            515 => new AzaleaLeavesBlock(Identifier, 3, false, false),
            516 => new AzaleaLeavesBlock(Identifier, 4, true, true),
            517 => new AzaleaLeavesBlock(Identifier, 4, true, false),
            518 => new AzaleaLeavesBlock(Identifier, 4, false, true),
            519 => new AzaleaLeavesBlock(Identifier, 4, false, false),
            520 => new AzaleaLeavesBlock(Identifier, 5, true, true),
            521 => new AzaleaLeavesBlock(Identifier, 5, true, false),
            522 => new AzaleaLeavesBlock(Identifier, 5, false, true),
            523 => new AzaleaLeavesBlock(Identifier, 5, false, false),
            524 => new AzaleaLeavesBlock(Identifier, 6, true, true),
            525 => new AzaleaLeavesBlock(Identifier, 6, true, false),
            526 => new AzaleaLeavesBlock(Identifier, 6, false, true),
            527 => new AzaleaLeavesBlock(Identifier, 6, false, false),
            528 => new AzaleaLeavesBlock(Identifier, 7, true, true),
            529 => new AzaleaLeavesBlock(Identifier, 7, true, false),
            530 => new AzaleaLeavesBlock(Identifier, 7, false, true),
            531 => new AzaleaLeavesBlock(Identifier, 7, false, false),
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
