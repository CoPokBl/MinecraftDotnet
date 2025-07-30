using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 221;
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
    public Identifier? Item => "minecraft:oak_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 4938,
                        false => 4939,
                    },
                    1 => Waterlogged switch {
                        true => 4940,
                        false => 4941,
                    },
                    2 => Waterlogged switch {
                        true => 4942,
                        false => 4943,
                    },
                    3 => Waterlogged switch {
                        true => 4944,
                        false => 4945,
                    },
                    4 => Waterlogged switch {
                        true => 4946,
                        false => 4947,
                    },
                    5 => Waterlogged switch {
                        true => 4948,
                        false => 4949,
                    },
                    6 => Waterlogged switch {
                        true => 4950,
                        false => 4951,
                    },
                    7 => Waterlogged switch {
                        true => 4952,
                        false => 4953,
                    },
                    8 => Waterlogged switch {
                        true => 4954,
                        false => 4955,
                    },
                    9 => Waterlogged switch {
                        true => 4956,
                        false => 4957,
                    },
                    10 => Waterlogged switch {
                        true => 4958,
                        false => 4959,
                    },
                    11 => Waterlogged switch {
                        true => 4960,
                        false => 4961,
                    },
                    12 => Waterlogged switch {
                        true => 4962,
                        false => 4963,
                    },
                    13 => Waterlogged switch {
                        true => 4964,
                        false => 4965,
                    },
                    14 => Waterlogged switch {
                        true => 4966,
                        false => 4967,
                    },
                    15 => Waterlogged switch {
                        true => 4968,
                        false => 4969,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 4970,
                        false => 4971,
                    },
                    1 => Waterlogged switch {
                        true => 4972,
                        false => 4973,
                    },
                    2 => Waterlogged switch {
                        true => 4974,
                        false => 4975,
                    },
                    3 => Waterlogged switch {
                        true => 4976,
                        false => 4977,
                    },
                    4 => Waterlogged switch {
                        true => 4978,
                        false => 4979,
                    },
                    5 => Waterlogged switch {
                        true => 4980,
                        false => 4981,
                    },
                    6 => Waterlogged switch {
                        true => 4982,
                        false => 4983,
                    },
                    7 => Waterlogged switch {
                        true => 4984,
                        false => 4985,
                    },
                    8 => Waterlogged switch {
                        true => 4986,
                        false => 4987,
                    },
                    9 => Waterlogged switch {
                        true => 4988,
                        false => 4989,
                    },
                    10 => Waterlogged switch {
                        true => 4990,
                        false => 4991,
                    },
                    11 => Waterlogged switch {
                        true => 4992,
                        false => 4993,
                    },
                    12 => Waterlogged switch {
                        true => 4994,
                        false => 4995,
                    },
                    13 => Waterlogged switch {
                        true => 4996,
                        false => 4997,
                    },
                    14 => Waterlogged switch {
                        true => 4998,
                        false => 4999,
                    },
                    15 => Waterlogged switch {
                        true => 5000,
                        false => 5001,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4938 => new OakHangingSignBlock(Identifier, true, 0, true),
            4939 => new OakHangingSignBlock(Identifier, true, 0, false),
            4940 => new OakHangingSignBlock(Identifier, true, 1, true),
            4941 => new OakHangingSignBlock(Identifier, true, 1, false),
            4942 => new OakHangingSignBlock(Identifier, true, 2, true),
            4943 => new OakHangingSignBlock(Identifier, true, 2, false),
            4944 => new OakHangingSignBlock(Identifier, true, 3, true),
            4945 => new OakHangingSignBlock(Identifier, true, 3, false),
            4946 => new OakHangingSignBlock(Identifier, true, 4, true),
            4947 => new OakHangingSignBlock(Identifier, true, 4, false),
            4948 => new OakHangingSignBlock(Identifier, true, 5, true),
            4949 => new OakHangingSignBlock(Identifier, true, 5, false),
            4950 => new OakHangingSignBlock(Identifier, true, 6, true),
            4951 => new OakHangingSignBlock(Identifier, true, 6, false),
            4952 => new OakHangingSignBlock(Identifier, true, 7, true),
            4953 => new OakHangingSignBlock(Identifier, true, 7, false),
            4954 => new OakHangingSignBlock(Identifier, true, 8, true),
            4955 => new OakHangingSignBlock(Identifier, true, 8, false),
            4956 => new OakHangingSignBlock(Identifier, true, 9, true),
            4957 => new OakHangingSignBlock(Identifier, true, 9, false),
            4958 => new OakHangingSignBlock(Identifier, true, 10, true),
            4959 => new OakHangingSignBlock(Identifier, true, 10, false),
            4960 => new OakHangingSignBlock(Identifier, true, 11, true),
            4961 => new OakHangingSignBlock(Identifier, true, 11, false),
            4962 => new OakHangingSignBlock(Identifier, true, 12, true),
            4963 => new OakHangingSignBlock(Identifier, true, 12, false),
            4964 => new OakHangingSignBlock(Identifier, true, 13, true),
            4965 => new OakHangingSignBlock(Identifier, true, 13, false),
            4966 => new OakHangingSignBlock(Identifier, true, 14, true),
            4967 => new OakHangingSignBlock(Identifier, true, 14, false),
            4968 => new OakHangingSignBlock(Identifier, true, 15, true),
            4969 => new OakHangingSignBlock(Identifier, true, 15, false),
            4970 => new OakHangingSignBlock(Identifier, false, 0, true),
            4971 => new OakHangingSignBlock(Identifier, false, 0, false),
            4972 => new OakHangingSignBlock(Identifier, false, 1, true),
            4973 => new OakHangingSignBlock(Identifier, false, 1, false),
            4974 => new OakHangingSignBlock(Identifier, false, 2, true),
            4975 => new OakHangingSignBlock(Identifier, false, 2, false),
            4976 => new OakHangingSignBlock(Identifier, false, 3, true),
            4977 => new OakHangingSignBlock(Identifier, false, 3, false),
            4978 => new OakHangingSignBlock(Identifier, false, 4, true),
            4979 => new OakHangingSignBlock(Identifier, false, 4, false),
            4980 => new OakHangingSignBlock(Identifier, false, 5, true),
            4981 => new OakHangingSignBlock(Identifier, false, 5, false),
            4982 => new OakHangingSignBlock(Identifier, false, 6, true),
            4983 => new OakHangingSignBlock(Identifier, false, 6, false),
            4984 => new OakHangingSignBlock(Identifier, false, 7, true),
            4985 => new OakHangingSignBlock(Identifier, false, 7, false),
            4986 => new OakHangingSignBlock(Identifier, false, 8, true),
            4987 => new OakHangingSignBlock(Identifier, false, 8, false),
            4988 => new OakHangingSignBlock(Identifier, false, 9, true),
            4989 => new OakHangingSignBlock(Identifier, false, 9, false),
            4990 => new OakHangingSignBlock(Identifier, false, 10, true),
            4991 => new OakHangingSignBlock(Identifier, false, 10, false),
            4992 => new OakHangingSignBlock(Identifier, false, 11, true),
            4993 => new OakHangingSignBlock(Identifier, false, 11, false),
            4994 => new OakHangingSignBlock(Identifier, false, 12, true),
            4995 => new OakHangingSignBlock(Identifier, false, 12, false),
            4996 => new OakHangingSignBlock(Identifier, false, 13, true),
            4997 => new OakHangingSignBlock(Identifier, false, 13, false),
            4998 => new OakHangingSignBlock(Identifier, false, 14, true),
            4999 => new OakHangingSignBlock(Identifier, false, 14, false),
            5000 => new OakHangingSignBlock(Identifier, false, 15, true),
            5001 => new OakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
