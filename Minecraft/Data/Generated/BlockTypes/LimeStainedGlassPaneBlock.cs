using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 473;
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
    public Identifier? Item => "minecraft:lime_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.lime_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10341,
                                false => 10342,
                            },
                            false => West switch {
                                true => 10343,
                                false => 10344,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10345,
                                false => 10346,
                            },
                            false => West switch {
                                true => 10347,
                                false => 10348,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10349,
                                false => 10350,
                            },
                            false => West switch {
                                true => 10351,
                                false => 10352,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10353,
                                false => 10354,
                            },
                            false => West switch {
                                true => 10355,
                                false => 10356,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10357,
                                false => 10358,
                            },
                            false => West switch {
                                true => 10359,
                                false => 10360,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10361,
                                false => 10362,
                            },
                            false => West switch {
                                true => 10363,
                                false => 10364,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10365,
                                false => 10366,
                            },
                            false => West switch {
                                true => 10367,
                                false => 10368,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10369,
                                false => 10370,
                            },
                            false => West switch {
                                true => 10371,
                                false => 10372,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10341 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10342 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10343 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10344 => new LimeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10345 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10346 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10347 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10348 => new LimeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10349 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10350 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10351 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10352 => new LimeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10353 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10354 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10355 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10356 => new LimeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10357 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10358 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10359 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10360 => new LimeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10361 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10362 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10363 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10364 => new LimeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10365 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10366 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10367 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10368 => new LimeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10369 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10370 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10371 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10372 => new LimeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
