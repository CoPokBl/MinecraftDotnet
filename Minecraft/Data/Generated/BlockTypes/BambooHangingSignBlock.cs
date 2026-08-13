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
public record BambooHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:ceiling_hanging_sign", "block.minecraft.bamboo_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:bamboo_hanging_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 18, "bamboo_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 6611];

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
                        true => 6611,
                        false => 6612,
                    },
                    1 => Waterlogged switch {
                        true => 6613,
                        false => 6614,
                    },
                    2 => Waterlogged switch {
                        true => 6615,
                        false => 6616,
                    },
                    3 => Waterlogged switch {
                        true => 6617,
                        false => 6618,
                    },
                    4 => Waterlogged switch {
                        true => 6619,
                        false => 6620,
                    },
                    5 => Waterlogged switch {
                        true => 6621,
                        false => 6622,
                    },
                    6 => Waterlogged switch {
                        true => 6623,
                        false => 6624,
                    },
                    7 => Waterlogged switch {
                        true => 6625,
                        false => 6626,
                    },
                    8 => Waterlogged switch {
                        true => 6627,
                        false => 6628,
                    },
                    9 => Waterlogged switch {
                        true => 6629,
                        false => 6630,
                    },
                    10 => Waterlogged switch {
                        true => 6631,
                        false => 6632,
                    },
                    11 => Waterlogged switch {
                        true => 6633,
                        false => 6634,
                    },
                    12 => Waterlogged switch {
                        true => 6635,
                        false => 6636,
                    },
                    13 => Waterlogged switch {
                        true => 6637,
                        false => 6638,
                    },
                    14 => Waterlogged switch {
                        true => 6639,
                        false => 6640,
                    },
                    15 => Waterlogged switch {
                        true => 6641,
                        false => 6642,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6643,
                        false => 6644,
                    },
                    1 => Waterlogged switch {
                        true => 6645,
                        false => 6646,
                    },
                    2 => Waterlogged switch {
                        true => 6647,
                        false => 6648,
                    },
                    3 => Waterlogged switch {
                        true => 6649,
                        false => 6650,
                    },
                    4 => Waterlogged switch {
                        true => 6651,
                        false => 6652,
                    },
                    5 => Waterlogged switch {
                        true => 6653,
                        false => 6654,
                    },
                    6 => Waterlogged switch {
                        true => 6655,
                        false => 6656,
                    },
                    7 => Waterlogged switch {
                        true => 6657,
                        false => 6658,
                    },
                    8 => Waterlogged switch {
                        true => 6659,
                        false => 6660,
                    },
                    9 => Waterlogged switch {
                        true => 6661,
                        false => 6662,
                    },
                    10 => Waterlogged switch {
                        true => 6663,
                        false => 6664,
                    },
                    11 => Waterlogged switch {
                        true => 6665,
                        false => 6666,
                    },
                    12 => Waterlogged switch {
                        true => 6667,
                        false => 6668,
                    },
                    13 => Waterlogged switch {
                        true => 6669,
                        false => 6670,
                    },
                    14 => Waterlogged switch {
                        true => 6671,
                        false => 6672,
                    },
                    15 => Waterlogged switch {
                        true => 6673,
                        false => 6674,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6611 => new BambooHangingSignBlock(Identifier, true, 0, true),
            6612 => new BambooHangingSignBlock(Identifier, true, 0, false),
            6613 => new BambooHangingSignBlock(Identifier, true, 1, true),
            6614 => new BambooHangingSignBlock(Identifier, true, 1, false),
            6615 => new BambooHangingSignBlock(Identifier, true, 2, true),
            6616 => new BambooHangingSignBlock(Identifier, true, 2, false),
            6617 => new BambooHangingSignBlock(Identifier, true, 3, true),
            6618 => new BambooHangingSignBlock(Identifier, true, 3, false),
            6619 => new BambooHangingSignBlock(Identifier, true, 4, true),
            6620 => new BambooHangingSignBlock(Identifier, true, 4, false),
            6621 => new BambooHangingSignBlock(Identifier, true, 5, true),
            6622 => new BambooHangingSignBlock(Identifier, true, 5, false),
            6623 => new BambooHangingSignBlock(Identifier, true, 6, true),
            6624 => new BambooHangingSignBlock(Identifier, true, 6, false),
            6625 => new BambooHangingSignBlock(Identifier, true, 7, true),
            6626 => new BambooHangingSignBlock(Identifier, true, 7, false),
            6627 => new BambooHangingSignBlock(Identifier, true, 8, true),
            6628 => new BambooHangingSignBlock(Identifier, true, 8, false),
            6629 => new BambooHangingSignBlock(Identifier, true, 9, true),
            6630 => new BambooHangingSignBlock(Identifier, true, 9, false),
            6631 => new BambooHangingSignBlock(Identifier, true, 10, true),
            6632 => new BambooHangingSignBlock(Identifier, true, 10, false),
            6633 => new BambooHangingSignBlock(Identifier, true, 11, true),
            6634 => new BambooHangingSignBlock(Identifier, true, 11, false),
            6635 => new BambooHangingSignBlock(Identifier, true, 12, true),
            6636 => new BambooHangingSignBlock(Identifier, true, 12, false),
            6637 => new BambooHangingSignBlock(Identifier, true, 13, true),
            6638 => new BambooHangingSignBlock(Identifier, true, 13, false),
            6639 => new BambooHangingSignBlock(Identifier, true, 14, true),
            6640 => new BambooHangingSignBlock(Identifier, true, 14, false),
            6641 => new BambooHangingSignBlock(Identifier, true, 15, true),
            6642 => new BambooHangingSignBlock(Identifier, true, 15, false),
            6643 => new BambooHangingSignBlock(Identifier, false, 0, true),
            6644 => new BambooHangingSignBlock(Identifier, false, 0, false),
            6645 => new BambooHangingSignBlock(Identifier, false, 1, true),
            6646 => new BambooHangingSignBlock(Identifier, false, 1, false),
            6647 => new BambooHangingSignBlock(Identifier, false, 2, true),
            6648 => new BambooHangingSignBlock(Identifier, false, 2, false),
            6649 => new BambooHangingSignBlock(Identifier, false, 3, true),
            6650 => new BambooHangingSignBlock(Identifier, false, 3, false),
            6651 => new BambooHangingSignBlock(Identifier, false, 4, true),
            6652 => new BambooHangingSignBlock(Identifier, false, 4, false),
            6653 => new BambooHangingSignBlock(Identifier, false, 5, true),
            6654 => new BambooHangingSignBlock(Identifier, false, 5, false),
            6655 => new BambooHangingSignBlock(Identifier, false, 6, true),
            6656 => new BambooHangingSignBlock(Identifier, false, 6, false),
            6657 => new BambooHangingSignBlock(Identifier, false, 7, true),
            6658 => new BambooHangingSignBlock(Identifier, false, 7, false),
            6659 => new BambooHangingSignBlock(Identifier, false, 8, true),
            6660 => new BambooHangingSignBlock(Identifier, false, 8, false),
            6661 => new BambooHangingSignBlock(Identifier, false, 9, true),
            6662 => new BambooHangingSignBlock(Identifier, false, 9, false),
            6663 => new BambooHangingSignBlock(Identifier, false, 10, true),
            6664 => new BambooHangingSignBlock(Identifier, false, 10, false),
            6665 => new BambooHangingSignBlock(Identifier, false, 11, true),
            6666 => new BambooHangingSignBlock(Identifier, false, 11, false),
            6667 => new BambooHangingSignBlock(Identifier, false, 12, true),
            6668 => new BambooHangingSignBlock(Identifier, false, 12, false),
            6669 => new BambooHangingSignBlock(Identifier, false, 13, true),
            6670 => new BambooHangingSignBlock(Identifier, false, 13, false),
            6671 => new BambooHangingSignBlock(Identifier, false, 14, true),
            6672 => new BambooHangingSignBlock(Identifier, false, 14, false),
            6673 => new BambooHangingSignBlock(Identifier, false, 15, true),
            6674 => new BambooHangingSignBlock(Identifier, false, 15, false),
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
