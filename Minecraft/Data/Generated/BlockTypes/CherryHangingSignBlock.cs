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
    public int ProtocolId => 237;
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
                        true => 5962,
                        false => 5963,
                    },
                    1 => Waterlogged switch {
                        true => 5964,
                        false => 5965,
                    },
                    2 => Waterlogged switch {
                        true => 5966,
                        false => 5967,
                    },
                    3 => Waterlogged switch {
                        true => 5968,
                        false => 5969,
                    },
                    4 => Waterlogged switch {
                        true => 5970,
                        false => 5971,
                    },
                    5 => Waterlogged switch {
                        true => 5972,
                        false => 5973,
                    },
                    6 => Waterlogged switch {
                        true => 5974,
                        false => 5975,
                    },
                    7 => Waterlogged switch {
                        true => 5976,
                        false => 5977,
                    },
                    8 => Waterlogged switch {
                        true => 5978,
                        false => 5979,
                    },
                    9 => Waterlogged switch {
                        true => 5980,
                        false => 5981,
                    },
                    10 => Waterlogged switch {
                        true => 5982,
                        false => 5983,
                    },
                    11 => Waterlogged switch {
                        true => 5984,
                        false => 5985,
                    },
                    12 => Waterlogged switch {
                        true => 5986,
                        false => 5987,
                    },
                    13 => Waterlogged switch {
                        true => 5988,
                        false => 5989,
                    },
                    14 => Waterlogged switch {
                        true => 5990,
                        false => 5991,
                    },
                    15 => Waterlogged switch {
                        true => 5992,
                        false => 5993,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5994,
                        false => 5995,
                    },
                    1 => Waterlogged switch {
                        true => 5996,
                        false => 5997,
                    },
                    2 => Waterlogged switch {
                        true => 5998,
                        false => 5999,
                    },
                    3 => Waterlogged switch {
                        true => 6000,
                        false => 6001,
                    },
                    4 => Waterlogged switch {
                        true => 6002,
                        false => 6003,
                    },
                    5 => Waterlogged switch {
                        true => 6004,
                        false => 6005,
                    },
                    6 => Waterlogged switch {
                        true => 6006,
                        false => 6007,
                    },
                    7 => Waterlogged switch {
                        true => 6008,
                        false => 6009,
                    },
                    8 => Waterlogged switch {
                        true => 6010,
                        false => 6011,
                    },
                    9 => Waterlogged switch {
                        true => 6012,
                        false => 6013,
                    },
                    10 => Waterlogged switch {
                        true => 6014,
                        false => 6015,
                    },
                    11 => Waterlogged switch {
                        true => 6016,
                        false => 6017,
                    },
                    12 => Waterlogged switch {
                        true => 6018,
                        false => 6019,
                    },
                    13 => Waterlogged switch {
                        true => 6020,
                        false => 6021,
                    },
                    14 => Waterlogged switch {
                        true => 6022,
                        false => 6023,
                    },
                    15 => Waterlogged switch {
                        true => 6024,
                        false => 6025,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5962 => new CherryHangingSignBlock(Identifier, true, 0, true),
            5963 => new CherryHangingSignBlock(Identifier, true, 0, false),
            5964 => new CherryHangingSignBlock(Identifier, true, 1, true),
            5965 => new CherryHangingSignBlock(Identifier, true, 1, false),
            5966 => new CherryHangingSignBlock(Identifier, true, 2, true),
            5967 => new CherryHangingSignBlock(Identifier, true, 2, false),
            5968 => new CherryHangingSignBlock(Identifier, true, 3, true),
            5969 => new CherryHangingSignBlock(Identifier, true, 3, false),
            5970 => new CherryHangingSignBlock(Identifier, true, 4, true),
            5971 => new CherryHangingSignBlock(Identifier, true, 4, false),
            5972 => new CherryHangingSignBlock(Identifier, true, 5, true),
            5973 => new CherryHangingSignBlock(Identifier, true, 5, false),
            5974 => new CherryHangingSignBlock(Identifier, true, 6, true),
            5975 => new CherryHangingSignBlock(Identifier, true, 6, false),
            5976 => new CherryHangingSignBlock(Identifier, true, 7, true),
            5977 => new CherryHangingSignBlock(Identifier, true, 7, false),
            5978 => new CherryHangingSignBlock(Identifier, true, 8, true),
            5979 => new CherryHangingSignBlock(Identifier, true, 8, false),
            5980 => new CherryHangingSignBlock(Identifier, true, 9, true),
            5981 => new CherryHangingSignBlock(Identifier, true, 9, false),
            5982 => new CherryHangingSignBlock(Identifier, true, 10, true),
            5983 => new CherryHangingSignBlock(Identifier, true, 10, false),
            5984 => new CherryHangingSignBlock(Identifier, true, 11, true),
            5985 => new CherryHangingSignBlock(Identifier, true, 11, false),
            5986 => new CherryHangingSignBlock(Identifier, true, 12, true),
            5987 => new CherryHangingSignBlock(Identifier, true, 12, false),
            5988 => new CherryHangingSignBlock(Identifier, true, 13, true),
            5989 => new CherryHangingSignBlock(Identifier, true, 13, false),
            5990 => new CherryHangingSignBlock(Identifier, true, 14, true),
            5991 => new CherryHangingSignBlock(Identifier, true, 14, false),
            5992 => new CherryHangingSignBlock(Identifier, true, 15, true),
            5993 => new CherryHangingSignBlock(Identifier, true, 15, false),
            5994 => new CherryHangingSignBlock(Identifier, false, 0, true),
            5995 => new CherryHangingSignBlock(Identifier, false, 0, false),
            5996 => new CherryHangingSignBlock(Identifier, false, 1, true),
            5997 => new CherryHangingSignBlock(Identifier, false, 1, false),
            5998 => new CherryHangingSignBlock(Identifier, false, 2, true),
            5999 => new CherryHangingSignBlock(Identifier, false, 2, false),
            6000 => new CherryHangingSignBlock(Identifier, false, 3, true),
            6001 => new CherryHangingSignBlock(Identifier, false, 3, false),
            6002 => new CherryHangingSignBlock(Identifier, false, 4, true),
            6003 => new CherryHangingSignBlock(Identifier, false, 4, false),
            6004 => new CherryHangingSignBlock(Identifier, false, 5, true),
            6005 => new CherryHangingSignBlock(Identifier, false, 5, false),
            6006 => new CherryHangingSignBlock(Identifier, false, 6, true),
            6007 => new CherryHangingSignBlock(Identifier, false, 6, false),
            6008 => new CherryHangingSignBlock(Identifier, false, 7, true),
            6009 => new CherryHangingSignBlock(Identifier, false, 7, false),
            6010 => new CherryHangingSignBlock(Identifier, false, 8, true),
            6011 => new CherryHangingSignBlock(Identifier, false, 8, false),
            6012 => new CherryHangingSignBlock(Identifier, false, 9, true),
            6013 => new CherryHangingSignBlock(Identifier, false, 9, false),
            6014 => new CherryHangingSignBlock(Identifier, false, 10, true),
            6015 => new CherryHangingSignBlock(Identifier, false, 10, false),
            6016 => new CherryHangingSignBlock(Identifier, false, 11, true),
            6017 => new CherryHangingSignBlock(Identifier, false, 11, false),
            6018 => new CherryHangingSignBlock(Identifier, false, 12, true),
            6019 => new CherryHangingSignBlock(Identifier, false, 12, false),
            6020 => new CherryHangingSignBlock(Identifier, false, 13, true),
            6021 => new CherryHangingSignBlock(Identifier, false, 13, false),
            6022 => new CherryHangingSignBlock(Identifier, false, 14, true),
            6023 => new CherryHangingSignBlock(Identifier, false, 14, false),
            6024 => new CherryHangingSignBlock(Identifier, false, 15, true),
            6025 => new CherryHangingSignBlock(Identifier, false, 15, false),
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
