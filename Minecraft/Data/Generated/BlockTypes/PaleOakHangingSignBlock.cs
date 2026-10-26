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
public record PaleOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:pale_oak_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 14, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7951];

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
                        true => 7951,
                        false => 7952,
                    },
                    1 => Waterlogged switch {
                        true => 7953,
                        false => 7954,
                    },
                    2 => Waterlogged switch {
                        true => 7955,
                        false => 7956,
                    },
                    3 => Waterlogged switch {
                        true => 7957,
                        false => 7958,
                    },
                    4 => Waterlogged switch {
                        true => 7959,
                        false => 7960,
                    },
                    5 => Waterlogged switch {
                        true => 7961,
                        false => 7962,
                    },
                    6 => Waterlogged switch {
                        true => 7963,
                        false => 7964,
                    },
                    7 => Waterlogged switch {
                        true => 7965,
                        false => 7966,
                    },
                    8 => Waterlogged switch {
                        true => 7967,
                        false => 7968,
                    },
                    9 => Waterlogged switch {
                        true => 7969,
                        false => 7970,
                    },
                    10 => Waterlogged switch {
                        true => 7971,
                        false => 7972,
                    },
                    11 => Waterlogged switch {
                        true => 7973,
                        false => 7974,
                    },
                    12 => Waterlogged switch {
                        true => 7975,
                        false => 7976,
                    },
                    13 => Waterlogged switch {
                        true => 7977,
                        false => 7978,
                    },
                    14 => Waterlogged switch {
                        true => 7979,
                        false => 7980,
                    },
                    15 => Waterlogged switch {
                        true => 7981,
                        false => 7982,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7983,
                        false => 7984,
                    },
                    1 => Waterlogged switch {
                        true => 7985,
                        false => 7986,
                    },
                    2 => Waterlogged switch {
                        true => 7987,
                        false => 7988,
                    },
                    3 => Waterlogged switch {
                        true => 7989,
                        false => 7990,
                    },
                    4 => Waterlogged switch {
                        true => 7991,
                        false => 7992,
                    },
                    5 => Waterlogged switch {
                        true => 7993,
                        false => 7994,
                    },
                    6 => Waterlogged switch {
                        true => 7995,
                        false => 7996,
                    },
                    7 => Waterlogged switch {
                        true => 7997,
                        false => 7998,
                    },
                    8 => Waterlogged switch {
                        true => 7999,
                        false => 8000,
                    },
                    9 => Waterlogged switch {
                        true => 8001,
                        false => 8002,
                    },
                    10 => Waterlogged switch {
                        true => 8003,
                        false => 8004,
                    },
                    11 => Waterlogged switch {
                        true => 8005,
                        false => 8006,
                    },
                    12 => Waterlogged switch {
                        true => 8007,
                        false => 8008,
                    },
                    13 => Waterlogged switch {
                        true => 8009,
                        false => 8010,
                    },
                    14 => Waterlogged switch {
                        true => 8011,
                        false => 8012,
                    },
                    15 => Waterlogged switch {
                        true => 8013,
                        false => 8014,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7951 => new PaleOakHangingSignBlock(Identifier, true, 0, true),
            7952 => new PaleOakHangingSignBlock(Identifier, true, 0, false),
            7953 => new PaleOakHangingSignBlock(Identifier, true, 1, true),
            7954 => new PaleOakHangingSignBlock(Identifier, true, 1, false),
            7955 => new PaleOakHangingSignBlock(Identifier, true, 2, true),
            7956 => new PaleOakHangingSignBlock(Identifier, true, 2, false),
            7957 => new PaleOakHangingSignBlock(Identifier, true, 3, true),
            7958 => new PaleOakHangingSignBlock(Identifier, true, 3, false),
            7959 => new PaleOakHangingSignBlock(Identifier, true, 4, true),
            7960 => new PaleOakHangingSignBlock(Identifier, true, 4, false),
            7961 => new PaleOakHangingSignBlock(Identifier, true, 5, true),
            7962 => new PaleOakHangingSignBlock(Identifier, true, 5, false),
            7963 => new PaleOakHangingSignBlock(Identifier, true, 6, true),
            7964 => new PaleOakHangingSignBlock(Identifier, true, 6, false),
            7965 => new PaleOakHangingSignBlock(Identifier, true, 7, true),
            7966 => new PaleOakHangingSignBlock(Identifier, true, 7, false),
            7967 => new PaleOakHangingSignBlock(Identifier, true, 8, true),
            7968 => new PaleOakHangingSignBlock(Identifier, true, 8, false),
            7969 => new PaleOakHangingSignBlock(Identifier, true, 9, true),
            7970 => new PaleOakHangingSignBlock(Identifier, true, 9, false),
            7971 => new PaleOakHangingSignBlock(Identifier, true, 10, true),
            7972 => new PaleOakHangingSignBlock(Identifier, true, 10, false),
            7973 => new PaleOakHangingSignBlock(Identifier, true, 11, true),
            7974 => new PaleOakHangingSignBlock(Identifier, true, 11, false),
            7975 => new PaleOakHangingSignBlock(Identifier, true, 12, true),
            7976 => new PaleOakHangingSignBlock(Identifier, true, 12, false),
            7977 => new PaleOakHangingSignBlock(Identifier, true, 13, true),
            7978 => new PaleOakHangingSignBlock(Identifier, true, 13, false),
            7979 => new PaleOakHangingSignBlock(Identifier, true, 14, true),
            7980 => new PaleOakHangingSignBlock(Identifier, true, 14, false),
            7981 => new PaleOakHangingSignBlock(Identifier, true, 15, true),
            7982 => new PaleOakHangingSignBlock(Identifier, true, 15, false),
            7983 => new PaleOakHangingSignBlock(Identifier, false, 0, true),
            7984 => new PaleOakHangingSignBlock(Identifier, false, 0, false),
            7985 => new PaleOakHangingSignBlock(Identifier, false, 1, true),
            7986 => new PaleOakHangingSignBlock(Identifier, false, 1, false),
            7987 => new PaleOakHangingSignBlock(Identifier, false, 2, true),
            7988 => new PaleOakHangingSignBlock(Identifier, false, 2, false),
            7989 => new PaleOakHangingSignBlock(Identifier, false, 3, true),
            7990 => new PaleOakHangingSignBlock(Identifier, false, 3, false),
            7991 => new PaleOakHangingSignBlock(Identifier, false, 4, true),
            7992 => new PaleOakHangingSignBlock(Identifier, false, 4, false),
            7993 => new PaleOakHangingSignBlock(Identifier, false, 5, true),
            7994 => new PaleOakHangingSignBlock(Identifier, false, 5, false),
            7995 => new PaleOakHangingSignBlock(Identifier, false, 6, true),
            7996 => new PaleOakHangingSignBlock(Identifier, false, 6, false),
            7997 => new PaleOakHangingSignBlock(Identifier, false, 7, true),
            7998 => new PaleOakHangingSignBlock(Identifier, false, 7, false),
            7999 => new PaleOakHangingSignBlock(Identifier, false, 8, true),
            8000 => new PaleOakHangingSignBlock(Identifier, false, 8, false),
            8001 => new PaleOakHangingSignBlock(Identifier, false, 9, true),
            8002 => new PaleOakHangingSignBlock(Identifier, false, 9, false),
            8003 => new PaleOakHangingSignBlock(Identifier, false, 10, true),
            8004 => new PaleOakHangingSignBlock(Identifier, false, 10, false),
            8005 => new PaleOakHangingSignBlock(Identifier, false, 11, true),
            8006 => new PaleOakHangingSignBlock(Identifier, false, 11, false),
            8007 => new PaleOakHangingSignBlock(Identifier, false, 12, true),
            8008 => new PaleOakHangingSignBlock(Identifier, false, 12, false),
            8009 => new PaleOakHangingSignBlock(Identifier, false, 13, true),
            8010 => new PaleOakHangingSignBlock(Identifier, false, 13, false),
            8011 => new PaleOakHangingSignBlock(Identifier, false, 14, true),
            8012 => new PaleOakHangingSignBlock(Identifier, false, 14, false),
            8013 => new PaleOakHangingSignBlock(Identifier, false, 15, true),
            8014 => new PaleOakHangingSignBlock(Identifier, false, 15, false),
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
