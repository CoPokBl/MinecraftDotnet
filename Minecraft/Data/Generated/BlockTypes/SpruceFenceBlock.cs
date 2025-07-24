using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 605;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:spruce_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12493,
                                false => 12494,
                            },
                            false => West switch {
                                true => 12495,
                                false => 12496,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12497,
                                false => 12498,
                            },
                            false => West switch {
                                true => 12499,
                                false => 12500,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12501,
                                false => 12502,
                            },
                            false => West switch {
                                true => 12503,
                                false => 12504,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12505,
                                false => 12506,
                            },
                            false => West switch {
                                true => 12507,
                                false => 12508,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12509,
                                false => 12510,
                            },
                            false => West switch {
                                true => 12511,
                                false => 12512,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12513,
                                false => 12514,
                            },
                            false => West switch {
                                true => 12515,
                                false => 12516,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12517,
                                false => 12518,
                            },
                            false => West switch {
                                true => 12519,
                                false => 12520,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12521,
                                false => 12522,
                            },
                            false => West switch {
                                true => 12523,
                                false => 12524,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12493 => new SpruceFenceBlock(Identifier, true, true, true, true, true),
            12494 => new SpruceFenceBlock(Identifier, true, true, true, true, false),
            12495 => new SpruceFenceBlock(Identifier, true, true, true, false, true),
            12496 => new SpruceFenceBlock(Identifier, true, true, true, false, false),
            12497 => new SpruceFenceBlock(Identifier, true, true, false, true, true),
            12498 => new SpruceFenceBlock(Identifier, true, true, false, true, false),
            12499 => new SpruceFenceBlock(Identifier, true, true, false, false, true),
            12500 => new SpruceFenceBlock(Identifier, true, true, false, false, false),
            12501 => new SpruceFenceBlock(Identifier, true, false, true, true, true),
            12502 => new SpruceFenceBlock(Identifier, true, false, true, true, false),
            12503 => new SpruceFenceBlock(Identifier, true, false, true, false, true),
            12504 => new SpruceFenceBlock(Identifier, true, false, true, false, false),
            12505 => new SpruceFenceBlock(Identifier, true, false, false, true, true),
            12506 => new SpruceFenceBlock(Identifier, true, false, false, true, false),
            12507 => new SpruceFenceBlock(Identifier, true, false, false, false, true),
            12508 => new SpruceFenceBlock(Identifier, true, false, false, false, false),
            12509 => new SpruceFenceBlock(Identifier, false, true, true, true, true),
            12510 => new SpruceFenceBlock(Identifier, false, true, true, true, false),
            12511 => new SpruceFenceBlock(Identifier, false, true, true, false, true),
            12512 => new SpruceFenceBlock(Identifier, false, true, true, false, false),
            12513 => new SpruceFenceBlock(Identifier, false, true, false, true, true),
            12514 => new SpruceFenceBlock(Identifier, false, true, false, true, false),
            12515 => new SpruceFenceBlock(Identifier, false, true, false, false, true),
            12516 => new SpruceFenceBlock(Identifier, false, true, false, false, false),
            12517 => new SpruceFenceBlock(Identifier, false, false, true, true, true),
            12518 => new SpruceFenceBlock(Identifier, false, false, true, true, false),
            12519 => new SpruceFenceBlock(Identifier, false, false, true, false, true),
            12520 => new SpruceFenceBlock(Identifier, false, false, true, false, false),
            12521 => new SpruceFenceBlock(Identifier, false, false, false, true, true),
            12522 => new SpruceFenceBlock(Identifier, false, false, false, true, false),
            12523 => new SpruceFenceBlock(Identifier, false, false, false, false, true),
            12524 => new SpruceFenceBlock(Identifier, false, false, false, false, false),
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
