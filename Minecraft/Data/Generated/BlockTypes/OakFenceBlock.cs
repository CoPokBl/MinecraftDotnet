using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 283;
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
    public Identifier? Item => "minecraft:oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6764,
                                false => 6765,
                            },
                            false => West switch {
                                true => 6766,
                                false => 6767,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6768,
                                false => 6769,
                            },
                            false => West switch {
                                true => 6770,
                                false => 6771,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6772,
                                false => 6773,
                            },
                            false => West switch {
                                true => 6774,
                                false => 6775,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6776,
                                false => 6777,
                            },
                            false => West switch {
                                true => 6778,
                                false => 6779,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6780,
                                false => 6781,
                            },
                            false => West switch {
                                true => 6782,
                                false => 6783,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6784,
                                false => 6785,
                            },
                            false => West switch {
                                true => 6786,
                                false => 6787,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 6788,
                                false => 6789,
                            },
                            false => West switch {
                                true => 6790,
                                false => 6791,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 6792,
                                false => 6793,
                            },
                            false => West switch {
                                true => 6794,
                                false => 6795,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6764 => new OakFenceBlock(Identifier, true, true, true, true, true),
            6765 => new OakFenceBlock(Identifier, true, true, true, true, false),
            6766 => new OakFenceBlock(Identifier, true, true, true, false, true),
            6767 => new OakFenceBlock(Identifier, true, true, true, false, false),
            6768 => new OakFenceBlock(Identifier, true, true, false, true, true),
            6769 => new OakFenceBlock(Identifier, true, true, false, true, false),
            6770 => new OakFenceBlock(Identifier, true, true, false, false, true),
            6771 => new OakFenceBlock(Identifier, true, true, false, false, false),
            6772 => new OakFenceBlock(Identifier, true, false, true, true, true),
            6773 => new OakFenceBlock(Identifier, true, false, true, true, false),
            6774 => new OakFenceBlock(Identifier, true, false, true, false, true),
            6775 => new OakFenceBlock(Identifier, true, false, true, false, false),
            6776 => new OakFenceBlock(Identifier, true, false, false, true, true),
            6777 => new OakFenceBlock(Identifier, true, false, false, true, false),
            6778 => new OakFenceBlock(Identifier, true, false, false, false, true),
            6779 => new OakFenceBlock(Identifier, true, false, false, false, false),
            6780 => new OakFenceBlock(Identifier, false, true, true, true, true),
            6781 => new OakFenceBlock(Identifier, false, true, true, true, false),
            6782 => new OakFenceBlock(Identifier, false, true, true, false, true),
            6783 => new OakFenceBlock(Identifier, false, true, true, false, false),
            6784 => new OakFenceBlock(Identifier, false, true, false, true, true),
            6785 => new OakFenceBlock(Identifier, false, true, false, true, false),
            6786 => new OakFenceBlock(Identifier, false, true, false, false, true),
            6787 => new OakFenceBlock(Identifier, false, true, false, false, false),
            6788 => new OakFenceBlock(Identifier, false, false, true, true, true),
            6789 => new OakFenceBlock(Identifier, false, false, true, true, false),
            6790 => new OakFenceBlock(Identifier, false, false, true, false, true),
            6791 => new OakFenceBlock(Identifier, false, false, true, false, false),
            6792 => new OakFenceBlock(Identifier, false, false, false, true, true),
            6793 => new OakFenceBlock(Identifier, false, false, false, true, false),
            6794 => new OakFenceBlock(Identifier, false, false, false, false, true),
            6795 => new OakFenceBlock(Identifier, false, false, false, false, false),
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
