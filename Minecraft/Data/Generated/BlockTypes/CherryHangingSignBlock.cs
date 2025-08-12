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
    public int ProtocolId => 225;
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
                        true => 5194,
                        false => 5195,
                    },
                    1 => Waterlogged switch {
                        true => 5196,
                        false => 5197,
                    },
                    2 => Waterlogged switch {
                        true => 5198,
                        false => 5199,
                    },
                    3 => Waterlogged switch {
                        true => 5200,
                        false => 5201,
                    },
                    4 => Waterlogged switch {
                        true => 5202,
                        false => 5203,
                    },
                    5 => Waterlogged switch {
                        true => 5204,
                        false => 5205,
                    },
                    6 => Waterlogged switch {
                        true => 5206,
                        false => 5207,
                    },
                    7 => Waterlogged switch {
                        true => 5208,
                        false => 5209,
                    },
                    8 => Waterlogged switch {
                        true => 5210,
                        false => 5211,
                    },
                    9 => Waterlogged switch {
                        true => 5212,
                        false => 5213,
                    },
                    10 => Waterlogged switch {
                        true => 5214,
                        false => 5215,
                    },
                    11 => Waterlogged switch {
                        true => 5216,
                        false => 5217,
                    },
                    12 => Waterlogged switch {
                        true => 5218,
                        false => 5219,
                    },
                    13 => Waterlogged switch {
                        true => 5220,
                        false => 5221,
                    },
                    14 => Waterlogged switch {
                        true => 5222,
                        false => 5223,
                    },
                    15 => Waterlogged switch {
                        true => 5224,
                        false => 5225,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5226,
                        false => 5227,
                    },
                    1 => Waterlogged switch {
                        true => 5228,
                        false => 5229,
                    },
                    2 => Waterlogged switch {
                        true => 5230,
                        false => 5231,
                    },
                    3 => Waterlogged switch {
                        true => 5232,
                        false => 5233,
                    },
                    4 => Waterlogged switch {
                        true => 5234,
                        false => 5235,
                    },
                    5 => Waterlogged switch {
                        true => 5236,
                        false => 5237,
                    },
                    6 => Waterlogged switch {
                        true => 5238,
                        false => 5239,
                    },
                    7 => Waterlogged switch {
                        true => 5240,
                        false => 5241,
                    },
                    8 => Waterlogged switch {
                        true => 5242,
                        false => 5243,
                    },
                    9 => Waterlogged switch {
                        true => 5244,
                        false => 5245,
                    },
                    10 => Waterlogged switch {
                        true => 5246,
                        false => 5247,
                    },
                    11 => Waterlogged switch {
                        true => 5248,
                        false => 5249,
                    },
                    12 => Waterlogged switch {
                        true => 5250,
                        false => 5251,
                    },
                    13 => Waterlogged switch {
                        true => 5252,
                        false => 5253,
                    },
                    14 => Waterlogged switch {
                        true => 5254,
                        false => 5255,
                    },
                    15 => Waterlogged switch {
                        true => 5256,
                        false => 5257,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5194 => new CherryHangingSignBlock(Identifier, true, 0, true),
            5195 => new CherryHangingSignBlock(Identifier, true, 0, false),
            5196 => new CherryHangingSignBlock(Identifier, true, 1, true),
            5197 => new CherryHangingSignBlock(Identifier, true, 1, false),
            5198 => new CherryHangingSignBlock(Identifier, true, 2, true),
            5199 => new CherryHangingSignBlock(Identifier, true, 2, false),
            5200 => new CherryHangingSignBlock(Identifier, true, 3, true),
            5201 => new CherryHangingSignBlock(Identifier, true, 3, false),
            5202 => new CherryHangingSignBlock(Identifier, true, 4, true),
            5203 => new CherryHangingSignBlock(Identifier, true, 4, false),
            5204 => new CherryHangingSignBlock(Identifier, true, 5, true),
            5205 => new CherryHangingSignBlock(Identifier, true, 5, false),
            5206 => new CherryHangingSignBlock(Identifier, true, 6, true),
            5207 => new CherryHangingSignBlock(Identifier, true, 6, false),
            5208 => new CherryHangingSignBlock(Identifier, true, 7, true),
            5209 => new CherryHangingSignBlock(Identifier, true, 7, false),
            5210 => new CherryHangingSignBlock(Identifier, true, 8, true),
            5211 => new CherryHangingSignBlock(Identifier, true, 8, false),
            5212 => new CherryHangingSignBlock(Identifier, true, 9, true),
            5213 => new CherryHangingSignBlock(Identifier, true, 9, false),
            5214 => new CherryHangingSignBlock(Identifier, true, 10, true),
            5215 => new CherryHangingSignBlock(Identifier, true, 10, false),
            5216 => new CherryHangingSignBlock(Identifier, true, 11, true),
            5217 => new CherryHangingSignBlock(Identifier, true, 11, false),
            5218 => new CherryHangingSignBlock(Identifier, true, 12, true),
            5219 => new CherryHangingSignBlock(Identifier, true, 12, false),
            5220 => new CherryHangingSignBlock(Identifier, true, 13, true),
            5221 => new CherryHangingSignBlock(Identifier, true, 13, false),
            5222 => new CherryHangingSignBlock(Identifier, true, 14, true),
            5223 => new CherryHangingSignBlock(Identifier, true, 14, false),
            5224 => new CherryHangingSignBlock(Identifier, true, 15, true),
            5225 => new CherryHangingSignBlock(Identifier, true, 15, false),
            5226 => new CherryHangingSignBlock(Identifier, false, 0, true),
            5227 => new CherryHangingSignBlock(Identifier, false, 0, false),
            5228 => new CherryHangingSignBlock(Identifier, false, 1, true),
            5229 => new CherryHangingSignBlock(Identifier, false, 1, false),
            5230 => new CherryHangingSignBlock(Identifier, false, 2, true),
            5231 => new CherryHangingSignBlock(Identifier, false, 2, false),
            5232 => new CherryHangingSignBlock(Identifier, false, 3, true),
            5233 => new CherryHangingSignBlock(Identifier, false, 3, false),
            5234 => new CherryHangingSignBlock(Identifier, false, 4, true),
            5235 => new CherryHangingSignBlock(Identifier, false, 4, false),
            5236 => new CherryHangingSignBlock(Identifier, false, 5, true),
            5237 => new CherryHangingSignBlock(Identifier, false, 5, false),
            5238 => new CherryHangingSignBlock(Identifier, false, 6, true),
            5239 => new CherryHangingSignBlock(Identifier, false, 6, false),
            5240 => new CherryHangingSignBlock(Identifier, false, 7, true),
            5241 => new CherryHangingSignBlock(Identifier, false, 7, false),
            5242 => new CherryHangingSignBlock(Identifier, false, 8, true),
            5243 => new CherryHangingSignBlock(Identifier, false, 8, false),
            5244 => new CherryHangingSignBlock(Identifier, false, 9, true),
            5245 => new CherryHangingSignBlock(Identifier, false, 9, false),
            5246 => new CherryHangingSignBlock(Identifier, false, 10, true),
            5247 => new CherryHangingSignBlock(Identifier, false, 10, false),
            5248 => new CherryHangingSignBlock(Identifier, false, 11, true),
            5249 => new CherryHangingSignBlock(Identifier, false, 11, false),
            5250 => new CherryHangingSignBlock(Identifier, false, 12, true),
            5251 => new CherryHangingSignBlock(Identifier, false, 12, false),
            5252 => new CherryHangingSignBlock(Identifier, false, 13, true),
            5253 => new CherryHangingSignBlock(Identifier, false, 13, false),
            5254 => new CherryHangingSignBlock(Identifier, false, 14, true),
            5255 => new CherryHangingSignBlock(Identifier, false, 14, false),
            5256 => new CherryHangingSignBlock(Identifier, false, 15, true),
            5257 => new CherryHangingSignBlock(Identifier, false, 15, false),
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
