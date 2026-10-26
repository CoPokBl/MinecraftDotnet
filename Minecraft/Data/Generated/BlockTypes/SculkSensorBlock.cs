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
public record SculkSensorBlock(Identifier Identifier, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.sculk_sensor", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sculk_sensor", "minecraft:sculk_sensor", BlockInfo.VanillaOnly, "minecraft:blocks/sculk_sensor");
    private static readonly BlockStateInfo I0 = new(1.5f, 1, 1, PushReaction.PushPull, 23, "sculk_sensor", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, true, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S89, BlockShapes.S89, BlockShapes.S1, BlockShapes.S89, BlockShapes.S89, BlockShapes.S89);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 30520];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Power switch {
                0 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30520,
                        false => 30521,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30522,
                        false => 30523,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30524,
                        false => 30525,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                1 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30526,
                        false => 30527,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30528,
                        false => 30529,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30530,
                        false => 30531,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                2 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30532,
                        false => 30533,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30534,
                        false => 30535,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30536,
                        false => 30537,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                3 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30538,
                        false => 30539,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30540,
                        false => 30541,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30542,
                        false => 30543,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                4 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30544,
                        false => 30545,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30546,
                        false => 30547,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30548,
                        false => 30549,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                5 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30550,
                        false => 30551,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30552,
                        false => 30553,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30554,
                        false => 30555,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                6 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30556,
                        false => 30557,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30558,
                        false => 30559,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30560,
                        false => 30561,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                7 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30562,
                        false => 30563,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30564,
                        false => 30565,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30566,
                        false => 30567,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                8 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30568,
                        false => 30569,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30570,
                        false => 30571,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30572,
                        false => 30573,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                9 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30574,
                        false => 30575,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30576,
                        false => 30577,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30578,
                        false => 30579,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                10 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30580,
                        false => 30581,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30582,
                        false => 30583,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30584,
                        false => 30585,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                11 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30586,
                        false => 30587,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30588,
                        false => 30589,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30590,
                        false => 30591,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                12 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30592,
                        false => 30593,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30594,
                        false => 30595,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30596,
                        false => 30597,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                13 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30598,
                        false => 30599,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30600,
                        false => 30601,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30602,
                        false => 30603,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                14 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30604,
                        false => 30605,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30606,
                        false => 30607,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30608,
                        false => 30609,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                15 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 30610,
                        false => 30611,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 30612,
                        false => 30613,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 30614,
                        false => 30615,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30520 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, true),
            30521 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, false),
            30522 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, true),
            30523 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, false),
            30524 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, true),
            30525 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, false),
            30526 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, true),
            30527 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, false),
            30528 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, true),
            30529 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, false),
            30530 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, true),
            30531 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, false),
            30532 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, true),
            30533 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, false),
            30534 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, true),
            30535 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, false),
            30536 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, true),
            30537 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, false),
            30538 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, true),
            30539 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, false),
            30540 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, true),
            30541 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, false),
            30542 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, true),
            30543 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, false),
            30544 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, true),
            30545 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, false),
            30546 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, true),
            30547 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, false),
            30548 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, true),
            30549 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, false),
            30550 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, true),
            30551 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, false),
            30552 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, true),
            30553 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, false),
            30554 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, true),
            30555 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, false),
            30556 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, true),
            30557 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, false),
            30558 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, true),
            30559 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, false),
            30560 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, true),
            30561 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, false),
            30562 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, true),
            30563 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, false),
            30564 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, true),
            30565 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, false),
            30566 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, true),
            30567 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, false),
            30568 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, true),
            30569 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, false),
            30570 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, true),
            30571 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, false),
            30572 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, true),
            30573 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, false),
            30574 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, true),
            30575 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, false),
            30576 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, true),
            30577 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, false),
            30578 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, true),
            30579 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, false),
            30580 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, true),
            30581 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, false),
            30582 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, true),
            30583 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, false),
            30584 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, true),
            30585 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, false),
            30586 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, true),
            30587 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, false),
            30588 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, true),
            30589 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, false),
            30590 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, true),
            30591 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, false),
            30592 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, true),
            30593 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, false),
            30594 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, true),
            30595 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, false),
            30596 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, true),
            30597 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, false),
            30598 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, true),
            30599 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, false),
            30600 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, true),
            30601 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, false),
            30602 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, true),
            30603 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, false),
            30604 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, true),
            30605 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, false),
            30606 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, true),
            30607 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, false),
            30608 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, true),
            30609 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, false),
            30610 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, true),
            30611 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, false),
            30612 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, true),
            30613 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, false),
            30614 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, true),
            30615 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
            SculkSensorPhase = properties.Contains("sculk_sensor_phase") ? SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()) : SculkSensorPhase,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("power", new StringTag(Power.ToString())),
            ("sculk_sensor_phase", new StringTag(SculkSensorPhase.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
