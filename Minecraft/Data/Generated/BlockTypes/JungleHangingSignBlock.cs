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
public record JungleHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.jungle_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:jungle_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 10, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7823];

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
                        true => 7823,
                        false => 7824,
                    },
                    1 => Waterlogged switch {
                        true => 7825,
                        false => 7826,
                    },
                    2 => Waterlogged switch {
                        true => 7827,
                        false => 7828,
                    },
                    3 => Waterlogged switch {
                        true => 7829,
                        false => 7830,
                    },
                    4 => Waterlogged switch {
                        true => 7831,
                        false => 7832,
                    },
                    5 => Waterlogged switch {
                        true => 7833,
                        false => 7834,
                    },
                    6 => Waterlogged switch {
                        true => 7835,
                        false => 7836,
                    },
                    7 => Waterlogged switch {
                        true => 7837,
                        false => 7838,
                    },
                    8 => Waterlogged switch {
                        true => 7839,
                        false => 7840,
                    },
                    9 => Waterlogged switch {
                        true => 7841,
                        false => 7842,
                    },
                    10 => Waterlogged switch {
                        true => 7843,
                        false => 7844,
                    },
                    11 => Waterlogged switch {
                        true => 7845,
                        false => 7846,
                    },
                    12 => Waterlogged switch {
                        true => 7847,
                        false => 7848,
                    },
                    13 => Waterlogged switch {
                        true => 7849,
                        false => 7850,
                    },
                    14 => Waterlogged switch {
                        true => 7851,
                        false => 7852,
                    },
                    15 => Waterlogged switch {
                        true => 7853,
                        false => 7854,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7855,
                        false => 7856,
                    },
                    1 => Waterlogged switch {
                        true => 7857,
                        false => 7858,
                    },
                    2 => Waterlogged switch {
                        true => 7859,
                        false => 7860,
                    },
                    3 => Waterlogged switch {
                        true => 7861,
                        false => 7862,
                    },
                    4 => Waterlogged switch {
                        true => 7863,
                        false => 7864,
                    },
                    5 => Waterlogged switch {
                        true => 7865,
                        false => 7866,
                    },
                    6 => Waterlogged switch {
                        true => 7867,
                        false => 7868,
                    },
                    7 => Waterlogged switch {
                        true => 7869,
                        false => 7870,
                    },
                    8 => Waterlogged switch {
                        true => 7871,
                        false => 7872,
                    },
                    9 => Waterlogged switch {
                        true => 7873,
                        false => 7874,
                    },
                    10 => Waterlogged switch {
                        true => 7875,
                        false => 7876,
                    },
                    11 => Waterlogged switch {
                        true => 7877,
                        false => 7878,
                    },
                    12 => Waterlogged switch {
                        true => 7879,
                        false => 7880,
                    },
                    13 => Waterlogged switch {
                        true => 7881,
                        false => 7882,
                    },
                    14 => Waterlogged switch {
                        true => 7883,
                        false => 7884,
                    },
                    15 => Waterlogged switch {
                        true => 7885,
                        false => 7886,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7823 => new JungleHangingSignBlock(Identifier, true, 0, true),
            7824 => new JungleHangingSignBlock(Identifier, true, 0, false),
            7825 => new JungleHangingSignBlock(Identifier, true, 1, true),
            7826 => new JungleHangingSignBlock(Identifier, true, 1, false),
            7827 => new JungleHangingSignBlock(Identifier, true, 2, true),
            7828 => new JungleHangingSignBlock(Identifier, true, 2, false),
            7829 => new JungleHangingSignBlock(Identifier, true, 3, true),
            7830 => new JungleHangingSignBlock(Identifier, true, 3, false),
            7831 => new JungleHangingSignBlock(Identifier, true, 4, true),
            7832 => new JungleHangingSignBlock(Identifier, true, 4, false),
            7833 => new JungleHangingSignBlock(Identifier, true, 5, true),
            7834 => new JungleHangingSignBlock(Identifier, true, 5, false),
            7835 => new JungleHangingSignBlock(Identifier, true, 6, true),
            7836 => new JungleHangingSignBlock(Identifier, true, 6, false),
            7837 => new JungleHangingSignBlock(Identifier, true, 7, true),
            7838 => new JungleHangingSignBlock(Identifier, true, 7, false),
            7839 => new JungleHangingSignBlock(Identifier, true, 8, true),
            7840 => new JungleHangingSignBlock(Identifier, true, 8, false),
            7841 => new JungleHangingSignBlock(Identifier, true, 9, true),
            7842 => new JungleHangingSignBlock(Identifier, true, 9, false),
            7843 => new JungleHangingSignBlock(Identifier, true, 10, true),
            7844 => new JungleHangingSignBlock(Identifier, true, 10, false),
            7845 => new JungleHangingSignBlock(Identifier, true, 11, true),
            7846 => new JungleHangingSignBlock(Identifier, true, 11, false),
            7847 => new JungleHangingSignBlock(Identifier, true, 12, true),
            7848 => new JungleHangingSignBlock(Identifier, true, 12, false),
            7849 => new JungleHangingSignBlock(Identifier, true, 13, true),
            7850 => new JungleHangingSignBlock(Identifier, true, 13, false),
            7851 => new JungleHangingSignBlock(Identifier, true, 14, true),
            7852 => new JungleHangingSignBlock(Identifier, true, 14, false),
            7853 => new JungleHangingSignBlock(Identifier, true, 15, true),
            7854 => new JungleHangingSignBlock(Identifier, true, 15, false),
            7855 => new JungleHangingSignBlock(Identifier, false, 0, true),
            7856 => new JungleHangingSignBlock(Identifier, false, 0, false),
            7857 => new JungleHangingSignBlock(Identifier, false, 1, true),
            7858 => new JungleHangingSignBlock(Identifier, false, 1, false),
            7859 => new JungleHangingSignBlock(Identifier, false, 2, true),
            7860 => new JungleHangingSignBlock(Identifier, false, 2, false),
            7861 => new JungleHangingSignBlock(Identifier, false, 3, true),
            7862 => new JungleHangingSignBlock(Identifier, false, 3, false),
            7863 => new JungleHangingSignBlock(Identifier, false, 4, true),
            7864 => new JungleHangingSignBlock(Identifier, false, 4, false),
            7865 => new JungleHangingSignBlock(Identifier, false, 5, true),
            7866 => new JungleHangingSignBlock(Identifier, false, 5, false),
            7867 => new JungleHangingSignBlock(Identifier, false, 6, true),
            7868 => new JungleHangingSignBlock(Identifier, false, 6, false),
            7869 => new JungleHangingSignBlock(Identifier, false, 7, true),
            7870 => new JungleHangingSignBlock(Identifier, false, 7, false),
            7871 => new JungleHangingSignBlock(Identifier, false, 8, true),
            7872 => new JungleHangingSignBlock(Identifier, false, 8, false),
            7873 => new JungleHangingSignBlock(Identifier, false, 9, true),
            7874 => new JungleHangingSignBlock(Identifier, false, 9, false),
            7875 => new JungleHangingSignBlock(Identifier, false, 10, true),
            7876 => new JungleHangingSignBlock(Identifier, false, 10, false),
            7877 => new JungleHangingSignBlock(Identifier, false, 11, true),
            7878 => new JungleHangingSignBlock(Identifier, false, 11, false),
            7879 => new JungleHangingSignBlock(Identifier, false, 12, true),
            7880 => new JungleHangingSignBlock(Identifier, false, 12, false),
            7881 => new JungleHangingSignBlock(Identifier, false, 13, true),
            7882 => new JungleHangingSignBlock(Identifier, false, 13, false),
            7883 => new JungleHangingSignBlock(Identifier, false, 14, true),
            7884 => new JungleHangingSignBlock(Identifier, false, 14, false),
            7885 => new JungleHangingSignBlock(Identifier, false, 15, true),
            7886 => new JungleHangingSignBlock(Identifier, false, 15, false),
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
