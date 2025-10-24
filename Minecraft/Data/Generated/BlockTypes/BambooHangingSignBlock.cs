using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 244;
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
    public string SoundType => "bamboo_wood_hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:bamboo_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6410,
                        false => 6411,
                    },
                    1 => Waterlogged switch {
                        true => 6412,
                        false => 6413,
                    },
                    2 => Waterlogged switch {
                        true => 6414,
                        false => 6415,
                    },
                    3 => Waterlogged switch {
                        true => 6416,
                        false => 6417,
                    },
                    4 => Waterlogged switch {
                        true => 6418,
                        false => 6419,
                    },
                    5 => Waterlogged switch {
                        true => 6420,
                        false => 6421,
                    },
                    6 => Waterlogged switch {
                        true => 6422,
                        false => 6423,
                    },
                    7 => Waterlogged switch {
                        true => 6424,
                        false => 6425,
                    },
                    8 => Waterlogged switch {
                        true => 6426,
                        false => 6427,
                    },
                    9 => Waterlogged switch {
                        true => 6428,
                        false => 6429,
                    },
                    10 => Waterlogged switch {
                        true => 6430,
                        false => 6431,
                    },
                    11 => Waterlogged switch {
                        true => 6432,
                        false => 6433,
                    },
                    12 => Waterlogged switch {
                        true => 6434,
                        false => 6435,
                    },
                    13 => Waterlogged switch {
                        true => 6436,
                        false => 6437,
                    },
                    14 => Waterlogged switch {
                        true => 6438,
                        false => 6439,
                    },
                    15 => Waterlogged switch {
                        true => 6440,
                        false => 6441,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6442,
                        false => 6443,
                    },
                    1 => Waterlogged switch {
                        true => 6444,
                        false => 6445,
                    },
                    2 => Waterlogged switch {
                        true => 6446,
                        false => 6447,
                    },
                    3 => Waterlogged switch {
                        true => 6448,
                        false => 6449,
                    },
                    4 => Waterlogged switch {
                        true => 6450,
                        false => 6451,
                    },
                    5 => Waterlogged switch {
                        true => 6452,
                        false => 6453,
                    },
                    6 => Waterlogged switch {
                        true => 6454,
                        false => 6455,
                    },
                    7 => Waterlogged switch {
                        true => 6456,
                        false => 6457,
                    },
                    8 => Waterlogged switch {
                        true => 6458,
                        false => 6459,
                    },
                    9 => Waterlogged switch {
                        true => 6460,
                        false => 6461,
                    },
                    10 => Waterlogged switch {
                        true => 6462,
                        false => 6463,
                    },
                    11 => Waterlogged switch {
                        true => 6464,
                        false => 6465,
                    },
                    12 => Waterlogged switch {
                        true => 6466,
                        false => 6467,
                    },
                    13 => Waterlogged switch {
                        true => 6468,
                        false => 6469,
                    },
                    14 => Waterlogged switch {
                        true => 6470,
                        false => 6471,
                    },
                    15 => Waterlogged switch {
                        true => 6472,
                        false => 6473,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6410 => new BambooHangingSignBlock(Identifier, true, 0, true),
            6411 => new BambooHangingSignBlock(Identifier, true, 0, false),
            6412 => new BambooHangingSignBlock(Identifier, true, 1, true),
            6413 => new BambooHangingSignBlock(Identifier, true, 1, false),
            6414 => new BambooHangingSignBlock(Identifier, true, 2, true),
            6415 => new BambooHangingSignBlock(Identifier, true, 2, false),
            6416 => new BambooHangingSignBlock(Identifier, true, 3, true),
            6417 => new BambooHangingSignBlock(Identifier, true, 3, false),
            6418 => new BambooHangingSignBlock(Identifier, true, 4, true),
            6419 => new BambooHangingSignBlock(Identifier, true, 4, false),
            6420 => new BambooHangingSignBlock(Identifier, true, 5, true),
            6421 => new BambooHangingSignBlock(Identifier, true, 5, false),
            6422 => new BambooHangingSignBlock(Identifier, true, 6, true),
            6423 => new BambooHangingSignBlock(Identifier, true, 6, false),
            6424 => new BambooHangingSignBlock(Identifier, true, 7, true),
            6425 => new BambooHangingSignBlock(Identifier, true, 7, false),
            6426 => new BambooHangingSignBlock(Identifier, true, 8, true),
            6427 => new BambooHangingSignBlock(Identifier, true, 8, false),
            6428 => new BambooHangingSignBlock(Identifier, true, 9, true),
            6429 => new BambooHangingSignBlock(Identifier, true, 9, false),
            6430 => new BambooHangingSignBlock(Identifier, true, 10, true),
            6431 => new BambooHangingSignBlock(Identifier, true, 10, false),
            6432 => new BambooHangingSignBlock(Identifier, true, 11, true),
            6433 => new BambooHangingSignBlock(Identifier, true, 11, false),
            6434 => new BambooHangingSignBlock(Identifier, true, 12, true),
            6435 => new BambooHangingSignBlock(Identifier, true, 12, false),
            6436 => new BambooHangingSignBlock(Identifier, true, 13, true),
            6437 => new BambooHangingSignBlock(Identifier, true, 13, false),
            6438 => new BambooHangingSignBlock(Identifier, true, 14, true),
            6439 => new BambooHangingSignBlock(Identifier, true, 14, false),
            6440 => new BambooHangingSignBlock(Identifier, true, 15, true),
            6441 => new BambooHangingSignBlock(Identifier, true, 15, false),
            6442 => new BambooHangingSignBlock(Identifier, false, 0, true),
            6443 => new BambooHangingSignBlock(Identifier, false, 0, false),
            6444 => new BambooHangingSignBlock(Identifier, false, 1, true),
            6445 => new BambooHangingSignBlock(Identifier, false, 1, false),
            6446 => new BambooHangingSignBlock(Identifier, false, 2, true),
            6447 => new BambooHangingSignBlock(Identifier, false, 2, false),
            6448 => new BambooHangingSignBlock(Identifier, false, 3, true),
            6449 => new BambooHangingSignBlock(Identifier, false, 3, false),
            6450 => new BambooHangingSignBlock(Identifier, false, 4, true),
            6451 => new BambooHangingSignBlock(Identifier, false, 4, false),
            6452 => new BambooHangingSignBlock(Identifier, false, 5, true),
            6453 => new BambooHangingSignBlock(Identifier, false, 5, false),
            6454 => new BambooHangingSignBlock(Identifier, false, 6, true),
            6455 => new BambooHangingSignBlock(Identifier, false, 6, false),
            6456 => new BambooHangingSignBlock(Identifier, false, 7, true),
            6457 => new BambooHangingSignBlock(Identifier, false, 7, false),
            6458 => new BambooHangingSignBlock(Identifier, false, 8, true),
            6459 => new BambooHangingSignBlock(Identifier, false, 8, false),
            6460 => new BambooHangingSignBlock(Identifier, false, 9, true),
            6461 => new BambooHangingSignBlock(Identifier, false, 9, false),
            6462 => new BambooHangingSignBlock(Identifier, false, 10, true),
            6463 => new BambooHangingSignBlock(Identifier, false, 10, false),
            6464 => new BambooHangingSignBlock(Identifier, false, 11, true),
            6465 => new BambooHangingSignBlock(Identifier, false, 11, false),
            6466 => new BambooHangingSignBlock(Identifier, false, 12, true),
            6467 => new BambooHangingSignBlock(Identifier, false, 12, false),
            6468 => new BambooHangingSignBlock(Identifier, false, 13, true),
            6469 => new BambooHangingSignBlock(Identifier, false, 13, false),
            6470 => new BambooHangingSignBlock(Identifier, false, 14, true),
            6471 => new BambooHangingSignBlock(Identifier, false, 14, false),
            6472 => new BambooHangingSignBlock(Identifier, false, 15, true),
            6473 => new BambooHangingSignBlock(Identifier, false, 15, false),
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
