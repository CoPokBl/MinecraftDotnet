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
    public int ProtocolId => 480;
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
                                true => 10565,
                                false => 10566,
                            },
                            false => West switch {
                                true => 10567,
                                false => 10568,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10569,
                                false => 10570,
                            },
                            false => West switch {
                                true => 10571,
                                false => 10572,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10573,
                                false => 10574,
                            },
                            false => West switch {
                                true => 10575,
                                false => 10576,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10577,
                                false => 10578,
                            },
                            false => West switch {
                                true => 10579,
                                false => 10580,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10581,
                                false => 10582,
                            },
                            false => West switch {
                                true => 10583,
                                false => 10584,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10585,
                                false => 10586,
                            },
                            false => West switch {
                                true => 10587,
                                false => 10588,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10589,
                                false => 10590,
                            },
                            false => West switch {
                                true => 10591,
                                false => 10592,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10593,
                                false => 10594,
                            },
                            false => West switch {
                                true => 10595,
                                false => 10596,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10565 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10566 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10567 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10568 => new BrownStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10569 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10570 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10571 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10572 => new BrownStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10573 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10574 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10575 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10576 => new BrownStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10577 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10578 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10579 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10580 => new BrownStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10581 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10582 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10583 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10584 => new BrownStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10585 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10586 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10587 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10588 => new BrownStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10589 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10590 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10591 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10592 => new BrownStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10593 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10594 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10595 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10596 => new BrownStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
