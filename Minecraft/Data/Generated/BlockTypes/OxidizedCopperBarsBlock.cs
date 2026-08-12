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
                                true => 8086,
                                false => 8087,
                            },
                            false => West switch {
                                true => 8088,
                                false => 8089,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8090,
                                false => 8091,
                            },
                            false => West switch {
                                true => 8092,
                                false => 8093,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8094,
                                false => 8095,
                            },
                            false => West switch {
                                true => 8096,
                                false => 8097,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8098,
                                false => 8099,
                            },
                            false => West switch {
                                true => 8100,
                                false => 8101,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8102,
                                false => 8103,
                            },
                            false => West switch {
                                true => 8104,
                                false => 8105,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8106,
                                false => 8107,
                            },
                            false => West switch {
                                true => 8108,
                                false => 8109,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8110,
                                false => 8111,
                            },
                            false => West switch {
                                true => 8112,
                                false => 8113,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8114,
                                false => 8115,
                            },
                            false => West switch {
                                true => 8116,
                                false => 8117,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8086 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, true),
            8087 => new OxidizedCopperBarsBlock(Identifier, true, true, true, true, false),
            8088 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, true),
            8089 => new OxidizedCopperBarsBlock(Identifier, true, true, true, false, false),
            8090 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, true),
            8091 => new OxidizedCopperBarsBlock(Identifier, true, true, false, true, false),
            8092 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, true),
            8093 => new OxidizedCopperBarsBlock(Identifier, true, true, false, false, false),
            8094 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, true),
            8095 => new OxidizedCopperBarsBlock(Identifier, true, false, true, true, false),
            8096 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, true),
            8097 => new OxidizedCopperBarsBlock(Identifier, true, false, true, false, false),
            8098 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, true),
            8099 => new OxidizedCopperBarsBlock(Identifier, true, false, false, true, false),
            8100 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, true),
            8101 => new OxidizedCopperBarsBlock(Identifier, true, false, false, false, false),
            8102 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, true),
            8103 => new OxidizedCopperBarsBlock(Identifier, false, true, true, true, false),
            8104 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, true),
            8105 => new OxidizedCopperBarsBlock(Identifier, false, true, true, false, false),
            8106 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, true),
            8107 => new OxidizedCopperBarsBlock(Identifier, false, true, false, true, false),
            8108 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, true),
            8109 => new OxidizedCopperBarsBlock(Identifier, false, true, false, false, false),
            8110 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, true),
            8111 => new OxidizedCopperBarsBlock(Identifier, false, false, true, true, false),
            8112 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, true),
            8113 => new OxidizedCopperBarsBlock(Identifier, false, false, true, false, false),
            8114 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, true),
            8115 => new OxidizedCopperBarsBlock(Identifier, false, false, false, true, false),
            8116 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, true),
            8117 => new OxidizedCopperBarsBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
