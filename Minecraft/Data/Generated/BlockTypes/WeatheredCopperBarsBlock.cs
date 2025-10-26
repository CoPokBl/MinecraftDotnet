using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_bar";
    public int ProtocolId => 343;
    public double Hardness => 5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weathered_copper_bars";
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
    public string TranslationKey => "block.minecraft.weathered_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7853,
                                false => 7854,
                            },
                            false => West switch {
                                true => 7855,
                                false => 7856,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7857,
                                false => 7858,
                            },
                            false => West switch {
                                true => 7859,
                                false => 7860,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7861,
                                false => 7862,
                            },
                            false => West switch {
                                true => 7863,
                                false => 7864,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7865,
                                false => 7866,
                            },
                            false => West switch {
                                true => 7867,
                                false => 7868,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7869,
                                false => 7870,
                            },
                            false => West switch {
                                true => 7871,
                                false => 7872,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7873,
                                false => 7874,
                            },
                            false => West switch {
                                true => 7875,
                                false => 7876,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7877,
                                false => 7878,
                            },
                            false => West switch {
                                true => 7879,
                                false => 7880,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7881,
                                false => 7882,
                            },
                            false => West switch {
                                true => 7883,
                                false => 7884,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7853 => new WeatheredCopperBarsBlock(Identifier, true, true, true, true, true),
            7854 => new WeatheredCopperBarsBlock(Identifier, true, true, true, true, false),
            7855 => new WeatheredCopperBarsBlock(Identifier, true, true, true, false, true),
            7856 => new WeatheredCopperBarsBlock(Identifier, true, true, true, false, false),
            7857 => new WeatheredCopperBarsBlock(Identifier, true, true, false, true, true),
            7858 => new WeatheredCopperBarsBlock(Identifier, true, true, false, true, false),
            7859 => new WeatheredCopperBarsBlock(Identifier, true, true, false, false, true),
            7860 => new WeatheredCopperBarsBlock(Identifier, true, true, false, false, false),
            7861 => new WeatheredCopperBarsBlock(Identifier, true, false, true, true, true),
            7862 => new WeatheredCopperBarsBlock(Identifier, true, false, true, true, false),
            7863 => new WeatheredCopperBarsBlock(Identifier, true, false, true, false, true),
            7864 => new WeatheredCopperBarsBlock(Identifier, true, false, true, false, false),
            7865 => new WeatheredCopperBarsBlock(Identifier, true, false, false, true, true),
            7866 => new WeatheredCopperBarsBlock(Identifier, true, false, false, true, false),
            7867 => new WeatheredCopperBarsBlock(Identifier, true, false, false, false, true),
            7868 => new WeatheredCopperBarsBlock(Identifier, true, false, false, false, false),
            7869 => new WeatheredCopperBarsBlock(Identifier, false, true, true, true, true),
            7870 => new WeatheredCopperBarsBlock(Identifier, false, true, true, true, false),
            7871 => new WeatheredCopperBarsBlock(Identifier, false, true, true, false, true),
            7872 => new WeatheredCopperBarsBlock(Identifier, false, true, true, false, false),
            7873 => new WeatheredCopperBarsBlock(Identifier, false, true, false, true, true),
            7874 => new WeatheredCopperBarsBlock(Identifier, false, true, false, true, false),
            7875 => new WeatheredCopperBarsBlock(Identifier, false, true, false, false, true),
            7876 => new WeatheredCopperBarsBlock(Identifier, false, true, false, false, false),
            7877 => new WeatheredCopperBarsBlock(Identifier, false, false, true, true, true),
            7878 => new WeatheredCopperBarsBlock(Identifier, false, false, true, true, false),
            7879 => new WeatheredCopperBarsBlock(Identifier, false, false, true, false, true),
            7880 => new WeatheredCopperBarsBlock(Identifier, false, false, true, false, false),
            7881 => new WeatheredCopperBarsBlock(Identifier, false, false, false, true, true),
            7882 => new WeatheredCopperBarsBlock(Identifier, false, false, false, true, false),
            7883 => new WeatheredCopperBarsBlock(Identifier, false, false, false, false, true),
            7884 => new WeatheredCopperBarsBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
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
