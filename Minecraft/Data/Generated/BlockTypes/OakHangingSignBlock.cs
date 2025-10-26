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
    public int ProtocolId => 233;
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
                        true => 5706,
                        false => 5707,
                    },
                    1 => Waterlogged switch {
                        true => 5708,
                        false => 5709,
                    },
                    2 => Waterlogged switch {
                        true => 5710,
                        false => 5711,
                    },
                    3 => Waterlogged switch {
                        true => 5712,
                        false => 5713,
                    },
                    4 => Waterlogged switch {
                        true => 5714,
                        false => 5715,
                    },
                    5 => Waterlogged switch {
                        true => 5716,
                        false => 5717,
                    },
                    6 => Waterlogged switch {
                        true => 5718,
                        false => 5719,
                    },
                    7 => Waterlogged switch {
                        true => 5720,
                        false => 5721,
                    },
                    8 => Waterlogged switch {
                        true => 5722,
                        false => 5723,
                    },
                    9 => Waterlogged switch {
                        true => 5724,
                        false => 5725,
                    },
                    10 => Waterlogged switch {
                        true => 5726,
                        false => 5727,
                    },
                    11 => Waterlogged switch {
                        true => 5728,
                        false => 5729,
                    },
                    12 => Waterlogged switch {
                        true => 5730,
                        false => 5731,
                    },
                    13 => Waterlogged switch {
                        true => 5732,
                        false => 5733,
                    },
                    14 => Waterlogged switch {
                        true => 5734,
                        false => 5735,
                    },
                    15 => Waterlogged switch {
                        true => 5736,
                        false => 5737,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5738,
                        false => 5739,
                    },
                    1 => Waterlogged switch {
                        true => 5740,
                        false => 5741,
                    },
                    2 => Waterlogged switch {
                        true => 5742,
                        false => 5743,
                    },
                    3 => Waterlogged switch {
                        true => 5744,
                        false => 5745,
                    },
                    4 => Waterlogged switch {
                        true => 5746,
                        false => 5747,
                    },
                    5 => Waterlogged switch {
                        true => 5748,
                        false => 5749,
                    },
                    6 => Waterlogged switch {
                        true => 5750,
                        false => 5751,
                    },
                    7 => Waterlogged switch {
                        true => 5752,
                        false => 5753,
                    },
                    8 => Waterlogged switch {
                        true => 5754,
                        false => 5755,
                    },
                    9 => Waterlogged switch {
                        true => 5756,
                        false => 5757,
                    },
                    10 => Waterlogged switch {
                        true => 5758,
                        false => 5759,
                    },
                    11 => Waterlogged switch {
                        true => 5760,
                        false => 5761,
                    },
                    12 => Waterlogged switch {
                        true => 5762,
                        false => 5763,
                    },
                    13 => Waterlogged switch {
                        true => 5764,
                        false => 5765,
                    },
                    14 => Waterlogged switch {
                        true => 5766,
                        false => 5767,
                    },
                    15 => Waterlogged switch {
                        true => 5768,
                        false => 5769,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5706 => new OakHangingSignBlock(Identifier, true, 0, true),
            5707 => new OakHangingSignBlock(Identifier, true, 0, false),
            5708 => new OakHangingSignBlock(Identifier, true, 1, true),
            5709 => new OakHangingSignBlock(Identifier, true, 1, false),
            5710 => new OakHangingSignBlock(Identifier, true, 2, true),
            5711 => new OakHangingSignBlock(Identifier, true, 2, false),
            5712 => new OakHangingSignBlock(Identifier, true, 3, true),
            5713 => new OakHangingSignBlock(Identifier, true, 3, false),
            5714 => new OakHangingSignBlock(Identifier, true, 4, true),
            5715 => new OakHangingSignBlock(Identifier, true, 4, false),
            5716 => new OakHangingSignBlock(Identifier, true, 5, true),
            5717 => new OakHangingSignBlock(Identifier, true, 5, false),
            5718 => new OakHangingSignBlock(Identifier, true, 6, true),
            5719 => new OakHangingSignBlock(Identifier, true, 6, false),
            5720 => new OakHangingSignBlock(Identifier, true, 7, true),
            5721 => new OakHangingSignBlock(Identifier, true, 7, false),
            5722 => new OakHangingSignBlock(Identifier, true, 8, true),
            5723 => new OakHangingSignBlock(Identifier, true, 8, false),
            5724 => new OakHangingSignBlock(Identifier, true, 9, true),
            5725 => new OakHangingSignBlock(Identifier, true, 9, false),
            5726 => new OakHangingSignBlock(Identifier, true, 10, true),
            5727 => new OakHangingSignBlock(Identifier, true, 10, false),
            5728 => new OakHangingSignBlock(Identifier, true, 11, true),
            5729 => new OakHangingSignBlock(Identifier, true, 11, false),
            5730 => new OakHangingSignBlock(Identifier, true, 12, true),
            5731 => new OakHangingSignBlock(Identifier, true, 12, false),
            5732 => new OakHangingSignBlock(Identifier, true, 13, true),
            5733 => new OakHangingSignBlock(Identifier, true, 13, false),
            5734 => new OakHangingSignBlock(Identifier, true, 14, true),
            5735 => new OakHangingSignBlock(Identifier, true, 14, false),
            5736 => new OakHangingSignBlock(Identifier, true, 15, true),
            5737 => new OakHangingSignBlock(Identifier, true, 15, false),
            5738 => new OakHangingSignBlock(Identifier, false, 0, true),
            5739 => new OakHangingSignBlock(Identifier, false, 0, false),
            5740 => new OakHangingSignBlock(Identifier, false, 1, true),
            5741 => new OakHangingSignBlock(Identifier, false, 1, false),
            5742 => new OakHangingSignBlock(Identifier, false, 2, true),
            5743 => new OakHangingSignBlock(Identifier, false, 2, false),
            5744 => new OakHangingSignBlock(Identifier, false, 3, true),
            5745 => new OakHangingSignBlock(Identifier, false, 3, false),
            5746 => new OakHangingSignBlock(Identifier, false, 4, true),
            5747 => new OakHangingSignBlock(Identifier, false, 4, false),
            5748 => new OakHangingSignBlock(Identifier, false, 5, true),
            5749 => new OakHangingSignBlock(Identifier, false, 5, false),
            5750 => new OakHangingSignBlock(Identifier, false, 6, true),
            5751 => new OakHangingSignBlock(Identifier, false, 6, false),
            5752 => new OakHangingSignBlock(Identifier, false, 7, true),
            5753 => new OakHangingSignBlock(Identifier, false, 7, false),
            5754 => new OakHangingSignBlock(Identifier, false, 8, true),
            5755 => new OakHangingSignBlock(Identifier, false, 8, false),
            5756 => new OakHangingSignBlock(Identifier, false, 9, true),
            5757 => new OakHangingSignBlock(Identifier, false, 9, false),
            5758 => new OakHangingSignBlock(Identifier, false, 10, true),
            5759 => new OakHangingSignBlock(Identifier, false, 10, false),
            5760 => new OakHangingSignBlock(Identifier, false, 11, true),
            5761 => new OakHangingSignBlock(Identifier, false, 11, false),
            5762 => new OakHangingSignBlock(Identifier, false, 12, true),
            5763 => new OakHangingSignBlock(Identifier, false, 12, false),
            5764 => new OakHangingSignBlock(Identifier, false, 13, true),
            5765 => new OakHangingSignBlock(Identifier, false, 13, false),
            5766 => new OakHangingSignBlock(Identifier, false, 14, true),
            5767 => new OakHangingSignBlock(Identifier, false, 14, false),
            5768 => new OakHangingSignBlock(Identifier, false, 15, true),
            5769 => new OakHangingSignBlock(Identifier, false, 15, false),
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
