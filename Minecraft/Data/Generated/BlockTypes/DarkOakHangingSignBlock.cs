using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 239;
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
    public Identifier? Item => "minecraft:dark_oak_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6090,
                        false => 6091,
                    },
                    1 => Waterlogged switch {
                        true => 6092,
                        false => 6093,
                    },
                    2 => Waterlogged switch {
                        true => 6094,
                        false => 6095,
                    },
                    3 => Waterlogged switch {
                        true => 6096,
                        false => 6097,
                    },
                    4 => Waterlogged switch {
                        true => 6098,
                        false => 6099,
                    },
                    5 => Waterlogged switch {
                        true => 6100,
                        false => 6101,
                    },
                    6 => Waterlogged switch {
                        true => 6102,
                        false => 6103,
                    },
                    7 => Waterlogged switch {
                        true => 6104,
                        false => 6105,
                    },
                    8 => Waterlogged switch {
                        true => 6106,
                        false => 6107,
                    },
                    9 => Waterlogged switch {
                        true => 6108,
                        false => 6109,
                    },
                    10 => Waterlogged switch {
                        true => 6110,
                        false => 6111,
                    },
                    11 => Waterlogged switch {
                        true => 6112,
                        false => 6113,
                    },
                    12 => Waterlogged switch {
                        true => 6114,
                        false => 6115,
                    },
                    13 => Waterlogged switch {
                        true => 6116,
                        false => 6117,
                    },
                    14 => Waterlogged switch {
                        true => 6118,
                        false => 6119,
                    },
                    15 => Waterlogged switch {
                        true => 6120,
                        false => 6121,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6122,
                        false => 6123,
                    },
                    1 => Waterlogged switch {
                        true => 6124,
                        false => 6125,
                    },
                    2 => Waterlogged switch {
                        true => 6126,
                        false => 6127,
                    },
                    3 => Waterlogged switch {
                        true => 6128,
                        false => 6129,
                    },
                    4 => Waterlogged switch {
                        true => 6130,
                        false => 6131,
                    },
                    5 => Waterlogged switch {
                        true => 6132,
                        false => 6133,
                    },
                    6 => Waterlogged switch {
                        true => 6134,
                        false => 6135,
                    },
                    7 => Waterlogged switch {
                        true => 6136,
                        false => 6137,
                    },
                    8 => Waterlogged switch {
                        true => 6138,
                        false => 6139,
                    },
                    9 => Waterlogged switch {
                        true => 6140,
                        false => 6141,
                    },
                    10 => Waterlogged switch {
                        true => 6142,
                        false => 6143,
                    },
                    11 => Waterlogged switch {
                        true => 6144,
                        false => 6145,
                    },
                    12 => Waterlogged switch {
                        true => 6146,
                        false => 6147,
                    },
                    13 => Waterlogged switch {
                        true => 6148,
                        false => 6149,
                    },
                    14 => Waterlogged switch {
                        true => 6150,
                        false => 6151,
                    },
                    15 => Waterlogged switch {
                        true => 6152,
                        false => 6153,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6090 => new DarkOakHangingSignBlock(Identifier, true, 0, true),
            6091 => new DarkOakHangingSignBlock(Identifier, true, 0, false),
            6092 => new DarkOakHangingSignBlock(Identifier, true, 1, true),
            6093 => new DarkOakHangingSignBlock(Identifier, true, 1, false),
            6094 => new DarkOakHangingSignBlock(Identifier, true, 2, true),
            6095 => new DarkOakHangingSignBlock(Identifier, true, 2, false),
            6096 => new DarkOakHangingSignBlock(Identifier, true, 3, true),
            6097 => new DarkOakHangingSignBlock(Identifier, true, 3, false),
            6098 => new DarkOakHangingSignBlock(Identifier, true, 4, true),
            6099 => new DarkOakHangingSignBlock(Identifier, true, 4, false),
            6100 => new DarkOakHangingSignBlock(Identifier, true, 5, true),
            6101 => new DarkOakHangingSignBlock(Identifier, true, 5, false),
            6102 => new DarkOakHangingSignBlock(Identifier, true, 6, true),
            6103 => new DarkOakHangingSignBlock(Identifier, true, 6, false),
            6104 => new DarkOakHangingSignBlock(Identifier, true, 7, true),
            6105 => new DarkOakHangingSignBlock(Identifier, true, 7, false),
            6106 => new DarkOakHangingSignBlock(Identifier, true, 8, true),
            6107 => new DarkOakHangingSignBlock(Identifier, true, 8, false),
            6108 => new DarkOakHangingSignBlock(Identifier, true, 9, true),
            6109 => new DarkOakHangingSignBlock(Identifier, true, 9, false),
            6110 => new DarkOakHangingSignBlock(Identifier, true, 10, true),
            6111 => new DarkOakHangingSignBlock(Identifier, true, 10, false),
            6112 => new DarkOakHangingSignBlock(Identifier, true, 11, true),
            6113 => new DarkOakHangingSignBlock(Identifier, true, 11, false),
            6114 => new DarkOakHangingSignBlock(Identifier, true, 12, true),
            6115 => new DarkOakHangingSignBlock(Identifier, true, 12, false),
            6116 => new DarkOakHangingSignBlock(Identifier, true, 13, true),
            6117 => new DarkOakHangingSignBlock(Identifier, true, 13, false),
            6118 => new DarkOakHangingSignBlock(Identifier, true, 14, true),
            6119 => new DarkOakHangingSignBlock(Identifier, true, 14, false),
            6120 => new DarkOakHangingSignBlock(Identifier, true, 15, true),
            6121 => new DarkOakHangingSignBlock(Identifier, true, 15, false),
            6122 => new DarkOakHangingSignBlock(Identifier, false, 0, true),
            6123 => new DarkOakHangingSignBlock(Identifier, false, 0, false),
            6124 => new DarkOakHangingSignBlock(Identifier, false, 1, true),
            6125 => new DarkOakHangingSignBlock(Identifier, false, 1, false),
            6126 => new DarkOakHangingSignBlock(Identifier, false, 2, true),
            6127 => new DarkOakHangingSignBlock(Identifier, false, 2, false),
            6128 => new DarkOakHangingSignBlock(Identifier, false, 3, true),
            6129 => new DarkOakHangingSignBlock(Identifier, false, 3, false),
            6130 => new DarkOakHangingSignBlock(Identifier, false, 4, true),
            6131 => new DarkOakHangingSignBlock(Identifier, false, 4, false),
            6132 => new DarkOakHangingSignBlock(Identifier, false, 5, true),
            6133 => new DarkOakHangingSignBlock(Identifier, false, 5, false),
            6134 => new DarkOakHangingSignBlock(Identifier, false, 6, true),
            6135 => new DarkOakHangingSignBlock(Identifier, false, 6, false),
            6136 => new DarkOakHangingSignBlock(Identifier, false, 7, true),
            6137 => new DarkOakHangingSignBlock(Identifier, false, 7, false),
            6138 => new DarkOakHangingSignBlock(Identifier, false, 8, true),
            6139 => new DarkOakHangingSignBlock(Identifier, false, 8, false),
            6140 => new DarkOakHangingSignBlock(Identifier, false, 9, true),
            6141 => new DarkOakHangingSignBlock(Identifier, false, 9, false),
            6142 => new DarkOakHangingSignBlock(Identifier, false, 10, true),
            6143 => new DarkOakHangingSignBlock(Identifier, false, 10, false),
            6144 => new DarkOakHangingSignBlock(Identifier, false, 11, true),
            6145 => new DarkOakHangingSignBlock(Identifier, false, 11, false),
            6146 => new DarkOakHangingSignBlock(Identifier, false, 12, true),
            6147 => new DarkOakHangingSignBlock(Identifier, false, 12, false),
            6148 => new DarkOakHangingSignBlock(Identifier, false, 13, true),
            6149 => new DarkOakHangingSignBlock(Identifier, false, 13, false),
            6150 => new DarkOakHangingSignBlock(Identifier, false, 14, true),
            6151 => new DarkOakHangingSignBlock(Identifier, false, 14, false),
            6152 => new DarkOakHangingSignBlock(Identifier, false, 15, true),
            6153 => new DarkOakHangingSignBlock(Identifier, false, 15, false),
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
