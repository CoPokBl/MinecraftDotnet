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
public record BirchHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.birch_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:birch_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/birch_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 2, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7631];

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
                        true => 7631,
                        false => 7632,
                    },
                    1 => Waterlogged switch {
                        true => 7633,
                        false => 7634,
                    },
                    2 => Waterlogged switch {
                        true => 7635,
                        false => 7636,
                    },
                    3 => Waterlogged switch {
                        true => 7637,
                        false => 7638,
                    },
                    4 => Waterlogged switch {
                        true => 7639,
                        false => 7640,
                    },
                    5 => Waterlogged switch {
                        true => 7641,
                        false => 7642,
                    },
                    6 => Waterlogged switch {
                        true => 7643,
                        false => 7644,
                    },
                    7 => Waterlogged switch {
                        true => 7645,
                        false => 7646,
                    },
                    8 => Waterlogged switch {
                        true => 7647,
                        false => 7648,
                    },
                    9 => Waterlogged switch {
                        true => 7649,
                        false => 7650,
                    },
                    10 => Waterlogged switch {
                        true => 7651,
                        false => 7652,
                    },
                    11 => Waterlogged switch {
                        true => 7653,
                        false => 7654,
                    },
                    12 => Waterlogged switch {
                        true => 7655,
                        false => 7656,
                    },
                    13 => Waterlogged switch {
                        true => 7657,
                        false => 7658,
                    },
                    14 => Waterlogged switch {
                        true => 7659,
                        false => 7660,
                    },
                    15 => Waterlogged switch {
                        true => 7661,
                        false => 7662,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7663,
                        false => 7664,
                    },
                    1 => Waterlogged switch {
                        true => 7665,
                        false => 7666,
                    },
                    2 => Waterlogged switch {
                        true => 7667,
                        false => 7668,
                    },
                    3 => Waterlogged switch {
                        true => 7669,
                        false => 7670,
                    },
                    4 => Waterlogged switch {
                        true => 7671,
                        false => 7672,
                    },
                    5 => Waterlogged switch {
                        true => 7673,
                        false => 7674,
                    },
                    6 => Waterlogged switch {
                        true => 7675,
                        false => 7676,
                    },
                    7 => Waterlogged switch {
                        true => 7677,
                        false => 7678,
                    },
                    8 => Waterlogged switch {
                        true => 7679,
                        false => 7680,
                    },
                    9 => Waterlogged switch {
                        true => 7681,
                        false => 7682,
                    },
                    10 => Waterlogged switch {
                        true => 7683,
                        false => 7684,
                    },
                    11 => Waterlogged switch {
                        true => 7685,
                        false => 7686,
                    },
                    12 => Waterlogged switch {
                        true => 7687,
                        false => 7688,
                    },
                    13 => Waterlogged switch {
                        true => 7689,
                        false => 7690,
                    },
                    14 => Waterlogged switch {
                        true => 7691,
                        false => 7692,
                    },
                    15 => Waterlogged switch {
                        true => 7693,
                        false => 7694,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7631 => new BirchHangingSignBlock(Identifier, true, 0, true),
            7632 => new BirchHangingSignBlock(Identifier, true, 0, false),
            7633 => new BirchHangingSignBlock(Identifier, true, 1, true),
            7634 => new BirchHangingSignBlock(Identifier, true, 1, false),
            7635 => new BirchHangingSignBlock(Identifier, true, 2, true),
            7636 => new BirchHangingSignBlock(Identifier, true, 2, false),
            7637 => new BirchHangingSignBlock(Identifier, true, 3, true),
            7638 => new BirchHangingSignBlock(Identifier, true, 3, false),
            7639 => new BirchHangingSignBlock(Identifier, true, 4, true),
            7640 => new BirchHangingSignBlock(Identifier, true, 4, false),
            7641 => new BirchHangingSignBlock(Identifier, true, 5, true),
            7642 => new BirchHangingSignBlock(Identifier, true, 5, false),
            7643 => new BirchHangingSignBlock(Identifier, true, 6, true),
            7644 => new BirchHangingSignBlock(Identifier, true, 6, false),
            7645 => new BirchHangingSignBlock(Identifier, true, 7, true),
            7646 => new BirchHangingSignBlock(Identifier, true, 7, false),
            7647 => new BirchHangingSignBlock(Identifier, true, 8, true),
            7648 => new BirchHangingSignBlock(Identifier, true, 8, false),
            7649 => new BirchHangingSignBlock(Identifier, true, 9, true),
            7650 => new BirchHangingSignBlock(Identifier, true, 9, false),
            7651 => new BirchHangingSignBlock(Identifier, true, 10, true),
            7652 => new BirchHangingSignBlock(Identifier, true, 10, false),
            7653 => new BirchHangingSignBlock(Identifier, true, 11, true),
            7654 => new BirchHangingSignBlock(Identifier, true, 11, false),
            7655 => new BirchHangingSignBlock(Identifier, true, 12, true),
            7656 => new BirchHangingSignBlock(Identifier, true, 12, false),
            7657 => new BirchHangingSignBlock(Identifier, true, 13, true),
            7658 => new BirchHangingSignBlock(Identifier, true, 13, false),
            7659 => new BirchHangingSignBlock(Identifier, true, 14, true),
            7660 => new BirchHangingSignBlock(Identifier, true, 14, false),
            7661 => new BirchHangingSignBlock(Identifier, true, 15, true),
            7662 => new BirchHangingSignBlock(Identifier, true, 15, false),
            7663 => new BirchHangingSignBlock(Identifier, false, 0, true),
            7664 => new BirchHangingSignBlock(Identifier, false, 0, false),
            7665 => new BirchHangingSignBlock(Identifier, false, 1, true),
            7666 => new BirchHangingSignBlock(Identifier, false, 1, false),
            7667 => new BirchHangingSignBlock(Identifier, false, 2, true),
            7668 => new BirchHangingSignBlock(Identifier, false, 2, false),
            7669 => new BirchHangingSignBlock(Identifier, false, 3, true),
            7670 => new BirchHangingSignBlock(Identifier, false, 3, false),
            7671 => new BirchHangingSignBlock(Identifier, false, 4, true),
            7672 => new BirchHangingSignBlock(Identifier, false, 4, false),
            7673 => new BirchHangingSignBlock(Identifier, false, 5, true),
            7674 => new BirchHangingSignBlock(Identifier, false, 5, false),
            7675 => new BirchHangingSignBlock(Identifier, false, 6, true),
            7676 => new BirchHangingSignBlock(Identifier, false, 6, false),
            7677 => new BirchHangingSignBlock(Identifier, false, 7, true),
            7678 => new BirchHangingSignBlock(Identifier, false, 7, false),
            7679 => new BirchHangingSignBlock(Identifier, false, 8, true),
            7680 => new BirchHangingSignBlock(Identifier, false, 8, false),
            7681 => new BirchHangingSignBlock(Identifier, false, 9, true),
            7682 => new BirchHangingSignBlock(Identifier, false, 9, false),
            7683 => new BirchHangingSignBlock(Identifier, false, 10, true),
            7684 => new BirchHangingSignBlock(Identifier, false, 10, false),
            7685 => new BirchHangingSignBlock(Identifier, false, 11, true),
            7686 => new BirchHangingSignBlock(Identifier, false, 11, false),
            7687 => new BirchHangingSignBlock(Identifier, false, 12, true),
            7688 => new BirchHangingSignBlock(Identifier, false, 12, false),
            7689 => new BirchHangingSignBlock(Identifier, false, 13, true),
            7690 => new BirchHangingSignBlock(Identifier, false, 13, false),
            7691 => new BirchHangingSignBlock(Identifier, false, 14, true),
            7692 => new BirchHangingSignBlock(Identifier, false, 14, false),
            7693 => new BirchHangingSignBlock(Identifier, false, 15, true),
            7694 => new BirchHangingSignBlock(Identifier, false, 15, false),
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
