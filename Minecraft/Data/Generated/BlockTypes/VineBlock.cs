using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record VineBlock(Identifier Identifier, bool East, bool North, bool South, bool Up, bool West) : IBlock {
    public Identifier Category => "minecraft:vine";
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "vine";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:vine";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.vine";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8358,
                                false => 8359,
                            },
                            false => West switch {
                                true => 8360,
                                false => 8361,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8362,
                                false => 8363,
                            },
                            false => West switch {
                                true => 8364,
                                false => 8365,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8366,
                                false => 8367,
                            },
                            false => West switch {
                                true => 8368,
                                false => 8369,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8370,
                                false => 8371,
                            },
                            false => West switch {
                                true => 8372,
                                false => 8373,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8374,
                                false => 8375,
                            },
                            false => West switch {
                                true => 8376,
                                false => 8377,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8378,
                                false => 8379,
                            },
                            false => West switch {
                                true => 8380,
                                false => 8381,
                            },
                        },
                    },
                    false => South switch {
                        true => Up switch {
                            true => West switch {
                                true => 8382,
                                false => 8383,
                            },
                            false => West switch {
                                true => 8384,
                                false => 8385,
                            },
                        },
                        false => Up switch {
                            true => West switch {
                                true => 8386,
                                false => 8387,
                            },
                            false => West switch {
                                true => 8388,
                                false => 8389,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8358 => new VineBlock(Identifier, true, true, true, true, true),
            8359 => new VineBlock(Identifier, true, true, true, true, false),
            8360 => new VineBlock(Identifier, true, true, true, false, true),
            8361 => new VineBlock(Identifier, true, true, true, false, false),
            8362 => new VineBlock(Identifier, true, true, false, true, true),
            8363 => new VineBlock(Identifier, true, true, false, true, false),
            8364 => new VineBlock(Identifier, true, true, false, false, true),
            8365 => new VineBlock(Identifier, true, true, false, false, false),
            8366 => new VineBlock(Identifier, true, false, true, true, true),
            8367 => new VineBlock(Identifier, true, false, true, true, false),
            8368 => new VineBlock(Identifier, true, false, true, false, true),
            8369 => new VineBlock(Identifier, true, false, true, false, false),
            8370 => new VineBlock(Identifier, true, false, false, true, true),
            8371 => new VineBlock(Identifier, true, false, false, true, false),
            8372 => new VineBlock(Identifier, true, false, false, false, true),
            8373 => new VineBlock(Identifier, true, false, false, false, false),
            8374 => new VineBlock(Identifier, false, true, true, true, true),
            8375 => new VineBlock(Identifier, false, true, true, true, false),
            8376 => new VineBlock(Identifier, false, true, true, false, true),
            8377 => new VineBlock(Identifier, false, true, true, false, false),
            8378 => new VineBlock(Identifier, false, true, false, true, true),
            8379 => new VineBlock(Identifier, false, true, false, true, false),
            8380 => new VineBlock(Identifier, false, true, false, false, true),
            8381 => new VineBlock(Identifier, false, true, false, false, false),
            8382 => new VineBlock(Identifier, false, false, true, true, true),
            8383 => new VineBlock(Identifier, false, false, true, true, false),
            8384 => new VineBlock(Identifier, false, false, true, false, true),
            8385 => new VineBlock(Identifier, false, false, true, false, false),
            8386 => new VineBlock(Identifier, false, false, false, true, true),
            8387 => new VineBlock(Identifier, false, false, false, true, false),
            8388 => new VineBlock(Identifier, false, false, false, false, true),
            8389 => new VineBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
