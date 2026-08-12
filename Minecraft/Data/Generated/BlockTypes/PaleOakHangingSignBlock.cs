using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
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
    public Identifier? Item => "minecraft:pale_oak_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6355,
                        false => 6356,
                    },
                    1 => Waterlogged switch {
                        true => 6357,
                        false => 6358,
                    },
                    2 => Waterlogged switch {
                        true => 6359,
                        false => 6360,
                    },
                    3 => Waterlogged switch {
                        true => 6361,
                        false => 6362,
                    },
                    4 => Waterlogged switch {
                        true => 6363,
                        false => 6364,
                    },
                    5 => Waterlogged switch {
                        true => 6365,
                        false => 6366,
                    },
                    6 => Waterlogged switch {
                        true => 6367,
                        false => 6368,
                    },
                    7 => Waterlogged switch {
                        true => 6369,
                        false => 6370,
                    },
                    8 => Waterlogged switch {
                        true => 6371,
                        false => 6372,
                    },
                    9 => Waterlogged switch {
                        true => 6373,
                        false => 6374,
                    },
                    10 => Waterlogged switch {
                        true => 6375,
                        false => 6376,
                    },
                    11 => Waterlogged switch {
                        true => 6377,
                        false => 6378,
                    },
                    12 => Waterlogged switch {
                        true => 6379,
                        false => 6380,
                    },
                    13 => Waterlogged switch {
                        true => 6381,
                        false => 6382,
                    },
                    14 => Waterlogged switch {
                        true => 6383,
                        false => 6384,
                    },
                    15 => Waterlogged switch {
                        true => 6385,
                        false => 6386,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6387,
                        false => 6388,
                    },
                    1 => Waterlogged switch {
                        true => 6389,
                        false => 6390,
                    },
                    2 => Waterlogged switch {
                        true => 6391,
                        false => 6392,
                    },
                    3 => Waterlogged switch {
                        true => 6393,
                        false => 6394,
                    },
                    4 => Waterlogged switch {
                        true => 6395,
                        false => 6396,
                    },
                    5 => Waterlogged switch {
                        true => 6397,
                        false => 6398,
                    },
                    6 => Waterlogged switch {
                        true => 6399,
                        false => 6400,
                    },
                    7 => Waterlogged switch {
                        true => 6401,
                        false => 6402,
                    },
                    8 => Waterlogged switch {
                        true => 6403,
                        false => 6404,
                    },
                    9 => Waterlogged switch {
                        true => 6405,
                        false => 6406,
                    },
                    10 => Waterlogged switch {
                        true => 6407,
                        false => 6408,
                    },
                    11 => Waterlogged switch {
                        true => 6409,
                        false => 6410,
                    },
                    12 => Waterlogged switch {
                        true => 6411,
                        false => 6412,
                    },
                    13 => Waterlogged switch {
                        true => 6413,
                        false => 6414,
                    },
                    14 => Waterlogged switch {
                        true => 6415,
                        false => 6416,
                    },
                    15 => Waterlogged switch {
                        true => 6417,
                        false => 6418,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6355 => new PaleOakHangingSignBlock(Identifier, true, 0, true),
            6356 => new PaleOakHangingSignBlock(Identifier, true, 0, false),
            6357 => new PaleOakHangingSignBlock(Identifier, true, 1, true),
            6358 => new PaleOakHangingSignBlock(Identifier, true, 1, false),
            6359 => new PaleOakHangingSignBlock(Identifier, true, 2, true),
            6360 => new PaleOakHangingSignBlock(Identifier, true, 2, false),
            6361 => new PaleOakHangingSignBlock(Identifier, true, 3, true),
            6362 => new PaleOakHangingSignBlock(Identifier, true, 3, false),
            6363 => new PaleOakHangingSignBlock(Identifier, true, 4, true),
            6364 => new PaleOakHangingSignBlock(Identifier, true, 4, false),
            6365 => new PaleOakHangingSignBlock(Identifier, true, 5, true),
            6366 => new PaleOakHangingSignBlock(Identifier, true, 5, false),
            6367 => new PaleOakHangingSignBlock(Identifier, true, 6, true),
            6368 => new PaleOakHangingSignBlock(Identifier, true, 6, false),
            6369 => new PaleOakHangingSignBlock(Identifier, true, 7, true),
            6370 => new PaleOakHangingSignBlock(Identifier, true, 7, false),
            6371 => new PaleOakHangingSignBlock(Identifier, true, 8, true),
            6372 => new PaleOakHangingSignBlock(Identifier, true, 8, false),
            6373 => new PaleOakHangingSignBlock(Identifier, true, 9, true),
            6374 => new PaleOakHangingSignBlock(Identifier, true, 9, false),
            6375 => new PaleOakHangingSignBlock(Identifier, true, 10, true),
            6376 => new PaleOakHangingSignBlock(Identifier, true, 10, false),
            6377 => new PaleOakHangingSignBlock(Identifier, true, 11, true),
            6378 => new PaleOakHangingSignBlock(Identifier, true, 11, false),
            6379 => new PaleOakHangingSignBlock(Identifier, true, 12, true),
            6380 => new PaleOakHangingSignBlock(Identifier, true, 12, false),
            6381 => new PaleOakHangingSignBlock(Identifier, true, 13, true),
            6382 => new PaleOakHangingSignBlock(Identifier, true, 13, false),
            6383 => new PaleOakHangingSignBlock(Identifier, true, 14, true),
            6384 => new PaleOakHangingSignBlock(Identifier, true, 14, false),
            6385 => new PaleOakHangingSignBlock(Identifier, true, 15, true),
            6386 => new PaleOakHangingSignBlock(Identifier, true, 15, false),
            6387 => new PaleOakHangingSignBlock(Identifier, false, 0, true),
            6388 => new PaleOakHangingSignBlock(Identifier, false, 0, false),
            6389 => new PaleOakHangingSignBlock(Identifier, false, 1, true),
            6390 => new PaleOakHangingSignBlock(Identifier, false, 1, false),
            6391 => new PaleOakHangingSignBlock(Identifier, false, 2, true),
            6392 => new PaleOakHangingSignBlock(Identifier, false, 2, false),
            6393 => new PaleOakHangingSignBlock(Identifier, false, 3, true),
            6394 => new PaleOakHangingSignBlock(Identifier, false, 3, false),
            6395 => new PaleOakHangingSignBlock(Identifier, false, 4, true),
            6396 => new PaleOakHangingSignBlock(Identifier, false, 4, false),
            6397 => new PaleOakHangingSignBlock(Identifier, false, 5, true),
            6398 => new PaleOakHangingSignBlock(Identifier, false, 5, false),
            6399 => new PaleOakHangingSignBlock(Identifier, false, 6, true),
            6400 => new PaleOakHangingSignBlock(Identifier, false, 6, false),
            6401 => new PaleOakHangingSignBlock(Identifier, false, 7, true),
            6402 => new PaleOakHangingSignBlock(Identifier, false, 7, false),
            6403 => new PaleOakHangingSignBlock(Identifier, false, 8, true),
            6404 => new PaleOakHangingSignBlock(Identifier, false, 8, false),
            6405 => new PaleOakHangingSignBlock(Identifier, false, 9, true),
            6406 => new PaleOakHangingSignBlock(Identifier, false, 9, false),
            6407 => new PaleOakHangingSignBlock(Identifier, false, 10, true),
            6408 => new PaleOakHangingSignBlock(Identifier, false, 10, false),
            6409 => new PaleOakHangingSignBlock(Identifier, false, 11, true),
            6410 => new PaleOakHangingSignBlock(Identifier, false, 11, false),
            6411 => new PaleOakHangingSignBlock(Identifier, false, 12, true),
            6412 => new PaleOakHangingSignBlock(Identifier, false, 12, false),
            6413 => new PaleOakHangingSignBlock(Identifier, false, 13, true),
            6414 => new PaleOakHangingSignBlock(Identifier, false, 13, false),
            6415 => new PaleOakHangingSignBlock(Identifier, false, 14, true),
            6416 => new PaleOakHangingSignBlock(Identifier, false, 14, false),
            6417 => new PaleOakHangingSignBlock(Identifier, false, 15, true),
            6418 => new PaleOakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
