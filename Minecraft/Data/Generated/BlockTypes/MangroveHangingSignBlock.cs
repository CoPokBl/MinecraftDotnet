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
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.mangrove_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:mangrove_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 28, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6547];

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
                        true => 6547,
                        false => 6548,
                    },
                    1 => Waterlogged switch {
                        true => 6549,
                        false => 6550,
                    },
                    2 => Waterlogged switch {
                        true => 6551,
                        false => 6552,
                    },
                    3 => Waterlogged switch {
                        true => 6553,
                        false => 6554,
                    },
                    4 => Waterlogged switch {
                        true => 6555,
                        false => 6556,
                    },
                    5 => Waterlogged switch {
                        true => 6557,
                        false => 6558,
                    },
                    6 => Waterlogged switch {
                        true => 6559,
                        false => 6560,
                    },
                    7 => Waterlogged switch {
                        true => 6561,
                        false => 6562,
                    },
                    8 => Waterlogged switch {
                        true => 6563,
                        false => 6564,
                    },
                    9 => Waterlogged switch {
                        true => 6565,
                        false => 6566,
                    },
                    10 => Waterlogged switch {
                        true => 6567,
                        false => 6568,
                    },
                    11 => Waterlogged switch {
                        true => 6569,
                        false => 6570,
                    },
                    12 => Waterlogged switch {
                        true => 6571,
                        false => 6572,
                    },
                    13 => Waterlogged switch {
                        true => 6573,
                        false => 6574,
                    },
                    14 => Waterlogged switch {
                        true => 6575,
                        false => 6576,
                    },
                    15 => Waterlogged switch {
                        true => 6577,
                        false => 6578,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6579,
                        false => 6580,
                    },
                    1 => Waterlogged switch {
                        true => 6581,
                        false => 6582,
                    },
                    2 => Waterlogged switch {
                        true => 6583,
                        false => 6584,
                    },
                    3 => Waterlogged switch {
                        true => 6585,
                        false => 6586,
                    },
                    4 => Waterlogged switch {
                        true => 6587,
                        false => 6588,
                    },
                    5 => Waterlogged switch {
                        true => 6589,
                        false => 6590,
                    },
                    6 => Waterlogged switch {
                        true => 6591,
                        false => 6592,
                    },
                    7 => Waterlogged switch {
                        true => 6593,
                        false => 6594,
                    },
                    8 => Waterlogged switch {
                        true => 6595,
                        false => 6596,
                    },
                    9 => Waterlogged switch {
                        true => 6597,
                        false => 6598,
                    },
                    10 => Waterlogged switch {
                        true => 6599,
                        false => 6600,
                    },
                    11 => Waterlogged switch {
                        true => 6601,
                        false => 6602,
                    },
                    12 => Waterlogged switch {
                        true => 6603,
                        false => 6604,
                    },
                    13 => Waterlogged switch {
                        true => 6605,
                        false => 6606,
                    },
                    14 => Waterlogged switch {
                        true => 6607,
                        false => 6608,
                    },
                    15 => Waterlogged switch {
                        true => 6609,
                        false => 6610,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6547 => new MangroveHangingSignBlock(Identifier, true, 0, true),
            6548 => new MangroveHangingSignBlock(Identifier, true, 0, false),
            6549 => new MangroveHangingSignBlock(Identifier, true, 1, true),
            6550 => new MangroveHangingSignBlock(Identifier, true, 1, false),
            6551 => new MangroveHangingSignBlock(Identifier, true, 2, true),
            6552 => new MangroveHangingSignBlock(Identifier, true, 2, false),
            6553 => new MangroveHangingSignBlock(Identifier, true, 3, true),
            6554 => new MangroveHangingSignBlock(Identifier, true, 3, false),
            6555 => new MangroveHangingSignBlock(Identifier, true, 4, true),
            6556 => new MangroveHangingSignBlock(Identifier, true, 4, false),
            6557 => new MangroveHangingSignBlock(Identifier, true, 5, true),
            6558 => new MangroveHangingSignBlock(Identifier, true, 5, false),
            6559 => new MangroveHangingSignBlock(Identifier, true, 6, true),
            6560 => new MangroveHangingSignBlock(Identifier, true, 6, false),
            6561 => new MangroveHangingSignBlock(Identifier, true, 7, true),
            6562 => new MangroveHangingSignBlock(Identifier, true, 7, false),
            6563 => new MangroveHangingSignBlock(Identifier, true, 8, true),
            6564 => new MangroveHangingSignBlock(Identifier, true, 8, false),
            6565 => new MangroveHangingSignBlock(Identifier, true, 9, true),
            6566 => new MangroveHangingSignBlock(Identifier, true, 9, false),
            6567 => new MangroveHangingSignBlock(Identifier, true, 10, true),
            6568 => new MangroveHangingSignBlock(Identifier, true, 10, false),
            6569 => new MangroveHangingSignBlock(Identifier, true, 11, true),
            6570 => new MangroveHangingSignBlock(Identifier, true, 11, false),
            6571 => new MangroveHangingSignBlock(Identifier, true, 12, true),
            6572 => new MangroveHangingSignBlock(Identifier, true, 12, false),
            6573 => new MangroveHangingSignBlock(Identifier, true, 13, true),
            6574 => new MangroveHangingSignBlock(Identifier, true, 13, false),
            6575 => new MangroveHangingSignBlock(Identifier, true, 14, true),
            6576 => new MangroveHangingSignBlock(Identifier, true, 14, false),
            6577 => new MangroveHangingSignBlock(Identifier, true, 15, true),
            6578 => new MangroveHangingSignBlock(Identifier, true, 15, false),
            6579 => new MangroveHangingSignBlock(Identifier, false, 0, true),
            6580 => new MangroveHangingSignBlock(Identifier, false, 0, false),
            6581 => new MangroveHangingSignBlock(Identifier, false, 1, true),
            6582 => new MangroveHangingSignBlock(Identifier, false, 1, false),
            6583 => new MangroveHangingSignBlock(Identifier, false, 2, true),
            6584 => new MangroveHangingSignBlock(Identifier, false, 2, false),
            6585 => new MangroveHangingSignBlock(Identifier, false, 3, true),
            6586 => new MangroveHangingSignBlock(Identifier, false, 3, false),
            6587 => new MangroveHangingSignBlock(Identifier, false, 4, true),
            6588 => new MangroveHangingSignBlock(Identifier, false, 4, false),
            6589 => new MangroveHangingSignBlock(Identifier, false, 5, true),
            6590 => new MangroveHangingSignBlock(Identifier, false, 5, false),
            6591 => new MangroveHangingSignBlock(Identifier, false, 6, true),
            6592 => new MangroveHangingSignBlock(Identifier, false, 6, false),
            6593 => new MangroveHangingSignBlock(Identifier, false, 7, true),
            6594 => new MangroveHangingSignBlock(Identifier, false, 7, false),
            6595 => new MangroveHangingSignBlock(Identifier, false, 8, true),
            6596 => new MangroveHangingSignBlock(Identifier, false, 8, false),
            6597 => new MangroveHangingSignBlock(Identifier, false, 9, true),
            6598 => new MangroveHangingSignBlock(Identifier, false, 9, false),
            6599 => new MangroveHangingSignBlock(Identifier, false, 10, true),
            6600 => new MangroveHangingSignBlock(Identifier, false, 10, false),
            6601 => new MangroveHangingSignBlock(Identifier, false, 11, true),
            6602 => new MangroveHangingSignBlock(Identifier, false, 11, false),
            6603 => new MangroveHangingSignBlock(Identifier, false, 12, true),
            6604 => new MangroveHangingSignBlock(Identifier, false, 12, false),
            6605 => new MangroveHangingSignBlock(Identifier, false, 13, true),
            6606 => new MangroveHangingSignBlock(Identifier, false, 13, false),
            6607 => new MangroveHangingSignBlock(Identifier, false, 14, true),
            6608 => new MangroveHangingSignBlock(Identifier, false, 14, false),
            6609 => new MangroveHangingSignBlock(Identifier, false, 15, true),
            6610 => new MangroveHangingSignBlock(Identifier, false, 15, false),
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
