using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public double Hardness => 5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:iron_bars";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 1.0, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.iron_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7958,
                                false => 7959,
                            },
                            false => West switch {
                                true => 7960,
                                false => 7961,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7962,
                                false => 7963,
                            },
                            false => West switch {
                                true => 7964,
                                false => 7965,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7966,
                                false => 7967,
                            },
                            false => West switch {
                                true => 7968,
                                false => 7969,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7970,
                                false => 7971,
                            },
                            false => West switch {
                                true => 7972,
                                false => 7973,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7974,
                                false => 7975,
                            },
                            false => West switch {
                                true => 7976,
                                false => 7977,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7978,
                                false => 7979,
                            },
                            false => West switch {
                                true => 7980,
                                false => 7981,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7982,
                                false => 7983,
                            },
                            false => West switch {
                                true => 7984,
                                false => 7985,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7986,
                                false => 7987,
                            },
                            false => West switch {
                                true => 7988,
                                false => 7989,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7958 => new IronBarsBlock(Identifier, true, true, true, true, true),
            7959 => new IronBarsBlock(Identifier, true, true, true, true, false),
            7960 => new IronBarsBlock(Identifier, true, true, true, false, true),
            7961 => new IronBarsBlock(Identifier, true, true, true, false, false),
            7962 => new IronBarsBlock(Identifier, true, true, false, true, true),
            7963 => new IronBarsBlock(Identifier, true, true, false, true, false),
            7964 => new IronBarsBlock(Identifier, true, true, false, false, true),
            7965 => new IronBarsBlock(Identifier, true, true, false, false, false),
            7966 => new IronBarsBlock(Identifier, true, false, true, true, true),
            7967 => new IronBarsBlock(Identifier, true, false, true, true, false),
            7968 => new IronBarsBlock(Identifier, true, false, true, false, true),
            7969 => new IronBarsBlock(Identifier, true, false, true, false, false),
            7970 => new IronBarsBlock(Identifier, true, false, false, true, true),
            7971 => new IronBarsBlock(Identifier, true, false, false, true, false),
            7972 => new IronBarsBlock(Identifier, true, false, false, false, true),
            7973 => new IronBarsBlock(Identifier, true, false, false, false, false),
            7974 => new IronBarsBlock(Identifier, false, true, true, true, true),
            7975 => new IronBarsBlock(Identifier, false, true, true, true, false),
            7976 => new IronBarsBlock(Identifier, false, true, true, false, true),
            7977 => new IronBarsBlock(Identifier, false, true, true, false, false),
            7978 => new IronBarsBlock(Identifier, false, true, false, true, true),
            7979 => new IronBarsBlock(Identifier, false, true, false, true, false),
            7980 => new IronBarsBlock(Identifier, false, true, false, false, true),
            7981 => new IronBarsBlock(Identifier, false, true, false, false, false),
            7982 => new IronBarsBlock(Identifier, false, false, true, true, true),
            7983 => new IronBarsBlock(Identifier, false, false, true, true, false),
            7984 => new IronBarsBlock(Identifier, false, false, true, false, true),
            7985 => new IronBarsBlock(Identifier, false, false, true, false, false),
            7986 => new IronBarsBlock(Identifier, false, false, false, true, true),
            7987 => new IronBarsBlock(Identifier, false, false, false, true, false),
            7988 => new IronBarsBlock(Identifier, false, false, false, false, true),
            7989 => new IronBarsBlock(Identifier, false, false, false, false, false),
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
