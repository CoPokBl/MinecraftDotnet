using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 887;
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
    public Identifier? Item => "minecraft:crimson_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20848,
                                false => 20849,
                            },
                            false => West switch {
                                true => 20850,
                                false => 20851,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20852,
                                false => 20853,
                            },
                            false => West switch {
                                true => 20854,
                                false => 20855,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20856,
                                false => 20857,
                            },
                            false => West switch {
                                true => 20858,
                                false => 20859,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20860,
                                false => 20861,
                            },
                            false => West switch {
                                true => 20862,
                                false => 20863,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20864,
                                false => 20865,
                            },
                            false => West switch {
                                true => 20866,
                                false => 20867,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20868,
                                false => 20869,
                            },
                            false => West switch {
                                true => 20870,
                                false => 20871,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 20872,
                                false => 20873,
                            },
                            false => West switch {
                                true => 20874,
                                false => 20875,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 20876,
                                false => 20877,
                            },
                            false => West switch {
                                true => 20878,
                                false => 20879,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20848 => new CrimsonFenceBlock(Identifier, true, true, true, true, true),
            20849 => new CrimsonFenceBlock(Identifier, true, true, true, true, false),
            20850 => new CrimsonFenceBlock(Identifier, true, true, true, false, true),
            20851 => new CrimsonFenceBlock(Identifier, true, true, true, false, false),
            20852 => new CrimsonFenceBlock(Identifier, true, true, false, true, true),
            20853 => new CrimsonFenceBlock(Identifier, true, true, false, true, false),
            20854 => new CrimsonFenceBlock(Identifier, true, true, false, false, true),
            20855 => new CrimsonFenceBlock(Identifier, true, true, false, false, false),
            20856 => new CrimsonFenceBlock(Identifier, true, false, true, true, true),
            20857 => new CrimsonFenceBlock(Identifier, true, false, true, true, false),
            20858 => new CrimsonFenceBlock(Identifier, true, false, true, false, true),
            20859 => new CrimsonFenceBlock(Identifier, true, false, true, false, false),
            20860 => new CrimsonFenceBlock(Identifier, true, false, false, true, true),
            20861 => new CrimsonFenceBlock(Identifier, true, false, false, true, false),
            20862 => new CrimsonFenceBlock(Identifier, true, false, false, false, true),
            20863 => new CrimsonFenceBlock(Identifier, true, false, false, false, false),
            20864 => new CrimsonFenceBlock(Identifier, false, true, true, true, true),
            20865 => new CrimsonFenceBlock(Identifier, false, true, true, true, false),
            20866 => new CrimsonFenceBlock(Identifier, false, true, true, false, true),
            20867 => new CrimsonFenceBlock(Identifier, false, true, true, false, false),
            20868 => new CrimsonFenceBlock(Identifier, false, true, false, true, true),
            20869 => new CrimsonFenceBlock(Identifier, false, true, false, true, false),
            20870 => new CrimsonFenceBlock(Identifier, false, true, false, false, true),
            20871 => new CrimsonFenceBlock(Identifier, false, true, false, false, false),
            20872 => new CrimsonFenceBlock(Identifier, false, false, true, true, true),
            20873 => new CrimsonFenceBlock(Identifier, false, false, true, true, false),
            20874 => new CrimsonFenceBlock(Identifier, false, false, true, false, true),
            20875 => new CrimsonFenceBlock(Identifier, false, false, true, false, false),
            20876 => new CrimsonFenceBlock(Identifier, false, false, false, true, true),
            20877 => new CrimsonFenceBlock(Identifier, false, false, false, true, false),
            20878 => new CrimsonFenceBlock(Identifier, false, false, false, false, true),
            20879 => new CrimsonFenceBlock(Identifier, false, false, false, false, false),
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
