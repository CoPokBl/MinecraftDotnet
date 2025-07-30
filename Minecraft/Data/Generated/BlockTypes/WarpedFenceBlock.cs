using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public Identifier Category => "minecraft:fence";
    public int ProtocolId => 850;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19771,
                                false => 19772,
                            },
                            false => West switch {
                                true => 19773,
                                false => 19774,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19775,
                                false => 19776,
                            },
                            false => West switch {
                                true => 19777,
                                false => 19778,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19779,
                                false => 19780,
                            },
                            false => West switch {
                                true => 19781,
                                false => 19782,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19783,
                                false => 19784,
                            },
                            false => West switch {
                                true => 19785,
                                false => 19786,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19787,
                                false => 19788,
                            },
                            false => West switch {
                                true => 19789,
                                false => 19790,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19791,
                                false => 19792,
                            },
                            false => West switch {
                                true => 19793,
                                false => 19794,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 19795,
                                false => 19796,
                            },
                            false => West switch {
                                true => 19797,
                                false => 19798,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 19799,
                                false => 19800,
                            },
                            false => West switch {
                                true => 19801,
                                false => 19802,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19771 => new WarpedFenceBlock(Identifier, true, true, true, true, true),
            19772 => new WarpedFenceBlock(Identifier, true, true, true, true, false),
            19773 => new WarpedFenceBlock(Identifier, true, true, true, false, true),
            19774 => new WarpedFenceBlock(Identifier, true, true, true, false, false),
            19775 => new WarpedFenceBlock(Identifier, true, true, false, true, true),
            19776 => new WarpedFenceBlock(Identifier, true, true, false, true, false),
            19777 => new WarpedFenceBlock(Identifier, true, true, false, false, true),
            19778 => new WarpedFenceBlock(Identifier, true, true, false, false, false),
            19779 => new WarpedFenceBlock(Identifier, true, false, true, true, true),
            19780 => new WarpedFenceBlock(Identifier, true, false, true, true, false),
            19781 => new WarpedFenceBlock(Identifier, true, false, true, false, true),
            19782 => new WarpedFenceBlock(Identifier, true, false, true, false, false),
            19783 => new WarpedFenceBlock(Identifier, true, false, false, true, true),
            19784 => new WarpedFenceBlock(Identifier, true, false, false, true, false),
            19785 => new WarpedFenceBlock(Identifier, true, false, false, false, true),
            19786 => new WarpedFenceBlock(Identifier, true, false, false, false, false),
            19787 => new WarpedFenceBlock(Identifier, false, true, true, true, true),
            19788 => new WarpedFenceBlock(Identifier, false, true, true, true, false),
            19789 => new WarpedFenceBlock(Identifier, false, true, true, false, true),
            19790 => new WarpedFenceBlock(Identifier, false, true, true, false, false),
            19791 => new WarpedFenceBlock(Identifier, false, true, false, true, true),
            19792 => new WarpedFenceBlock(Identifier, false, true, false, true, false),
            19793 => new WarpedFenceBlock(Identifier, false, true, false, false, true),
            19794 => new WarpedFenceBlock(Identifier, false, true, false, false, false),
            19795 => new WarpedFenceBlock(Identifier, false, false, true, true, true),
            19796 => new WarpedFenceBlock(Identifier, false, false, true, true, false),
            19797 => new WarpedFenceBlock(Identifier, false, false, true, false, true),
            19798 => new WarpedFenceBlock(Identifier, false, false, true, false, false),
            19799 => new WarpedFenceBlock(Identifier, false, false, false, true, true),
            19800 => new WarpedFenceBlock(Identifier, false, false, false, true, false),
            19801 => new WarpedFenceBlock(Identifier, false, false, false, false, true),
            19802 => new WarpedFenceBlock(Identifier, false, false, false, false, false),
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
