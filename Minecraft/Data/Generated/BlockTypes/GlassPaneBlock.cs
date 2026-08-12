using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
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
    public Identifier? Item => "minecraft:glass_pane";
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
    public string TranslationKey => "block.minecraft.glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8300,
                                false => 8301,
                            },
                            false => West switch {
                                true => 8302,
                                false => 8303,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8304,
                                false => 8305,
                            },
                            false => West switch {
                                true => 8306,
                                false => 8307,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8308,
                                false => 8309,
                            },
                            false => West switch {
                                true => 8310,
                                false => 8311,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8312,
                                false => 8313,
                            },
                            false => West switch {
                                true => 8314,
                                false => 8315,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8316,
                                false => 8317,
                            },
                            false => West switch {
                                true => 8318,
                                false => 8319,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8320,
                                false => 8321,
                            },
                            false => West switch {
                                true => 8322,
                                false => 8323,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8324,
                                false => 8325,
                            },
                            false => West switch {
                                true => 8326,
                                false => 8327,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8328,
                                false => 8329,
                            },
                            false => West switch {
                                true => 8330,
                                false => 8331,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8300 => new GlassPaneBlock(Identifier, true, true, true, true, true),
            8301 => new GlassPaneBlock(Identifier, true, true, true, true, false),
            8302 => new GlassPaneBlock(Identifier, true, true, true, false, true),
            8303 => new GlassPaneBlock(Identifier, true, true, true, false, false),
            8304 => new GlassPaneBlock(Identifier, true, true, false, true, true),
            8305 => new GlassPaneBlock(Identifier, true, true, false, true, false),
            8306 => new GlassPaneBlock(Identifier, true, true, false, false, true),
            8307 => new GlassPaneBlock(Identifier, true, true, false, false, false),
            8308 => new GlassPaneBlock(Identifier, true, false, true, true, true),
            8309 => new GlassPaneBlock(Identifier, true, false, true, true, false),
            8310 => new GlassPaneBlock(Identifier, true, false, true, false, true),
            8311 => new GlassPaneBlock(Identifier, true, false, true, false, false),
            8312 => new GlassPaneBlock(Identifier, true, false, false, true, true),
            8313 => new GlassPaneBlock(Identifier, true, false, false, true, false),
            8314 => new GlassPaneBlock(Identifier, true, false, false, false, true),
            8315 => new GlassPaneBlock(Identifier, true, false, false, false, false),
            8316 => new GlassPaneBlock(Identifier, false, true, true, true, true),
            8317 => new GlassPaneBlock(Identifier, false, true, true, true, false),
            8318 => new GlassPaneBlock(Identifier, false, true, true, false, true),
            8319 => new GlassPaneBlock(Identifier, false, true, true, false, false),
            8320 => new GlassPaneBlock(Identifier, false, true, false, true, true),
            8321 => new GlassPaneBlock(Identifier, false, true, false, true, false),
            8322 => new GlassPaneBlock(Identifier, false, true, false, false, true),
            8323 => new GlassPaneBlock(Identifier, false, true, false, false, false),
            8324 => new GlassPaneBlock(Identifier, false, false, true, true, true),
            8325 => new GlassPaneBlock(Identifier, false, false, true, true, false),
            8326 => new GlassPaneBlock(Identifier, false, false, true, false, true),
            8327 => new GlassPaneBlock(Identifier, false, false, true, false, false),
            8328 => new GlassPaneBlock(Identifier, false, false, false, true, true),
            8329 => new GlassPaneBlock(Identifier, false, false, false, true, false),
            8330 => new GlassPaneBlock(Identifier, false, false, false, false, true),
            8331 => new GlassPaneBlock(Identifier, false, false, false, false, false),
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
