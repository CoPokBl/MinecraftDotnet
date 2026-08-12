using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.jungle_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:jungle_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 10, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S74, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S76 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6227];

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
                        true => 6227,
                        false => 6228,
                    },
                    1 => Waterlogged switch {
                        true => 6229,
                        false => 6230,
                    },
                    2 => Waterlogged switch {
                        true => 6231,
                        false => 6232,
                    },
                    3 => Waterlogged switch {
                        true => 6233,
                        false => 6234,
                    },
                    4 => Waterlogged switch {
                        true => 6235,
                        false => 6236,
                    },
                    5 => Waterlogged switch {
                        true => 6237,
                        false => 6238,
                    },
                    6 => Waterlogged switch {
                        true => 6239,
                        false => 6240,
                    },
                    7 => Waterlogged switch {
                        true => 6241,
                        false => 6242,
                    },
                    8 => Waterlogged switch {
                        true => 6243,
                        false => 6244,
                    },
                    9 => Waterlogged switch {
                        true => 6245,
                        false => 6246,
                    },
                    10 => Waterlogged switch {
                        true => 6247,
                        false => 6248,
                    },
                    11 => Waterlogged switch {
                        true => 6249,
                        false => 6250,
                    },
                    12 => Waterlogged switch {
                        true => 6251,
                        false => 6252,
                    },
                    13 => Waterlogged switch {
                        true => 6253,
                        false => 6254,
                    },
                    14 => Waterlogged switch {
                        true => 6255,
                        false => 6256,
                    },
                    15 => Waterlogged switch {
                        true => 6257,
                        false => 6258,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6259,
                        false => 6260,
                    },
                    1 => Waterlogged switch {
                        true => 6261,
                        false => 6262,
                    },
                    2 => Waterlogged switch {
                        true => 6263,
                        false => 6264,
                    },
                    3 => Waterlogged switch {
                        true => 6265,
                        false => 6266,
                    },
                    4 => Waterlogged switch {
                        true => 6267,
                        false => 6268,
                    },
                    5 => Waterlogged switch {
                        true => 6269,
                        false => 6270,
                    },
                    6 => Waterlogged switch {
                        true => 6271,
                        false => 6272,
                    },
                    7 => Waterlogged switch {
                        true => 6273,
                        false => 6274,
                    },
                    8 => Waterlogged switch {
                        true => 6275,
                        false => 6276,
                    },
                    9 => Waterlogged switch {
                        true => 6277,
                        false => 6278,
                    },
                    10 => Waterlogged switch {
                        true => 6279,
                        false => 6280,
                    },
                    11 => Waterlogged switch {
                        true => 6281,
                        false => 6282,
                    },
                    12 => Waterlogged switch {
                        true => 6283,
                        false => 6284,
                    },
                    13 => Waterlogged switch {
                        true => 6285,
                        false => 6286,
                    },
                    14 => Waterlogged switch {
                        true => 6287,
                        false => 6288,
                    },
                    15 => Waterlogged switch {
                        true => 6289,
                        false => 6290,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6227 => new JungleHangingSignBlock(Identifier, true, 0, true),
            6228 => new JungleHangingSignBlock(Identifier, true, 0, false),
            6229 => new JungleHangingSignBlock(Identifier, true, 1, true),
            6230 => new JungleHangingSignBlock(Identifier, true, 1, false),
            6231 => new JungleHangingSignBlock(Identifier, true, 2, true),
            6232 => new JungleHangingSignBlock(Identifier, true, 2, false),
            6233 => new JungleHangingSignBlock(Identifier, true, 3, true),
            6234 => new JungleHangingSignBlock(Identifier, true, 3, false),
            6235 => new JungleHangingSignBlock(Identifier, true, 4, true),
            6236 => new JungleHangingSignBlock(Identifier, true, 4, false),
            6237 => new JungleHangingSignBlock(Identifier, true, 5, true),
            6238 => new JungleHangingSignBlock(Identifier, true, 5, false),
            6239 => new JungleHangingSignBlock(Identifier, true, 6, true),
            6240 => new JungleHangingSignBlock(Identifier, true, 6, false),
            6241 => new JungleHangingSignBlock(Identifier, true, 7, true),
            6242 => new JungleHangingSignBlock(Identifier, true, 7, false),
            6243 => new JungleHangingSignBlock(Identifier, true, 8, true),
            6244 => new JungleHangingSignBlock(Identifier, true, 8, false),
            6245 => new JungleHangingSignBlock(Identifier, true, 9, true),
            6246 => new JungleHangingSignBlock(Identifier, true, 9, false),
            6247 => new JungleHangingSignBlock(Identifier, true, 10, true),
            6248 => new JungleHangingSignBlock(Identifier, true, 10, false),
            6249 => new JungleHangingSignBlock(Identifier, true, 11, true),
            6250 => new JungleHangingSignBlock(Identifier, true, 11, false),
            6251 => new JungleHangingSignBlock(Identifier, true, 12, true),
            6252 => new JungleHangingSignBlock(Identifier, true, 12, false),
            6253 => new JungleHangingSignBlock(Identifier, true, 13, true),
            6254 => new JungleHangingSignBlock(Identifier, true, 13, false),
            6255 => new JungleHangingSignBlock(Identifier, true, 14, true),
            6256 => new JungleHangingSignBlock(Identifier, true, 14, false),
            6257 => new JungleHangingSignBlock(Identifier, true, 15, true),
            6258 => new JungleHangingSignBlock(Identifier, true, 15, false),
            6259 => new JungleHangingSignBlock(Identifier, false, 0, true),
            6260 => new JungleHangingSignBlock(Identifier, false, 0, false),
            6261 => new JungleHangingSignBlock(Identifier, false, 1, true),
            6262 => new JungleHangingSignBlock(Identifier, false, 1, false),
            6263 => new JungleHangingSignBlock(Identifier, false, 2, true),
            6264 => new JungleHangingSignBlock(Identifier, false, 2, false),
            6265 => new JungleHangingSignBlock(Identifier, false, 3, true),
            6266 => new JungleHangingSignBlock(Identifier, false, 3, false),
            6267 => new JungleHangingSignBlock(Identifier, false, 4, true),
            6268 => new JungleHangingSignBlock(Identifier, false, 4, false),
            6269 => new JungleHangingSignBlock(Identifier, false, 5, true),
            6270 => new JungleHangingSignBlock(Identifier, false, 5, false),
            6271 => new JungleHangingSignBlock(Identifier, false, 6, true),
            6272 => new JungleHangingSignBlock(Identifier, false, 6, false),
            6273 => new JungleHangingSignBlock(Identifier, false, 7, true),
            6274 => new JungleHangingSignBlock(Identifier, false, 7, false),
            6275 => new JungleHangingSignBlock(Identifier, false, 8, true),
            6276 => new JungleHangingSignBlock(Identifier, false, 8, false),
            6277 => new JungleHangingSignBlock(Identifier, false, 9, true),
            6278 => new JungleHangingSignBlock(Identifier, false, 9, false),
            6279 => new JungleHangingSignBlock(Identifier, false, 10, true),
            6280 => new JungleHangingSignBlock(Identifier, false, 10, false),
            6281 => new JungleHangingSignBlock(Identifier, false, 11, true),
            6282 => new JungleHangingSignBlock(Identifier, false, 11, false),
            6283 => new JungleHangingSignBlock(Identifier, false, 12, true),
            6284 => new JungleHangingSignBlock(Identifier, false, 12, false),
            6285 => new JungleHangingSignBlock(Identifier, false, 13, true),
            6286 => new JungleHangingSignBlock(Identifier, false, 13, false),
            6287 => new JungleHangingSignBlock(Identifier, false, 14, true),
            6288 => new JungleHangingSignBlock(Identifier, false, 14, false),
            6289 => new JungleHangingSignBlock(Identifier, false, 15, true),
            6290 => new JungleHangingSignBlock(Identifier, false, 15, false),
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
