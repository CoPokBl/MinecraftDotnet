using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinClumpBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool Waterlogged, bool West) : IBlock {
    public Identifier Category => "minecraft:multiface";
    public int ProtocolId => 367;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "resin";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:resin_clump";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 37;
    public string TranslationKey => "block.minecraft.resin_clump";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8317,
                                        false => 8318,
                                    },
                                    false => West switch {
                                        true => 8319,
                                        false => 8320,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8321,
                                        false => 8322,
                                    },
                                    false => West switch {
                                        true => 8323,
                                        false => 8324,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8325,
                                        false => 8326,
                                    },
                                    false => West switch {
                                        true => 8327,
                                        false => 8328,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8329,
                                        false => 8330,
                                    },
                                    false => West switch {
                                        true => 8331,
                                        false => 8332,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8333,
                                        false => 8334,
                                    },
                                    false => West switch {
                                        true => 8335,
                                        false => 8336,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8337,
                                        false => 8338,
                                    },
                                    false => West switch {
                                        true => 8339,
                                        false => 8340,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8341,
                                        false => 8342,
                                    },
                                    false => West switch {
                                        true => 8343,
                                        false => 8344,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8345,
                                        false => 8346,
                                    },
                                    false => West switch {
                                        true => 8347,
                                        false => 8348,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8349,
                                        false => 8350,
                                    },
                                    false => West switch {
                                        true => 8351,
                                        false => 8352,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8353,
                                        false => 8354,
                                    },
                                    false => West switch {
                                        true => 8355,
                                        false => 8356,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8357,
                                        false => 8358,
                                    },
                                    false => West switch {
                                        true => 8359,
                                        false => 8360,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8361,
                                        false => 8362,
                                    },
                                    false => West switch {
                                        true => 8363,
                                        false => 8364,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8365,
                                        false => 8366,
                                    },
                                    false => West switch {
                                        true => 8367,
                                        false => 8368,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8369,
                                        false => 8370,
                                    },
                                    false => West switch {
                                        true => 8371,
                                        false => 8372,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8373,
                                        false => 8374,
                                    },
                                    false => West switch {
                                        true => 8375,
                                        false => 8376,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8377,
                                        false => 8378,
                                    },
                                    false => West switch {
                                        true => 8379,
                                        false => 8380,
                                    },
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8381,
                                        false => 8382,
                                    },
                                    false => West switch {
                                        true => 8383,
                                        false => 8384,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8385,
                                        false => 8386,
                                    },
                                    false => West switch {
                                        true => 8387,
                                        false => 8388,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8389,
                                        false => 8390,
                                    },
                                    false => West switch {
                                        true => 8391,
                                        false => 8392,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8393,
                                        false => 8394,
                                    },
                                    false => West switch {
                                        true => 8395,
                                        false => 8396,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8397,
                                        false => 8398,
                                    },
                                    false => West switch {
                                        true => 8399,
                                        false => 8400,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8401,
                                        false => 8402,
                                    },
                                    false => West switch {
                                        true => 8403,
                                        false => 8404,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8405,
                                        false => 8406,
                                    },
                                    false => West switch {
                                        true => 8407,
                                        false => 8408,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8409,
                                        false => 8410,
                                    },
                                    false => West switch {
                                        true => 8411,
                                        false => 8412,
                                    },
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8413,
                                        false => 8414,
                                    },
                                    false => West switch {
                                        true => 8415,
                                        false => 8416,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8417,
                                        false => 8418,
                                    },
                                    false => West switch {
                                        true => 8419,
                                        false => 8420,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8421,
                                        false => 8422,
                                    },
                                    false => West switch {
                                        true => 8423,
                                        false => 8424,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8425,
                                        false => 8426,
                                    },
                                    false => West switch {
                                        true => 8427,
                                        false => 8428,
                                    },
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8429,
                                        false => 8430,
                                    },
                                    false => West switch {
                                        true => 8431,
                                        false => 8432,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8433,
                                        false => 8434,
                                    },
                                    false => West switch {
                                        true => 8435,
                                        false => 8436,
                                    },
                                },
                            },
                            false => Up switch {
                                true => Waterlogged switch {
                                    true => West switch {
                                        true => 8437,
                                        false => 8438,
                                    },
                                    false => West switch {
                                        true => 8439,
                                        false => 8440,
                                    },
                                },
                                false => Waterlogged switch {
                                    true => West switch {
                                        true => 8441,
                                        false => 8442,
                                    },
                                    false => West switch {
                                        true => 8443,
                                        false => 8444,
                                    },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8317 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, true),
            8318 => new ResinClumpBlock(Identifier, true, true, true, true, true, true, false),
            8319 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, true),
            8320 => new ResinClumpBlock(Identifier, true, true, true, true, true, false, false),
            8321 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, true),
            8322 => new ResinClumpBlock(Identifier, true, true, true, true, false, true, false),
            8323 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, true),
            8324 => new ResinClumpBlock(Identifier, true, true, true, true, false, false, false),
            8325 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, true),
            8326 => new ResinClumpBlock(Identifier, true, true, true, false, true, true, false),
            8327 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, true),
            8328 => new ResinClumpBlock(Identifier, true, true, true, false, true, false, false),
            8329 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, true),
            8330 => new ResinClumpBlock(Identifier, true, true, true, false, false, true, false),
            8331 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, true),
            8332 => new ResinClumpBlock(Identifier, true, true, true, false, false, false, false),
            8333 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, true),
            8334 => new ResinClumpBlock(Identifier, true, true, false, true, true, true, false),
            8335 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, true),
            8336 => new ResinClumpBlock(Identifier, true, true, false, true, true, false, false),
            8337 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, true),
            8338 => new ResinClumpBlock(Identifier, true, true, false, true, false, true, false),
            8339 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, true),
            8340 => new ResinClumpBlock(Identifier, true, true, false, true, false, false, false),
            8341 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, true),
            8342 => new ResinClumpBlock(Identifier, true, true, false, false, true, true, false),
            8343 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, true),
            8344 => new ResinClumpBlock(Identifier, true, true, false, false, true, false, false),
            8345 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, true),
            8346 => new ResinClumpBlock(Identifier, true, true, false, false, false, true, false),
            8347 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, true),
            8348 => new ResinClumpBlock(Identifier, true, true, false, false, false, false, false),
            8349 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, true),
            8350 => new ResinClumpBlock(Identifier, true, false, true, true, true, true, false),
            8351 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, true),
            8352 => new ResinClumpBlock(Identifier, true, false, true, true, true, false, false),
            8353 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, true),
            8354 => new ResinClumpBlock(Identifier, true, false, true, true, false, true, false),
            8355 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, true),
            8356 => new ResinClumpBlock(Identifier, true, false, true, true, false, false, false),
            8357 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, true),
            8358 => new ResinClumpBlock(Identifier, true, false, true, false, true, true, false),
            8359 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, true),
            8360 => new ResinClumpBlock(Identifier, true, false, true, false, true, false, false),
            8361 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, true),
            8362 => new ResinClumpBlock(Identifier, true, false, true, false, false, true, false),
            8363 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, true),
            8364 => new ResinClumpBlock(Identifier, true, false, true, false, false, false, false),
            8365 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, true),
            8366 => new ResinClumpBlock(Identifier, true, false, false, true, true, true, false),
            8367 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, true),
            8368 => new ResinClumpBlock(Identifier, true, false, false, true, true, false, false),
            8369 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, true),
            8370 => new ResinClumpBlock(Identifier, true, false, false, true, false, true, false),
            8371 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, true),
            8372 => new ResinClumpBlock(Identifier, true, false, false, true, false, false, false),
            8373 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, true),
            8374 => new ResinClumpBlock(Identifier, true, false, false, false, true, true, false),
            8375 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, true),
            8376 => new ResinClumpBlock(Identifier, true, false, false, false, true, false, false),
            8377 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, true),
            8378 => new ResinClumpBlock(Identifier, true, false, false, false, false, true, false),
            8379 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, true),
            8380 => new ResinClumpBlock(Identifier, true, false, false, false, false, false, false),
            8381 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, true),
            8382 => new ResinClumpBlock(Identifier, false, true, true, true, true, true, false),
            8383 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, true),
            8384 => new ResinClumpBlock(Identifier, false, true, true, true, true, false, false),
            8385 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, true),
            8386 => new ResinClumpBlock(Identifier, false, true, true, true, false, true, false),
            8387 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, true),
            8388 => new ResinClumpBlock(Identifier, false, true, true, true, false, false, false),
            8389 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, true),
            8390 => new ResinClumpBlock(Identifier, false, true, true, false, true, true, false),
            8391 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, true),
            8392 => new ResinClumpBlock(Identifier, false, true, true, false, true, false, false),
            8393 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, true),
            8394 => new ResinClumpBlock(Identifier, false, true, true, false, false, true, false),
            8395 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, true),
            8396 => new ResinClumpBlock(Identifier, false, true, true, false, false, false, false),
            8397 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, true),
            8398 => new ResinClumpBlock(Identifier, false, true, false, true, true, true, false),
            8399 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, true),
            8400 => new ResinClumpBlock(Identifier, false, true, false, true, true, false, false),
            8401 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, true),
            8402 => new ResinClumpBlock(Identifier, false, true, false, true, false, true, false),
            8403 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, true),
            8404 => new ResinClumpBlock(Identifier, false, true, false, true, false, false, false),
            8405 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, true),
            8406 => new ResinClumpBlock(Identifier, false, true, false, false, true, true, false),
            8407 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, true),
            8408 => new ResinClumpBlock(Identifier, false, true, false, false, true, false, false),
            8409 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, true),
            8410 => new ResinClumpBlock(Identifier, false, true, false, false, false, true, false),
            8411 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, true),
            8412 => new ResinClumpBlock(Identifier, false, true, false, false, false, false, false),
            8413 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, true),
            8414 => new ResinClumpBlock(Identifier, false, false, true, true, true, true, false),
            8415 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, true),
            8416 => new ResinClumpBlock(Identifier, false, false, true, true, true, false, false),
            8417 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, true),
            8418 => new ResinClumpBlock(Identifier, false, false, true, true, false, true, false),
            8419 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, true),
            8420 => new ResinClumpBlock(Identifier, false, false, true, true, false, false, false),
            8421 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, true),
            8422 => new ResinClumpBlock(Identifier, false, false, true, false, true, true, false),
            8423 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, true),
            8424 => new ResinClumpBlock(Identifier, false, false, true, false, true, false, false),
            8425 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, true),
            8426 => new ResinClumpBlock(Identifier, false, false, true, false, false, true, false),
            8427 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, true),
            8428 => new ResinClumpBlock(Identifier, false, false, true, false, false, false, false),
            8429 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, true),
            8430 => new ResinClumpBlock(Identifier, false, false, false, true, true, true, false),
            8431 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, true),
            8432 => new ResinClumpBlock(Identifier, false, false, false, true, true, false, false),
            8433 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, true),
            8434 => new ResinClumpBlock(Identifier, false, false, false, true, false, true, false),
            8435 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, true),
            8436 => new ResinClumpBlock(Identifier, false, false, false, true, false, false, false),
            8437 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, true),
            8438 => new ResinClumpBlock(Identifier, false, false, false, false, true, true, false),
            8439 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, true),
            8440 => new ResinClumpBlock(Identifier, false, false, false, false, true, false, false),
            8441 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, true),
            8442 => new ResinClumpBlock(Identifier, false, false, false, false, false, true, false),
            8443 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, true),
            8444 => new ResinClumpBlock(Identifier, false, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.ChildrenMap.ContainsKey("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.ChildrenMap.ContainsKey("east") ? properties["east"].GetString() == "true" : East,
            North = properties.ChildrenMap.ContainsKey("north") ? properties["north"].GetString() == "true" : North,
            South = properties.ChildrenMap.ContainsKey("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.ChildrenMap.ContainsKey("up") ? properties["up"].GetString() == "true" : Up,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
            West = properties.ChildrenMap.ContainsKey("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("down", Down.ToString().ToLower()),
            new StringTag("east", East.ToString().ToLower()),
            new StringTag("north", North.ToString().ToLower()),
            new StringTag("south", South.ToString().ToLower()),
            new StringTag("up", Up.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()),
            new StringTag("west", West.ToString().ToLower())
        );
    }
    
}
