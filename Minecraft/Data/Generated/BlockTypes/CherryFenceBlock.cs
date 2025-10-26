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
    public int ProtocolId => 639;
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
                                true => 13698,
                                false => 13699,
                            },
                            false => West switch {
                                true => 13700,
                                false => 13701,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13702,
                                false => 13703,
                            },
                            false => West switch {
                                true => 13704,
                                false => 13705,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13706,
                                false => 13707,
                            },
                            false => West switch {
                                true => 13708,
                                false => 13709,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13710,
                                false => 13711,
                            },
                            false => West switch {
                                true => 13712,
                                false => 13713,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13714,
                                false => 13715,
                            },
                            false => West switch {
                                true => 13716,
                                false => 13717,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13718,
                                false => 13719,
                            },
                            false => West switch {
                                true => 13720,
                                false => 13721,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13722,
                                false => 13723,
                            },
                            false => West switch {
                                true => 13724,
                                false => 13725,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13726,
                                false => 13727,
                            },
                            false => West switch {
                                true => 13728,
                                false => 13729,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13698 => new CherryFenceBlock(Identifier, true, true, true, true, true),
            13699 => new CherryFenceBlock(Identifier, true, true, true, true, false),
            13700 => new CherryFenceBlock(Identifier, true, true, true, false, true),
            13701 => new CherryFenceBlock(Identifier, true, true, true, false, false),
            13702 => new CherryFenceBlock(Identifier, true, true, false, true, true),
            13703 => new CherryFenceBlock(Identifier, true, true, false, true, false),
            13704 => new CherryFenceBlock(Identifier, true, true, false, false, true),
            13705 => new CherryFenceBlock(Identifier, true, true, false, false, false),
            13706 => new CherryFenceBlock(Identifier, true, false, true, true, true),
            13707 => new CherryFenceBlock(Identifier, true, false, true, true, false),
            13708 => new CherryFenceBlock(Identifier, true, false, true, false, true),
            13709 => new CherryFenceBlock(Identifier, true, false, true, false, false),
            13710 => new CherryFenceBlock(Identifier, true, false, false, true, true),
            13711 => new CherryFenceBlock(Identifier, true, false, false, true, false),
            13712 => new CherryFenceBlock(Identifier, true, false, false, false, true),
            13713 => new CherryFenceBlock(Identifier, true, false, false, false, false),
            13714 => new CherryFenceBlock(Identifier, false, true, true, true, true),
            13715 => new CherryFenceBlock(Identifier, false, true, true, true, false),
            13716 => new CherryFenceBlock(Identifier, false, true, true, false, true),
            13717 => new CherryFenceBlock(Identifier, false, true, true, false, false),
            13718 => new CherryFenceBlock(Identifier, false, true, false, true, true),
            13719 => new CherryFenceBlock(Identifier, false, true, false, true, false),
            13720 => new CherryFenceBlock(Identifier, false, true, false, false, true),
            13721 => new CherryFenceBlock(Identifier, false, true, false, false, false),
            13722 => new CherryFenceBlock(Identifier, false, false, true, true, true),
            13723 => new CherryFenceBlock(Identifier, false, false, true, true, false),
            13724 => new CherryFenceBlock(Identifier, false, false, true, false, true),
            13725 => new CherryFenceBlock(Identifier, false, false, true, false, false),
            13726 => new CherryFenceBlock(Identifier, false, false, false, true, true),
            13727 => new CherryFenceBlock(Identifier, false, false, false, true, false),
            13728 => new CherryFenceBlock(Identifier, false, false, false, false, true),
            13729 => new CherryFenceBlock(Identifier, false, false, false, false, false),
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
