using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperBarsBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_bar";
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
    public Identifier? Item => "minecraft:exposed_copper_bars";
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
    public string TranslationKey => "block.minecraft.exposed_copper_bars";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8022,
                                false => 8023,
                            },
                            false => West switch {
                                true => 8024,
                                false => 8025,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8026,
                                false => 8027,
                            },
                            false => West switch {
                                true => 8028,
                                false => 8029,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8030,
                                false => 8031,
                            },
                            false => West switch {
                                true => 8032,
                                false => 8033,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8034,
                                false => 8035,
                            },
                            false => West switch {
                                true => 8036,
                                false => 8037,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8038,
                                false => 8039,
                            },
                            false => West switch {
                                true => 8040,
                                false => 8041,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8042,
                                false => 8043,
                            },
                            false => West switch {
                                true => 8044,
                                false => 8045,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 8046,
                                false => 8047,
                            },
                            false => West switch {
                                true => 8048,
                                false => 8049,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 8050,
                                false => 8051,
                            },
                            false => West switch {
                                true => 8052,
                                false => 8053,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8022 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, true),
            8023 => new ExposedCopperBarsBlock(Identifier, true, true, true, true, false),
            8024 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, true),
            8025 => new ExposedCopperBarsBlock(Identifier, true, true, true, false, false),
            8026 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, true),
            8027 => new ExposedCopperBarsBlock(Identifier, true, true, false, true, false),
            8028 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, true),
            8029 => new ExposedCopperBarsBlock(Identifier, true, true, false, false, false),
            8030 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, true),
            8031 => new ExposedCopperBarsBlock(Identifier, true, false, true, true, false),
            8032 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, true),
            8033 => new ExposedCopperBarsBlock(Identifier, true, false, true, false, false),
            8034 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, true),
            8035 => new ExposedCopperBarsBlock(Identifier, true, false, false, true, false),
            8036 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, true),
            8037 => new ExposedCopperBarsBlock(Identifier, true, false, false, false, false),
            8038 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, true),
            8039 => new ExposedCopperBarsBlock(Identifier, false, true, true, true, false),
            8040 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, true),
            8041 => new ExposedCopperBarsBlock(Identifier, false, true, true, false, false),
            8042 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, true),
            8043 => new ExposedCopperBarsBlock(Identifier, false, true, false, true, false),
            8044 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, true),
            8045 => new ExposedCopperBarsBlock(Identifier, false, true, false, false, false),
            8046 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, true),
            8047 => new ExposedCopperBarsBlock(Identifier, false, false, true, true, false),
            8048 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, true),
            8049 => new ExposedCopperBarsBlock(Identifier, false, false, true, false, false),
            8050 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, true),
            8051 => new ExposedCopperBarsBlock(Identifier, false, false, false, true, false),
            8052 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, true),
            8053 => new ExposedCopperBarsBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
