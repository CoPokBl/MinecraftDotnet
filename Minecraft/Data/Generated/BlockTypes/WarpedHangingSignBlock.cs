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
    private static readonly BlockInfo Data = new("block.minecraft.warped_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:warped_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/warped_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 56, "nether_wood_hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 8079];

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
                        true => 8079,
                        false => 8080,
                    },
                    1 => Waterlogged switch {
                        true => 8081,
                        false => 8082,
                    },
                    2 => Waterlogged switch {
                        true => 8083,
                        false => 8084,
                    },
                    3 => Waterlogged switch {
                        true => 8085,
                        false => 8086,
                    },
                    4 => Waterlogged switch {
                        true => 8087,
                        false => 8088,
                    },
                    5 => Waterlogged switch {
                        true => 8089,
                        false => 8090,
                    },
                    6 => Waterlogged switch {
                        true => 8091,
                        false => 8092,
                    },
                    7 => Waterlogged switch {
                        true => 8093,
                        false => 8094,
                    },
                    8 => Waterlogged switch {
                        true => 8095,
                        false => 8096,
                    },
                    9 => Waterlogged switch {
                        true => 8097,
                        false => 8098,
                    },
                    10 => Waterlogged switch {
                        true => 8099,
                        false => 8100,
                    },
                    11 => Waterlogged switch {
                        true => 8101,
                        false => 8102,
                    },
                    12 => Waterlogged switch {
                        true => 8103,
                        false => 8104,
                    },
                    13 => Waterlogged switch {
                        true => 8105,
                        false => 8106,
                    },
                    14 => Waterlogged switch {
                        true => 8107,
                        false => 8108,
                    },
                    15 => Waterlogged switch {
                        true => 8109,
                        false => 8110,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 8111,
                        false => 8112,
                    },
                    1 => Waterlogged switch {
                        true => 8113,
                        false => 8114,
                    },
                    2 => Waterlogged switch {
                        true => 8115,
                        false => 8116,
                    },
                    3 => Waterlogged switch {
                        true => 8117,
                        false => 8118,
                    },
                    4 => Waterlogged switch {
                        true => 8119,
                        false => 8120,
                    },
                    5 => Waterlogged switch {
                        true => 8121,
                        false => 8122,
                    },
                    6 => Waterlogged switch {
                        true => 8123,
                        false => 8124,
                    },
                    7 => Waterlogged switch {
                        true => 8125,
                        false => 8126,
                    },
                    8 => Waterlogged switch {
                        true => 8127,
                        false => 8128,
                    },
                    9 => Waterlogged switch {
                        true => 8129,
                        false => 8130,
                    },
                    10 => Waterlogged switch {
                        true => 8131,
                        false => 8132,
                    },
                    11 => Waterlogged switch {
                        true => 8133,
                        false => 8134,
                    },
                    12 => Waterlogged switch {
                        true => 8135,
                        false => 8136,
                    },
                    13 => Waterlogged switch {
                        true => 8137,
                        false => 8138,
                    },
                    14 => Waterlogged switch {
                        true => 8139,
                        false => 8140,
                    },
                    15 => Waterlogged switch {
                        true => 8141,
                        false => 8142,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8079 => new WarpedHangingSignBlock(Identifier, true, 0, true),
            8080 => new WarpedHangingSignBlock(Identifier, true, 0, false),
            8081 => new WarpedHangingSignBlock(Identifier, true, 1, true),
            8082 => new WarpedHangingSignBlock(Identifier, true, 1, false),
            8083 => new WarpedHangingSignBlock(Identifier, true, 2, true),
            8084 => new WarpedHangingSignBlock(Identifier, true, 2, false),
            8085 => new WarpedHangingSignBlock(Identifier, true, 3, true),
            8086 => new WarpedHangingSignBlock(Identifier, true, 3, false),
            8087 => new WarpedHangingSignBlock(Identifier, true, 4, true),
            8088 => new WarpedHangingSignBlock(Identifier, true, 4, false),
            8089 => new WarpedHangingSignBlock(Identifier, true, 5, true),
            8090 => new WarpedHangingSignBlock(Identifier, true, 5, false),
            8091 => new WarpedHangingSignBlock(Identifier, true, 6, true),
            8092 => new WarpedHangingSignBlock(Identifier, true, 6, false),
            8093 => new WarpedHangingSignBlock(Identifier, true, 7, true),
            8094 => new WarpedHangingSignBlock(Identifier, true, 7, false),
            8095 => new WarpedHangingSignBlock(Identifier, true, 8, true),
            8096 => new WarpedHangingSignBlock(Identifier, true, 8, false),
            8097 => new WarpedHangingSignBlock(Identifier, true, 9, true),
            8098 => new WarpedHangingSignBlock(Identifier, true, 9, false),
            8099 => new WarpedHangingSignBlock(Identifier, true, 10, true),
            8100 => new WarpedHangingSignBlock(Identifier, true, 10, false),
            8101 => new WarpedHangingSignBlock(Identifier, true, 11, true),
            8102 => new WarpedHangingSignBlock(Identifier, true, 11, false),
            8103 => new WarpedHangingSignBlock(Identifier, true, 12, true),
            8104 => new WarpedHangingSignBlock(Identifier, true, 12, false),
            8105 => new WarpedHangingSignBlock(Identifier, true, 13, true),
            8106 => new WarpedHangingSignBlock(Identifier, true, 13, false),
            8107 => new WarpedHangingSignBlock(Identifier, true, 14, true),
            8108 => new WarpedHangingSignBlock(Identifier, true, 14, false),
            8109 => new WarpedHangingSignBlock(Identifier, true, 15, true),
            8110 => new WarpedHangingSignBlock(Identifier, true, 15, false),
            8111 => new WarpedHangingSignBlock(Identifier, false, 0, true),
            8112 => new WarpedHangingSignBlock(Identifier, false, 0, false),
            8113 => new WarpedHangingSignBlock(Identifier, false, 1, true),
            8114 => new WarpedHangingSignBlock(Identifier, false, 1, false),
            8115 => new WarpedHangingSignBlock(Identifier, false, 2, true),
            8116 => new WarpedHangingSignBlock(Identifier, false, 2, false),
            8117 => new WarpedHangingSignBlock(Identifier, false, 3, true),
            8118 => new WarpedHangingSignBlock(Identifier, false, 3, false),
            8119 => new WarpedHangingSignBlock(Identifier, false, 4, true),
            8120 => new WarpedHangingSignBlock(Identifier, false, 4, false),
            8121 => new WarpedHangingSignBlock(Identifier, false, 5, true),
            8122 => new WarpedHangingSignBlock(Identifier, false, 5, false),
            8123 => new WarpedHangingSignBlock(Identifier, false, 6, true),
            8124 => new WarpedHangingSignBlock(Identifier, false, 6, false),
            8125 => new WarpedHangingSignBlock(Identifier, false, 7, true),
            8126 => new WarpedHangingSignBlock(Identifier, false, 7, false),
            8127 => new WarpedHangingSignBlock(Identifier, false, 8, true),
            8128 => new WarpedHangingSignBlock(Identifier, false, 8, false),
            8129 => new WarpedHangingSignBlock(Identifier, false, 9, true),
            8130 => new WarpedHangingSignBlock(Identifier, false, 9, false),
            8131 => new WarpedHangingSignBlock(Identifier, false, 10, true),
            8132 => new WarpedHangingSignBlock(Identifier, false, 10, false),
            8133 => new WarpedHangingSignBlock(Identifier, false, 11, true),
            8134 => new WarpedHangingSignBlock(Identifier, false, 11, false),
            8135 => new WarpedHangingSignBlock(Identifier, false, 12, true),
            8136 => new WarpedHangingSignBlock(Identifier, false, 12, false),
            8137 => new WarpedHangingSignBlock(Identifier, false, 13, true),
            8138 => new WarpedHangingSignBlock(Identifier, false, 13, false),
            8139 => new WarpedHangingSignBlock(Identifier, false, 14, true),
            8140 => new WarpedHangingSignBlock(Identifier, false, 14, false),
            8141 => new WarpedHangingSignBlock(Identifier, false, 15, true),
            8142 => new WarpedHangingSignBlock(Identifier, false, 15, false),
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
