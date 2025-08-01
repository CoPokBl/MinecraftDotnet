using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 471;
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
    public Identifier? Item => "minecraft:light_blue_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.light_blue_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10277,
                                false => 10278,
                            },
                            false => West switch {
                                true => 10279,
                                false => 10280,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10281,
                                false => 10282,
                            },
                            false => West switch {
                                true => 10283,
                                false => 10284,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10285,
                                false => 10286,
                            },
                            false => West switch {
                                true => 10287,
                                false => 10288,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10289,
                                false => 10290,
                            },
                            false => West switch {
                                true => 10291,
                                false => 10292,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10293,
                                false => 10294,
                            },
                            false => West switch {
                                true => 10295,
                                false => 10296,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10297,
                                false => 10298,
                            },
                            false => West switch {
                                true => 10299,
                                false => 10300,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10301,
                                false => 10302,
                            },
                            false => West switch {
                                true => 10303,
                                false => 10304,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10305,
                                false => 10306,
                            },
                            false => West switch {
                                true => 10307,
                                false => 10308,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10277 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10278 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10279 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10280 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10281 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10282 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10283 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10284 => new LightBlueStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10285 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10286 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10287 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10288 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10289 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10290 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10291 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10292 => new LightBlueStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10293 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10294 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10295 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10296 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10297 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10298 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10299 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10300 => new LightBlueStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10301 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10302 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10303 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10304 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10305 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10306 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10307 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10308 => new LightBlueStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
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
