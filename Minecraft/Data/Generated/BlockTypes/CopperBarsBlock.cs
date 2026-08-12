using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:copper_bars";
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
    public string TranslationKey => "block.minecraft.copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7990,
                                false => 7991,
                            },
                            false => West switch {
                                true => 7992,
                                false => 7993,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7994,
                                false => 7995,
                            },
                            false => West switch {
                                true => 7996,
                                false => 7997,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7998,
                                false => 7999,
                            },
                            false => West switch {
                                true => 8000,
                                false => 8001,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8002,
                                false => 8003,
                            },
                            false => West switch {
                                true => 8004,
                                false => 8005,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8006,
                                false => 8007,
                            },
                            false => West switch {
                                true => 8008,
                                false => 8009,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8010,
                                false => 8011,
                            },
                            false => West switch {
                                true => 8012,
                                false => 8013,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8014,
                                false => 8015,
                            },
                            false => West switch {
                                true => 8016,
                                false => 8017,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8018,
                                false => 8019,
                            },
                            false => West switch {
                                true => 8020,
                                false => 8021,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7990 => new CopperBarsBlock(Identifier, true, true, true, true, true),
            7991 => new CopperBarsBlock(Identifier, true, true, true, true, false),
            7992 => new CopperBarsBlock(Identifier, true, true, true, false, true),
            7993 => new CopperBarsBlock(Identifier, true, true, true, false, false),
            7994 => new CopperBarsBlock(Identifier, true, true, false, true, true),
            7995 => new CopperBarsBlock(Identifier, true, true, false, true, false),
            7996 => new CopperBarsBlock(Identifier, true, true, false, false, true),
            7997 => new CopperBarsBlock(Identifier, true, true, false, false, false),
            7998 => new CopperBarsBlock(Identifier, true, false, true, true, true),
            7999 => new CopperBarsBlock(Identifier, true, false, true, true, false),
            8000 => new CopperBarsBlock(Identifier, true, false, true, false, true),
            8001 => new CopperBarsBlock(Identifier, true, false, true, false, false),
            8002 => new CopperBarsBlock(Identifier, true, false, false, true, true),
            8003 => new CopperBarsBlock(Identifier, true, false, false, true, false),
            8004 => new CopperBarsBlock(Identifier, true, false, false, false, true),
            8005 => new CopperBarsBlock(Identifier, true, false, false, false, false),
            8006 => new CopperBarsBlock(Identifier, false, true, true, true, true),
            8007 => new CopperBarsBlock(Identifier, false, true, true, true, false),
            8008 => new CopperBarsBlock(Identifier, false, true, true, false, true),
            8009 => new CopperBarsBlock(Identifier, false, true, true, false, false),
            8010 => new CopperBarsBlock(Identifier, false, true, false, true, true),
            8011 => new CopperBarsBlock(Identifier, false, true, false, true, false),
            8012 => new CopperBarsBlock(Identifier, false, true, false, false, true),
            8013 => new CopperBarsBlock(Identifier, false, true, false, false, false),
            8014 => new CopperBarsBlock(Identifier, false, false, true, true, true),
            8015 => new CopperBarsBlock(Identifier, false, false, true, true, false),
            8016 => new CopperBarsBlock(Identifier, false, false, true, false, true),
            8017 => new CopperBarsBlock(Identifier, false, false, true, false, false),
            8018 => new CopperBarsBlock(Identifier, false, false, false, true, true),
            8019 => new CopperBarsBlock(Identifier, false, false, false, true, false),
            8020 => new CopperBarsBlock(Identifier, false, false, false, false, true),
            8021 => new CopperBarsBlock(Identifier, false, false, false, false, false),
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
