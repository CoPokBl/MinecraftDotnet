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
public record WarpedHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.warped_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:warped_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/warped_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 56, "nether_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6483];

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
                        true => 6483,
                        false => 6484,
                    },
                    1 => Waterlogged switch {
                        true => 6485,
                        false => 6486,
                    },
                    2 => Waterlogged switch {
                        true => 6487,
                        false => 6488,
                    },
                    3 => Waterlogged switch {
                        true => 6489,
                        false => 6490,
                    },
                    4 => Waterlogged switch {
                        true => 6491,
                        false => 6492,
                    },
                    5 => Waterlogged switch {
                        true => 6493,
                        false => 6494,
                    },
                    6 => Waterlogged switch {
                        true => 6495,
                        false => 6496,
                    },
                    7 => Waterlogged switch {
                        true => 6497,
                        false => 6498,
                    },
                    8 => Waterlogged switch {
                        true => 6499,
                        false => 6500,
                    },
                    9 => Waterlogged switch {
                        true => 6501,
                        false => 6502,
                    },
                    10 => Waterlogged switch {
                        true => 6503,
                        false => 6504,
                    },
                    11 => Waterlogged switch {
                        true => 6505,
                        false => 6506,
                    },
                    12 => Waterlogged switch {
                        true => 6507,
                        false => 6508,
                    },
                    13 => Waterlogged switch {
                        true => 6509,
                        false => 6510,
                    },
                    14 => Waterlogged switch {
                        true => 6511,
                        false => 6512,
                    },
                    15 => Waterlogged switch {
                        true => 6513,
                        false => 6514,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6515,
                        false => 6516,
                    },
                    1 => Waterlogged switch {
                        true => 6517,
                        false => 6518,
                    },
                    2 => Waterlogged switch {
                        true => 6519,
                        false => 6520,
                    },
                    3 => Waterlogged switch {
                        true => 6521,
                        false => 6522,
                    },
                    4 => Waterlogged switch {
                        true => 6523,
                        false => 6524,
                    },
                    5 => Waterlogged switch {
                        true => 6525,
                        false => 6526,
                    },
                    6 => Waterlogged switch {
                        true => 6527,
                        false => 6528,
                    },
                    7 => Waterlogged switch {
                        true => 6529,
                        false => 6530,
                    },
                    8 => Waterlogged switch {
                        true => 6531,
                        false => 6532,
                    },
                    9 => Waterlogged switch {
                        true => 6533,
                        false => 6534,
                    },
                    10 => Waterlogged switch {
                        true => 6535,
                        false => 6536,
                    },
                    11 => Waterlogged switch {
                        true => 6537,
                        false => 6538,
                    },
                    12 => Waterlogged switch {
                        true => 6539,
                        false => 6540,
                    },
                    13 => Waterlogged switch {
                        true => 6541,
                        false => 6542,
                    },
                    14 => Waterlogged switch {
                        true => 6543,
                        false => 6544,
                    },
                    15 => Waterlogged switch {
                        true => 6545,
                        false => 6546,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6483 => new WarpedHangingSignBlock(Identifier, true, 0, true),
            6484 => new WarpedHangingSignBlock(Identifier, true, 0, false),
            6485 => new WarpedHangingSignBlock(Identifier, true, 1, true),
            6486 => new WarpedHangingSignBlock(Identifier, true, 1, false),
            6487 => new WarpedHangingSignBlock(Identifier, true, 2, true),
            6488 => new WarpedHangingSignBlock(Identifier, true, 2, false),
            6489 => new WarpedHangingSignBlock(Identifier, true, 3, true),
            6490 => new WarpedHangingSignBlock(Identifier, true, 3, false),
            6491 => new WarpedHangingSignBlock(Identifier, true, 4, true),
            6492 => new WarpedHangingSignBlock(Identifier, true, 4, false),
            6493 => new WarpedHangingSignBlock(Identifier, true, 5, true),
            6494 => new WarpedHangingSignBlock(Identifier, true, 5, false),
            6495 => new WarpedHangingSignBlock(Identifier, true, 6, true),
            6496 => new WarpedHangingSignBlock(Identifier, true, 6, false),
            6497 => new WarpedHangingSignBlock(Identifier, true, 7, true),
            6498 => new WarpedHangingSignBlock(Identifier, true, 7, false),
            6499 => new WarpedHangingSignBlock(Identifier, true, 8, true),
            6500 => new WarpedHangingSignBlock(Identifier, true, 8, false),
            6501 => new WarpedHangingSignBlock(Identifier, true, 9, true),
            6502 => new WarpedHangingSignBlock(Identifier, true, 9, false),
            6503 => new WarpedHangingSignBlock(Identifier, true, 10, true),
            6504 => new WarpedHangingSignBlock(Identifier, true, 10, false),
            6505 => new WarpedHangingSignBlock(Identifier, true, 11, true),
            6506 => new WarpedHangingSignBlock(Identifier, true, 11, false),
            6507 => new WarpedHangingSignBlock(Identifier, true, 12, true),
            6508 => new WarpedHangingSignBlock(Identifier, true, 12, false),
            6509 => new WarpedHangingSignBlock(Identifier, true, 13, true),
            6510 => new WarpedHangingSignBlock(Identifier, true, 13, false),
            6511 => new WarpedHangingSignBlock(Identifier, true, 14, true),
            6512 => new WarpedHangingSignBlock(Identifier, true, 14, false),
            6513 => new WarpedHangingSignBlock(Identifier, true, 15, true),
            6514 => new WarpedHangingSignBlock(Identifier, true, 15, false),
            6515 => new WarpedHangingSignBlock(Identifier, false, 0, true),
            6516 => new WarpedHangingSignBlock(Identifier, false, 0, false),
            6517 => new WarpedHangingSignBlock(Identifier, false, 1, true),
            6518 => new WarpedHangingSignBlock(Identifier, false, 1, false),
            6519 => new WarpedHangingSignBlock(Identifier, false, 2, true),
            6520 => new WarpedHangingSignBlock(Identifier, false, 2, false),
            6521 => new WarpedHangingSignBlock(Identifier, false, 3, true),
            6522 => new WarpedHangingSignBlock(Identifier, false, 3, false),
            6523 => new WarpedHangingSignBlock(Identifier, false, 4, true),
            6524 => new WarpedHangingSignBlock(Identifier, false, 4, false),
            6525 => new WarpedHangingSignBlock(Identifier, false, 5, true),
            6526 => new WarpedHangingSignBlock(Identifier, false, 5, false),
            6527 => new WarpedHangingSignBlock(Identifier, false, 6, true),
            6528 => new WarpedHangingSignBlock(Identifier, false, 6, false),
            6529 => new WarpedHangingSignBlock(Identifier, false, 7, true),
            6530 => new WarpedHangingSignBlock(Identifier, false, 7, false),
            6531 => new WarpedHangingSignBlock(Identifier, false, 8, true),
            6532 => new WarpedHangingSignBlock(Identifier, false, 8, false),
            6533 => new WarpedHangingSignBlock(Identifier, false, 9, true),
            6534 => new WarpedHangingSignBlock(Identifier, false, 9, false),
            6535 => new WarpedHangingSignBlock(Identifier, false, 10, true),
            6536 => new WarpedHangingSignBlock(Identifier, false, 10, false),
            6537 => new WarpedHangingSignBlock(Identifier, false, 11, true),
            6538 => new WarpedHangingSignBlock(Identifier, false, 11, false),
            6539 => new WarpedHangingSignBlock(Identifier, false, 12, true),
            6540 => new WarpedHangingSignBlock(Identifier, false, 12, false),
            6541 => new WarpedHangingSignBlock(Identifier, false, 13, true),
            6542 => new WarpedHangingSignBlock(Identifier, false, 13, false),
            6543 => new WarpedHangingSignBlock(Identifier, false, 14, true),
            6544 => new WarpedHangingSignBlock(Identifier, false, 14, false),
            6545 => new WarpedHangingSignBlock(Identifier, false, 15, true),
            6546 => new WarpedHangingSignBlock(Identifier, false, 15, false),
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
