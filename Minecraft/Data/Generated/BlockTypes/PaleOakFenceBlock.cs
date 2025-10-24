using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 641;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13762,
                                false => 13763,
                            },
                            false => West switch {
                                true => 13764,
                                false => 13765,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13766,
                                false => 13767,
                            },
                            false => West switch {
                                true => 13768,
                                false => 13769,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13770,
                                false => 13771,
                            },
                            false => West switch {
                                true => 13772,
                                false => 13773,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13774,
                                false => 13775,
                            },
                            false => West switch {
                                true => 13776,
                                false => 13777,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13778,
                                false => 13779,
                            },
                            false => West switch {
                                true => 13780,
                                false => 13781,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13782,
                                false => 13783,
                            },
                            false => West switch {
                                true => 13784,
                                false => 13785,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13786,
                                false => 13787,
                            },
                            false => West switch {
                                true => 13788,
                                false => 13789,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13790,
                                false => 13791,
                            },
                            false => West switch {
                                true => 13792,
                                false => 13793,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13762 => new PaleOakFenceBlock(Identifier, true, true, true, true, true),
            13763 => new PaleOakFenceBlock(Identifier, true, true, true, true, false),
            13764 => new PaleOakFenceBlock(Identifier, true, true, true, false, true),
            13765 => new PaleOakFenceBlock(Identifier, true, true, true, false, false),
            13766 => new PaleOakFenceBlock(Identifier, true, true, false, true, true),
            13767 => new PaleOakFenceBlock(Identifier, true, true, false, true, false),
            13768 => new PaleOakFenceBlock(Identifier, true, true, false, false, true),
            13769 => new PaleOakFenceBlock(Identifier, true, true, false, false, false),
            13770 => new PaleOakFenceBlock(Identifier, true, false, true, true, true),
            13771 => new PaleOakFenceBlock(Identifier, true, false, true, true, false),
            13772 => new PaleOakFenceBlock(Identifier, true, false, true, false, true),
            13773 => new PaleOakFenceBlock(Identifier, true, false, true, false, false),
            13774 => new PaleOakFenceBlock(Identifier, true, false, false, true, true),
            13775 => new PaleOakFenceBlock(Identifier, true, false, false, true, false),
            13776 => new PaleOakFenceBlock(Identifier, true, false, false, false, true),
            13777 => new PaleOakFenceBlock(Identifier, true, false, false, false, false),
            13778 => new PaleOakFenceBlock(Identifier, false, true, true, true, true),
            13779 => new PaleOakFenceBlock(Identifier, false, true, true, true, false),
            13780 => new PaleOakFenceBlock(Identifier, false, true, true, false, true),
            13781 => new PaleOakFenceBlock(Identifier, false, true, true, false, false),
            13782 => new PaleOakFenceBlock(Identifier, false, true, false, true, true),
            13783 => new PaleOakFenceBlock(Identifier, false, true, false, true, false),
            13784 => new PaleOakFenceBlock(Identifier, false, true, false, false, true),
            13785 => new PaleOakFenceBlock(Identifier, false, true, false, false, false),
            13786 => new PaleOakFenceBlock(Identifier, false, false, true, true, true),
            13787 => new PaleOakFenceBlock(Identifier, false, false, true, true, false),
            13788 => new PaleOakFenceBlock(Identifier, false, false, true, false, true),
            13789 => new PaleOakFenceBlock(Identifier, false, false, true, false, false),
            13790 => new PaleOakFenceBlock(Identifier, false, false, false, true, true),
            13791 => new PaleOakFenceBlock(Identifier, false, false, false, true, false),
            13792 => new PaleOakFenceBlock(Identifier, false, false, false, false, true),
            13793 => new PaleOakFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
