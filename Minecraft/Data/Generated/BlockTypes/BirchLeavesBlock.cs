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
public record BirchLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.birch_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 308];

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
                        true => 308,
                        false => 309,
                    },
                    false => Waterlogged switch {
                        true => 310,
                        false => 311,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 312,
                        false => 313,
                    },
                    false => Waterlogged switch {
                        true => 314,
                        false => 315,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 316,
                        false => 317,
                    },
                    false => Waterlogged switch {
                        true => 318,
                        false => 319,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 320,
                        false => 321,
                    },
                    false => Waterlogged switch {
                        true => 322,
                        false => 323,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 324,
                        false => 325,
                    },
                    false => Waterlogged switch {
                        true => 326,
                        false => 327,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 328,
                        false => 329,
                    },
                    false => Waterlogged switch {
                        true => 330,
                        false => 331,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 332,
                        false => 333,
                    },
                    false => Waterlogged switch {
                        true => 334,
                        false => 335,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            308 => new BirchLeavesBlock(Identifier, 1, true, true),
            309 => new BirchLeavesBlock(Identifier, 1, true, false),
            310 => new BirchLeavesBlock(Identifier, 1, false, true),
            311 => new BirchLeavesBlock(Identifier, 1, false, false),
            312 => new BirchLeavesBlock(Identifier, 2, true, true),
            313 => new BirchLeavesBlock(Identifier, 2, true, false),
            314 => new BirchLeavesBlock(Identifier, 2, false, true),
            315 => new BirchLeavesBlock(Identifier, 2, false, false),
            316 => new BirchLeavesBlock(Identifier, 3, true, true),
            317 => new BirchLeavesBlock(Identifier, 3, true, false),
            318 => new BirchLeavesBlock(Identifier, 3, false, true),
            319 => new BirchLeavesBlock(Identifier, 3, false, false),
            320 => new BirchLeavesBlock(Identifier, 4, true, true),
            321 => new BirchLeavesBlock(Identifier, 4, true, false),
            322 => new BirchLeavesBlock(Identifier, 4, false, true),
            323 => new BirchLeavesBlock(Identifier, 4, false, false),
            324 => new BirchLeavesBlock(Identifier, 5, true, true),
            325 => new BirchLeavesBlock(Identifier, 5, true, false),
            326 => new BirchLeavesBlock(Identifier, 5, false, true),
            327 => new BirchLeavesBlock(Identifier, 5, false, false),
            328 => new BirchLeavesBlock(Identifier, 6, true, true),
            329 => new BirchLeavesBlock(Identifier, 6, true, false),
            330 => new BirchLeavesBlock(Identifier, 6, false, true),
            331 => new BirchLeavesBlock(Identifier, 6, false, false),
            332 => new BirchLeavesBlock(Identifier, 7, true, true),
            333 => new BirchLeavesBlock(Identifier, 7, true, false),
            334 => new BirchLeavesBlock(Identifier, 7, false, true),
            335 => new BirchLeavesBlock(Identifier, 7, false, false),
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
