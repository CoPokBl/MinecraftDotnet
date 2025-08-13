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
    public int ProtocolId => 224;
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
                        true => 5130,
                        false => 5131,
                    },
                    1 => Waterlogged switch {
                        true => 5132,
                        false => 5133,
                    },
                    2 => Waterlogged switch {
                        true => 5134,
                        false => 5135,
                    },
                    3 => Waterlogged switch {
                        true => 5136,
                        false => 5137,
                    },
                    4 => Waterlogged switch {
                        true => 5138,
                        false => 5139,
                    },
                    5 => Waterlogged switch {
                        true => 5140,
                        false => 5141,
                    },
                    6 => Waterlogged switch {
                        true => 5142,
                        false => 5143,
                    },
                    7 => Waterlogged switch {
                        true => 5144,
                        false => 5145,
                    },
                    8 => Waterlogged switch {
                        true => 5146,
                        false => 5147,
                    },
                    9 => Waterlogged switch {
                        true => 5148,
                        false => 5149,
                    },
                    10 => Waterlogged switch {
                        true => 5150,
                        false => 5151,
                    },
                    11 => Waterlogged switch {
                        true => 5152,
                        false => 5153,
                    },
                    12 => Waterlogged switch {
                        true => 5154,
                        false => 5155,
                    },
                    13 => Waterlogged switch {
                        true => 5156,
                        false => 5157,
                    },
                    14 => Waterlogged switch {
                        true => 5158,
                        false => 5159,
                    },
                    15 => Waterlogged switch {
                        true => 5160,
                        false => 5161,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5162,
                        false => 5163,
                    },
                    1 => Waterlogged switch {
                        true => 5164,
                        false => 5165,
                    },
                    2 => Waterlogged switch {
                        true => 5166,
                        false => 5167,
                    },
                    3 => Waterlogged switch {
                        true => 5168,
                        false => 5169,
                    },
                    4 => Waterlogged switch {
                        true => 5170,
                        false => 5171,
                    },
                    5 => Waterlogged switch {
                        true => 5172,
                        false => 5173,
                    },
                    6 => Waterlogged switch {
                        true => 5174,
                        false => 5175,
                    },
                    7 => Waterlogged switch {
                        true => 5176,
                        false => 5177,
                    },
                    8 => Waterlogged switch {
                        true => 5178,
                        false => 5179,
                    },
                    9 => Waterlogged switch {
                        true => 5180,
                        false => 5181,
                    },
                    10 => Waterlogged switch {
                        true => 5182,
                        false => 5183,
                    },
                    11 => Waterlogged switch {
                        true => 5184,
                        false => 5185,
                    },
                    12 => Waterlogged switch {
                        true => 5186,
                        false => 5187,
                    },
                    13 => Waterlogged switch {
                        true => 5188,
                        false => 5189,
                    },
                    14 => Waterlogged switch {
                        true => 5190,
                        false => 5191,
                    },
                    15 => Waterlogged switch {
                        true => 5192,
                        false => 5193,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5130 => new AcaciaHangingSignBlock(Identifier, true, 0, true),
            5131 => new AcaciaHangingSignBlock(Identifier, true, 0, false),
            5132 => new AcaciaHangingSignBlock(Identifier, true, 1, true),
            5133 => new AcaciaHangingSignBlock(Identifier, true, 1, false),
            5134 => new AcaciaHangingSignBlock(Identifier, true, 2, true),
            5135 => new AcaciaHangingSignBlock(Identifier, true, 2, false),
            5136 => new AcaciaHangingSignBlock(Identifier, true, 3, true),
            5137 => new AcaciaHangingSignBlock(Identifier, true, 3, false),
            5138 => new AcaciaHangingSignBlock(Identifier, true, 4, true),
            5139 => new AcaciaHangingSignBlock(Identifier, true, 4, false),
            5140 => new AcaciaHangingSignBlock(Identifier, true, 5, true),
            5141 => new AcaciaHangingSignBlock(Identifier, true, 5, false),
            5142 => new AcaciaHangingSignBlock(Identifier, true, 6, true),
            5143 => new AcaciaHangingSignBlock(Identifier, true, 6, false),
            5144 => new AcaciaHangingSignBlock(Identifier, true, 7, true),
            5145 => new AcaciaHangingSignBlock(Identifier, true, 7, false),
            5146 => new AcaciaHangingSignBlock(Identifier, true, 8, true),
            5147 => new AcaciaHangingSignBlock(Identifier, true, 8, false),
            5148 => new AcaciaHangingSignBlock(Identifier, true, 9, true),
            5149 => new AcaciaHangingSignBlock(Identifier, true, 9, false),
            5150 => new AcaciaHangingSignBlock(Identifier, true, 10, true),
            5151 => new AcaciaHangingSignBlock(Identifier, true, 10, false),
            5152 => new AcaciaHangingSignBlock(Identifier, true, 11, true),
            5153 => new AcaciaHangingSignBlock(Identifier, true, 11, false),
            5154 => new AcaciaHangingSignBlock(Identifier, true, 12, true),
            5155 => new AcaciaHangingSignBlock(Identifier, true, 12, false),
            5156 => new AcaciaHangingSignBlock(Identifier, true, 13, true),
            5157 => new AcaciaHangingSignBlock(Identifier, true, 13, false),
            5158 => new AcaciaHangingSignBlock(Identifier, true, 14, true),
            5159 => new AcaciaHangingSignBlock(Identifier, true, 14, false),
            5160 => new AcaciaHangingSignBlock(Identifier, true, 15, true),
            5161 => new AcaciaHangingSignBlock(Identifier, true, 15, false),
            5162 => new AcaciaHangingSignBlock(Identifier, false, 0, true),
            5163 => new AcaciaHangingSignBlock(Identifier, false, 0, false),
            5164 => new AcaciaHangingSignBlock(Identifier, false, 1, true),
            5165 => new AcaciaHangingSignBlock(Identifier, false, 1, false),
            5166 => new AcaciaHangingSignBlock(Identifier, false, 2, true),
            5167 => new AcaciaHangingSignBlock(Identifier, false, 2, false),
            5168 => new AcaciaHangingSignBlock(Identifier, false, 3, true),
            5169 => new AcaciaHangingSignBlock(Identifier, false, 3, false),
            5170 => new AcaciaHangingSignBlock(Identifier, false, 4, true),
            5171 => new AcaciaHangingSignBlock(Identifier, false, 4, false),
            5172 => new AcaciaHangingSignBlock(Identifier, false, 5, true),
            5173 => new AcaciaHangingSignBlock(Identifier, false, 5, false),
            5174 => new AcaciaHangingSignBlock(Identifier, false, 6, true),
            5175 => new AcaciaHangingSignBlock(Identifier, false, 6, false),
            5176 => new AcaciaHangingSignBlock(Identifier, false, 7, true),
            5177 => new AcaciaHangingSignBlock(Identifier, false, 7, false),
            5178 => new AcaciaHangingSignBlock(Identifier, false, 8, true),
            5179 => new AcaciaHangingSignBlock(Identifier, false, 8, false),
            5180 => new AcaciaHangingSignBlock(Identifier, false, 9, true),
            5181 => new AcaciaHangingSignBlock(Identifier, false, 9, false),
            5182 => new AcaciaHangingSignBlock(Identifier, false, 10, true),
            5183 => new AcaciaHangingSignBlock(Identifier, false, 10, false),
            5184 => new AcaciaHangingSignBlock(Identifier, false, 11, true),
            5185 => new AcaciaHangingSignBlock(Identifier, false, 11, false),
            5186 => new AcaciaHangingSignBlock(Identifier, false, 12, true),
            5187 => new AcaciaHangingSignBlock(Identifier, false, 12, false),
            5188 => new AcaciaHangingSignBlock(Identifier, false, 13, true),
            5189 => new AcaciaHangingSignBlock(Identifier, false, 13, false),
            5190 => new AcaciaHangingSignBlock(Identifier, false, 14, true),
            5191 => new AcaciaHangingSignBlock(Identifier, false, 14, false),
            5192 => new AcaciaHangingSignBlock(Identifier, false, 15, true),
            5193 => new AcaciaHangingSignBlock(Identifier, false, 15, false),
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
