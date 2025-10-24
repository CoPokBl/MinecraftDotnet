using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 235;
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
    public Identifier? Item => "minecraft:birch_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5834,
                        false => 5835,
                    },
                    1 => Waterlogged switch {
                        true => 5836,
                        false => 5837,
                    },
                    2 => Waterlogged switch {
                        true => 5838,
                        false => 5839,
                    },
                    3 => Waterlogged switch {
                        true => 5840,
                        false => 5841,
                    },
                    4 => Waterlogged switch {
                        true => 5842,
                        false => 5843,
                    },
                    5 => Waterlogged switch {
                        true => 5844,
                        false => 5845,
                    },
                    6 => Waterlogged switch {
                        true => 5846,
                        false => 5847,
                    },
                    7 => Waterlogged switch {
                        true => 5848,
                        false => 5849,
                    },
                    8 => Waterlogged switch {
                        true => 5850,
                        false => 5851,
                    },
                    9 => Waterlogged switch {
                        true => 5852,
                        false => 5853,
                    },
                    10 => Waterlogged switch {
                        true => 5854,
                        false => 5855,
                    },
                    11 => Waterlogged switch {
                        true => 5856,
                        false => 5857,
                    },
                    12 => Waterlogged switch {
                        true => 5858,
                        false => 5859,
                    },
                    13 => Waterlogged switch {
                        true => 5860,
                        false => 5861,
                    },
                    14 => Waterlogged switch {
                        true => 5862,
                        false => 5863,
                    },
                    15 => Waterlogged switch {
                        true => 5864,
                        false => 5865,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5866,
                        false => 5867,
                    },
                    1 => Waterlogged switch {
                        true => 5868,
                        false => 5869,
                    },
                    2 => Waterlogged switch {
                        true => 5870,
                        false => 5871,
                    },
                    3 => Waterlogged switch {
                        true => 5872,
                        false => 5873,
                    },
                    4 => Waterlogged switch {
                        true => 5874,
                        false => 5875,
                    },
                    5 => Waterlogged switch {
                        true => 5876,
                        false => 5877,
                    },
                    6 => Waterlogged switch {
                        true => 5878,
                        false => 5879,
                    },
                    7 => Waterlogged switch {
                        true => 5880,
                        false => 5881,
                    },
                    8 => Waterlogged switch {
                        true => 5882,
                        false => 5883,
                    },
                    9 => Waterlogged switch {
                        true => 5884,
                        false => 5885,
                    },
                    10 => Waterlogged switch {
                        true => 5886,
                        false => 5887,
                    },
                    11 => Waterlogged switch {
                        true => 5888,
                        false => 5889,
                    },
                    12 => Waterlogged switch {
                        true => 5890,
                        false => 5891,
                    },
                    13 => Waterlogged switch {
                        true => 5892,
                        false => 5893,
                    },
                    14 => Waterlogged switch {
                        true => 5894,
                        false => 5895,
                    },
                    15 => Waterlogged switch {
                        true => 5896,
                        false => 5897,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5834 => new BirchHangingSignBlock(Identifier, true, 0, true),
            5835 => new BirchHangingSignBlock(Identifier, true, 0, false),
            5836 => new BirchHangingSignBlock(Identifier, true, 1, true),
            5837 => new BirchHangingSignBlock(Identifier, true, 1, false),
            5838 => new BirchHangingSignBlock(Identifier, true, 2, true),
            5839 => new BirchHangingSignBlock(Identifier, true, 2, false),
            5840 => new BirchHangingSignBlock(Identifier, true, 3, true),
            5841 => new BirchHangingSignBlock(Identifier, true, 3, false),
            5842 => new BirchHangingSignBlock(Identifier, true, 4, true),
            5843 => new BirchHangingSignBlock(Identifier, true, 4, false),
            5844 => new BirchHangingSignBlock(Identifier, true, 5, true),
            5845 => new BirchHangingSignBlock(Identifier, true, 5, false),
            5846 => new BirchHangingSignBlock(Identifier, true, 6, true),
            5847 => new BirchHangingSignBlock(Identifier, true, 6, false),
            5848 => new BirchHangingSignBlock(Identifier, true, 7, true),
            5849 => new BirchHangingSignBlock(Identifier, true, 7, false),
            5850 => new BirchHangingSignBlock(Identifier, true, 8, true),
            5851 => new BirchHangingSignBlock(Identifier, true, 8, false),
            5852 => new BirchHangingSignBlock(Identifier, true, 9, true),
            5853 => new BirchHangingSignBlock(Identifier, true, 9, false),
            5854 => new BirchHangingSignBlock(Identifier, true, 10, true),
            5855 => new BirchHangingSignBlock(Identifier, true, 10, false),
            5856 => new BirchHangingSignBlock(Identifier, true, 11, true),
            5857 => new BirchHangingSignBlock(Identifier, true, 11, false),
            5858 => new BirchHangingSignBlock(Identifier, true, 12, true),
            5859 => new BirchHangingSignBlock(Identifier, true, 12, false),
            5860 => new BirchHangingSignBlock(Identifier, true, 13, true),
            5861 => new BirchHangingSignBlock(Identifier, true, 13, false),
            5862 => new BirchHangingSignBlock(Identifier, true, 14, true),
            5863 => new BirchHangingSignBlock(Identifier, true, 14, false),
            5864 => new BirchHangingSignBlock(Identifier, true, 15, true),
            5865 => new BirchHangingSignBlock(Identifier, true, 15, false),
            5866 => new BirchHangingSignBlock(Identifier, false, 0, true),
            5867 => new BirchHangingSignBlock(Identifier, false, 0, false),
            5868 => new BirchHangingSignBlock(Identifier, false, 1, true),
            5869 => new BirchHangingSignBlock(Identifier, false, 1, false),
            5870 => new BirchHangingSignBlock(Identifier, false, 2, true),
            5871 => new BirchHangingSignBlock(Identifier, false, 2, false),
            5872 => new BirchHangingSignBlock(Identifier, false, 3, true),
            5873 => new BirchHangingSignBlock(Identifier, false, 3, false),
            5874 => new BirchHangingSignBlock(Identifier, false, 4, true),
            5875 => new BirchHangingSignBlock(Identifier, false, 4, false),
            5876 => new BirchHangingSignBlock(Identifier, false, 5, true),
            5877 => new BirchHangingSignBlock(Identifier, false, 5, false),
            5878 => new BirchHangingSignBlock(Identifier, false, 6, true),
            5879 => new BirchHangingSignBlock(Identifier, false, 6, false),
            5880 => new BirchHangingSignBlock(Identifier, false, 7, true),
            5881 => new BirchHangingSignBlock(Identifier, false, 7, false),
            5882 => new BirchHangingSignBlock(Identifier, false, 8, true),
            5883 => new BirchHangingSignBlock(Identifier, false, 8, false),
            5884 => new BirchHangingSignBlock(Identifier, false, 9, true),
            5885 => new BirchHangingSignBlock(Identifier, false, 9, false),
            5886 => new BirchHangingSignBlock(Identifier, false, 10, true),
            5887 => new BirchHangingSignBlock(Identifier, false, 10, false),
            5888 => new BirchHangingSignBlock(Identifier, false, 11, true),
            5889 => new BirchHangingSignBlock(Identifier, false, 11, false),
            5890 => new BirchHangingSignBlock(Identifier, false, 12, true),
            5891 => new BirchHangingSignBlock(Identifier, false, 12, false),
            5892 => new BirchHangingSignBlock(Identifier, false, 13, true),
            5893 => new BirchHangingSignBlock(Identifier, false, 13, false),
            5894 => new BirchHangingSignBlock(Identifier, false, 14, true),
            5895 => new BirchHangingSignBlock(Identifier, false, 14, false),
            5896 => new BirchHangingSignBlock(Identifier, false, 15, true),
            5897 => new BirchHangingSignBlock(Identifier, false, 15, false),
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
