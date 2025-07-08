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
                        true => 5386,
                        false => 5387,
                    },
                    1 => Waterlogged switch {
                        true => 5388,
                        false => 5389,
                    },
                    2 => Waterlogged switch {
                        true => 5390,
                        false => 5391,
                    },
                    3 => Waterlogged switch {
                        true => 5392,
                        false => 5393,
                    },
                    4 => Waterlogged switch {
                        true => 5394,
                        false => 5395,
                    },
                    5 => Waterlogged switch {
                        true => 5396,
                        false => 5397,
                    },
                    6 => Waterlogged switch {
                        true => 5398,
                        false => 5399,
                    },
                    7 => Waterlogged switch {
                        true => 5400,
                        false => 5401,
                    },
                    8 => Waterlogged switch {
                        true => 5402,
                        false => 5403,
                    },
                    9 => Waterlogged switch {
                        true => 5404,
                        false => 5405,
                    },
                    10 => Waterlogged switch {
                        true => 5406,
                        false => 5407,
                    },
                    11 => Waterlogged switch {
                        true => 5408,
                        false => 5409,
                    },
                    12 => Waterlogged switch {
                        true => 5410,
                        false => 5411,
                    },
                    13 => Waterlogged switch {
                        true => 5412,
                        false => 5413,
                    },
                    14 => Waterlogged switch {
                        true => 5414,
                        false => 5415,
                    },
                    15 => Waterlogged switch {
                        true => 5416,
                        false => 5417,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5418,
                        false => 5419,
                    },
                    1 => Waterlogged switch {
                        true => 5420,
                        false => 5421,
                    },
                    2 => Waterlogged switch {
                        true => 5422,
                        false => 5423,
                    },
                    3 => Waterlogged switch {
                        true => 5424,
                        false => 5425,
                    },
                    4 => Waterlogged switch {
                        true => 5426,
                        false => 5427,
                    },
                    5 => Waterlogged switch {
                        true => 5428,
                        false => 5429,
                    },
                    6 => Waterlogged switch {
                        true => 5430,
                        false => 5431,
                    },
                    7 => Waterlogged switch {
                        true => 5432,
                        false => 5433,
                    },
                    8 => Waterlogged switch {
                        true => 5434,
                        false => 5435,
                    },
                    9 => Waterlogged switch {
                        true => 5436,
                        false => 5437,
                    },
                    10 => Waterlogged switch {
                        true => 5438,
                        false => 5439,
                    },
                    11 => Waterlogged switch {
                        true => 5440,
                        false => 5441,
                    },
                    12 => Waterlogged switch {
                        true => 5442,
                        false => 5443,
                    },
                    13 => Waterlogged switch {
                        true => 5444,
                        false => 5445,
                    },
                    14 => Waterlogged switch {
                        true => 5446,
                        false => 5447,
                    },
                    15 => Waterlogged switch {
                        true => 5448,
                        false => 5449,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5386 => new PaleOakHangingSignBlock(Identifier, true, 0, true),
            5387 => new PaleOakHangingSignBlock(Identifier, true, 0, false),
            5388 => new PaleOakHangingSignBlock(Identifier, true, 1, true),
            5389 => new PaleOakHangingSignBlock(Identifier, true, 1, false),
            5390 => new PaleOakHangingSignBlock(Identifier, true, 2, true),
            5391 => new PaleOakHangingSignBlock(Identifier, true, 2, false),
            5392 => new PaleOakHangingSignBlock(Identifier, true, 3, true),
            5393 => new PaleOakHangingSignBlock(Identifier, true, 3, false),
            5394 => new PaleOakHangingSignBlock(Identifier, true, 4, true),
            5395 => new PaleOakHangingSignBlock(Identifier, true, 4, false),
            5396 => new PaleOakHangingSignBlock(Identifier, true, 5, true),
            5397 => new PaleOakHangingSignBlock(Identifier, true, 5, false),
            5398 => new PaleOakHangingSignBlock(Identifier, true, 6, true),
            5399 => new PaleOakHangingSignBlock(Identifier, true, 6, false),
            5400 => new PaleOakHangingSignBlock(Identifier, true, 7, true),
            5401 => new PaleOakHangingSignBlock(Identifier, true, 7, false),
            5402 => new PaleOakHangingSignBlock(Identifier, true, 8, true),
            5403 => new PaleOakHangingSignBlock(Identifier, true, 8, false),
            5404 => new PaleOakHangingSignBlock(Identifier, true, 9, true),
            5405 => new PaleOakHangingSignBlock(Identifier, true, 9, false),
            5406 => new PaleOakHangingSignBlock(Identifier, true, 10, true),
            5407 => new PaleOakHangingSignBlock(Identifier, true, 10, false),
            5408 => new PaleOakHangingSignBlock(Identifier, true, 11, true),
            5409 => new PaleOakHangingSignBlock(Identifier, true, 11, false),
            5410 => new PaleOakHangingSignBlock(Identifier, true, 12, true),
            5411 => new PaleOakHangingSignBlock(Identifier, true, 12, false),
            5412 => new PaleOakHangingSignBlock(Identifier, true, 13, true),
            5413 => new PaleOakHangingSignBlock(Identifier, true, 13, false),
            5414 => new PaleOakHangingSignBlock(Identifier, true, 14, true),
            5415 => new PaleOakHangingSignBlock(Identifier, true, 14, false),
            5416 => new PaleOakHangingSignBlock(Identifier, true, 15, true),
            5417 => new PaleOakHangingSignBlock(Identifier, true, 15, false),
            5418 => new PaleOakHangingSignBlock(Identifier, false, 0, true),
            5419 => new PaleOakHangingSignBlock(Identifier, false, 0, false),
            5420 => new PaleOakHangingSignBlock(Identifier, false, 1, true),
            5421 => new PaleOakHangingSignBlock(Identifier, false, 1, false),
            5422 => new PaleOakHangingSignBlock(Identifier, false, 2, true),
            5423 => new PaleOakHangingSignBlock(Identifier, false, 2, false),
            5424 => new PaleOakHangingSignBlock(Identifier, false, 3, true),
            5425 => new PaleOakHangingSignBlock(Identifier, false, 3, false),
            5426 => new PaleOakHangingSignBlock(Identifier, false, 4, true),
            5427 => new PaleOakHangingSignBlock(Identifier, false, 4, false),
            5428 => new PaleOakHangingSignBlock(Identifier, false, 5, true),
            5429 => new PaleOakHangingSignBlock(Identifier, false, 5, false),
            5430 => new PaleOakHangingSignBlock(Identifier, false, 6, true),
            5431 => new PaleOakHangingSignBlock(Identifier, false, 6, false),
            5432 => new PaleOakHangingSignBlock(Identifier, false, 7, true),
            5433 => new PaleOakHangingSignBlock(Identifier, false, 7, false),
            5434 => new PaleOakHangingSignBlock(Identifier, false, 8, true),
            5435 => new PaleOakHangingSignBlock(Identifier, false, 8, false),
            5436 => new PaleOakHangingSignBlock(Identifier, false, 9, true),
            5437 => new PaleOakHangingSignBlock(Identifier, false, 9, false),
            5438 => new PaleOakHangingSignBlock(Identifier, false, 10, true),
            5439 => new PaleOakHangingSignBlock(Identifier, false, 10, false),
            5440 => new PaleOakHangingSignBlock(Identifier, false, 11, true),
            5441 => new PaleOakHangingSignBlock(Identifier, false, 11, false),
            5442 => new PaleOakHangingSignBlock(Identifier, false, 12, true),
            5443 => new PaleOakHangingSignBlock(Identifier, false, 12, false),
            5444 => new PaleOakHangingSignBlock(Identifier, false, 13, true),
            5445 => new PaleOakHangingSignBlock(Identifier, false, 13, false),
            5446 => new PaleOakHangingSignBlock(Identifier, false, 14, true),
            5447 => new PaleOakHangingSignBlock(Identifier, false, 14, false),
            5448 => new PaleOakHangingSignBlock(Identifier, false, 15, true),
            5449 => new PaleOakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
