using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 326;
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
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:iron_bars";
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
    public string TranslationKey => "block.minecraft.iron_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6984,
                                false => 6985,
                            },
                            false => West switch {
                                true => 6986,
                                false => 6987,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6988,
                                false => 6989,
                            },
                            false => West switch {
                                true => 6990,
                                false => 6991,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6992,
                                false => 6993,
                            },
                            false => West switch {
                                true => 6994,
                                false => 6995,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6996,
                                false => 6997,
                            },
                            false => West switch {
                                true => 6998,
                                false => 6999,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7000,
                                false => 7001,
                            },
                            false => West switch {
                                true => 7002,
                                false => 7003,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7004,
                                false => 7005,
                            },
                            false => West switch {
                                true => 7006,
                                false => 7007,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7008,
                                false => 7009,
                            },
                            false => West switch {
                                true => 7010,
                                false => 7011,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7012,
                                false => 7013,
                            },
                            false => West switch {
                                true => 7014,
                                false => 7015,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6984 => new IronBarsBlock(Identifier, true, true, true, true, true),
            6985 => new IronBarsBlock(Identifier, true, true, true, true, false),
            6986 => new IronBarsBlock(Identifier, true, true, true, false, true),
            6987 => new IronBarsBlock(Identifier, true, true, true, false, false),
            6988 => new IronBarsBlock(Identifier, true, true, false, true, true),
            6989 => new IronBarsBlock(Identifier, true, true, false, true, false),
            6990 => new IronBarsBlock(Identifier, true, true, false, false, true),
            6991 => new IronBarsBlock(Identifier, true, true, false, false, false),
            6992 => new IronBarsBlock(Identifier, true, false, true, true, true),
            6993 => new IronBarsBlock(Identifier, true, false, true, true, false),
            6994 => new IronBarsBlock(Identifier, true, false, true, false, true),
            6995 => new IronBarsBlock(Identifier, true, false, true, false, false),
            6996 => new IronBarsBlock(Identifier, true, false, false, true, true),
            6997 => new IronBarsBlock(Identifier, true, false, false, true, false),
            6998 => new IronBarsBlock(Identifier, true, false, false, false, true),
            6999 => new IronBarsBlock(Identifier, true, false, false, false, false),
            7000 => new IronBarsBlock(Identifier, false, true, true, true, true),
            7001 => new IronBarsBlock(Identifier, false, true, true, true, false),
            7002 => new IronBarsBlock(Identifier, false, true, true, false, true),
            7003 => new IronBarsBlock(Identifier, false, true, true, false, false),
            7004 => new IronBarsBlock(Identifier, false, true, false, true, true),
            7005 => new IronBarsBlock(Identifier, false, true, false, true, false),
            7006 => new IronBarsBlock(Identifier, false, true, false, false, true),
            7007 => new IronBarsBlock(Identifier, false, true, false, false, false),
            7008 => new IronBarsBlock(Identifier, false, false, true, true, true),
            7009 => new IronBarsBlock(Identifier, false, false, true, true, false),
            7010 => new IronBarsBlock(Identifier, false, false, true, false, true),
            7011 => new IronBarsBlock(Identifier, false, false, true, false, false),
            7012 => new IronBarsBlock(Identifier, false, false, false, true, true),
            7013 => new IronBarsBlock(Identifier, false, false, false, true, false),
            7014 => new IronBarsBlock(Identifier, false, false, false, false, true),
            7015 => new IronBarsBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
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
