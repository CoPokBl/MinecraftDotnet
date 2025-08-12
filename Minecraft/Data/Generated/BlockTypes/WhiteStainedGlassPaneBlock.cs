using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:stained_glass_pane";
    public int ProtocolId => 468;
    public double Hardness => 0.3;
    public double ExplosionResistance => 0.3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "glass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:white_stained_glass_pane";
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
    public string TranslationKey => "block.minecraft.white_stained_glass_pane";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10181,
                                false => 10182,
                            },
                            false => West switch {
                                true => 10183,
                                false => 10184,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10185,
                                false => 10186,
                            },
                            false => West switch {
                                true => 10187,
                                false => 10188,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10189,
                                false => 10190,
                            },
                            false => West switch {
                                true => 10191,
                                false => 10192,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10193,
                                false => 10194,
                            },
                            false => West switch {
                                true => 10195,
                                false => 10196,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10197,
                                false => 10198,
                            },
                            false => West switch {
                                true => 10199,
                                false => 10200,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10201,
                                false => 10202,
                            },
                            false => West switch {
                                true => 10203,
                                false => 10204,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10205,
                                false => 10206,
                            },
                            false => West switch {
                                true => 10207,
                                false => 10208,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10209,
                                false => 10210,
                            },
                            false => West switch {
                                true => 10211,
                                false => 10212,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10181 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10182 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10183 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10184 => new WhiteStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10185 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10186 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10187 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10188 => new WhiteStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10189 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10190 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10191 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10192 => new WhiteStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10193 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10194 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10195 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10196 => new WhiteStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10197 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10198 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10199 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10200 => new WhiteStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10201 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10202 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10203 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10204 => new WhiteStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10205 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10206 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10207 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10208 => new WhiteStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10209 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10210 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10211 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10212 => new WhiteStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
