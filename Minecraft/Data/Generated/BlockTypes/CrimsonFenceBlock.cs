using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21050,
                                false => 21051,
                            },
                            false => West switch {
                                true => 21052,
                                false => 21053,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21054,
                                false => 21055,
                            },
                            false => West switch {
                                true => 21056,
                                false => 21057,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21058,
                                false => 21059,
                            },
                            false => West switch {
                                true => 21060,
                                false => 21061,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21062,
                                false => 21063,
                            },
                            false => West switch {
                                true => 21064,
                                false => 21065,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21066,
                                false => 21067,
                            },
                            false => West switch {
                                true => 21068,
                                false => 21069,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21070,
                                false => 21071,
                            },
                            false => West switch {
                                true => 21072,
                                false => 21073,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21074,
                                false => 21075,
                            },
                            false => West switch {
                                true => 21076,
                                false => 21077,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21078,
                                false => 21079,
                            },
                            false => West switch {
                                true => 21080,
                                false => 21081,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21050 => new CrimsonFenceBlock(Identifier, true, true, true, true, true),
            21051 => new CrimsonFenceBlock(Identifier, true, true, true, true, false),
            21052 => new CrimsonFenceBlock(Identifier, true, true, true, false, true),
            21053 => new CrimsonFenceBlock(Identifier, true, true, true, false, false),
            21054 => new CrimsonFenceBlock(Identifier, true, true, false, true, true),
            21055 => new CrimsonFenceBlock(Identifier, true, true, false, true, false),
            21056 => new CrimsonFenceBlock(Identifier, true, true, false, false, true),
            21057 => new CrimsonFenceBlock(Identifier, true, true, false, false, false),
            21058 => new CrimsonFenceBlock(Identifier, true, false, true, true, true),
            21059 => new CrimsonFenceBlock(Identifier, true, false, true, true, false),
            21060 => new CrimsonFenceBlock(Identifier, true, false, true, false, true),
            21061 => new CrimsonFenceBlock(Identifier, true, false, true, false, false),
            21062 => new CrimsonFenceBlock(Identifier, true, false, false, true, true),
            21063 => new CrimsonFenceBlock(Identifier, true, false, false, true, false),
            21064 => new CrimsonFenceBlock(Identifier, true, false, false, false, true),
            21065 => new CrimsonFenceBlock(Identifier, true, false, false, false, false),
            21066 => new CrimsonFenceBlock(Identifier, false, true, true, true, true),
            21067 => new CrimsonFenceBlock(Identifier, false, true, true, true, false),
            21068 => new CrimsonFenceBlock(Identifier, false, true, true, false, true),
            21069 => new CrimsonFenceBlock(Identifier, false, true, true, false, false),
            21070 => new CrimsonFenceBlock(Identifier, false, true, false, true, true),
            21071 => new CrimsonFenceBlock(Identifier, false, true, false, true, false),
            21072 => new CrimsonFenceBlock(Identifier, false, true, false, false, true),
            21073 => new CrimsonFenceBlock(Identifier, false, true, false, false, false),
            21074 => new CrimsonFenceBlock(Identifier, false, false, true, true, true),
            21075 => new CrimsonFenceBlock(Identifier, false, false, true, true, false),
            21076 => new CrimsonFenceBlock(Identifier, false, false, true, false, true),
            21077 => new CrimsonFenceBlock(Identifier, false, false, true, false, false),
            21078 => new CrimsonFenceBlock(Identifier, false, false, false, true, true),
            21079 => new CrimsonFenceBlock(Identifier, false, false, false, true, false),
            21080 => new CrimsonFenceBlock(Identifier, false, false, false, false, true),
            21081 => new CrimsonFenceBlock(Identifier, false, false, false, false, false),
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
