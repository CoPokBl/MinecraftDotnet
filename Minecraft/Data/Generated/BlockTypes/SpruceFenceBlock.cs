using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 635;
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
    public Identifier? Item => "minecraft:spruce_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13570,
                                false => 13571,
                            },
                            false => West switch {
                                true => 13572,
                                false => 13573,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13574,
                                false => 13575,
                            },
                            false => West switch {
                                true => 13576,
                                false => 13577,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13578,
                                false => 13579,
                            },
                            false => West switch {
                                true => 13580,
                                false => 13581,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13582,
                                false => 13583,
                            },
                            false => West switch {
                                true => 13584,
                                false => 13585,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13586,
                                false => 13587,
                            },
                            false => West switch {
                                true => 13588,
                                false => 13589,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13590,
                                false => 13591,
                            },
                            false => West switch {
                                true => 13592,
                                false => 13593,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13594,
                                false => 13595,
                            },
                            false => West switch {
                                true => 13596,
                                false => 13597,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 13598,
                                false => 13599,
                            },
                            false => West switch {
                                true => 13600,
                                false => 13601,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13570 => new SpruceFenceBlock(Identifier, true, true, true, true, true),
            13571 => new SpruceFenceBlock(Identifier, true, true, true, true, false),
            13572 => new SpruceFenceBlock(Identifier, true, true, true, false, true),
            13573 => new SpruceFenceBlock(Identifier, true, true, true, false, false),
            13574 => new SpruceFenceBlock(Identifier, true, true, false, true, true),
            13575 => new SpruceFenceBlock(Identifier, true, true, false, true, false),
            13576 => new SpruceFenceBlock(Identifier, true, true, false, false, true),
            13577 => new SpruceFenceBlock(Identifier, true, true, false, false, false),
            13578 => new SpruceFenceBlock(Identifier, true, false, true, true, true),
            13579 => new SpruceFenceBlock(Identifier, true, false, true, true, false),
            13580 => new SpruceFenceBlock(Identifier, true, false, true, false, true),
            13581 => new SpruceFenceBlock(Identifier, true, false, true, false, false),
            13582 => new SpruceFenceBlock(Identifier, true, false, false, true, true),
            13583 => new SpruceFenceBlock(Identifier, true, false, false, true, false),
            13584 => new SpruceFenceBlock(Identifier, true, false, false, false, true),
            13585 => new SpruceFenceBlock(Identifier, true, false, false, false, false),
            13586 => new SpruceFenceBlock(Identifier, false, true, true, true, true),
            13587 => new SpruceFenceBlock(Identifier, false, true, true, true, false),
            13588 => new SpruceFenceBlock(Identifier, false, true, true, false, true),
            13589 => new SpruceFenceBlock(Identifier, false, true, true, false, false),
            13590 => new SpruceFenceBlock(Identifier, false, true, false, true, true),
            13591 => new SpruceFenceBlock(Identifier, false, true, false, true, false),
            13592 => new SpruceFenceBlock(Identifier, false, true, false, false, true),
            13593 => new SpruceFenceBlock(Identifier, false, true, false, false, false),
            13594 => new SpruceFenceBlock(Identifier, false, false, true, true, true),
            13595 => new SpruceFenceBlock(Identifier, false, false, true, true, false),
            13596 => new SpruceFenceBlock(Identifier, false, false, true, false, true),
            13597 => new SpruceFenceBlock(Identifier, false, false, true, false, false),
            13598 => new SpruceFenceBlock(Identifier, false, false, false, true, true),
            13599 => new SpruceFenceBlock(Identifier, false, false, false, true, false),
            13600 => new SpruceFenceBlock(Identifier, false, false, false, false, true),
            13601 => new SpruceFenceBlock(Identifier, false, false, false, false, false),
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
