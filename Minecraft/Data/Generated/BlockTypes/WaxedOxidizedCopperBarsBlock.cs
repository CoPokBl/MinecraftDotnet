using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:iron_bars";
    public int ProtocolId => 348;
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_bars";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8013,
                                false => 8014,
                            },
                            false => West switch {
                                true => 8015,
                                false => 8016,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8017,
                                false => 8018,
                            },
                            false => West switch {
                                true => 8019,
                                false => 8020,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8021,
                                false => 8022,
                            },
                            false => West switch {
                                true => 8023,
                                false => 8024,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8025,
                                false => 8026,
                            },
                            false => West switch {
                                true => 8027,
                                false => 8028,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8029,
                                false => 8030,
                            },
                            false => West switch {
                                true => 8031,
                                false => 8032,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8033,
                                false => 8034,
                            },
                            false => West switch {
                                true => 8035,
                                false => 8036,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8037,
                                false => 8038,
                            },
                            false => West switch {
                                true => 8039,
                                false => 8040,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8041,
                                false => 8042,
                            },
                            false => West switch {
                                true => 8043,
                                false => 8044,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8013 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, true, true),
            8014 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, true, false),
            8015 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, false, true),
            8016 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, true, false, false),
            8017 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, true, true),
            8018 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, true, false),
            8019 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, false, true),
            8020 => new WaxedOxidizedCopperBarsBlock(Identifier, true, true, false, false, false),
            8021 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, true, true),
            8022 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, true, false),
            8023 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, false, true),
            8024 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, true, false, false),
            8025 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, true, true),
            8026 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, true, false),
            8027 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, false, true),
            8028 => new WaxedOxidizedCopperBarsBlock(Identifier, true, false, false, false, false),
            8029 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, true, true),
            8030 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, true, false),
            8031 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, false, true),
            8032 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, true, false, false),
            8033 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, true, true),
            8034 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, true, false),
            8035 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, false, true),
            8036 => new WaxedOxidizedCopperBarsBlock(Identifier, false, true, false, false, false),
            8037 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, true, true),
            8038 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, true, false),
            8039 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, false, true),
            8040 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, true, false, false),
            8041 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, true, true),
            8042 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, true, false),
            8043 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, false, true),
            8044 => new WaxedOxidizedCopperBarsBlock(Identifier, false, false, false, false, false),
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
