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
public record PoplarHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:poplar_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 22, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8207];

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
                        true => 8207,
                        false => 8208,
                    },
                    1 => Waterlogged switch {
                        true => 8209,
                        false => 8210,
                    },
                    2 => Waterlogged switch {
                        true => 8211,
                        false => 8212,
                    },
                    3 => Waterlogged switch {
                        true => 8213,
                        false => 8214,
                    },
                    4 => Waterlogged switch {
                        true => 8215,
                        false => 8216,
                    },
                    5 => Waterlogged switch {
                        true => 8217,
                        false => 8218,
                    },
                    6 => Waterlogged switch {
                        true => 8219,
                        false => 8220,
                    },
                    7 => Waterlogged switch {
                        true => 8221,
                        false => 8222,
                    },
                    8 => Waterlogged switch {
                        true => 8223,
                        false => 8224,
                    },
                    9 => Waterlogged switch {
                        true => 8225,
                        false => 8226,
                    },
                    10 => Waterlogged switch {
                        true => 8227,
                        false => 8228,
                    },
                    11 => Waterlogged switch {
                        true => 8229,
                        false => 8230,
                    },
                    12 => Waterlogged switch {
                        true => 8231,
                        false => 8232,
                    },
                    13 => Waterlogged switch {
                        true => 8233,
                        false => 8234,
                    },
                    14 => Waterlogged switch {
                        true => 8235,
                        false => 8236,
                    },
                    15 => Waterlogged switch {
                        true => 8237,
                        false => 8238,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 8239,
                        false => 8240,
                    },
                    1 => Waterlogged switch {
                        true => 8241,
                        false => 8242,
                    },
                    2 => Waterlogged switch {
                        true => 8243,
                        false => 8244,
                    },
                    3 => Waterlogged switch {
                        true => 8245,
                        false => 8246,
                    },
                    4 => Waterlogged switch {
                        true => 8247,
                        false => 8248,
                    },
                    5 => Waterlogged switch {
                        true => 8249,
                        false => 8250,
                    },
                    6 => Waterlogged switch {
                        true => 8251,
                        false => 8252,
                    },
                    7 => Waterlogged switch {
                        true => 8253,
                        false => 8254,
                    },
                    8 => Waterlogged switch {
                        true => 8255,
                        false => 8256,
                    },
                    9 => Waterlogged switch {
                        true => 8257,
                        false => 8258,
                    },
                    10 => Waterlogged switch {
                        true => 8259,
                        false => 8260,
                    },
                    11 => Waterlogged switch {
                        true => 8261,
                        false => 8262,
                    },
                    12 => Waterlogged switch {
                        true => 8263,
                        false => 8264,
                    },
                    13 => Waterlogged switch {
                        true => 8265,
                        false => 8266,
                    },
                    14 => Waterlogged switch {
                        true => 8267,
                        false => 8268,
                    },
                    15 => Waterlogged switch {
                        true => 8269,
                        false => 8270,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8207 => new PoplarHangingSignBlock(Identifier, true, 0, true),
            8208 => new PoplarHangingSignBlock(Identifier, true, 0, false),
            8209 => new PoplarHangingSignBlock(Identifier, true, 1, true),
            8210 => new PoplarHangingSignBlock(Identifier, true, 1, false),
            8211 => new PoplarHangingSignBlock(Identifier, true, 2, true),
            8212 => new PoplarHangingSignBlock(Identifier, true, 2, false),
            8213 => new PoplarHangingSignBlock(Identifier, true, 3, true),
            8214 => new PoplarHangingSignBlock(Identifier, true, 3, false),
            8215 => new PoplarHangingSignBlock(Identifier, true, 4, true),
            8216 => new PoplarHangingSignBlock(Identifier, true, 4, false),
            8217 => new PoplarHangingSignBlock(Identifier, true, 5, true),
            8218 => new PoplarHangingSignBlock(Identifier, true, 5, false),
            8219 => new PoplarHangingSignBlock(Identifier, true, 6, true),
            8220 => new PoplarHangingSignBlock(Identifier, true, 6, false),
            8221 => new PoplarHangingSignBlock(Identifier, true, 7, true),
            8222 => new PoplarHangingSignBlock(Identifier, true, 7, false),
            8223 => new PoplarHangingSignBlock(Identifier, true, 8, true),
            8224 => new PoplarHangingSignBlock(Identifier, true, 8, false),
            8225 => new PoplarHangingSignBlock(Identifier, true, 9, true),
            8226 => new PoplarHangingSignBlock(Identifier, true, 9, false),
            8227 => new PoplarHangingSignBlock(Identifier, true, 10, true),
            8228 => new PoplarHangingSignBlock(Identifier, true, 10, false),
            8229 => new PoplarHangingSignBlock(Identifier, true, 11, true),
            8230 => new PoplarHangingSignBlock(Identifier, true, 11, false),
            8231 => new PoplarHangingSignBlock(Identifier, true, 12, true),
            8232 => new PoplarHangingSignBlock(Identifier, true, 12, false),
            8233 => new PoplarHangingSignBlock(Identifier, true, 13, true),
            8234 => new PoplarHangingSignBlock(Identifier, true, 13, false),
            8235 => new PoplarHangingSignBlock(Identifier, true, 14, true),
            8236 => new PoplarHangingSignBlock(Identifier, true, 14, false),
            8237 => new PoplarHangingSignBlock(Identifier, true, 15, true),
            8238 => new PoplarHangingSignBlock(Identifier, true, 15, false),
            8239 => new PoplarHangingSignBlock(Identifier, false, 0, true),
            8240 => new PoplarHangingSignBlock(Identifier, false, 0, false),
            8241 => new PoplarHangingSignBlock(Identifier, false, 1, true),
            8242 => new PoplarHangingSignBlock(Identifier, false, 1, false),
            8243 => new PoplarHangingSignBlock(Identifier, false, 2, true),
            8244 => new PoplarHangingSignBlock(Identifier, false, 2, false),
            8245 => new PoplarHangingSignBlock(Identifier, false, 3, true),
            8246 => new PoplarHangingSignBlock(Identifier, false, 3, false),
            8247 => new PoplarHangingSignBlock(Identifier, false, 4, true),
            8248 => new PoplarHangingSignBlock(Identifier, false, 4, false),
            8249 => new PoplarHangingSignBlock(Identifier, false, 5, true),
            8250 => new PoplarHangingSignBlock(Identifier, false, 5, false),
            8251 => new PoplarHangingSignBlock(Identifier, false, 6, true),
            8252 => new PoplarHangingSignBlock(Identifier, false, 6, false),
            8253 => new PoplarHangingSignBlock(Identifier, false, 7, true),
            8254 => new PoplarHangingSignBlock(Identifier, false, 7, false),
            8255 => new PoplarHangingSignBlock(Identifier, false, 8, true),
            8256 => new PoplarHangingSignBlock(Identifier, false, 8, false),
            8257 => new PoplarHangingSignBlock(Identifier, false, 9, true),
            8258 => new PoplarHangingSignBlock(Identifier, false, 9, false),
            8259 => new PoplarHangingSignBlock(Identifier, false, 10, true),
            8260 => new PoplarHangingSignBlock(Identifier, false, 10, false),
            8261 => new PoplarHangingSignBlock(Identifier, false, 11, true),
            8262 => new PoplarHangingSignBlock(Identifier, false, 11, false),
            8263 => new PoplarHangingSignBlock(Identifier, false, 12, true),
            8264 => new PoplarHangingSignBlock(Identifier, false, 12, false),
            8265 => new PoplarHangingSignBlock(Identifier, false, 13, true),
            8266 => new PoplarHangingSignBlock(Identifier, false, 13, false),
            8267 => new PoplarHangingSignBlock(Identifier, false, 14, true),
            8268 => new PoplarHangingSignBlock(Identifier, false, 14, false),
            8269 => new PoplarHangingSignBlock(Identifier, false, 15, true),
            8270 => new PoplarHangingSignBlock(Identifier, false, 15, false),
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
