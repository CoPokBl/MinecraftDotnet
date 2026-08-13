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
public record SpruceLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:tinted_particle_leaves", "block.minecraft.spruce_leaves", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_leaves", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 280];

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
                        true => 280,
                        false => 281,
                    },
                    false => Waterlogged switch {
                        true => 282,
                        false => 283,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 284,
                        false => 285,
                    },
                    false => Waterlogged switch {
                        true => 286,
                        false => 287,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 288,
                        false => 289,
                    },
                    false => Waterlogged switch {
                        true => 290,
                        false => 291,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 292,
                        false => 293,
                    },
                    false => Waterlogged switch {
                        true => 294,
                        false => 295,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 296,
                        false => 297,
                    },
                    false => Waterlogged switch {
                        true => 298,
                        false => 299,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 300,
                        false => 301,
                    },
                    false => Waterlogged switch {
                        true => 302,
                        false => 303,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 304,
                        false => 305,
                    },
                    false => Waterlogged switch {
                        true => 306,
                        false => 307,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            280 => new SpruceLeavesBlock(Identifier, 1, true, true),
            281 => new SpruceLeavesBlock(Identifier, 1, true, false),
            282 => new SpruceLeavesBlock(Identifier, 1, false, true),
            283 => new SpruceLeavesBlock(Identifier, 1, false, false),
            284 => new SpruceLeavesBlock(Identifier, 2, true, true),
            285 => new SpruceLeavesBlock(Identifier, 2, true, false),
            286 => new SpruceLeavesBlock(Identifier, 2, false, true),
            287 => new SpruceLeavesBlock(Identifier, 2, false, false),
            288 => new SpruceLeavesBlock(Identifier, 3, true, true),
            289 => new SpruceLeavesBlock(Identifier, 3, true, false),
            290 => new SpruceLeavesBlock(Identifier, 3, false, true),
            291 => new SpruceLeavesBlock(Identifier, 3, false, false),
            292 => new SpruceLeavesBlock(Identifier, 4, true, true),
            293 => new SpruceLeavesBlock(Identifier, 4, true, false),
            294 => new SpruceLeavesBlock(Identifier, 4, false, true),
            295 => new SpruceLeavesBlock(Identifier, 4, false, false),
            296 => new SpruceLeavesBlock(Identifier, 5, true, true),
            297 => new SpruceLeavesBlock(Identifier, 5, true, false),
            298 => new SpruceLeavesBlock(Identifier, 5, false, true),
            299 => new SpruceLeavesBlock(Identifier, 5, false, false),
            300 => new SpruceLeavesBlock(Identifier, 6, true, true),
            301 => new SpruceLeavesBlock(Identifier, 6, true, false),
            302 => new SpruceLeavesBlock(Identifier, 6, false, true),
            303 => new SpruceLeavesBlock(Identifier, 6, false, false),
            304 => new SpruceLeavesBlock(Identifier, 7, true, true),
            305 => new SpruceLeavesBlock(Identifier, 7, true, false),
            306 => new SpruceLeavesBlock(Identifier, 7, false, true),
            307 => new SpruceLeavesBlock(Identifier, 7, false, false),
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
