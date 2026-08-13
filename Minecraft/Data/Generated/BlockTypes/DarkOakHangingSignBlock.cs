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
public record DarkOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.dark_oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:dark_oak_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 26, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6291];

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
                        true => 6291,
                        false => 6292,
                    },
                    1 => Waterlogged switch {
                        true => 6293,
                        false => 6294,
                    },
                    2 => Waterlogged switch {
                        true => 6295,
                        false => 6296,
                    },
                    3 => Waterlogged switch {
                        true => 6297,
                        false => 6298,
                    },
                    4 => Waterlogged switch {
                        true => 6299,
                        false => 6300,
                    },
                    5 => Waterlogged switch {
                        true => 6301,
                        false => 6302,
                    },
                    6 => Waterlogged switch {
                        true => 6303,
                        false => 6304,
                    },
                    7 => Waterlogged switch {
                        true => 6305,
                        false => 6306,
                    },
                    8 => Waterlogged switch {
                        true => 6307,
                        false => 6308,
                    },
                    9 => Waterlogged switch {
                        true => 6309,
                        false => 6310,
                    },
                    10 => Waterlogged switch {
                        true => 6311,
                        false => 6312,
                    },
                    11 => Waterlogged switch {
                        true => 6313,
                        false => 6314,
                    },
                    12 => Waterlogged switch {
                        true => 6315,
                        false => 6316,
                    },
                    13 => Waterlogged switch {
                        true => 6317,
                        false => 6318,
                    },
                    14 => Waterlogged switch {
                        true => 6319,
                        false => 6320,
                    },
                    15 => Waterlogged switch {
                        true => 6321,
                        false => 6322,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6323,
                        false => 6324,
                    },
                    1 => Waterlogged switch {
                        true => 6325,
                        false => 6326,
                    },
                    2 => Waterlogged switch {
                        true => 6327,
                        false => 6328,
                    },
                    3 => Waterlogged switch {
                        true => 6329,
                        false => 6330,
                    },
                    4 => Waterlogged switch {
                        true => 6331,
                        false => 6332,
                    },
                    5 => Waterlogged switch {
                        true => 6333,
                        false => 6334,
                    },
                    6 => Waterlogged switch {
                        true => 6335,
                        false => 6336,
                    },
                    7 => Waterlogged switch {
                        true => 6337,
                        false => 6338,
                    },
                    8 => Waterlogged switch {
                        true => 6339,
                        false => 6340,
                    },
                    9 => Waterlogged switch {
                        true => 6341,
                        false => 6342,
                    },
                    10 => Waterlogged switch {
                        true => 6343,
                        false => 6344,
                    },
                    11 => Waterlogged switch {
                        true => 6345,
                        false => 6346,
                    },
                    12 => Waterlogged switch {
                        true => 6347,
                        false => 6348,
                    },
                    13 => Waterlogged switch {
                        true => 6349,
                        false => 6350,
                    },
                    14 => Waterlogged switch {
                        true => 6351,
                        false => 6352,
                    },
                    15 => Waterlogged switch {
                        true => 6353,
                        false => 6354,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6291 => new DarkOakHangingSignBlock(Identifier, true, 0, true),
            6292 => new DarkOakHangingSignBlock(Identifier, true, 0, false),
            6293 => new DarkOakHangingSignBlock(Identifier, true, 1, true),
            6294 => new DarkOakHangingSignBlock(Identifier, true, 1, false),
            6295 => new DarkOakHangingSignBlock(Identifier, true, 2, true),
            6296 => new DarkOakHangingSignBlock(Identifier, true, 2, false),
            6297 => new DarkOakHangingSignBlock(Identifier, true, 3, true),
            6298 => new DarkOakHangingSignBlock(Identifier, true, 3, false),
            6299 => new DarkOakHangingSignBlock(Identifier, true, 4, true),
            6300 => new DarkOakHangingSignBlock(Identifier, true, 4, false),
            6301 => new DarkOakHangingSignBlock(Identifier, true, 5, true),
            6302 => new DarkOakHangingSignBlock(Identifier, true, 5, false),
            6303 => new DarkOakHangingSignBlock(Identifier, true, 6, true),
            6304 => new DarkOakHangingSignBlock(Identifier, true, 6, false),
            6305 => new DarkOakHangingSignBlock(Identifier, true, 7, true),
            6306 => new DarkOakHangingSignBlock(Identifier, true, 7, false),
            6307 => new DarkOakHangingSignBlock(Identifier, true, 8, true),
            6308 => new DarkOakHangingSignBlock(Identifier, true, 8, false),
            6309 => new DarkOakHangingSignBlock(Identifier, true, 9, true),
            6310 => new DarkOakHangingSignBlock(Identifier, true, 9, false),
            6311 => new DarkOakHangingSignBlock(Identifier, true, 10, true),
            6312 => new DarkOakHangingSignBlock(Identifier, true, 10, false),
            6313 => new DarkOakHangingSignBlock(Identifier, true, 11, true),
            6314 => new DarkOakHangingSignBlock(Identifier, true, 11, false),
            6315 => new DarkOakHangingSignBlock(Identifier, true, 12, true),
            6316 => new DarkOakHangingSignBlock(Identifier, true, 12, false),
            6317 => new DarkOakHangingSignBlock(Identifier, true, 13, true),
            6318 => new DarkOakHangingSignBlock(Identifier, true, 13, false),
            6319 => new DarkOakHangingSignBlock(Identifier, true, 14, true),
            6320 => new DarkOakHangingSignBlock(Identifier, true, 14, false),
            6321 => new DarkOakHangingSignBlock(Identifier, true, 15, true),
            6322 => new DarkOakHangingSignBlock(Identifier, true, 15, false),
            6323 => new DarkOakHangingSignBlock(Identifier, false, 0, true),
            6324 => new DarkOakHangingSignBlock(Identifier, false, 0, false),
            6325 => new DarkOakHangingSignBlock(Identifier, false, 1, true),
            6326 => new DarkOakHangingSignBlock(Identifier, false, 1, false),
            6327 => new DarkOakHangingSignBlock(Identifier, false, 2, true),
            6328 => new DarkOakHangingSignBlock(Identifier, false, 2, false),
            6329 => new DarkOakHangingSignBlock(Identifier, false, 3, true),
            6330 => new DarkOakHangingSignBlock(Identifier, false, 3, false),
            6331 => new DarkOakHangingSignBlock(Identifier, false, 4, true),
            6332 => new DarkOakHangingSignBlock(Identifier, false, 4, false),
            6333 => new DarkOakHangingSignBlock(Identifier, false, 5, true),
            6334 => new DarkOakHangingSignBlock(Identifier, false, 5, false),
            6335 => new DarkOakHangingSignBlock(Identifier, false, 6, true),
            6336 => new DarkOakHangingSignBlock(Identifier, false, 6, false),
            6337 => new DarkOakHangingSignBlock(Identifier, false, 7, true),
            6338 => new DarkOakHangingSignBlock(Identifier, false, 7, false),
            6339 => new DarkOakHangingSignBlock(Identifier, false, 8, true),
            6340 => new DarkOakHangingSignBlock(Identifier, false, 8, false),
            6341 => new DarkOakHangingSignBlock(Identifier, false, 9, true),
            6342 => new DarkOakHangingSignBlock(Identifier, false, 9, false),
            6343 => new DarkOakHangingSignBlock(Identifier, false, 10, true),
            6344 => new DarkOakHangingSignBlock(Identifier, false, 10, false),
            6345 => new DarkOakHangingSignBlock(Identifier, false, 11, true),
            6346 => new DarkOakHangingSignBlock(Identifier, false, 11, false),
            6347 => new DarkOakHangingSignBlock(Identifier, false, 12, true),
            6348 => new DarkOakHangingSignBlock(Identifier, false, 12, false),
            6349 => new DarkOakHangingSignBlock(Identifier, false, 13, true),
            6350 => new DarkOakHangingSignBlock(Identifier, false, 13, false),
            6351 => new DarkOakHangingSignBlock(Identifier, false, 14, true),
            6352 => new DarkOakHangingSignBlock(Identifier, false, 14, false),
            6353 => new DarkOakHangingSignBlock(Identifier, false, 15, true),
            6354 => new DarkOakHangingSignBlock(Identifier, false, 15, false),
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
