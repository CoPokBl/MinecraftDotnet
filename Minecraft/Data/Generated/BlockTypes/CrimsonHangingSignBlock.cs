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
public record CrimsonHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.crimson_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:crimson_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 53, "nether_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6419];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6419,
                        false => 6420,
                    },
                    1 => Waterlogged switch {
                        true => 6421,
                        false => 6422,
                    },
                    2 => Waterlogged switch {
                        true => 6423,
                        false => 6424,
                    },
                    3 => Waterlogged switch {
                        true => 6425,
                        false => 6426,
                    },
                    4 => Waterlogged switch {
                        true => 6427,
                        false => 6428,
                    },
                    5 => Waterlogged switch {
                        true => 6429,
                        false => 6430,
                    },
                    6 => Waterlogged switch {
                        true => 6431,
                        false => 6432,
                    },
                    7 => Waterlogged switch {
                        true => 6433,
                        false => 6434,
                    },
                    8 => Waterlogged switch {
                        true => 6435,
                        false => 6436,
                    },
                    9 => Waterlogged switch {
                        true => 6437,
                        false => 6438,
                    },
                    10 => Waterlogged switch {
                        true => 6439,
                        false => 6440,
                    },
                    11 => Waterlogged switch {
                        true => 6441,
                        false => 6442,
                    },
                    12 => Waterlogged switch {
                        true => 6443,
                        false => 6444,
                    },
                    13 => Waterlogged switch {
                        true => 6445,
                        false => 6446,
                    },
                    14 => Waterlogged switch {
                        true => 6447,
                        false => 6448,
                    },
                    15 => Waterlogged switch {
                        true => 6449,
                        false => 6450,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6451,
                        false => 6452,
                    },
                    1 => Waterlogged switch {
                        true => 6453,
                        false => 6454,
                    },
                    2 => Waterlogged switch {
                        true => 6455,
                        false => 6456,
                    },
                    3 => Waterlogged switch {
                        true => 6457,
                        false => 6458,
                    },
                    4 => Waterlogged switch {
                        true => 6459,
                        false => 6460,
                    },
                    5 => Waterlogged switch {
                        true => 6461,
                        false => 6462,
                    },
                    6 => Waterlogged switch {
                        true => 6463,
                        false => 6464,
                    },
                    7 => Waterlogged switch {
                        true => 6465,
                        false => 6466,
                    },
                    8 => Waterlogged switch {
                        true => 6467,
                        false => 6468,
                    },
                    9 => Waterlogged switch {
                        true => 6469,
                        false => 6470,
                    },
                    10 => Waterlogged switch {
                        true => 6471,
                        false => 6472,
                    },
                    11 => Waterlogged switch {
                        true => 6473,
                        false => 6474,
                    },
                    12 => Waterlogged switch {
                        true => 6475,
                        false => 6476,
                    },
                    13 => Waterlogged switch {
                        true => 6477,
                        false => 6478,
                    },
                    14 => Waterlogged switch {
                        true => 6479,
                        false => 6480,
                    },
                    15 => Waterlogged switch {
                        true => 6481,
                        false => 6482,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6419 => new CrimsonHangingSignBlock(Identifier, true, 0, true),
            6420 => new CrimsonHangingSignBlock(Identifier, true, 0, false),
            6421 => new CrimsonHangingSignBlock(Identifier, true, 1, true),
            6422 => new CrimsonHangingSignBlock(Identifier, true, 1, false),
            6423 => new CrimsonHangingSignBlock(Identifier, true, 2, true),
            6424 => new CrimsonHangingSignBlock(Identifier, true, 2, false),
            6425 => new CrimsonHangingSignBlock(Identifier, true, 3, true),
            6426 => new CrimsonHangingSignBlock(Identifier, true, 3, false),
            6427 => new CrimsonHangingSignBlock(Identifier, true, 4, true),
            6428 => new CrimsonHangingSignBlock(Identifier, true, 4, false),
            6429 => new CrimsonHangingSignBlock(Identifier, true, 5, true),
            6430 => new CrimsonHangingSignBlock(Identifier, true, 5, false),
            6431 => new CrimsonHangingSignBlock(Identifier, true, 6, true),
            6432 => new CrimsonHangingSignBlock(Identifier, true, 6, false),
            6433 => new CrimsonHangingSignBlock(Identifier, true, 7, true),
            6434 => new CrimsonHangingSignBlock(Identifier, true, 7, false),
            6435 => new CrimsonHangingSignBlock(Identifier, true, 8, true),
            6436 => new CrimsonHangingSignBlock(Identifier, true, 8, false),
            6437 => new CrimsonHangingSignBlock(Identifier, true, 9, true),
            6438 => new CrimsonHangingSignBlock(Identifier, true, 9, false),
            6439 => new CrimsonHangingSignBlock(Identifier, true, 10, true),
            6440 => new CrimsonHangingSignBlock(Identifier, true, 10, false),
            6441 => new CrimsonHangingSignBlock(Identifier, true, 11, true),
            6442 => new CrimsonHangingSignBlock(Identifier, true, 11, false),
            6443 => new CrimsonHangingSignBlock(Identifier, true, 12, true),
            6444 => new CrimsonHangingSignBlock(Identifier, true, 12, false),
            6445 => new CrimsonHangingSignBlock(Identifier, true, 13, true),
            6446 => new CrimsonHangingSignBlock(Identifier, true, 13, false),
            6447 => new CrimsonHangingSignBlock(Identifier, true, 14, true),
            6448 => new CrimsonHangingSignBlock(Identifier, true, 14, false),
            6449 => new CrimsonHangingSignBlock(Identifier, true, 15, true),
            6450 => new CrimsonHangingSignBlock(Identifier, true, 15, false),
            6451 => new CrimsonHangingSignBlock(Identifier, false, 0, true),
            6452 => new CrimsonHangingSignBlock(Identifier, false, 0, false),
            6453 => new CrimsonHangingSignBlock(Identifier, false, 1, true),
            6454 => new CrimsonHangingSignBlock(Identifier, false, 1, false),
            6455 => new CrimsonHangingSignBlock(Identifier, false, 2, true),
            6456 => new CrimsonHangingSignBlock(Identifier, false, 2, false),
            6457 => new CrimsonHangingSignBlock(Identifier, false, 3, true),
            6458 => new CrimsonHangingSignBlock(Identifier, false, 3, false),
            6459 => new CrimsonHangingSignBlock(Identifier, false, 4, true),
            6460 => new CrimsonHangingSignBlock(Identifier, false, 4, false),
            6461 => new CrimsonHangingSignBlock(Identifier, false, 5, true),
            6462 => new CrimsonHangingSignBlock(Identifier, false, 5, false),
            6463 => new CrimsonHangingSignBlock(Identifier, false, 6, true),
            6464 => new CrimsonHangingSignBlock(Identifier, false, 6, false),
            6465 => new CrimsonHangingSignBlock(Identifier, false, 7, true),
            6466 => new CrimsonHangingSignBlock(Identifier, false, 7, false),
            6467 => new CrimsonHangingSignBlock(Identifier, false, 8, true),
            6468 => new CrimsonHangingSignBlock(Identifier, false, 8, false),
            6469 => new CrimsonHangingSignBlock(Identifier, false, 9, true),
            6470 => new CrimsonHangingSignBlock(Identifier, false, 9, false),
            6471 => new CrimsonHangingSignBlock(Identifier, false, 10, true),
            6472 => new CrimsonHangingSignBlock(Identifier, false, 10, false),
            6473 => new CrimsonHangingSignBlock(Identifier, false, 11, true),
            6474 => new CrimsonHangingSignBlock(Identifier, false, 11, false),
            6475 => new CrimsonHangingSignBlock(Identifier, false, 12, true),
            6476 => new CrimsonHangingSignBlock(Identifier, false, 12, false),
            6477 => new CrimsonHangingSignBlock(Identifier, false, 13, true),
            6478 => new CrimsonHangingSignBlock(Identifier, false, 13, false),
            6479 => new CrimsonHangingSignBlock(Identifier, false, 14, true),
            6480 => new CrimsonHangingSignBlock(Identifier, false, 14, false),
            6481 => new CrimsonHangingSignBlock(Identifier, false, 15, true),
            6482 => new CrimsonHangingSignBlock(Identifier, false, 15, false),
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
