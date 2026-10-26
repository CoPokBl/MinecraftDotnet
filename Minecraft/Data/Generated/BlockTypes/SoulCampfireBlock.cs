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
public record SoulCampfireBlock(Identifier Identifier, Direction Facing, bool Lit, bool SignalFire, bool Waterlogged) : IBlock, IHorizontalFacing, ILit, ISignalFire, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.soul_campfire", 2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:campfire", "minecraft:soul_campfire", BlockInfo.VanillaOnly, "minecraft:blocks/soul_campfire");
    private static readonly BlockStateInfo I0 = new(2f, 10, 1, PushReaction.PushPull, 34, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S411, BlockShapes.S411, BlockShapes.S1, BlockShapes.S1, BlockShapes.S411, BlockShapes.S411);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 24266];

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
                            true => 24266,
                            false => 24267,
                        },
                        false => Waterlogged switch {
                            true => 24268,
                            false => 24269,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24270,
                            false => 24271,
                        },
                        false => Waterlogged switch {
                            true => 24272,
                            false => 24273,
                        },
                    },
                },
                Direction.South => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24274,
                            false => 24275,
                        },
                        false => Waterlogged switch {
                            true => 24276,
                            false => 24277,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24278,
                            false => 24279,
                        },
                        false => Waterlogged switch {
                            true => 24280,
                            false => 24281,
                        },
                    },
                },
                Direction.West => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24282,
                            false => 24283,
                        },
                        false => Waterlogged switch {
                            true => 24284,
                            false => 24285,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24286,
                            false => 24287,
                        },
                        false => Waterlogged switch {
                            true => 24288,
                            false => 24289,
                        },
                    },
                },
                Direction.East => Lit switch {
                    true => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24290,
                            false => 24291,
                        },
                        false => Waterlogged switch {
                            true => 24292,
                            false => 24293,
                        },
                    },
                    false => SignalFire switch {
                        true => Waterlogged switch {
                            true => 24294,
                            false => 24295,
                        },
                        false => Waterlogged switch {
                            true => 24296,
                            false => 24297,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24266 => new SoulCampfireBlock(Identifier, Direction.North, true, true, true),
            24267 => new SoulCampfireBlock(Identifier, Direction.North, true, true, false),
            24268 => new SoulCampfireBlock(Identifier, Direction.North, true, false, true),
            24269 => new SoulCampfireBlock(Identifier, Direction.North, true, false, false),
            24270 => new SoulCampfireBlock(Identifier, Direction.North, false, true, true),
            24271 => new SoulCampfireBlock(Identifier, Direction.North, false, true, false),
            24272 => new SoulCampfireBlock(Identifier, Direction.North, false, false, true),
            24273 => new SoulCampfireBlock(Identifier, Direction.North, false, false, false),
            24274 => new SoulCampfireBlock(Identifier, Direction.South, true, true, true),
            24275 => new SoulCampfireBlock(Identifier, Direction.South, true, true, false),
            24276 => new SoulCampfireBlock(Identifier, Direction.South, true, false, true),
            24277 => new SoulCampfireBlock(Identifier, Direction.South, true, false, false),
            24278 => new SoulCampfireBlock(Identifier, Direction.South, false, true, true),
            24279 => new SoulCampfireBlock(Identifier, Direction.South, false, true, false),
            24280 => new SoulCampfireBlock(Identifier, Direction.South, false, false, true),
            24281 => new SoulCampfireBlock(Identifier, Direction.South, false, false, false),
            24282 => new SoulCampfireBlock(Identifier, Direction.West, true, true, true),
            24283 => new SoulCampfireBlock(Identifier, Direction.West, true, true, false),
            24284 => new SoulCampfireBlock(Identifier, Direction.West, true, false, true),
            24285 => new SoulCampfireBlock(Identifier, Direction.West, true, false, false),
            24286 => new SoulCampfireBlock(Identifier, Direction.West, false, true, true),
            24287 => new SoulCampfireBlock(Identifier, Direction.West, false, true, false),
            24288 => new SoulCampfireBlock(Identifier, Direction.West, false, false, true),
            24289 => new SoulCampfireBlock(Identifier, Direction.West, false, false, false),
            24290 => new SoulCampfireBlock(Identifier, Direction.East, true, true, true),
            24291 => new SoulCampfireBlock(Identifier, Direction.East, true, true, false),
            24292 => new SoulCampfireBlock(Identifier, Direction.East, true, false, true),
            24293 => new SoulCampfireBlock(Identifier, Direction.East, true, false, false),
            24294 => new SoulCampfireBlock(Identifier, Direction.East, false, true, true),
            24295 => new SoulCampfireBlock(Identifier, Direction.East, false, true, false),
            24296 => new SoulCampfireBlock(Identifier, Direction.East, false, false, true),
            24297 => new SoulCampfireBlock(Identifier, Direction.East, false, false, false),
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
