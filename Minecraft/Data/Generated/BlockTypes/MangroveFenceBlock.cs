using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
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
    public Identifier? Item => "minecraft:mangrove_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 13996,
                                false => 13997,
                            },
                            false => West switch {
                                true => 13998,
                                false => 13999,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14000,
                                false => 14001,
                            },
                            false => West switch {
                                true => 14002,
                                false => 14003,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14004,
                                false => 14005,
                            },
                            false => West switch {
                                true => 14006,
                                false => 14007,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14008,
                                false => 14009,
                            },
                            false => West switch {
                                true => 14010,
                                false => 14011,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14012,
                                false => 14013,
                            },
                            false => West switch {
                                true => 14014,
                                false => 14015,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14016,
                                false => 14017,
                            },
                            false => West switch {
                                true => 14018,
                                false => 14019,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 14020,
                                false => 14021,
                            },
                            false => West switch {
                                true => 14022,
                                false => 14023,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 14024,
                                false => 14025,
                            },
                            false => West switch {
                                true => 14026,
                                false => 14027,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13996 => new MangroveFenceBlock(Identifier, true, true, true, true, true),
            13997 => new MangroveFenceBlock(Identifier, true, true, true, true, false),
            13998 => new MangroveFenceBlock(Identifier, true, true, true, false, true),
            13999 => new MangroveFenceBlock(Identifier, true, true, true, false, false),
            14000 => new MangroveFenceBlock(Identifier, true, true, false, true, true),
            14001 => new MangroveFenceBlock(Identifier, true, true, false, true, false),
            14002 => new MangroveFenceBlock(Identifier, true, true, false, false, true),
            14003 => new MangroveFenceBlock(Identifier, true, true, false, false, false),
            14004 => new MangroveFenceBlock(Identifier, true, false, true, true, true),
            14005 => new MangroveFenceBlock(Identifier, true, false, true, true, false),
            14006 => new MangroveFenceBlock(Identifier, true, false, true, false, true),
            14007 => new MangroveFenceBlock(Identifier, true, false, true, false, false),
            14008 => new MangroveFenceBlock(Identifier, true, false, false, true, true),
            14009 => new MangroveFenceBlock(Identifier, true, false, false, true, false),
            14010 => new MangroveFenceBlock(Identifier, true, false, false, false, true),
            14011 => new MangroveFenceBlock(Identifier, true, false, false, false, false),
            14012 => new MangroveFenceBlock(Identifier, false, true, true, true, true),
            14013 => new MangroveFenceBlock(Identifier, false, true, true, true, false),
            14014 => new MangroveFenceBlock(Identifier, false, true, true, false, true),
            14015 => new MangroveFenceBlock(Identifier, false, true, true, false, false),
            14016 => new MangroveFenceBlock(Identifier, false, true, false, true, true),
            14017 => new MangroveFenceBlock(Identifier, false, true, false, true, false),
            14018 => new MangroveFenceBlock(Identifier, false, true, false, false, true),
            14019 => new MangroveFenceBlock(Identifier, false, true, false, false, false),
            14020 => new MangroveFenceBlock(Identifier, false, false, true, true, true),
            14021 => new MangroveFenceBlock(Identifier, false, false, true, true, false),
            14022 => new MangroveFenceBlock(Identifier, false, false, true, false, true),
            14023 => new MangroveFenceBlock(Identifier, false, false, true, false, false),
            14024 => new MangroveFenceBlock(Identifier, false, false, false, true, true),
            14025 => new MangroveFenceBlock(Identifier, false, false, false, true, false),
            14026 => new MangroveFenceBlock(Identifier, false, false, false, false, true),
            14027 => new MangroveFenceBlock(Identifier, false, false, false, false, false),
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
