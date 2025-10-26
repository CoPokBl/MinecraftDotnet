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
    public int ProtocolId => 365;
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
                                true => 8157,
                                false => 8158,
                            },
                            false => West switch {
                                true => 8159,
                                false => 8160,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8161,
                                false => 8162,
                            },
                            false => West switch {
                                true => 8163,
                                false => 8164,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8165,
                                false => 8166,
                            },
                            false => West switch {
                                true => 8167,
                                false => 8168,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8169,
                                false => 8170,
                            },
                            false => West switch {
                                true => 8171,
                                false => 8172,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8173,
                                false => 8174,
                            },
                            false => West switch {
                                true => 8175,
                                false => 8176,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8177,
                                false => 8178,
                            },
                            false => West switch {
                                true => 8179,
                                false => 8180,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8181,
                                false => 8182,
                            },
                            false => West switch {
                                true => 8183,
                                false => 8184,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8185,
                                false => 8186,
                            },
                            false => West switch {
                                true => 8187,
                                false => 8188,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8157 => new VineBlock(Identifier, true, true, true, true, true),
            8158 => new VineBlock(Identifier, true, true, true, true, false),
            8159 => new VineBlock(Identifier, true, true, true, false, true),
            8160 => new VineBlock(Identifier, true, true, true, false, false),
            8161 => new VineBlock(Identifier, true, true, false, true, true),
            8162 => new VineBlock(Identifier, true, true, false, true, false),
            8163 => new VineBlock(Identifier, true, true, false, false, true),
            8164 => new VineBlock(Identifier, true, true, false, false, false),
            8165 => new VineBlock(Identifier, true, false, true, true, true),
            8166 => new VineBlock(Identifier, true, false, true, true, false),
            8167 => new VineBlock(Identifier, true, false, true, false, true),
            8168 => new VineBlock(Identifier, true, false, true, false, false),
            8169 => new VineBlock(Identifier, true, false, false, true, true),
            8170 => new VineBlock(Identifier, true, false, false, true, false),
            8171 => new VineBlock(Identifier, true, false, false, false, true),
            8172 => new VineBlock(Identifier, true, false, false, false, false),
            8173 => new VineBlock(Identifier, false, true, true, true, true),
            8174 => new VineBlock(Identifier, false, true, true, true, false),
            8175 => new VineBlock(Identifier, false, true, true, false, true),
            8176 => new VineBlock(Identifier, false, true, true, false, false),
            8177 => new VineBlock(Identifier, false, true, false, true, true),
            8178 => new VineBlock(Identifier, false, true, false, true, false),
            8179 => new VineBlock(Identifier, false, true, false, false, true),
            8180 => new VineBlock(Identifier, false, true, false, false, false),
            8181 => new VineBlock(Identifier, false, false, true, true, true),
            8182 => new VineBlock(Identifier, false, false, true, true, false),
            8183 => new VineBlock(Identifier, false, false, true, false, true),
            8184 => new VineBlock(Identifier, false, false, true, false, false),
            8185 => new VineBlock(Identifier, false, false, false, true, true),
            8186 => new VineBlock(Identifier, false, false, false, true, false),
            8187 => new VineBlock(Identifier, false, false, false, false, true),
            8188 => new VineBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
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
