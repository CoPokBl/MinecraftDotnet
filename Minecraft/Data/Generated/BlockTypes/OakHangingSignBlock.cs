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
public record OakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:oak_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 13, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 5907];

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

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5907,
                        false => 5908,
                    },
                    1 => Waterlogged switch {
                        true => 5909,
                        false => 5910,
                    },
                    2 => Waterlogged switch {
                        true => 5911,
                        false => 5912,
                    },
                    3 => Waterlogged switch {
                        true => 5913,
                        false => 5914,
                    },
                    4 => Waterlogged switch {
                        true => 5915,
                        false => 5916,
                    },
                    5 => Waterlogged switch {
                        true => 5917,
                        false => 5918,
                    },
                    6 => Waterlogged switch {
                        true => 5919,
                        false => 5920,
                    },
                    7 => Waterlogged switch {
                        true => 5921,
                        false => 5922,
                    },
                    8 => Waterlogged switch {
                        true => 5923,
                        false => 5924,
                    },
                    9 => Waterlogged switch {
                        true => 5925,
                        false => 5926,
                    },
                    10 => Waterlogged switch {
                        true => 5927,
                        false => 5928,
                    },
                    11 => Waterlogged switch {
                        true => 5929,
                        false => 5930,
                    },
                    12 => Waterlogged switch {
                        true => 5931,
                        false => 5932,
                    },
                    13 => Waterlogged switch {
                        true => 5933,
                        false => 5934,
                    },
                    14 => Waterlogged switch {
                        true => 5935,
                        false => 5936,
                    },
                    15 => Waterlogged switch {
                        true => 5937,
                        false => 5938,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5939,
                        false => 5940,
                    },
                    1 => Waterlogged switch {
                        true => 5941,
                        false => 5942,
                    },
                    2 => Waterlogged switch {
                        true => 5943,
                        false => 5944,
                    },
                    3 => Waterlogged switch {
                        true => 5945,
                        false => 5946,
                    },
                    4 => Waterlogged switch {
                        true => 5947,
                        false => 5948,
                    },
                    5 => Waterlogged switch {
                        true => 5949,
                        false => 5950,
                    },
                    6 => Waterlogged switch {
                        true => 5951,
                        false => 5952,
                    },
                    7 => Waterlogged switch {
                        true => 5953,
                        false => 5954,
                    },
                    8 => Waterlogged switch {
                        true => 5955,
                        false => 5956,
                    },
                    9 => Waterlogged switch {
                        true => 5957,
                        false => 5958,
                    },
                    10 => Waterlogged switch {
                        true => 5959,
                        false => 5960,
                    },
                    11 => Waterlogged switch {
                        true => 5961,
                        false => 5962,
                    },
                    12 => Waterlogged switch {
                        true => 5963,
                        false => 5964,
                    },
                    13 => Waterlogged switch {
                        true => 5965,
                        false => 5966,
                    },
                    14 => Waterlogged switch {
                        true => 5967,
                        false => 5968,
                    },
                    15 => Waterlogged switch {
                        true => 5969,
                        false => 5970,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5907 => new OakHangingSignBlock(Identifier, true, 0, true),
            5908 => new OakHangingSignBlock(Identifier, true, 0, false),
            5909 => new OakHangingSignBlock(Identifier, true, 1, true),
            5910 => new OakHangingSignBlock(Identifier, true, 1, false),
            5911 => new OakHangingSignBlock(Identifier, true, 2, true),
            5912 => new OakHangingSignBlock(Identifier, true, 2, false),
            5913 => new OakHangingSignBlock(Identifier, true, 3, true),
            5914 => new OakHangingSignBlock(Identifier, true, 3, false),
            5915 => new OakHangingSignBlock(Identifier, true, 4, true),
            5916 => new OakHangingSignBlock(Identifier, true, 4, false),
            5917 => new OakHangingSignBlock(Identifier, true, 5, true),
            5918 => new OakHangingSignBlock(Identifier, true, 5, false),
            5919 => new OakHangingSignBlock(Identifier, true, 6, true),
            5920 => new OakHangingSignBlock(Identifier, true, 6, false),
            5921 => new OakHangingSignBlock(Identifier, true, 7, true),
            5922 => new OakHangingSignBlock(Identifier, true, 7, false),
            5923 => new OakHangingSignBlock(Identifier, true, 8, true),
            5924 => new OakHangingSignBlock(Identifier, true, 8, false),
            5925 => new OakHangingSignBlock(Identifier, true, 9, true),
            5926 => new OakHangingSignBlock(Identifier, true, 9, false),
            5927 => new OakHangingSignBlock(Identifier, true, 10, true),
            5928 => new OakHangingSignBlock(Identifier, true, 10, false),
            5929 => new OakHangingSignBlock(Identifier, true, 11, true),
            5930 => new OakHangingSignBlock(Identifier, true, 11, false),
            5931 => new OakHangingSignBlock(Identifier, true, 12, true),
            5932 => new OakHangingSignBlock(Identifier, true, 12, false),
            5933 => new OakHangingSignBlock(Identifier, true, 13, true),
            5934 => new OakHangingSignBlock(Identifier, true, 13, false),
            5935 => new OakHangingSignBlock(Identifier, true, 14, true),
            5936 => new OakHangingSignBlock(Identifier, true, 14, false),
            5937 => new OakHangingSignBlock(Identifier, true, 15, true),
            5938 => new OakHangingSignBlock(Identifier, true, 15, false),
            5939 => new OakHangingSignBlock(Identifier, false, 0, true),
            5940 => new OakHangingSignBlock(Identifier, false, 0, false),
            5941 => new OakHangingSignBlock(Identifier, false, 1, true),
            5942 => new OakHangingSignBlock(Identifier, false, 1, false),
            5943 => new OakHangingSignBlock(Identifier, false, 2, true),
            5944 => new OakHangingSignBlock(Identifier, false, 2, false),
            5945 => new OakHangingSignBlock(Identifier, false, 3, true),
            5946 => new OakHangingSignBlock(Identifier, false, 3, false),
            5947 => new OakHangingSignBlock(Identifier, false, 4, true),
            5948 => new OakHangingSignBlock(Identifier, false, 4, false),
            5949 => new OakHangingSignBlock(Identifier, false, 5, true),
            5950 => new OakHangingSignBlock(Identifier, false, 5, false),
            5951 => new OakHangingSignBlock(Identifier, false, 6, true),
            5952 => new OakHangingSignBlock(Identifier, false, 6, false),
            5953 => new OakHangingSignBlock(Identifier, false, 7, true),
            5954 => new OakHangingSignBlock(Identifier, false, 7, false),
            5955 => new OakHangingSignBlock(Identifier, false, 8, true),
            5956 => new OakHangingSignBlock(Identifier, false, 8, false),
            5957 => new OakHangingSignBlock(Identifier, false, 9, true),
            5958 => new OakHangingSignBlock(Identifier, false, 9, false),
            5959 => new OakHangingSignBlock(Identifier, false, 10, true),
            5960 => new OakHangingSignBlock(Identifier, false, 10, false),
            5961 => new OakHangingSignBlock(Identifier, false, 11, true),
            5962 => new OakHangingSignBlock(Identifier, false, 11, false),
            5963 => new OakHangingSignBlock(Identifier, false, 12, true),
            5964 => new OakHangingSignBlock(Identifier, false, 12, false),
            5965 => new OakHangingSignBlock(Identifier, false, 13, true),
            5966 => new OakHangingSignBlock(Identifier, false, 13, false),
            5967 => new OakHangingSignBlock(Identifier, false, 14, true),
            5968 => new OakHangingSignBlock(Identifier, false, 14, false),
            5969 => new OakHangingSignBlock(Identifier, false, 15, true),
            5970 => new OakHangingSignBlock(Identifier, false, 15, false),
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
