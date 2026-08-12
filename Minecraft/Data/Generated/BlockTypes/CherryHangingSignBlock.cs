using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
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
    public string SoundType => "cherry_wood_hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:cherry_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 42;
    public string TranslationKey => "block.minecraft.cherry_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6163,
                        false => 6164,
                    },
                    1 => Waterlogged switch {
                        true => 6165,
                        false => 6166,
                    },
                    2 => Waterlogged switch {
                        true => 6167,
                        false => 6168,
                    },
                    3 => Waterlogged switch {
                        true => 6169,
                        false => 6170,
                    },
                    4 => Waterlogged switch {
                        true => 6171,
                        false => 6172,
                    },
                    5 => Waterlogged switch {
                        true => 6173,
                        false => 6174,
                    },
                    6 => Waterlogged switch {
                        true => 6175,
                        false => 6176,
                    },
                    7 => Waterlogged switch {
                        true => 6177,
                        false => 6178,
                    },
                    8 => Waterlogged switch {
                        true => 6179,
                        false => 6180,
                    },
                    9 => Waterlogged switch {
                        true => 6181,
                        false => 6182,
                    },
                    10 => Waterlogged switch {
                        true => 6183,
                        false => 6184,
                    },
                    11 => Waterlogged switch {
                        true => 6185,
                        false => 6186,
                    },
                    12 => Waterlogged switch {
                        true => 6187,
                        false => 6188,
                    },
                    13 => Waterlogged switch {
                        true => 6189,
                        false => 6190,
                    },
                    14 => Waterlogged switch {
                        true => 6191,
                        false => 6192,
                    },
                    15 => Waterlogged switch {
                        true => 6193,
                        false => 6194,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6195,
                        false => 6196,
                    },
                    1 => Waterlogged switch {
                        true => 6197,
                        false => 6198,
                    },
                    2 => Waterlogged switch {
                        true => 6199,
                        false => 6200,
                    },
                    3 => Waterlogged switch {
                        true => 6201,
                        false => 6202,
                    },
                    4 => Waterlogged switch {
                        true => 6203,
                        false => 6204,
                    },
                    5 => Waterlogged switch {
                        true => 6205,
                        false => 6206,
                    },
                    6 => Waterlogged switch {
                        true => 6207,
                        false => 6208,
                    },
                    7 => Waterlogged switch {
                        true => 6209,
                        false => 6210,
                    },
                    8 => Waterlogged switch {
                        true => 6211,
                        false => 6212,
                    },
                    9 => Waterlogged switch {
                        true => 6213,
                        false => 6214,
                    },
                    10 => Waterlogged switch {
                        true => 6215,
                        false => 6216,
                    },
                    11 => Waterlogged switch {
                        true => 6217,
                        false => 6218,
                    },
                    12 => Waterlogged switch {
                        true => 6219,
                        false => 6220,
                    },
                    13 => Waterlogged switch {
                        true => 6221,
                        false => 6222,
                    },
                    14 => Waterlogged switch {
                        true => 6223,
                        false => 6224,
                    },
                    15 => Waterlogged switch {
                        true => 6225,
                        false => 6226,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6163 => new CherryHangingSignBlock(Identifier, true, 0, true),
            6164 => new CherryHangingSignBlock(Identifier, true, 0, false),
            6165 => new CherryHangingSignBlock(Identifier, true, 1, true),
            6166 => new CherryHangingSignBlock(Identifier, true, 1, false),
            6167 => new CherryHangingSignBlock(Identifier, true, 2, true),
            6168 => new CherryHangingSignBlock(Identifier, true, 2, false),
            6169 => new CherryHangingSignBlock(Identifier, true, 3, true),
            6170 => new CherryHangingSignBlock(Identifier, true, 3, false),
            6171 => new CherryHangingSignBlock(Identifier, true, 4, true),
            6172 => new CherryHangingSignBlock(Identifier, true, 4, false),
            6173 => new CherryHangingSignBlock(Identifier, true, 5, true),
            6174 => new CherryHangingSignBlock(Identifier, true, 5, false),
            6175 => new CherryHangingSignBlock(Identifier, true, 6, true),
            6176 => new CherryHangingSignBlock(Identifier, true, 6, false),
            6177 => new CherryHangingSignBlock(Identifier, true, 7, true),
            6178 => new CherryHangingSignBlock(Identifier, true, 7, false),
            6179 => new CherryHangingSignBlock(Identifier, true, 8, true),
            6180 => new CherryHangingSignBlock(Identifier, true, 8, false),
            6181 => new CherryHangingSignBlock(Identifier, true, 9, true),
            6182 => new CherryHangingSignBlock(Identifier, true, 9, false),
            6183 => new CherryHangingSignBlock(Identifier, true, 10, true),
            6184 => new CherryHangingSignBlock(Identifier, true, 10, false),
            6185 => new CherryHangingSignBlock(Identifier, true, 11, true),
            6186 => new CherryHangingSignBlock(Identifier, true, 11, false),
            6187 => new CherryHangingSignBlock(Identifier, true, 12, true),
            6188 => new CherryHangingSignBlock(Identifier, true, 12, false),
            6189 => new CherryHangingSignBlock(Identifier, true, 13, true),
            6190 => new CherryHangingSignBlock(Identifier, true, 13, false),
            6191 => new CherryHangingSignBlock(Identifier, true, 14, true),
            6192 => new CherryHangingSignBlock(Identifier, true, 14, false),
            6193 => new CherryHangingSignBlock(Identifier, true, 15, true),
            6194 => new CherryHangingSignBlock(Identifier, true, 15, false),
            6195 => new CherryHangingSignBlock(Identifier, false, 0, true),
            6196 => new CherryHangingSignBlock(Identifier, false, 0, false),
            6197 => new CherryHangingSignBlock(Identifier, false, 1, true),
            6198 => new CherryHangingSignBlock(Identifier, false, 1, false),
            6199 => new CherryHangingSignBlock(Identifier, false, 2, true),
            6200 => new CherryHangingSignBlock(Identifier, false, 2, false),
            6201 => new CherryHangingSignBlock(Identifier, false, 3, true),
            6202 => new CherryHangingSignBlock(Identifier, false, 3, false),
            6203 => new CherryHangingSignBlock(Identifier, false, 4, true),
            6204 => new CherryHangingSignBlock(Identifier, false, 4, false),
            6205 => new CherryHangingSignBlock(Identifier, false, 5, true),
            6206 => new CherryHangingSignBlock(Identifier, false, 5, false),
            6207 => new CherryHangingSignBlock(Identifier, false, 6, true),
            6208 => new CherryHangingSignBlock(Identifier, false, 6, false),
            6209 => new CherryHangingSignBlock(Identifier, false, 7, true),
            6210 => new CherryHangingSignBlock(Identifier, false, 7, false),
            6211 => new CherryHangingSignBlock(Identifier, false, 8, true),
            6212 => new CherryHangingSignBlock(Identifier, false, 8, false),
            6213 => new CherryHangingSignBlock(Identifier, false, 9, true),
            6214 => new CherryHangingSignBlock(Identifier, false, 9, false),
            6215 => new CherryHangingSignBlock(Identifier, false, 10, true),
            6216 => new CherryHangingSignBlock(Identifier, false, 10, false),
            6217 => new CherryHangingSignBlock(Identifier, false, 11, true),
            6218 => new CherryHangingSignBlock(Identifier, false, 11, false),
            6219 => new CherryHangingSignBlock(Identifier, false, 12, true),
            6220 => new CherryHangingSignBlock(Identifier, false, 12, false),
            6221 => new CherryHangingSignBlock(Identifier, false, 13, true),
            6222 => new CherryHangingSignBlock(Identifier, false, 13, false),
            6223 => new CherryHangingSignBlock(Identifier, false, 14, true),
            6224 => new CherryHangingSignBlock(Identifier, false, 14, false),
            6225 => new CherryHangingSignBlock(Identifier, false, 15, true),
            6226 => new CherryHangingSignBlock(Identifier, false, 15, false),
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
