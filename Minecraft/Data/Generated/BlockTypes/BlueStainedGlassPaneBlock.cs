using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 509;
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
    public Identifier? Item => "minecraft:blue_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.blue_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11610,
                                false => 11611,
                            },
                            false => West switch {
                                true => 11612,
                                false => 11613,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11614,
                                false => 11615,
                            },
                            false => West switch {
                                true => 11616,
                                false => 11617,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11618,
                                false => 11619,
                            },
                            false => West switch {
                                true => 11620,
                                false => 11621,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11622,
                                false => 11623,
                            },
                            false => West switch {
                                true => 11624,
                                false => 11625,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11626,
                                false => 11627,
                            },
                            false => West switch {
                                true => 11628,
                                false => 11629,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11630,
                                false => 11631,
                            },
                            false => West switch {
                                true => 11632,
                                false => 11633,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11634,
                                false => 11635,
                            },
                            false => West switch {
                                true => 11636,
                                false => 11637,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11638,
                                false => 11639,
                            },
                            false => West switch {
                                true => 11640,
                                false => 11641,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11610 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11611 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11612 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11613 => new BlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11614 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11615 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11616 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11617 => new BlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11618 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11619 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11620 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11621 => new BlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11622 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11623 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11624 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11625 => new BlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11626 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11627 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11628 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11629 => new BlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11630 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11631 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11632 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11633 => new BlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11634 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11635 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11636 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11637 => new BlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11638 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11639 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11640 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11641 => new BlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
