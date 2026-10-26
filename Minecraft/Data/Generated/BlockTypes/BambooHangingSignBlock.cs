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
public record BambooHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:bamboo_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 18, "bamboo_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8271];

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
                        true => 8271,
                        false => 8272,
                    },
                    1 => Waterlogged switch {
                        true => 8273,
                        false => 8274,
                    },
                    2 => Waterlogged switch {
                        true => 8275,
                        false => 8276,
                    },
                    3 => Waterlogged switch {
                        true => 8277,
                        false => 8278,
                    },
                    4 => Waterlogged switch {
                        true => 8279,
                        false => 8280,
                    },
                    5 => Waterlogged switch {
                        true => 8281,
                        false => 8282,
                    },
                    6 => Waterlogged switch {
                        true => 8283,
                        false => 8284,
                    },
                    7 => Waterlogged switch {
                        true => 8285,
                        false => 8286,
                    },
                    8 => Waterlogged switch {
                        true => 8287,
                        false => 8288,
                    },
                    9 => Waterlogged switch {
                        true => 8289,
                        false => 8290,
                    },
                    10 => Waterlogged switch {
                        true => 8291,
                        false => 8292,
                    },
                    11 => Waterlogged switch {
                        true => 8293,
                        false => 8294,
                    },
                    12 => Waterlogged switch {
                        true => 8295,
                        false => 8296,
                    },
                    13 => Waterlogged switch {
                        true => 8297,
                        false => 8298,
                    },
                    14 => Waterlogged switch {
                        true => 8299,
                        false => 8300,
                    },
                    15 => Waterlogged switch {
                        true => 8301,
                        false => 8302,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 8303,
                        false => 8304,
                    },
                    1 => Waterlogged switch {
                        true => 8305,
                        false => 8306,
                    },
                    2 => Waterlogged switch {
                        true => 8307,
                        false => 8308,
                    },
                    3 => Waterlogged switch {
                        true => 8309,
                        false => 8310,
                    },
                    4 => Waterlogged switch {
                        true => 8311,
                        false => 8312,
                    },
                    5 => Waterlogged switch {
                        true => 8313,
                        false => 8314,
                    },
                    6 => Waterlogged switch {
                        true => 8315,
                        false => 8316,
                    },
                    7 => Waterlogged switch {
                        true => 8317,
                        false => 8318,
                    },
                    8 => Waterlogged switch {
                        true => 8319,
                        false => 8320,
                    },
                    9 => Waterlogged switch {
                        true => 8321,
                        false => 8322,
                    },
                    10 => Waterlogged switch {
                        true => 8323,
                        false => 8324,
                    },
                    11 => Waterlogged switch {
                        true => 8325,
                        false => 8326,
                    },
                    12 => Waterlogged switch {
                        true => 8327,
                        false => 8328,
                    },
                    13 => Waterlogged switch {
                        true => 8329,
                        false => 8330,
                    },
                    14 => Waterlogged switch {
                        true => 8331,
                        false => 8332,
                    },
                    15 => Waterlogged switch {
                        true => 8333,
                        false => 8334,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8271 => new BambooHangingSignBlock(Identifier, true, 0, true),
            8272 => new BambooHangingSignBlock(Identifier, true, 0, false),
            8273 => new BambooHangingSignBlock(Identifier, true, 1, true),
            8274 => new BambooHangingSignBlock(Identifier, true, 1, false),
            8275 => new BambooHangingSignBlock(Identifier, true, 2, true),
            8276 => new BambooHangingSignBlock(Identifier, true, 2, false),
            8277 => new BambooHangingSignBlock(Identifier, true, 3, true),
            8278 => new BambooHangingSignBlock(Identifier, true, 3, false),
            8279 => new BambooHangingSignBlock(Identifier, true, 4, true),
            8280 => new BambooHangingSignBlock(Identifier, true, 4, false),
            8281 => new BambooHangingSignBlock(Identifier, true, 5, true),
            8282 => new BambooHangingSignBlock(Identifier, true, 5, false),
            8283 => new BambooHangingSignBlock(Identifier, true, 6, true),
            8284 => new BambooHangingSignBlock(Identifier, true, 6, false),
            8285 => new BambooHangingSignBlock(Identifier, true, 7, true),
            8286 => new BambooHangingSignBlock(Identifier, true, 7, false),
            8287 => new BambooHangingSignBlock(Identifier, true, 8, true),
            8288 => new BambooHangingSignBlock(Identifier, true, 8, false),
            8289 => new BambooHangingSignBlock(Identifier, true, 9, true),
            8290 => new BambooHangingSignBlock(Identifier, true, 9, false),
            8291 => new BambooHangingSignBlock(Identifier, true, 10, true),
            8292 => new BambooHangingSignBlock(Identifier, true, 10, false),
            8293 => new BambooHangingSignBlock(Identifier, true, 11, true),
            8294 => new BambooHangingSignBlock(Identifier, true, 11, false),
            8295 => new BambooHangingSignBlock(Identifier, true, 12, true),
            8296 => new BambooHangingSignBlock(Identifier, true, 12, false),
            8297 => new BambooHangingSignBlock(Identifier, true, 13, true),
            8298 => new BambooHangingSignBlock(Identifier, true, 13, false),
            8299 => new BambooHangingSignBlock(Identifier, true, 14, true),
            8300 => new BambooHangingSignBlock(Identifier, true, 14, false),
            8301 => new BambooHangingSignBlock(Identifier, true, 15, true),
            8302 => new BambooHangingSignBlock(Identifier, true, 15, false),
            8303 => new BambooHangingSignBlock(Identifier, false, 0, true),
            8304 => new BambooHangingSignBlock(Identifier, false, 0, false),
            8305 => new BambooHangingSignBlock(Identifier, false, 1, true),
            8306 => new BambooHangingSignBlock(Identifier, false, 1, false),
            8307 => new BambooHangingSignBlock(Identifier, false, 2, true),
            8308 => new BambooHangingSignBlock(Identifier, false, 2, false),
            8309 => new BambooHangingSignBlock(Identifier, false, 3, true),
            8310 => new BambooHangingSignBlock(Identifier, false, 3, false),
            8311 => new BambooHangingSignBlock(Identifier, false, 4, true),
            8312 => new BambooHangingSignBlock(Identifier, false, 4, false),
            8313 => new BambooHangingSignBlock(Identifier, false, 5, true),
            8314 => new BambooHangingSignBlock(Identifier, false, 5, false),
            8315 => new BambooHangingSignBlock(Identifier, false, 6, true),
            8316 => new BambooHangingSignBlock(Identifier, false, 6, false),
            8317 => new BambooHangingSignBlock(Identifier, false, 7, true),
            8318 => new BambooHangingSignBlock(Identifier, false, 7, false),
            8319 => new BambooHangingSignBlock(Identifier, false, 8, true),
            8320 => new BambooHangingSignBlock(Identifier, false, 8, false),
            8321 => new BambooHangingSignBlock(Identifier, false, 9, true),
            8322 => new BambooHangingSignBlock(Identifier, false, 9, false),
            8323 => new BambooHangingSignBlock(Identifier, false, 10, true),
            8324 => new BambooHangingSignBlock(Identifier, false, 10, false),
            8325 => new BambooHangingSignBlock(Identifier, false, 11, true),
            8326 => new BambooHangingSignBlock(Identifier, false, 11, false),
            8327 => new BambooHangingSignBlock(Identifier, false, 12, true),
            8328 => new BambooHangingSignBlock(Identifier, false, 12, false),
            8329 => new BambooHangingSignBlock(Identifier, false, 13, true),
            8330 => new BambooHangingSignBlock(Identifier, false, 13, false),
            8331 => new BambooHangingSignBlock(Identifier, false, 14, true),
            8332 => new BambooHangingSignBlock(Identifier, false, 14, false),
            8333 => new BambooHangingSignBlock(Identifier, false, 15, true),
            8334 => new BambooHangingSignBlock(Identifier, false, 15, false),
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
