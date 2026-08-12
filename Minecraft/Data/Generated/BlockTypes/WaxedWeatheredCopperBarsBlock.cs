using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_weathered_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8182,
                                false => 8183,
                            },
                            false => West switch {
                                true => 8184,
                                false => 8185,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8186,
                                false => 8187,
                            },
                            false => West switch {
                                true => 8188,
                                false => 8189,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8190,
                                false => 8191,
                            },
                            false => West switch {
                                true => 8192,
                                false => 8193,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8194,
                                false => 8195,
                            },
                            false => West switch {
                                true => 8196,
                                false => 8197,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8198,
                                false => 8199,
                            },
                            false => West switch {
                                true => 8200,
                                false => 8201,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8202,
                                false => 8203,
                            },
                            false => West switch {
                                true => 8204,
                                false => 8205,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8206,
                                false => 8207,
                            },
                            false => West switch {
                                true => 8208,
                                false => 8209,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8210,
                                false => 8211,
                            },
                            false => West switch {
                                true => 8212,
                                false => 8213,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8182 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, true, true),
            8183 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, true, false),
            8184 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, false, true),
            8185 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, false, false),
            8186 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, true, true),
            8187 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, true, false),
            8188 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, false, true),
            8189 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, false, false),
            8190 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, true, true),
            8191 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, true, false),
            8192 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, false, true),
            8193 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, false, false),
            8194 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, true, true),
            8195 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, true, false),
            8196 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, false, true),
            8197 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, false, false),
            8198 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, true, true),
            8199 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, true, false),
            8200 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, false, true),
            8201 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, false, false),
            8202 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, true, true),
            8203 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, true, false),
            8204 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, false, true),
            8205 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, false, false),
            8206 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, true, true),
            8207 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, true, false),
            8208 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, false, true),
            8209 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, false, false),
            8210 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, true, true),
            8211 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, true, false),
            8212 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, false, true),
            8213 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, false, false),
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
