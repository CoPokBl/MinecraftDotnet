using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 345;
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
    public Identifier? Item => "minecraft:waxed_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7917,
                                false => 7918,
                            },
                            false => West switch {
                                true => 7919,
                                false => 7920,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7921,
                                false => 7922,
                            },
                            false => West switch {
                                true => 7923,
                                false => 7924,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7925,
                                false => 7926,
                            },
                            false => West switch {
                                true => 7927,
                                false => 7928,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7929,
                                false => 7930,
                            },
                            false => West switch {
                                true => 7931,
                                false => 7932,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7933,
                                false => 7934,
                            },
                            false => West switch {
                                true => 7935,
                                false => 7936,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7937,
                                false => 7938,
                            },
                            false => West switch {
                                true => 7939,
                                false => 7940,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7941,
                                false => 7942,
                            },
                            false => West switch {
                                true => 7943,
                                false => 7944,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7945,
                                false => 7946,
                            },
                            false => West switch {
                                true => 7947,
                                false => 7948,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7917 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, true),
            7918 => new WaxedCopperBarsBlock(Identifier, true, true, true, true, false),
            7919 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, true),
            7920 => new WaxedCopperBarsBlock(Identifier, true, true, true, false, false),
            7921 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, true),
            7922 => new WaxedCopperBarsBlock(Identifier, true, true, false, true, false),
            7923 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, true),
            7924 => new WaxedCopperBarsBlock(Identifier, true, true, false, false, false),
            7925 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, true),
            7926 => new WaxedCopperBarsBlock(Identifier, true, false, true, true, false),
            7927 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, true),
            7928 => new WaxedCopperBarsBlock(Identifier, true, false, true, false, false),
            7929 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, true),
            7930 => new WaxedCopperBarsBlock(Identifier, true, false, false, true, false),
            7931 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, true),
            7932 => new WaxedCopperBarsBlock(Identifier, true, false, false, false, false),
            7933 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, true),
            7934 => new WaxedCopperBarsBlock(Identifier, false, true, true, true, false),
            7935 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, true),
            7936 => new WaxedCopperBarsBlock(Identifier, false, true, true, false, false),
            7937 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, true),
            7938 => new WaxedCopperBarsBlock(Identifier, false, true, false, true, false),
            7939 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, true),
            7940 => new WaxedCopperBarsBlock(Identifier, false, true, false, false, false),
            7941 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, true),
            7942 => new WaxedCopperBarsBlock(Identifier, false, false, true, true, false),
            7943 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, true),
            7944 => new WaxedCopperBarsBlock(Identifier, false, false, true, false, false),
            7945 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, true),
            7946 => new WaxedCopperBarsBlock(Identifier, false, false, false, true, false),
            7947 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, true),
            7948 => new WaxedCopperBarsBlock(Identifier, false, false, false, false, false),
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
