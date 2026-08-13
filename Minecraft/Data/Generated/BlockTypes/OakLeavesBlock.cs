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
public record OakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.oak_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 252];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 252,
                        false => 253,
                    },
                    false => Waterlogged switch {
                        true => 254,
                        false => 255,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 256,
                        false => 257,
                    },
                    false => Waterlogged switch {
                        true => 258,
                        false => 259,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 260,
                        false => 261,
                    },
                    false => Waterlogged switch {
                        true => 262,
                        false => 263,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 264,
                        false => 265,
                    },
                    false => Waterlogged switch {
                        true => 266,
                        false => 267,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 268,
                        false => 269,
                    },
                    false => Waterlogged switch {
                        true => 270,
                        false => 271,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 272,
                        false => 273,
                    },
                    false => Waterlogged switch {
                        true => 274,
                        false => 275,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 276,
                        false => 277,
                    },
                    false => Waterlogged switch {
                        true => 278,
                        false => 279,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            252 => new OakLeavesBlock(Identifier, 1, true, true),
            253 => new OakLeavesBlock(Identifier, 1, true, false),
            254 => new OakLeavesBlock(Identifier, 1, false, true),
            255 => new OakLeavesBlock(Identifier, 1, false, false),
            256 => new OakLeavesBlock(Identifier, 2, true, true),
            257 => new OakLeavesBlock(Identifier, 2, true, false),
            258 => new OakLeavesBlock(Identifier, 2, false, true),
            259 => new OakLeavesBlock(Identifier, 2, false, false),
            260 => new OakLeavesBlock(Identifier, 3, true, true),
            261 => new OakLeavesBlock(Identifier, 3, true, false),
            262 => new OakLeavesBlock(Identifier, 3, false, true),
            263 => new OakLeavesBlock(Identifier, 3, false, false),
            264 => new OakLeavesBlock(Identifier, 4, true, true),
            265 => new OakLeavesBlock(Identifier, 4, true, false),
            266 => new OakLeavesBlock(Identifier, 4, false, true),
            267 => new OakLeavesBlock(Identifier, 4, false, false),
            268 => new OakLeavesBlock(Identifier, 5, true, true),
            269 => new OakLeavesBlock(Identifier, 5, true, false),
            270 => new OakLeavesBlock(Identifier, 5, false, true),
            271 => new OakLeavesBlock(Identifier, 5, false, false),
            272 => new OakLeavesBlock(Identifier, 6, true, true),
            273 => new OakLeavesBlock(Identifier, 6, true, false),
            274 => new OakLeavesBlock(Identifier, 6, false, true),
            275 => new OakLeavesBlock(Identifier, 6, false, false),
            276 => new OakLeavesBlock(Identifier, 7, true, true),
            277 => new OakLeavesBlock(Identifier, 7, true, false),
            278 => new OakLeavesBlock(Identifier, 7, false, true),
            279 => new OakLeavesBlock(Identifier, 7, false, false),
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
