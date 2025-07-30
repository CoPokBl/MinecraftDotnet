using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record VineBlock(Identifier Identifier, bool East, bool North, bool South, bool Up, bool West) : IBlock {

    public Identifier Category => "minecraft:vine";
    public int ProtocolId => 335;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "vine";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:vine";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.vine";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7080,
                                false => 7081,
                            },
                            false => West switch {
                                true => 7082,
                                false => 7083,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7084,
                                false => 7085,
                            },
                            false => West switch {
                                true => 7086,
                                false => 7087,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7088,
                                false => 7089,
                            },
                            false => West switch {
                                true => 7090,
                                false => 7091,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7092,
                                false => 7093,
                            },
                            false => West switch {
                                true => 7094,
                                false => 7095,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7096,
                                false => 7097,
                            },
                            false => West switch {
                                true => 7098,
                                false => 7099,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7100,
                                false => 7101,
                            },
                            false => West switch {
                                true => 7102,
                                false => 7103,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 7104,
                                false => 7105,
                            },
                            false => West switch {
                                true => 7106,
                                false => 7107,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 7108,
                                false => 7109,
                            },
                            false => West switch {
                                true => 7110,
                                false => 7111,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7080 => new VineBlock(Identifier, true, true, true, true, true),
            7081 => new VineBlock(Identifier, true, true, true, true, false),
            7082 => new VineBlock(Identifier, true, true, true, false, true),
            7083 => new VineBlock(Identifier, true, true, true, false, false),
            7084 => new VineBlock(Identifier, true, true, false, true, true),
            7085 => new VineBlock(Identifier, true, true, false, true, false),
            7086 => new VineBlock(Identifier, true, true, false, false, true),
            7087 => new VineBlock(Identifier, true, true, false, false, false),
            7088 => new VineBlock(Identifier, true, false, true, true, true),
            7089 => new VineBlock(Identifier, true, false, true, true, false),
            7090 => new VineBlock(Identifier, true, false, true, false, true),
            7091 => new VineBlock(Identifier, true, false, true, false, false),
            7092 => new VineBlock(Identifier, true, false, false, true, true),
            7093 => new VineBlock(Identifier, true, false, false, true, false),
            7094 => new VineBlock(Identifier, true, false, false, false, true),
            7095 => new VineBlock(Identifier, true, false, false, false, false),
            7096 => new VineBlock(Identifier, false, true, true, true, true),
            7097 => new VineBlock(Identifier, false, true, true, true, false),
            7098 => new VineBlock(Identifier, false, true, true, false, true),
            7099 => new VineBlock(Identifier, false, true, true, false, false),
            7100 => new VineBlock(Identifier, false, true, false, true, true),
            7101 => new VineBlock(Identifier, false, true, false, true, false),
            7102 => new VineBlock(Identifier, false, true, false, false, true),
            7103 => new VineBlock(Identifier, false, true, false, false, false),
            7104 => new VineBlock(Identifier, false, false, true, true, true),
            7105 => new VineBlock(Identifier, false, false, true, true, false),
            7106 => new VineBlock(Identifier, false, false, true, false, true),
            7107 => new VineBlock(Identifier, false, false, true, false, false),
            7108 => new VineBlock(Identifier, false, false, false, true, true),
            7109 => new VineBlock(Identifier, false, false, false, true, false),
            7110 => new VineBlock(Identifier, false, false, false, false, true),
            7111 => new VineBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Up = properties["up"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
