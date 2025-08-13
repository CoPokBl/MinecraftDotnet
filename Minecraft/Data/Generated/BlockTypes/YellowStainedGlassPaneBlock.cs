using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 472;
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
    public Identifier? Item => "minecraft:yellow_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.yellow_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10309,
                                false => 10310,
                            },
                            false => West switch {
                                true => 10311,
                                false => 10312,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10313,
                                false => 10314,
                            },
                            false => West switch {
                                true => 10315,
                                false => 10316,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10317,
                                false => 10318,
                            },
                            false => West switch {
                                true => 10319,
                                false => 10320,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10321,
                                false => 10322,
                            },
                            false => West switch {
                                true => 10323,
                                false => 10324,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10325,
                                false => 10326,
                            },
                            false => West switch {
                                true => 10327,
                                false => 10328,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10329,
                                false => 10330,
                            },
                            false => West switch {
                                true => 10331,
                                false => 10332,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10333,
                                false => 10334,
                            },
                            false => West switch {
                                true => 10335,
                                false => 10336,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10337,
                                false => 10338,
                            },
                            false => West switch {
                                true => 10339,
                                false => 10340,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10309 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10310 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10311 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10312 => new YellowStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10313 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10314 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10315 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10316 => new YellowStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10317 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10318 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10319 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10320 => new YellowStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10321 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10322 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10323 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10324 => new YellowStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10325 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10326 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10327 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10328 => new YellowStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10329 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10330 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10331 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10332 => new YellowStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10333 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10334 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10335 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10336 => new YellowStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10337 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10338 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10339 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10340 => new YellowStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
