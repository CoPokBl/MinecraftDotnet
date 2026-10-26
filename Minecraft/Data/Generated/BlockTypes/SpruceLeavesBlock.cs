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
public record SpruceLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock, IDistanced, IPersistent, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_leaves", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_leaves", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_leaves");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, ["minecraft:ocelot", "minecraft:parrot"], "minecraft:water", BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true };
    private static readonly BlockStateInfo I3 = I0 with { Flammable = true, RandomlyTicking = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 295];

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
                        true => 295,
                        false => 296,
                    },
                    false => Waterlogged switch {
                        true => 297,
                        false => 298,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 299,
                        false => 300,
                    },
                    false => Waterlogged switch {
                        true => 301,
                        false => 302,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 303,
                        false => 304,
                    },
                    false => Waterlogged switch {
                        true => 305,
                        false => 306,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 307,
                        false => 308,
                    },
                    false => Waterlogged switch {
                        true => 309,
                        false => 310,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 311,
                        false => 312,
                    },
                    false => Waterlogged switch {
                        true => 313,
                        false => 314,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 315,
                        false => 316,
                    },
                    false => Waterlogged switch {
                        true => 317,
                        false => 318,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 319,
                        false => 320,
                    },
                    false => Waterlogged switch {
                        true => 321,
                        false => 322,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            295 => new SpruceLeavesBlock(Identifier, 1, true, true),
            296 => new SpruceLeavesBlock(Identifier, 1, true, false),
            297 => new SpruceLeavesBlock(Identifier, 1, false, true),
            298 => new SpruceLeavesBlock(Identifier, 1, false, false),
            299 => new SpruceLeavesBlock(Identifier, 2, true, true),
            300 => new SpruceLeavesBlock(Identifier, 2, true, false),
            301 => new SpruceLeavesBlock(Identifier, 2, false, true),
            302 => new SpruceLeavesBlock(Identifier, 2, false, false),
            303 => new SpruceLeavesBlock(Identifier, 3, true, true),
            304 => new SpruceLeavesBlock(Identifier, 3, true, false),
            305 => new SpruceLeavesBlock(Identifier, 3, false, true),
            306 => new SpruceLeavesBlock(Identifier, 3, false, false),
            307 => new SpruceLeavesBlock(Identifier, 4, true, true),
            308 => new SpruceLeavesBlock(Identifier, 4, true, false),
            309 => new SpruceLeavesBlock(Identifier, 4, false, true),
            310 => new SpruceLeavesBlock(Identifier, 4, false, false),
            311 => new SpruceLeavesBlock(Identifier, 5, true, true),
            312 => new SpruceLeavesBlock(Identifier, 5, true, false),
            313 => new SpruceLeavesBlock(Identifier, 5, false, true),
            314 => new SpruceLeavesBlock(Identifier, 5, false, false),
            315 => new SpruceLeavesBlock(Identifier, 6, true, true),
            316 => new SpruceLeavesBlock(Identifier, 6, true, false),
            317 => new SpruceLeavesBlock(Identifier, 6, false, true),
            318 => new SpruceLeavesBlock(Identifier, 6, false, false),
            319 => new SpruceLeavesBlock(Identifier, 7, true, true),
            320 => new SpruceLeavesBlock(Identifier, 7, true, false),
            321 => new SpruceLeavesBlock(Identifier, 7, false, true),
            322 => new SpruceLeavesBlock(Identifier, 7, false, false),
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
