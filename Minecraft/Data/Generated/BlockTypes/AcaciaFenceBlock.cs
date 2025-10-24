using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 638;
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
    public Identifier? Item => "minecraft:acacia_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13666,
                                false => 13667,
                            },
                            false => West switch {
                                true => 13668,
                                false => 13669,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13670,
                                false => 13671,
                            },
                            false => West switch {
                                true => 13672,
                                false => 13673,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13674,
                                false => 13675,
                            },
                            false => West switch {
                                true => 13676,
                                false => 13677,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13678,
                                false => 13679,
                            },
                            false => West switch {
                                true => 13680,
                                false => 13681,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13682,
                                false => 13683,
                            },
                            false => West switch {
                                true => 13684,
                                false => 13685,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13686,
                                false => 13687,
                            },
                            false => West switch {
                                true => 13688,
                                false => 13689,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13690,
                                false => 13691,
                            },
                            false => West switch {
                                true => 13692,
                                false => 13693,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13694,
                                false => 13695,
                            },
                            false => West switch {
                                true => 13696,
                                false => 13697,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13666 => new AcaciaFenceBlock(Identifier, true, true, true, true, true),
            13667 => new AcaciaFenceBlock(Identifier, true, true, true, true, false),
            13668 => new AcaciaFenceBlock(Identifier, true, true, true, false, true),
            13669 => new AcaciaFenceBlock(Identifier, true, true, true, false, false),
            13670 => new AcaciaFenceBlock(Identifier, true, true, false, true, true),
            13671 => new AcaciaFenceBlock(Identifier, true, true, false, true, false),
            13672 => new AcaciaFenceBlock(Identifier, true, true, false, false, true),
            13673 => new AcaciaFenceBlock(Identifier, true, true, false, false, false),
            13674 => new AcaciaFenceBlock(Identifier, true, false, true, true, true),
            13675 => new AcaciaFenceBlock(Identifier, true, false, true, true, false),
            13676 => new AcaciaFenceBlock(Identifier, true, false, true, false, true),
            13677 => new AcaciaFenceBlock(Identifier, true, false, true, false, false),
            13678 => new AcaciaFenceBlock(Identifier, true, false, false, true, true),
            13679 => new AcaciaFenceBlock(Identifier, true, false, false, true, false),
            13680 => new AcaciaFenceBlock(Identifier, true, false, false, false, true),
            13681 => new AcaciaFenceBlock(Identifier, true, false, false, false, false),
            13682 => new AcaciaFenceBlock(Identifier, false, true, true, true, true),
            13683 => new AcaciaFenceBlock(Identifier, false, true, true, true, false),
            13684 => new AcaciaFenceBlock(Identifier, false, true, true, false, true),
            13685 => new AcaciaFenceBlock(Identifier, false, true, true, false, false),
            13686 => new AcaciaFenceBlock(Identifier, false, true, false, true, true),
            13687 => new AcaciaFenceBlock(Identifier, false, true, false, true, false),
            13688 => new AcaciaFenceBlock(Identifier, false, true, false, false, true),
            13689 => new AcaciaFenceBlock(Identifier, false, true, false, false, false),
            13690 => new AcaciaFenceBlock(Identifier, false, false, true, true, true),
            13691 => new AcaciaFenceBlock(Identifier, false, false, true, true, false),
            13692 => new AcaciaFenceBlock(Identifier, false, false, true, false, true),
            13693 => new AcaciaFenceBlock(Identifier, false, false, true, false, false),
            13694 => new AcaciaFenceBlock(Identifier, false, false, false, true, true),
            13695 => new AcaciaFenceBlock(Identifier, false, false, false, true, false),
            13696 => new AcaciaFenceBlock(Identifier, false, false, false, false, true),
            13697 => new AcaciaFenceBlock(Identifier, false, false, false, false, false),
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
