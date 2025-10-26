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
    public int ProtocolId => 347;
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
                                true => 7981,
                                false => 7982,
                            },
                            false => West switch {
                                true => 7983,
                                false => 7984,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7985,
                                false => 7986,
                            },
                            false => West switch {
                                true => 7987,
                                false => 7988,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7989,
                                false => 7990,
                            },
                            false => West switch {
                                true => 7991,
                                false => 7992,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7993,
                                false => 7994,
                            },
                            false => West switch {
                                true => 7995,
                                false => 7996,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7997,
                                false => 7998,
                            },
                            false => West switch {
                                true => 7999,
                                false => 8000,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8001,
                                false => 8002,
                            },
                            false => West switch {
                                true => 8003,
                                false => 8004,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8005,
                                false => 8006,
                            },
                            false => West switch {
                                true => 8007,
                                false => 8008,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8009,
                                false => 8010,
                            },
                            false => West switch {
                                true => 8011,
                                false => 8012,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7981 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, true, true),
            7982 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, true, false),
            7983 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, false, true),
            7984 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, true, false, false),
            7985 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, true, true),
            7986 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, true, false),
            7987 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, false, true),
            7988 => new WaxedWeatheredCopperBarsBlock(Identifier, true, true, false, false, false),
            7989 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, true, true),
            7990 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, true, false),
            7991 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, false, true),
            7992 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, true, false, false),
            7993 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, true, true),
            7994 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, true, false),
            7995 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, false, true),
            7996 => new WaxedWeatheredCopperBarsBlock(Identifier, true, false, false, false, false),
            7997 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, true, true),
            7998 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, true, false),
            7999 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, false, true),
            8000 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, true, false, false),
            8001 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, true, true),
            8002 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, true, false),
            8003 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, false, true),
            8004 => new WaxedWeatheredCopperBarsBlock(Identifier, false, true, false, false, false),
            8005 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, true, true),
            8006 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, true, false),
            8007 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, false, true),
            8008 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, true, false, false),
            8009 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, true, true),
            8010 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, true, false),
            8011 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, false, true),
            8012 => new WaxedWeatheredCopperBarsBlock(Identifier, false, false, false, false, false),
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
