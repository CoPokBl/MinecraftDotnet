using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:fence";
    public double Hardness => 2;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:nether_brick_fence";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.375, 0.0, 0.375] -> [0.625, 1.0, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.nether_brick_fence";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9335,
                                false => 9336,
                            },
                            false => West switch {
                                true => 9337,
                                false => 9338,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9339,
                                false => 9340,
                            },
                            false => West switch {
                                true => 9341,
                                false => 9342,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9343,
                                false => 9344,
                            },
                            false => West switch {
                                true => 9345,
                                false => 9346,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9347,
                                false => 9348,
                            },
                            false => West switch {
                                true => 9349,
                                false => 9350,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9351,
                                false => 9352,
                            },
                            false => West switch {
                                true => 9353,
                                false => 9354,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9355,
                                false => 9356,
                            },
                            false => West switch {
                                true => 9357,
                                false => 9358,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 9359,
                                false => 9360,
                            },
                            false => West switch {
                                true => 9361,
                                false => 9362,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 9363,
                                false => 9364,
                            },
                            false => West switch {
                                true => 9365,
                                false => 9366,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9335 => new NetherBrickFenceBlock(Identifier, true, true, true, true, true),
            9336 => new NetherBrickFenceBlock(Identifier, true, true, true, true, false),
            9337 => new NetherBrickFenceBlock(Identifier, true, true, true, false, true),
            9338 => new NetherBrickFenceBlock(Identifier, true, true, true, false, false),
            9339 => new NetherBrickFenceBlock(Identifier, true, true, false, true, true),
            9340 => new NetherBrickFenceBlock(Identifier, true, true, false, true, false),
            9341 => new NetherBrickFenceBlock(Identifier, true, true, false, false, true),
            9342 => new NetherBrickFenceBlock(Identifier, true, true, false, false, false),
            9343 => new NetherBrickFenceBlock(Identifier, true, false, true, true, true),
            9344 => new NetherBrickFenceBlock(Identifier, true, false, true, true, false),
            9345 => new NetherBrickFenceBlock(Identifier, true, false, true, false, true),
            9346 => new NetherBrickFenceBlock(Identifier, true, false, true, false, false),
            9347 => new NetherBrickFenceBlock(Identifier, true, false, false, true, true),
            9348 => new NetherBrickFenceBlock(Identifier, true, false, false, true, false),
            9349 => new NetherBrickFenceBlock(Identifier, true, false, false, false, true),
            9350 => new NetherBrickFenceBlock(Identifier, true, false, false, false, false),
            9351 => new NetherBrickFenceBlock(Identifier, false, true, true, true, true),
            9352 => new NetherBrickFenceBlock(Identifier, false, true, true, true, false),
            9353 => new NetherBrickFenceBlock(Identifier, false, true, true, false, true),
            9354 => new NetherBrickFenceBlock(Identifier, false, true, true, false, false),
            9355 => new NetherBrickFenceBlock(Identifier, false, true, false, true, true),
            9356 => new NetherBrickFenceBlock(Identifier, false, true, false, true, false),
            9357 => new NetherBrickFenceBlock(Identifier, false, true, false, false, true),
            9358 => new NetherBrickFenceBlock(Identifier, false, true, false, false, false),
            9359 => new NetherBrickFenceBlock(Identifier, false, false, true, true, true),
            9360 => new NetherBrickFenceBlock(Identifier, false, false, true, true, false),
            9361 => new NetherBrickFenceBlock(Identifier, false, false, true, false, true),
            9362 => new NetherBrickFenceBlock(Identifier, false, false, true, false, false),
            9363 => new NetherBrickFenceBlock(Identifier, false, false, false, true, true),
            9364 => new NetherBrickFenceBlock(Identifier, false, false, false, true, false),
            9365 => new NetherBrickFenceBlock(Identifier, false, false, false, false, true),
            9366 => new NetherBrickFenceBlock(Identifier, false, false, false, false, false),
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
