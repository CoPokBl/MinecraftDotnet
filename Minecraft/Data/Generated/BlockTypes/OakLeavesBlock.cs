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
public record OakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/oak_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 267];

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
                        true => 267,
                        false => 268,
                    },
                    false => Waterlogged switch {
                        true => 269,
                        false => 270,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 271,
                        false => 272,
                    },
                    false => Waterlogged switch {
                        true => 273,
                        false => 274,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 275,
                        false => 276,
                    },
                    false => Waterlogged switch {
                        true => 277,
                        false => 278,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 279,
                        false => 280,
                    },
                    false => Waterlogged switch {
                        true => 281,
                        false => 282,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 283,
                        false => 284,
                    },
                    false => Waterlogged switch {
                        true => 285,
                        false => 286,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 287,
                        false => 288,
                    },
                    false => Waterlogged switch {
                        true => 289,
                        false => 290,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 291,
                        false => 292,
                    },
                    false => Waterlogged switch {
                        true => 293,
                        false => 294,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            267 => new OakLeavesBlock(Identifier, 1, true, true),
            268 => new OakLeavesBlock(Identifier, 1, true, false),
            269 => new OakLeavesBlock(Identifier, 1, false, true),
            270 => new OakLeavesBlock(Identifier, 1, false, false),
            271 => new OakLeavesBlock(Identifier, 2, true, true),
            272 => new OakLeavesBlock(Identifier, 2, true, false),
            273 => new OakLeavesBlock(Identifier, 2, false, true),
            274 => new OakLeavesBlock(Identifier, 2, false, false),
            275 => new OakLeavesBlock(Identifier, 3, true, true),
            276 => new OakLeavesBlock(Identifier, 3, true, false),
            277 => new OakLeavesBlock(Identifier, 3, false, true),
            278 => new OakLeavesBlock(Identifier, 3, false, false),
            279 => new OakLeavesBlock(Identifier, 4, true, true),
            280 => new OakLeavesBlock(Identifier, 4, true, false),
            281 => new OakLeavesBlock(Identifier, 4, false, true),
            282 => new OakLeavesBlock(Identifier, 4, false, false),
            283 => new OakLeavesBlock(Identifier, 5, true, true),
            284 => new OakLeavesBlock(Identifier, 5, true, false),
            285 => new OakLeavesBlock(Identifier, 5, false, true),
            286 => new OakLeavesBlock(Identifier, 5, false, false),
            287 => new OakLeavesBlock(Identifier, 6, true, true),
            288 => new OakLeavesBlock(Identifier, 6, true, false),
            289 => new OakLeavesBlock(Identifier, 6, false, true),
            290 => new OakLeavesBlock(Identifier, 6, false, false),
            291 => new OakLeavesBlock(Identifier, 7, true, true),
            292 => new OakLeavesBlock(Identifier, 7, true, false),
            293 => new OakLeavesBlock(Identifier, 7, false, true),
            294 => new OakLeavesBlock(Identifier, 7, false, false),
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
