using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13900,
                                false => 13901,
                            },
                            false => West switch {
                                true => 13902,
                                false => 13903,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13904,
                                false => 13905,
                            },
                            false => West switch {
                                true => 13906,
                                false => 13907,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13908,
                                false => 13909,
                            },
                            false => West switch {
                                true => 13910,
                                false => 13911,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13912,
                                false => 13913,
                            },
                            false => West switch {
                                true => 13914,
                                false => 13915,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13916,
                                false => 13917,
                            },
                            false => West switch {
                                true => 13918,
                                false => 13919,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13920,
                                false => 13921,
                            },
                            false => West switch {
                                true => 13922,
                                false => 13923,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13924,
                                false => 13925,
                            },
                            false => West switch {
                                true => 13926,
                                false => 13927,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13928,
                                false => 13929,
                            },
                            false => West switch {
                                true => 13930,
                                false => 13931,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13900 => new CherryFenceBlock(Identifier, true, true, true, true, true),
            13901 => new CherryFenceBlock(Identifier, true, true, true, true, false),
            13902 => new CherryFenceBlock(Identifier, true, true, true, false, true),
            13903 => new CherryFenceBlock(Identifier, true, true, true, false, false),
            13904 => new CherryFenceBlock(Identifier, true, true, false, true, true),
            13905 => new CherryFenceBlock(Identifier, true, true, false, true, false),
            13906 => new CherryFenceBlock(Identifier, true, true, false, false, true),
            13907 => new CherryFenceBlock(Identifier, true, true, false, false, false),
            13908 => new CherryFenceBlock(Identifier, true, false, true, true, true),
            13909 => new CherryFenceBlock(Identifier, true, false, true, true, false),
            13910 => new CherryFenceBlock(Identifier, true, false, true, false, true),
            13911 => new CherryFenceBlock(Identifier, true, false, true, false, false),
            13912 => new CherryFenceBlock(Identifier, true, false, false, true, true),
            13913 => new CherryFenceBlock(Identifier, true, false, false, true, false),
            13914 => new CherryFenceBlock(Identifier, true, false, false, false, true),
            13915 => new CherryFenceBlock(Identifier, true, false, false, false, false),
            13916 => new CherryFenceBlock(Identifier, false, true, true, true, true),
            13917 => new CherryFenceBlock(Identifier, false, true, true, true, false),
            13918 => new CherryFenceBlock(Identifier, false, true, true, false, true),
            13919 => new CherryFenceBlock(Identifier, false, true, true, false, false),
            13920 => new CherryFenceBlock(Identifier, false, true, false, true, true),
            13921 => new CherryFenceBlock(Identifier, false, true, false, true, false),
            13922 => new CherryFenceBlock(Identifier, false, true, false, false, true),
            13923 => new CherryFenceBlock(Identifier, false, true, false, false, false),
            13924 => new CherryFenceBlock(Identifier, false, false, true, true, true),
            13925 => new CherryFenceBlock(Identifier, false, false, true, true, false),
            13926 => new CherryFenceBlock(Identifier, false, false, true, false, true),
            13927 => new CherryFenceBlock(Identifier, false, false, true, false, false),
            13928 => new CherryFenceBlock(Identifier, false, false, false, true, true),
            13929 => new CherryFenceBlock(Identifier, false, false, false, true, false),
            13930 => new CherryFenceBlock(Identifier, false, false, false, false, true),
            13931 => new CherryFenceBlock(Identifier, false, false, false, false, false),
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
