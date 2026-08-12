using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6965,
                                false => 6966,
                            },
                            false => West switch {
                                true => 6967,
                                false => 6968,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6969,
                                false => 6970,
                            },
                            false => West switch {
                                true => 6971,
                                false => 6972,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6973,
                                false => 6974,
                            },
                            false => West switch {
                                true => 6975,
                                false => 6976,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6977,
                                false => 6978,
                            },
                            false => West switch {
                                true => 6979,
                                false => 6980,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6981,
                                false => 6982,
                            },
                            false => West switch {
                                true => 6983,
                                false => 6984,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6985,
                                false => 6986,
                            },
                            false => West switch {
                                true => 6987,
                                false => 6988,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6989,
                                false => 6990,
                            },
                            false => West switch {
                                true => 6991,
                                false => 6992,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6993,
                                false => 6994,
                            },
                            false => West switch {
                                true => 6995,
                                false => 6996,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6965 => new OakFenceBlock(Identifier, true, true, true, true, true),
            6966 => new OakFenceBlock(Identifier, true, true, true, true, false),
            6967 => new OakFenceBlock(Identifier, true, true, true, false, true),
            6968 => new OakFenceBlock(Identifier, true, true, true, false, false),
            6969 => new OakFenceBlock(Identifier, true, true, false, true, true),
            6970 => new OakFenceBlock(Identifier, true, true, false, true, false),
            6971 => new OakFenceBlock(Identifier, true, true, false, false, true),
            6972 => new OakFenceBlock(Identifier, true, true, false, false, false),
            6973 => new OakFenceBlock(Identifier, true, false, true, true, true),
            6974 => new OakFenceBlock(Identifier, true, false, true, true, false),
            6975 => new OakFenceBlock(Identifier, true, false, true, false, true),
            6976 => new OakFenceBlock(Identifier, true, false, true, false, false),
            6977 => new OakFenceBlock(Identifier, true, false, false, true, true),
            6978 => new OakFenceBlock(Identifier, true, false, false, true, false),
            6979 => new OakFenceBlock(Identifier, true, false, false, false, true),
            6980 => new OakFenceBlock(Identifier, true, false, false, false, false),
            6981 => new OakFenceBlock(Identifier, false, true, true, true, true),
            6982 => new OakFenceBlock(Identifier, false, true, true, true, false),
            6983 => new OakFenceBlock(Identifier, false, true, true, false, true),
            6984 => new OakFenceBlock(Identifier, false, true, true, false, false),
            6985 => new OakFenceBlock(Identifier, false, true, false, true, true),
            6986 => new OakFenceBlock(Identifier, false, true, false, true, false),
            6987 => new OakFenceBlock(Identifier, false, true, false, false, true),
            6988 => new OakFenceBlock(Identifier, false, true, false, false, false),
            6989 => new OakFenceBlock(Identifier, false, false, true, true, true),
            6990 => new OakFenceBlock(Identifier, false, false, true, true, false),
            6991 => new OakFenceBlock(Identifier, false, false, true, false, true),
            6992 => new OakFenceBlock(Identifier, false, false, true, false, false),
            6993 => new OakFenceBlock(Identifier, false, false, false, true, true),
            6994 => new OakFenceBlock(Identifier, false, false, false, true, false),
            6995 => new OakFenceBlock(Identifier, false, false, false, false, true),
            6996 => new OakFenceBlock(Identifier, false, false, false, false, false),
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
