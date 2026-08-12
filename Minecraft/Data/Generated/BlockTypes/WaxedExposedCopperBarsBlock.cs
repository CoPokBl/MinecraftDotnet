using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8150,
                                false => 8151,
                            },
                            false => West switch {
                                true => 8152,
                                false => 8153,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8154,
                                false => 8155,
                            },
                            false => West switch {
                                true => 8156,
                                false => 8157,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8158,
                                false => 8159,
                            },
                            false => West switch {
                                true => 8160,
                                false => 8161,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8162,
                                false => 8163,
                            },
                            false => West switch {
                                true => 8164,
                                false => 8165,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8166,
                                false => 8167,
                            },
                            false => West switch {
                                true => 8168,
                                false => 8169,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8170,
                                false => 8171,
                            },
                            false => West switch {
                                true => 8172,
                                false => 8173,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8174,
                                false => 8175,
                            },
                            false => West switch {
                                true => 8176,
                                false => 8177,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8178,
                                false => 8179,
                            },
                            false => West switch {
                                true => 8180,
                                false => 8181,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8150 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, true, true),
            8151 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, true, false),
            8152 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, false, true),
            8153 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, false, false),
            8154 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, true, true),
            8155 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, true, false),
            8156 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, false, true),
            8157 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, false, false),
            8158 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, true, true),
            8159 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, true, false),
            8160 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, false, true),
            8161 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, false, false),
            8162 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, true, true),
            8163 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, true, false),
            8164 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, false, true),
            8165 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, false, false),
            8166 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, true, true),
            8167 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, true, false),
            8168 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, false, true),
            8169 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, false, false),
            8170 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, true, true),
            8171 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, true, false),
            8172 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, false, true),
            8173 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, false, false),
            8174 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, true, true),
            8175 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, true, false),
            8176 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, false, true),
            8177 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, false, false),
            8178 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, true, true),
            8179 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, true, false),
            8180 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, false, true),
            8181 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, false, false),
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
