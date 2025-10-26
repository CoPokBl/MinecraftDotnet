using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 888;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20880,
                                false => 20881,
                            },
                            false => West switch {
                                true => 20882,
                                false => 20883,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20884,
                                false => 20885,
                            },
                            false => West switch {
                                true => 20886,
                                false => 20887,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20888,
                                false => 20889,
                            },
                            false => West switch {
                                true => 20890,
                                false => 20891,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20892,
                                false => 20893,
                            },
                            false => West switch {
                                true => 20894,
                                false => 20895,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20896,
                                false => 20897,
                            },
                            false => West switch {
                                true => 20898,
                                false => 20899,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20900,
                                false => 20901,
                            },
                            false => West switch {
                                true => 20902,
                                false => 20903,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20904,
                                false => 20905,
                            },
                            false => West switch {
                                true => 20906,
                                false => 20907,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20908,
                                false => 20909,
                            },
                            false => West switch {
                                true => 20910,
                                false => 20911,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20880 => new WarpedFenceBlock(Identifier, true, true, true, true, true),
            20881 => new WarpedFenceBlock(Identifier, true, true, true, true, false),
            20882 => new WarpedFenceBlock(Identifier, true, true, true, false, true),
            20883 => new WarpedFenceBlock(Identifier, true, true, true, false, false),
            20884 => new WarpedFenceBlock(Identifier, true, true, false, true, true),
            20885 => new WarpedFenceBlock(Identifier, true, true, false, true, false),
            20886 => new WarpedFenceBlock(Identifier, true, true, false, false, true),
            20887 => new WarpedFenceBlock(Identifier, true, true, false, false, false),
            20888 => new WarpedFenceBlock(Identifier, true, false, true, true, true),
            20889 => new WarpedFenceBlock(Identifier, true, false, true, true, false),
            20890 => new WarpedFenceBlock(Identifier, true, false, true, false, true),
            20891 => new WarpedFenceBlock(Identifier, true, false, true, false, false),
            20892 => new WarpedFenceBlock(Identifier, true, false, false, true, true),
            20893 => new WarpedFenceBlock(Identifier, true, false, false, true, false),
            20894 => new WarpedFenceBlock(Identifier, true, false, false, false, true),
            20895 => new WarpedFenceBlock(Identifier, true, false, false, false, false),
            20896 => new WarpedFenceBlock(Identifier, false, true, true, true, true),
            20897 => new WarpedFenceBlock(Identifier, false, true, true, true, false),
            20898 => new WarpedFenceBlock(Identifier, false, true, true, false, true),
            20899 => new WarpedFenceBlock(Identifier, false, true, true, false, false),
            20900 => new WarpedFenceBlock(Identifier, false, true, false, true, true),
            20901 => new WarpedFenceBlock(Identifier, false, true, false, true, false),
            20902 => new WarpedFenceBlock(Identifier, false, true, false, false, true),
            20903 => new WarpedFenceBlock(Identifier, false, true, false, false, false),
            20904 => new WarpedFenceBlock(Identifier, false, false, true, true, true),
            20905 => new WarpedFenceBlock(Identifier, false, false, true, true, false),
            20906 => new WarpedFenceBlock(Identifier, false, false, true, false, true),
            20907 => new WarpedFenceBlock(Identifier, false, false, true, false, false),
            20908 => new WarpedFenceBlock(Identifier, false, false, false, true, true),
            20909 => new WarpedFenceBlock(Identifier, false, false, false, true, false),
            20910 => new WarpedFenceBlock(Identifier, false, false, false, false, true),
            20911 => new WarpedFenceBlock(Identifier, false, false, false, false, false),
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
