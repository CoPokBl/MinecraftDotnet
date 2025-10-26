using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 240;
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
    public Identifier? Item => "minecraft:pale_oak_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6154,
                        false => 6155,
                    },
                    1 => Waterlogged switch {
                        true => 6156,
                        false => 6157,
                    },
                    2 => Waterlogged switch {
                        true => 6158,
                        false => 6159,
                    },
                    3 => Waterlogged switch {
                        true => 6160,
                        false => 6161,
                    },
                    4 => Waterlogged switch {
                        true => 6162,
                        false => 6163,
                    },
                    5 => Waterlogged switch {
                        true => 6164,
                        false => 6165,
                    },
                    6 => Waterlogged switch {
                        true => 6166,
                        false => 6167,
                    },
                    7 => Waterlogged switch {
                        true => 6168,
                        false => 6169,
                    },
                    8 => Waterlogged switch {
                        true => 6170,
                        false => 6171,
                    },
                    9 => Waterlogged switch {
                        true => 6172,
                        false => 6173,
                    },
                    10 => Waterlogged switch {
                        true => 6174,
                        false => 6175,
                    },
                    11 => Waterlogged switch {
                        true => 6176,
                        false => 6177,
                    },
                    12 => Waterlogged switch {
                        true => 6178,
                        false => 6179,
                    },
                    13 => Waterlogged switch {
                        true => 6180,
                        false => 6181,
                    },
                    14 => Waterlogged switch {
                        true => 6182,
                        false => 6183,
                    },
                    15 => Waterlogged switch {
                        true => 6184,
                        false => 6185,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6186,
                        false => 6187,
                    },
                    1 => Waterlogged switch {
                        true => 6188,
                        false => 6189,
                    },
                    2 => Waterlogged switch {
                        true => 6190,
                        false => 6191,
                    },
                    3 => Waterlogged switch {
                        true => 6192,
                        false => 6193,
                    },
                    4 => Waterlogged switch {
                        true => 6194,
                        false => 6195,
                    },
                    5 => Waterlogged switch {
                        true => 6196,
                        false => 6197,
                    },
                    6 => Waterlogged switch {
                        true => 6198,
                        false => 6199,
                    },
                    7 => Waterlogged switch {
                        true => 6200,
                        false => 6201,
                    },
                    8 => Waterlogged switch {
                        true => 6202,
                        false => 6203,
                    },
                    9 => Waterlogged switch {
                        true => 6204,
                        false => 6205,
                    },
                    10 => Waterlogged switch {
                        true => 6206,
                        false => 6207,
                    },
                    11 => Waterlogged switch {
                        true => 6208,
                        false => 6209,
                    },
                    12 => Waterlogged switch {
                        true => 6210,
                        false => 6211,
                    },
                    13 => Waterlogged switch {
                        true => 6212,
                        false => 6213,
                    },
                    14 => Waterlogged switch {
                        true => 6214,
                        false => 6215,
                    },
                    15 => Waterlogged switch {
                        true => 6216,
                        false => 6217,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6154 => new PaleOakHangingSignBlock(Identifier, true, 0, true),
            6155 => new PaleOakHangingSignBlock(Identifier, true, 0, false),
            6156 => new PaleOakHangingSignBlock(Identifier, true, 1, true),
            6157 => new PaleOakHangingSignBlock(Identifier, true, 1, false),
            6158 => new PaleOakHangingSignBlock(Identifier, true, 2, true),
            6159 => new PaleOakHangingSignBlock(Identifier, true, 2, false),
            6160 => new PaleOakHangingSignBlock(Identifier, true, 3, true),
            6161 => new PaleOakHangingSignBlock(Identifier, true, 3, false),
            6162 => new PaleOakHangingSignBlock(Identifier, true, 4, true),
            6163 => new PaleOakHangingSignBlock(Identifier, true, 4, false),
            6164 => new PaleOakHangingSignBlock(Identifier, true, 5, true),
            6165 => new PaleOakHangingSignBlock(Identifier, true, 5, false),
            6166 => new PaleOakHangingSignBlock(Identifier, true, 6, true),
            6167 => new PaleOakHangingSignBlock(Identifier, true, 6, false),
            6168 => new PaleOakHangingSignBlock(Identifier, true, 7, true),
            6169 => new PaleOakHangingSignBlock(Identifier, true, 7, false),
            6170 => new PaleOakHangingSignBlock(Identifier, true, 8, true),
            6171 => new PaleOakHangingSignBlock(Identifier, true, 8, false),
            6172 => new PaleOakHangingSignBlock(Identifier, true, 9, true),
            6173 => new PaleOakHangingSignBlock(Identifier, true, 9, false),
            6174 => new PaleOakHangingSignBlock(Identifier, true, 10, true),
            6175 => new PaleOakHangingSignBlock(Identifier, true, 10, false),
            6176 => new PaleOakHangingSignBlock(Identifier, true, 11, true),
            6177 => new PaleOakHangingSignBlock(Identifier, true, 11, false),
            6178 => new PaleOakHangingSignBlock(Identifier, true, 12, true),
            6179 => new PaleOakHangingSignBlock(Identifier, true, 12, false),
            6180 => new PaleOakHangingSignBlock(Identifier, true, 13, true),
            6181 => new PaleOakHangingSignBlock(Identifier, true, 13, false),
            6182 => new PaleOakHangingSignBlock(Identifier, true, 14, true),
            6183 => new PaleOakHangingSignBlock(Identifier, true, 14, false),
            6184 => new PaleOakHangingSignBlock(Identifier, true, 15, true),
            6185 => new PaleOakHangingSignBlock(Identifier, true, 15, false),
            6186 => new PaleOakHangingSignBlock(Identifier, false, 0, true),
            6187 => new PaleOakHangingSignBlock(Identifier, false, 0, false),
            6188 => new PaleOakHangingSignBlock(Identifier, false, 1, true),
            6189 => new PaleOakHangingSignBlock(Identifier, false, 1, false),
            6190 => new PaleOakHangingSignBlock(Identifier, false, 2, true),
            6191 => new PaleOakHangingSignBlock(Identifier, false, 2, false),
            6192 => new PaleOakHangingSignBlock(Identifier, false, 3, true),
            6193 => new PaleOakHangingSignBlock(Identifier, false, 3, false),
            6194 => new PaleOakHangingSignBlock(Identifier, false, 4, true),
            6195 => new PaleOakHangingSignBlock(Identifier, false, 4, false),
            6196 => new PaleOakHangingSignBlock(Identifier, false, 5, true),
            6197 => new PaleOakHangingSignBlock(Identifier, false, 5, false),
            6198 => new PaleOakHangingSignBlock(Identifier, false, 6, true),
            6199 => new PaleOakHangingSignBlock(Identifier, false, 6, false),
            6200 => new PaleOakHangingSignBlock(Identifier, false, 7, true),
            6201 => new PaleOakHangingSignBlock(Identifier, false, 7, false),
            6202 => new PaleOakHangingSignBlock(Identifier, false, 8, true),
            6203 => new PaleOakHangingSignBlock(Identifier, false, 8, false),
            6204 => new PaleOakHangingSignBlock(Identifier, false, 9, true),
            6205 => new PaleOakHangingSignBlock(Identifier, false, 9, false),
            6206 => new PaleOakHangingSignBlock(Identifier, false, 10, true),
            6207 => new PaleOakHangingSignBlock(Identifier, false, 10, false),
            6208 => new PaleOakHangingSignBlock(Identifier, false, 11, true),
            6209 => new PaleOakHangingSignBlock(Identifier, false, 11, false),
            6210 => new PaleOakHangingSignBlock(Identifier, false, 12, true),
            6211 => new PaleOakHangingSignBlock(Identifier, false, 12, false),
            6212 => new PaleOakHangingSignBlock(Identifier, false, 13, true),
            6213 => new PaleOakHangingSignBlock(Identifier, false, 13, false),
            6214 => new PaleOakHangingSignBlock(Identifier, false, 14, true),
            6215 => new PaleOakHangingSignBlock(Identifier, false, 14, false),
            6216 => new PaleOakHangingSignBlock(Identifier, false, 15, true),
            6217 => new PaleOakHangingSignBlock(Identifier, false, 15, false),
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
