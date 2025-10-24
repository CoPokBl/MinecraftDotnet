using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 643;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13826,
                                false => 13827,
                            },
                            false => West switch {
                                true => 13828,
                                false => 13829,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13830,
                                false => 13831,
                            },
                            false => West switch {
                                true => 13832,
                                false => 13833,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13834,
                                false => 13835,
                            },
                            false => West switch {
                                true => 13836,
                                false => 13837,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13838,
                                false => 13839,
                            },
                            false => West switch {
                                true => 13840,
                                false => 13841,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13842,
                                false => 13843,
                            },
                            false => West switch {
                                true => 13844,
                                false => 13845,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13846,
                                false => 13847,
                            },
                            false => West switch {
                                true => 13848,
                                false => 13849,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13850,
                                false => 13851,
                            },
                            false => West switch {
                                true => 13852,
                                false => 13853,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13854,
                                false => 13855,
                            },
                            false => West switch {
                                true => 13856,
                                false => 13857,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13826 => new BambooFenceBlock(Identifier, true, true, true, true, true),
            13827 => new BambooFenceBlock(Identifier, true, true, true, true, false),
            13828 => new BambooFenceBlock(Identifier, true, true, true, false, true),
            13829 => new BambooFenceBlock(Identifier, true, true, true, false, false),
            13830 => new BambooFenceBlock(Identifier, true, true, false, true, true),
            13831 => new BambooFenceBlock(Identifier, true, true, false, true, false),
            13832 => new BambooFenceBlock(Identifier, true, true, false, false, true),
            13833 => new BambooFenceBlock(Identifier, true, true, false, false, false),
            13834 => new BambooFenceBlock(Identifier, true, false, true, true, true),
            13835 => new BambooFenceBlock(Identifier, true, false, true, true, false),
            13836 => new BambooFenceBlock(Identifier, true, false, true, false, true),
            13837 => new BambooFenceBlock(Identifier, true, false, true, false, false),
            13838 => new BambooFenceBlock(Identifier, true, false, false, true, true),
            13839 => new BambooFenceBlock(Identifier, true, false, false, true, false),
            13840 => new BambooFenceBlock(Identifier, true, false, false, false, true),
            13841 => new BambooFenceBlock(Identifier, true, false, false, false, false),
            13842 => new BambooFenceBlock(Identifier, false, true, true, true, true),
            13843 => new BambooFenceBlock(Identifier, false, true, true, true, false),
            13844 => new BambooFenceBlock(Identifier, false, true, true, false, true),
            13845 => new BambooFenceBlock(Identifier, false, true, true, false, false),
            13846 => new BambooFenceBlock(Identifier, false, true, false, true, true),
            13847 => new BambooFenceBlock(Identifier, false, true, false, true, false),
            13848 => new BambooFenceBlock(Identifier, false, true, false, false, true),
            13849 => new BambooFenceBlock(Identifier, false, true, false, false, false),
            13850 => new BambooFenceBlock(Identifier, false, false, true, true, true),
            13851 => new BambooFenceBlock(Identifier, false, false, true, true, false),
            13852 => new BambooFenceBlock(Identifier, false, false, true, false, true),
            13853 => new BambooFenceBlock(Identifier, false, false, true, false, false),
            13854 => new BambooFenceBlock(Identifier, false, false, false, true, true),
            13855 => new BambooFenceBlock(Identifier, false, false, false, true, false),
            13856 => new BambooFenceBlock(Identifier, false, false, false, false, true),
            13857 => new BambooFenceBlock(Identifier, false, false, false, false, false),
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
