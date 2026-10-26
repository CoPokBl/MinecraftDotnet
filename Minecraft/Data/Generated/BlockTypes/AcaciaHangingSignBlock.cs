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
public record AcaciaHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.acacia_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:acacia_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 15, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7695];

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
                        true => 7695,
                        false => 7696,
                    },
                    1 => Waterlogged switch {
                        true => 7697,
                        false => 7698,
                    },
                    2 => Waterlogged switch {
                        true => 7699,
                        false => 7700,
                    },
                    3 => Waterlogged switch {
                        true => 7701,
                        false => 7702,
                    },
                    4 => Waterlogged switch {
                        true => 7703,
                        false => 7704,
                    },
                    5 => Waterlogged switch {
                        true => 7705,
                        false => 7706,
                    },
                    6 => Waterlogged switch {
                        true => 7707,
                        false => 7708,
                    },
                    7 => Waterlogged switch {
                        true => 7709,
                        false => 7710,
                    },
                    8 => Waterlogged switch {
                        true => 7711,
                        false => 7712,
                    },
                    9 => Waterlogged switch {
                        true => 7713,
                        false => 7714,
                    },
                    10 => Waterlogged switch {
                        true => 7715,
                        false => 7716,
                    },
                    11 => Waterlogged switch {
                        true => 7717,
                        false => 7718,
                    },
                    12 => Waterlogged switch {
                        true => 7719,
                        false => 7720,
                    },
                    13 => Waterlogged switch {
                        true => 7721,
                        false => 7722,
                    },
                    14 => Waterlogged switch {
                        true => 7723,
                        false => 7724,
                    },
                    15 => Waterlogged switch {
                        true => 7725,
                        false => 7726,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7727,
                        false => 7728,
                    },
                    1 => Waterlogged switch {
                        true => 7729,
                        false => 7730,
                    },
                    2 => Waterlogged switch {
                        true => 7731,
                        false => 7732,
                    },
                    3 => Waterlogged switch {
                        true => 7733,
                        false => 7734,
                    },
                    4 => Waterlogged switch {
                        true => 7735,
                        false => 7736,
                    },
                    5 => Waterlogged switch {
                        true => 7737,
                        false => 7738,
                    },
                    6 => Waterlogged switch {
                        true => 7739,
                        false => 7740,
                    },
                    7 => Waterlogged switch {
                        true => 7741,
                        false => 7742,
                    },
                    8 => Waterlogged switch {
                        true => 7743,
                        false => 7744,
                    },
                    9 => Waterlogged switch {
                        true => 7745,
                        false => 7746,
                    },
                    10 => Waterlogged switch {
                        true => 7747,
                        false => 7748,
                    },
                    11 => Waterlogged switch {
                        true => 7749,
                        false => 7750,
                    },
                    12 => Waterlogged switch {
                        true => 7751,
                        false => 7752,
                    },
                    13 => Waterlogged switch {
                        true => 7753,
                        false => 7754,
                    },
                    14 => Waterlogged switch {
                        true => 7755,
                        false => 7756,
                    },
                    15 => Waterlogged switch {
                        true => 7757,
                        false => 7758,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7695 => new AcaciaHangingSignBlock(Identifier, true, 0, true),
            7696 => new AcaciaHangingSignBlock(Identifier, true, 0, false),
            7697 => new AcaciaHangingSignBlock(Identifier, true, 1, true),
            7698 => new AcaciaHangingSignBlock(Identifier, true, 1, false),
            7699 => new AcaciaHangingSignBlock(Identifier, true, 2, true),
            7700 => new AcaciaHangingSignBlock(Identifier, true, 2, false),
            7701 => new AcaciaHangingSignBlock(Identifier, true, 3, true),
            7702 => new AcaciaHangingSignBlock(Identifier, true, 3, false),
            7703 => new AcaciaHangingSignBlock(Identifier, true, 4, true),
            7704 => new AcaciaHangingSignBlock(Identifier, true, 4, false),
            7705 => new AcaciaHangingSignBlock(Identifier, true, 5, true),
            7706 => new AcaciaHangingSignBlock(Identifier, true, 5, false),
            7707 => new AcaciaHangingSignBlock(Identifier, true, 6, true),
            7708 => new AcaciaHangingSignBlock(Identifier, true, 6, false),
            7709 => new AcaciaHangingSignBlock(Identifier, true, 7, true),
            7710 => new AcaciaHangingSignBlock(Identifier, true, 7, false),
            7711 => new AcaciaHangingSignBlock(Identifier, true, 8, true),
            7712 => new AcaciaHangingSignBlock(Identifier, true, 8, false),
            7713 => new AcaciaHangingSignBlock(Identifier, true, 9, true),
            7714 => new AcaciaHangingSignBlock(Identifier, true, 9, false),
            7715 => new AcaciaHangingSignBlock(Identifier, true, 10, true),
            7716 => new AcaciaHangingSignBlock(Identifier, true, 10, false),
            7717 => new AcaciaHangingSignBlock(Identifier, true, 11, true),
            7718 => new AcaciaHangingSignBlock(Identifier, true, 11, false),
            7719 => new AcaciaHangingSignBlock(Identifier, true, 12, true),
            7720 => new AcaciaHangingSignBlock(Identifier, true, 12, false),
            7721 => new AcaciaHangingSignBlock(Identifier, true, 13, true),
            7722 => new AcaciaHangingSignBlock(Identifier, true, 13, false),
            7723 => new AcaciaHangingSignBlock(Identifier, true, 14, true),
            7724 => new AcaciaHangingSignBlock(Identifier, true, 14, false),
            7725 => new AcaciaHangingSignBlock(Identifier, true, 15, true),
            7726 => new AcaciaHangingSignBlock(Identifier, true, 15, false),
            7727 => new AcaciaHangingSignBlock(Identifier, false, 0, true),
            7728 => new AcaciaHangingSignBlock(Identifier, false, 0, false),
            7729 => new AcaciaHangingSignBlock(Identifier, false, 1, true),
            7730 => new AcaciaHangingSignBlock(Identifier, false, 1, false),
            7731 => new AcaciaHangingSignBlock(Identifier, false, 2, true),
            7732 => new AcaciaHangingSignBlock(Identifier, false, 2, false),
            7733 => new AcaciaHangingSignBlock(Identifier, false, 3, true),
            7734 => new AcaciaHangingSignBlock(Identifier, false, 3, false),
            7735 => new AcaciaHangingSignBlock(Identifier, false, 4, true),
            7736 => new AcaciaHangingSignBlock(Identifier, false, 4, false),
            7737 => new AcaciaHangingSignBlock(Identifier, false, 5, true),
            7738 => new AcaciaHangingSignBlock(Identifier, false, 5, false),
            7739 => new AcaciaHangingSignBlock(Identifier, false, 6, true),
            7740 => new AcaciaHangingSignBlock(Identifier, false, 6, false),
            7741 => new AcaciaHangingSignBlock(Identifier, false, 7, true),
            7742 => new AcaciaHangingSignBlock(Identifier, false, 7, false),
            7743 => new AcaciaHangingSignBlock(Identifier, false, 8, true),
            7744 => new AcaciaHangingSignBlock(Identifier, false, 8, false),
            7745 => new AcaciaHangingSignBlock(Identifier, false, 9, true),
            7746 => new AcaciaHangingSignBlock(Identifier, false, 9, false),
            7747 => new AcaciaHangingSignBlock(Identifier, false, 10, true),
            7748 => new AcaciaHangingSignBlock(Identifier, false, 10, false),
            7749 => new AcaciaHangingSignBlock(Identifier, false, 11, true),
            7750 => new AcaciaHangingSignBlock(Identifier, false, 11, false),
            7751 => new AcaciaHangingSignBlock(Identifier, false, 12, true),
            7752 => new AcaciaHangingSignBlock(Identifier, false, 12, false),
            7753 => new AcaciaHangingSignBlock(Identifier, false, 13, true),
            7754 => new AcaciaHangingSignBlock(Identifier, false, 13, false),
            7755 => new AcaciaHangingSignBlock(Identifier, false, 14, true),
            7756 => new AcaciaHangingSignBlock(Identifier, false, 14, false),
            7757 => new AcaciaHangingSignBlock(Identifier, false, 15, true),
            7758 => new AcaciaHangingSignBlock(Identifier, false, 15, false),
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
