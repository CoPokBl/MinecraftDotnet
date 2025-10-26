using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 346;
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7949,
                                false => 7950,
                            },
                            false => West switch {
                                true => 7951,
                                false => 7952,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7953,
                                false => 7954,
                            },
                            false => West switch {
                                true => 7955,
                                false => 7956,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7957,
                                false => 7958,
                            },
                            false => West switch {
                                true => 7959,
                                false => 7960,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7961,
                                false => 7962,
                            },
                            false => West switch {
                                true => 7963,
                                false => 7964,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7965,
                                false => 7966,
                            },
                            false => West switch {
                                true => 7967,
                                false => 7968,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7969,
                                false => 7970,
                            },
                            false => West switch {
                                true => 7971,
                                false => 7972,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 7973,
                                false => 7974,
                            },
                            false => West switch {
                                true => 7975,
                                false => 7976,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 7977,
                                false => 7978,
                            },
                            false => West switch {
                                true => 7979,
                                false => 7980,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7949 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, true, true),
            7950 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, true, false),
            7951 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, false, true),
            7952 => new WaxedExposedCopperBarsBlock(Identifier, true, true, true, false, false),
            7953 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, true, true),
            7954 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, true, false),
            7955 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, false, true),
            7956 => new WaxedExposedCopperBarsBlock(Identifier, true, true, false, false, false),
            7957 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, true, true),
            7958 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, true, false),
            7959 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, false, true),
            7960 => new WaxedExposedCopperBarsBlock(Identifier, true, false, true, false, false),
            7961 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, true, true),
            7962 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, true, false),
            7963 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, false, true),
            7964 => new WaxedExposedCopperBarsBlock(Identifier, true, false, false, false, false),
            7965 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, true, true),
            7966 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, true, false),
            7967 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, false, true),
            7968 => new WaxedExposedCopperBarsBlock(Identifier, false, true, true, false, false),
            7969 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, true, true),
            7970 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, true, false),
            7971 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, false, true),
            7972 => new WaxedExposedCopperBarsBlock(Identifier, false, true, false, false, false),
            7973 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, true, true),
            7974 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, true, false),
            7975 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, false, true),
            7976 => new WaxedExposedCopperBarsBlock(Identifier, false, false, true, false, false),
            7977 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, true, true),
            7978 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, true, false),
            7979 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, false, true),
            7980 => new WaxedExposedCopperBarsBlock(Identifier, false, false, false, false, false),
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
