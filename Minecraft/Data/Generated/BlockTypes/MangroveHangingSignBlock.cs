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
public record MangroveHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:mangrove_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 28, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8143];

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
                        true => 8143,
                        false => 8144,
                    },
                    1 => Waterlogged switch {
                        true => 8145,
                        false => 8146,
                    },
                    2 => Waterlogged switch {
                        true => 8147,
                        false => 8148,
                    },
                    3 => Waterlogged switch {
                        true => 8149,
                        false => 8150,
                    },
                    4 => Waterlogged switch {
                        true => 8151,
                        false => 8152,
                    },
                    5 => Waterlogged switch {
                        true => 8153,
                        false => 8154,
                    },
                    6 => Waterlogged switch {
                        true => 8155,
                        false => 8156,
                    },
                    7 => Waterlogged switch {
                        true => 8157,
                        false => 8158,
                    },
                    8 => Waterlogged switch {
                        true => 8159,
                        false => 8160,
                    },
                    9 => Waterlogged switch {
                        true => 8161,
                        false => 8162,
                    },
                    10 => Waterlogged switch {
                        true => 8163,
                        false => 8164,
                    },
                    11 => Waterlogged switch {
                        true => 8165,
                        false => 8166,
                    },
                    12 => Waterlogged switch {
                        true => 8167,
                        false => 8168,
                    },
                    13 => Waterlogged switch {
                        true => 8169,
                        false => 8170,
                    },
                    14 => Waterlogged switch {
                        true => 8171,
                        false => 8172,
                    },
                    15 => Waterlogged switch {
                        true => 8173,
                        false => 8174,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 8175,
                        false => 8176,
                    },
                    1 => Waterlogged switch {
                        true => 8177,
                        false => 8178,
                    },
                    2 => Waterlogged switch {
                        true => 8179,
                        false => 8180,
                    },
                    3 => Waterlogged switch {
                        true => 8181,
                        false => 8182,
                    },
                    4 => Waterlogged switch {
                        true => 8183,
                        false => 8184,
                    },
                    5 => Waterlogged switch {
                        true => 8185,
                        false => 8186,
                    },
                    6 => Waterlogged switch {
                        true => 8187,
                        false => 8188,
                    },
                    7 => Waterlogged switch {
                        true => 8189,
                        false => 8190,
                    },
                    8 => Waterlogged switch {
                        true => 8191,
                        false => 8192,
                    },
                    9 => Waterlogged switch {
                        true => 8193,
                        false => 8194,
                    },
                    10 => Waterlogged switch {
                        true => 8195,
                        false => 8196,
                    },
                    11 => Waterlogged switch {
                        true => 8197,
                        false => 8198,
                    },
                    12 => Waterlogged switch {
                        true => 8199,
                        false => 8200,
                    },
                    13 => Waterlogged switch {
                        true => 8201,
                        false => 8202,
                    },
                    14 => Waterlogged switch {
                        true => 8203,
                        false => 8204,
                    },
                    15 => Waterlogged switch {
                        true => 8205,
                        false => 8206,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8143 => new MangroveHangingSignBlock(Identifier, true, 0, true),
            8144 => new MangroveHangingSignBlock(Identifier, true, 0, false),
            8145 => new MangroveHangingSignBlock(Identifier, true, 1, true),
            8146 => new MangroveHangingSignBlock(Identifier, true, 1, false),
            8147 => new MangroveHangingSignBlock(Identifier, true, 2, true),
            8148 => new MangroveHangingSignBlock(Identifier, true, 2, false),
            8149 => new MangroveHangingSignBlock(Identifier, true, 3, true),
            8150 => new MangroveHangingSignBlock(Identifier, true, 3, false),
            8151 => new MangroveHangingSignBlock(Identifier, true, 4, true),
            8152 => new MangroveHangingSignBlock(Identifier, true, 4, false),
            8153 => new MangroveHangingSignBlock(Identifier, true, 5, true),
            8154 => new MangroveHangingSignBlock(Identifier, true, 5, false),
            8155 => new MangroveHangingSignBlock(Identifier, true, 6, true),
            8156 => new MangroveHangingSignBlock(Identifier, true, 6, false),
            8157 => new MangroveHangingSignBlock(Identifier, true, 7, true),
            8158 => new MangroveHangingSignBlock(Identifier, true, 7, false),
            8159 => new MangroveHangingSignBlock(Identifier, true, 8, true),
            8160 => new MangroveHangingSignBlock(Identifier, true, 8, false),
            8161 => new MangroveHangingSignBlock(Identifier, true, 9, true),
            8162 => new MangroveHangingSignBlock(Identifier, true, 9, false),
            8163 => new MangroveHangingSignBlock(Identifier, true, 10, true),
            8164 => new MangroveHangingSignBlock(Identifier, true, 10, false),
            8165 => new MangroveHangingSignBlock(Identifier, true, 11, true),
            8166 => new MangroveHangingSignBlock(Identifier, true, 11, false),
            8167 => new MangroveHangingSignBlock(Identifier, true, 12, true),
            8168 => new MangroveHangingSignBlock(Identifier, true, 12, false),
            8169 => new MangroveHangingSignBlock(Identifier, true, 13, true),
            8170 => new MangroveHangingSignBlock(Identifier, true, 13, false),
            8171 => new MangroveHangingSignBlock(Identifier, true, 14, true),
            8172 => new MangroveHangingSignBlock(Identifier, true, 14, false),
            8173 => new MangroveHangingSignBlock(Identifier, true, 15, true),
            8174 => new MangroveHangingSignBlock(Identifier, true, 15, false),
            8175 => new MangroveHangingSignBlock(Identifier, false, 0, true),
            8176 => new MangroveHangingSignBlock(Identifier, false, 0, false),
            8177 => new MangroveHangingSignBlock(Identifier, false, 1, true),
            8178 => new MangroveHangingSignBlock(Identifier, false, 1, false),
            8179 => new MangroveHangingSignBlock(Identifier, false, 2, true),
            8180 => new MangroveHangingSignBlock(Identifier, false, 2, false),
            8181 => new MangroveHangingSignBlock(Identifier, false, 3, true),
            8182 => new MangroveHangingSignBlock(Identifier, false, 3, false),
            8183 => new MangroveHangingSignBlock(Identifier, false, 4, true),
            8184 => new MangroveHangingSignBlock(Identifier, false, 4, false),
            8185 => new MangroveHangingSignBlock(Identifier, false, 5, true),
            8186 => new MangroveHangingSignBlock(Identifier, false, 5, false),
            8187 => new MangroveHangingSignBlock(Identifier, false, 6, true),
            8188 => new MangroveHangingSignBlock(Identifier, false, 6, false),
            8189 => new MangroveHangingSignBlock(Identifier, false, 7, true),
            8190 => new MangroveHangingSignBlock(Identifier, false, 7, false),
            8191 => new MangroveHangingSignBlock(Identifier, false, 8, true),
            8192 => new MangroveHangingSignBlock(Identifier, false, 8, false),
            8193 => new MangroveHangingSignBlock(Identifier, false, 9, true),
            8194 => new MangroveHangingSignBlock(Identifier, false, 9, false),
            8195 => new MangroveHangingSignBlock(Identifier, false, 10, true),
            8196 => new MangroveHangingSignBlock(Identifier, false, 10, false),
            8197 => new MangroveHangingSignBlock(Identifier, false, 11, true),
            8198 => new MangroveHangingSignBlock(Identifier, false, 11, false),
            8199 => new MangroveHangingSignBlock(Identifier, false, 12, true),
            8200 => new MangroveHangingSignBlock(Identifier, false, 12, false),
            8201 => new MangroveHangingSignBlock(Identifier, false, 13, true),
            8202 => new MangroveHangingSignBlock(Identifier, false, 13, false),
            8203 => new MangroveHangingSignBlock(Identifier, false, 14, true),
            8204 => new MangroveHangingSignBlock(Identifier, false, 14, false),
            8205 => new MangroveHangingSignBlock(Identifier, false, 15, true),
            8206 => new MangroveHangingSignBlock(Identifier, false, 15, false),
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
