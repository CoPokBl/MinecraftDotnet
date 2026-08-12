using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.birch_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:birch_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 2, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S74, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6035];

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
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6035,
                        false => 6036,
                    },
                    1 => Waterlogged switch {
                        true => 6037,
                        false => 6038,
                    },
                    2 => Waterlogged switch {
                        true => 6039,
                        false => 6040,
                    },
                    3 => Waterlogged switch {
                        true => 6041,
                        false => 6042,
                    },
                    4 => Waterlogged switch {
                        true => 6043,
                        false => 6044,
                    },
                    5 => Waterlogged switch {
                        true => 6045,
                        false => 6046,
                    },
                    6 => Waterlogged switch {
                        true => 6047,
                        false => 6048,
                    },
                    7 => Waterlogged switch {
                        true => 6049,
                        false => 6050,
                    },
                    8 => Waterlogged switch {
                        true => 6051,
                        false => 6052,
                    },
                    9 => Waterlogged switch {
                        true => 6053,
                        false => 6054,
                    },
                    10 => Waterlogged switch {
                        true => 6055,
                        false => 6056,
                    },
                    11 => Waterlogged switch {
                        true => 6057,
                        false => 6058,
                    },
                    12 => Waterlogged switch {
                        true => 6059,
                        false => 6060,
                    },
                    13 => Waterlogged switch {
                        true => 6061,
                        false => 6062,
                    },
                    14 => Waterlogged switch {
                        true => 6063,
                        false => 6064,
                    },
                    15 => Waterlogged switch {
                        true => 6065,
                        false => 6066,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6067,
                        false => 6068,
                    },
                    1 => Waterlogged switch {
                        true => 6069,
                        false => 6070,
                    },
                    2 => Waterlogged switch {
                        true => 6071,
                        false => 6072,
                    },
                    3 => Waterlogged switch {
                        true => 6073,
                        false => 6074,
                    },
                    4 => Waterlogged switch {
                        true => 6075,
                        false => 6076,
                    },
                    5 => Waterlogged switch {
                        true => 6077,
                        false => 6078,
                    },
                    6 => Waterlogged switch {
                        true => 6079,
                        false => 6080,
                    },
                    7 => Waterlogged switch {
                        true => 6081,
                        false => 6082,
                    },
                    8 => Waterlogged switch {
                        true => 6083,
                        false => 6084,
                    },
                    9 => Waterlogged switch {
                        true => 6085,
                        false => 6086,
                    },
                    10 => Waterlogged switch {
                        true => 6087,
                        false => 6088,
                    },
                    11 => Waterlogged switch {
                        true => 6089,
                        false => 6090,
                    },
                    12 => Waterlogged switch {
                        true => 6091,
                        false => 6092,
                    },
                    13 => Waterlogged switch {
                        true => 6093,
                        false => 6094,
                    },
                    14 => Waterlogged switch {
                        true => 6095,
                        false => 6096,
                    },
                    15 => Waterlogged switch {
                        true => 6097,
                        false => 6098,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6035 => new BirchHangingSignBlock(Identifier, true, 0, true),
            6036 => new BirchHangingSignBlock(Identifier, true, 0, false),
            6037 => new BirchHangingSignBlock(Identifier, true, 1, true),
            6038 => new BirchHangingSignBlock(Identifier, true, 1, false),
            6039 => new BirchHangingSignBlock(Identifier, true, 2, true),
            6040 => new BirchHangingSignBlock(Identifier, true, 2, false),
            6041 => new BirchHangingSignBlock(Identifier, true, 3, true),
            6042 => new BirchHangingSignBlock(Identifier, true, 3, false),
            6043 => new BirchHangingSignBlock(Identifier, true, 4, true),
            6044 => new BirchHangingSignBlock(Identifier, true, 4, false),
            6045 => new BirchHangingSignBlock(Identifier, true, 5, true),
            6046 => new BirchHangingSignBlock(Identifier, true, 5, false),
            6047 => new BirchHangingSignBlock(Identifier, true, 6, true),
            6048 => new BirchHangingSignBlock(Identifier, true, 6, false),
            6049 => new BirchHangingSignBlock(Identifier, true, 7, true),
            6050 => new BirchHangingSignBlock(Identifier, true, 7, false),
            6051 => new BirchHangingSignBlock(Identifier, true, 8, true),
            6052 => new BirchHangingSignBlock(Identifier, true, 8, false),
            6053 => new BirchHangingSignBlock(Identifier, true, 9, true),
            6054 => new BirchHangingSignBlock(Identifier, true, 9, false),
            6055 => new BirchHangingSignBlock(Identifier, true, 10, true),
            6056 => new BirchHangingSignBlock(Identifier, true, 10, false),
            6057 => new BirchHangingSignBlock(Identifier, true, 11, true),
            6058 => new BirchHangingSignBlock(Identifier, true, 11, false),
            6059 => new BirchHangingSignBlock(Identifier, true, 12, true),
            6060 => new BirchHangingSignBlock(Identifier, true, 12, false),
            6061 => new BirchHangingSignBlock(Identifier, true, 13, true),
            6062 => new BirchHangingSignBlock(Identifier, true, 13, false),
            6063 => new BirchHangingSignBlock(Identifier, true, 14, true),
            6064 => new BirchHangingSignBlock(Identifier, true, 14, false),
            6065 => new BirchHangingSignBlock(Identifier, true, 15, true),
            6066 => new BirchHangingSignBlock(Identifier, true, 15, false),
            6067 => new BirchHangingSignBlock(Identifier, false, 0, true),
            6068 => new BirchHangingSignBlock(Identifier, false, 0, false),
            6069 => new BirchHangingSignBlock(Identifier, false, 1, true),
            6070 => new BirchHangingSignBlock(Identifier, false, 1, false),
            6071 => new BirchHangingSignBlock(Identifier, false, 2, true),
            6072 => new BirchHangingSignBlock(Identifier, false, 2, false),
            6073 => new BirchHangingSignBlock(Identifier, false, 3, true),
            6074 => new BirchHangingSignBlock(Identifier, false, 3, false),
            6075 => new BirchHangingSignBlock(Identifier, false, 4, true),
            6076 => new BirchHangingSignBlock(Identifier, false, 4, false),
            6077 => new BirchHangingSignBlock(Identifier, false, 5, true),
            6078 => new BirchHangingSignBlock(Identifier, false, 5, false),
            6079 => new BirchHangingSignBlock(Identifier, false, 6, true),
            6080 => new BirchHangingSignBlock(Identifier, false, 6, false),
            6081 => new BirchHangingSignBlock(Identifier, false, 7, true),
            6082 => new BirchHangingSignBlock(Identifier, false, 7, false),
            6083 => new BirchHangingSignBlock(Identifier, false, 8, true),
            6084 => new BirchHangingSignBlock(Identifier, false, 8, false),
            6085 => new BirchHangingSignBlock(Identifier, false, 9, true),
            6086 => new BirchHangingSignBlock(Identifier, false, 9, false),
            6087 => new BirchHangingSignBlock(Identifier, false, 10, true),
            6088 => new BirchHangingSignBlock(Identifier, false, 10, false),
            6089 => new BirchHangingSignBlock(Identifier, false, 11, true),
            6090 => new BirchHangingSignBlock(Identifier, false, 11, false),
            6091 => new BirchHangingSignBlock(Identifier, false, 12, true),
            6092 => new BirchHangingSignBlock(Identifier, false, 12, false),
            6093 => new BirchHangingSignBlock(Identifier, false, 13, true),
            6094 => new BirchHangingSignBlock(Identifier, false, 13, false),
            6095 => new BirchHangingSignBlock(Identifier, false, 14, true),
            6096 => new BirchHangingSignBlock(Identifier, false, 14, false),
            6097 => new BirchHangingSignBlock(Identifier, false, 15, true),
            6098 => new BirchHangingSignBlock(Identifier, false, 15, false),
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
