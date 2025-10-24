using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 640;
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
    public Identifier? Item => "minecraft:dark_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13730,
                                false => 13731,
                            },
                            false => West switch {
                                true => 13732,
                                false => 13733,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13734,
                                false => 13735,
                            },
                            false => West switch {
                                true => 13736,
                                false => 13737,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13738,
                                false => 13739,
                            },
                            false => West switch {
                                true => 13740,
                                false => 13741,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13742,
                                false => 13743,
                            },
                            false => West switch {
                                true => 13744,
                                false => 13745,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13746,
                                false => 13747,
                            },
                            false => West switch {
                                true => 13748,
                                false => 13749,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13750,
                                false => 13751,
                            },
                            false => West switch {
                                true => 13752,
                                false => 13753,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13754,
                                false => 13755,
                            },
                            false => West switch {
                                true => 13756,
                                false => 13757,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13758,
                                false => 13759,
                            },
                            false => West switch {
                                true => 13760,
                                false => 13761,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13730 => new DarkOakFenceBlock(Identifier, true, true, true, true, true),
            13731 => new DarkOakFenceBlock(Identifier, true, true, true, true, false),
            13732 => new DarkOakFenceBlock(Identifier, true, true, true, false, true),
            13733 => new DarkOakFenceBlock(Identifier, true, true, true, false, false),
            13734 => new DarkOakFenceBlock(Identifier, true, true, false, true, true),
            13735 => new DarkOakFenceBlock(Identifier, true, true, false, true, false),
            13736 => new DarkOakFenceBlock(Identifier, true, true, false, false, true),
            13737 => new DarkOakFenceBlock(Identifier, true, true, false, false, false),
            13738 => new DarkOakFenceBlock(Identifier, true, false, true, true, true),
            13739 => new DarkOakFenceBlock(Identifier, true, false, true, true, false),
            13740 => new DarkOakFenceBlock(Identifier, true, false, true, false, true),
            13741 => new DarkOakFenceBlock(Identifier, true, false, true, false, false),
            13742 => new DarkOakFenceBlock(Identifier, true, false, false, true, true),
            13743 => new DarkOakFenceBlock(Identifier, true, false, false, true, false),
            13744 => new DarkOakFenceBlock(Identifier, true, false, false, false, true),
            13745 => new DarkOakFenceBlock(Identifier, true, false, false, false, false),
            13746 => new DarkOakFenceBlock(Identifier, false, true, true, true, true),
            13747 => new DarkOakFenceBlock(Identifier, false, true, true, true, false),
            13748 => new DarkOakFenceBlock(Identifier, false, true, true, false, true),
            13749 => new DarkOakFenceBlock(Identifier, false, true, true, false, false),
            13750 => new DarkOakFenceBlock(Identifier, false, true, false, true, true),
            13751 => new DarkOakFenceBlock(Identifier, false, true, false, true, false),
            13752 => new DarkOakFenceBlock(Identifier, false, true, false, false, true),
            13753 => new DarkOakFenceBlock(Identifier, false, true, false, false, false),
            13754 => new DarkOakFenceBlock(Identifier, false, false, true, true, true),
            13755 => new DarkOakFenceBlock(Identifier, false, false, true, true, false),
            13756 => new DarkOakFenceBlock(Identifier, false, false, true, false, true),
            13757 => new DarkOakFenceBlock(Identifier, false, false, true, false, false),
            13758 => new DarkOakFenceBlock(Identifier, false, false, false, true, true),
            13759 => new DarkOakFenceBlock(Identifier, false, false, false, true, false),
            13760 => new DarkOakFenceBlock(Identifier, false, false, false, false, true),
            13761 => new DarkOakFenceBlock(Identifier, false, false, false, false, false),
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
