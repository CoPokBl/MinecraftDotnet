using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:spruce_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5971,
                        false => 5972,
                    },
                    1 => Waterlogged switch {
                        true => 5973,
                        false => 5974,
                    },
                    2 => Waterlogged switch {
                        true => 5975,
                        false => 5976,
                    },
                    3 => Waterlogged switch {
                        true => 5977,
                        false => 5978,
                    },
                    4 => Waterlogged switch {
                        true => 5979,
                        false => 5980,
                    },
                    5 => Waterlogged switch {
                        true => 5981,
                        false => 5982,
                    },
                    6 => Waterlogged switch {
                        true => 5983,
                        false => 5984,
                    },
                    7 => Waterlogged switch {
                        true => 5985,
                        false => 5986,
                    },
                    8 => Waterlogged switch {
                        true => 5987,
                        false => 5988,
                    },
                    9 => Waterlogged switch {
                        true => 5989,
                        false => 5990,
                    },
                    10 => Waterlogged switch {
                        true => 5991,
                        false => 5992,
                    },
                    11 => Waterlogged switch {
                        true => 5993,
                        false => 5994,
                    },
                    12 => Waterlogged switch {
                        true => 5995,
                        false => 5996,
                    },
                    13 => Waterlogged switch {
                        true => 5997,
                        false => 5998,
                    },
                    14 => Waterlogged switch {
                        true => 5999,
                        false => 6000,
                    },
                    15 => Waterlogged switch {
                        true => 6001,
                        false => 6002,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6003,
                        false => 6004,
                    },
                    1 => Waterlogged switch {
                        true => 6005,
                        false => 6006,
                    },
                    2 => Waterlogged switch {
                        true => 6007,
                        false => 6008,
                    },
                    3 => Waterlogged switch {
                        true => 6009,
                        false => 6010,
                    },
                    4 => Waterlogged switch {
                        true => 6011,
                        false => 6012,
                    },
                    5 => Waterlogged switch {
                        true => 6013,
                        false => 6014,
                    },
                    6 => Waterlogged switch {
                        true => 6015,
                        false => 6016,
                    },
                    7 => Waterlogged switch {
                        true => 6017,
                        false => 6018,
                    },
                    8 => Waterlogged switch {
                        true => 6019,
                        false => 6020,
                    },
                    9 => Waterlogged switch {
                        true => 6021,
                        false => 6022,
                    },
                    10 => Waterlogged switch {
                        true => 6023,
                        false => 6024,
                    },
                    11 => Waterlogged switch {
                        true => 6025,
                        false => 6026,
                    },
                    12 => Waterlogged switch {
                        true => 6027,
                        false => 6028,
                    },
                    13 => Waterlogged switch {
                        true => 6029,
                        false => 6030,
                    },
                    14 => Waterlogged switch {
                        true => 6031,
                        false => 6032,
                    },
                    15 => Waterlogged switch {
                        true => 6033,
                        false => 6034,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5971 => new SpruceHangingSignBlock(Identifier, true, 0, true),
            5972 => new SpruceHangingSignBlock(Identifier, true, 0, false),
            5973 => new SpruceHangingSignBlock(Identifier, true, 1, true),
            5974 => new SpruceHangingSignBlock(Identifier, true, 1, false),
            5975 => new SpruceHangingSignBlock(Identifier, true, 2, true),
            5976 => new SpruceHangingSignBlock(Identifier, true, 2, false),
            5977 => new SpruceHangingSignBlock(Identifier, true, 3, true),
            5978 => new SpruceHangingSignBlock(Identifier, true, 3, false),
            5979 => new SpruceHangingSignBlock(Identifier, true, 4, true),
            5980 => new SpruceHangingSignBlock(Identifier, true, 4, false),
            5981 => new SpruceHangingSignBlock(Identifier, true, 5, true),
            5982 => new SpruceHangingSignBlock(Identifier, true, 5, false),
            5983 => new SpruceHangingSignBlock(Identifier, true, 6, true),
            5984 => new SpruceHangingSignBlock(Identifier, true, 6, false),
            5985 => new SpruceHangingSignBlock(Identifier, true, 7, true),
            5986 => new SpruceHangingSignBlock(Identifier, true, 7, false),
            5987 => new SpruceHangingSignBlock(Identifier, true, 8, true),
            5988 => new SpruceHangingSignBlock(Identifier, true, 8, false),
            5989 => new SpruceHangingSignBlock(Identifier, true, 9, true),
            5990 => new SpruceHangingSignBlock(Identifier, true, 9, false),
            5991 => new SpruceHangingSignBlock(Identifier, true, 10, true),
            5992 => new SpruceHangingSignBlock(Identifier, true, 10, false),
            5993 => new SpruceHangingSignBlock(Identifier, true, 11, true),
            5994 => new SpruceHangingSignBlock(Identifier, true, 11, false),
            5995 => new SpruceHangingSignBlock(Identifier, true, 12, true),
            5996 => new SpruceHangingSignBlock(Identifier, true, 12, false),
            5997 => new SpruceHangingSignBlock(Identifier, true, 13, true),
            5998 => new SpruceHangingSignBlock(Identifier, true, 13, false),
            5999 => new SpruceHangingSignBlock(Identifier, true, 14, true),
            6000 => new SpruceHangingSignBlock(Identifier, true, 14, false),
            6001 => new SpruceHangingSignBlock(Identifier, true, 15, true),
            6002 => new SpruceHangingSignBlock(Identifier, true, 15, false),
            6003 => new SpruceHangingSignBlock(Identifier, false, 0, true),
            6004 => new SpruceHangingSignBlock(Identifier, false, 0, false),
            6005 => new SpruceHangingSignBlock(Identifier, false, 1, true),
            6006 => new SpruceHangingSignBlock(Identifier, false, 1, false),
            6007 => new SpruceHangingSignBlock(Identifier, false, 2, true),
            6008 => new SpruceHangingSignBlock(Identifier, false, 2, false),
            6009 => new SpruceHangingSignBlock(Identifier, false, 3, true),
            6010 => new SpruceHangingSignBlock(Identifier, false, 3, false),
            6011 => new SpruceHangingSignBlock(Identifier, false, 4, true),
            6012 => new SpruceHangingSignBlock(Identifier, false, 4, false),
            6013 => new SpruceHangingSignBlock(Identifier, false, 5, true),
            6014 => new SpruceHangingSignBlock(Identifier, false, 5, false),
            6015 => new SpruceHangingSignBlock(Identifier, false, 6, true),
            6016 => new SpruceHangingSignBlock(Identifier, false, 6, false),
            6017 => new SpruceHangingSignBlock(Identifier, false, 7, true),
            6018 => new SpruceHangingSignBlock(Identifier, false, 7, false),
            6019 => new SpruceHangingSignBlock(Identifier, false, 8, true),
            6020 => new SpruceHangingSignBlock(Identifier, false, 8, false),
            6021 => new SpruceHangingSignBlock(Identifier, false, 9, true),
            6022 => new SpruceHangingSignBlock(Identifier, false, 9, false),
            6023 => new SpruceHangingSignBlock(Identifier, false, 10, true),
            6024 => new SpruceHangingSignBlock(Identifier, false, 10, false),
            6025 => new SpruceHangingSignBlock(Identifier, false, 11, true),
            6026 => new SpruceHangingSignBlock(Identifier, false, 11, false),
            6027 => new SpruceHangingSignBlock(Identifier, false, 12, true),
            6028 => new SpruceHangingSignBlock(Identifier, false, 12, false),
            6029 => new SpruceHangingSignBlock(Identifier, false, 13, true),
            6030 => new SpruceHangingSignBlock(Identifier, false, 13, false),
            6031 => new SpruceHangingSignBlock(Identifier, false, 14, true),
            6032 => new SpruceHangingSignBlock(Identifier, false, 14, false),
            6033 => new SpruceHangingSignBlock(Identifier, false, 15, true),
            6034 => new SpruceHangingSignBlock(Identifier, false, 15, false),
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
