using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
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
    public Identifier? Item => "minecraft:waxed_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8118,
                                false => 8119,
                            },
                            false => West switch {
                                true => 8120,
                                false => 8121,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8122,
                                false => 8123,
                            },
                            false => West switch {
                                true => 8124,
                                false => 8125,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8126,
                                false => 8127,
                            },
                            false => West switch {
                                true => 8128,
                                false => 8129,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8130,
                                false => 8131,
                            },
                            false => West switch {
                                true => 8132,
                                false => 8133,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8134,
                                false => 8135,
                            },
                            false => West switch {
                                true => 8136,
                                false => 8137,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8138,
                                false => 8139,
                            },
                            false => West switch {
                                true => 8140,
                                false => 8141,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8142,
                                false => 8143,
                            },
                            false => West switch {
                                true => 8144,
                                false => 8145,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8146,
                                false => 8147,
                            },
                            false => West switch {
                                true => 8148,
                                false => 8149,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8118 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, true),
            8119 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, false),
            8120 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, true),
            8121 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, false),
            8122 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, true),
            8123 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, false),
            8124 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, true),
            8125 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, false),
            8126 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, true),
            8127 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, false),
            8128 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, true),
            8129 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, false),
            8130 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, true),
            8131 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, false),
            8132 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, true),
            8133 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, false),
            8134 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, true),
            8135 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, false),
            8136 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, true),
            8137 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, false),
            8138 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, true),
            8139 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, false),
            8140 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, true),
            8141 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, false),
            8142 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, true),
            8143 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, false),
            8144 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, true),
            8145 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, false),
            8146 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, true),
            8147 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, false),
            8148 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, true),
            8149 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, false),
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
