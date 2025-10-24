using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 510;
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
    public Identifier? Item => "minecraft:brown_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.brown_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11642,
                                false => 11643,
                            },
                            false => West switch {
                                true => 11644,
                                false => 11645,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11646,
                                false => 11647,
                            },
                            false => West switch {
                                true => 11648,
                                false => 11649,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11650,
                                false => 11651,
                            },
                            false => West switch {
                                true => 11652,
                                false => 11653,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11654,
                                false => 11655,
                            },
                            false => West switch {
                                true => 11656,
                                false => 11657,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11658,
                                false => 11659,
                            },
                            false => West switch {
                                true => 11660,
                                false => 11661,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11662,
                                false => 11663,
                            },
                            false => West switch {
                                true => 11664,
                                false => 11665,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 11666,
                                false => 11667,
                            },
                            false => West switch {
                                true => 11668,
                                false => 11669,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 11670,
                                false => 11671,
                            },
                            false => West switch {
                                true => 11672,
                                false => 11673,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11642 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            11643 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            11644 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            11645 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            11646 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            11647 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            11648 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            11649 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            11650 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            11651 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            11652 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            11653 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            11654 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            11655 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            11656 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            11657 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            11658 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            11659 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            11660 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            11661 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            11662 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            11663 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            11664 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            11665 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            11666 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            11667 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            11668 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            11669 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            11670 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            11671 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            11672 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            11673 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
