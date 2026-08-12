using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
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
    public Identifier? Item => "minecraft:acacia_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6099,
                        false => 6100,
                    },
                    1 => Waterlogged switch {
                        true => 6101,
                        false => 6102,
                    },
                    2 => Waterlogged switch {
                        true => 6103,
                        false => 6104,
                    },
                    3 => Waterlogged switch {
                        true => 6105,
                        false => 6106,
                    },
                    4 => Waterlogged switch {
                        true => 6107,
                        false => 6108,
                    },
                    5 => Waterlogged switch {
                        true => 6109,
                        false => 6110,
                    },
                    6 => Waterlogged switch {
                        true => 6111,
                        false => 6112,
                    },
                    7 => Waterlogged switch {
                        true => 6113,
                        false => 6114,
                    },
                    8 => Waterlogged switch {
                        true => 6115,
                        false => 6116,
                    },
                    9 => Waterlogged switch {
                        true => 6117,
                        false => 6118,
                    },
                    10 => Waterlogged switch {
                        true => 6119,
                        false => 6120,
                    },
                    11 => Waterlogged switch {
                        true => 6121,
                        false => 6122,
                    },
                    12 => Waterlogged switch {
                        true => 6123,
                        false => 6124,
                    },
                    13 => Waterlogged switch {
                        true => 6125,
                        false => 6126,
                    },
                    14 => Waterlogged switch {
                        true => 6127,
                        false => 6128,
                    },
                    15 => Waterlogged switch {
                        true => 6129,
                        false => 6130,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6131,
                        false => 6132,
                    },
                    1 => Waterlogged switch {
                        true => 6133,
                        false => 6134,
                    },
                    2 => Waterlogged switch {
                        true => 6135,
                        false => 6136,
                    },
                    3 => Waterlogged switch {
                        true => 6137,
                        false => 6138,
                    },
                    4 => Waterlogged switch {
                        true => 6139,
                        false => 6140,
                    },
                    5 => Waterlogged switch {
                        true => 6141,
                        false => 6142,
                    },
                    6 => Waterlogged switch {
                        true => 6143,
                        false => 6144,
                    },
                    7 => Waterlogged switch {
                        true => 6145,
                        false => 6146,
                    },
                    8 => Waterlogged switch {
                        true => 6147,
                        false => 6148,
                    },
                    9 => Waterlogged switch {
                        true => 6149,
                        false => 6150,
                    },
                    10 => Waterlogged switch {
                        true => 6151,
                        false => 6152,
                    },
                    11 => Waterlogged switch {
                        true => 6153,
                        false => 6154,
                    },
                    12 => Waterlogged switch {
                        true => 6155,
                        false => 6156,
                    },
                    13 => Waterlogged switch {
                        true => 6157,
                        false => 6158,
                    },
                    14 => Waterlogged switch {
                        true => 6159,
                        false => 6160,
                    },
                    15 => Waterlogged switch {
                        true => 6161,
                        false => 6162,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6099 => new AcaciaHangingSignBlock(Identifier, true, 0, true),
            6100 => new AcaciaHangingSignBlock(Identifier, true, 0, false),
            6101 => new AcaciaHangingSignBlock(Identifier, true, 1, true),
            6102 => new AcaciaHangingSignBlock(Identifier, true, 1, false),
            6103 => new AcaciaHangingSignBlock(Identifier, true, 2, true),
            6104 => new AcaciaHangingSignBlock(Identifier, true, 2, false),
            6105 => new AcaciaHangingSignBlock(Identifier, true, 3, true),
            6106 => new AcaciaHangingSignBlock(Identifier, true, 3, false),
            6107 => new AcaciaHangingSignBlock(Identifier, true, 4, true),
            6108 => new AcaciaHangingSignBlock(Identifier, true, 4, false),
            6109 => new AcaciaHangingSignBlock(Identifier, true, 5, true),
            6110 => new AcaciaHangingSignBlock(Identifier, true, 5, false),
            6111 => new AcaciaHangingSignBlock(Identifier, true, 6, true),
            6112 => new AcaciaHangingSignBlock(Identifier, true, 6, false),
            6113 => new AcaciaHangingSignBlock(Identifier, true, 7, true),
            6114 => new AcaciaHangingSignBlock(Identifier, true, 7, false),
            6115 => new AcaciaHangingSignBlock(Identifier, true, 8, true),
            6116 => new AcaciaHangingSignBlock(Identifier, true, 8, false),
            6117 => new AcaciaHangingSignBlock(Identifier, true, 9, true),
            6118 => new AcaciaHangingSignBlock(Identifier, true, 9, false),
            6119 => new AcaciaHangingSignBlock(Identifier, true, 10, true),
            6120 => new AcaciaHangingSignBlock(Identifier, true, 10, false),
            6121 => new AcaciaHangingSignBlock(Identifier, true, 11, true),
            6122 => new AcaciaHangingSignBlock(Identifier, true, 11, false),
            6123 => new AcaciaHangingSignBlock(Identifier, true, 12, true),
            6124 => new AcaciaHangingSignBlock(Identifier, true, 12, false),
            6125 => new AcaciaHangingSignBlock(Identifier, true, 13, true),
            6126 => new AcaciaHangingSignBlock(Identifier, true, 13, false),
            6127 => new AcaciaHangingSignBlock(Identifier, true, 14, true),
            6128 => new AcaciaHangingSignBlock(Identifier, true, 14, false),
            6129 => new AcaciaHangingSignBlock(Identifier, true, 15, true),
            6130 => new AcaciaHangingSignBlock(Identifier, true, 15, false),
            6131 => new AcaciaHangingSignBlock(Identifier, false, 0, true),
            6132 => new AcaciaHangingSignBlock(Identifier, false, 0, false),
            6133 => new AcaciaHangingSignBlock(Identifier, false, 1, true),
            6134 => new AcaciaHangingSignBlock(Identifier, false, 1, false),
            6135 => new AcaciaHangingSignBlock(Identifier, false, 2, true),
            6136 => new AcaciaHangingSignBlock(Identifier, false, 2, false),
            6137 => new AcaciaHangingSignBlock(Identifier, false, 3, true),
            6138 => new AcaciaHangingSignBlock(Identifier, false, 3, false),
            6139 => new AcaciaHangingSignBlock(Identifier, false, 4, true),
            6140 => new AcaciaHangingSignBlock(Identifier, false, 4, false),
            6141 => new AcaciaHangingSignBlock(Identifier, false, 5, true),
            6142 => new AcaciaHangingSignBlock(Identifier, false, 5, false),
            6143 => new AcaciaHangingSignBlock(Identifier, false, 6, true),
            6144 => new AcaciaHangingSignBlock(Identifier, false, 6, false),
            6145 => new AcaciaHangingSignBlock(Identifier, false, 7, true),
            6146 => new AcaciaHangingSignBlock(Identifier, false, 7, false),
            6147 => new AcaciaHangingSignBlock(Identifier, false, 8, true),
            6148 => new AcaciaHangingSignBlock(Identifier, false, 8, false),
            6149 => new AcaciaHangingSignBlock(Identifier, false, 9, true),
            6150 => new AcaciaHangingSignBlock(Identifier, false, 9, false),
            6151 => new AcaciaHangingSignBlock(Identifier, false, 10, true),
            6152 => new AcaciaHangingSignBlock(Identifier, false, 10, false),
            6153 => new AcaciaHangingSignBlock(Identifier, false, 11, true),
            6154 => new AcaciaHangingSignBlock(Identifier, false, 11, false),
            6155 => new AcaciaHangingSignBlock(Identifier, false, 12, true),
            6156 => new AcaciaHangingSignBlock(Identifier, false, 12, false),
            6157 => new AcaciaHangingSignBlock(Identifier, false, 13, true),
            6158 => new AcaciaHangingSignBlock(Identifier, false, 13, false),
            6159 => new AcaciaHangingSignBlock(Identifier, false, 14, true),
            6160 => new AcaciaHangingSignBlock(Identifier, false, 14, false),
            6161 => new AcaciaHangingSignBlock(Identifier, false, 15, true),
            6162 => new AcaciaHangingSignBlock(Identifier, false, 15, false),
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
