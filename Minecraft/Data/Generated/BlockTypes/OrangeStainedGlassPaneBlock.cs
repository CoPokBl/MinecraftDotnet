using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 469;
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
    public Identifier? Item => "minecraft:orange_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.orange_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10213,
                                false => 10214,
                            },
                            false => West switch {
                                true => 10215,
                                false => 10216,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10217,
                                false => 10218,
                            },
                            false => West switch {
                                true => 10219,
                                false => 10220,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10221,
                                false => 10222,
                            },
                            false => West switch {
                                true => 10223,
                                false => 10224,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10225,
                                false => 10226,
                            },
                            false => West switch {
                                true => 10227,
                                false => 10228,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10229,
                                false => 10230,
                            },
                            false => West switch {
                                true => 10231,
                                false => 10232,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10233,
                                false => 10234,
                            },
                            false => West switch {
                                true => 10235,
                                false => 10236,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10237,
                                false => 10238,
                            },
                            false => West switch {
                                true => 10239,
                                false => 10240,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10241,
                                false => 10242,
                            },
                            false => West switch {
                                true => 10243,
                                false => 10244,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10213 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10214 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10215 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10216 => new OrangeStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10217 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10218 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10219 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10220 => new OrangeStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10221 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10222 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10223 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10224 => new OrangeStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10225 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10226 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10227 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10228 => new OrangeStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10229 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10230 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10231 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10232 => new OrangeStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10233 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10234 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10235 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10236 => new OrangeStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10237 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10238 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10239 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10240 => new OrangeStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10241 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10242 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10243 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10244 => new OrangeStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
