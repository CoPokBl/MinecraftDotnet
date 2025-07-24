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
    public int ProtocolId => 328;
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
                                true => 7022,
                                false => 7023,
                            },
                            false => West switch {
                                true => 7024,
                                false => 7025,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7026,
                                false => 7027,
                            },
                            false => West switch {
                                true => 7028,
                                false => 7029,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7030,
                                false => 7031,
                            },
                            false => West switch {
                                true => 7032,
                                false => 7033,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7034,
                                false => 7035,
                            },
                            false => West switch {
                                true => 7036,
                                false => 7037,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7038,
                                false => 7039,
                            },
                            false => West switch {
                                true => 7040,
                                false => 7041,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7042,
                                false => 7043,
                            },
                            false => West switch {
                                true => 7044,
                                false => 7045,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7046,
                                false => 7047,
                            },
                            false => West switch {
                                true => 7048,
                                false => 7049,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7050,
                                false => 7051,
                            },
                            false => West switch {
                                true => 7052,
                                false => 7053,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7022 => new GlassPaneBlock(Identifier, true, true, true, true, true),
            7023 => new GlassPaneBlock(Identifier, true, true, true, true, false),
            7024 => new GlassPaneBlock(Identifier, true, true, true, false, true),
            7025 => new GlassPaneBlock(Identifier, true, true, true, false, false),
            7026 => new GlassPaneBlock(Identifier, true, true, false, true, true),
            7027 => new GlassPaneBlock(Identifier, true, true, false, true, false),
            7028 => new GlassPaneBlock(Identifier, true, true, false, false, true),
            7029 => new GlassPaneBlock(Identifier, true, true, false, false, false),
            7030 => new GlassPaneBlock(Identifier, true, false, true, true, true),
            7031 => new GlassPaneBlock(Identifier, true, false, true, true, false),
            7032 => new GlassPaneBlock(Identifier, true, false, true, false, true),
            7033 => new GlassPaneBlock(Identifier, true, false, true, false, false),
            7034 => new GlassPaneBlock(Identifier, true, false, false, true, true),
            7035 => new GlassPaneBlock(Identifier, true, false, false, true, false),
            7036 => new GlassPaneBlock(Identifier, true, false, false, false, true),
            7037 => new GlassPaneBlock(Identifier, true, false, false, false, false),
            7038 => new GlassPaneBlock(Identifier, false, true, true, true, true),
            7039 => new GlassPaneBlock(Identifier, false, true, true, true, false),
            7040 => new GlassPaneBlock(Identifier, false, true, true, false, true),
            7041 => new GlassPaneBlock(Identifier, false, true, true, false, false),
            7042 => new GlassPaneBlock(Identifier, false, true, false, true, true),
            7043 => new GlassPaneBlock(Identifier, false, true, false, true, false),
            7044 => new GlassPaneBlock(Identifier, false, true, false, false, true),
            7045 => new GlassPaneBlock(Identifier, false, true, false, false, false),
            7046 => new GlassPaneBlock(Identifier, false, false, true, true, true),
            7047 => new GlassPaneBlock(Identifier, false, false, true, true, false),
            7048 => new GlassPaneBlock(Identifier, false, false, true, false, true),
            7049 => new GlassPaneBlock(Identifier, false, false, true, false, false),
            7050 => new GlassPaneBlock(Identifier, false, false, false, true, true),
            7051 => new GlassPaneBlock(Identifier, false, false, false, true, false),
            7052 => new GlassPaneBlock(Identifier, false, false, false, false, true),
            7053 => new GlassPaneBlock(Identifier, false, false, false, false, false),
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
    
}
