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
                                true => 13772,
                                false => 13773,
                            },
                            false => West switch {
                                true => 13774,
                                false => 13775,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13776,
                                false => 13777,
                            },
                            false => West switch {
                                true => 13778,
                                false => 13779,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13780,
                                false => 13781,
                            },
                            false => West switch {
                                true => 13782,
                                false => 13783,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13784,
                                false => 13785,
                            },
                            false => West switch {
                                true => 13786,
                                false => 13787,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13788,
                                false => 13789,
                            },
                            false => West switch {
                                true => 13790,
                                false => 13791,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13792,
                                false => 13793,
                            },
                            false => West switch {
                                true => 13794,
                                false => 13795,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13796,
                                false => 13797,
                            },
                            false => West switch {
                                true => 13798,
                                false => 13799,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13800,
                                false => 13801,
                            },
                            false => West switch {
                                true => 13802,
                                false => 13803,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13772 => new SpruceFenceBlock(Identifier, true, true, true, true, true),
            13773 => new SpruceFenceBlock(Identifier, true, true, true, true, false),
            13774 => new SpruceFenceBlock(Identifier, true, true, true, false, true),
            13775 => new SpruceFenceBlock(Identifier, true, true, true, false, false),
            13776 => new SpruceFenceBlock(Identifier, true, true, false, true, true),
            13777 => new SpruceFenceBlock(Identifier, true, true, false, true, false),
            13778 => new SpruceFenceBlock(Identifier, true, true, false, false, true),
            13779 => new SpruceFenceBlock(Identifier, true, true, false, false, false),
            13780 => new SpruceFenceBlock(Identifier, true, false, true, true, true),
            13781 => new SpruceFenceBlock(Identifier, true, false, true, true, false),
            13782 => new SpruceFenceBlock(Identifier, true, false, true, false, true),
            13783 => new SpruceFenceBlock(Identifier, true, false, true, false, false),
            13784 => new SpruceFenceBlock(Identifier, true, false, false, true, true),
            13785 => new SpruceFenceBlock(Identifier, true, false, false, true, false),
            13786 => new SpruceFenceBlock(Identifier, true, false, false, false, true),
            13787 => new SpruceFenceBlock(Identifier, true, false, false, false, false),
            13788 => new SpruceFenceBlock(Identifier, false, true, true, true, true),
            13789 => new SpruceFenceBlock(Identifier, false, true, true, true, false),
            13790 => new SpruceFenceBlock(Identifier, false, true, true, false, true),
            13791 => new SpruceFenceBlock(Identifier, false, true, true, false, false),
            13792 => new SpruceFenceBlock(Identifier, false, true, false, true, true),
            13793 => new SpruceFenceBlock(Identifier, false, true, false, true, false),
            13794 => new SpruceFenceBlock(Identifier, false, true, false, false, true),
            13795 => new SpruceFenceBlock(Identifier, false, true, false, false, false),
            13796 => new SpruceFenceBlock(Identifier, false, false, true, true, true),
            13797 => new SpruceFenceBlock(Identifier, false, false, true, true, false),
            13798 => new SpruceFenceBlock(Identifier, false, false, true, false, true),
            13799 => new SpruceFenceBlock(Identifier, false, false, true, false, false),
            13800 => new SpruceFenceBlock(Identifier, false, false, false, true, true),
            13801 => new SpruceFenceBlock(Identifier, false, false, false, true, false),
            13802 => new SpruceFenceBlock(Identifier, false, false, false, false, true),
            13803 => new SpruceFenceBlock(Identifier, false, false, false, false, false),
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
