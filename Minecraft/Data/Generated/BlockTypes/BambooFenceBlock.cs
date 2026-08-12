using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14028,
                                false => 14029,
                            },
                            false => West switch {
                                true => 14030,
                                false => 14031,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14032,
                                false => 14033,
                            },
                            false => West switch {
                                true => 14034,
                                false => 14035,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14036,
                                false => 14037,
                            },
                            false => West switch {
                                true => 14038,
                                false => 14039,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14040,
                                false => 14041,
                            },
                            false => West switch {
                                true => 14042,
                                false => 14043,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14044,
                                false => 14045,
                            },
                            false => West switch {
                                true => 14046,
                                false => 14047,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14048,
                                false => 14049,
                            },
                            false => West switch {
                                true => 14050,
                                false => 14051,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14052,
                                false => 14053,
                            },
                            false => West switch {
                                true => 14054,
                                false => 14055,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14056,
                                false => 14057,
                            },
                            false => West switch {
                                true => 14058,
                                false => 14059,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14028 => new BambooFenceBlock(Identifier, true, true, true, true, true),
            14029 => new BambooFenceBlock(Identifier, true, true, true, true, false),
            14030 => new BambooFenceBlock(Identifier, true, true, true, false, true),
            14031 => new BambooFenceBlock(Identifier, true, true, true, false, false),
            14032 => new BambooFenceBlock(Identifier, true, true, false, true, true),
            14033 => new BambooFenceBlock(Identifier, true, true, false, true, false),
            14034 => new BambooFenceBlock(Identifier, true, true, false, false, true),
            14035 => new BambooFenceBlock(Identifier, true, true, false, false, false),
            14036 => new BambooFenceBlock(Identifier, true, false, true, true, true),
            14037 => new BambooFenceBlock(Identifier, true, false, true, true, false),
            14038 => new BambooFenceBlock(Identifier, true, false, true, false, true),
            14039 => new BambooFenceBlock(Identifier, true, false, true, false, false),
            14040 => new BambooFenceBlock(Identifier, true, false, false, true, true),
            14041 => new BambooFenceBlock(Identifier, true, false, false, true, false),
            14042 => new BambooFenceBlock(Identifier, true, false, false, false, true),
            14043 => new BambooFenceBlock(Identifier, true, false, false, false, false),
            14044 => new BambooFenceBlock(Identifier, false, true, true, true, true),
            14045 => new BambooFenceBlock(Identifier, false, true, true, true, false),
            14046 => new BambooFenceBlock(Identifier, false, true, true, false, true),
            14047 => new BambooFenceBlock(Identifier, false, true, true, false, false),
            14048 => new BambooFenceBlock(Identifier, false, true, false, true, true),
            14049 => new BambooFenceBlock(Identifier, false, true, false, true, false),
            14050 => new BambooFenceBlock(Identifier, false, true, false, false, true),
            14051 => new BambooFenceBlock(Identifier, false, true, false, false, false),
            14052 => new BambooFenceBlock(Identifier, false, false, true, true, true),
            14053 => new BambooFenceBlock(Identifier, false, false, true, true, false),
            14054 => new BambooFenceBlock(Identifier, false, false, true, false, true),
            14055 => new BambooFenceBlock(Identifier, false, false, true, false, false),
            14056 => new BambooFenceBlock(Identifier, false, false, false, true, true),
            14057 => new BambooFenceBlock(Identifier, false, false, false, true, false),
            14058 => new BambooFenceBlock(Identifier, false, false, false, false, true),
            14059 => new BambooFenceBlock(Identifier, false, false, false, false, false),
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
