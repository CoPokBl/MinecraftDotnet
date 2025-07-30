using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 610;
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
    public Identifier? Item => "minecraft:dark_oak_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12653,
                                false => 12654,
                            },
                            false => West switch {
                                true => 12655,
                                false => 12656,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12657,
                                false => 12658,
                            },
                            false => West switch {
                                true => 12659,
                                false => 12660,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12661,
                                false => 12662,
                            },
                            false => West switch {
                                true => 12663,
                                false => 12664,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12665,
                                false => 12666,
                            },
                            false => West switch {
                                true => 12667,
                                false => 12668,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12669,
                                false => 12670,
                            },
                            false => West switch {
                                true => 12671,
                                false => 12672,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12673,
                                false => 12674,
                            },
                            false => West switch {
                                true => 12675,
                                false => 12676,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12677,
                                false => 12678,
                            },
                            false => West switch {
                                true => 12679,
                                false => 12680,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12681,
                                false => 12682,
                            },
                            false => West switch {
                                true => 12683,
                                false => 12684,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12653 => new DarkOakFenceBlock(Identifier, true, true, true, true, true),
            12654 => new DarkOakFenceBlock(Identifier, true, true, true, true, false),
            12655 => new DarkOakFenceBlock(Identifier, true, true, true, false, true),
            12656 => new DarkOakFenceBlock(Identifier, true, true, true, false, false),
            12657 => new DarkOakFenceBlock(Identifier, true, true, false, true, true),
            12658 => new DarkOakFenceBlock(Identifier, true, true, false, true, false),
            12659 => new DarkOakFenceBlock(Identifier, true, true, false, false, true),
            12660 => new DarkOakFenceBlock(Identifier, true, true, false, false, false),
            12661 => new DarkOakFenceBlock(Identifier, true, false, true, true, true),
            12662 => new DarkOakFenceBlock(Identifier, true, false, true, true, false),
            12663 => new DarkOakFenceBlock(Identifier, true, false, true, false, true),
            12664 => new DarkOakFenceBlock(Identifier, true, false, true, false, false),
            12665 => new DarkOakFenceBlock(Identifier, true, false, false, true, true),
            12666 => new DarkOakFenceBlock(Identifier, true, false, false, true, false),
            12667 => new DarkOakFenceBlock(Identifier, true, false, false, false, true),
            12668 => new DarkOakFenceBlock(Identifier, true, false, false, false, false),
            12669 => new DarkOakFenceBlock(Identifier, false, true, true, true, true),
            12670 => new DarkOakFenceBlock(Identifier, false, true, true, true, false),
            12671 => new DarkOakFenceBlock(Identifier, false, true, true, false, true),
            12672 => new DarkOakFenceBlock(Identifier, false, true, true, false, false),
            12673 => new DarkOakFenceBlock(Identifier, false, true, false, true, true),
            12674 => new DarkOakFenceBlock(Identifier, false, true, false, true, false),
            12675 => new DarkOakFenceBlock(Identifier, false, true, false, false, true),
            12676 => new DarkOakFenceBlock(Identifier, false, true, false, false, false),
            12677 => new DarkOakFenceBlock(Identifier, false, false, true, true, true),
            12678 => new DarkOakFenceBlock(Identifier, false, false, true, true, false),
            12679 => new DarkOakFenceBlock(Identifier, false, false, true, false, true),
            12680 => new DarkOakFenceBlock(Identifier, false, false, true, false, false),
            12681 => new DarkOakFenceBlock(Identifier, false, false, false, true, true),
            12682 => new DarkOakFenceBlock(Identifier, false, false, false, true, false),
            12683 => new DarkOakFenceBlock(Identifier, false, false, false, false, true),
            12684 => new DarkOakFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
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
