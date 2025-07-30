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
    public int ProtocolId => 478;
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
                                true => 10501,
                                false => 10502,
                            },
                            false => West switch {
                                true => 10503,
                                false => 10504,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10505,
                                false => 10506,
                            },
                            false => West switch {
                                true => 10507,
                                false => 10508,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10509,
                                false => 10510,
                            },
                            false => West switch {
                                true => 10511,
                                false => 10512,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10513,
                                false => 10514,
                            },
                            false => West switch {
                                true => 10515,
                                false => 10516,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10517,
                                false => 10518,
                            },
                            false => West switch {
                                true => 10519,
                                false => 10520,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10521,
                                false => 10522,
                            },
                            false => West switch {
                                true => 10523,
                                false => 10524,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10525,
                                false => 10526,
                            },
                            false => West switch {
                                true => 10527,
                                false => 10528,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10529,
                                false => 10530,
                            },
                            false => West switch {
                                true => 10531,
                                false => 10532,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10501 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10502 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10503 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10504 => new PurpleStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10505 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10506 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10507 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10508 => new PurpleStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10509 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10510 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10511 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10512 => new PurpleStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10513 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10514 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10515 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10516 => new PurpleStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10517 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10518 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10519 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10520 => new PurpleStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10521 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10522 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10523 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10524 => new PurpleStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10525 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10526 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10527 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10528 => new PurpleStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10529 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10530 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10531 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10532 => new PurpleStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
