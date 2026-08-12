using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:purple_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.purple_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11780,
                                false => 11781,
                            },
                            false => West switch {
                                true => 11782,
                                false => 11783,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11784,
                                false => 11785,
                            },
                            false => West switch {
                                true => 11786,
                                false => 11787,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11788,
                                false => 11789,
                            },
                            false => West switch {
                                true => 11790,
                                false => 11791,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11792,
                                false => 11793,
                            },
                            false => West switch {
                                true => 11794,
                                false => 11795,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11796,
                                false => 11797,
                            },
                            false => West switch {
                                true => 11798,
                                false => 11799,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11800,
                                false => 11801,
                            },
                            false => West switch {
                                true => 11802,
                                false => 11803,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11804,
                                false => 11805,
                            },
                            false => West switch {
                                true => 11806,
                                false => 11807,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11808,
                                false => 11809,
                            },
                            false => West switch {
                                true => 11810,
                                false => 11811,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11780 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11781 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11782 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11783 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11784 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11785 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11786 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11787 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11788 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11789 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11790 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11791 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11792 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11793 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11794 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11795 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11796 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11797 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11798 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11799 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11800 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11801 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11802 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11803 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11804 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11805 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11806 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11807 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11808 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11809 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11810 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11811 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
