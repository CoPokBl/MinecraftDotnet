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
public record CampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock, IHorizontalFacing, ILit, ISignalFire, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.campfire", 2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:campfire", "minecraft:campfire", BlockInfo.VanillaOnly, "minecraft:blocks/campfire");
    private static readonly BlockStateInfo I0 = new(2f, 15, 1, PushReaction.PushPull, 34, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S411, BlockShapes.S411, BlockShapes.S1, BlockShapes.S1, BlockShapes.S411, BlockShapes.S411);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 24234];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithLit(bool lit) => this with { Lit = lit };

    public IBlock WithSignalFire(bool signalFire) => this with { SignalFire = signalFire };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24234,
                            false => 24235,
                        },
                        false => Waterlogged switch {
                            true => 24236,
                            false => 24237,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24238,
                            false => 24239,
                        },
                        false => Waterlogged switch {
                            true => 24240,
                            false => 24241,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24242,
                            false => 24243,
                        },
                        false => Waterlogged switch {
                            true => 24244,
                            false => 24245,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24246,
                            false => 24247,
                        },
                        false => Waterlogged switch {
                            true => 24248,
                            false => 24249,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24250,
                            false => 24251,
                        },
                        false => Waterlogged switch {
                            true => 24252,
                            false => 24253,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24254,
                            false => 24255,
                        },
                        false => Waterlogged switch {
                            true => 24256,
                            false => 24257,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24258,
                            false => 24259,
                        },
                        false => Waterlogged switch {
                            true => 24260,
                            false => 24261,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24262,
                            false => 24263,
                        },
                        false => Waterlogged switch {
                            true => 24264,
                            false => 24265,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24234 => new CampfireBlock(Identifier, Direction.North, true, true, true),
            24235 => new CampfireBlock(Identifier, Direction.North, true, true, false),
            24236 => new CampfireBlock(Identifier, Direction.North, true, false, true),
            24237 => new CampfireBlock(Identifier, Direction.North, true, false, false),
            24238 => new CampfireBlock(Identifier, Direction.North, false, true, true),
            24239 => new CampfireBlock(Identifier, Direction.North, false, true, false),
            24240 => new CampfireBlock(Identifier, Direction.North, false, false, true),
            24241 => new CampfireBlock(Identifier, Direction.North, false, false, false),
            24242 => new CampfireBlock(Identifier, Direction.South, true, true, true),
            24243 => new CampfireBlock(Identifier, Direction.South, true, true, false),
            24244 => new CampfireBlock(Identifier, Direction.South, true, false, true),
            24245 => new CampfireBlock(Identifier, Direction.South, true, false, false),
            24246 => new CampfireBlock(Identifier, Direction.South, false, true, true),
            24247 => new CampfireBlock(Identifier, Direction.South, false, true, false),
            24248 => new CampfireBlock(Identifier, Direction.South, false, false, true),
            24249 => new CampfireBlock(Identifier, Direction.South, false, false, false),
            24250 => new CampfireBlock(Identifier, Direction.West, true, true, true),
            24251 => new CampfireBlock(Identifier, Direction.West, true, true, false),
            24252 => new CampfireBlock(Identifier, Direction.West, true, false, true),
            24253 => new CampfireBlock(Identifier, Direction.West, true, false, false),
            24254 => new CampfireBlock(Identifier, Direction.West, false, true, true),
            24255 => new CampfireBlock(Identifier, Direction.West, false, true, false),
            24256 => new CampfireBlock(Identifier, Direction.West, false, false, true),
            24257 => new CampfireBlock(Identifier, Direction.West, false, false, false),
            24258 => new CampfireBlock(Identifier, Direction.East, true, true, true),
            24259 => new CampfireBlock(Identifier, Direction.East, true, true, false),
            24260 => new CampfireBlock(Identifier, Direction.East, true, false, true),
            24261 => new CampfireBlock(Identifier, Direction.East, true, false, false),
            24262 => new CampfireBlock(Identifier, Direction.East, false, true, true),
            24263 => new CampfireBlock(Identifier, Direction.East, false, true, false),
            24264 => new CampfireBlock(Identifier, Direction.East, false, false, true),
            24265 => new CampfireBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            SignalFire = properties.Contains("signal_fire") ? properties["signal_fire"].GetString() == "true" : SignalFire,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("signal_fire", new StringTag(SignalFire.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
