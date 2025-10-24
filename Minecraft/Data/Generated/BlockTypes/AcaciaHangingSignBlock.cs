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
    public int ProtocolId => 236;
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
                        true => 5898,
                        false => 5899,
                    },
                    1 => Waterlogged switch {
                        true => 5900,
                        false => 5901,
                    },
                    2 => Waterlogged switch {
                        true => 5902,
                        false => 5903,
                    },
                    3 => Waterlogged switch {
                        true => 5904,
                        false => 5905,
                    },
                    4 => Waterlogged switch {
                        true => 5906,
                        false => 5907,
                    },
                    5 => Waterlogged switch {
                        true => 5908,
                        false => 5909,
                    },
                    6 => Waterlogged switch {
                        true => 5910,
                        false => 5911,
                    },
                    7 => Waterlogged switch {
                        true => 5912,
                        false => 5913,
                    },
                    8 => Waterlogged switch {
                        true => 5914,
                        false => 5915,
                    },
                    9 => Waterlogged switch {
                        true => 5916,
                        false => 5917,
                    },
                    10 => Waterlogged switch {
                        true => 5918,
                        false => 5919,
                    },
                    11 => Waterlogged switch {
                        true => 5920,
                        false => 5921,
                    },
                    12 => Waterlogged switch {
                        true => 5922,
                        false => 5923,
                    },
                    13 => Waterlogged switch {
                        true => 5924,
                        false => 5925,
                    },
                    14 => Waterlogged switch {
                        true => 5926,
                        false => 5927,
                    },
                    15 => Waterlogged switch {
                        true => 5928,
                        false => 5929,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5930,
                        false => 5931,
                    },
                    1 => Waterlogged switch {
                        true => 5932,
                        false => 5933,
                    },
                    2 => Waterlogged switch {
                        true => 5934,
                        false => 5935,
                    },
                    3 => Waterlogged switch {
                        true => 5936,
                        false => 5937,
                    },
                    4 => Waterlogged switch {
                        true => 5938,
                        false => 5939,
                    },
                    5 => Waterlogged switch {
                        true => 5940,
                        false => 5941,
                    },
                    6 => Waterlogged switch {
                        true => 5942,
                        false => 5943,
                    },
                    7 => Waterlogged switch {
                        true => 5944,
                        false => 5945,
                    },
                    8 => Waterlogged switch {
                        true => 5946,
                        false => 5947,
                    },
                    9 => Waterlogged switch {
                        true => 5948,
                        false => 5949,
                    },
                    10 => Waterlogged switch {
                        true => 5950,
                        false => 5951,
                    },
                    11 => Waterlogged switch {
                        true => 5952,
                        false => 5953,
                    },
                    12 => Waterlogged switch {
                        true => 5954,
                        false => 5955,
                    },
                    13 => Waterlogged switch {
                        true => 5956,
                        false => 5957,
                    },
                    14 => Waterlogged switch {
                        true => 5958,
                        false => 5959,
                    },
                    15 => Waterlogged switch {
                        true => 5960,
                        false => 5961,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5898 => new AcaciaHangingSignBlock(Identifier, true, 0, true),
            5899 => new AcaciaHangingSignBlock(Identifier, true, 0, false),
            5900 => new AcaciaHangingSignBlock(Identifier, true, 1, true),
            5901 => new AcaciaHangingSignBlock(Identifier, true, 1, false),
            5902 => new AcaciaHangingSignBlock(Identifier, true, 2, true),
            5903 => new AcaciaHangingSignBlock(Identifier, true, 2, false),
            5904 => new AcaciaHangingSignBlock(Identifier, true, 3, true),
            5905 => new AcaciaHangingSignBlock(Identifier, true, 3, false),
            5906 => new AcaciaHangingSignBlock(Identifier, true, 4, true),
            5907 => new AcaciaHangingSignBlock(Identifier, true, 4, false),
            5908 => new AcaciaHangingSignBlock(Identifier, true, 5, true),
            5909 => new AcaciaHangingSignBlock(Identifier, true, 5, false),
            5910 => new AcaciaHangingSignBlock(Identifier, true, 6, true),
            5911 => new AcaciaHangingSignBlock(Identifier, true, 6, false),
            5912 => new AcaciaHangingSignBlock(Identifier, true, 7, true),
            5913 => new AcaciaHangingSignBlock(Identifier, true, 7, false),
            5914 => new AcaciaHangingSignBlock(Identifier, true, 8, true),
            5915 => new AcaciaHangingSignBlock(Identifier, true, 8, false),
            5916 => new AcaciaHangingSignBlock(Identifier, true, 9, true),
            5917 => new AcaciaHangingSignBlock(Identifier, true, 9, false),
            5918 => new AcaciaHangingSignBlock(Identifier, true, 10, true),
            5919 => new AcaciaHangingSignBlock(Identifier, true, 10, false),
            5920 => new AcaciaHangingSignBlock(Identifier, true, 11, true),
            5921 => new AcaciaHangingSignBlock(Identifier, true, 11, false),
            5922 => new AcaciaHangingSignBlock(Identifier, true, 12, true),
            5923 => new AcaciaHangingSignBlock(Identifier, true, 12, false),
            5924 => new AcaciaHangingSignBlock(Identifier, true, 13, true),
            5925 => new AcaciaHangingSignBlock(Identifier, true, 13, false),
            5926 => new AcaciaHangingSignBlock(Identifier, true, 14, true),
            5927 => new AcaciaHangingSignBlock(Identifier, true, 14, false),
            5928 => new AcaciaHangingSignBlock(Identifier, true, 15, true),
            5929 => new AcaciaHangingSignBlock(Identifier, true, 15, false),
            5930 => new AcaciaHangingSignBlock(Identifier, false, 0, true),
            5931 => new AcaciaHangingSignBlock(Identifier, false, 0, false),
            5932 => new AcaciaHangingSignBlock(Identifier, false, 1, true),
            5933 => new AcaciaHangingSignBlock(Identifier, false, 1, false),
            5934 => new AcaciaHangingSignBlock(Identifier, false, 2, true),
            5935 => new AcaciaHangingSignBlock(Identifier, false, 2, false),
            5936 => new AcaciaHangingSignBlock(Identifier, false, 3, true),
            5937 => new AcaciaHangingSignBlock(Identifier, false, 3, false),
            5938 => new AcaciaHangingSignBlock(Identifier, false, 4, true),
            5939 => new AcaciaHangingSignBlock(Identifier, false, 4, false),
            5940 => new AcaciaHangingSignBlock(Identifier, false, 5, true),
            5941 => new AcaciaHangingSignBlock(Identifier, false, 5, false),
            5942 => new AcaciaHangingSignBlock(Identifier, false, 6, true),
            5943 => new AcaciaHangingSignBlock(Identifier, false, 6, false),
            5944 => new AcaciaHangingSignBlock(Identifier, false, 7, true),
            5945 => new AcaciaHangingSignBlock(Identifier, false, 7, false),
            5946 => new AcaciaHangingSignBlock(Identifier, false, 8, true),
            5947 => new AcaciaHangingSignBlock(Identifier, false, 8, false),
            5948 => new AcaciaHangingSignBlock(Identifier, false, 9, true),
            5949 => new AcaciaHangingSignBlock(Identifier, false, 9, false),
            5950 => new AcaciaHangingSignBlock(Identifier, false, 10, true),
            5951 => new AcaciaHangingSignBlock(Identifier, false, 10, false),
            5952 => new AcaciaHangingSignBlock(Identifier, false, 11, true),
            5953 => new AcaciaHangingSignBlock(Identifier, false, 11, false),
            5954 => new AcaciaHangingSignBlock(Identifier, false, 12, true),
            5955 => new AcaciaHangingSignBlock(Identifier, false, 12, false),
            5956 => new AcaciaHangingSignBlock(Identifier, false, 13, true),
            5957 => new AcaciaHangingSignBlock(Identifier, false, 13, false),
            5958 => new AcaciaHangingSignBlock(Identifier, false, 14, true),
            5959 => new AcaciaHangingSignBlock(Identifier, false, 14, false),
            5960 => new AcaciaHangingSignBlock(Identifier, false, 15, true),
            5961 => new AcaciaHangingSignBlock(Identifier, false, 15, false),
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
