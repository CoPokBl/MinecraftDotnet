using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:dark_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13932,
                                false => 13933,
                            },
                            false => West switch {
                                true => 13934,
                                false => 13935,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13936,
                                false => 13937,
                            },
                            false => West switch {
                                true => 13938,
                                false => 13939,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13940,
                                false => 13941,
                            },
                            false => West switch {
                                true => 13942,
                                false => 13943,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13944,
                                false => 13945,
                            },
                            false => West switch {
                                true => 13946,
                                false => 13947,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13948,
                                false => 13949,
                            },
                            false => West switch {
                                true => 13950,
                                false => 13951,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13952,
                                false => 13953,
                            },
                            false => West switch {
                                true => 13954,
                                false => 13955,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13956,
                                false => 13957,
                            },
                            false => West switch {
                                true => 13958,
                                false => 13959,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13960,
                                false => 13961,
                            },
                            false => West switch {
                                true => 13962,
                                false => 13963,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13932 => new DarkOakFenceBlock(Identifier, true, true, true, true, true),
            13933 => new DarkOakFenceBlock(Identifier, true, true, true, true, false),
            13934 => new DarkOakFenceBlock(Identifier, true, true, true, false, true),
            13935 => new DarkOakFenceBlock(Identifier, true, true, true, false, false),
            13936 => new DarkOakFenceBlock(Identifier, true, true, false, true, true),
            13937 => new DarkOakFenceBlock(Identifier, true, true, false, true, false),
            13938 => new DarkOakFenceBlock(Identifier, true, true, false, false, true),
            13939 => new DarkOakFenceBlock(Identifier, true, true, false, false, false),
            13940 => new DarkOakFenceBlock(Identifier, true, false, true, true, true),
            13941 => new DarkOakFenceBlock(Identifier, true, false, true, true, false),
            13942 => new DarkOakFenceBlock(Identifier, true, false, true, false, true),
            13943 => new DarkOakFenceBlock(Identifier, true, false, true, false, false),
            13944 => new DarkOakFenceBlock(Identifier, true, false, false, true, true),
            13945 => new DarkOakFenceBlock(Identifier, true, false, false, true, false),
            13946 => new DarkOakFenceBlock(Identifier, true, false, false, false, true),
            13947 => new DarkOakFenceBlock(Identifier, true, false, false, false, false),
            13948 => new DarkOakFenceBlock(Identifier, false, true, true, true, true),
            13949 => new DarkOakFenceBlock(Identifier, false, true, true, true, false),
            13950 => new DarkOakFenceBlock(Identifier, false, true, true, false, true),
            13951 => new DarkOakFenceBlock(Identifier, false, true, true, false, false),
            13952 => new DarkOakFenceBlock(Identifier, false, true, false, true, true),
            13953 => new DarkOakFenceBlock(Identifier, false, true, false, true, false),
            13954 => new DarkOakFenceBlock(Identifier, false, true, false, false, true),
            13955 => new DarkOakFenceBlock(Identifier, false, true, false, false, false),
            13956 => new DarkOakFenceBlock(Identifier, false, false, true, true, true),
            13957 => new DarkOakFenceBlock(Identifier, false, false, true, true, false),
            13958 => new DarkOakFenceBlock(Identifier, false, false, true, false, true),
            13959 => new DarkOakFenceBlock(Identifier, false, false, true, false, false),
            13960 => new DarkOakFenceBlock(Identifier, false, false, false, true, true),
            13961 => new DarkOakFenceBlock(Identifier, false, false, false, true, false),
            13962 => new DarkOakFenceBlock(Identifier, false, false, false, false, true),
            13963 => new DarkOakFenceBlock(Identifier, false, false, false, false, false),
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
