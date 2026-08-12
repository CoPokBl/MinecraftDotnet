using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8214,
                                false => 8215,
                            },
                            false => West switch {
                                true => 8216,
                                false => 8217,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8218,
                                false => 8219,
                            },
                            false => West switch {
                                true => 8220,
                                false => 8221,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8222,
                                false => 8223,
                            },
                            false => West switch {
                                true => 8224,
                                false => 8225,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8226,
                                false => 8227,
                            },
                            false => West switch {
                                true => 8228,
                                false => 8229,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8230,
                                false => 8231,
                            },
                            false => West switch {
                                true => 8232,
                                false => 8233,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8234,
                                false => 8235,
                            },
                            false => West switch {
                                true => 8236,
                                false => 8237,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8238,
                                false => 8239,
                            },
                            false => West switch {
                                true => 8240,
                                false => 8241,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8242,
                                false => 8243,
                            },
                            false => West switch {
                                true => 8244,
                                false => 8245,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8214 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, true, true),
            8215 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, true, false),
            8216 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, false, true),
            8217 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, false, false),
            8218 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, true, true),
            8219 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, true, false),
            8220 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, false, true),
            8221 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, false, false),
            8222 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, true, true),
            8223 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, true, false),
            8224 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, false, true),
            8225 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, false, false),
            8226 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, true, true),
            8227 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, true, false),
            8228 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, false, true),
            8229 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, false, false),
            8230 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, true, true),
            8231 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, true, false),
            8232 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, false, true),
            8233 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, false, false),
            8234 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, true, true),
            8235 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, true, false),
            8236 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, false, true),
            8237 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, false, false),
            8238 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, true, true),
            8239 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, true, false),
            8240 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, false, true),
            8241 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, false, false),
            8242 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, true, true),
            8243 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, true, false),
            8244 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, false, true),
            8245 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, false, false),
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
