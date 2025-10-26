using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_bar";
    public int ProtocolId => 342;
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
    public Identifier? Item => "minecraft:exposed_copper_bars";
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
    public string TranslationKey => "block.minecraft.exposed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7821,
                                false => 7822,
                            },
                            false => West switch {
                                true => 7823,
                                false => 7824,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7825,
                                false => 7826,
                            },
                            false => West switch {
                                true => 7827,
                                false => 7828,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7829,
                                false => 7830,
                            },
                            false => West switch {
                                true => 7831,
                                false => 7832,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7833,
                                false => 7834,
                            },
                            false => West switch {
                                true => 7835,
                                false => 7836,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7837,
                                false => 7838,
                            },
                            false => West switch {
                                true => 7839,
                                false => 7840,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7841,
                                false => 7842,
                            },
                            false => West switch {
                                true => 7843,
                                false => 7844,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7845,
                                false => 7846,
                            },
                            false => West switch {
                                true => 7847,
                                false => 7848,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7849,
                                false => 7850,
                            },
                            false => West switch {
                                true => 7851,
                                false => 7852,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7821 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, true),
            7822 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, false),
            7823 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, true),
            7824 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, false),
            7825 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, true),
            7826 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, false),
            7827 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, true),
            7828 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, false),
            7829 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, true),
            7830 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, false),
            7831 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, true),
            7832 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, false),
            7833 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, true),
            7834 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, false),
            7835 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, true),
            7836 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, false),
            7837 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, true),
            7838 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, false),
            7839 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, true),
            7840 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, false),
            7841 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, true),
            7842 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, false),
            7843 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, true),
            7844 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, false),
            7845 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, true),
            7846 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, false),
            7847 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, true),
            7848 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, false),
            7849 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, true),
            7850 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, false),
            7851 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, true),
            7852 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, false),
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
