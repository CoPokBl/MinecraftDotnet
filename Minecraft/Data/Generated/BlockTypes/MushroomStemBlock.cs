using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MushroomStemBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:huge_mushroom", "block.minecraft.mushroom_stem", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mushroom_stem", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 15, PushReaction.Normal, 3, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, true, false, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);

    public BlockStateInfo StateInfo => I0;

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
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7894,
                                    false => 7895,
                                },
                                false => West switch {
                                    true => 7896,
                                    false => 7897,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7898,
                                    false => 7899,
                                },
                                false => West switch {
                                    true => 7900,
                                    false => 7901,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7902,
                                    false => 7903,
                                },
                                false => West switch {
                                    true => 7904,
                                    false => 7905,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7906,
                                    false => 7907,
                                },
                                false => West switch {
                                    true => 7908,
                                    false => 7909,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7910,
                                    false => 7911,
                                },
                                false => West switch {
                                    true => 7912,
                                    false => 7913,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7914,
                                    false => 7915,
                                },
                                false => West switch {
                                    true => 7916,
                                    false => 7917,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7918,
                                    false => 7919,
                                },
                                false => West switch {
                                    true => 7920,
                                    false => 7921,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7922,
                                    false => 7923,
                                },
                                false => West switch {
                                    true => 7924,
                                    false => 7925,
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7926,
                                    false => 7927,
                                },
                                false => West switch {
                                    true => 7928,
                                    false => 7929,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7930,
                                    false => 7931,
                                },
                                false => West switch {
                                    true => 7932,
                                    false => 7933,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7934,
                                    false => 7935,
                                },
                                false => West switch {
                                    true => 7936,
                                    false => 7937,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7938,
                                    false => 7939,
                                },
                                false => West switch {
                                    true => 7940,
                                    false => 7941,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7942,
                                    false => 7943,
                                },
                                false => West switch {
                                    true => 7944,
                                    false => 7945,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7946,
                                    false => 7947,
                                },
                                false => West switch {
                                    true => 7948,
                                    false => 7949,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 7950,
                                    false => 7951,
                                },
                                false => West switch {
                                    true => 7952,
                                    false => 7953,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 7954,
                                    false => 7955,
                                },
                                false => West switch {
                                    true => 7956,
                                    false => 7957,
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7894 => new MushroomStemBlock(Identifier, true, true, true, true, true, true),
            7895 => new MushroomStemBlock(Identifier, true, true, true, true, true, false),
            7896 => new MushroomStemBlock(Identifier, true, true, true, true, false, true),
            7897 => new MushroomStemBlock(Identifier, true, true, true, true, false, false),
            7898 => new MushroomStemBlock(Identifier, true, true, true, false, true, true),
            7899 => new MushroomStemBlock(Identifier, true, true, true, false, true, false),
            7900 => new MushroomStemBlock(Identifier, true, true, true, false, false, true),
            7901 => new MushroomStemBlock(Identifier, true, true, true, false, false, false),
            7902 => new MushroomStemBlock(Identifier, true, true, false, true, true, true),
            7903 => new MushroomStemBlock(Identifier, true, true, false, true, true, false),
            7904 => new MushroomStemBlock(Identifier, true, true, false, true, false, true),
            7905 => new MushroomStemBlock(Identifier, true, true, false, true, false, false),
            7906 => new MushroomStemBlock(Identifier, true, true, false, false, true, true),
            7907 => new MushroomStemBlock(Identifier, true, true, false, false, true, false),
            7908 => new MushroomStemBlock(Identifier, true, true, false, false, false, true),
            7909 => new MushroomStemBlock(Identifier, true, true, false, false, false, false),
            7910 => new MushroomStemBlock(Identifier, true, false, true, true, true, true),
            7911 => new MushroomStemBlock(Identifier, true, false, true, true, true, false),
            7912 => new MushroomStemBlock(Identifier, true, false, true, true, false, true),
            7913 => new MushroomStemBlock(Identifier, true, false, true, true, false, false),
            7914 => new MushroomStemBlock(Identifier, true, false, true, false, true, true),
            7915 => new MushroomStemBlock(Identifier, true, false, true, false, true, false),
            7916 => new MushroomStemBlock(Identifier, true, false, true, false, false, true),
            7917 => new MushroomStemBlock(Identifier, true, false, true, false, false, false),
            7918 => new MushroomStemBlock(Identifier, true, false, false, true, true, true),
            7919 => new MushroomStemBlock(Identifier, true, false, false, true, true, false),
            7920 => new MushroomStemBlock(Identifier, true, false, false, true, false, true),
            7921 => new MushroomStemBlock(Identifier, true, false, false, true, false, false),
            7922 => new MushroomStemBlock(Identifier, true, false, false, false, true, true),
            7923 => new MushroomStemBlock(Identifier, true, false, false, false, true, false),
            7924 => new MushroomStemBlock(Identifier, true, false, false, false, false, true),
            7925 => new MushroomStemBlock(Identifier, true, false, false, false, false, false),
            7926 => new MushroomStemBlock(Identifier, false, true, true, true, true, true),
            7927 => new MushroomStemBlock(Identifier, false, true, true, true, true, false),
            7928 => new MushroomStemBlock(Identifier, false, true, true, true, false, true),
            7929 => new MushroomStemBlock(Identifier, false, true, true, true, false, false),
            7930 => new MushroomStemBlock(Identifier, false, true, true, false, true, true),
            7931 => new MushroomStemBlock(Identifier, false, true, true, false, true, false),
            7932 => new MushroomStemBlock(Identifier, false, true, true, false, false, true),
            7933 => new MushroomStemBlock(Identifier, false, true, true, false, false, false),
            7934 => new MushroomStemBlock(Identifier, false, true, false, true, true, true),
            7935 => new MushroomStemBlock(Identifier, false, true, false, true, true, false),
            7936 => new MushroomStemBlock(Identifier, false, true, false, true, false, true),
            7937 => new MushroomStemBlock(Identifier, false, true, false, true, false, false),
            7938 => new MushroomStemBlock(Identifier, false, true, false, false, true, true),
            7939 => new MushroomStemBlock(Identifier, false, true, false, false, true, false),
            7940 => new MushroomStemBlock(Identifier, false, true, false, false, false, true),
            7941 => new MushroomStemBlock(Identifier, false, true, false, false, false, false),
            7942 => new MushroomStemBlock(Identifier, false, false, true, true, true, true),
            7943 => new MushroomStemBlock(Identifier, false, false, true, true, true, false),
            7944 => new MushroomStemBlock(Identifier, false, false, true, true, false, true),
            7945 => new MushroomStemBlock(Identifier, false, false, true, true, false, false),
            7946 => new MushroomStemBlock(Identifier, false, false, true, false, true, true),
            7947 => new MushroomStemBlock(Identifier, false, false, true, false, true, false),
            7948 => new MushroomStemBlock(Identifier, false, false, true, false, false, true),
            7949 => new MushroomStemBlock(Identifier, false, false, true, false, false, false),
            7950 => new MushroomStemBlock(Identifier, false, false, false, true, true, true),
            7951 => new MushroomStemBlock(Identifier, false, false, false, true, true, false),
            7952 => new MushroomStemBlock(Identifier, false, false, false, true, false, true),
            7953 => new MushroomStemBlock(Identifier, false, false, false, true, false, false),
            7954 => new MushroomStemBlock(Identifier, false, false, false, false, true, true),
            7955 => new MushroomStemBlock(Identifier, false, false, false, false, true, false),
            7956 => new MushroomStemBlock(Identifier, false, false, false, false, false, true),
            7957 => new MushroomStemBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.Contains("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("down", new StringTag(Down.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
