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
    public int ProtocolId => 234;
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
                        true => 5770,
                        false => 5771,
                    },
                    1 => Waterlogged switch {
                        true => 5772,
                        false => 5773,
                    },
                    2 => Waterlogged switch {
                        true => 5774,
                        false => 5775,
                    },
                    3 => Waterlogged switch {
                        true => 5776,
                        false => 5777,
                    },
                    4 => Waterlogged switch {
                        true => 5778,
                        false => 5779,
                    },
                    5 => Waterlogged switch {
                        true => 5780,
                        false => 5781,
                    },
                    6 => Waterlogged switch {
                        true => 5782,
                        false => 5783,
                    },
                    7 => Waterlogged switch {
                        true => 5784,
                        false => 5785,
                    },
                    8 => Waterlogged switch {
                        true => 5786,
                        false => 5787,
                    },
                    9 => Waterlogged switch {
                        true => 5788,
                        false => 5789,
                    },
                    10 => Waterlogged switch {
                        true => 5790,
                        false => 5791,
                    },
                    11 => Waterlogged switch {
                        true => 5792,
                        false => 5793,
                    },
                    12 => Waterlogged switch {
                        true => 5794,
                        false => 5795,
                    },
                    13 => Waterlogged switch {
                        true => 5796,
                        false => 5797,
                    },
                    14 => Waterlogged switch {
                        true => 5798,
                        false => 5799,
                    },
                    15 => Waterlogged switch {
                        true => 5800,
                        false => 5801,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5802,
                        false => 5803,
                    },
                    1 => Waterlogged switch {
                        true => 5804,
                        false => 5805,
                    },
                    2 => Waterlogged switch {
                        true => 5806,
                        false => 5807,
                    },
                    3 => Waterlogged switch {
                        true => 5808,
                        false => 5809,
                    },
                    4 => Waterlogged switch {
                        true => 5810,
                        false => 5811,
                    },
                    5 => Waterlogged switch {
                        true => 5812,
                        false => 5813,
                    },
                    6 => Waterlogged switch {
                        true => 5814,
                        false => 5815,
                    },
                    7 => Waterlogged switch {
                        true => 5816,
                        false => 5817,
                    },
                    8 => Waterlogged switch {
                        true => 5818,
                        false => 5819,
                    },
                    9 => Waterlogged switch {
                        true => 5820,
                        false => 5821,
                    },
                    10 => Waterlogged switch {
                        true => 5822,
                        false => 5823,
                    },
                    11 => Waterlogged switch {
                        true => 5824,
                        false => 5825,
                    },
                    12 => Waterlogged switch {
                        true => 5826,
                        false => 5827,
                    },
                    13 => Waterlogged switch {
                        true => 5828,
                        false => 5829,
                    },
                    14 => Waterlogged switch {
                        true => 5830,
                        false => 5831,
                    },
                    15 => Waterlogged switch {
                        true => 5832,
                        false => 5833,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5770 => new SpruceHangingSignBlock(Identifier, true, 0, true),
            5771 => new SpruceHangingSignBlock(Identifier, true, 0, false),
            5772 => new SpruceHangingSignBlock(Identifier, true, 1, true),
            5773 => new SpruceHangingSignBlock(Identifier, true, 1, false),
            5774 => new SpruceHangingSignBlock(Identifier, true, 2, true),
            5775 => new SpruceHangingSignBlock(Identifier, true, 2, false),
            5776 => new SpruceHangingSignBlock(Identifier, true, 3, true),
            5777 => new SpruceHangingSignBlock(Identifier, true, 3, false),
            5778 => new SpruceHangingSignBlock(Identifier, true, 4, true),
            5779 => new SpruceHangingSignBlock(Identifier, true, 4, false),
            5780 => new SpruceHangingSignBlock(Identifier, true, 5, true),
            5781 => new SpruceHangingSignBlock(Identifier, true, 5, false),
            5782 => new SpruceHangingSignBlock(Identifier, true, 6, true),
            5783 => new SpruceHangingSignBlock(Identifier, true, 6, false),
            5784 => new SpruceHangingSignBlock(Identifier, true, 7, true),
            5785 => new SpruceHangingSignBlock(Identifier, true, 7, false),
            5786 => new SpruceHangingSignBlock(Identifier, true, 8, true),
            5787 => new SpruceHangingSignBlock(Identifier, true, 8, false),
            5788 => new SpruceHangingSignBlock(Identifier, true, 9, true),
            5789 => new SpruceHangingSignBlock(Identifier, true, 9, false),
            5790 => new SpruceHangingSignBlock(Identifier, true, 10, true),
            5791 => new SpruceHangingSignBlock(Identifier, true, 10, false),
            5792 => new SpruceHangingSignBlock(Identifier, true, 11, true),
            5793 => new SpruceHangingSignBlock(Identifier, true, 11, false),
            5794 => new SpruceHangingSignBlock(Identifier, true, 12, true),
            5795 => new SpruceHangingSignBlock(Identifier, true, 12, false),
            5796 => new SpruceHangingSignBlock(Identifier, true, 13, true),
            5797 => new SpruceHangingSignBlock(Identifier, true, 13, false),
            5798 => new SpruceHangingSignBlock(Identifier, true, 14, true),
            5799 => new SpruceHangingSignBlock(Identifier, true, 14, false),
            5800 => new SpruceHangingSignBlock(Identifier, true, 15, true),
            5801 => new SpruceHangingSignBlock(Identifier, true, 15, false),
            5802 => new SpruceHangingSignBlock(Identifier, false, 0, true),
            5803 => new SpruceHangingSignBlock(Identifier, false, 0, false),
            5804 => new SpruceHangingSignBlock(Identifier, false, 1, true),
            5805 => new SpruceHangingSignBlock(Identifier, false, 1, false),
            5806 => new SpruceHangingSignBlock(Identifier, false, 2, true),
            5807 => new SpruceHangingSignBlock(Identifier, false, 2, false),
            5808 => new SpruceHangingSignBlock(Identifier, false, 3, true),
            5809 => new SpruceHangingSignBlock(Identifier, false, 3, false),
            5810 => new SpruceHangingSignBlock(Identifier, false, 4, true),
            5811 => new SpruceHangingSignBlock(Identifier, false, 4, false),
            5812 => new SpruceHangingSignBlock(Identifier, false, 5, true),
            5813 => new SpruceHangingSignBlock(Identifier, false, 5, false),
            5814 => new SpruceHangingSignBlock(Identifier, false, 6, true),
            5815 => new SpruceHangingSignBlock(Identifier, false, 6, false),
            5816 => new SpruceHangingSignBlock(Identifier, false, 7, true),
            5817 => new SpruceHangingSignBlock(Identifier, false, 7, false),
            5818 => new SpruceHangingSignBlock(Identifier, false, 8, true),
            5819 => new SpruceHangingSignBlock(Identifier, false, 8, false),
            5820 => new SpruceHangingSignBlock(Identifier, false, 9, true),
            5821 => new SpruceHangingSignBlock(Identifier, false, 9, false),
            5822 => new SpruceHangingSignBlock(Identifier, false, 10, true),
            5823 => new SpruceHangingSignBlock(Identifier, false, 10, false),
            5824 => new SpruceHangingSignBlock(Identifier, false, 11, true),
            5825 => new SpruceHangingSignBlock(Identifier, false, 11, false),
            5826 => new SpruceHangingSignBlock(Identifier, false, 12, true),
            5827 => new SpruceHangingSignBlock(Identifier, false, 12, false),
            5828 => new SpruceHangingSignBlock(Identifier, false, 13, true),
            5829 => new SpruceHangingSignBlock(Identifier, false, 13, false),
            5830 => new SpruceHangingSignBlock(Identifier, false, 14, true),
            5831 => new SpruceHangingSignBlock(Identifier, false, 14, false),
            5832 => new SpruceHangingSignBlock(Identifier, false, 15, true),
            5833 => new SpruceHangingSignBlock(Identifier, false, 15, false),
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
