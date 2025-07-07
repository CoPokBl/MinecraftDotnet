using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mangrove_leaves";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.mangrove_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 476,
                        false => 477,
                    },
                    false => Waterlogged switch {
                        true => 478,
                        false => 479,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 480,
                        false => 481,
                    },
                    false => Waterlogged switch {
                        true => 482,
                        false => 483,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 484,
                        false => 485,
                    },
                    false => Waterlogged switch {
                        true => 486,
                        false => 487,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 488,
                        false => 489,
                    },
                    false => Waterlogged switch {
                        true => 490,
                        false => 491,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 492,
                        false => 493,
                    },
                    false => Waterlogged switch {
                        true => 494,
                        false => 495,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 496,
                        false => 497,
                    },
                    false => Waterlogged switch {
                        true => 498,
                        false => 499,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 500,
                        false => 501,
                    },
                    false => Waterlogged switch {
                        true => 502,
                        false => 503,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            476 => new MangroveLeavesBlock(Identifier, 1, true, true),
            477 => new MangroveLeavesBlock(Identifier, 1, true, false),
            478 => new MangroveLeavesBlock(Identifier, 1, false, true),
            479 => new MangroveLeavesBlock(Identifier, 1, false, false),
            480 => new MangroveLeavesBlock(Identifier, 2, true, true),
            481 => new MangroveLeavesBlock(Identifier, 2, true, false),
            482 => new MangroveLeavesBlock(Identifier, 2, false, true),
            483 => new MangroveLeavesBlock(Identifier, 2, false, false),
            484 => new MangroveLeavesBlock(Identifier, 3, true, true),
            485 => new MangroveLeavesBlock(Identifier, 3, true, false),
            486 => new MangroveLeavesBlock(Identifier, 3, false, true),
            487 => new MangroveLeavesBlock(Identifier, 3, false, false),
            488 => new MangroveLeavesBlock(Identifier, 4, true, true),
            489 => new MangroveLeavesBlock(Identifier, 4, true, false),
            490 => new MangroveLeavesBlock(Identifier, 4, false, true),
            491 => new MangroveLeavesBlock(Identifier, 4, false, false),
            492 => new MangroveLeavesBlock(Identifier, 5, true, true),
            493 => new MangroveLeavesBlock(Identifier, 5, true, false),
            494 => new MangroveLeavesBlock(Identifier, 5, false, true),
            495 => new MangroveLeavesBlock(Identifier, 5, false, false),
            496 => new MangroveLeavesBlock(Identifier, 6, true, true),
            497 => new MangroveLeavesBlock(Identifier, 6, true, false),
            498 => new MangroveLeavesBlock(Identifier, 6, false, true),
            499 => new MangroveLeavesBlock(Identifier, 6, false, false),
            500 => new MangroveLeavesBlock(Identifier, 7, true, true),
            501 => new MangroveLeavesBlock(Identifier, 7, true, false),
            502 => new MangroveLeavesBlock(Identifier, 7, false, true),
            503 => new MangroveLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = int.Parse(properties["distance"].GetString()),
            Persistent = properties["persistent"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
