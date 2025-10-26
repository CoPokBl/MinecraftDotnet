using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_bar";
    public int ProtocolId => 344;
    public double Hardness => 5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:oxidized_copper_bars";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.oxidized_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7885,
                                false => 7886,
                            },
                            false => West switch {
                                true => 7887,
                                false => 7888,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7889,
                                false => 7890,
                            },
                            false => West switch {
                                true => 7891,
                                false => 7892,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7893,
                                false => 7894,
                            },
                            false => West switch {
                                true => 7895,
                                false => 7896,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7897,
                                false => 7898,
                            },
                            false => West switch {
                                true => 7899,
                                false => 7900,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7901,
                                false => 7902,
                            },
                            false => West switch {
                                true => 7903,
                                false => 7904,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7905,
                                false => 7906,
                            },
                            false => West switch {
                                true => 7907,
                                false => 7908,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7909,
                                false => 7910,
                            },
                            false => West switch {
                                true => 7911,
                                false => 7912,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7913,
                                false => 7914,
                            },
                            false => West switch {
                                true => 7915,
                                false => 7916,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7885 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, true),
            7886 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, false),
            7887 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, true),
            7888 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, false),
            7889 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, true),
            7890 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, false),
            7891 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, true),
            7892 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, false),
            7893 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, true),
            7894 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, false),
            7895 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, true),
            7896 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, false),
            7897 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, true),
            7898 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, false),
            7899 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, true),
            7900 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, false),
            7901 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, true),
            7902 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, false),
            7903 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, true),
            7904 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, false),
            7905 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, true),
            7906 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, false),
            7907 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, true),
            7908 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, false),
            7909 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, true),
            7910 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, false),
            7911 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, true),
            7912 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, false),
            7913 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, true),
            7914 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, false),
            7915 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, true),
            7916 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, false),
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
