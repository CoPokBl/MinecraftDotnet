using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
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
    public Identifier? Item => "minecraft:jungle_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13836,
                                false => 13837,
                            },
                            false => West switch {
                                true => 13838,
                                false => 13839,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13840,
                                false => 13841,
                            },
                            false => West switch {
                                true => 13842,
                                false => 13843,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13844,
                                false => 13845,
                            },
                            false => West switch {
                                true => 13846,
                                false => 13847,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13848,
                                false => 13849,
                            },
                            false => West switch {
                                true => 13850,
                                false => 13851,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13852,
                                false => 13853,
                            },
                            false => West switch {
                                true => 13854,
                                false => 13855,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13856,
                                false => 13857,
                            },
                            false => West switch {
                                true => 13858,
                                false => 13859,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13860,
                                false => 13861,
                            },
                            false => West switch {
                                true => 13862,
                                false => 13863,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13864,
                                false => 13865,
                            },
                            false => West switch {
                                true => 13866,
                                false => 13867,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13836 => new JungleFenceBlock(Identifier, true, true, true, true, true),
            13837 => new JungleFenceBlock(Identifier, true, true, true, true, false),
            13838 => new JungleFenceBlock(Identifier, true, true, true, false, true),
            13839 => new JungleFenceBlock(Identifier, true, true, true, false, false),
            13840 => new JungleFenceBlock(Identifier, true, true, false, true, true),
            13841 => new JungleFenceBlock(Identifier, true, true, false, true, false),
            13842 => new JungleFenceBlock(Identifier, true, true, false, false, true),
            13843 => new JungleFenceBlock(Identifier, true, true, false, false, false),
            13844 => new JungleFenceBlock(Identifier, true, false, true, true, true),
            13845 => new JungleFenceBlock(Identifier, true, false, true, true, false),
            13846 => new JungleFenceBlock(Identifier, true, false, true, false, true),
            13847 => new JungleFenceBlock(Identifier, true, false, true, false, false),
            13848 => new JungleFenceBlock(Identifier, true, false, false, true, true),
            13849 => new JungleFenceBlock(Identifier, true, false, false, true, false),
            13850 => new JungleFenceBlock(Identifier, true, false, false, false, true),
            13851 => new JungleFenceBlock(Identifier, true, false, false, false, false),
            13852 => new JungleFenceBlock(Identifier, false, true, true, true, true),
            13853 => new JungleFenceBlock(Identifier, false, true, true, true, false),
            13854 => new JungleFenceBlock(Identifier, false, true, true, false, true),
            13855 => new JungleFenceBlock(Identifier, false, true, true, false, false),
            13856 => new JungleFenceBlock(Identifier, false, true, false, true, true),
            13857 => new JungleFenceBlock(Identifier, false, true, false, true, false),
            13858 => new JungleFenceBlock(Identifier, false, true, false, false, true),
            13859 => new JungleFenceBlock(Identifier, false, true, false, false, false),
            13860 => new JungleFenceBlock(Identifier, false, false, true, true, true),
            13861 => new JungleFenceBlock(Identifier, false, false, true, true, false),
            13862 => new JungleFenceBlock(Identifier, false, false, true, false, true),
            13863 => new JungleFenceBlock(Identifier, false, false, true, false, false),
            13864 => new JungleFenceBlock(Identifier, false, false, false, true, true),
            13865 => new JungleFenceBlock(Identifier, false, false, false, true, false),
            13866 => new JungleFenceBlock(Identifier, false, false, false, false, true),
            13867 => new JungleFenceBlock(Identifier, false, false, false, false, false),
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
