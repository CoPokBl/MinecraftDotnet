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
    private static readonly BlockInfo Data = new("block.minecraft.crimson_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:crimson_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 53, "nether_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8015];

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
                        true => 8015,
                        false => 8016,
                    },
                    1 => Waterlogged switch {
                        true => 8017,
                        false => 8018,
                    },
                    2 => Waterlogged switch {
                        true => 8019,
                        false => 8020,
                    },
                    3 => Waterlogged switch {
                        true => 8021,
                        false => 8022,
                    },
                    4 => Waterlogged switch {
                        true => 8023,
                        false => 8024,
                    },
                    5 => Waterlogged switch {
                        true => 8025,
                        false => 8026,
                    },
                    6 => Waterlogged switch {
                        true => 8027,
                        false => 8028,
                    },
                    7 => Waterlogged switch {
                        true => 8029,
                        false => 8030,
                    },
                    8 => Waterlogged switch {
                        true => 8031,
                        false => 8032,
                    },
                    9 => Waterlogged switch {
                        true => 8033,
                        false => 8034,
                    },
                    10 => Waterlogged switch {
                        true => 8035,
                        false => 8036,
                    },
                    11 => Waterlogged switch {
                        true => 8037,
                        false => 8038,
                    },
                    12 => Waterlogged switch {
                        true => 8039,
                        false => 8040,
                    },
                    13 => Waterlogged switch {
                        true => 8041,
                        false => 8042,
                    },
                    14 => Waterlogged switch {
                        true => 8043,
                        false => 8044,
                    },
                    15 => Waterlogged switch {
                        true => 8045,
                        false => 8046,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 8047,
                        false => 8048,
                    },
                    1 => Waterlogged switch {
                        true => 8049,
                        false => 8050,
                    },
                    2 => Waterlogged switch {
                        true => 8051,
                        false => 8052,
                    },
                    3 => Waterlogged switch {
                        true => 8053,
                        false => 8054,
                    },
                    4 => Waterlogged switch {
                        true => 8055,
                        false => 8056,
                    },
                    5 => Waterlogged switch {
                        true => 8057,
                        false => 8058,
                    },
                    6 => Waterlogged switch {
                        true => 8059,
                        false => 8060,
                    },
                    7 => Waterlogged switch {
                        true => 8061,
                        false => 8062,
                    },
                    8 => Waterlogged switch {
                        true => 8063,
                        false => 8064,
                    },
                    9 => Waterlogged switch {
                        true => 8065,
                        false => 8066,
                    },
                    10 => Waterlogged switch {
                        true => 8067,
                        false => 8068,
                    },
                    11 => Waterlogged switch {
                        true => 8069,
                        false => 8070,
                    },
                    12 => Waterlogged switch {
                        true => 8071,
                        false => 8072,
                    },
                    13 => Waterlogged switch {
                        true => 8073,
                        false => 8074,
                    },
                    14 => Waterlogged switch {
                        true => 8075,
                        false => 8076,
                    },
                    15 => Waterlogged switch {
                        true => 8077,
                        false => 8078,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8015 => new CrimsonHangingSignBlock(Identifier, true, 0, true),
            8016 => new CrimsonHangingSignBlock(Identifier, true, 0, false),
            8017 => new CrimsonHangingSignBlock(Identifier, true, 1, true),
            8018 => new CrimsonHangingSignBlock(Identifier, true, 1, false),
            8019 => new CrimsonHangingSignBlock(Identifier, true, 2, true),
            8020 => new CrimsonHangingSignBlock(Identifier, true, 2, false),
            8021 => new CrimsonHangingSignBlock(Identifier, true, 3, true),
            8022 => new CrimsonHangingSignBlock(Identifier, true, 3, false),
            8023 => new CrimsonHangingSignBlock(Identifier, true, 4, true),
            8024 => new CrimsonHangingSignBlock(Identifier, true, 4, false),
            8025 => new CrimsonHangingSignBlock(Identifier, true, 5, true),
            8026 => new CrimsonHangingSignBlock(Identifier, true, 5, false),
            8027 => new CrimsonHangingSignBlock(Identifier, true, 6, true),
            8028 => new CrimsonHangingSignBlock(Identifier, true, 6, false),
            8029 => new CrimsonHangingSignBlock(Identifier, true, 7, true),
            8030 => new CrimsonHangingSignBlock(Identifier, true, 7, false),
            8031 => new CrimsonHangingSignBlock(Identifier, true, 8, true),
            8032 => new CrimsonHangingSignBlock(Identifier, true, 8, false),
            8033 => new CrimsonHangingSignBlock(Identifier, true, 9, true),
            8034 => new CrimsonHangingSignBlock(Identifier, true, 9, false),
            8035 => new CrimsonHangingSignBlock(Identifier, true, 10, true),
            8036 => new CrimsonHangingSignBlock(Identifier, true, 10, false),
            8037 => new CrimsonHangingSignBlock(Identifier, true, 11, true),
            8038 => new CrimsonHangingSignBlock(Identifier, true, 11, false),
            8039 => new CrimsonHangingSignBlock(Identifier, true, 12, true),
            8040 => new CrimsonHangingSignBlock(Identifier, true, 12, false),
            8041 => new CrimsonHangingSignBlock(Identifier, true, 13, true),
            8042 => new CrimsonHangingSignBlock(Identifier, true, 13, false),
            8043 => new CrimsonHangingSignBlock(Identifier, true, 14, true),
            8044 => new CrimsonHangingSignBlock(Identifier, true, 14, false),
            8045 => new CrimsonHangingSignBlock(Identifier, true, 15, true),
            8046 => new CrimsonHangingSignBlock(Identifier, true, 15, false),
            8047 => new CrimsonHangingSignBlock(Identifier, false, 0, true),
            8048 => new CrimsonHangingSignBlock(Identifier, false, 0, false),
            8049 => new CrimsonHangingSignBlock(Identifier, false, 1, true),
            8050 => new CrimsonHangingSignBlock(Identifier, false, 1, false),
            8051 => new CrimsonHangingSignBlock(Identifier, false, 2, true),
            8052 => new CrimsonHangingSignBlock(Identifier, false, 2, false),
            8053 => new CrimsonHangingSignBlock(Identifier, false, 3, true),
            8054 => new CrimsonHangingSignBlock(Identifier, false, 3, false),
            8055 => new CrimsonHangingSignBlock(Identifier, false, 4, true),
            8056 => new CrimsonHangingSignBlock(Identifier, false, 4, false),
            8057 => new CrimsonHangingSignBlock(Identifier, false, 5, true),
            8058 => new CrimsonHangingSignBlock(Identifier, false, 5, false),
            8059 => new CrimsonHangingSignBlock(Identifier, false, 6, true),
            8060 => new CrimsonHangingSignBlock(Identifier, false, 6, false),
            8061 => new CrimsonHangingSignBlock(Identifier, false, 7, true),
            8062 => new CrimsonHangingSignBlock(Identifier, false, 7, false),
            8063 => new CrimsonHangingSignBlock(Identifier, false, 8, true),
            8064 => new CrimsonHangingSignBlock(Identifier, false, 8, false),
            8065 => new CrimsonHangingSignBlock(Identifier, false, 9, true),
            8066 => new CrimsonHangingSignBlock(Identifier, false, 9, false),
            8067 => new CrimsonHangingSignBlock(Identifier, false, 10, true),
            8068 => new CrimsonHangingSignBlock(Identifier, false, 10, false),
            8069 => new CrimsonHangingSignBlock(Identifier, false, 11, true),
            8070 => new CrimsonHangingSignBlock(Identifier, false, 11, false),
            8071 => new CrimsonHangingSignBlock(Identifier, false, 12, true),
            8072 => new CrimsonHangingSignBlock(Identifier, false, 12, false),
            8073 => new CrimsonHangingSignBlock(Identifier, false, 13, true),
            8074 => new CrimsonHangingSignBlock(Identifier, false, 13, false),
            8075 => new CrimsonHangingSignBlock(Identifier, false, 14, true),
            8076 => new CrimsonHangingSignBlock(Identifier, false, 14, false),
            8077 => new CrimsonHangingSignBlock(Identifier, false, 15, true),
            8078 => new CrimsonHangingSignBlock(Identifier, false, 15, false),
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
