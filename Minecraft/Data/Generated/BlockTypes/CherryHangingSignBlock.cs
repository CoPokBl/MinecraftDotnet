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
public record CherryHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:cherry_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 42, "cherry_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7759];

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
                        true => 7759,
                        false => 7760,
                    },
                    1 => Waterlogged switch {
                        true => 7761,
                        false => 7762,
                    },
                    2 => Waterlogged switch {
                        true => 7763,
                        false => 7764,
                    },
                    3 => Waterlogged switch {
                        true => 7765,
                        false => 7766,
                    },
                    4 => Waterlogged switch {
                        true => 7767,
                        false => 7768,
                    },
                    5 => Waterlogged switch {
                        true => 7769,
                        false => 7770,
                    },
                    6 => Waterlogged switch {
                        true => 7771,
                        false => 7772,
                    },
                    7 => Waterlogged switch {
                        true => 7773,
                        false => 7774,
                    },
                    8 => Waterlogged switch {
                        true => 7775,
                        false => 7776,
                    },
                    9 => Waterlogged switch {
                        true => 7777,
                        false => 7778,
                    },
                    10 => Waterlogged switch {
                        true => 7779,
                        false => 7780,
                    },
                    11 => Waterlogged switch {
                        true => 7781,
                        false => 7782,
                    },
                    12 => Waterlogged switch {
                        true => 7783,
                        false => 7784,
                    },
                    13 => Waterlogged switch {
                        true => 7785,
                        false => 7786,
                    },
                    14 => Waterlogged switch {
                        true => 7787,
                        false => 7788,
                    },
                    15 => Waterlogged switch {
                        true => 7789,
                        false => 7790,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7791,
                        false => 7792,
                    },
                    1 => Waterlogged switch {
                        true => 7793,
                        false => 7794,
                    },
                    2 => Waterlogged switch {
                        true => 7795,
                        false => 7796,
                    },
                    3 => Waterlogged switch {
                        true => 7797,
                        false => 7798,
                    },
                    4 => Waterlogged switch {
                        true => 7799,
                        false => 7800,
                    },
                    5 => Waterlogged switch {
                        true => 7801,
                        false => 7802,
                    },
                    6 => Waterlogged switch {
                        true => 7803,
                        false => 7804,
                    },
                    7 => Waterlogged switch {
                        true => 7805,
                        false => 7806,
                    },
                    8 => Waterlogged switch {
                        true => 7807,
                        false => 7808,
                    },
                    9 => Waterlogged switch {
                        true => 7809,
                        false => 7810,
                    },
                    10 => Waterlogged switch {
                        true => 7811,
                        false => 7812,
                    },
                    11 => Waterlogged switch {
                        true => 7813,
                        false => 7814,
                    },
                    12 => Waterlogged switch {
                        true => 7815,
                        false => 7816,
                    },
                    13 => Waterlogged switch {
                        true => 7817,
                        false => 7818,
                    },
                    14 => Waterlogged switch {
                        true => 7819,
                        false => 7820,
                    },
                    15 => Waterlogged switch {
                        true => 7821,
                        false => 7822,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7759 => new CherryHangingSignBlock(Identifier, true, 0, true),
            7760 => new CherryHangingSignBlock(Identifier, true, 0, false),
            7761 => new CherryHangingSignBlock(Identifier, true, 1, true),
            7762 => new CherryHangingSignBlock(Identifier, true, 1, false),
            7763 => new CherryHangingSignBlock(Identifier, true, 2, true),
            7764 => new CherryHangingSignBlock(Identifier, true, 2, false),
            7765 => new CherryHangingSignBlock(Identifier, true, 3, true),
            7766 => new CherryHangingSignBlock(Identifier, true, 3, false),
            7767 => new CherryHangingSignBlock(Identifier, true, 4, true),
            7768 => new CherryHangingSignBlock(Identifier, true, 4, false),
            7769 => new CherryHangingSignBlock(Identifier, true, 5, true),
            7770 => new CherryHangingSignBlock(Identifier, true, 5, false),
            7771 => new CherryHangingSignBlock(Identifier, true, 6, true),
            7772 => new CherryHangingSignBlock(Identifier, true, 6, false),
            7773 => new CherryHangingSignBlock(Identifier, true, 7, true),
            7774 => new CherryHangingSignBlock(Identifier, true, 7, false),
            7775 => new CherryHangingSignBlock(Identifier, true, 8, true),
            7776 => new CherryHangingSignBlock(Identifier, true, 8, false),
            7777 => new CherryHangingSignBlock(Identifier, true, 9, true),
            7778 => new CherryHangingSignBlock(Identifier, true, 9, false),
            7779 => new CherryHangingSignBlock(Identifier, true, 10, true),
            7780 => new CherryHangingSignBlock(Identifier, true, 10, false),
            7781 => new CherryHangingSignBlock(Identifier, true, 11, true),
            7782 => new CherryHangingSignBlock(Identifier, true, 11, false),
            7783 => new CherryHangingSignBlock(Identifier, true, 12, true),
            7784 => new CherryHangingSignBlock(Identifier, true, 12, false),
            7785 => new CherryHangingSignBlock(Identifier, true, 13, true),
            7786 => new CherryHangingSignBlock(Identifier, true, 13, false),
            7787 => new CherryHangingSignBlock(Identifier, true, 14, true),
            7788 => new CherryHangingSignBlock(Identifier, true, 14, false),
            7789 => new CherryHangingSignBlock(Identifier, true, 15, true),
            7790 => new CherryHangingSignBlock(Identifier, true, 15, false),
            7791 => new CherryHangingSignBlock(Identifier, false, 0, true),
            7792 => new CherryHangingSignBlock(Identifier, false, 0, false),
            7793 => new CherryHangingSignBlock(Identifier, false, 1, true),
            7794 => new CherryHangingSignBlock(Identifier, false, 1, false),
            7795 => new CherryHangingSignBlock(Identifier, false, 2, true),
            7796 => new CherryHangingSignBlock(Identifier, false, 2, false),
            7797 => new CherryHangingSignBlock(Identifier, false, 3, true),
            7798 => new CherryHangingSignBlock(Identifier, false, 3, false),
            7799 => new CherryHangingSignBlock(Identifier, false, 4, true),
            7800 => new CherryHangingSignBlock(Identifier, false, 4, false),
            7801 => new CherryHangingSignBlock(Identifier, false, 5, true),
            7802 => new CherryHangingSignBlock(Identifier, false, 5, false),
            7803 => new CherryHangingSignBlock(Identifier, false, 6, true),
            7804 => new CherryHangingSignBlock(Identifier, false, 6, false),
            7805 => new CherryHangingSignBlock(Identifier, false, 7, true),
            7806 => new CherryHangingSignBlock(Identifier, false, 7, false),
            7807 => new CherryHangingSignBlock(Identifier, false, 8, true),
            7808 => new CherryHangingSignBlock(Identifier, false, 8, false),
            7809 => new CherryHangingSignBlock(Identifier, false, 9, true),
            7810 => new CherryHangingSignBlock(Identifier, false, 9, false),
            7811 => new CherryHangingSignBlock(Identifier, false, 10, true),
            7812 => new CherryHangingSignBlock(Identifier, false, 10, false),
            7813 => new CherryHangingSignBlock(Identifier, false, 11, true),
            7814 => new CherryHangingSignBlock(Identifier, false, 11, false),
            7815 => new CherryHangingSignBlock(Identifier, false, 12, true),
            7816 => new CherryHangingSignBlock(Identifier, false, 12, false),
            7817 => new CherryHangingSignBlock(Identifier, false, 13, true),
            7818 => new CherryHangingSignBlock(Identifier, false, 13, false),
            7819 => new CherryHangingSignBlock(Identifier, false, 14, true),
            7820 => new CherryHangingSignBlock(Identifier, false, 14, false),
            7821 => new CherryHangingSignBlock(Identifier, false, 15, true),
            7822 => new CherryHangingSignBlock(Identifier, false, 15, false),
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
