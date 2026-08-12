using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13964,
                                false => 13965,
                            },
                            false => West switch {
                                true => 13966,
                                false => 13967,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13968,
                                false => 13969,
                            },
                            false => West switch {
                                true => 13970,
                                false => 13971,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13972,
                                false => 13973,
                            },
                            false => West switch {
                                true => 13974,
                                false => 13975,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13976,
                                false => 13977,
                            },
                            false => West switch {
                                true => 13978,
                                false => 13979,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13980,
                                false => 13981,
                            },
                            false => West switch {
                                true => 13982,
                                false => 13983,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13984,
                                false => 13985,
                            },
                            false => West switch {
                                true => 13986,
                                false => 13987,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13988,
                                false => 13989,
                            },
                            false => West switch {
                                true => 13990,
                                false => 13991,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13992,
                                false => 13993,
                            },
                            false => West switch {
                                true => 13994,
                                false => 13995,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13964 => new PaleOakFenceBlock(Identifier, true, true, true, true, true),
            13965 => new PaleOakFenceBlock(Identifier, true, true, true, true, false),
            13966 => new PaleOakFenceBlock(Identifier, true, true, true, false, true),
            13967 => new PaleOakFenceBlock(Identifier, true, true, true, false, false),
            13968 => new PaleOakFenceBlock(Identifier, true, true, false, true, true),
            13969 => new PaleOakFenceBlock(Identifier, true, true, false, true, false),
            13970 => new PaleOakFenceBlock(Identifier, true, true, false, false, true),
            13971 => new PaleOakFenceBlock(Identifier, true, true, false, false, false),
            13972 => new PaleOakFenceBlock(Identifier, true, false, true, true, true),
            13973 => new PaleOakFenceBlock(Identifier, true, false, true, true, false),
            13974 => new PaleOakFenceBlock(Identifier, true, false, true, false, true),
            13975 => new PaleOakFenceBlock(Identifier, true, false, true, false, false),
            13976 => new PaleOakFenceBlock(Identifier, true, false, false, true, true),
            13977 => new PaleOakFenceBlock(Identifier, true, false, false, true, false),
            13978 => new PaleOakFenceBlock(Identifier, true, false, false, false, true),
            13979 => new PaleOakFenceBlock(Identifier, true, false, false, false, false),
            13980 => new PaleOakFenceBlock(Identifier, false, true, true, true, true),
            13981 => new PaleOakFenceBlock(Identifier, false, true, true, true, false),
            13982 => new PaleOakFenceBlock(Identifier, false, true, true, false, true),
            13983 => new PaleOakFenceBlock(Identifier, false, true, true, false, false),
            13984 => new PaleOakFenceBlock(Identifier, false, true, false, true, true),
            13985 => new PaleOakFenceBlock(Identifier, false, true, false, true, false),
            13986 => new PaleOakFenceBlock(Identifier, false, true, false, false, true),
            13987 => new PaleOakFenceBlock(Identifier, false, true, false, false, false),
            13988 => new PaleOakFenceBlock(Identifier, false, false, true, true, true),
            13989 => new PaleOakFenceBlock(Identifier, false, false, true, true, false),
            13990 => new PaleOakFenceBlock(Identifier, false, false, true, false, true),
            13991 => new PaleOakFenceBlock(Identifier, false, false, true, false, false),
            13992 => new PaleOakFenceBlock(Identifier, false, false, false, true, true),
            13993 => new PaleOakFenceBlock(Identifier, false, false, false, true, false),
            13994 => new PaleOakFenceBlock(Identifier, false, false, false, false, true),
            13995 => new PaleOakFenceBlock(Identifier, false, false, false, false, false),
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
