using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 243;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:mangrove_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6346,
                        false => 6347,
                    },
                    1 => Waterlogged switch {
                        true => 6348,
                        false => 6349,
                    },
                    2 => Waterlogged switch {
                        true => 6350,
                        false => 6351,
                    },
                    3 => Waterlogged switch {
                        true => 6352,
                        false => 6353,
                    },
                    4 => Waterlogged switch {
                        true => 6354,
                        false => 6355,
                    },
                    5 => Waterlogged switch {
                        true => 6356,
                        false => 6357,
                    },
                    6 => Waterlogged switch {
                        true => 6358,
                        false => 6359,
                    },
                    7 => Waterlogged switch {
                        true => 6360,
                        false => 6361,
                    },
                    8 => Waterlogged switch {
                        true => 6362,
                        false => 6363,
                    },
                    9 => Waterlogged switch {
                        true => 6364,
                        false => 6365,
                    },
                    10 => Waterlogged switch {
                        true => 6366,
                        false => 6367,
                    },
                    11 => Waterlogged switch {
                        true => 6368,
                        false => 6369,
                    },
                    12 => Waterlogged switch {
                        true => 6370,
                        false => 6371,
                    },
                    13 => Waterlogged switch {
                        true => 6372,
                        false => 6373,
                    },
                    14 => Waterlogged switch {
                        true => 6374,
                        false => 6375,
                    },
                    15 => Waterlogged switch {
                        true => 6376,
                        false => 6377,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6378,
                        false => 6379,
                    },
                    1 => Waterlogged switch {
                        true => 6380,
                        false => 6381,
                    },
                    2 => Waterlogged switch {
                        true => 6382,
                        false => 6383,
                    },
                    3 => Waterlogged switch {
                        true => 6384,
                        false => 6385,
                    },
                    4 => Waterlogged switch {
                        true => 6386,
                        false => 6387,
                    },
                    5 => Waterlogged switch {
                        true => 6388,
                        false => 6389,
                    },
                    6 => Waterlogged switch {
                        true => 6390,
                        false => 6391,
                    },
                    7 => Waterlogged switch {
                        true => 6392,
                        false => 6393,
                    },
                    8 => Waterlogged switch {
                        true => 6394,
                        false => 6395,
                    },
                    9 => Waterlogged switch {
                        true => 6396,
                        false => 6397,
                    },
                    10 => Waterlogged switch {
                        true => 6398,
                        false => 6399,
                    },
                    11 => Waterlogged switch {
                        true => 6400,
                        false => 6401,
                    },
                    12 => Waterlogged switch {
                        true => 6402,
                        false => 6403,
                    },
                    13 => Waterlogged switch {
                        true => 6404,
                        false => 6405,
                    },
                    14 => Waterlogged switch {
                        true => 6406,
                        false => 6407,
                    },
                    15 => Waterlogged switch {
                        true => 6408,
                        false => 6409,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6346 => new MangroveHangingSignBlock(Identifier, true, 0, true),
            6347 => new MangroveHangingSignBlock(Identifier, true, 0, false),
            6348 => new MangroveHangingSignBlock(Identifier, true, 1, true),
            6349 => new MangroveHangingSignBlock(Identifier, true, 1, false),
            6350 => new MangroveHangingSignBlock(Identifier, true, 2, true),
            6351 => new MangroveHangingSignBlock(Identifier, true, 2, false),
            6352 => new MangroveHangingSignBlock(Identifier, true, 3, true),
            6353 => new MangroveHangingSignBlock(Identifier, true, 3, false),
            6354 => new MangroveHangingSignBlock(Identifier, true, 4, true),
            6355 => new MangroveHangingSignBlock(Identifier, true, 4, false),
            6356 => new MangroveHangingSignBlock(Identifier, true, 5, true),
            6357 => new MangroveHangingSignBlock(Identifier, true, 5, false),
            6358 => new MangroveHangingSignBlock(Identifier, true, 6, true),
            6359 => new MangroveHangingSignBlock(Identifier, true, 6, false),
            6360 => new MangroveHangingSignBlock(Identifier, true, 7, true),
            6361 => new MangroveHangingSignBlock(Identifier, true, 7, false),
            6362 => new MangroveHangingSignBlock(Identifier, true, 8, true),
            6363 => new MangroveHangingSignBlock(Identifier, true, 8, false),
            6364 => new MangroveHangingSignBlock(Identifier, true, 9, true),
            6365 => new MangroveHangingSignBlock(Identifier, true, 9, false),
            6366 => new MangroveHangingSignBlock(Identifier, true, 10, true),
            6367 => new MangroveHangingSignBlock(Identifier, true, 10, false),
            6368 => new MangroveHangingSignBlock(Identifier, true, 11, true),
            6369 => new MangroveHangingSignBlock(Identifier, true, 11, false),
            6370 => new MangroveHangingSignBlock(Identifier, true, 12, true),
            6371 => new MangroveHangingSignBlock(Identifier, true, 12, false),
            6372 => new MangroveHangingSignBlock(Identifier, true, 13, true),
            6373 => new MangroveHangingSignBlock(Identifier, true, 13, false),
            6374 => new MangroveHangingSignBlock(Identifier, true, 14, true),
            6375 => new MangroveHangingSignBlock(Identifier, true, 14, false),
            6376 => new MangroveHangingSignBlock(Identifier, true, 15, true),
            6377 => new MangroveHangingSignBlock(Identifier, true, 15, false),
            6378 => new MangroveHangingSignBlock(Identifier, false, 0, true),
            6379 => new MangroveHangingSignBlock(Identifier, false, 0, false),
            6380 => new MangroveHangingSignBlock(Identifier, false, 1, true),
            6381 => new MangroveHangingSignBlock(Identifier, false, 1, false),
            6382 => new MangroveHangingSignBlock(Identifier, false, 2, true),
            6383 => new MangroveHangingSignBlock(Identifier, false, 2, false),
            6384 => new MangroveHangingSignBlock(Identifier, false, 3, true),
            6385 => new MangroveHangingSignBlock(Identifier, false, 3, false),
            6386 => new MangroveHangingSignBlock(Identifier, false, 4, true),
            6387 => new MangroveHangingSignBlock(Identifier, false, 4, false),
            6388 => new MangroveHangingSignBlock(Identifier, false, 5, true),
            6389 => new MangroveHangingSignBlock(Identifier, false, 5, false),
            6390 => new MangroveHangingSignBlock(Identifier, false, 6, true),
            6391 => new MangroveHangingSignBlock(Identifier, false, 6, false),
            6392 => new MangroveHangingSignBlock(Identifier, false, 7, true),
            6393 => new MangroveHangingSignBlock(Identifier, false, 7, false),
            6394 => new MangroveHangingSignBlock(Identifier, false, 8, true),
            6395 => new MangroveHangingSignBlock(Identifier, false, 8, false),
            6396 => new MangroveHangingSignBlock(Identifier, false, 9, true),
            6397 => new MangroveHangingSignBlock(Identifier, false, 9, false),
            6398 => new MangroveHangingSignBlock(Identifier, false, 10, true),
            6399 => new MangroveHangingSignBlock(Identifier, false, 10, false),
            6400 => new MangroveHangingSignBlock(Identifier, false, 11, true),
            6401 => new MangroveHangingSignBlock(Identifier, false, 11, false),
            6402 => new MangroveHangingSignBlock(Identifier, false, 12, true),
            6403 => new MangroveHangingSignBlock(Identifier, false, 12, false),
            6404 => new MangroveHangingSignBlock(Identifier, false, 13, true),
            6405 => new MangroveHangingSignBlock(Identifier, false, 13, false),
            6406 => new MangroveHangingSignBlock(Identifier, false, 14, true),
            6407 => new MangroveHangingSignBlock(Identifier, false, 14, false),
            6408 => new MangroveHangingSignBlock(Identifier, false, 15, true),
            6409 => new MangroveHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.ChildrenMap.ContainsKey("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("attached", Attached.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
