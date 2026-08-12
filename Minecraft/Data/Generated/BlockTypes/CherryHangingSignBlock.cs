using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.cherry_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:cherry_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 42, "cherry_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S74, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6163];

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
                        true => 6163,
                        false => 6164,
                    },
                    1 => Waterlogged switch {
                        true => 6165,
                        false => 6166,
                    },
                    2 => Waterlogged switch {
                        true => 6167,
                        false => 6168,
                    },
                    3 => Waterlogged switch {
                        true => 6169,
                        false => 6170,
                    },
                    4 => Waterlogged switch {
                        true => 6171,
                        false => 6172,
                    },
                    5 => Waterlogged switch {
                        true => 6173,
                        false => 6174,
                    },
                    6 => Waterlogged switch {
                        true => 6175,
                        false => 6176,
                    },
                    7 => Waterlogged switch {
                        true => 6177,
                        false => 6178,
                    },
                    8 => Waterlogged switch {
                        true => 6179,
                        false => 6180,
                    },
                    9 => Waterlogged switch {
                        true => 6181,
                        false => 6182,
                    },
                    10 => Waterlogged switch {
                        true => 6183,
                        false => 6184,
                    },
                    11 => Waterlogged switch {
                        true => 6185,
                        false => 6186,
                    },
                    12 => Waterlogged switch {
                        true => 6187,
                        false => 6188,
                    },
                    13 => Waterlogged switch {
                        true => 6189,
                        false => 6190,
                    },
                    14 => Waterlogged switch {
                        true => 6191,
                        false => 6192,
                    },
                    15 => Waterlogged switch {
                        true => 6193,
                        false => 6194,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6195,
                        false => 6196,
                    },
                    1 => Waterlogged switch {
                        true => 6197,
                        false => 6198,
                    },
                    2 => Waterlogged switch {
                        true => 6199,
                        false => 6200,
                    },
                    3 => Waterlogged switch {
                        true => 6201,
                        false => 6202,
                    },
                    4 => Waterlogged switch {
                        true => 6203,
                        false => 6204,
                    },
                    5 => Waterlogged switch {
                        true => 6205,
                        false => 6206,
                    },
                    6 => Waterlogged switch {
                        true => 6207,
                        false => 6208,
                    },
                    7 => Waterlogged switch {
                        true => 6209,
                        false => 6210,
                    },
                    8 => Waterlogged switch {
                        true => 6211,
                        false => 6212,
                    },
                    9 => Waterlogged switch {
                        true => 6213,
                        false => 6214,
                    },
                    10 => Waterlogged switch {
                        true => 6215,
                        false => 6216,
                    },
                    11 => Waterlogged switch {
                        true => 6217,
                        false => 6218,
                    },
                    12 => Waterlogged switch {
                        true => 6219,
                        false => 6220,
                    },
                    13 => Waterlogged switch {
                        true => 6221,
                        false => 6222,
                    },
                    14 => Waterlogged switch {
                        true => 6223,
                        false => 6224,
                    },
                    15 => Waterlogged switch {
                        true => 6225,
                        false => 6226,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6163 => new CherryHangingSignBlock(Identifier, true, 0, true),
            6164 => new CherryHangingSignBlock(Identifier, true, 0, false),
            6165 => new CherryHangingSignBlock(Identifier, true, 1, true),
            6166 => new CherryHangingSignBlock(Identifier, true, 1, false),
            6167 => new CherryHangingSignBlock(Identifier, true, 2, true),
            6168 => new CherryHangingSignBlock(Identifier, true, 2, false),
            6169 => new CherryHangingSignBlock(Identifier, true, 3, true),
            6170 => new CherryHangingSignBlock(Identifier, true, 3, false),
            6171 => new CherryHangingSignBlock(Identifier, true, 4, true),
            6172 => new CherryHangingSignBlock(Identifier, true, 4, false),
            6173 => new CherryHangingSignBlock(Identifier, true, 5, true),
            6174 => new CherryHangingSignBlock(Identifier, true, 5, false),
            6175 => new CherryHangingSignBlock(Identifier, true, 6, true),
            6176 => new CherryHangingSignBlock(Identifier, true, 6, false),
            6177 => new CherryHangingSignBlock(Identifier, true, 7, true),
            6178 => new CherryHangingSignBlock(Identifier, true, 7, false),
            6179 => new CherryHangingSignBlock(Identifier, true, 8, true),
            6180 => new CherryHangingSignBlock(Identifier, true, 8, false),
            6181 => new CherryHangingSignBlock(Identifier, true, 9, true),
            6182 => new CherryHangingSignBlock(Identifier, true, 9, false),
            6183 => new CherryHangingSignBlock(Identifier, true, 10, true),
            6184 => new CherryHangingSignBlock(Identifier, true, 10, false),
            6185 => new CherryHangingSignBlock(Identifier, true, 11, true),
            6186 => new CherryHangingSignBlock(Identifier, true, 11, false),
            6187 => new CherryHangingSignBlock(Identifier, true, 12, true),
            6188 => new CherryHangingSignBlock(Identifier, true, 12, false),
            6189 => new CherryHangingSignBlock(Identifier, true, 13, true),
            6190 => new CherryHangingSignBlock(Identifier, true, 13, false),
            6191 => new CherryHangingSignBlock(Identifier, true, 14, true),
            6192 => new CherryHangingSignBlock(Identifier, true, 14, false),
            6193 => new CherryHangingSignBlock(Identifier, true, 15, true),
            6194 => new CherryHangingSignBlock(Identifier, true, 15, false),
            6195 => new CherryHangingSignBlock(Identifier, false, 0, true),
            6196 => new CherryHangingSignBlock(Identifier, false, 0, false),
            6197 => new CherryHangingSignBlock(Identifier, false, 1, true),
            6198 => new CherryHangingSignBlock(Identifier, false, 1, false),
            6199 => new CherryHangingSignBlock(Identifier, false, 2, true),
            6200 => new CherryHangingSignBlock(Identifier, false, 2, false),
            6201 => new CherryHangingSignBlock(Identifier, false, 3, true),
            6202 => new CherryHangingSignBlock(Identifier, false, 3, false),
            6203 => new CherryHangingSignBlock(Identifier, false, 4, true),
            6204 => new CherryHangingSignBlock(Identifier, false, 4, false),
            6205 => new CherryHangingSignBlock(Identifier, false, 5, true),
            6206 => new CherryHangingSignBlock(Identifier, false, 5, false),
            6207 => new CherryHangingSignBlock(Identifier, false, 6, true),
            6208 => new CherryHangingSignBlock(Identifier, false, 6, false),
            6209 => new CherryHangingSignBlock(Identifier, false, 7, true),
            6210 => new CherryHangingSignBlock(Identifier, false, 7, false),
            6211 => new CherryHangingSignBlock(Identifier, false, 8, true),
            6212 => new CherryHangingSignBlock(Identifier, false, 8, false),
            6213 => new CherryHangingSignBlock(Identifier, false, 9, true),
            6214 => new CherryHangingSignBlock(Identifier, false, 9, false),
            6215 => new CherryHangingSignBlock(Identifier, false, 10, true),
            6216 => new CherryHangingSignBlock(Identifier, false, 10, false),
            6217 => new CherryHangingSignBlock(Identifier, false, 11, true),
            6218 => new CherryHangingSignBlock(Identifier, false, 11, false),
            6219 => new CherryHangingSignBlock(Identifier, false, 12, true),
            6220 => new CherryHangingSignBlock(Identifier, false, 12, false),
            6221 => new CherryHangingSignBlock(Identifier, false, 13, true),
            6222 => new CherryHangingSignBlock(Identifier, false, 13, false),
            6223 => new CherryHangingSignBlock(Identifier, false, 14, true),
            6224 => new CherryHangingSignBlock(Identifier, false, 14, false),
            6225 => new CherryHangingSignBlock(Identifier, false, 15, true),
            6226 => new CherryHangingSignBlock(Identifier, false, 15, false),
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
