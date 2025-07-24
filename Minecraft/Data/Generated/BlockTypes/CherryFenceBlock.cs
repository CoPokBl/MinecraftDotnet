using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 609;
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12621,
                                false => 12622,
                            },
                            false => West switch {
                                true => 12623,
                                false => 12624,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12625,
                                false => 12626,
                            },
                            false => West switch {
                                true => 12627,
                                false => 12628,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12629,
                                false => 12630,
                            },
                            false => West switch {
                                true => 12631,
                                false => 12632,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12633,
                                false => 12634,
                            },
                            false => West switch {
                                true => 12635,
                                false => 12636,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12637,
                                false => 12638,
                            },
                            false => West switch {
                                true => 12639,
                                false => 12640,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12641,
                                false => 12642,
                            },
                            false => West switch {
                                true => 12643,
                                false => 12644,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12645,
                                false => 12646,
                            },
                            false => West switch {
                                true => 12647,
                                false => 12648,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12649,
                                false => 12650,
                            },
                            false => West switch {
                                true => 12651,
                                false => 12652,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12621 => new CherryFenceBlock(Identifier, true, true, true, true, true),
            12622 => new CherryFenceBlock(Identifier, true, true, true, true, false),
            12623 => new CherryFenceBlock(Identifier, true, true, true, false, true),
            12624 => new CherryFenceBlock(Identifier, true, true, true, false, false),
            12625 => new CherryFenceBlock(Identifier, true, true, false, true, true),
            12626 => new CherryFenceBlock(Identifier, true, true, false, true, false),
            12627 => new CherryFenceBlock(Identifier, true, true, false, false, true),
            12628 => new CherryFenceBlock(Identifier, true, true, false, false, false),
            12629 => new CherryFenceBlock(Identifier, true, false, true, true, true),
            12630 => new CherryFenceBlock(Identifier, true, false, true, true, false),
            12631 => new CherryFenceBlock(Identifier, true, false, true, false, true),
            12632 => new CherryFenceBlock(Identifier, true, false, true, false, false),
            12633 => new CherryFenceBlock(Identifier, true, false, false, true, true),
            12634 => new CherryFenceBlock(Identifier, true, false, false, true, false),
            12635 => new CherryFenceBlock(Identifier, true, false, false, false, true),
            12636 => new CherryFenceBlock(Identifier, true, false, false, false, false),
            12637 => new CherryFenceBlock(Identifier, false, true, true, true, true),
            12638 => new CherryFenceBlock(Identifier, false, true, true, true, false),
            12639 => new CherryFenceBlock(Identifier, false, true, true, false, true),
            12640 => new CherryFenceBlock(Identifier, false, true, true, false, false),
            12641 => new CherryFenceBlock(Identifier, false, true, false, true, true),
            12642 => new CherryFenceBlock(Identifier, false, true, false, true, false),
            12643 => new CherryFenceBlock(Identifier, false, true, false, false, true),
            12644 => new CherryFenceBlock(Identifier, false, true, false, false, false),
            12645 => new CherryFenceBlock(Identifier, false, false, true, true, true),
            12646 => new CherryFenceBlock(Identifier, false, false, true, true, false),
            12647 => new CherryFenceBlock(Identifier, false, false, true, false, true),
            12648 => new CherryFenceBlock(Identifier, false, false, true, false, false),
            12649 => new CherryFenceBlock(Identifier, false, false, false, true, true),
            12650 => new CherryFenceBlock(Identifier, false, false, false, true, false),
            12651 => new CherryFenceBlock(Identifier, false, false, false, false, true),
            12652 => new CherryFenceBlock(Identifier, false, false, false, false, false),
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
