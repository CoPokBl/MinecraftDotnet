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
public record DarkOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:dark_oak_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 26, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7887];

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7887,
                        false => 7888,
                    },
                    1 => Waterlogged switch {
                        true => 7889,
                        false => 7890,
                    },
                    2 => Waterlogged switch {
                        true => 7891,
                        false => 7892,
                    },
                    3 => Waterlogged switch {
                        true => 7893,
                        false => 7894,
                    },
                    4 => Waterlogged switch {
                        true => 7895,
                        false => 7896,
                    },
                    5 => Waterlogged switch {
                        true => 7897,
                        false => 7898,
                    },
                    6 => Waterlogged switch {
                        true => 7899,
                        false => 7900,
                    },
                    7 => Waterlogged switch {
                        true => 7901,
                        false => 7902,
                    },
                    8 => Waterlogged switch {
                        true => 7903,
                        false => 7904,
                    },
                    9 => Waterlogged switch {
                        true => 7905,
                        false => 7906,
                    },
                    10 => Waterlogged switch {
                        true => 7907,
                        false => 7908,
                    },
                    11 => Waterlogged switch {
                        true => 7909,
                        false => 7910,
                    },
                    12 => Waterlogged switch {
                        true => 7911,
                        false => 7912,
                    },
                    13 => Waterlogged switch {
                        true => 7913,
                        false => 7914,
                    },
                    14 => Waterlogged switch {
                        true => 7915,
                        false => 7916,
                    },
                    15 => Waterlogged switch {
                        true => 7917,
                        false => 7918,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7919,
                        false => 7920,
                    },
                    1 => Waterlogged switch {
                        true => 7921,
                        false => 7922,
                    },
                    2 => Waterlogged switch {
                        true => 7923,
                        false => 7924,
                    },
                    3 => Waterlogged switch {
                        true => 7925,
                        false => 7926,
                    },
                    4 => Waterlogged switch {
                        true => 7927,
                        false => 7928,
                    },
                    5 => Waterlogged switch {
                        true => 7929,
                        false => 7930,
                    },
                    6 => Waterlogged switch {
                        true => 7931,
                        false => 7932,
                    },
                    7 => Waterlogged switch {
                        true => 7933,
                        false => 7934,
                    },
                    8 => Waterlogged switch {
                        true => 7935,
                        false => 7936,
                    },
                    9 => Waterlogged switch {
                        true => 7937,
                        false => 7938,
                    },
                    10 => Waterlogged switch {
                        true => 7939,
                        false => 7940,
                    },
                    11 => Waterlogged switch {
                        true => 7941,
                        false => 7942,
                    },
                    12 => Waterlogged switch {
                        true => 7943,
                        false => 7944,
                    },
                    13 => Waterlogged switch {
                        true => 7945,
                        false => 7946,
                    },
                    14 => Waterlogged switch {
                        true => 7947,
                        false => 7948,
                    },
                    15 => Waterlogged switch {
                        true => 7949,
                        false => 7950,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7887 => new DarkOakHangingSignBlock(Identifier, true, 0, true),
            7888 => new DarkOakHangingSignBlock(Identifier, true, 0, false),
            7889 => new DarkOakHangingSignBlock(Identifier, true, 1, true),
            7890 => new DarkOakHangingSignBlock(Identifier, true, 1, false),
            7891 => new DarkOakHangingSignBlock(Identifier, true, 2, true),
            7892 => new DarkOakHangingSignBlock(Identifier, true, 2, false),
            7893 => new DarkOakHangingSignBlock(Identifier, true, 3, true),
            7894 => new DarkOakHangingSignBlock(Identifier, true, 3, false),
            7895 => new DarkOakHangingSignBlock(Identifier, true, 4, true),
            7896 => new DarkOakHangingSignBlock(Identifier, true, 4, false),
            7897 => new DarkOakHangingSignBlock(Identifier, true, 5, true),
            7898 => new DarkOakHangingSignBlock(Identifier, true, 5, false),
            7899 => new DarkOakHangingSignBlock(Identifier, true, 6, true),
            7900 => new DarkOakHangingSignBlock(Identifier, true, 6, false),
            7901 => new DarkOakHangingSignBlock(Identifier, true, 7, true),
            7902 => new DarkOakHangingSignBlock(Identifier, true, 7, false),
            7903 => new DarkOakHangingSignBlock(Identifier, true, 8, true),
            7904 => new DarkOakHangingSignBlock(Identifier, true, 8, false),
            7905 => new DarkOakHangingSignBlock(Identifier, true, 9, true),
            7906 => new DarkOakHangingSignBlock(Identifier, true, 9, false),
            7907 => new DarkOakHangingSignBlock(Identifier, true, 10, true),
            7908 => new DarkOakHangingSignBlock(Identifier, true, 10, false),
            7909 => new DarkOakHangingSignBlock(Identifier, true, 11, true),
            7910 => new DarkOakHangingSignBlock(Identifier, true, 11, false),
            7911 => new DarkOakHangingSignBlock(Identifier, true, 12, true),
            7912 => new DarkOakHangingSignBlock(Identifier, true, 12, false),
            7913 => new DarkOakHangingSignBlock(Identifier, true, 13, true),
            7914 => new DarkOakHangingSignBlock(Identifier, true, 13, false),
            7915 => new DarkOakHangingSignBlock(Identifier, true, 14, true),
            7916 => new DarkOakHangingSignBlock(Identifier, true, 14, false),
            7917 => new DarkOakHangingSignBlock(Identifier, true, 15, true),
            7918 => new DarkOakHangingSignBlock(Identifier, true, 15, false),
            7919 => new DarkOakHangingSignBlock(Identifier, false, 0, true),
            7920 => new DarkOakHangingSignBlock(Identifier, false, 0, false),
            7921 => new DarkOakHangingSignBlock(Identifier, false, 1, true),
            7922 => new DarkOakHangingSignBlock(Identifier, false, 1, false),
            7923 => new DarkOakHangingSignBlock(Identifier, false, 2, true),
            7924 => new DarkOakHangingSignBlock(Identifier, false, 2, false),
            7925 => new DarkOakHangingSignBlock(Identifier, false, 3, true),
            7926 => new DarkOakHangingSignBlock(Identifier, false, 3, false),
            7927 => new DarkOakHangingSignBlock(Identifier, false, 4, true),
            7928 => new DarkOakHangingSignBlock(Identifier, false, 4, false),
            7929 => new DarkOakHangingSignBlock(Identifier, false, 5, true),
            7930 => new DarkOakHangingSignBlock(Identifier, false, 5, false),
            7931 => new DarkOakHangingSignBlock(Identifier, false, 6, true),
            7932 => new DarkOakHangingSignBlock(Identifier, false, 6, false),
            7933 => new DarkOakHangingSignBlock(Identifier, false, 7, true),
            7934 => new DarkOakHangingSignBlock(Identifier, false, 7, false),
            7935 => new DarkOakHangingSignBlock(Identifier, false, 8, true),
            7936 => new DarkOakHangingSignBlock(Identifier, false, 8, false),
            7937 => new DarkOakHangingSignBlock(Identifier, false, 9, true),
            7938 => new DarkOakHangingSignBlock(Identifier, false, 9, false),
            7939 => new DarkOakHangingSignBlock(Identifier, false, 10, true),
            7940 => new DarkOakHangingSignBlock(Identifier, false, 10, false),
            7941 => new DarkOakHangingSignBlock(Identifier, false, 11, true),
            7942 => new DarkOakHangingSignBlock(Identifier, false, 11, false),
            7943 => new DarkOakHangingSignBlock(Identifier, false, 12, true),
            7944 => new DarkOakHangingSignBlock(Identifier, false, 12, false),
            7945 => new DarkOakHangingSignBlock(Identifier, false, 13, true),
            7946 => new DarkOakHangingSignBlock(Identifier, false, 13, false),
            7947 => new DarkOakHangingSignBlock(Identifier, false, 14, true),
            7948 => new DarkOakHangingSignBlock(Identifier, false, 14, false),
            7949 => new DarkOakHangingSignBlock(Identifier, false, 15, true),
            7950 => new DarkOakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
