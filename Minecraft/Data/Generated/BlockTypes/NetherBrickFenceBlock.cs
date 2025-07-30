using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 351;
    public double Hardness => 2;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:nether_brick_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.nether_brick_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8057,
                                false => 8058,
                            },
                            false => West switch {
                                true => 8059,
                                false => 8060,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8061,
                                false => 8062,
                            },
                            false => West switch {
                                true => 8063,
                                false => 8064,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8065,
                                false => 8066,
                            },
                            false => West switch {
                                true => 8067,
                                false => 8068,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8069,
                                false => 8070,
                            },
                            false => West switch {
                                true => 8071,
                                false => 8072,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8073,
                                false => 8074,
                            },
                            false => West switch {
                                true => 8075,
                                false => 8076,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8077,
                                false => 8078,
                            },
                            false => West switch {
                                true => 8079,
                                false => 8080,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8081,
                                false => 8082,
                            },
                            false => West switch {
                                true => 8083,
                                false => 8084,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8085,
                                false => 8086,
                            },
                            false => West switch {
                                true => 8087,
                                false => 8088,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8057 => new NetherBrickFenceBlock(Identifier, true, true, true, true, true),
            8058 => new NetherBrickFenceBlock(Identifier, true, true, true, true, false),
            8059 => new NetherBrickFenceBlock(Identifier, true, true, true, false, true),
            8060 => new NetherBrickFenceBlock(Identifier, true, true, true, false, false),
            8061 => new NetherBrickFenceBlock(Identifier, true, true, false, true, true),
            8062 => new NetherBrickFenceBlock(Identifier, true, true, false, true, false),
            8063 => new NetherBrickFenceBlock(Identifier, true, true, false, false, true),
            8064 => new NetherBrickFenceBlock(Identifier, true, true, false, false, false),
            8065 => new NetherBrickFenceBlock(Identifier, true, false, true, true, true),
            8066 => new NetherBrickFenceBlock(Identifier, true, false, true, true, false),
            8067 => new NetherBrickFenceBlock(Identifier, true, false, true, false, true),
            8068 => new NetherBrickFenceBlock(Identifier, true, false, true, false, false),
            8069 => new NetherBrickFenceBlock(Identifier, true, false, false, true, true),
            8070 => new NetherBrickFenceBlock(Identifier, true, false, false, true, false),
            8071 => new NetherBrickFenceBlock(Identifier, true, false, false, false, true),
            8072 => new NetherBrickFenceBlock(Identifier, true, false, false, false, false),
            8073 => new NetherBrickFenceBlock(Identifier, false, true, true, true, true),
            8074 => new NetherBrickFenceBlock(Identifier, false, true, true, true, false),
            8075 => new NetherBrickFenceBlock(Identifier, false, true, true, false, true),
            8076 => new NetherBrickFenceBlock(Identifier, false, true, true, false, false),
            8077 => new NetherBrickFenceBlock(Identifier, false, true, false, true, true),
            8078 => new NetherBrickFenceBlock(Identifier, false, true, false, true, false),
            8079 => new NetherBrickFenceBlock(Identifier, false, true, false, false, true),
            8080 => new NetherBrickFenceBlock(Identifier, false, true, false, false, false),
            8081 => new NetherBrickFenceBlock(Identifier, false, false, true, true, true),
            8082 => new NetherBrickFenceBlock(Identifier, false, false, true, true, false),
            8083 => new NetherBrickFenceBlock(Identifier, false, false, true, false, true),
            8084 => new NetherBrickFenceBlock(Identifier, false, false, true, false, false),
            8085 => new NetherBrickFenceBlock(Identifier, false, false, false, true, true),
            8086 => new NetherBrickFenceBlock(Identifier, false, false, false, true, false),
            8087 => new NetherBrickFenceBlock(Identifier, false, false, false, false, true),
            8088 => new NetherBrickFenceBlock(Identifier, false, false, false, false, false),
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
