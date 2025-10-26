using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 642;
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
    public Identifier? Item => "minecraft:mangrove_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13794,
                                false => 13795,
                            },
                            false => West switch {
                                true => 13796,
                                false => 13797,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13798,
                                false => 13799,
                            },
                            false => West switch {
                                true => 13800,
                                false => 13801,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13802,
                                false => 13803,
                            },
                            false => West switch {
                                true => 13804,
                                false => 13805,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13806,
                                false => 13807,
                            },
                            false => West switch {
                                true => 13808,
                                false => 13809,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13810,
                                false => 13811,
                            },
                            false => West switch {
                                true => 13812,
                                false => 13813,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13814,
                                false => 13815,
                            },
                            false => West switch {
                                true => 13816,
                                false => 13817,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13818,
                                false => 13819,
                            },
                            false => West switch {
                                true => 13820,
                                false => 13821,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13822,
                                false => 13823,
                            },
                            false => West switch {
                                true => 13824,
                                false => 13825,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13794 => new MangroveFenceBlock(Identifier, true, true, true, true, true),
            13795 => new MangroveFenceBlock(Identifier, true, true, true, true, false),
            13796 => new MangroveFenceBlock(Identifier, true, true, true, false, true),
            13797 => new MangroveFenceBlock(Identifier, true, true, true, false, false),
            13798 => new MangroveFenceBlock(Identifier, true, true, false, true, true),
            13799 => new MangroveFenceBlock(Identifier, true, true, false, true, false),
            13800 => new MangroveFenceBlock(Identifier, true, true, false, false, true),
            13801 => new MangroveFenceBlock(Identifier, true, true, false, false, false),
            13802 => new MangroveFenceBlock(Identifier, true, false, true, true, true),
            13803 => new MangroveFenceBlock(Identifier, true, false, true, true, false),
            13804 => new MangroveFenceBlock(Identifier, true, false, true, false, true),
            13805 => new MangroveFenceBlock(Identifier, true, false, true, false, false),
            13806 => new MangroveFenceBlock(Identifier, true, false, false, true, true),
            13807 => new MangroveFenceBlock(Identifier, true, false, false, true, false),
            13808 => new MangroveFenceBlock(Identifier, true, false, false, false, true),
            13809 => new MangroveFenceBlock(Identifier, true, false, false, false, false),
            13810 => new MangroveFenceBlock(Identifier, false, true, true, true, true),
            13811 => new MangroveFenceBlock(Identifier, false, true, true, true, false),
            13812 => new MangroveFenceBlock(Identifier, false, true, true, false, true),
            13813 => new MangroveFenceBlock(Identifier, false, true, true, false, false),
            13814 => new MangroveFenceBlock(Identifier, false, true, false, true, true),
            13815 => new MangroveFenceBlock(Identifier, false, true, false, true, false),
            13816 => new MangroveFenceBlock(Identifier, false, true, false, false, true),
            13817 => new MangroveFenceBlock(Identifier, false, true, false, false, false),
            13818 => new MangroveFenceBlock(Identifier, false, false, true, true, true),
            13819 => new MangroveFenceBlock(Identifier, false, false, true, true, false),
            13820 => new MangroveFenceBlock(Identifier, false, false, true, false, true),
            13821 => new MangroveFenceBlock(Identifier, false, false, true, false, false),
            13822 => new MangroveFenceBlock(Identifier, false, false, false, true, true),
            13823 => new MangroveFenceBlock(Identifier, false, false, false, true, false),
            13824 => new MangroveFenceBlock(Identifier, false, false, false, false, true),
            13825 => new MangroveFenceBlock(Identifier, false, false, false, false, false),
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
