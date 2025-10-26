using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_bar";
    public int ProtocolId => 341;
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
    public Identifier? Item => "minecraft:copper_bars";
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
    public string TranslationKey => "block.minecraft.copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7789,
                                false => 7790,
                            },
                            false => West switch {
                                true => 7791,
                                false => 7792,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7793,
                                false => 7794,
                            },
                            false => West switch {
                                true => 7795,
                                false => 7796,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7797,
                                false => 7798,
                            },
                            false => West switch {
                                true => 7799,
                                false => 7800,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7801,
                                false => 7802,
                            },
                            false => West switch {
                                true => 7803,
                                false => 7804,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7805,
                                false => 7806,
                            },
                            false => West switch {
                                true => 7807,
                                false => 7808,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7809,
                                false => 7810,
                            },
                            false => West switch {
                                true => 7811,
                                false => 7812,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7813,
                                false => 7814,
                            },
                            false => West switch {
                                true => 7815,
                                false => 7816,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7817,
                                false => 7818,
                            },
                            false => West switch {
                                true => 7819,
                                false => 7820,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7789 => new CopperBarsBlock(Identifier, true, true, true, true, true),
            7790 => new CopperBarsBlock(Identifier, true, true, true, true, false),
            7791 => new CopperBarsBlock(Identifier, true, true, true, false, true),
            7792 => new CopperBarsBlock(Identifier, true, true, true, false, false),
            7793 => new CopperBarsBlock(Identifier, true, true, false, true, true),
            7794 => new CopperBarsBlock(Identifier, true, true, false, true, false),
            7795 => new CopperBarsBlock(Identifier, true, true, false, false, true),
            7796 => new CopperBarsBlock(Identifier, true, true, false, false, false),
            7797 => new CopperBarsBlock(Identifier, true, false, true, true, true),
            7798 => new CopperBarsBlock(Identifier, true, false, true, true, false),
            7799 => new CopperBarsBlock(Identifier, true, false, true, false, true),
            7800 => new CopperBarsBlock(Identifier, true, false, true, false, false),
            7801 => new CopperBarsBlock(Identifier, true, false, false, true, true),
            7802 => new CopperBarsBlock(Identifier, true, false, false, true, false),
            7803 => new CopperBarsBlock(Identifier, true, false, false, false, true),
            7804 => new CopperBarsBlock(Identifier, true, false, false, false, false),
            7805 => new CopperBarsBlock(Identifier, false, true, true, true, true),
            7806 => new CopperBarsBlock(Identifier, false, true, true, true, false),
            7807 => new CopperBarsBlock(Identifier, false, true, true, false, true),
            7808 => new CopperBarsBlock(Identifier, false, true, true, false, false),
            7809 => new CopperBarsBlock(Identifier, false, true, false, true, true),
            7810 => new CopperBarsBlock(Identifier, false, true, false, true, false),
            7811 => new CopperBarsBlock(Identifier, false, true, false, false, true),
            7812 => new CopperBarsBlock(Identifier, false, true, false, false, false),
            7813 => new CopperBarsBlock(Identifier, false, false, true, true, true),
            7814 => new CopperBarsBlock(Identifier, false, false, true, true, false),
            7815 => new CopperBarsBlock(Identifier, false, false, true, false, true),
            7816 => new CopperBarsBlock(Identifier, false, false, true, false, false),
            7817 => new CopperBarsBlock(Identifier, false, false, false, true, true),
            7818 => new CopperBarsBlock(Identifier, false, false, false, true, false),
            7819 => new CopperBarsBlock(Identifier, false, false, false, false, true),
            7820 => new CopperBarsBlock(Identifier, false, false, false, false, false),
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
