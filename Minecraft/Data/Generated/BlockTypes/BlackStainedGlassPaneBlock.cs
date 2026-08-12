using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public double Hardness => 0.3;
    public double ExplosionResistance => 0.3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "glass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:black_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.black_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11940,
                                false => 11941,
                            },
                            false => West switch {
                                true => 11942,
                                false => 11943,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11944,
                                false => 11945,
                            },
                            false => West switch {
                                true => 11946,
                                false => 11947,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11948,
                                false => 11949,
                            },
                            false => West switch {
                                true => 11950,
                                false => 11951,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11952,
                                false => 11953,
                            },
                            false => West switch {
                                true => 11954,
                                false => 11955,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11956,
                                false => 11957,
                            },
                            false => West switch {
                                true => 11958,
                                false => 11959,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11960,
                                false => 11961,
                            },
                            false => West switch {
                                true => 11962,
                                false => 11963,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11964,
                                false => 11965,
                            },
                            false => West switch {
                                true => 11966,
                                false => 11967,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11968,
                                false => 11969,
                            },
                            false => West switch {
                                true => 11970,
                                false => 11971,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11940 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11941 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11942 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11943 => new BlackStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11944 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11945 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11946 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11947 => new BlackStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11948 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11949 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11950 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11951 => new BlackStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11952 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11953 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11954 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11955 => new BlackStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11956 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11957 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11958 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11959 => new BlackStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11960 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11961 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11962 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11963 => new BlackStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11964 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11965 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11966 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11967 => new BlackStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11968 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11969 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11970 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11971 => new BlackStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
