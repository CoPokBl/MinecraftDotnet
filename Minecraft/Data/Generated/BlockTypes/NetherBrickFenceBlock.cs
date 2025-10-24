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
    public int ProtocolId => 381;
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
                                true => 9134,
                                false => 9135,
                            },
                            false => West switch {
                                true => 9136,
                                false => 9137,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9138,
                                false => 9139,
                            },
                            false => West switch {
                                true => 9140,
                                false => 9141,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9142,
                                false => 9143,
                            },
                            false => West switch {
                                true => 9144,
                                false => 9145,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9146,
                                false => 9147,
                            },
                            false => West switch {
                                true => 9148,
                                false => 9149,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9150,
                                false => 9151,
                            },
                            false => West switch {
                                true => 9152,
                                false => 9153,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9154,
                                false => 9155,
                            },
                            false => West switch {
                                true => 9156,
                                false => 9157,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9158,
                                false => 9159,
                            },
                            false => West switch {
                                true => 9160,
                                false => 9161,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9162,
                                false => 9163,
                            },
                            false => West switch {
                                true => 9164,
                                false => 9165,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9134 => new NetherBrickFenceBlock(Identifier, true, true, true, true, true),
            9135 => new NetherBrickFenceBlock(Identifier, true, true, true, true, false),
            9136 => new NetherBrickFenceBlock(Identifier, true, true, true, false, true),
            9137 => new NetherBrickFenceBlock(Identifier, true, true, true, false, false),
            9138 => new NetherBrickFenceBlock(Identifier, true, true, false, true, true),
            9139 => new NetherBrickFenceBlock(Identifier, true, true, false, true, false),
            9140 => new NetherBrickFenceBlock(Identifier, true, true, false, false, true),
            9141 => new NetherBrickFenceBlock(Identifier, true, true, false, false, false),
            9142 => new NetherBrickFenceBlock(Identifier, true, false, true, true, true),
            9143 => new NetherBrickFenceBlock(Identifier, true, false, true, true, false),
            9144 => new NetherBrickFenceBlock(Identifier, true, false, true, false, true),
            9145 => new NetherBrickFenceBlock(Identifier, true, false, true, false, false),
            9146 => new NetherBrickFenceBlock(Identifier, true, false, false, true, true),
            9147 => new NetherBrickFenceBlock(Identifier, true, false, false, true, false),
            9148 => new NetherBrickFenceBlock(Identifier, true, false, false, false, true),
            9149 => new NetherBrickFenceBlock(Identifier, true, false, false, false, false),
            9150 => new NetherBrickFenceBlock(Identifier, false, true, true, true, true),
            9151 => new NetherBrickFenceBlock(Identifier, false, true, true, true, false),
            9152 => new NetherBrickFenceBlock(Identifier, false, true, true, false, true),
            9153 => new NetherBrickFenceBlock(Identifier, false, true, true, false, false),
            9154 => new NetherBrickFenceBlock(Identifier, false, true, false, true, true),
            9155 => new NetherBrickFenceBlock(Identifier, false, true, false, true, false),
            9156 => new NetherBrickFenceBlock(Identifier, false, true, false, false, true),
            9157 => new NetherBrickFenceBlock(Identifier, false, true, false, false, false),
            9158 => new NetherBrickFenceBlock(Identifier, false, false, true, true, true),
            9159 => new NetherBrickFenceBlock(Identifier, false, false, true, true, false),
            9160 => new NetherBrickFenceBlock(Identifier, false, false, true, false, true),
            9161 => new NetherBrickFenceBlock(Identifier, false, false, true, false, false),
            9162 => new NetherBrickFenceBlock(Identifier, false, false, false, true, true),
            9163 => new NetherBrickFenceBlock(Identifier, false, false, false, true, false),
            9164 => new NetherBrickFenceBlock(Identifier, false, false, false, false, true),
            9165 => new NetherBrickFenceBlock(Identifier, false, false, false, false, false),
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
