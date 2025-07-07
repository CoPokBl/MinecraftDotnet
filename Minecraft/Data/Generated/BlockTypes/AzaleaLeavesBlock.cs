using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AzaleaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

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
    public string SoundType => "azalea_leaves";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:azalea_leaves";
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
    public string TranslationKey => "block.minecraft.azalea_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 504,
                        false => 505,
                    },
                    false => Waterlogged switch {
                        true => 506,
                        false => 507,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 508,
                        false => 509,
                    },
                    false => Waterlogged switch {
                        true => 510,
                        false => 511,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 512,
                        false => 513,
                    },
                    false => Waterlogged switch {
                        true => 514,
                        false => 515,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 516,
                        false => 517,
                    },
                    false => Waterlogged switch {
                        true => 518,
                        false => 519,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 520,
                        false => 521,
                    },
                    false => Waterlogged switch {
                        true => 522,
                        false => 523,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 524,
                        false => 525,
                    },
                    false => Waterlogged switch {
                        true => 526,
                        false => 527,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 528,
                        false => 529,
                    },
                    false => Waterlogged switch {
                        true => 530,
                        false => 531,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            504 => new AzaleaLeavesBlock(Identifier, 1, true, true),
            505 => new AzaleaLeavesBlock(Identifier, 1, true, false),
            506 => new AzaleaLeavesBlock(Identifier, 1, false, true),
            507 => new AzaleaLeavesBlock(Identifier, 1, false, false),
            508 => new AzaleaLeavesBlock(Identifier, 2, true, true),
            509 => new AzaleaLeavesBlock(Identifier, 2, true, false),
            510 => new AzaleaLeavesBlock(Identifier, 2, false, true),
            511 => new AzaleaLeavesBlock(Identifier, 2, false, false),
            512 => new AzaleaLeavesBlock(Identifier, 3, true, true),
            513 => new AzaleaLeavesBlock(Identifier, 3, true, false),
            514 => new AzaleaLeavesBlock(Identifier, 3, false, true),
            515 => new AzaleaLeavesBlock(Identifier, 3, false, false),
            516 => new AzaleaLeavesBlock(Identifier, 4, true, true),
            517 => new AzaleaLeavesBlock(Identifier, 4, true, false),
            518 => new AzaleaLeavesBlock(Identifier, 4, false, true),
            519 => new AzaleaLeavesBlock(Identifier, 4, false, false),
            520 => new AzaleaLeavesBlock(Identifier, 5, true, true),
            521 => new AzaleaLeavesBlock(Identifier, 5, true, false),
            522 => new AzaleaLeavesBlock(Identifier, 5, false, true),
            523 => new AzaleaLeavesBlock(Identifier, 5, false, false),
            524 => new AzaleaLeavesBlock(Identifier, 6, true, true),
            525 => new AzaleaLeavesBlock(Identifier, 6, true, false),
            526 => new AzaleaLeavesBlock(Identifier, 6, false, true),
            527 => new AzaleaLeavesBlock(Identifier, 6, false, false),
            528 => new AzaleaLeavesBlock(Identifier, 7, true, true),
            529 => new AzaleaLeavesBlock(Identifier, 7, true, false),
            530 => new AzaleaLeavesBlock(Identifier, 7, false, true),
            531 => new AzaleaLeavesBlock(Identifier, 7, false, false),
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
