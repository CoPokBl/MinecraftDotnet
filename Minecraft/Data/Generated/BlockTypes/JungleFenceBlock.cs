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
    public int ProtocolId => 637;
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
                                true => 13634,
                                false => 13635,
                            },
                            false => West switch {
                                true => 13636,
                                false => 13637,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13638,
                                false => 13639,
                            },
                            false => West switch {
                                true => 13640,
                                false => 13641,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13642,
                                false => 13643,
                            },
                            false => West switch {
                                true => 13644,
                                false => 13645,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13646,
                                false => 13647,
                            },
                            false => West switch {
                                true => 13648,
                                false => 13649,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13650,
                                false => 13651,
                            },
                            false => West switch {
                                true => 13652,
                                false => 13653,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13654,
                                false => 13655,
                            },
                            false => West switch {
                                true => 13656,
                                false => 13657,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13658,
                                false => 13659,
                            },
                            false => West switch {
                                true => 13660,
                                false => 13661,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13662,
                                false => 13663,
                            },
                            false => West switch {
                                true => 13664,
                                false => 13665,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13634 => new JungleFenceBlock(Identifier, true, true, true, true, true),
            13635 => new JungleFenceBlock(Identifier, true, true, true, true, false),
            13636 => new JungleFenceBlock(Identifier, true, true, true, false, true),
            13637 => new JungleFenceBlock(Identifier, true, true, true, false, false),
            13638 => new JungleFenceBlock(Identifier, true, true, false, true, true),
            13639 => new JungleFenceBlock(Identifier, true, true, false, true, false),
            13640 => new JungleFenceBlock(Identifier, true, true, false, false, true),
            13641 => new JungleFenceBlock(Identifier, true, true, false, false, false),
            13642 => new JungleFenceBlock(Identifier, true, false, true, true, true),
            13643 => new JungleFenceBlock(Identifier, true, false, true, true, false),
            13644 => new JungleFenceBlock(Identifier, true, false, true, false, true),
            13645 => new JungleFenceBlock(Identifier, true, false, true, false, false),
            13646 => new JungleFenceBlock(Identifier, true, false, false, true, true),
            13647 => new JungleFenceBlock(Identifier, true, false, false, true, false),
            13648 => new JungleFenceBlock(Identifier, true, false, false, false, true),
            13649 => new JungleFenceBlock(Identifier, true, false, false, false, false),
            13650 => new JungleFenceBlock(Identifier, false, true, true, true, true),
            13651 => new JungleFenceBlock(Identifier, false, true, true, true, false),
            13652 => new JungleFenceBlock(Identifier, false, true, true, false, true),
            13653 => new JungleFenceBlock(Identifier, false, true, true, false, false),
            13654 => new JungleFenceBlock(Identifier, false, true, false, true, true),
            13655 => new JungleFenceBlock(Identifier, false, true, false, true, false),
            13656 => new JungleFenceBlock(Identifier, false, true, false, false, true),
            13657 => new JungleFenceBlock(Identifier, false, true, false, false, false),
            13658 => new JungleFenceBlock(Identifier, false, false, true, true, true),
            13659 => new JungleFenceBlock(Identifier, false, false, true, true, false),
            13660 => new JungleFenceBlock(Identifier, false, false, true, false, true),
            13661 => new JungleFenceBlock(Identifier, false, false, true, false, false),
            13662 => new JungleFenceBlock(Identifier, false, false, false, true, true),
            13663 => new JungleFenceBlock(Identifier, false, false, false, true, false),
            13664 => new JungleFenceBlock(Identifier, false, false, false, false, true),
            13665 => new JungleFenceBlock(Identifier, false, false, false, false, false),
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
