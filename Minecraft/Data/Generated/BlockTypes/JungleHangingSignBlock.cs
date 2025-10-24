using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 238;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:jungle_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6026,
                        false => 6027,
                    },
                    1 => Waterlogged switch {
                        true => 6028,
                        false => 6029,
                    },
                    2 => Waterlogged switch {
                        true => 6030,
                        false => 6031,
                    },
                    3 => Waterlogged switch {
                        true => 6032,
                        false => 6033,
                    },
                    4 => Waterlogged switch {
                        true => 6034,
                        false => 6035,
                    },
                    5 => Waterlogged switch {
                        true => 6036,
                        false => 6037,
                    },
                    6 => Waterlogged switch {
                        true => 6038,
                        false => 6039,
                    },
                    7 => Waterlogged switch {
                        true => 6040,
                        false => 6041,
                    },
                    8 => Waterlogged switch {
                        true => 6042,
                        false => 6043,
                    },
                    9 => Waterlogged switch {
                        true => 6044,
                        false => 6045,
                    },
                    10 => Waterlogged switch {
                        true => 6046,
                        false => 6047,
                    },
                    11 => Waterlogged switch {
                        true => 6048,
                        false => 6049,
                    },
                    12 => Waterlogged switch {
                        true => 6050,
                        false => 6051,
                    },
                    13 => Waterlogged switch {
                        true => 6052,
                        false => 6053,
                    },
                    14 => Waterlogged switch {
                        true => 6054,
                        false => 6055,
                    },
                    15 => Waterlogged switch {
                        true => 6056,
                        false => 6057,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6058,
                        false => 6059,
                    },
                    1 => Waterlogged switch {
                        true => 6060,
                        false => 6061,
                    },
                    2 => Waterlogged switch {
                        true => 6062,
                        false => 6063,
                    },
                    3 => Waterlogged switch {
                        true => 6064,
                        false => 6065,
                    },
                    4 => Waterlogged switch {
                        true => 6066,
                        false => 6067,
                    },
                    5 => Waterlogged switch {
                        true => 6068,
                        false => 6069,
                    },
                    6 => Waterlogged switch {
                        true => 6070,
                        false => 6071,
                    },
                    7 => Waterlogged switch {
                        true => 6072,
                        false => 6073,
                    },
                    8 => Waterlogged switch {
                        true => 6074,
                        false => 6075,
                    },
                    9 => Waterlogged switch {
                        true => 6076,
                        false => 6077,
                    },
                    10 => Waterlogged switch {
                        true => 6078,
                        false => 6079,
                    },
                    11 => Waterlogged switch {
                        true => 6080,
                        false => 6081,
                    },
                    12 => Waterlogged switch {
                        true => 6082,
                        false => 6083,
                    },
                    13 => Waterlogged switch {
                        true => 6084,
                        false => 6085,
                    },
                    14 => Waterlogged switch {
                        true => 6086,
                        false => 6087,
                    },
                    15 => Waterlogged switch {
                        true => 6088,
                        false => 6089,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6026 => new JungleHangingSignBlock(Identifier, true, 0, true),
            6027 => new JungleHangingSignBlock(Identifier, true, 0, false),
            6028 => new JungleHangingSignBlock(Identifier, true, 1, true),
            6029 => new JungleHangingSignBlock(Identifier, true, 1, false),
            6030 => new JungleHangingSignBlock(Identifier, true, 2, true),
            6031 => new JungleHangingSignBlock(Identifier, true, 2, false),
            6032 => new JungleHangingSignBlock(Identifier, true, 3, true),
            6033 => new JungleHangingSignBlock(Identifier, true, 3, false),
            6034 => new JungleHangingSignBlock(Identifier, true, 4, true),
            6035 => new JungleHangingSignBlock(Identifier, true, 4, false),
            6036 => new JungleHangingSignBlock(Identifier, true, 5, true),
            6037 => new JungleHangingSignBlock(Identifier, true, 5, false),
            6038 => new JungleHangingSignBlock(Identifier, true, 6, true),
            6039 => new JungleHangingSignBlock(Identifier, true, 6, false),
            6040 => new JungleHangingSignBlock(Identifier, true, 7, true),
            6041 => new JungleHangingSignBlock(Identifier, true, 7, false),
            6042 => new JungleHangingSignBlock(Identifier, true, 8, true),
            6043 => new JungleHangingSignBlock(Identifier, true, 8, false),
            6044 => new JungleHangingSignBlock(Identifier, true, 9, true),
            6045 => new JungleHangingSignBlock(Identifier, true, 9, false),
            6046 => new JungleHangingSignBlock(Identifier, true, 10, true),
            6047 => new JungleHangingSignBlock(Identifier, true, 10, false),
            6048 => new JungleHangingSignBlock(Identifier, true, 11, true),
            6049 => new JungleHangingSignBlock(Identifier, true, 11, false),
            6050 => new JungleHangingSignBlock(Identifier, true, 12, true),
            6051 => new JungleHangingSignBlock(Identifier, true, 12, false),
            6052 => new JungleHangingSignBlock(Identifier, true, 13, true),
            6053 => new JungleHangingSignBlock(Identifier, true, 13, false),
            6054 => new JungleHangingSignBlock(Identifier, true, 14, true),
            6055 => new JungleHangingSignBlock(Identifier, true, 14, false),
            6056 => new JungleHangingSignBlock(Identifier, true, 15, true),
            6057 => new JungleHangingSignBlock(Identifier, true, 15, false),
            6058 => new JungleHangingSignBlock(Identifier, false, 0, true),
            6059 => new JungleHangingSignBlock(Identifier, false, 0, false),
            6060 => new JungleHangingSignBlock(Identifier, false, 1, true),
            6061 => new JungleHangingSignBlock(Identifier, false, 1, false),
            6062 => new JungleHangingSignBlock(Identifier, false, 2, true),
            6063 => new JungleHangingSignBlock(Identifier, false, 2, false),
            6064 => new JungleHangingSignBlock(Identifier, false, 3, true),
            6065 => new JungleHangingSignBlock(Identifier, false, 3, false),
            6066 => new JungleHangingSignBlock(Identifier, false, 4, true),
            6067 => new JungleHangingSignBlock(Identifier, false, 4, false),
            6068 => new JungleHangingSignBlock(Identifier, false, 5, true),
            6069 => new JungleHangingSignBlock(Identifier, false, 5, false),
            6070 => new JungleHangingSignBlock(Identifier, false, 6, true),
            6071 => new JungleHangingSignBlock(Identifier, false, 6, false),
            6072 => new JungleHangingSignBlock(Identifier, false, 7, true),
            6073 => new JungleHangingSignBlock(Identifier, false, 7, false),
            6074 => new JungleHangingSignBlock(Identifier, false, 8, true),
            6075 => new JungleHangingSignBlock(Identifier, false, 8, false),
            6076 => new JungleHangingSignBlock(Identifier, false, 9, true),
            6077 => new JungleHangingSignBlock(Identifier, false, 9, false),
            6078 => new JungleHangingSignBlock(Identifier, false, 10, true),
            6079 => new JungleHangingSignBlock(Identifier, false, 10, false),
            6080 => new JungleHangingSignBlock(Identifier, false, 11, true),
            6081 => new JungleHangingSignBlock(Identifier, false, 11, false),
            6082 => new JungleHangingSignBlock(Identifier, false, 12, true),
            6083 => new JungleHangingSignBlock(Identifier, false, 12, false),
            6084 => new JungleHangingSignBlock(Identifier, false, 13, true),
            6085 => new JungleHangingSignBlock(Identifier, false, 13, false),
            6086 => new JungleHangingSignBlock(Identifier, false, 14, true),
            6087 => new JungleHangingSignBlock(Identifier, false, 14, false),
            6088 => new JungleHangingSignBlock(Identifier, false, 15, true),
            6089 => new JungleHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.ChildrenMap.ContainsKey("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("attached", Attached.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
