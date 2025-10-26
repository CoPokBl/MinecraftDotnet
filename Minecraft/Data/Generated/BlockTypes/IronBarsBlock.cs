using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 340;
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
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:iron_bars";
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
    public string TranslationKey => "block.minecraft.iron_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7757,
                                false => 7758,
                            },
                            false => West switch {
                                true => 7759,
                                false => 7760,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7761,
                                false => 7762,
                            },
                            false => West switch {
                                true => 7763,
                                false => 7764,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7765,
                                false => 7766,
                            },
                            false => West switch {
                                true => 7767,
                                false => 7768,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7769,
                                false => 7770,
                            },
                            false => West switch {
                                true => 7771,
                                false => 7772,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7773,
                                false => 7774,
                            },
                            false => West switch {
                                true => 7775,
                                false => 7776,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7777,
                                false => 7778,
                            },
                            false => West switch {
                                true => 7779,
                                false => 7780,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7781,
                                false => 7782,
                            },
                            false => West switch {
                                true => 7783,
                                false => 7784,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7785,
                                false => 7786,
                            },
                            false => West switch {
                                true => 7787,
                                false => 7788,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7757 => new IronBarsBlock(Identifier, true, true, true, true, true),
            7758 => new IronBarsBlock(Identifier, true, true, true, true, false),
            7759 => new IronBarsBlock(Identifier, true, true, true, false, true),
            7760 => new IronBarsBlock(Identifier, true, true, true, false, false),
            7761 => new IronBarsBlock(Identifier, true, true, false, true, true),
            7762 => new IronBarsBlock(Identifier, true, true, false, true, false),
            7763 => new IronBarsBlock(Identifier, true, true, false, false, true),
            7764 => new IronBarsBlock(Identifier, true, true, false, false, false),
            7765 => new IronBarsBlock(Identifier, true, false, true, true, true),
            7766 => new IronBarsBlock(Identifier, true, false, true, true, false),
            7767 => new IronBarsBlock(Identifier, true, false, true, false, true),
            7768 => new IronBarsBlock(Identifier, true, false, true, false, false),
            7769 => new IronBarsBlock(Identifier, true, false, false, true, true),
            7770 => new IronBarsBlock(Identifier, true, false, false, true, false),
            7771 => new IronBarsBlock(Identifier, true, false, false, false, true),
            7772 => new IronBarsBlock(Identifier, true, false, false, false, false),
            7773 => new IronBarsBlock(Identifier, false, true, true, true, true),
            7774 => new IronBarsBlock(Identifier, false, true, true, true, false),
            7775 => new IronBarsBlock(Identifier, false, true, true, false, true),
            7776 => new IronBarsBlock(Identifier, false, true, true, false, false),
            7777 => new IronBarsBlock(Identifier, false, true, false, true, true),
            7778 => new IronBarsBlock(Identifier, false, true, false, true, false),
            7779 => new IronBarsBlock(Identifier, false, true, false, false, true),
            7780 => new IronBarsBlock(Identifier, false, true, false, false, false),
            7781 => new IronBarsBlock(Identifier, false, false, true, true, true),
            7782 => new IronBarsBlock(Identifier, false, false, true, true, false),
            7783 => new IronBarsBlock(Identifier, false, false, true, false, true),
            7784 => new IronBarsBlock(Identifier, false, false, true, false, false),
            7785 => new IronBarsBlock(Identifier, false, false, false, true, true),
            7786 => new IronBarsBlock(Identifier, false, false, false, true, false),
            7787 => new IronBarsBlock(Identifier, false, false, false, false, true),
            7788 => new IronBarsBlock(Identifier, false, false, false, false, false),
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
