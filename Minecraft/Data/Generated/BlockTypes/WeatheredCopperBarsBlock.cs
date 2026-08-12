using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:weathered_copper_bars";
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
    public string TranslationKey => "block.minecraft.weathered_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8054,
                                false => 8055,
                            },
                            false => West switch {
                                true => 8056,
                                false => 8057,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8058,
                                false => 8059,
                            },
                            false => West switch {
                                true => 8060,
                                false => 8061,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8062,
                                false => 8063,
                            },
                            false => West switch {
                                true => 8064,
                                false => 8065,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8066,
                                false => 8067,
                            },
                            false => West switch {
                                true => 8068,
                                false => 8069,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8070,
                                false => 8071,
                            },
                            false => West switch {
                                true => 8072,
                                false => 8073,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8074,
                                false => 8075,
                            },
                            false => West switch {
                                true => 8076,
                                false => 8077,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8078,
                                false => 8079,
                            },
                            false => West switch {
                                true => 8080,
                                false => 8081,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8082,
                                false => 8083,
                            },
                            false => West switch {
                                true => 8084,
                                false => 8085,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8054 => new WeatheredCopperBarsBlock(Identifier, true, true, true, true, true),
            8055 => new WeatheredCopperBarsBlock(Identifier, true, true, true, true, false),
            8056 => new WeatheredCopperBarsBlock(Identifier, true, true, true, false, true),
            8057 => new WeatheredCopperBarsBlock(Identifier, true, true, true, false, false),
            8058 => new WeatheredCopperBarsBlock(Identifier, true, true, false, true, true),
            8059 => new WeatheredCopperBarsBlock(Identifier, true, true, false, true, false),
            8060 => new WeatheredCopperBarsBlock(Identifier, true, true, false, false, true),
            8061 => new WeatheredCopperBarsBlock(Identifier, true, true, false, false, false),
            8062 => new WeatheredCopperBarsBlock(Identifier, true, false, true, true, true),
            8063 => new WeatheredCopperBarsBlock(Identifier, true, false, true, true, false),
            8064 => new WeatheredCopperBarsBlock(Identifier, true, false, true, false, true),
            8065 => new WeatheredCopperBarsBlock(Identifier, true, false, true, false, false),
            8066 => new WeatheredCopperBarsBlock(Identifier, true, false, false, true, true),
            8067 => new WeatheredCopperBarsBlock(Identifier, true, false, false, true, false),
            8068 => new WeatheredCopperBarsBlock(Identifier, true, false, false, false, true),
            8069 => new WeatheredCopperBarsBlock(Identifier, true, false, false, false, false),
            8070 => new WeatheredCopperBarsBlock(Identifier, false, true, true, true, true),
            8071 => new WeatheredCopperBarsBlock(Identifier, false, true, true, true, false),
            8072 => new WeatheredCopperBarsBlock(Identifier, false, true, true, false, true),
            8073 => new WeatheredCopperBarsBlock(Identifier, false, true, true, false, false),
            8074 => new WeatheredCopperBarsBlock(Identifier, false, true, false, true, true),
            8075 => new WeatheredCopperBarsBlock(Identifier, false, true, false, true, false),
            8076 => new WeatheredCopperBarsBlock(Identifier, false, true, false, false, true),
            8077 => new WeatheredCopperBarsBlock(Identifier, false, true, false, false, false),
            8078 => new WeatheredCopperBarsBlock(Identifier, false, false, true, true, true),
            8079 => new WeatheredCopperBarsBlock(Identifier, false, false, true, true, false),
            8080 => new WeatheredCopperBarsBlock(Identifier, false, false, true, false, true),
            8081 => new WeatheredCopperBarsBlock(Identifier, false, false, true, false, false),
            8082 => new WeatheredCopperBarsBlock(Identifier, false, false, false, true, true),
            8083 => new WeatheredCopperBarsBlock(Identifier, false, false, false, true, false),
            8084 => new WeatheredCopperBarsBlock(Identifier, false, false, false, false, true),
            8085 => new WeatheredCopperBarsBlock(Identifier, false, false, false, false, false),
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
