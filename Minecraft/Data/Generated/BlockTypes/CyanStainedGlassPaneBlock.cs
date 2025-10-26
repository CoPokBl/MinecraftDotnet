using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 507;
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
    public Identifier? Item => "minecraft:cyan_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.cyan_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11546,
                                false => 11547,
                            },
                            false => West switch {
                                true => 11548,
                                false => 11549,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11550,
                                false => 11551,
                            },
                            false => West switch {
                                true => 11552,
                                false => 11553,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11554,
                                false => 11555,
                            },
                            false => West switch {
                                true => 11556,
                                false => 11557,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11558,
                                false => 11559,
                            },
                            false => West switch {
                                true => 11560,
                                false => 11561,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11562,
                                false => 11563,
                            },
                            false => West switch {
                                true => 11564,
                                false => 11565,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11566,
                                false => 11567,
                            },
                            false => West switch {
                                true => 11568,
                                false => 11569,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11570,
                                false => 11571,
                            },
                            false => West switch {
                                true => 11572,
                                false => 11573,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11574,
                                false => 11575,
                            },
                            false => West switch {
                                true => 11576,
                                false => 11577,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11546 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11547 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11548 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11549 => new CyanStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11550 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11551 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11552 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11553 => new CyanStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11554 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11555 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11556 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11557 => new CyanStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11558 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11559 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11560 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11561 => new CyanStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11562 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11563 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11564 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11565 => new CyanStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11566 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11567 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11568 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11569 => new CyanStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11570 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11571 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11572 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11573 => new CyanStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11574 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11575 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11576 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11577 => new CyanStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
