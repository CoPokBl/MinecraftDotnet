using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:warped_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21082,
                                false => 21083,
                            },
                            false => West switch {
                                true => 21084,
                                false => 21085,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21086,
                                false => 21087,
                            },
                            false => West switch {
                                true => 21088,
                                false => 21089,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21090,
                                false => 21091,
                            },
                            false => West switch {
                                true => 21092,
                                false => 21093,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21094,
                                false => 21095,
                            },
                            false => West switch {
                                true => 21096,
                                false => 21097,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21098,
                                false => 21099,
                            },
                            false => West switch {
                                true => 21100,
                                false => 21101,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21102,
                                false => 21103,
                            },
                            false => West switch {
                                true => 21104,
                                false => 21105,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 21106,
                                false => 21107,
                            },
                            false => West switch {
                                true => 21108,
                                false => 21109,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 21110,
                                false => 21111,
                            },
                            false => West switch {
                                true => 21112,
                                false => 21113,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21082 => new WarpedFenceBlock(Identifier, true, true, true, true, true),
            21083 => new WarpedFenceBlock(Identifier, true, true, true, true, false),
            21084 => new WarpedFenceBlock(Identifier, true, true, true, false, true),
            21085 => new WarpedFenceBlock(Identifier, true, true, true, false, false),
            21086 => new WarpedFenceBlock(Identifier, true, true, false, true, true),
            21087 => new WarpedFenceBlock(Identifier, true, true, false, true, false),
            21088 => new WarpedFenceBlock(Identifier, true, true, false, false, true),
            21089 => new WarpedFenceBlock(Identifier, true, true, false, false, false),
            21090 => new WarpedFenceBlock(Identifier, true, false, true, true, true),
            21091 => new WarpedFenceBlock(Identifier, true, false, true, true, false),
            21092 => new WarpedFenceBlock(Identifier, true, false, true, false, true),
            21093 => new WarpedFenceBlock(Identifier, true, false, true, false, false),
            21094 => new WarpedFenceBlock(Identifier, true, false, false, true, true),
            21095 => new WarpedFenceBlock(Identifier, true, false, false, true, false),
            21096 => new WarpedFenceBlock(Identifier, true, false, false, false, true),
            21097 => new WarpedFenceBlock(Identifier, true, false, false, false, false),
            21098 => new WarpedFenceBlock(Identifier, false, true, true, true, true),
            21099 => new WarpedFenceBlock(Identifier, false, true, true, true, false),
            21100 => new WarpedFenceBlock(Identifier, false, true, true, false, true),
            21101 => new WarpedFenceBlock(Identifier, false, true, true, false, false),
            21102 => new WarpedFenceBlock(Identifier, false, true, false, true, true),
            21103 => new WarpedFenceBlock(Identifier, false, true, false, true, false),
            21104 => new WarpedFenceBlock(Identifier, false, true, false, false, true),
            21105 => new WarpedFenceBlock(Identifier, false, true, false, false, false),
            21106 => new WarpedFenceBlock(Identifier, false, false, true, true, true),
            21107 => new WarpedFenceBlock(Identifier, false, false, true, true, false),
            21108 => new WarpedFenceBlock(Identifier, false, false, true, false, true),
            21109 => new WarpedFenceBlock(Identifier, false, false, true, false, false),
            21110 => new WarpedFenceBlock(Identifier, false, false, false, true, true),
            21111 => new WarpedFenceBlock(Identifier, false, false, false, true, false),
            21112 => new WarpedFenceBlock(Identifier, false, false, false, false, true),
            21113 => new WarpedFenceBlock(Identifier, false, false, false, false, false),
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
