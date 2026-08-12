using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
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
    public string SoundType => "nether_wood_hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:warped_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6483,
                        false => 6484,
                    },
                    1 => Waterlogged switch {
                        true => 6485,
                        false => 6486,
                    },
                    2 => Waterlogged switch {
                        true => 6487,
                        false => 6488,
                    },
                    3 => Waterlogged switch {
                        true => 6489,
                        false => 6490,
                    },
                    4 => Waterlogged switch {
                        true => 6491,
                        false => 6492,
                    },
                    5 => Waterlogged switch {
                        true => 6493,
                        false => 6494,
                    },
                    6 => Waterlogged switch {
                        true => 6495,
                        false => 6496,
                    },
                    7 => Waterlogged switch {
                        true => 6497,
                        false => 6498,
                    },
                    8 => Waterlogged switch {
                        true => 6499,
                        false => 6500,
                    },
                    9 => Waterlogged switch {
                        true => 6501,
                        false => 6502,
                    },
                    10 => Waterlogged switch {
                        true => 6503,
                        false => 6504,
                    },
                    11 => Waterlogged switch {
                        true => 6505,
                        false => 6506,
                    },
                    12 => Waterlogged switch {
                        true => 6507,
                        false => 6508,
                    },
                    13 => Waterlogged switch {
                        true => 6509,
                        false => 6510,
                    },
                    14 => Waterlogged switch {
                        true => 6511,
                        false => 6512,
                    },
                    15 => Waterlogged switch {
                        true => 6513,
                        false => 6514,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6515,
                        false => 6516,
                    },
                    1 => Waterlogged switch {
                        true => 6517,
                        false => 6518,
                    },
                    2 => Waterlogged switch {
                        true => 6519,
                        false => 6520,
                    },
                    3 => Waterlogged switch {
                        true => 6521,
                        false => 6522,
                    },
                    4 => Waterlogged switch {
                        true => 6523,
                        false => 6524,
                    },
                    5 => Waterlogged switch {
                        true => 6525,
                        false => 6526,
                    },
                    6 => Waterlogged switch {
                        true => 6527,
                        false => 6528,
                    },
                    7 => Waterlogged switch {
                        true => 6529,
                        false => 6530,
                    },
                    8 => Waterlogged switch {
                        true => 6531,
                        false => 6532,
                    },
                    9 => Waterlogged switch {
                        true => 6533,
                        false => 6534,
                    },
                    10 => Waterlogged switch {
                        true => 6535,
                        false => 6536,
                    },
                    11 => Waterlogged switch {
                        true => 6537,
                        false => 6538,
                    },
                    12 => Waterlogged switch {
                        true => 6539,
                        false => 6540,
                    },
                    13 => Waterlogged switch {
                        true => 6541,
                        false => 6542,
                    },
                    14 => Waterlogged switch {
                        true => 6543,
                        false => 6544,
                    },
                    15 => Waterlogged switch {
                        true => 6545,
                        false => 6546,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6483 => new WarpedHangingSignBlock(Identifier, true, 0, true),
            6484 => new WarpedHangingSignBlock(Identifier, true, 0, false),
            6485 => new WarpedHangingSignBlock(Identifier, true, 1, true),
            6486 => new WarpedHangingSignBlock(Identifier, true, 1, false),
            6487 => new WarpedHangingSignBlock(Identifier, true, 2, true),
            6488 => new WarpedHangingSignBlock(Identifier, true, 2, false),
            6489 => new WarpedHangingSignBlock(Identifier, true, 3, true),
            6490 => new WarpedHangingSignBlock(Identifier, true, 3, false),
            6491 => new WarpedHangingSignBlock(Identifier, true, 4, true),
            6492 => new WarpedHangingSignBlock(Identifier, true, 4, false),
            6493 => new WarpedHangingSignBlock(Identifier, true, 5, true),
            6494 => new WarpedHangingSignBlock(Identifier, true, 5, false),
            6495 => new WarpedHangingSignBlock(Identifier, true, 6, true),
            6496 => new WarpedHangingSignBlock(Identifier, true, 6, false),
            6497 => new WarpedHangingSignBlock(Identifier, true, 7, true),
            6498 => new WarpedHangingSignBlock(Identifier, true, 7, false),
            6499 => new WarpedHangingSignBlock(Identifier, true, 8, true),
            6500 => new WarpedHangingSignBlock(Identifier, true, 8, false),
            6501 => new WarpedHangingSignBlock(Identifier, true, 9, true),
            6502 => new WarpedHangingSignBlock(Identifier, true, 9, false),
            6503 => new WarpedHangingSignBlock(Identifier, true, 10, true),
            6504 => new WarpedHangingSignBlock(Identifier, true, 10, false),
            6505 => new WarpedHangingSignBlock(Identifier, true, 11, true),
            6506 => new WarpedHangingSignBlock(Identifier, true, 11, false),
            6507 => new WarpedHangingSignBlock(Identifier, true, 12, true),
            6508 => new WarpedHangingSignBlock(Identifier, true, 12, false),
            6509 => new WarpedHangingSignBlock(Identifier, true, 13, true),
            6510 => new WarpedHangingSignBlock(Identifier, true, 13, false),
            6511 => new WarpedHangingSignBlock(Identifier, true, 14, true),
            6512 => new WarpedHangingSignBlock(Identifier, true, 14, false),
            6513 => new WarpedHangingSignBlock(Identifier, true, 15, true),
            6514 => new WarpedHangingSignBlock(Identifier, true, 15, false),
            6515 => new WarpedHangingSignBlock(Identifier, false, 0, true),
            6516 => new WarpedHangingSignBlock(Identifier, false, 0, false),
            6517 => new WarpedHangingSignBlock(Identifier, false, 1, true),
            6518 => new WarpedHangingSignBlock(Identifier, false, 1, false),
            6519 => new WarpedHangingSignBlock(Identifier, false, 2, true),
            6520 => new WarpedHangingSignBlock(Identifier, false, 2, false),
            6521 => new WarpedHangingSignBlock(Identifier, false, 3, true),
            6522 => new WarpedHangingSignBlock(Identifier, false, 3, false),
            6523 => new WarpedHangingSignBlock(Identifier, false, 4, true),
            6524 => new WarpedHangingSignBlock(Identifier, false, 4, false),
            6525 => new WarpedHangingSignBlock(Identifier, false, 5, true),
            6526 => new WarpedHangingSignBlock(Identifier, false, 5, false),
            6527 => new WarpedHangingSignBlock(Identifier, false, 6, true),
            6528 => new WarpedHangingSignBlock(Identifier, false, 6, false),
            6529 => new WarpedHangingSignBlock(Identifier, false, 7, true),
            6530 => new WarpedHangingSignBlock(Identifier, false, 7, false),
            6531 => new WarpedHangingSignBlock(Identifier, false, 8, true),
            6532 => new WarpedHangingSignBlock(Identifier, false, 8, false),
            6533 => new WarpedHangingSignBlock(Identifier, false, 9, true),
            6534 => new WarpedHangingSignBlock(Identifier, false, 9, false),
            6535 => new WarpedHangingSignBlock(Identifier, false, 10, true),
            6536 => new WarpedHangingSignBlock(Identifier, false, 10, false),
            6537 => new WarpedHangingSignBlock(Identifier, false, 11, true),
            6538 => new WarpedHangingSignBlock(Identifier, false, 11, false),
            6539 => new WarpedHangingSignBlock(Identifier, false, 12, true),
            6540 => new WarpedHangingSignBlock(Identifier, false, 12, false),
            6541 => new WarpedHangingSignBlock(Identifier, false, 13, true),
            6542 => new WarpedHangingSignBlock(Identifier, false, 13, false),
            6543 => new WarpedHangingSignBlock(Identifier, false, 14, true),
            6544 => new WarpedHangingSignBlock(Identifier, false, 14, false),
            6545 => new WarpedHangingSignBlock(Identifier, false, 15, true),
            6546 => new WarpedHangingSignBlock(Identifier, false, 15, false),
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
